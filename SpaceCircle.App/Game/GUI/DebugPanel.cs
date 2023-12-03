using SpaceCircle.App.Objects;
using System.Numerics;

namespace SpaceCircle.App.Game.GUI;

public class DebugPanel : GameObject
{
    public override bool IsActive => _isActive;

    public override bool IsVisible => _isVisible;

    public string SceneName;
    public int SceneObjects;
    public int ActiveSceneObjects;

    private Rectangle basePanel;
    private string runtime;
    private string fps;
    private string deltaTime;

    public DebugPanel()
    {
        basePanel = new Rectangle(0, 0, 300, 150);
    }

    public override void Draw()
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

        DrawText("Objects in scene:", 10, 85, 10, BLACK);
        DrawText(SceneObjects.ToString(), 110, 85, 10, BLACK);

        DrawText("Active in scene:", 10, 100, 10, BLACK);
        DrawText(ActiveSceneObjects.ToString(), 110, 100, 10, BLACK);
    }

    public override void Update()
    {
        if (!_isActive)
            return;
        runtime = GetTime().ToString();
        fps = GetFPS().ToString();
        deltaTime = GetFrameTime().ToString();
        Draw();
    }
}