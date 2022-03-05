using System;
using System.Collections.Generic;
using Raylib_cs; // Raylib

namespace pathfinding {
    class Pathfindinder : ProgramBase {
        //Properties
        private List<List<Cell>> grid; //The grid list

        private int columnsAmount; //The amount of columns (horizontally)
        private int rowsAmount; //The amount of rows (vertically)

        //The constructor
        public Pathfindinder() {
            //Initialize the properties
            columnsAmount = 5;
            rowsAmount = 5;
            
            //Create a 2 dimensional list of cells
            grid = new List<List<Cell>>(columnsAmount);
            for (int i = 0; i < columnsAmount; i++) {
                grid.Add(new List<Cell>(rowsAmount));
                for (int j = 0; j < columnsAmount; j++) {
                    grid[i].Add(new Cell());
                }
            }
        }

        //Everything in the update function will be updated every frame and able to be drawn in the visualizer
        public override void Update() {
        }
    }
}
