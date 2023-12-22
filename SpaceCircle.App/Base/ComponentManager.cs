using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Base;

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

public class Transform2DManager : ComponentManager<Transform2DComponent> { }

