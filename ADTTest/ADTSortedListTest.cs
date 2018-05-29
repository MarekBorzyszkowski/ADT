using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADTList;

namespace ADTTest {
    [TestClass]
    public class ADTSortedListTest {
        [TestMethod]
        [TestCategory("ListSorted")]
        public void EmptyListIsSorted() {
            // Arrange
            var emptyList = new ADTSortedList<int>();
            // Act
            bool isSortedList = emptyList.isSorted();
            // Assert
            Assert.AreEqual(true, isSortedList);
        }
        [TestMethod]
        [TestCategory("ListSorted")]
        public void FiveElemListIsSorted() {
            // Arrange
            var fiveElemList = new ADTSortedList<int>()
                .InsertSorted(3)
                .InsertSorted(5)
                .InsertSorted(4)
                .InsertSorted(1)
                .InsertSorted(6);
            // Act
            bool isSortedList = fiveElemList.isSorted();
            // Assert
            Assert.AreEqual(true, isSortedList);
        }
        [TestMethod]
        [TestCategory("ListSorted")]
        public void FiveElemListSort() {
            // Arrange
            var fiveElemList = (ADTSortedList<int>) new ADTSortedList<int>()
                .AddLast(3)
                .AddLast(5)
                .AddLast(4)
                .AddLast(1)
                .AddLast(6);
            // Act
            bool isSortedBefore = fiveElemList.isSorted();
            fiveElemList.Sort();
            bool isSortedAfter = fiveElemList.isSorted();
            // Assert
            Assert.AreEqual(false, isSortedBefore);
            Assert.AreEqual(true, isSortedAfter);
        }
    }
}
