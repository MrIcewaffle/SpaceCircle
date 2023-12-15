using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Components;

public class Panel : DrawableComponent
{
    public Vector2 Size = Vector2.Zero;
    public Color Color = Color.WHITE;

    public Panel(Vector2? size = null, Color? color = null)
    {
        DrawableSystem.Register(this);

        if (size != null)
            Size = (Vector2)size;
        if (color != null)
            Color = (Color)color;
    }

    public override void Update(float deltaTime)
    {
        Transform2D transform = entity.GetComponent<Transform2D>();
        DrawRectangle((int)transform.Position.X, (int)transform.Position.Y, (int)Size.X, (int)Size.Y, Color);
    }
}
