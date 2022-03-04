using System;
using System.Numerics;
using Raylib_cs; // Raylib
using System.Collections.Generic;
using System.Text;

namespace pathfinding {
    class Visualizer {
        private Vector2 screenSize = new Vector2(400, 400);

        public Visualizer(string _title) {
            Raylib.InitWindow((int)screenSize.X, (int)screenSize.Y, _title);

            while (true) {
                if (Raylib.WindowShouldClose()) {
                    Raylib.CloseWindow();
                    break;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.EndDrawing();
            }
        }
    }
}
