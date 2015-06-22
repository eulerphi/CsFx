using CsFx.CtCI.ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsFxCtCITests.ArraysAndStrings {
    [TestClass]
    public class Problem3Tests {
        [TestMethod]
        public void Test() {
            Assert.IsTrue(new Problem3().Solution2("abc", "cba"));
            Assert.IsFalse(new Problem3().Solution2("abc", "cda"));
        }
    }
}
