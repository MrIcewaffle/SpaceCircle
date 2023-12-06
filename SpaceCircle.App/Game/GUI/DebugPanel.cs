using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.GUI;

public class DebugPanel : Entity
{
    private Transform2D? _transform;
    private Rectangle _background;
    private string sceneName = string.Empty;
    private int entities;
    private int components;
    private string? runtime;
    private string? fps;


    public DebugPanel(string sceneName)
    {
        _transform = new Transform2D();
        _background = new Rectangle(0, 0, 300, 150);

        AddComponent(_transform);
        RegisterEntity(this);
    }

    public override void Update(float deltaTime)
    {
        entities = SystemBase.EntityCount();
        components = SystemBase.ComponentCount();
        runtime = GetTime().ToString();
        fps = GetFPS().ToString();

        DrawRectangleRec(_background, LIGHTGRAY);

        DrawText("Run duration(sec):", 10, 10, 10, BLACK);
        DrawText(runtime, 110, 10, 10, BLACK);

        DrawText("Frames/sec:", 10, 25, 10, BLACK);
        DrawText(fps, 110, 25, 10, BLACK);

        DrawText("ms/Frame:", 10, 40, 10, BLACK);
        DrawText(deltaTime.ToString(), 110, 40, 10, BLACK);

        DrawText("Scene:", 10, 70, 10, BLACK);
        DrawText(sceneName, 110, 70, 10, BLACK);

        DrawText("Entities:", 10, 85, 10, BLACK);
        DrawText(entities.ToString(), 110, 85, 10, BLACK);

        DrawText("Components:", 10, 100, 10, BLACK);
        DrawText(components.ToString(), 110, 100, 10, BLACK);
    }
}
