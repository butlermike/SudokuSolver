using System;

namespace SudokuSolver
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Start...");

			SudokuEngine engine = new SudokuEngine();
			engine.GameGrid = new SudokuGrid();
			engine.initializeGrid();




			Console.WriteLine("...Finish.");
		}
	}
}
