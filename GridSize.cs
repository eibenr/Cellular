using System;

namespace Cellular {

	public struct GridSize : IEquatable<GridSize> {

		public int Width { get; }
		public int Height { get; }

		public GridSize (int width, int height) {
			Width = width;
			Height = height;
		}

		public static GridSize Zero = new GridSize (0, 0);

		public string Save () {
			return string.Format ("{0},{1}", Width, Height);
		}

		public static GridSize Restore (string saved) {
			string [] savedSplit = saved.Split (new char [] { ',' });
			int width = Convert.ToInt32 (savedSplit [0]);
			int height = Convert.ToInt32 (savedSplit [1]);
			return new GridSize (width, height);
		}

		public bool Equals (GridSize other) {
			return Width == other.Width && Height == other.Height;
		}
	}

}