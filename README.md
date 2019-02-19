# Cellular
Cellular Automata framework and library

This work is Copyright 2019 Robert J. Eiben and licensed under the MIT License. See LICENSE.txt for details.

Synopsis

Cellular allows you to build and run cellular automata. It comes with the implementation of Lifelike Cellular Automata, much like
Conway's Game of Life. Other implementations can be added as needed.

Usage

Include the Cellular namespace in any file that needs access. Use the CellularAutomataFactory to create your CA. Currently the supported CA implementation is:

public static CellularAutomata CreateLifelikeAutomata (int columns, int rows, string ruleString, CellularAutomataEdgeHandling edgeHandling, int [,] initialState = null);

where:

columns - The number or horizontal columns in the grid.
    
rows - The number of vertical rows in the grid.

ruleString - A rule string of the form B(birth neighbor counts)/S(survival neighbor counts). Many existing rules can be found as public static strings on LifelikeCellularAutomataRule. For example, John Conway's Life is B3/S23.

edgeHandling - Whether cells beyond the edges of the grid are ignored or wrapped.

initialState - An optional initial state of the grid. If absent the grid is randomly initiatlized with a randomized 50/50 mix of 1s and 0s.
        
Once you have your CA, you can get the current state by inspecting the CA.Grid property which returns an IAutomataGrid reference to the current state.

Iterate the rule by calling CA.Evaluate (iterations). This evaluates the rule on the grid for a certain number of iterations. The method returns the total number of iterations that have been evaluated to date. Reset the CA by calling CA.Reset (). This resets the grid to its initial state or re-randomizes the grid if no initial state is provided and resets the iteration count to 0.
 
 
