using Raylib_cs;
using System;

namespace pathfinding {
    class Cell {
        //Properties
        private int x; //The x position of the cell
        private int y; //The y position of the cell

        private int width;
        private int height;

        //The variables needed for the formula f(n) = g(n) + h(n), n being the next node on the path
        public int F { get; private set; } //Total cost of the node
        public int G { get; private set; } //Cost from start to N node
        public int H { get; private set; } //Cost from N to end node
        
        //The cell positions
        public int X { get { return x; } }
        public int Y { get { return y; } }

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
        }

        //Draw the cell
        public void DrawCell(Color _cellColor) {
            Raylib.DrawRectangle(x * width, y * height, width, height, _cellColor); //Draw the cell rectangle
            Raylib.DrawRectangleLines(x * width, y * height, width, height, Color.BLACK); //Draw the cell outline
        }
    }
}
