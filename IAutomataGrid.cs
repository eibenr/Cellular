using System;

namespace Cellular {

	public interface IAutomataGrid {

		AutomataCell GetCell (int x, int y);
		void VisitMatrix (AutomataCellVisitor action);
		void VisitMatrix (Action<int> action);
		void CopyMatrix (int [,] matrix);
		void Reset ();
	}
}
