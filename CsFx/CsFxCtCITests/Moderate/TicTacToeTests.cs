using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsFx.CtCI.Moderate;

namespace CsFxCtCITests.Moderate {
    [TestClass]
    public class TicTacToeTests {
        private const TicTacToePiece _ = TicTacToePiece.None;
        private const TicTacToePiece O = TicTacToePiece.O;
        private const TicTacToePiece X = TicTacToePiece.X;

        [TestMethod]
        public void TestNoWinner() {
            var board = new TicTacToeBoard();
            var result = board.FindWinner();
            Assert.AreEqual(TicTacToePiece.None, result);
        }

        [TestMethod]
        public void TestRow() {
            var board = TicTacToeBoard.Create(
                X, O, X,
                _, _, _,
                X, X, X);


            var result = board.FindWinner();
            Assert.AreEqual(TicTacToePiece.X, result);
        }

        [TestMethod]
        public void TestColumn() {
            var board = TicTacToeBoard.Create(
                O, _, O,
                X, _, O,
                O, _, O);


            var result = board.FindWinner();
            Assert.AreEqual(TicTacToePiece.O, result);
        }

        [TestMethod]
        public void TestLeftToRightDiagnol() {
            var board = TicTacToeBoard.Create(
                O, X, _,
                X, O, _,
                O, X, O);


            var result = board.FindWinner();
            Assert.AreEqual(TicTacToePiece.O, result);
        }

        [TestMethod]
        public void TestRightToLeftDiagnol() {
            var board = TicTacToeBoard.Create(
                O, X, X,
                X, X, _,
                X, X, _);


            var result = board.FindWinner();
            Assert.AreEqual(TicTacToePiece.X, result);
        }
    }
}