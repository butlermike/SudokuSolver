using System;
using System.Collections.Generic;
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
					SudokuCell sCell = (SudokuCell) sgrid.Cells[i, j];
					sCell.Quadrant = quadrantNumberWithRowColumn(i, j);
				}
			}

			// Set the cell observers
			for (var i = 0; i < sgrid.Rows; i += 1)
			{
				for (var j = 0; j < sgrid.Columns; j += 1)
				{
					SudokuCell sCell = (SudokuCell)sgrid.Cells[i, j];

					for (var index1 = 0; index1 < sgrid.Rows; index1 += 1)
					{
						// Add the observers in this column (skipping myself as needed)
						if (index1 != j)
						{
							sCell.registerObserver(sgrid.Cells[i, index1]);
						}

						// Add the observers in this row (skipping myself as needed)
						if (index1 != i)
						{
							sCell.registerObserver(sgrid.Cells[index1, j]);
						}
					}
				}
			}

			// Add the observers in this quadrant
			// We can skip cells that already have our own row or column, they were already added.
			// Until I come up with a better way, just gonna walk the cells and find those in my own quadrant
			for (var qi = 0; qi < sgrid.Rows; qi += 1)
			{
				for (var qj = 0; qj < sgrid.Columns; qj += 1)
				{
					SudokuCell sCell = (SudokuCell)sgrid.Cells[qi, qj];

					for (var qi1 = 0; qi1 < sgrid.Rows; qi1 += 1)
					{
						for (var qj1 = 0; qj1 < sgrid.Columns; qj1 += 1)
						{
							SudokuCell sCell1 = (SudokuCell)sgrid.Cells[qi1, qj1];

							// Skip cells that are not in our quadrant
							if (sCell.Quadrant != sCell1.Quadrant)
							{
								continue;
							}

							// Skip cells that have already been added as a row or column observer
							if (qi == qi1)
							{
								continue;
							}
							if (qj == qj1)
							{
								continue;
							}
							sCell.registerObserver(sgrid.Cells[qi1, qj1]);
						}
					}
				}
			}
			return sgrid;
		}

		public int quadrantNumberWithRowColumn(int row, int column)
		{
			if (row < 3)
			{
				if (column < 3)
				{
					return 0;
				}

				if (column > 2 && column < 6)
				{
					return 1;
				}

				if (column > 5)
				{
					return 2;
				}
			}

			if (row > 2 && row < 6)
			{
				if (column < 3)
				{
					return 3;
				}

				if (column > 2 && column < 6)
				{
					return 4;
				}

				if (column > 5)
				{
					return 5;
				}
			}

			if (row > 5)
			{
				if (column < 3)
				{
					return 6;
				}

				if (column > 2 && column < 6)
				{
					return 7;
				}

				if (column > 5)
				{
					return 8;
				}
			}

			return -1;
		}

		public void loadGrid(GameGrid grid, int row, int column, int value)
		{
			SudokuCell sCell = (SudokuCell)grid.Cells[row, column];
			sCell.SetValue(value);
			sCell.notifyObservers();
		}

		public int processGrid(SudokuGrid sgrid)
		{
			SudokuCell sCell;
			SudokuCell tCell;
			List<int> allPossibleValues = new List<int>();
			int cellsSolved = 0;

			for (int r = 0; r < sgrid.Rows; r++)
			{
				for (int c = 0; c < sgrid.Columns; c++)
				{
					allPossibleValues.Clear();
					allPossibleValues.Add(1);
					allPossibleValues.Add(2);
					allPossibleValues.Add(3);
					allPossibleValues.Add(4);
					allPossibleValues.Add(5);
					allPossibleValues.Add(6);
					allPossibleValues.Add(7);
					allPossibleValues.Add(8);
					allPossibleValues.Add(9);

					// Get the SudokuCell (with its PossibleValues) from the GameGrid at this row and column.
					sCell = (SudokuCell)sgrid.Cells[r, c];
					if (sCell.PossibleValues.Count < 2)
					{
						continue;
					}

					// Build a temporary cell to check values for this row and column
					for (int i1 = 0; i1 < 9; i1++)
					{
						if (allPossibleValues.Count < 2)
						{
							break;
						}

						// Skip the cell I'm on
						if (i1 != r)
						{
							tCell = (SudokuCell)sgrid.Cells[i1, c];
							if (tCell.PossibleValues.Count < 2)
							{
								allPossibleValues.Remove(tCell.Value());
							}
						}

						if (i1 != c)
						{
							tCell = (SudokuCell)sgrid.Cells[r, i1];
							if (tCell.PossibleValues.Count < 2)
							{
								allPossibleValues.Remove(tCell.Value());
							}
						}
					}

					// Check the values in this quadrant
					// my quadrant == sCell.Quadrant
					for (int qr = 0; qr < 9; qr += 1)
					{
						for (int qc = 0; qc < 9; qc += 1)
						{
							tCell = (SudokuCell)sgrid.Cells[qr, qc];
							if (tCell.Quadrant == sCell.Quadrant)
							{
								if (tCell.PossibleValues.Count < 2)
								{
									//Console.WriteLine("Removing possible value [{0},{1}]...[{2}]", r,c,tCell.Value());
									allPossibleValues.Remove(tCell.Value());
								}
							}
						}
					}

					if (allPossibleValues.Count < 2)
					{
						foreach (var cellValue in allPossibleValues)
						{
							sCell.SetValue(cellValue);
						}
						Console.WriteLine("*** Solved [{0},{1}] with value [{2}]",r,c,sCell.Value());
						cellsSolved += 1;
					}
					Console.Write("Possible values for [{0},{1}]",r,c);
					foreach (var v in allPossibleValues)
					{
						Console.Write(v + " ");
					}
					Console.WriteLine();
				}
			}
			return cellsSolved;
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

		public void displaySudokuGridPossibleValues(SudokuGrid sgrid)
		{
			Console.WriteLine();
			Console.WriteLine();

			for (int r = 0; r < sgrid.Rows; r++)
			{
				for (int c = 0; c < sgrid.Columns; c++)
				{

					var sCell = (SudokuCell)sgrid.Cells[r, c];
					Console.Write("Possible Values [" + r + "," + c + "]");
					foreach (var val in sCell.PossibleValues)
					{
						Console.Write(val + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine();
			}
		}
	}
}

