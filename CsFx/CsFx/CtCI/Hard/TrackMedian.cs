using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Hard {
    class TrackMedian {
        private readonly IList<int> maxHeap;
        private readonly IList<int> minHeap;

        public TrackMedian() {
            this.maxHeap = new List<int>();
            this.minHeap = new List<int>();
        }

        public double GetMedian() {
            if (!this.maxHeap.Any()) {
                throw new InvalidOperationException();
            }

            if (this.maxHeap.Count == this.minHeap.Count) {
                return ((double)this.MaxPeek() + (double)this.MinPeek()) / 2;
            } else {
                return this.MaxPeek();
            }
        }

        public void Track(int value) {
            if (this.maxHeap.Count == this.minHeap.Count) {
                if (minHeap.Count > 0 && value > this.MinPeek()) {
                    this.TransferMinToMax();
                    this.minHeap.Add(value);
                } else {
                    maxHeap.Add(value);
                }
            } else {
                if (value < this.MaxPeek()) {
                    this.TransferMaxToMin();
                    this.maxHeap.Add(value);
                } else {
                    this.minHeap.Add(value);
                }
            }

        }

        private int MaxPeek() {
            return this.maxHeap.Max();
        }

        private int MinPeek() {
            return this.minHeap.Min();
        }

        private void TransferMinToMax() {
            var minPeek = this.MinPeek();
            this.minHeap.Remove(minPeek);
            this.maxHeap.Add(minPeek);
        }

        private void TransferMaxToMin() {
            var maxPeek = this.MaxPeek();
            this.maxHeap.Remove(maxPeek);
            this.minHeap.Add(maxPeek);
        }
    }
}
