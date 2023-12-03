using SpaceCircle.App.Systems;

namespace SpaceCircle.App;

internal class Program
{
    private static SceneManager? _sceneManager;

    public static float DeltaTime;

    private static void Main(string[] args)
    {
        InitWindow(1280, 720, "SpaceCircles");
        SetTargetFPS(60);
        GuiLoadStyleDefault();

        Console.WriteLine("Starting SceneManger");
        _sceneManager = new SceneManager();


        while (!WindowShouldClose())
        {
            DeltaTime = GetFrameTime();
            _sceneManager.RunScene();
        }
        CloseWindow();
    }
}