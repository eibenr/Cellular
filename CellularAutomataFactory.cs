using System;

namespace Cellular {

	public enum CellularAutomataNeighborhoodType {
		VonNeumann,
		ExtendedVonNeumann,
		Moore,
	}

	public enum CellularAutomataEdgeHandling {
		Ignore,
		Wrap,
	}

	public static class CellularAutomataFactory {

		private static readonly GridCoordinate [] _vonNeumannCoordinates = { new GridCoordinate (-1, 0), new GridCoordinate (0, 1), new GridCoordinate (1, 0), new GridCoordinate (0, -1) };
		private static readonly GridCoordinate [] _extendedVonNeumannCoordinates = { new GridCoordinate (-2, 0), new GridCoordinate (-1, 0), new GridCoordinate (0, 1), new GridCoordinate (0, 2), new GridCoordinate (1, 0), new GridCoordinate (2, 0), new GridCoordinate (0, -1), new GridCoordinate (0, -2) };
		private static readonly GridCoordinate [] _mooreCoordinates = { new GridCoordinate (-1, 1), new GridCoordinate (-1, 0), new GridCoordinate (-1, 1), new GridCoordinate (0, -1), new GridCoordinate (0, 1), new GridCoordinate (1, -1), new GridCoordinate (1, 0), new GridCoordinate (1, 1) };

		public static CellularAutomataNeighborhoodType ToNeighborhood (string value) {
			return (CellularAutomataNeighborhoodType)Enum.Parse (typeof (CellularAutomataNeighborhoodType), value);
		}

		public static CellularAutomataEdgeHandling ToEdgeHandling (string value) {
			return (CellularAutomataEdgeHandling)Enum.Parse (typeof (CellularAutomataEdgeHandling), value);
		}

		public static CellularAutomata CreateLifelikeAutomata (int columns, int rows, string ruleString, CellularAutomataEdgeHandling edgeHandling, int [,] initialState = null) {

			// Create the lifelike rule
			var rule = new LifelikeCellularAutomataRule (ruleString);

			// Set up the neighborhood coordinates
			GridCoordinate [] neighborhoodCoordinates = null;
			switch (rule.NeighborhoodType) {
				case CellularAutomataNeighborhoodType.VonNeumann:
					neighborhoodCoordinates = _vonNeumannCoordinates;
					break;
				case CellularAutomataNeighborhoodType.ExtendedVonNeumann:
					neighborhoodCoordinates = _extendedVonNeumannCoordinates;
					break;
				case CellularAutomataNeighborhoodType.Moore:
					neighborhoodCoordinates = _mooreCoordinates;
					break;
			}

			// Build the correct grid based on the edge handling
			AutomataGrid grid = null;
			if (edgeHandling == CellularAutomataEdgeHandling.Wrap) {
				grid = new AutomataGridWrapped (columns, rows, neighborhoodCoordinates, initialState);
			} else {
				grid = new AutomataGrid (columns, rows, neighborhoodCoordinates, initialState);
			}

			return new CellularAutomata (grid, rule);
		}

	}
}