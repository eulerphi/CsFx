using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class XmlEncodingTests {
        [TestMethod]
        public void Test() {
            var root = new XElement("family",
                new XAttribute("lastName", "McDowell"),
                new XAttribute("state", "CA"),
                new XElement("person",
                    new XAttribute("firstName", "Gayle"),
                    "Some Message"));

            var expected = "1 4 McDowell 5 CA 0 2 3 Gayle 0 Some Message 0 0";
            var actual = XmlEncoding.Encode(root);

            Assert.AreEqual(expected, actual);
        }
    }
}
