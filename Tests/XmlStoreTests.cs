using System.IO;
using Core;
using GUI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class XmlStoreTests : StoreBaseTests
    {
        private IStore _store;

        [SetUp]
        public void SetUp()
        {
            _store = new XmlStore();
            if (File.Exists("store.xml"))
            {
                File.Delete("store.xml");
            }
        }

        [Test]
        public void CreateNewStore_GetAllCommands_NonInStore()
        {
            CreateNewStore_GetAllCommands_NonInStore(_store);
        }

        [Test]
        public void CreateNewStore_AddOneItem_OneItemInStore()
        {
            CreateNewStore_AddOneItem_OneItemInStore(_store);
        }

        [Test]
        public void CreateSecondStoreWithXmlOnSameLocation_AddOneItem_ReadOneItemFromSecondStore()
        {
            CreateNewStore_AddOneItem_OneItemInStore(_store);

            var secondStore = new XmlStore();
            Assert.AreEqual(1, secondStore.AllCommands.Count);
        }

        [Test]
        public void CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList()
        {
            CreateNewStore_TwoDifferentItems_TwoItemsInStoreLastAddedItemIsFirstInList(_store);
        }

        [Test]
        public void CreateNewStore_TwoDifferentItemsSameInternals_OneItem()
        {
            CreateNewStore_TwoDifferentItemsSameInternals_OneItem(_store);
        }
    }
}
