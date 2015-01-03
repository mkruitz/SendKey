using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests.Xml
{
    [TestFixture]
    public class XmlStoreVersionTests
    {
        private StringBuilder text;

        [SetUp]
        public void SetUp()
        {
            text = new StringBuilder();
            text.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        }

        [Test]
        public void EmptyCommandElement_ReadStore_Empty()
        {
            text.AppendLine("<Commands>");
            text.AppendLine("</Commands>");
            SaveText();

            AssertEmptyExistingStore();
        }

        [Test]
        public void HasOneScanCommandElement_ReadStore_ReturnOneElement()
        {
            text.AppendLine("<Commands>");
            AddScanCommand(text);
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();
            Assert.IsTrue(store.Exists());
            Assert.AreEqual(new Version(1, 0), store.GetStoreVersion());
            Assert.AreEqual(1, store.AllCommands.Count());
            AssertSingleItem(store.AllCommands.First());
        }

        [Test]
        public void HasTwoScanCommandElement_ReadStore_ReturnTwoElements()
        {
            text.AppendLine("<Commands>");
            AddScanCommand(text);
            AddScanCommand(text);
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();
            Assert.IsTrue(store.Exists());
            Assert.AreEqual(2, store.AllCommands.Count());
        }

        [Test]
        public void HasNoScanCommandElementWithVersion_ReadStore_ReturnCorrectVersion()
        {
            text.AppendLine("<Commands Version=\"1.1\">");
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();
            Assert.IsTrue(store.Exists());
            Assert.AreEqual(new Version(1, 1), store.GetStoreVersion());
            Assert.AreEqual(0, store.AllCommands.Count());
        }

        [Test]
        public void HasScanCommandsWithId_ReadStore_ReturnIds()
        {
            text.AppendLine("<Commands Version=\"1.1\">");
            AddScanCommand(text, "00000000-0000-0000-0000-000000000000");
            AddScanCommand(text, "7A6BF285-BBD7-4F72-AA8F-7BA6FF85D6BD");
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();
 
            AssertId("00000000-0000-0000-0000-000000000000", store.AllCommands[0]);
            AssertId("7A6BF285-BBD7-4F72-AA8F-7BA6FF85D6BD", store.AllCommands[1]);
        }

        [Test]
        public void HasOldVersion_ReadStore_GeneratesUniqueIds()
        {
            text.AppendLine("<Commands>");
            AddScanCommand(text);
            AddScanCommand(text);
            AddScanCommand(text);
            AddScanCommand(text);
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();

            var ids = new HashSet<Guid>(
                store.AllCommands.Select(command => command.Id)
            );

            Assert.AreEqual(4, ids.Count);
        }

        [Test]
        public void HasOldVersion_SaveStore_GeneratesdUniqueIdsAreStored()
        {
            text.AppendLine("<Commands>");
            AddScanCommand(text);
            AddScanCommand(text);
            AddScanCommand(text);
            AddScanCommand(text);
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();
            var idsBeforeSave = new HashSet<Guid>(
                store.AllCommands.Select(command => command.Id)
            );

            store.Save(store.AllCommands.First());

            var idsAfterSave = new HashSet<Guid>(
                store.AllCommands.Select(command => command.Id)
            );

            Assert.IsTrue(idsBeforeSave.IsSubsetOf(idsAfterSave));
            Assert.IsTrue(idsAfterSave.IsSubsetOf(idsBeforeSave));
        }

        private void AssertId(string expectedId, ScanCommmands actualCommand)
        {
            Assert.AreEqual(expectedId, actualCommand.Id.ToString().ToUpper());
        }

        private void AddScanCommand(StringBuilder sb, String id = "")
        {
            id = String.IsNullOrEmpty(id) ? String.Empty : String.Format("Id=\"{0}\"", id);
            sb.AppendFormat("<ScanCommand {0} DisplayName=\"A\" ProcessName=\"B\" TitleStartsWith=\"C\">", id);
            sb.AppendLine();
            sb.AppendLine("<KeysToSend>D</KeysToSend>");
            sb.AppendLine("<KeysToSend>E</KeysToSend>");
            sb.AppendLine("</ScanCommand>");
        }

        private void SaveText()
        {
            File.WriteAllText(XmlStore.StoreLocation, text.ToString());
        }

        private static void AssertSingleItem(ScanCommmands scanCommmands)
        {
            Assert.AreEqual("A", scanCommmands.DisplayName);
            Assert.AreEqual("B", scanCommmands.ProcessName);
            Assert.AreEqual("C", scanCommmands.TitleStartsWith);
            Assert.AreEqual("D", scanCommmands.KeysToSend[0]);
            Assert.AreEqual("E", scanCommmands.KeysToSend[1]);
        }

        private void AssertEmptyExistingStore()
        {
            var store = new XmlStore();
            Assert.IsTrue(store.Exists());
            Assert.IsFalse(store.AllCommands.Any());
        }
    }
}
