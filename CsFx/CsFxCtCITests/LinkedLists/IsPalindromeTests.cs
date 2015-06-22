using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.LinkedLists;

namespace CsFxCtCITests.LinkedLists {
    [TestClass]
    public class IsPalindromeTests {
        [TestMethod]
        public void TestNullParameter() {
            Assert.IsTrue(IsPalindrome.Check(null));
        }

        [TestMethod]
        public void TestLengthOne() {
            Assert.IsTrue(IsPalindrome.Check(new LinkedListNode()));
        }

        [TestMethod]
        public void TestLengthTwo_Green() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 1
                }
            };

            Assert.IsTrue(IsPalindrome.Check(head));
        }


        [TestMethod]
        public void TestLengthTwo_Red() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 2
                }
            };

            Assert.IsFalse(IsPalindrome.Check(head));

            head = new LinkedListNode {
                Value = 2,
                Next = new LinkedListNode {
                    Value = 1
                }
            };

            Assert.IsFalse(IsPalindrome.Check(head));
        }

        [TestMethod]
        public void TestLengthThree_Green() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 2,
                    Next = new LinkedListNode {
                        Value = 1
                    }
                }
            };

            Assert.IsTrue(IsPalindrome.Check(head));
        }

        [TestMethod]
        public void TestLengthThree_Red() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 2,
                    Next = new LinkedListNode {
                        Value = 2
                    }
                }
            };

            Assert.IsFalse(IsPalindrome.Check(head));
        }

        [TestMethod]
        public void TestLengthSix_Green() {
            var head = new LinkedListNode {
                Value = 1,
                Next = new LinkedListNode {
                    Value = 2,
                    Next = new LinkedListNode {
                        Value = 3,
                        Next = new LinkedListNode {
                            Value = 3,
                            Next = new LinkedListNode {
                                Value = 2,
                                Next = new LinkedListNode {
                                    Value = 1
                                }
                            }
                        }
                    }
                }
            };

            Assert.IsTrue(IsPalindrome.Check(head));
        }

        [TestMethod]
        public void TestLengthSix_Red() {
            var head = new LinkedListNode {
                Value = 3,
                Next = new LinkedListNode {
                    Value = 2,
                    Next = new LinkedListNode {
                        Value = 3,
                        Next = new LinkedListNode {
                            Value = 3,
                            Next = new LinkedListNode {
                                Value = 2,
                                Next = new LinkedListNode {
                                    Value = 1
                                }
                            }
                        }
                    }
                }
            };

            Assert.IsFalse(IsPalindrome.Check(head));
        }
    }
}
