using System;
using System.Numerics;
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

        private int cellWidth; //The cell width
        private int cellHeight; //The cell height

        private Cell startCell; //The starting point of the pathfinding search
        private Cell finishCell; //The finishing point of the pathfinding search

        //The constructor
        public Pathfindinder() {
            //Initialize the properties
            columnsAmount = 100;
            rowsAmount = 100;

            //Set the width and height of the cells depending on the screensize
            cellWidth = (int)Settings.ScreenSize.X / columnsAmount; ;
            cellHeight = (int)Settings.ScreenSize.Y / rowsAmount; ;

            //Create a 2 dimensional list of cells
            grid = new List<List<Cell>>(columnsAmount);
            for (int i = 0; i < columnsAmount; i++) {
                grid.Add(new List<Cell>(rowsAmount));
                for (int j = 0; j < columnsAmount; j++)
                    grid[i].Add(new Cell(i, j, cellWidth, cellHeight)); //Cell(x, y, width, height)
            }

            //Add the neighbors to each of the cells
            for(int i = 0; i < columnsAmount; i++)
                for (int j = 0; j < rowsAmount; j++)
                    grid[i][j].AddNeighbors(grid, columnsAmount, rowsAmount);

            //Create an empty list for the open and closed sets
            openSet = new List<Cell>();
            closedSet = new List<Cell>();

            Setup();
        }

        //Everything in the setup function will execute once at the start
        public override void Setup() {
            startCell = grid[0][0]; //Assign the start cell
            finishCell = grid[columnsAmount - 1][rowsAmount - 1]; //Assign the finish cell

            openSet.Add(startCell); //Add the start cell to the open set
        }

        //Everything in the update function will be updated every frame and able to be drawn in the visualizer
        public override void Update() {
            //Check if there is anything in the open set
            if(openSet.Count > 0) { //If there is anything in the open set, continue searching for a path
                int lowestIndex = 0; //The lowest number in the open set is the closest / is the winner
                for (int i = 0; i < openSet.Count; i++) {
                    //Sets the lowest index (the closest to being correct/the winner) to the lower value
                    //So if i is lower than the lowest index, the lowest index will become i
                    lowestIndex = openSet[i].F < openSet[lowestIndex].F ? i : lowestIndex; 
                }

                Cell currentCell = openSet[lowestIndex]; //Set the winning cell as the current cell, as it is first in the list

                //Check if the pathfinding algorythm has finished
                if (currentCell == finishCell) 
                    Console.WriteLine("DONE");

                //If the current cell isn't the finish cell, the search hasn't ended yet
                openSet.Remove(currentCell); //Remove the current cell from the open set
                closedSet.Add(currentCell); //Add the current cell to the closed set

                //Add all the neighbors of the current cell to the open set, but first evaluate them
                List<Cell> neighbors = currentCell.Neighbors; //Get the neighbors of the current cell
                for(var i = 0; i < neighbors.Count; i++) {
                    Cell neighbor = neighbors[i]; //Get the current neighbor

                    //If the neighbor is in the closed list, it shouldn't be evaluated
                    if(!closedSet.Contains(neighbor)) {
                        //If you move to a neighbor, g should increase by the distance between the current cell and the neighbor,
                        //seeing as g is the cost of getting to the next node
                        Vector2 currentCellPosition = new Vector2(currentCell.X, currentCell.Y);
                        Vector2 neighborPosition = new Vector2(neighbor.X, neighbor.Y);
                        int distanceBetweenCells = (int)Vector2.Distance(currentCellPosition, neighborPosition);
                        
                        int temporaryG = currentCell.G + distanceBetweenCells; //Create a temporary g value

                        //Check if the neighbor has already been evaluated
                        if (openSet.Contains(neighbor)) {
                            //If it has been evaluated, check if the current g is better than the evaluated g
                            //If the temporary g is better than the neighbor's g, set the neighbor's g to the temporary g
                            if (temporaryG < neighbor.G) neighbor.G = temporaryG; 
                        } else {
                            neighbor.G = temporaryG; //If the neighbor isn't in the open set, set the neighbor's g to the temporary g
                            openSet.Add(neighbor); //Add the neighbor to the open set
                        }

                        neighbor.H = CalculateHeuristic(neighbor, finishCell); //Calculate the neighbor's heuristic
                        neighbor.F = neighbor.G + neighbor.H; //Calculate the neighbor's total cost
                    }
                }
            }
            else { //If there is nothing in the open set, there is no solution and stop searching
            }

            //Draw the cells of the grid
            DrawCells();
        }
        
        //Draw the cells of the grid
        private void DrawCells() {
            //Draw the cells
            for (int i = 0; i < columnsAmount; i++) 
                for (int j = 0; j < rowsAmount; j++)
                    grid[i][j].DrawCell(Color.WHITE);

            //Look through the open set
            for (int i = 0; i < openSet.Count; i++)
                openSet[i].DrawCell(Color.GREEN); //Draw all the cells in the open set green

            //Look through the closed set
            for (int i = 0; i < closedSet.Count; i++) 
                closedSet[i].DrawCell(Color.RED); //Draw all the cells in the closed set red
        }

        //Calculate the heuristic
        private int CalculateHeuristic(Cell _neighbor, Cell _finishCell) {
            Vector2 neighborPosition = new Vector2(_neighbor.X, _neighbor.Y);
            Vector2 finishPosition = new Vector2(_finishCell.X, _finishCell.Y);
            return (int)Vector2.Distance(neighborPosition, finishPosition);
        }
    }
}
