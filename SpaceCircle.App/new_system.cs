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
        //Transform2DSystem.Update(delta)
    }

    public static void UnregisterEntity(Guid Id)
    {
        Entities.Remove(Id);
    }

    public static void CleanScene()
    {
        foreach (var entity in Entities.Values)
            entity.Destroy();
    }
}

public class newEntity
{
    public Guid Id = Guid.NewGuid();
    public Dictionary<Type, object> Components = new();

    public virtual void Update(float deltaTime) { }
    public void Destroy() 
    {
        foreach (var component in Components.Values)
            HelperFunctions.UnregisterComponentFromManager(component);
        
        Components.Clear();
        SceneSystem.UnregisterEntity(Id);
    }

    public void RegisterEntity(newEntity entity)
    {
        SceneSystem.RegisterEntity(entity);
    }

    public void AddComponent(object component)
    {
        Components[component.GetType()] = (component);
        HelperFunctions.RegisterComponentToManager(component);
    }

    public void RemoveComponent(object component)
    {
        Components.Remove(component.GetType());
        HelperFunctions.UnregisterComponentFromManager(component);
    }

    public void RemoveAllComponents()
    {
        foreach (var component in Components.Values)
            HelperFunctions.UnregisterComponentFromManager(component);
        
        Components.Clear();
    }

    public bool HasComponent(Type componentType)
    { 
        return Components.ContainsKey(componentType);
    }

    public bool HasComponent<T>() where T : class
    {
        return Components.ContainsKey(typeof(T));
    }

    public T GetComponent<T>() where T : class
    { 
        return (T)Components[typeof(T)];
    }
}

public static class HelperFunctions
{
    public static void RegisterComponentToManager(object component)
    { //TODO: this is kinda gross and could get unwieldy?
        switch (component)
        {
            case Transform2DComponent t1:
                Transform2DSystem.Register(t1);
                break;
        }   
    }

    public static void UnregisterComponentFromManager(object component)
    {
        switch (component)
        {
            case Transform2DComponent t1:
                Transform2DSystem.Unregister(t1);
                break;
        }   
    }

    public static void ClearComponentManagers()
    {
        Transform2DSystem.Components.Clear();
    }

}

public class Transform2DSystem : ComponentManager<Transform2DComponent> { }

public class ComponentManager<T> where T : class
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

public class Transform2DComponent
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
