using SpaceCircle.App.Game.Objects;
using SpaceCircle.App.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.Scenes;

public class DebugScene : Scene
{
    public override bool Initialized => _initialized;

    private Dictionary<Guid, GameObject> sceneObjects;

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
        sceneObjects.Add(Guid.NewGuid(), new Box(new Vector2(100, 100), new Vector2(20, 20), BLUE));

        _initialized = true;
    }

    public override void RunScene() => Update();


    protected override void Update()
    {
        BeginDrawing();
        ClearBackground(LIGHTGRAY);

        foreach (GameObject gameObject in sceneObjects.Values)
            gameObject.Update();

        EndDrawing();
    }
}