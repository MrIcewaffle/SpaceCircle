using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Base;

public class newEntity
{
    public readonly Guid Id = Guid.NewGuid();
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

    public void AddComponent(Guid componentId, object component)
    {
        Components[component.GetType()] = (component);
        HelperFunctions.RegisterComponentToManager(component);
        SceneSystem.RegisterEntityComponent(Id, componentId);
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
