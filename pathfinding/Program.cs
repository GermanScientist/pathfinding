namespace pathfinding {
    class Program {
        static void Main(string[] args) {
            Visualizer visualizer = new Visualizer("Pathfinding", new Pathfindinder()); //Create a window that runs the pathfinding program
            while (visualizer.Run()) { ; } //Create an update loop to start running the application
        }
    }
}
