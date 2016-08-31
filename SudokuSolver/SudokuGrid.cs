using System;
namespace SudokuSolver
{
	public class SudokuGrid : GameGrid
	{
		public SudokuGrid()
		{
			Rows = 9;
			Columns = 9;
			Cells = new SudokuCell[Rows, Columns];
		}
	}
}

