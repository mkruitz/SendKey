using System.Linq;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InMemoryStoreTests : StoreBaseTests
    {
        private IStore store;

        [SetUp]
        public void SetUp()
        {
            store = new InMemoryStore();
        }

        [Test]
        public void NewStore_Exists_False()
        {
            Assert.IsFalse(store.Exists());
        }

        [Test]
        public void NewStoreAddOneItem_Exists_True()
        {
            store.Save(CreateScanCommmand());
            Assert.IsTrue(store.Exists());
        }

        [Test]
        public void NonExistingStore_Reset_DoesNotThrow()
        {
            Assert.DoesNotThrow(store.Reset);
        }

        [Test]
        public void ExistingStore_Reset_StoreIsEmpty()
        {
            store.Save(CreateScanCommmand());

            store.Reset();
            Assert.IsFalse(store.Exists());
            Assert.IsFalse(store.AllCommands.Any());
        }

        [Test]
        public void CreateNewStore_GetAllCommands_NonInStore()
        {
            CreateNewStore_GetAllCommands_NonInStore(store);
        }

        [Test]
        public void CreateNewStore_AddOneItem_OneItemInStore()
        {
            CreateNewStore_AddOneItem_OneItemInStore(store);
        }

        [Test]
        public void CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList()
        {
            CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList(store);
        }

        [Test]
        public void CreateNewStore_TwoDifferentItemsSameInternals_OneItem()
        {
            CreateNewStore_TwoDifferentItemsSameInternals_OneItem(store);
        }
    }
}
