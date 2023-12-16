using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Components;

public class LineComponent : DrawableComponent
{
    public Color Color = Color.MAGENTA;
    public Vector2 StartPos;
    public Vector2 EndPos;

    public LineComponent(Color? color = null)
    {
        DrawableSystem.Register(this);

        if (color != null)
            Color = (Color)color;
    }

    public override void Update(float deltaTime)
    {
        DrawLineV(StartPos, EndPos, Color);
    }
}
