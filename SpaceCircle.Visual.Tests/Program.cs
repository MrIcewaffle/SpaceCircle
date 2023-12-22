using SpaceCircle.App.Base;
using SpaceCircle.App.Game.Scenes;

namespace SpaceCircle.Visual.Tests;
//TODO:Flesh out as visual test frameworky-thing-a-ma-bob

internal class Program
{
    static void Main(string[] args)
    {
        InitWindow(1280, 720, "Visual Tests");
        SceneSystem.LoadScene(new newDebugScene());
        while (!WindowShouldClose())
        {
            SceneSystem.Update();
        }
        CloseWindow();
    }
}