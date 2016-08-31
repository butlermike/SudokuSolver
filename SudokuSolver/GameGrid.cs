using System;
namespace SudokuSolver
{
	public abstract class GameGrid
	{
		int rows;
		int columns;
		Cell[,] cells;

		public GameGrid()
		{
		}

		public int Rows
		{
			get
			{
				return rows;
			}

			set
			{
				rows = value;
			}
		}

		public int Columns
		{
			get
			{
				return columns;
			}

			set
			{
				columns = value;
			}
		}

		public Cell[,] Cells
		{
			get
			{
				return cells;
			}

			set
			{
				cells = value;
			}
		}
		public void setCell(int row, int column, Cell cell)
		{
			cells[row, column] = cell;
		}
	}
}

