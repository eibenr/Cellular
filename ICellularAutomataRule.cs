
namespace Cellular {

	public interface ICellularAutomataRule {
	
		int Evaluate (AutomataCell cell, int neighbors);
	}
}