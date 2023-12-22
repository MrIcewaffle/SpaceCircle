using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Base;

public static class HelperFunctions
{
    public static void RegisterComponentToManager(object component)
    { //TODO: this is kinda gross and could get unwieldy?
        switch (component)
        {
            case Transform2DComponent t1:
                Transform2DManager.Register(t1);
                break;
            case CircleComponent t2:
                RendererManager.Register(t2);
                break;
            case RectangleComponent t3:
                RendererManager.Register(t3);
                break;
        }
    }

    public static void UnregisterComponentFromManager(object component)
    {
        switch (component)
        {
            case Transform2DComponent t1:
                Transform2DManager.Unregister(t1);
                break;
            case CircleComponent t2:
                RendererManager.Register(t2);
                break;
            case RectangleComponent t3:
                RendererManager.Register(t3);
                break;
        }
    }

    public static void ClearComponentManagers()
    {
        Transform2DManager.Components.Clear();
        RendererManager.Components.Clear();
    }

}
