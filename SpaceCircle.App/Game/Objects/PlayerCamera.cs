using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.Objects;

public class PlayerCamera : Entity
{
    private Transform2D _transform;
    private CameraComponent _camera;
    private Vector2 _offset = new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2);

    public PlayerCamera() 
    {
        _transform = new Transform2D();
        _camera = new CameraComponent(_offset);

        AddComponent(_transform);
        AddComponent(_camera);
        RegisterEntity(this);
    }

    public override void Update(float deltaTime)
    {
        //TODO:create generic controller class
        MoveCamera();
    }

    private void MoveCamera() 
    {
        if (IsKeyDown(KeyboardKey.KEY_W))
            _transform.Position.Y -= 2;
        if (IsKeyDown(KeyboardKey.KEY_S))
            _transform.Position.Y += 2;
        if (IsKeyDown(KeyboardKey.KEY_A))
            _transform.Position.X -= 2;
        if (IsKeyDown(KeyboardKey.KEY_D))
            _transform.Position.X += 2;

        if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            _transform.Position = Vector2.Zero;
    }
}
