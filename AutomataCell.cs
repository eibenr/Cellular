
namespace Cellular {

	public struct AutomataCell {

		public int State { get; }
		public int PreviousState { get; }

		public AutomataCell (int previousState, int state) {
			PreviousState = previousState;
			State = state;
		}
	}
}