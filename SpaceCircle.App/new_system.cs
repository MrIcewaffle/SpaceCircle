using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App;

public static class SceneSystem
{
    public static Dictionary<Guid, newEntity> Entities = new();

    public static void RegisterEntity(newEntity entity)
    { 
        var id = entity.Id;
        Entities.Add(id, entity);
    }

    public static void Update()
    { 
        float deltaTime = GetFrameTime();
        UpdateEntities(deltaTime);
        UpdateComponents(deltaTime);
    }

    public static void UpdateEntities(float deltaTime)
    {
        foreach (var entity in Entities.Values)
            entity.Update(deltaTime);
    }

    public static void UpdateComponents(float deltaTime)
    { 
        //Transform2DSystem.Update(delta)
    }
}

public class newEntity
{
    public Guid Id = Guid.NewGuid();
    public Dictionary<Type, object> Components = new();

    public virtual void Update(float deltaTime) { }
    public virtual void Destroy() { }

    public void RegisterEntity(newEntity entity)
    {
        SceneSystem.RegisterEntity(entity);
    }

    public void AddComponent(object component)
    {
        Components[component.GetType()] = (component);
    }

    public void RemoveComponent(object component) { }

    public bool HasComponent(Type componentType)
    { 
        return Components.ContainsKey(componentType);
    }

    public bool HasComponent<T>() where T : struct
    {
        return Components.ContainsKey(typeof(T));
    }

    public T GetComponent<T>() where T : struct
    { 
        return (T)Components[typeof(T)];
    }

    private void RegisterComponentToManager(object component)
    { 
        var componentType = component.GetType();

        switch (componentType)
        {
            //case Transform2DComponent t2D:
            //    break;
            //default:
            //    break;
        }
    }
}

public class Transform2DSystem : ComponentManager<Transform2DComponent> { }

public class ComponentManager<T> where T : struct
{
    public static List<T> Components = new List<T>();
    public static int ComponentCount()
    {
        return Components.Count;
    }

    public static void Register(T componenet)
    {
        Components.Add(componenet);
    }

    public static void Unregister(T componenet)
    {
        Components.Remove(componenet);
    }
}

public struct Transform2DComponent
{
    public Vector2 Position;
    public float Rotation;
    public Vector2 Scale;

    public Transform2DComponent()
    { 
        Position = Vector2.Zero;
        Rotation = 0.0f;
        Scale = Vector2.Zero;
    }
}
