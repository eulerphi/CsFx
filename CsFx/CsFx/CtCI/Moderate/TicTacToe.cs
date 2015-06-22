using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    enum TicTacToePiece {
        None,
        X,
        O
    }

    class TicTacToeBoard {
        private const int BoardSize = 3;

        private TicTacToePiece[,] board;

        public TicTacToeBoard() {
            this.board = new TicTacToePiece[BoardSize, BoardSize];
        }

        public void PlacePiece(TicTacToePiece piece, int row, int column) {
            if (row < 0 || row >= BoardSize || column < 0 || column >= BoardSize) {
                throw new ArgumentException();
            }

            // Doesn't enforce correctness, i.e. only allowing
            // squares without a piece in them to be changed.
            this.board[row, column] = piece;
        }

        public static TicTacToeBoard Create(params TicTacToePiece[] pieces) {
            if (pieces.Length != (BoardSize * BoardSize)) {
                throw new ArgumentException();
            }

            var board = new TicTacToeBoard();
            for (var row = 0; row < BoardSize; row++) {
                for (var col = 0; col < BoardSize; col++) {
                    var index = BoardSize * row + col;
                    board.PlacePiece(pieces[index], row, col);
                }
            }

            return board;
        }

        public TicTacToePiece FindWinner() {
            var result = CheckRows();
            if (result != TicTacToePiece.None) {
                return result;
            }

            result = CheckColumns();
            if (result != TicTacToePiece.None) {
                return result;
            }

            result = CheckLeftToRightDiagnol();
            if (result != TicTacToePiece.None) {
                return result;
            }

            result = CheckRightToLeftDiagnol();
            if (result != TicTacToePiece.None) {
                return result;
            }

            return TicTacToePiece.None;
        }

        private TicTacToePiece CheckRows() {
            for (var row = 0; row < BoardSize; row++) {
                for (var col = 1; col <= BoardSize; col++) {
                    if (col == BoardSize) {
                        return this.board[row, 0];
                    }

                    if (this.board[row, col] == TicTacToePiece.None ||
                        this.board[row, col] != this.board[row, col - 1]) {
                        break;
                    }
                }
            }

            return TicTacToePiece.None;
        }

        private TicTacToePiece CheckColumns() {
            for (var col = 0; col < BoardSize; col++) {
                for (var row = 1; row <= BoardSize; row++) {
                    if (row == BoardSize) {
                        return this.board[0, col];
                    }

                    if (this.board[row, col] == TicTacToePiece.None ||
                        this.board[row, col] != this.board[row - 1, col]) {
                        break;
                    }
                }
            }

            return TicTacToePiece.None;
        }

        private TicTacToePiece CheckLeftToRightDiagnol() {
            for (var i = 1; i <= BoardSize; i++) {
                if (i == BoardSize) {
                    return this.board[0, 0];
                }

                if (this.board[i, i] == TicTacToePiece.None ||
                    this.board[i, i] != this.board[i - 1, i - 1]) {
                    break;
                }
            }

            return TicTacToePiece.None;
        }

        private TicTacToePiece CheckRightToLeftDiagnol() {
            for (var i = 1; i <= BoardSize; i++) {
                if (i == BoardSize) {
                    return this.board[0, 0];
                }

                if (this.board[i, BoardSize - i] == TicTacToePiece.None ||
                    this.board[i, BoardSize - i] != this.board[i - 1, BoardSize - i - 1]) {
                    break;
                }
            }

            return TicTacToePiece.None;
        }
    }
}
