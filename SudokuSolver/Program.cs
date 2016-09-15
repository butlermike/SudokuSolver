using System;

namespace SudokuSolver
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Start...");


			int rowcount = 9;
			int columncount = 9;

			SudokuGrid theGrid = new SudokuGrid(rowcount, columncount);
			SudokuEngine engine = new SudokuEngine(theGrid);

			SudokuGrid gameGrid = engine.initializeGrid(theGrid);

			engine.loadGrid(gameGrid, 0, 2, 4);
			engine.loadGrid(gameGrid, 0, 5, 7);
			engine.loadGrid(gameGrid, 0, 6, 5);
			engine.loadGrid(gameGrid, 0, 7, 1);

			engine.loadGrid(gameGrid, 1, 2, 7);
			engine.loadGrid(gameGrid, 1, 4, 4);
			engine.loadGrid(gameGrid, 1, 7, 9);
			engine.loadGrid(gameGrid, 1, 8, 8);

			engine.loadGrid(gameGrid, 2, 1, 6);
			engine.loadGrid(gameGrid, 2, 3, 1);
			engine.loadGrid(gameGrid, 2, 5, 9);

			engine.loadGrid(gameGrid, 3, 0, 4);
			engine.loadGrid(gameGrid, 3, 3, 9);
			engine.loadGrid(gameGrid, 3, 4, 3);
			engine.loadGrid(gameGrid, 3, 8, 5);

			engine.loadGrid(gameGrid, 4, 0, 9);
			engine.loadGrid(gameGrid, 4, 1, 7);
			engine.loadGrid(gameGrid, 4, 7, 6);
			engine.loadGrid(gameGrid, 4, 8, 3);

			engine.loadGrid(gameGrid, 5, 0, 1);
			engine.loadGrid(gameGrid, 5, 4, 7);
			engine.loadGrid(gameGrid, 5, 5, 2);
			engine.loadGrid(gameGrid, 5, 8, 4);

			engine.loadGrid(gameGrid, 6, 3, 2);
			engine.loadGrid(gameGrid, 6, 5, 3);
			engine.loadGrid(gameGrid, 6, 7, 5);

			engine.loadGrid(gameGrid, 7, 0, 6);
			engine.loadGrid(gameGrid, 7, 1, 5);
			engine.loadGrid(gameGrid, 7, 4, 9);
			engine.loadGrid(gameGrid, 7, 6, 7);

			engine.loadGrid(gameGrid, 8, 1, 2);
			engine.loadGrid(gameGrid, 8, 2, 1);
			engine.loadGrid(gameGrid, 8, 3, 7);
			engine.loadGrid(gameGrid, 8, 6, 6);

			engine.displaySudokuGrid(gameGrid);

			for (int j = 0; j < 64; j += 1)
			{
				var solved = engine.processGrid(gameGrid);

				engine.displaySudokuGrid(gameGrid);
				engine.displaySudokuGridPossibleValues(gameGrid);

				if (solved == 0)
				{
					Console.WriteLine("Solved.");
					break;
				}
			}
			engine.displaySudokuGridPossibleValues(gameGrid);
			Console.WriteLine("Wait here.");
			Console.WriteLine("...Finish.");

		}
	}
}
