using SpaceCircle.App.Game.GUI;
using SpaceCircle.App.Game.Objects;
using SpaceCircle.App.Objects;
using System.Numerics;

namespace SpaceCircle.App.Game.Scenes;

public class DebugScene : Scene
{
    public override bool Initialized => _initialized;

    private Dictionary<Guid, GameObject> sceneObjects;
    private DebugPanel debugPanel = new DebugPanel();


    public DebugScene()
    {
        sceneObjects = new Dictionary<Guid, GameObject>();
    }

    public override void Dispose()
    {
        throw new NotImplementedException();
    }

    public override void InitializeScene()
    {

        debugPanel.SceneName = this.GetType().Name;

        //sceneObjects.Add(Guid.NewGuid(), new Box(new Vector2(100, 100), new Vector2(20, 20), BLUE));
        sceneObjects.Add(Guid.NewGuid(), new Planet(Vector2.Zero, 10, new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), 100));
        sceneObjects.Add(Guid.NewGuid(), new Planet(Vector2.Zero, 30, new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), 200));
        sceneObjects.Add(Guid.NewGuid(), new Planet(Vector2.Zero, 10, new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), 300));
        _initialized = true;
    }

    public override void RunScene()
    {
        BeginDrawing();
        ClearBackground(LIGHTGRAY);

        debugPanel.SceneObjects = sceneObjects.Count();
        debugPanel.ActiveSceneObjects = sceneObjects.Where(t => t.Value.IsActive == true).Count();
        debugPanel.Update();

        Update();
        EndDrawing();
    }

    protected override void Update()
    {
        foreach (GameObject gameObject in sceneObjects.Values)
            gameObject.Update();
    }
}