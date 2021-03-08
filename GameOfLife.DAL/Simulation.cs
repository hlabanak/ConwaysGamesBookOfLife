using System;
using System.Text;
using System.Threading;

namespace GameOfLife.DAL
{
    public class Simulation
    {
        public static string SimulateGeneration(Status[,] nextGenerationAliveOrDead, int Rows =0, int Columns = 0)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var cell = nextGenerationAliveOrDead[row, column];
                    stringBuilder.Append(cell == Status.Alive ? "X" : "-");
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();    
        }
    }
}
