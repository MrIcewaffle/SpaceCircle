using SpaceCircle.App.Game.Scenes;
using SpaceCircle.App.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        ActiveScene.RunScene();
    }
}

