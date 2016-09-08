using System;

namespace SudokuSolver
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Start...");

			// A Sudoku grid is 9 by 9
			int rowcount = 9;
			int columncount = 9;

			SudokuGrid theGrid = new SudokuGrid(rowcount, columncount);
			SudokuEngine engine = new SudokuEngine(theGrid);

			SudokuGrid gameGrid = engine.initializeGrid(theGrid);

			engine.displaySudokuGrid(gameGrid);

			var scell = (SudokuCell)gameGrid.Cells[0, 2];
			//scell.PossibleValues = 4;

			


			Console.WriteLine("...Finish.");
		}
	}
}
