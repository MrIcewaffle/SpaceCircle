namespace SpaceCircle.App.Objects;

/// <summary>
/// Base class for a scene.<br /><br />
/// Scenes must be registered with the SceneDictionary in SceneManager.
/// </summary>
public abstract class Scene
{
    /// <summary>
    /// Internal flag for the initialized state of scene.
    /// </summary>
    protected bool _initialized = false;

    /// <summary>
    /// Returns the initialized state of scene.
    /// </summary>
    public abstract bool Initialized { get; }

    /// <summary>
    /// Method to dispose of scene and scene objects.
    /// </summary>
    public abstract void Dispose();

    /// <summary>
    /// Method to setup scene and any start up objects before running.<br />
    /// Warning: THIS SHOULD NOT BE USED AS A CONSTRUCTOR!
    /// </summary>
    public abstract void InitializeScene();

    /// <summary>
    /// Runs the scene.
    /// </summary>
    public abstract void RunScene();

    /// <summary>
    /// Internal method to update objects within the scene each frame..
    /// </summary>
    protected abstract void Update();
}