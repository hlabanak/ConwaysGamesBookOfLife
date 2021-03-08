using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GameOfLife.DAL
{
    public class Matrix
    {
        public static Status[,] GenerateMatrix(int Rows, int Columns)
        {
            var matrix = new Status[Rows, Columns];

            // randomly initialize our matrix
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    matrix[row, column] = (Status)RandomNumberGenerator.GetInt32(0, 2);
                }
            }
            return matrix;
        }
    }
}
