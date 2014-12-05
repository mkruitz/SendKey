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
        private const string StoreLocation = "store.xml";

        public IList<ScanCommmands> AllCommands { get { return ReadFromFile(); } }

        private IList<ScanCommmands> ReadFromFile()
        {
            var commands = new List<ScanCommmands>();
            if (!File.Exists(StoreLocation))
                return commands;

            var document = XDocument.Load(StoreLocation);
            return ListFromXml(document.Root);
        }

        private XElement ToXml(IEnumerable<ScanCommmands> allCommands)
        {
            return new XElement("Commands", allCommands.Select(ToXml));
        }

        private XElement ToXml(ScanCommmands scanCommmands)
        {
            var flatttendKeysToSend = String.Join(Environment.NewLine, scanCommmands.KeysToSend);
            return new XElement(
                "ScanCommand",
                new XAttribute("DisplayName", scanCommmands.DisplayName),
                new XAttribute("ProcessName", scanCommmands.ProcessName),
                new XAttribute("TitleStartsWith", scanCommmands.TitleStartsWith),
                flatttendKeysToSend
                );
        }

        private IList<ScanCommmands> ListFromXml(XElement element)
        {
            return element.Elements("ScanCommand")
                .Select(ItemFromXml)
                .ToList();
        }

        private ScanCommmands ItemFromXml(XElement element)
        {
            var keysToSend =
                element.Value.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
            return new ScanCommmands{
                DisplayName = element.Attribute("DisplayName").Value,
                ProcessName = element.Attribute("ProcessName").Value,
                TitleStartsWith = element.Attribute("TitleStartsWith").Value,
                KeysToSend = keysToSend
            };
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
    }
}