    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Tetris_test_v3
    {
        internal class Tetromino
        {
            Random rnd = new Random();
            public int pieceRow { get; set; } = 0;
            public int pieceCol { get; set; } = 3;
            public int [,] piece {  get; set; }

          // an araay of 2D arrays that hold the pieces
           public int[][,] Pieces =
           {
                new int[,] // I
                {
                    {0,0},
                    {0,1},
                    {0,2},
                    {0,3}
                },

                new int[,] // J
                {
                    {0,0},
                    {1,0},
                    {1,1},
                    {1,2}
                },
                 new int[,] // L
                {
                    {1,0},
                    {1,1},
                    {1,2},
                    {0,2}
                },
                  new int[,] // O
                {
                    {0,0},
                    {0,1},
                    {1,0},
                    {1,1}
                },
                   new int[,] // S
                {
                    {1,0},
                    {1,1},
                    {0,1},
                    {0,2}
                },
                    new int[,] // Z
                {
                    {0,0},
                    {0,1},
                    {1,1},
                    {1,2}
                },
                     new int[,] // T
                {
                    {1,0},
                    {1,1},
                    {1,2},
                    {0,1}
                }

           };

            public Tetromino()
            {
               piece = (Pieces[rnd.Next(0,Pieces.Length)]);
           
            }

           // finds the pivot point that is used to turn the piece around 
            public int  [] CalculatePivotPoint(Tetromino _currentPiece)
            {
                int[] centerPovit = new int[2];
                double centerRow = 0;
                double centerCol = 0;
                for (int i = 0; i < _currentPiece.piece.GetLength(0); i++)
                {
                
                
                    centerRow += _currentPiece.piece[i, 0] + _currentPiece.pieceRow;
                    centerCol += _currentPiece.piece[i, 1] + _currentPiece.pieceCol;

                
                }
                centerRow = centerRow / _currentPiece.piece.GetLength(0);
                centerCol = centerCol / _currentPiece.piece.GetLength(0);
                
                centerPovit[0] = (int)Math.Round(centerRow); // rounds the number so it can be used as a set of cords
                centerPovit [1]= (int)Math.Round(centerCol);
                return centerPovit;
            }


        public int[,] RoataePiece(Tetromino block)
        {

                int[,] rotatedPiece = new int[4, 2];
                int [] center = block.CalculatePivotPoint(block);
       
               // for each blovk in the piece it does the (x,y) => (y,-x) that turns it 90 degress 
                for (int i = 0; i < block.piece.GetLength(0); i++)
                {
                

                    int relativeRow = block.piece[i, 0] + block.pieceRow - center[0];
                    int relativeCol = block.piece[i, 1] + block.pieceCol - center[1];

                    int rotatedRow = relativeCol;
                    int rotatedCol = -relativeRow;

                    int newRow = center[0] + rotatedRow;
                    int newCol = center[1] + rotatedCol;

                    rotatedPiece[i, 0] = newRow - block.pieceRow;
                    rotatedPiece[i, 1] = newCol - block.pieceCol;

                  




                }
                return rotatedPiece;

            }
             

           




        }
       
    }

    

