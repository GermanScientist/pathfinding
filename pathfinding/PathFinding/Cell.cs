namespace pathfinding {
    class Cell {
        public int F { get; private set; }
        public int G { get; private set; }
        public int H { get; private set; }

        public Cell() {
            //The variables needed for the formula f(n) = g(n) + h(n), n being the next node on the path
            F = 0; //f(n) is the total cost of the node
            G = 0; //g(n) is the cost from the start node to n
            H = 0; //h(n) is a heuristic function that estimates the cost of the cheapest path from n to the end
        }
    }
}
