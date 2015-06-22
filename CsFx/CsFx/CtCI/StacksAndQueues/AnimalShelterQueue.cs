using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.StacksAndQueues {
    class AnimalShelterQueue {
        private int idCounter;
        private LinkedList<int> cats;
        private LinkedList<int> dogs;

        public AnimalShelterQueue() {
            this.cats = new LinkedList<int>();
            this.dogs = new LinkedList<int>();
            this.idCounter = 0;
        }

        public int EnqueueCat() {
            var id = this.idCounter++;
            this.cats.AddLast(id);
            return id;
        }

        public int EnqueueDog() {
            var id = this.idCounter++;
            this.dogs.AddLast(id);
            return id;
        }

        public int DequeueAny() {
            if (!this.cats.Any() && !this.dogs.Any()) {
                throw new InvalidOperationException();
            } else if (!this.cats.Any()) {
                return this.DequeueDog();
            } else if (!this.dogs.Any()) {
                return this.DequeueCat();
            } else if (this.cats.First() < this.dogs.First()) {
                return this.DequeueCat();
            } else {
                return this.DequeueDog();
            }
        }

        public int DequeueCat() {
            var id = this.cats.First();
            this.cats.RemoveFirst();
            return id;
        }

        public int DequeueDog() {
            var id = this.dogs.First();
            this.dogs.RemoveFirst();
            return id;
        }
    }
}
