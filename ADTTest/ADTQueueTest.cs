using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADTList;

namespace ADTTest {
    [TestClass]
    public class ADTQueueTest {
        [TestMethod]
        [TestCategory("Queue")]
        public void EmptyQueueContains() {
            // Arrange
            var emptyQueue = new ADTQueue<int>();
            // Act
            bool result = emptyQueue.Contains(1);
            // Assert
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        [TestCategory("Queue")]
        public void NotEmptyQueueContains() {
            // Arrange
            var notEmptyQueue = new ADTQueue<int>()
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);
            // Act
            bool result = notEmptyQueue.Contains(3);
            // Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        [TestCategory("Queue")]
        public void NotEmptyQueueNotContains() {
            // Arrange
            var notEmptyQueue = new ADTQueue<int>()
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);
            // Act
            bool result = notEmptyQueue.Contains(4);
            // Assert
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        [TestCategory("Queue")]
        public void QueueDequeueSuccess() {
            // Arrange
            var notEmptyQueue = new ADTQueue<int>()
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);
            // Act
            int result = notEmptyQueue.Dequeue();
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyQueueException))]
        [TestCategory("Queue")]
        public void QueueDequeueFail() {
            // Arrange
            var emptyQueue = new ADTQueue<int>();
            // Act
            int result = emptyQueue.Dequeue();
            // Assert
            Assert.Fail();
        }
        [TestMethod]
        [TestCategory("Queue")]
        public void QueuePeekSuccess() {
            // Arrange
            var notEmptyQueue = new ADTQueue<int>()
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);
            // Act
            int result = notEmptyQueue.Peek();
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyQueueException))]
        [TestCategory("Queue")]
        public void QueuePeekFail() {
            // Arrange
            var emptyQueue = new ADTQueue<int>();
            // Act
            int result = emptyQueue.Peek();
            // Assert
            Assert.Fail();
        }
    }
}
