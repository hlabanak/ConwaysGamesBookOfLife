using GameOfLife.DAL;
using System;

namespace GameOfLife.BLL
{
    public class GameRules : IGameRules
    {
        public GameRules()
        {

        }
        public Status[,] PopulateNextGenerationMatrix(Status[,] currentMatrixBoard, int Rows, int Columns)
        {
            var isAliveOrDead = new Status[Rows, Columns];

            // Loop through every cell 
            for (var row = 1; row < Rows - 1; row++)
            {
                for (var column = 1; column < Columns - 1; column++)
                {
                    // find your alive neighbors
                    int aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            //aliveNeighbors += currentMatrix[row + i, column + j] == Status.Alive ? 1 : 0;
                            aliveNeighbors += currentMatrixBoard[row + i, column + j] == Status.Alive ? 1 : 0;
                        }
                    }

                    isAliveOrDead = CheckRulesOfLife(currentMatrixBoard, isAliveOrDead, aliveNeighbors, row, column);
                }
            }
                
            return isAliveOrDead;
        }

        public Status[,] CheckRulesOfLife(Status[,] currentMatrixBoard,Status[,] isAliveOrDead, int aliveNeighbors, int row, int column)
        {

            var currentCell = currentMatrixBoard[row, column];

            // The cell needs to be subtracted 
            // from its neighbors as it was  
            // counted before 
            aliveNeighbors -= currentCell == Status.Alive ? 1 : 0;

            // Implementing the Rules of Life 

            // Cell is lonely and dies 
            if (currentCell == Status.Alive && aliveNeighbors < 2)
            {
                isAliveOrDead[row, column] = Status.Dead;
            }

            // Cell dies due to over population 
            else if (currentCell == Status.Alive && aliveNeighbors > 3)
            {
                isAliveOrDead[row, column] = Status.Dead;
            }

            // A new cell is born 
            else if (currentCell == Status.Dead && aliveNeighbors == 3)
            {
                isAliveOrDead[row, column] = Status.Alive;
            }
            // stays the same
            else
            {
                isAliveOrDead[row, column] = currentCell;
            }
            return isAliveOrDead;
        }

        public string SimulateMatrix(Status[,] nextGenerationAliveOrDead, int Rows = 0, int Columns = 0)
        {
            return Simulation.SimulateGeneration(nextGenerationAliveOrDead, Rows,Columns);
        }

        public Status[,] GenerateMatrix(int Rows, int Columns)
        {
            return Matrix.GenerateMatrix(Rows, Columns);
        }
    }
}
