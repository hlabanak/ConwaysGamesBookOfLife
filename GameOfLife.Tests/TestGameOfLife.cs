using FluentAssertions;
using GameOfLife.BLL;
using GameOfLife.DAL;
using NUnit.Framework;
using System.Threading;

namespace GameOfLife.Tests
{
    public class TestGameOfLife
    {
        private IGameRules _gameRules;
        [SetUp]
        public void Setup()
        {
            _gameRules = new GameRules();
        }

        [TestCase(10, 500, 25, 50)]
        public void TestNextTenGenerations(int NextGenerationIterations, int intervals, int Rows, int Columns)
        {
            var matrixBoard = _gameRules.GenerateMatrix(Rows, Columns);
            string mewMatrixBoard = string.Empty;
            for (int i = 0; i < NextGenerationIterations; i++)
            {
                mewMatrixBoard = _gameRules.SimulateMatrix(matrixBoard, Rows, Columns);
                Thread.Sleep(intervals);
                matrixBoard = _gameRules.PopulateNextGenerationMatrix(matrixBoard, Rows, Columns);
            }
            mewMatrixBoard.Should().Contain(mewMatrixBoard);
            Assert.Pass();
        }

        [TestCase(49, 500, 50, 50)]
        public void TestNextFourtyNineGenerations(int NextGenerationIterations, int intervals, int Rows, int Columns)
        {
            var matrixBoard = _gameRules.GenerateMatrix(Rows, Columns);
            string mewMatrixBoard = string.Empty;
            for (int i = 0; i < NextGenerationIterations; i++)
            {
                mewMatrixBoard = _gameRules.SimulateMatrix(matrixBoard, Rows, Columns);
                Thread.Sleep(intervals);
                matrixBoard = _gameRules.PopulateNextGenerationMatrix(matrixBoard, Rows, Columns);
            }
            mewMatrixBoard.Should().Contain(mewMatrixBoard);
            Assert.Pass();
        }

        [TestCase(5, 1000, 100, 100)]
        public void TestNextFiveGenerations(int NextGenerationIterations, int intervals, int Rows, int Columns)
        {
            var matrixBoard = _gameRules.GenerateMatrix(Rows, Columns);
            string mewMatrixBoard = string.Empty;
            for (int i = 0; i < NextGenerationIterations; i++)
            {
                mewMatrixBoard = _gameRules.SimulateMatrix(matrixBoard, Rows, Columns);
                Thread.Sleep(intervals);
                matrixBoard = _gameRules.PopulateNextGenerationMatrix(matrixBoard, Rows, Columns);
            }
            mewMatrixBoard.Should().Contain(mewMatrixBoard);
            Assert.Pass();
        }
    }
}