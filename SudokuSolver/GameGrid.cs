using System;
namespace SudokuSolver
{
	public abstract class GameGrid
	{
		private int rows;
		private int columns;
		private Cell[,] cells;

		public GameGrid()
		{
		}

		public GameGrid(int rowval, int colval)
		{
			this.rows = rowval;
			this.columns = colval;
			this.cells = new Cell[this.rows, this.columns];
		}

		public virtual int Rows
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

		public virtual int Columns
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

		public virtual Cell[,] Cells
		{
			get
			{
				return cells;
			}
		}
		public void setCell(int row, int column, Cell cell)
		{
			cells[row, column] = cell;
		}
	}
}