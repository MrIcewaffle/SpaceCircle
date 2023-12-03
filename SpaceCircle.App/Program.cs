using SpaceCircle.App.Systems;

namespace SpaceCircle.App;

internal class Program
{
    private static SceneManager? _sceneManager;

    private static void Main(string[] args)
    {
        InitWindow(1280, 720, "SpaceCircles");
        SetTargetFPS(60);
        GuiLoadStyleDefault();

        Console.WriteLine("Starting SceneManger");
        _sceneManager = new SceneManager();

        while (!WindowShouldClose())
        {
            _sceneManager.RunScene();
        }
        CloseWindow();
    }
}