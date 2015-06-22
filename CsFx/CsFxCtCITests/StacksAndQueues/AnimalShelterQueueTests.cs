using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.StacksAndQueues;

namespace CsFxCtCITests.StacksAndQueues {
    [TestClass]
    public class AnimalShelterQueueTests {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeueAny_NoAnimals() {
            new AnimalShelterQueue().DequeueAny();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeueCat_NoAnimals() {
            new AnimalShelterQueue().DequeueCat();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeueDog_NoAnimals() {
            new AnimalShelterQueue().DequeueDog();
        }

        [TestMethod]
        public void TestEnqueueDequeueCat() {
            var queue = new AnimalShelterQueue();
            var id = queue.EnqueueCat();
            Assert.AreEqual(id, queue.DequeueCat());
        }

        [TestMethod]
        public void TestEnqueueDequeueDog() {
            var queue = new AnimalShelterQueue();
            var id = queue.EnqueueDog();
            Assert.AreEqual(id, queue.DequeueDog());
        }

        [TestMethod]
        public void TestEnqueueCatDequeueAny() {
            var queue = new AnimalShelterQueue();
            var id = queue.EnqueueCat();
            Assert.AreEqual(id, queue.DequeueAny());
        }

        [TestMethod]
        public void TestEnqueueDogDequeueAny() {
            var queue = new AnimalShelterQueue();
            var id = queue.EnqueueDog();
            Assert.AreEqual(id, queue.DequeueAny());
        }

        [TestMethod]
        public void TestEnqueueCatEnqueueDogDequeueAny() {
            var queue = new AnimalShelterQueue();
            var catId1 = queue.EnqueueCat();
            var dogId1 = queue.EnqueueDog();

            Assert.AreEqual(catId1, queue.DequeueAny());

            var dogId2 = queue.EnqueueDog();
            var catId2 = queue.EnqueueCat();

            Assert.AreEqual(dogId1, queue.DequeueAny());
            Assert.AreEqual(dogId2, queue.DequeueAny());
            Assert.AreEqual(catId2, queue.DequeueAny());
        }
    }
}
