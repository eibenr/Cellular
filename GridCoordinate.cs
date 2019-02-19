using System;

namespace Cellular {

	public enum GridDirection {
		None = 0,
		Up = 1,
		Right = 2,
		Down = 3,
		Left = 4,
	}

	public enum GridSublocation {
		None = 0,
		Center = 1,
		Top = 2,
		TopRight = 3,
		Right = 4,
		BottomRight = 5,
		Bottom = 6,
		BottomLeft = 7,
		Left = 8,
		TopLeft = 9,
	}

	public enum GridNeighborLocation {
		Above = 0,
		AboveRight = 1,
		Right = 2,
		BelowRight = 3,
		Below = 4,
		BelowLeft = 5,
		Left = 6,
		AboveLeft = 7,
	}

	public struct GridCoordinate : IEquatable<GridCoordinate> {
		public int X { get; }
		public int Y { get; }

		public GridCoordinate (int x, int y) {
			X = x;
			Y = y;
		}

		public static GridCoordinate Zero = new GridCoordinate (0, 0);

		public static GridCoordinate GetRotatedCoordinate (GridCoordinate relativeGridCoordinate, GridDirection orientation) {
			switch (orientation) {
				case GridDirection.Right:
					return new GridCoordinate (relativeGridCoordinate.Y, -relativeGridCoordinate.X);
				case GridDirection.Down:
					return new GridCoordinate (-relativeGridCoordinate.X, -relativeGridCoordinate.Y);
				case GridDirection.Left:
					return new GridCoordinate (-relativeGridCoordinate.Y, relativeGridCoordinate.X);
			}
			return relativeGridCoordinate;
		}

		public static GridDirection GetRotatedDirection (GridDirection direction, GridDirection orientation) {
			switch (orientation) {
				case GridDirection.Right:
					switch (direction) {
						case GridDirection.Up:
							return GridDirection.Right;
						case GridDirection.Right:
							return GridDirection.Down;
						case GridDirection.Down:
							return GridDirection.Left;
						case GridDirection.Left:
							return GridDirection.Up;
					}
					break;
				case GridDirection.Down:
					switch (direction) {
						case GridDirection.Up:
							return GridDirection.Down;
						case GridDirection.Right:
							return GridDirection.Left;
						case GridDirection.Down:
							return GridDirection.Up;
						case GridDirection.Left:
							return GridDirection.Right;
					}
					break;
				case GridDirection.Left:
					switch (direction) {
						case GridDirection.Up:
							return GridDirection.Left;
						case GridDirection.Right:
							return GridDirection.Up;
						case GridDirection.Down:
							return GridDirection.Right;
						case GridDirection.Left:
							return GridDirection.Down;
					}
					break;
			}
			return direction;
		}

		public string Save () {
			return string.Format ("{0},{1}", X, Y);
		}

		public static GridCoordinate Restore (string saved) {
			string [] savedSplit = saved.Split (new char [] { ',' });
			int x = Convert.ToInt32 (savedSplit [0]);
			int y = Convert.ToInt32 (savedSplit [1]);
			return new GridCoordinate (x, y);
		}

		public bool Equals (GridCoordinate other) {
			return X == other.X && Y == other.Y;
		}
	}
}