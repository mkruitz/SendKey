using System.IO;
using System.Linq;
using System.Text;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class XmlStoreVersionTests : StoreBaseTests
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
            text.AppendLine("<ScanCommand DisplayName=\"A\" ProcessName=\"B\" TitleStartsWith=\"C\">");
            text.AppendLine("<KeysToSend>D</KeysToSend>");
            text.AppendLine("<KeysToSend>E</KeysToSend>");
            text.AppendLine("</ScanCommand>");
            text.AppendLine("</Commands>");
            SaveText();

            var store = new XmlStore();
            Assert.IsTrue(store.Exists());
            Assert.AreEqual(1, store.AllCommands.Count());
            AssertSingleItem(store.AllCommands.First());
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
