namespace SpaceCircle.App.Base;

public static class SceneSystem
{
    public static Dictionary<Guid, newEntity> Entities = new();
    public static Dictionary<Guid, Guid> ComponentEntityRegistry = new();

    public static void RegisterEntity(newEntity entity)
    {
        var id = entity.Id;
        Entities.Add(id, entity);
    }

    public static newEntity? GetEntity(Guid id)
    {
        if (Entities.ContainsKey(id))
            return Entities[id];
        else
            return null;
    }

    public static void Update()
    {
        float deltaTime = GetFrameTime();
        UpdateEntities(deltaTime);
        UpdateDrawables(deltaTime);
    }

    public static void UpdateEntities(float deltaTime)
    {
        foreach (var entity in Entities.Values)
            entity.Update(deltaTime);
    }

    public static void UpdateDrawables(float deltaTime)
    {
        BeginDrawing();
        ClearBackground(Color.LIGHTGRAY);
        List<(Type type, object component)> list = null;
        //sprites
        //rectangles
        list = RendererManager.GetComponentList(typeof(RectangleComponent));
        foreach (var component in list)
        { 
            var item = component.component as RectangleComponent;
            var entityId = GetEntityIdFromRegistry(item.Id);
            var transform = GetEntity(entityId)?.GetComponent<Transform2DComponent>();

            DrawRectangle((int)transform.Position.X, (int)transform.Position.Y, item.Width, item.Height, item.Color);
        }
        //circles
        list = RendererManager.GetComponentList(typeof(CircleComponent));
        foreach (var component in list)
        {
            var item = component.component as CircleComponent;
            var entityId = GetEntityIdFromRegistry(item.Id);
            var transform = GetEntity(entityId)?.GetComponent<Transform2DComponent>();

            DrawCircle((int)transform.Position.X, (int)transform.Position.Y, item.Radius, item.Color);
        }
        //text
        EndDrawing();
    }

    public static void RegisterEntityComponent(Guid entityId, Guid componentId)
    { 
        ComponentEntityRegistry.Add(componentId, entityId);
    }

    public static Guid GetEntityIdFromRegistry(Guid componentId)
    {
        return ComponentEntityRegistry[componentId];
    }

    public static void UnregisterEntity(Guid Id)
    {
        Entities.Remove(Id);
    }

    public static void LoadScene(newScene scene)
    { 
        scene.Initialise();
    }

    public static void ChangeScene(newScene scene) 
    {
        CleanScene();
        LoadScene(scene);
    }

    public static void CleanScene()
    {
        foreach (var entity in Entities.Values)
            entity.Destroy();
    }
}