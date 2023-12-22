using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Base;

public class RendererManager
{
    public static List<(Type type, object component)> Components = new();
    public static int ComponentCount()
    {
        return Components.Count;
    }

    public static void Register(object component)
    {
        Components.Add((component.GetType(), component));
    }

    public static void Unregister(object component)
    {
        Components.Remove((component.GetType(), component));
    }

    public static List<(Type type, object component)> GetComponentList(Type type)
    {
        return Components.Where(c => c.type == type).ToList();
    }
}
