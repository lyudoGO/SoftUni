namespace CustomLinkedList.Tests.CustomLinkedListTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CustomLinkedList;

    [TestClass]
    public class CustomLinkedListUnitTest
    {
        private DynamicList<int> intDynamicList;
        private DynamicList<string> stringDynamicList;

        [TestInitialize]
        public void InitializeDynamicList()
        {
            intDynamicList = new DynamicList<int>();
            stringDynamicList = new DynamicList<string>();
        }

        [TestMethod]
        public void ShouldCountBeZeroAtInitalize()
        {
            intDynamicList = new DynamicList<int>();
            Assert.AreEqual(0, intDynamicList.Count, "List count must be zero on initalize");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListShouldGetOrSetElementAtSpecifiedPosition()
        {
            intDynamicList = new DynamicList<int>();
            intDynamicList[0] = 100;
            Assert.AreEqual(100, intDynamicList[0]);

            intDynamicList[0] = 200;
            Assert.AreEqual(200, intDynamicList[0]);
        }

        [TestMethod]
        public void ListShouldAddElementAtEnd()
        {
            intDynamicList = new DynamicList<int>();
            intDynamicList.Add(100);
            Assert.AreEqual(100, intDynamicList[0], "List cannot add element");

            intDynamicList.Add(200);
            Assert.AreEqual(200, intDynamicList[1], "List cannot add element at the end");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListShouldRemovesAndReturnElementOnSpecifiedIndex()
        {
            intDynamicList = new DynamicList<int>();
            intDynamicList[0] = 100;
            Assert.IsTrue(intDynamicList.RemoveAt(0) == 100);
        }

        [TestMethod]
        public void ListShouldRemoveSpecifiedItemAndReturnItsIndex()
        {
            intDynamicList = new DynamicList<int>();
            intDynamicList.Add(100);
            Assert.AreEqual(0, intDynamicList.Remove(100), "List cannot remove specified element");
            //Assert.AreEqual(-1, intDynamicList.Remove(200), "List cannot remove specified element");
        }

        [TestMethod]
        public void ListShouldSearchesForGivenElement()
        {
            intDynamicList = new DynamicList<int>();
            intDynamicList.Add(100);
            intDynamicList.Add(200);
            Assert.AreEqual(1, intDynamicList.IndexOf(200), "List cannot search at specified index");
        }

        [TestMethod]
        public void ListShouldChecksIfSpecifiedElementExists()
        {
            intDynamicList = new DynamicList<int>();
            intDynamicList.Add(100);
            Assert.IsTrue(true == intDynamicList.Contains(100), "List cannot check if specified element exists");
        }
    }
}
