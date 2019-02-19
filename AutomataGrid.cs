using System;

namespace Cellular {

	public delegate void AutomataCellVisitor (int x, int y, AutomataCell cell);

	public class AutomataGrid : IAutomataGrid {

		protected readonly int _rows;
		protected readonly int _columns;
		protected readonly int [,] _initialState;
		protected readonly GridCoordinate [] _neighborhoodCoordinates;
		protected readonly Random _randomGenerator;

		protected AutomataCell [,] _matrix;
		protected AutomataCell [,] _nextMatrix;

		public AutomataGrid (int columns, int rows, GridCoordinate [] neighborhoodCoordinates, int [,] initialState = null) {
			_columns = columns;
			_rows = rows;
			_neighborhoodCoordinates = neighborhoodCoordinates;
			_initialState = initialState;
			_randomGenerator = new Random ();

			// Reset the matrix
			_matrix = new AutomataCell [columns, rows];
			_nextMatrix = new AutomataCell [columns, rows];
			Reset ();
		}

		public AutomataCell GetCell (int x, int y) {
			return _matrix [x, y];
		}

		public void SetCell (int x, int y, AutomataCell cell) {
			_matrix [x, y] = cell;
		}

		public AutomataCell GetNextCell (int x, int y) {
			return _nextMatrix [x, y];
		}

		public void SetNextCell (int x, int y, AutomataCell cell) {
			_nextMatrix [x, y] = cell;
		}

		public void VisitMatrix (AutomataCellVisitor action) {
			for (int x = 0; x < _columns; ++x) {
				for (int y = 0; y < _rows; ++y) {
					AutomataCell cell = _matrix [x, y];
					action (x, y, cell);
				}
			}
		}

		public void VisitMatrix (Action<int> action) {
			for (int x = 0; x < _columns; ++x) {
				for (int y = 0; y < _rows; ++y) {
					AutomataCell cell = _matrix [x, y];
					action (cell.State);
				}
			}
		}

		public void CopyMatrix (int [,] matrix) {
			for (int x = 0; x < _columns; ++x) {
				for (int y = 0; y < _rows; ++y) {
					matrix [x, y] = _matrix [x, y].State;
				}
			}
		}

		public void Reset () {
			// If we are handed an initial state then use it, else create a randomized matrix
			if (_initialState != null) {
				for (int x = 0; x < _columns; ++x) {
					for (int y = 0; y < _rows; ++y) {
						int state = _initialState [x, y];
						_matrix [x, y] = new AutomataCell (state, state);
					}
				}
			} else {
				for (int x = 0; x < _columns; ++x) {
					for (int y = 0; y < _rows; ++y) {
						int state = _randomGenerator.Next (2);
						_matrix [x, y] = new AutomataCell (state, state);
					}
				}
			}
		}

		public void SwapMatricies () {
			var temp = _matrix;
			_matrix = _nextMatrix;
			_nextMatrix = temp;
		}

		public virtual int CountNeighbors (int cellX, int cellY) {
			int neighbors = 0;
			for (int neighborIndex = 0; neighborIndex < _neighborhoodCoordinates.Length; ++neighborIndex) {
				GridCoordinate neighborCoordinate = _neighborhoodCoordinates [neighborIndex];
				int x = neighborCoordinate.X + cellX;
				int y = neighborCoordinate.Y + cellY;
				// Neighbors off the grid do not count
				if (x >= 0 && x < _columns && y >= 0 && y < _rows && _matrix [x, y].State > 0) {
					++neighbors;
				}
			}
			return neighbors;
		}

	}
}
