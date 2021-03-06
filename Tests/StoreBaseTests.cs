using System;
using Core;
using NUnit.Framework;

namespace Tests
{
    public abstract class StoreBaseTests
    {
        protected void CreateNewStore_GetAllCommands_NonInStore(IStore store)
        {
            Assert.AreEqual(0, store.AllCommands.Count);
        }

        protected void CreateNewStore_AddOneItem_OneItemInStore(IStore store)
        {
            var item = CreateScanCommmand();

            store.Save(item);

            Assert.AreEqual(1, store.AllCommands.Count);
            Assert.AreEqual(item, store.AllCommands[0]);
        }

        protected void CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList(IStore store)
        {
            var firstItem = CreateScanCommmand("1");
            var secondItem = CreateScanCommmand("2");

            store.Save(firstItem);
            store.Save(secondItem);

            Assert.AreEqual(2, store.AllCommands.Count);
            Assert.AreEqual(secondItem, store.AllCommands[0]);
            Assert.AreEqual(firstItem, store.AllCommands[1]);
        }

        protected void CreateNewStore_TwoDifferentItemsSameInternals_OneItem(IStore store)
        {
            var firstItem = CreateScanCommmand();
            var secondItem = CreateScanCommmand();

            store.Save(firstItem);
            store.Save(secondItem);

            Assert.AreEqual(firstItem, secondItem);
            Assert.AreEqual(1, store.AllCommands.Count);
        }

        protected ScanCommmands CreateScanCommmand(String postFix = "")
        {
            return ScanCommandsTests.SetProperties(new ScanCommmands(), postFix);
        }
    }
}