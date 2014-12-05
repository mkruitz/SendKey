using System;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InMemoryStoreTests
    {
        [Test]
        public void CreateNewStore_GetAllCommands_NonInMemory()
        {
            var store = new InMemoryStore();

            Assert.AreEqual(0, store.AllCommands.Count);
        }

        [Test]
        public void CreateNewStore_AddOneItem_OneItemInMemory()
        {
            var store = new InMemoryStore();

            var item = CreateScanCommmand();

            store.Save(item);

            Assert.AreEqual(1, store.AllCommands.Count);
            Assert.IsTrue(item.Equals(store.AllCommands[0]));
        }

        [Test]
        public void CreateNewStore_TwoDifferentItems_TwoItemsInMemoryLastAddedItemIsFirstInList()
        {
            var store = new InMemoryStore();

            var firstItem = CreateScanCommmand("1");
            var secondItem = CreateScanCommmand("2");

            store.Save(firstItem);
            store.Save(secondItem);

            Assert.AreEqual(2, store.AllCommands.Count);
            Assert.IsTrue(secondItem.Equals(store.AllCommands[0]));
            Assert.IsTrue(firstItem.Equals(store.AllCommands[1]));
        }

        [Test]
        public void CreateNewStore_TwoDifferentItemsSameInternals_OneItem()
        {
            var store = new InMemoryStore();

            var firstItem = CreateScanCommmand();
            var secondItem = CreateScanCommmand();

            store.Save(firstItem);
            store.Save(secondItem);

            Assert.IsTrue(firstItem.Equals(secondItem));
            Assert.AreEqual(1, store.AllCommands.Count);
        }

        private static ScanCommmands CreateScanCommmand(String postFix = "")
        {
            return ScanCommandsTests.SetProperties(new ScanCommmands(), postFix);
        }
    }
}
