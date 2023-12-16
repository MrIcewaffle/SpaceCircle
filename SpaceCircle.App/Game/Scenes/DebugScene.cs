using SpaceCircle.App.Game.GUI;
using SpaceCircle.App.Game.Objects;
using SpaceCircle.App.BaseObjects;
using System.Numerics;
using SpaceCircle.App.Systems;
using SpaceCircle.App.Game.Managers;

namespace SpaceCircle.App.Game.Scenes;

public class DebugScene : Scene
{
    public override bool Initialized => _initialized;

    private DebugPanel debugPanel;
    private Dictionary<Type, Guid> sceneObjects;


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
        new ConnectionManager();
        var v1 = new Planet(Vector2.Zero, 10, 100);
        var v2 = new Planet(Vector2.Zero, 30, 200);
        var v3 = new Planet(Vector2.Zero, 10, 300);
        new Sun(
            new object[] {
                v1.Id, v2.Id, v3.Id,
            });

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