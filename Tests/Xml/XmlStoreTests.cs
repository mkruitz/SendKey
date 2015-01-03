using System.Linq;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests.Xml
{
    [TestFixture]
    public class XmlStoreTests : StoreBaseTests
    {
        private IStore store;

        [SetUp]
        public void SetUp()
        {
            store = new XmlStore();
            store.Reset();
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
        public void CreateNewStore_AddOneItemWithoutKeysToSend_OneItemInStore()
        {
            var item = CreateScanCommmand();
            item.KeysToSend.Clear();

            store.Save(item);

            Assert.AreEqual(1, store.AllCommands.Count);
            Assert.AreEqual(item, store.AllCommands[0]);
        }

        [Test]
        public void CreateSecondStoreWithXmlOnSameLocation_AddOneItem_ReadOneItemFromSecondStore()
        {
            CreateNewStore_AddOneItem_OneItemInStore(store);

            var secondStore = new XmlStore();
            Assert.AreEqual(1, secondStore.AllCommands.Count);
        }

        [Test]
        public void CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList()
        {
            CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList(store);
        }

        [Test]
        public void CreateNewStore_TwoDifferentItemsSameInternals_OneItem()
        {
            var firstItem = CreateScanCommmand();
            var secondItem = CreateScanCommmand();
            secondItem.Id = firstItem.Id;

            store.Save(firstItem);
            store.Save(secondItem);

            Assert.AreEqual(firstItem, secondItem);
            Assert.AreEqual(1, store.AllCommands.Count);
        }
    }
}
