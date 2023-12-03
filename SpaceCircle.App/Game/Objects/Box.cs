using SpaceCircle.App.Objects;
using System.Numerics;

namespace SpaceCircle.App.Game.Objects;

public class Box : GameObject
{
    public Vector2 Position => _position;
    public Vector2 Dimensions => _dimensions;
    public Color Color => _color;

    private Vector2 _position;
    private Vector2 _dimensions;
    private Color _color;

    public override bool IsActive => _isActive;

    public override bool IsVisible => _isVisible;

    public Box(Vector2 position, Vector2 dimensions, Color color)
    {
        _position = position;
        _dimensions = dimensions;
        _color = color;
    }

    public override void Destroy()
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        if (_isActive)
            if (_isVisible)
                DrawRectangle((int)_position.X, (int)_position.Y, (int)_dimensions.X, (int)_dimensions.Y, _color);
    }

    public override void Update()
    {
        Draw();
    }
}