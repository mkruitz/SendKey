using System;
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
            Assert.AreEqual(new Version(0, 0), store.GetStoreVersion());
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
        public void HasOneScanCommandElementWithVersion_ReadStore_ReturnOneElement()
        {
            text.AppendLine("<Commands Version=\"12.3\">");
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();
            Assert.IsTrue(store.Exists());
            Assert.AreEqual(new Version(12, 3), store.GetStoreVersion());
            Assert.AreEqual(0, store.AllCommands.Count());
        }
        
        private void AddScanCommand(StringBuilder sb)
        {
            sb.AppendLine("<ScanCommand DisplayName=\"A\" ProcessName=\"B\" TitleStartsWith=\"C\">");
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
