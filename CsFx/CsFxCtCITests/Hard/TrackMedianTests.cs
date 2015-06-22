using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Hard;

namespace CsFxCtCITests.Hard {
    [TestClass]
    public class TrackMedianTests {
        [TestMethod]
        public void Test() {
            var sut = new TrackMedian();
            var values = new int[] { 3, 2, 5, 10, 6 };
            foreach (var v in values) {
                sut.Track(v);
            }

            Assert.AreEqual(5, sut.GetMedian());
        }
    }
}
