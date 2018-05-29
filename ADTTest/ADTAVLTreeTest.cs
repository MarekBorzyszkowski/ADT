using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADTAVLTree;

namespace ADTTest {
    [TestClass]
    public class ADTAVLTreeTest {
        [TestMethod]
        [TestCategory("AVLTree")]
        public void EmptyTreeContainsNode() {
            // Arrange
            var emptyTree = new ADTAVLTree<int>();
            // Act
            bool contains = emptyTree.Contains(1);
            // Assert
            Assert.AreEqual(false, contains);
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        public void OneElemTreeContainsNode() {
            // Arrange
            var oneElemTree = new ADTAVLTree<int>().Add(1);
            // Act
            bool contains = oneElemTree.Contains(1);
            // Assert
            Assert.AreEqual(true, contains);
        }
        [TestMethod]
        [TestCategory("AVLTree")]
        public void EmptyTreeAddDeleteContainsNode() {
            // Arrange
            var oneElemTree = new ADTAVLTree<int>().Add(1).Delete(1);
            // Act
            bool contains = oneElemTree.Contains(1);
            // Assert
            Assert.AreEqual(false, contains);
        }
        [TestMethod]
        [TestCategory("AVLTree")]
        public void FiveElemTreeContainsNode() {
            // Arrange
            var fiveElemTree = new ADTAVLTree<int>()
                .Add(1).Add(2).Add(3).Add(4).Add(5);
            // Act
            bool contains = fiveElemTree.Contains(5);
            int height = fiveElemTree.Height();
            // Assert
            Assert.AreEqual(true, contains);
            Assert.AreEqual(3, height);
        }
        [TestMethod]
        [TestCategory("AVLTree")]
        public void SameElemTreeContainsNode() {
            // Arrange
            var fiveElemTree = new ADTAVLTree<int>()
                .Add(1).Add(1).Add(1).Add(1).Add(1);
            // Act
            bool contains = fiveElemTree.Contains(1);
            int height = fiveElemTree.Height();
            // Assert
            Assert.AreEqual(true, contains);
            Assert.AreEqual(3, height);
        }
        [TestMethod]
        [TestCategory("AVLTree")]
        public void ThreeElemTreeDeleteNode() {
            // Arrange
            var threeElemTree = new ADTAVLTree<int>()
                .Add(1).Add(1).Add(1);
            threeElemTree.PrettyPrintTree();
            Console.WriteLine();
            threeElemTree.Delete(1);
            threeElemTree.PrettyPrintTree();
            // Act
            bool contains = threeElemTree.Contains(1);
            int height = threeElemTree.Height();
            // Assert
            Assert.AreEqual(true, contains);
            Assert.AreEqual(2, height);
        }
        [TestMethod]
        [TestCategory("AVLTree")]
        public void FiveElemTreeDeleteNode() {
            // Arrange
            var threeElemTree = new ADTAVLTree<int>()
                .Add(1).Add(1).Add(1).Add(1).Add(1);
            threeElemTree.PrettyPrintTree();
            Console.WriteLine();
            threeElemTree.Delete(1);
            threeElemTree.PrettyPrintTree();
            // Act
            bool contains = threeElemTree.Contains(1);
            int height = threeElemTree.Height();
            // Assert
            Assert.AreEqual(true, contains);
            Assert.AreEqual(3, height);
        }
    }
}
