using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Core;

namespace GUI
{
    public class XmlStore : IStore
    {
        private class Stored
        {
            public Stored()
            {
                Commands = new List<ScanCommmands>();
            }

            public Version Version { get; set; }
            public IList<ScanCommmands> Commands { get; set; } 
        }

        public const string StoreLocation = "store.xml";

        public IList<ScanCommmands> AllCommands { get { return ReadFromFile().Commands; } }
        
        public bool Exists()
        {
            return File.Exists(StoreLocation);
        }

        public void Reset()
        {
            File.Delete(StoreLocation);
        }

        private Stored ReadFromFile()
        {
            if (!File.Exists(StoreLocation))
                return new Stored();

            var document = XDocument.Load(StoreLocation);
            return FromXml(document.Root);
        }

        private Stored FromXml(XElement element)
        {
            return new Stored
            {
                Commands = element.Elements("ScanCommand")
                                .Select(ItemFromXml)
                                .ToList(),
                Version = ExtractVersion(element)
            };
        }

        private Version ExtractVersion(XElement element)
        {
            var attribute = element.Attribute("Version");
            return attribute == null
                ? new Version(1, 0)
                : Version.Parse(attribute.Value);
        }

        private ScanCommmands ItemFromXml(XElement element)
        {
            return new ScanCommmands{
                DisplayName = element.Attribute("DisplayName").Value,
                ProcessName = element.Attribute("ProcessName").Value,
                TitleStartsWith = element.Attribute("TitleStartsWith").Value,
                KeysToSend = element.Elements("KeysToSend").Select(KeysToSendFromXml).ToList()
            };
        }

        private String KeysToSendFromXml(XElement element)
        {
            return element.Value;
        }

        public void Save(ScanCommmands scanCommmands)
        {
            var list = AllCommands;

            if (!list.Contains(scanCommmands))
            {
                list.Insert(0, scanCommmands);
                ToXml(list)
                    .Save(StoreLocation, SaveOptions.None);
            }
        }

        private XElement ToXml(IEnumerable<ScanCommmands> allCommands)
        {
            return new XElement("Commands", allCommands.Select(ToXml));
        }

        private XElement ToXml(ScanCommmands scanCommmands)
        {
            return new XElement(
                "ScanCommand",
                new XAttribute("DisplayName", scanCommmands.DisplayName),
                new XAttribute("ProcessName", scanCommmands.ProcessName),
                new XAttribute("TitleStartsWith", scanCommmands.TitleStartsWith),
                scanCommmands.KeysToSend.Select(ToXml)
                );
        }

        private XElement ToXml(String keysToSend)
        {
            return new XElement("KeysToSend", keysToSend);
        }

        public Version GetStoreVersion()
        {
            return ReadFromFile().Version;
        }
    }
}