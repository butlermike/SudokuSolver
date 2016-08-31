using System;
namespace SudokuSolver
{
	public interface ISubject
	{
		void registerObserver(Cell c);

		void removeObserver(Cell c);

		void notifyObservers();
	}
}

