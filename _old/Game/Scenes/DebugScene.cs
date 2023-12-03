namespace Scenes
{
    public class DebugScene : SceneBase
    {
        public List<ObjectBase> SceneObjects = new List<ObjectBase>();

        private Button btnTest = new Button(new Rectangle { X = 10f, Y = 10f, width = 100, height = 40 }, "Test Button");

        public DebugScene()
        {
            SetTargetFPS(60);
            //init
            float x = GetScreenWidth();
            float y = GetScreenHeight();
            var planet = new Planet(new Vector2(x/2, y/2), 
                new Vector2(x/2, (y/2)), 0.0f, 10.0f, BLUE, 0.0f);
            SceneObjects.Add(planet);
        }

        public override void Draw()
        {
            ClearBackground(WHITE);
            
            btnTest.Draw();

            foreach (var obj in SceneObjects)
            {
                obj.Draw();
            }
        }

        public override int SwitchToScene()
        {
            return -1;
        }

        public override void Update()
        {
            if (btnTest.Pressed())
                Console.WriteLine("Test button pressed");

            foreach (var obj in SceneObjects)
            {
                obj.Update();
            }
        }
    }
}