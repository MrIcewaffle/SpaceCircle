using SpaceCircle.App.BaseObjects;
using SpaceCircle.App.Systems;
using System.Numerics;

namespace SpaceCircle.App.Game.GUI;

public class DebugPanel
{
    private string SceneName;
    private int Entities;
    private int Components;

    private Rectangle basePanel;
    private string runtime;
    private string fps;
    private string deltaTime;

    public DebugPanel(string scene)
    {
        SceneName = scene;
        basePanel = new Rectangle(0, 0, 300, 150);
    }

    public void Draw()
    {
        DrawRectangleRec(basePanel, LIGHTGRAY);
        DrawRectangleLinesEx(basePanel, 1, GRAY);

        DrawText("Run duration(sec):", 10, 10, 10, BLACK);
        DrawText(runtime, 110, 10, 10, BLACK);

        DrawText("Frames/sec:", 10, 25, 10, BLACK);
        DrawText(fps, 110, 25, 10, BLACK);

        DrawText("ms/Frame:", 10, 40, 10, BLACK);
        DrawText(deltaTime, 110, 40, 10, BLACK);

        DrawText("Scene:", 10, 70, 10, BLACK);
        DrawText(SceneName, 110, 70, 10, BLACK);

        DrawText("Entities:", 10, 85, 10, BLACK);
        DrawText(Entities.ToString(), 110, 85, 10, BLACK);

        DrawText("Components:", 10, 100, 10, BLACK);
        DrawText(Components.ToString(), 110, 100, 10, BLACK);
    }

    public void Update()
    {
        Entities = SystemBase.EntityCount();
        Components = SystemBase.ComponentCount();
        runtime = GetTime().ToString();
        fps = GetFPS().ToString();
        deltaTime = GetFrameTime().ToString();
        Draw();
    }
}