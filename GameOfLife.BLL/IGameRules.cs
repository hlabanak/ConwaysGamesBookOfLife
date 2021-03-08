using GameOfLife.DAL;

namespace GameOfLife.BLL
{
    public interface IGameRules
    {
        Status[,] PopulateNextGenerationMatrix(Status[,] currentMatrix, int Rows, int Columns);
        Status[,] CheckRulesOfLife(Status[,] currentMatrix, Status[,] isAliveOrDead, int aliveNeighbors, int row, int column);
        string SimulateMatrix(Status[,] nextGenerationAliveOrDead, int Rows = 0, int Columns = 0);
        Status[,] GenerateMatrix(int Rows, int Columns);
    }
}
