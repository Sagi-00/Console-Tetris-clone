    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO.Pipelines;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    using Tetris_test_v3;



    namespace MyApp
    {
        internal class Program
        {
       
            static void Main(string[] args)
            {
                Console.CursorVisible = false;
                Tetromino block = new Tetromino();
                PlayField board = new PlayField(20, 10);
                Stopwatch stopwatch = Stopwatch.StartNew();

                while (true)
                {
                

                

                    Console.SetCursorPosition(0, 0);

                    if (stopwatch.ElapsedMilliseconds >= 1000)
                    {
                        if (board.CanPieceMoveDown(block))
                        {
                            block.pieceRow++;
                        }
                        else
                        {
                            board.HandlePieceLanding(block);
                            block = new Tetromino();
                            if (board.IsGameOver(block))
                            {
                                board = new PlayField(20, 10);
                            }
                        }
                        stopwatch.Restart();
                    }
                    Console.WriteLine($"Score = ({board.score.ToString()})");
                    board.DrawBoard(block);




                    if (Console.KeyAvailable)
                    {


                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Escape) break;



                        if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            if (board.CanPieceMoveDown(block))
                            {
                                block.pieceRow++;
                            }
                            else
                            {
                                board.HandlePieceLanding(block);
                                block = new Tetromino();
                                if (board.IsGameOver(block))
                                {
                                    board = new PlayField(20, 10);
                                }
                            }
                        }


                        if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            if (board.CanPieceMoveRight(block))
                            {
                                block.pieceCol++;
                            }

                        }

                        if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            if (board.CanPieceMoveLeft(block))
                            {
                                block.pieceCol--;
                            }

                        }

                        if (keyInfo.Key == ConsoleKey.UpArrow) 
                        {
                            int[,] rotatedPiece = block.RoataePiece(block);

                            if (board.IsRotationValid(rotatedPiece, block)) // checks if the rotation is valid 
                            {
                                block.piece = rotatedPiece;
                            }

                        }
                    
                    }
                    Thread.Sleep(16); // limits the frame rate to 60. 
                }
               








            

            }


        }
    }