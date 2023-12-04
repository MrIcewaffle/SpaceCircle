using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Components;

public class Circle : DrawableComponent
{
    public float Radius = 0.0f;
    public Color Color = WHITE;

    public Circle(float? radius = null, Color? color = null) 
    {
        DrawableSystem.Register(this);

        if (radius != null)
            Radius = (float)radius;
        if (color != null)
            Color = (Color)color;
    }

    public override void Update(float deltaTime)
    {
        Transform2D transform = entity.GetComponent<Transform2D>();
        DrawCircleV(transform.Position, Radius, Color);
    }
}
