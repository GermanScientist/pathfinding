using System;
using System.Collections.Generic;
using Raylib_cs;

namespace pathfinding {
    class Pathfindinder : ProgramBase {
        //Properties
        private List<List<Cell>> grid; //The grid list
        private List<Cell> openSet; //Stores a list of nodes that still need to be evaluated
        private List<Cell> closedSet; //Stores a list of all the nodes that have finished being evaluated

        private int columnsAmount; //The amount of columns (horizontally)
        private int rowsAmount; //The amount of rows (vertically)

        private int cellWidth;
        private int cellHeight;

        //The constructor
        public Pathfindinder() {
            //Initialize the properties
            columnsAmount = 10;
            rowsAmount = 10;

            //Set the width and height of the cells depending on the screensize
            cellWidth = (int)Settings.ScreenSize.X / columnsAmount; ;
            cellHeight = (int)Settings.ScreenSize.Y / rowsAmount; ;

            //Create a 2 dimensional list of cells
            grid = new List<List<Cell>>(columnsAmount);
            for (int i = 0; i < columnsAmount; i++) {
                grid.Add(new List<Cell>(rowsAmount));
                for (int j = 0; j < columnsAmount; j++) {
                    grid[i].Add(new Cell(i, j, cellWidth, cellHeight)); //Cell(x, y, width, height)
                }
            }

            //Create an empty list for the open and closed sets
            openSet = new List<Cell>();
            closedSet = new List<Cell>();

            Setup();
        }

        //Everything in the setup function will execute once at the start
        public override void Setup() {
            Cell startCell = grid[0][0]; //Assign the start cell
            Cell finishCell = grid[columnsAmount - 1][rowsAmount - 1]; //Assign the finish cell

            openSet.Add(startCell); //Add the start cell to the open set
        }

        //Everything in the update function will be updated every frame and able to be drawn in the visualizer
        public override void Update() {
            //Check if there is anything in the open set
            if(openSet.Count > 0) {
                //We can continue
            }
            else {
                //No solution
            }

            //Draw the cells
            for (int i = 0; i < columnsAmount; i++) {
                for (int j = 0; j < rowsAmount; j++) {
                    grid[i][j].DrawCell();
                }
            }
        }
    }
}
