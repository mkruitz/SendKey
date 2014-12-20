using System.IO;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class XmlStoreTests : StoreBaseTests
    {
        private IStore store;

        [SetUp]
        public void SetUp()
        {
            store = new XmlStore();
            if (File.Exists("store.xml"))
            {
                File.Delete("store.xml");
            }
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
            CreateNewStore_TwoDifferentItemsSameInternals_OneItem(store);
        }
    }
}
