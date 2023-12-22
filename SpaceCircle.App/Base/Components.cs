using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Base;

public class Transform2DComponent
{
    public readonly Guid Id = Guid.NewGuid();
    public Vector2 Position;
    public float Rotation;
    public Vector2 Scale;

    public Transform2DComponent()
    {
        Position = Vector2.Zero;
        Rotation = 0.0f;
        Scale = Vector2.Zero;
    }
}
