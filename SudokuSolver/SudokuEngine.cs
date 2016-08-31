using System;
namespace SudokuSolver
{
	public class SudokuEngine : ISudokuEngine
	{
		GameGrid gameGrid;

		public SudokuEngine()
		{
		}

		public GameGrid GameGrid
		{
			get
			{
				return gameGrid;
			}

			set
			{
				gameGrid = value;
			}
		}

		public SudokuGrid initializeGrid()
		{
			SudokuGrid grid = new SudokuGrid();
			for (var i = 0; i < grid.Rows; i++)
			{
				for (var j = 0; j < grid.Columns; j++)
				{
					grid.Cells[i, j] = new SudokuCell();
				}
			}
			return grid;
		}
	}
}

