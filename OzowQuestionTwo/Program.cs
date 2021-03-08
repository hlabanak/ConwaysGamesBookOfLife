using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using GameOfLife.BLL;

namespace OzowQuestionTwo
{
    class Program
    {

        private static IGameRules _gameRules;
        public static void Main()
        {
            _gameRules = new GameRules();

            Console.WriteLine("***************************Welcome to Game of Life.***************************\n");

            Console.WriteLine("Please enter number of rows for the matrix: ");
            int Rows = Int32.Parse( Console.ReadLine());

            Console.WriteLine("Please enter number of colums for the matrix: ");
            int Columns = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter iteration through generations displaying each state: ");
            int NextGenerationIterations = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter intervals to simulate matrix: ");
            int intervals = Int32.Parse(Console.ReadLine());

            var matrixBoard = _gameRules.GenerateMatrix(Rows, Columns);

            Console.Clear();


            string mewMatrixBoard = string.Empty;
            for (int i = 0; i < NextGenerationIterations; i++)
            {
                mewMatrixBoard = _gameRules.SimulateMatrix(matrixBoard, Rows, Columns);

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.Write(mewMatrixBoard);
                Thread.Sleep(intervals);
                matrixBoard = _gameRules.PopulateNextGenerationMatrix(matrixBoard, Rows, Columns);
            }
           
        }
    }
}

