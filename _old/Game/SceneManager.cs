namespace Game
{
    public class SceneManager
    {
        public SceneBase? Scene;
        public SceneManager()
        {
            InitWindow(800, 600, "Hello there");
            GuiLoadStyleDefault();
        }

        public int Run()
        {
            Scene = new DebugScene();
            while (!WindowShouldClose())
            {
                if (Scene.SwitchToScene() != -1)
                {
                    //switch scene
                }

                Update();
                Draw();
            }
            return 0;
        }

        protected bool Update()
        {
            Scene?.Update();
            return true;
        }

        protected bool Draw()
        {
            BeginDrawing();

            Scene?.Draw();

            EndDrawing();

            return true;
        }
    }
}