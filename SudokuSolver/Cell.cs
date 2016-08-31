using System;
namespace SudokuSolver
{
	public abstract class Cell
	{
		int id;

		public Cell()
		{
		}

		public int Id
		{
			get
			{
				return id;
			}

			set
			{
				id = value;
			}
		}
	}
}

