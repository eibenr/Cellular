
namespace Cellular {

	public class AutomataGridWrapped : AutomataGrid {

		public AutomataGridWrapped (int columns, int rows, GridCoordinate [] neighborhoodCoordinates, int [,] initialState = null) : base (columns, rows, neighborhoodCoordinates, initialState) {
		}

		public override int CountNeighbors (int cellX, int cellY) {
			int neighbors = 0;
			for (int neighborIndex = 0; neighborIndex < _neighborhoodCoordinates.Length; ++neighborIndex) {
				GridCoordinate neighborCoordinate = _neighborhoodCoordinates [neighborIndex];
				int x = neighborCoordinate.X + cellX;
				int y = neighborCoordinate.Y + cellY;
				// Wrap the horizontal boundaries
				if (x < 0) {
					x = x + _columns;
				} else if (x >= _columns) {
					x = x - _columns;
				}
				// Wrap the vertical boundaries
				if (y < 0) {
					y = y + _rows;
				} else if (y >= _rows) {
					y = y - _rows;
				}
				// Add this neighbor if it is non-zero
				if (_matrix [x, y].State > 0) {
					++neighbors;
				}
			}
			return neighbors;
		}

	}
}
