using System.Collections.Generic;
using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ScanCommandsTests
    {
        [Test]
        public void SameItem_EqualsToItSelfs_IsEqual()
        {
            var item = new ScanCommmands();
            SetProperties(item, "");

            Assert.IsTrue(item.Equals(item));
        }

        [Test]
        public void SameItem_EqualsToNull_NotEqual()
        {
            var item = new ScanCommmands();
            SetProperties(item, "");

            Assert.IsFalse(item.Equals(null));
        }

        [Test]
        public void TwoDifferentItems_Equals_NotEqual()
        {
            var firstItem = new ScanCommmands();
            SetProperties(firstItem, "1");

            var secondItem = new ScanCommmands();
            SetProperties(secondItem, "2");

            Assert.IsFalse(firstItem.Equals(secondItem));
            Assert.AreNotEqual(firstItem.GetHashCode(), secondItem.GetHashCode());
        }

        [Test]
        public void TwoDifferentObjectsWithSameInternals_Equals_IsEqual()
        {
            var firstItem = new ScanCommmands();
            SetProperties(firstItem, "");

            var secondItem = new ScanCommmands();
            SetProperties(secondItem, "");

            Assert.IsTrue(firstItem.Equals(secondItem));
            Assert.AreEqual(firstItem.GetHashCode(), secondItem.GetHashCode());
        }
        
        public static ScanCommmands SetProperties(ScanCommmands item, string postfix)
        {
            item.DisplayName = "DisplayName" + postfix;
            item.KeysToSend = new List<string> { "KeysToSend" + postfix };
            item.ProcessName = "ProcessName" + postfix;
            item.TitleStartsWith = "TitleStartsWith" + postfix;
            return item;
        }
    }
}