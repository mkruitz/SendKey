using System;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests
{
    public abstract class StoreBaseTests
    {
        protected InMemoryStore Store;

        [Test]
        public void CreateNewStore_GetAllCommands_NonInStore()
        {
            var store = new InMemoryStore();

            Assert.AreEqual(0, store.AllCommands.Count);
        }

        [Test]
        public void CreateNewStore_AddOneItem_OneItemInStore()
        {
            Store = new InMemoryStore();

            var item = CreateScanCommmand();

            Store.Save(item);

            Assert.AreEqual(1, Store.AllCommands.Count);
            Assert.IsTrue(item.Equals(Store.AllCommands[0]));
        }

        [Test]
        public void CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList()
        {
            var firstItem = CreateScanCommmand("1");
            var secondItem = CreateScanCommmand("2");

            Store.Save(firstItem);
            Store.Save(secondItem);

            Assert.AreEqual(2, Store.AllCommands.Count);
            Assert.IsTrue(secondItem.Equals(Store.AllCommands[0]));
            Assert.IsTrue(firstItem.Equals(Store.AllCommands[1]));
        }

        [Test]
        public void CreateNewStore_TwoDifferentItemsSameInternals_OneItem()
        {
            var firstItem = CreateScanCommmand();
            var secondItem = CreateScanCommmand();

            Store.Save(firstItem);
            Store.Save(secondItem);

            Assert.IsTrue(firstItem.Equals(secondItem));
            Assert.AreEqual(1, Store.AllCommands.Count);
        }

        private static ScanCommmands CreateScanCommmand(String postFix = "")
        {
            return ScanCommandsTests.SetProperties(new ScanCommmands(), postFix);
        }
    }
}