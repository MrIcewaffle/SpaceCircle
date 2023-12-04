using SpaceCircle.App.Game.GUI;
using SpaceCircle.App.Game.Objects;
using SpaceCircle.App.BaseObjects;
using System.Numerics;
using SpaceCircle.App.Systems;

namespace SpaceCircle.App.Game.Scenes;

public class DebugScene : Scene
{
    public override bool Initialized => _initialized;

    private DebugPanel debugPanel;


    public DebugScene()
    {
    }

    public override void Dispose()
    {
        throw new NotImplementedException();
    }

    public override void InitializeScene()
    {

        debugPanel = new DebugPanel(this.GetType().Name);

        new Planet(new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), 10, 100);
        new Planet(new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), 30, 200);
        new Planet(new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), 10, 300);
        _initialized = true;
    }

    public override void RunScene()
    {
        BeginDrawing();
        ClearBackground(LIGHTGRAY);

        debugPanel.Update();
        SystemBase.Update();

        Update();
        EndDrawing();
    }

    protected override void Update()
    {
    }
}