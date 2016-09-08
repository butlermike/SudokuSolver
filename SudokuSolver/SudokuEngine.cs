using System;
namespace SudokuSolver
{
	public class SudokuEngine : ISudokuEngine
	{
		GameGrid gameGrid;

		public SudokuEngine(GameGrid grid)
		{
			this.gameGrid = grid;

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

		public SudokuGrid initializeGrid(GameGrid grid)
		{
			var sgrid = (SudokuGrid)grid;
			for (var i = 0; i < sgrid.Rows; i++)
			{
				for (var j = 0; j < sgrid.Columns; j++)
				{
					sgrid.Cells[i, j] = new SudokuCell();
				}
			}
			return sgrid;
		}

		public void displaySudokuGrid(SudokuGrid sgrid)
		{
			for (int r = 0; r < sgrid.Rows; r++)
			{
				for (int c = 0; c < sgrid.Columns; c++)
				{
					var sCell = (SudokuCell)sgrid.Cells[r, c];
					if (sCell.PossibleValues.Count > 1)
					{
						Console.Write("_ _");
						continue;
					}
					foreach (var value in sCell.PossibleValues)
					{
						Console.Write("_" + value + "_");
					}
				}
				Console.WriteLine();
			}
		}
	}
}

