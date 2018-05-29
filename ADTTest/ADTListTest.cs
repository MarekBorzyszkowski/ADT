using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADTList;
using System.Collections.Generic;

namespace ADTTest {
    [TestClass]
    public class ADTListTest {
        [TestMethod]
        [TestCategory("List")]
        public void EmptyADTListCountTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act

            // Assert
            Assert.AreEqual(0, emptyList.Count);
        }

        [TestMethod]
        [TestCategory("List")]
        public void AddLastToEmptyADTListCountTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.AddLast(5);
            // Assert
            Assert.AreEqual(1, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void AddLastToOneElemADTListCountTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.AddLast(5).AddLast(6);
            // Assert
            Assert.AreEqual(2, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void AddLastToEmptyADTListHeadTailTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.AddLast(5);
            // Assert
            Assert.AreNotEqual(null, emptyList.Head);
            Assert.AreSame(emptyList.Head, emptyList.Tail);
        }

        [TestMethod]
        [TestCategory("List")]
        public void AddLastToOneElemADTListHeadTailTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.AddLast(5).AddLast(6);
            // Assert
            Assert.AreNotSame(emptyList.Head, emptyList.Tail);
            Assert.AreSame(emptyList.Head, emptyList.Tail.Previous);
            Assert.AreSame(emptyList.Head.Next, emptyList.Tail);
        }
        [TestMethod]
        [TestCategory("List")]
        public void AddFirstToEmptyElemADTListCountTest()
        {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.AddFirst(5);
            // Assert
            Assert.AreEqual(1, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void AddFirstToEmptyElemADTListHeadTailTest()
        {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.AddFirst(5);
            // Assert
            Assert.AreSame(emptyList.Head, emptyList.Tail);
        }
        [TestMethod]
        [TestCategory("List")]
        public void AddFirstToOneElemADTListHeadTailTest()
        {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.AddFirst(5).AddFirst(6);
            // Assert
            Assert.AreNotSame(emptyList.Head, emptyList.Tail);
        }
        [TestMethod]
        [TestCategory("List")]
        public void DeleteLastEmptyADTListHeadTailCountTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.DeleteLast();
            // Assert
            Assert.AreEqual(null, emptyList.Head);
            Assert.AreEqual(null, emptyList.Tail);
            Assert.AreEqual(0, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void DeleteLastOneElemADTListHeadTailCountTest() {
            // Arrange
            var emptyList = new ADTList<int>().AddLast(1);
            // Act
            emptyList.DeleteLast();
            // Assert
            Assert.AreEqual(null, emptyList.Head);
            Assert.AreEqual(null, emptyList.Tail);
            Assert.AreEqual(0, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void DeleteLastTwoElemADTListHeadTailCountTest() {
            // Arrange
            var emptyList = new ADTList<int>().AddLast(1).AddLast(2);
            // Act
            emptyList.DeleteLast();
            // Assert 
            Assert.AreSame(emptyList.Head, emptyList.Tail);
            Assert.AreEqual(1, emptyList.Head.Data);
            Assert.AreEqual(1, emptyList.Tail.Data);
            Assert.AreEqual(1, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void DeleteFirstEmptyADTListHeadTailCountTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            // Act
            emptyList.DeleteFirst();
            // Assert
            Assert.AreEqual(null, emptyList.Head);
            Assert.AreEqual(null, emptyList.Tail);
            Assert.AreEqual(0, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void DeleteFirstOneElemADTListHeadTailCountTest() {
            // Arrange
            var emptyList = new ADTList<int>().AddLast(1);
            // Act
            emptyList.DeleteFirst();
            // Assert
            Assert.AreEqual(null, emptyList.Head);
            Assert.AreEqual(null, emptyList.Tail);
            Assert.AreEqual(0, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void DeleteFirstTwoElemADTListHeadTailCountTest() {
            // Arrange
            var emptyList = new ADTList<int>().AddLast(1).AddLast(2);
            // Act
            emptyList.DeleteFirst();
            // Assert 
            Assert.AreSame(emptyList.Head, emptyList.Tail);
            Assert.AreEqual(2, emptyList.Head.Data);
            Assert.AreEqual(2, emptyList.Tail.Data);
            Assert.AreEqual(1, emptyList.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public void DeleteSelectedNodeInADTListTest()
        {
            // Arrange
            var emptyList = new ADTList<int>();
            for (int i = 1; i < 5; i++)
            {
                emptyList.AddLast(i);
            }
            // Act
            emptyList.DeleteSelected(3);
            // Assert 
            Assert.AreEqual(2, emptyList.Tail.Previous.Data);
            Assert.AreSame(emptyList.Tail, emptyList.Head.Next.Next);
        }
        [TestMethod]
        [TestCategory("List")]
        public void FindMinimumNodeInADTListTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            for (int i = 1; i < 5; i++)
            {
                emptyList.AddLast(i);
            }
            // Act
            ADTList<int>.Node n = emptyList.FindMinimum(
                Comparer<int>.Create(
                    (x,y) => (x>y) ? 1 : (x<y) ? -1 : 0)
                   );
            
            // Assert 
            Assert.AreEqual(1, n.Data);
        }
        [TestMethod]
        [TestCategory("ListFind")]
        public void FindMinimumReverseOrderNodeInADTListTest() {
            // Arrange
            var emptyList = new ADTList<int>();
            for (int i = 1; i < 5; i++)
            {
                emptyList.AddLast(i);
            }
            // Act
            ADTList<int>.Node n = emptyList.FindMinimum(
                Comparer<int>.Create(
                    (x, y) => (x < y) ? 1 : (x > y) ? -1 : 0)
                   );

            // Assert 
            Assert.AreEqual(4, n.Data);
        }

    }
}
