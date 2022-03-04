using System;
using System.Numerics;
using Raylib_cs; // Raylib

namespace pathfinding {
    class Visualizer {
        private Vector2 screenSize = new Vector2(400, 400);
        private PathfindingProgram pathfinder;

        //The constructor for the visualizer class
        public Visualizer(string _title) {
            Raylib.InitWindow((int)screenSize.X, (int)screenSize.Y, _title); //Initialize a window
            pathfinder = new PathfindingProgram(); //A pointer to the pathfinder class
        }

        //Run every frame of the window
        public bool Run() {
            //Close the window if the user tries to close the window
            if (Raylib.WindowShouldClose()) { 
                Raylib.CloseWindow();
                return false; //If this method returns false, the loop will end
            }

            //Start drawing (everything between begin and end drawing will be drawn)
            Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK); //Clear the background
                pathfinder.Draw(); //Draw everything made in the pathfinder script
            Raylib.EndDrawing();

            return true; //If this method returns true, another loop will start
        }
    }
}
