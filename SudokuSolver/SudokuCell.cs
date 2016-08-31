using System;
using System.Collections.Generic;

namespace SudokuSolver
{
	public class SudokuCell : Cell, ISubject, IObserver
	{
		List<int> possibleValues;
		List<Cell> observers;
		int quadrant;

		public SudokuCell()
		{
		}

		public List<int> PossibleValues
		{
			get
			{
				return possibleValues;
			}

			set
			{
				possibleValues = value;
			}
		}

		public List<Cell> Observers
		{
			get
			{
				return observers;
			}

			set
			{
				observers = value;
			}
		}

		public int Quadrant
		{
			get
			{
				return quadrant;
			}

			set
			{
				quadrant = value;
			}
		}

		public void registerObserver(Cell sudokuCell)
		{
			Observers.Add(sudokuCell);
		}

		public void removeObserver(Cell sudokuCell)
		{
			Observers.Remove(sudokuCell);
		}

		public void notifyObservers()
		{
			foreach (SudokuCell observer in Observers)
			{
				observer.update();
			}
		}

		//public void registerObserver(SudokuCell sudokuCell)
		//{
		//	Observers.Add(sudokuCell);
		//}

		//public void removeObserver(SudokuCell sudokuCell)
		//{
		//	Observers.Remove(sudokuCell);
		//}

		//public void notifyObservers()
		//{
		//	foreach (var observer in Observers)
		//	{
		//		observer.update();
		//	}
		//}

		public void update()
		{
			Console.WriteLine("Update!");
		}

	}
}

