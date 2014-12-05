using GUI;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class InMemoryStoreTests : StoreBaseTests
    {
        [SetUp]
        public void SetUp()
        {
            Store = new InMemoryStore();
        }
    }
}
