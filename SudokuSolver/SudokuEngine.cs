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

		public void loadGrid(GameGrid grid, int row, int column, int value)
		{
			SudokuCell sCell = (SudokuCell)grid.Cells[row, column];
			sCell.SetValue(value);
		}

		public void displaySudokuGrid(SudokuGrid sgrid)
		{
			Console.WriteLine();
			Console.WriteLine();

			int delimiterRowCount = 0;

			for (int r = 0; r < sgrid.Rows; r++)
			{
				int delimiterColumnCount = 0;
				for (int c = 0; c < sgrid.Columns; c++)
				{
					delimiterColumnCount += 1;

					if (delimiterColumnCount > 3)
					{
						Console.Write("|");
						delimiterColumnCount = 1;
					}

					var sCell = (SudokuCell)sgrid.Cells[r, c];
					if (sCell.PossibleValues.Count > 1)
					{
						Console.Write("*");
						continue;
					}
					foreach (var value in sCell.PossibleValues)
					{
						Console.Write(value);
					}
				}
				Console.WriteLine();

				delimiterRowCount += 1;
				if (r < 7 && delimiterRowCount > 2 )
				{
					Console.WriteLine("-----------");
					delimiterRowCount = 0;
				}
			}

			Console.WriteLine();
			Console.WriteLine();
		}
	}
}

