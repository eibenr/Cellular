using System;

namespace Cellular {

	public struct GridRectangle : IEquatable<GridRectangle> {

		public int X { get; }
		public int Y { get; }
		public int Width { get; }
		public int Height { get; }

		public GridSize Size { get { return new GridSize (Width, Height); } }
		public GridCoordinate Origin { get { return new GridCoordinate (X, Y); } }
		public GridSize Extent { get { return new GridSize (X + Width, Y + Height); } }

		public GridRectangle (int x, int y, int width, int height) {
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public GridRectangle (GridSize size, GridCoordinate coordinate) {
			X = coordinate.X;
			Y = coordinate.Y;
			Width = size.Width;
			Height = size.Height;
		}

		public static GridRectangle Zero = new GridRectangle (0, 0, 0, 0);

		public bool IsContained (GridCoordinate coordinate) {
			return (coordinate.X >= X) && (coordinate.X < X + Width) && (coordinate.Y >= Y) && (coordinate.Y < Y + Height);
		}

		public string Save () {
			return string.Format ("{0},{1},{2},{3}", X, Y, Width, Height);
		}

		public static GridRectangle Restore (string saved) {
			string [] savedSplit = saved.Split (new char [] { ',' });
			int x = Convert.ToInt32 (savedSplit [0]);
			int y = Convert.ToInt32 (savedSplit [1]);
			int width = Convert.ToInt32 (savedSplit [2]);
			int height = Convert.ToInt32 (savedSplit [3]);
			return new GridRectangle (x, y, width, height);
		}

		public bool Equals (GridRectangle other) {
			return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
		}
	}
}