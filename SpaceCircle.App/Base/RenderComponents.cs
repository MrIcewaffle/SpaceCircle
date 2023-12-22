using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Base;

public class CircleComponent
{
    public readonly Guid Id = Guid.NewGuid();
    public float Radius;
    public Color Color;

    public CircleComponent() 
    {
        Radius = 0.0f;
        Color = Color.BLANK;
    }
}

public class RectangleComponent
{
    public readonly Guid Id = Guid.NewGuid();
    public int Width;
    public int Height;
    public Color Color;

    public RectangleComponent() 
    {
        Width = 0;
        Height = 0;
        Color = Color.BLANK;
    }
}
