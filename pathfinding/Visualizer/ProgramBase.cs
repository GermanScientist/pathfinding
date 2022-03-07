namespace visualizer {
    class ProgramBase {
        //Everything in the update function will be updated every frame and able to be drawn in the visualizer
        public virtual void Update() { }

        //Everything in the setup method will be ran once at the start of the script
        public virtual void Setup() { }
    }
}
