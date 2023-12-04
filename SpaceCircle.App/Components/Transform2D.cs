using SpaceCircle.App.BaseObjects;
using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Components;

public class Transform2D : Component
{
    public Vector2 Position = Vector2.Zero;
    public float Rotation = 0.0f;

    public Transform2D()
    {
        TransformSystem.Register(this);
    }
}
