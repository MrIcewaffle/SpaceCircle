﻿using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Components
{
    public class CameraComponent : Component
    {
        public Vector2 Offset = Vector2.Zero;
        public Camera Camera = new Camera();
        public float Zoom = 1f;

        public CameraComponent(Vector2? offset = null, float? zoom = null)
        {
            CameraSystem.Register(this);
            if (offset != null)
                Offset = (Vector2)offset;
            if (zoom != null)
                Zoom = (float)zoom;
        }

        public override void Update(float deltaTime)
        {
            Transform2D transform = entity.GetComponent<Transform2D>();
            Camera.Target = transform.Position;
            Camera.Rotation = transform.Rotation;
            Camera.Offset = Offset;
            Camera.Zoom = Zoom;
        }
    }
}
