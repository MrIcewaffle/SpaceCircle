﻿using SpaceCircle.App.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Systems;

public static class SystemBase
{
    public static Dictionary<Guid, Entity> Entities = new Dictionary<Guid, Entity>();

    public static void RegisterEntity(Entity entity)
    {
        Entities.Add(entity.Id, entity);
    }

    public static void RemoveEntity(Entity entity) => RemoveEntity(entity.Id);

    public static int EntityCount()
    { 
        return Entities.Count;
    }

    public static int ComponentCount()
    {
        int count = 0;
        count += TransformSystem.ComponentCount();
        count += DrawableSystem.ComponentCount();

        return count;
    }

    public static Entity? GetEntity(Guid entityId)
    {
        if (Entities.ContainsKey(entityId))
            return Entities[entityId];
        else
            return null;
    }

    private static void RemoveEntity(Guid entityId)
    {
        Entities.Remove(entityId);
    }

    public static void Update()
    {
        float deltaTime = GetFrameTime();
        UpdateEntities(deltaTime);
        UpdateComponentsSystems(deltaTime);
    }

    private static void UpdateEntities(float deltaTime)
    {
        foreach (var entity in Entities.Values)
            entity.Update(deltaTime);
    }

    private static void UpdateComponentsSystems(float deltaTime)
    {
        TransformSystem.Update(deltaTime);
        DrawableSystem.Update(deltaTime, true);
        GenericComponentSystem.Update(deltaTime);
        CameraSystem.Update(deltaTime);
    }
}

internal class ComponentSystem<T> where T : Component
{
    protected static List<T> Components = new List<T>();

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

    public static void Update(float deltaTime)
    {
        foreach (T component in Components)
            component.Update(deltaTime);
    }
}
internal class GenericComponentSystem : ComponentSystem<Component> { }
internal class TransformSystem : ComponentSystem<Transform2D> { }
internal class DrawableSystem : ComponentSystem<DrawableComponent> 
{
    public static new void Update(float deltaTime, bool updateFixed = true)
    {
        //LATER:Confirm offset issue is fixed
        foreach (var component in Components)
        {
            if (!component.Visible)
                continue;

            if (!updateFixed && !component.FixedToScreen)
            {
                component.Update(deltaTime);
            }
            if (updateFixed && component.FixedToScreen)
                component.Update(deltaTime);
        }
    }
}
internal class CameraSystem : ComponentSystem<CameraComponent> 
{
    public static new void Update(float deltaTime)
    {
        foreach (var component in Components)
        {
            BeginMode2D(component.Camera);
            component.Update(deltaTime);
            DrawableSystem.Update(deltaTime, false);
            EndMode2D();
        }
    }
}
