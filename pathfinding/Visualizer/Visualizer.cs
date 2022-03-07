using System;
using System.Numerics;
using Raylib_cs;

namespace visualizer {
    class Visualizer {
        private ProgramBase program;

        //The constructor for the visualizer class
        public Visualizer(string _title, ProgramBase _program) {
            program = _program; //Assign the program
            Raylib.InitWindow((int)Settings.ScreenSize.X, (int)Settings.ScreenSize.Y, _title); //Initialize a window
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
                program.Update(); //Draw everything made in the pathfinder script
            Raylib.EndDrawing();

            return true; //If this method returns true, another loop will start
        }
    }
}
