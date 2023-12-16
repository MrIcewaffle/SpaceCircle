using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.BaseObjects;

public class Entity
{
    public Guid Id = Guid.NewGuid();
    public Dictionary<Type, Component> Components = new();

    public bool IsActive = true;
    public bool IsVisible = true;

    public virtual void Update(float deltaTime) { }
    public virtual void Destroy() { }

    public void RegisterEntity(Entity entity)
    {
        SystemBase.RegisterEntity(entity);
    }

    public void AddComponent(Component component)
    {
        Components[component.GetType()] = (component);
        component.entity = this;
    }

    public void RemoveComponent<T>() where T : Component
    {
        Components.Remove(typeof(T));
    }

    public bool HasComponent(Type componentType)
    {
        return Components.ContainsKey(componentType);
    }

    public bool HasComponent<T>() where T : Component
    {
        return Components.ContainsKey(typeof(T));
    }

    public T GetComponent<T>() where T : Component
    {
        return (T)Components[typeof(T)];
    }
}
