using System;
using Raylib_cs;
using System.Collections.Generic;

namespace visualizer {
    namespace pathfinding {
        class Cell {
            //Properties
            private int x; //The x position of the cell
            private int y; //The y position of the cell

            private int width; //Cell width
            private int height; //Cell height

            private bool walkable; //Bool to see whether this tile is walkable or not
            private float walkablePercentage; //A number between 0 and 1 to see how likely the tile is to become unwalkable

            private List<Cell> neighbors;
            private Cell parent;

            //The variables needed for the formula f(n) = g(n) + h(n), n being the next node on the path
            public int F { get; set; } //Total cost of the node
            public int G { get; set; } //Cost from start to N node
            public int H { get; set; } //Cost from N to end node

            //The cell positions
            public int X { get { return x; } }
            public int Y { get { return y; } }
            public bool Walkable { get { return walkable; } set { walkable = value; } }

            //A list of this cell's neighboors
            public List<Cell> Neighbors { get { return neighbors; } }
            public Cell Parent { get { return parent; } set { parent = value; } }

            public Cell(int _x, int _y, int _width, int _height) {
                //The variables needed for the formula f(n) = g(n) + h(n), n being the next node on the path
                F = 0; //f(n) is the total cost of the node
                G = 0; //g(n) is the cost from the start node to n
                H = 0; //h(n) is a heuristic function that estimates the cost of the cheapest path from n to the end

                //The cell positions and size
                x = _x;
                y = _y;
                width = _width;
                height = _height;

                //Create an empty list of neighbors
                neighbors = new List<Cell>();

                //Randomly set some tiles as unwalkable
                Random random = new Random(); //Initialize the random class
                walkablePercentage = 0.3f;
                walkable = random.NextDouble() > walkablePercentage ? true : false; //There is a 30% chance of the tile becoming unwalkable
            }

            //Draw the cell
            public void DrawCell(Color _cellColor) {
                if (!walkable) _cellColor = Color.BLACK;
                Raylib.DrawRectangle(x * width, y * height, width, height, _cellColor); //Draw the cell rectangle
                Raylib.DrawRectangleLines(x * width, y * height, width, height, Color.BLACK); //Draw the cell outline
            }

            //Add a neighboor to this cell
            public void AddNeighbors(List<List<Cell>> _grid, int _columns, int _rows) {
                //Add neighboors to this cell if the current cell isn't on an edge
                if (x < _columns - 1) neighbors.Add(_grid[x + 1][y]);
                if (x > 0) neighbors.Add(_grid[x - 1][y]);
                if (y < _rows - 1) neighbors.Add(_grid[x][y + 1]);
                if (y > 0) neighbors.Add(_grid[x][y - 1]);
            }
        }
    }
}