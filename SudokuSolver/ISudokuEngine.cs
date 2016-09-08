using System;
namespace SudokuSolver
{
	public interface ISudokuEngine
	{
		SudokuGrid initializeGrid(GameGrid grid);
		void displaySudokuGrid(SudokuGrid sgrid);
	}
}

