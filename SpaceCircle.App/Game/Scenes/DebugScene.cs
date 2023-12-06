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

        new DebugPanel(this.GetType().Name);
        new PlayerCamera();
        new Planet(Vector2.Zero, 10, 100);
        new Planet(Vector2.Zero, 30, 200);
        new Planet(Vector2.Zero, 10, 300);
        _initialized = true;
    }

    public override void RunScene()
    {
        Update();
        SystemBase.Update();
    }

    protected override void Update()
    {
    }
}