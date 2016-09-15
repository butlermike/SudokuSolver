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
			base.Id = DateTime.Now.Millisecond;
			this.possibleValues = new List<int>();
			this.possibleValues.Add(1);
			this.possibleValues.Add(2);
			this.possibleValues.Add(3);
			this.possibleValues.Add(4);
			this.possibleValues.Add(5);
			this.possibleValues.Add(6);
			this.possibleValues.Add(7);
			this.possibleValues.Add(8);
			this.possibleValues.Add(9);

			this.observers = new List<Cell>();
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
		public int Value()
		{
			int theValue=0;

			if (possibleValues.Count < 2)
			{
				foreach (int value in possibleValues)
				{
					theValue = value;
				}
			}
			return theValue;
		}
		public void SetValue(int value)
		{
			this.possibleValues.Clear();
			this.possibleValues.Add(value);
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

		public void update()
		{
			Console.WriteLine("Update!");
			foreach (SudokuCell observer in Observers)
			{
				if (this.PossibleValues.Count < 2)
				{
					foreach (var value in this.PossibleValues)
					{
						observer.PossibleValues.Remove(value);
					}

					// Future enhancement: If I have figured out what my value is, I can remove myself from observing other cells.
				}
			}
		}

	}
}

