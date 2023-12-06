using SpaceCircle.App.Game.Scenes;
using SpaceCircle.App.BaseObjects;

namespace SpaceCircle.App.Systems;

public class SceneManager
{
    protected List<Scene> Scenes; //TODO:set later
    protected Scene ActiveScene;

    public SceneManager()
    {
        //TODO:set list of scenes
        ActiveScene = new DebugScene();
    }

    public void RunScene()
    {
        if (!ActiveScene.Initialized)
            ActiveScene.InitializeScene();

        BeginDrawing();
        ClearBackground(LIGHTGRAY);

        ActiveScene.RunScene();

        EndDrawing();
    }
}