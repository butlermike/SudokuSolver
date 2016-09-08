using System;
namespace SudokuSolver
{
	public class SudokuGrid : GameGrid
	{
		private int rows;
		private int columns;
		private Cell[,] cells;

		public SudokuGrid(int rowcount, int columncount)
		{
			
			this.rows = rowcount;
			this.columns = columncount;
			this.cells = new Cell[this.rows, this.columns];
		}

		public override int Rows
		{
			get
			{
				return rows;
			}
		}

		public override int Columns
		{
			get
			{
				return columns;
			}
		}

		public override Cell[,] Cells
		{
			get
			{
				return cells;
			}
		}
	}
}

