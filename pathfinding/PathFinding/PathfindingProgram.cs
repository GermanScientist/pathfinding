using Raylib_cs; // Raylib

namespace pathfinding {
    class PathfindingProgram {
        public PathfindingProgram() { }

        //Everything in the draw function will be updated every frame and able to be drawn in the visualizer
        public void Draw() {
            //Create a grid of red squares, with a size of 50x50, with a space of 10 units between each cell
            int distance = 10;
            int size = 50;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    Raylib.DrawRectangle(distance + (i * (distance+size)), distance + (j * (distance + size)), size, size, Color.RED);
                }
            }
        }
    }
}
