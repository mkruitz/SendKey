using Core;
using GUI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InMemoryStoreTests : StoreBaseTests
    {
        private IStore _store;

        [SetUp]
        public void SetUp()
        {
            _store = new InMemoryStore();
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
