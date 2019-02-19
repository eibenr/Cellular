
namespace Cellular {

	public class CellularAutomata {

		protected AutomataGrid _grid;
		public IAutomataGrid Grid { get { return _grid; } }

		public int Iterations { get; private set; }

		protected readonly ICellularAutomataRule _rule;

		public CellularAutomata (AutomataGrid grid, ICellularAutomataRule rule) {
			_grid = grid;
			_rule = rule;
		}

		public void Reset () {
			Iterations = 0;
			Grid.Reset ();
		}

		public int Evaluate (int iterations) {
			for (int iteration = 0; iteration < iterations; ++iteration) {
				++Iterations;
				_grid.VisitMatrix ((int x, int y, AutomataCell cell) => {
					int result = _rule.Evaluate (cell, _grid.CountNeighbors (x, y));
					_grid.SetNextCell (x, y, new AutomataCell (cell.State, result));
				});
				// Swap matrices so that _matrix always shows the latest state
				_grid.SwapMatricies ();
			}
			return Iterations;
		}

	}
}
