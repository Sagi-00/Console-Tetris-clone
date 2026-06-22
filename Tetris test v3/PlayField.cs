using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_test_v3
{
    internal class PlayField
    {

        public int Rows { get; }
        public int Columns { get; }

        private int[,] board;
        public int score { get; set; }  

        public PlayField(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            board = new int[Rows, Columns];
        }


        public void DrawBoard(Tetromino _currentPiece)
        {
            for (int i = 0; i < board.GetLength(0); i++) // this for loop is for the row. 
            {
                for (int j = 0; j < board.GetLength(1); j++) // this for loop is for each col inside the current row.
                {
                    
                    if (board[i, j] == 1)
                    {
                        Console.Write("#");
                    }
                    else if (IsPieceAt(_currentPiece, i, j))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }

                }
                Console.WriteLine(); // move down a line and starts drawing the next row.
            }
        }

        public void ClearLines()
        {
            int count = 0;
            for (int i = board.GetLength(0) -1; i > 0 ; i--)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                    {
                        count ++;
                    }
                    
                }
                if (count == board.GetLength(1))
                {
                    for (int row = i; row > 0; row--)
                    {
                        for (int col = 0; col < board.GetLength(1); col++)
                        {
                            board[row, col] = board[row - 1, col];

                        }
                        
                    }
                    for (int c = 0; c < board.GetLength(1); c++)
                    {
                        board[0, c] = 0;
                    }
                    score += 100;  
                    i++;


                }
                count = 0;
                
            }


        }
        public void LockPieceInBoard(Tetromino _currentPiece)
        {
            for (int i = 0; i < _currentPiece.piece.GetLength(0); i++)
            {
                board[_currentPiece.piece[i, 0] + _currentPiece.pieceRow, _currentPiece.piece[i, 1] + _currentPiece.pieceCol] = 1;
            }

        }


        public bool IsGameOver(Tetromino _currentPiece)
        {
            if (!CanPieceMoveDown(_currentPiece) && _currentPiece.pieceRow  == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsPieceAt(Tetromino _currentPiece, int row, int col )
        {

            for (int i = 0; i < _currentPiece.piece.GetLength(0); i++)
            {

                int actualRow;
                int actualCol;

                actualRow = _currentPiece.piece[i, 0] + _currentPiece.pieceRow;
                actualCol = _currentPiece.piece[i, 1] + _currentPiece.pieceCol;


                if (actualRow == row && actualCol == col)
                {
                    return true;
                }
            }
            return false;




        }

        public bool CanPieceMoveDown(Tetromino _currentPiece)
        {
            for (int i = 0; i < _currentPiece.piece.GetLength(0); i++) 
            {

                int actualRow;
                int actualCol;
                int nextRow;
                actualRow = _currentPiece.piece[i, 0] + _currentPiece.pieceRow;
                actualCol = _currentPiece.piece[i, 1] + _currentPiece.pieceCol;
                nextRow = actualRow + 1;

                if (nextRow > 19) 
                {
                    return false;
                }
                else if (board[nextRow, actualCol] == 1)
                {
                    return false;
                }
               
            }
            return true;

        }


        public bool CanPieceMoveRight(Tetromino _currentPiece)
        {

            for (int i = 0; i < _currentPiece.piece.GetLength(0); i++)
            {

                int actualRow;
                int actualCol;
                int nextCol;
                actualRow = _currentPiece.piece[i, 0] + _currentPiece.pieceRow;
                actualCol = _currentPiece.piece[i, 1] + _currentPiece.pieceCol;
                nextCol = actualCol + 1;

                if (nextCol > 9)
                {
                    return false;
                }
                else if (board[ actualRow, nextCol] == 1)
                {
                    return false;
                }

            }
            return true;

        }



        public bool CanPieceMoveLeft(Tetromino _currentPiece)
        {
            for (int i = 0; i < _currentPiece.piece.GetLength(0); i++)
            {

                int actualRow;
                int actualCol;
                int nextCol;
                actualRow = _currentPiece.piece[i, 0] + _currentPiece.pieceRow;
                actualCol = _currentPiece.piece[i, 1] + _currentPiece.pieceCol;
                nextCol = actualCol -1;

                if (nextCol < 0)
                {
                    return false;
                }
                else if (board[actualRow, nextCol] == 1)
                {
                    return false;
                }

            }
            return true;

        }
        public bool IsRotationValid(int [,] _rotatedPiece , Tetromino block )
        {
            for (int i = 0; i< _rotatedPiece.GetLength(0); i++)
            {
               int boardRow = _rotatedPiece[i, 0] + block.pieceRow;
               int boardCol = _rotatedPiece[i, 1] + block.pieceCol;
               // checks if the current block in the piece is not valid if so return false
                if(boardRow< 0)
                {
                   return false;     
                }
                if (boardRow >= board.GetLength(0) -1) 
                {
                  return false;
                }
                if(boardCol < 0)
                {
                    return false;
                }
                if(boardCol >= board.GetLength(1))
                {
                    return false;
                }
                if (board[boardRow, boardCol] == 1)
                {
                    return false;
                }
            }
            // all the block were valid 
            return true;
        }
        public void HandlePieceLanding(Tetromino piece) 
        {
            LockPieceInBoard(piece);
            ClearLines();
        }

    }
}
