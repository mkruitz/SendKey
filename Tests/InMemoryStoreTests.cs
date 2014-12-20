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
