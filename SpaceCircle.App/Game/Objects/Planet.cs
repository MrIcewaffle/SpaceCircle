using SpaceCircle.App.Objects;
using System.Numerics;

namespace SpaceCircle.App.Game.Objects;

public class Planet : GameObject
{
    public Vector2 Position => _position;
    public float Diameter => _diameter;
    public float OrbitRadius => _orbitRadius;

    private Vector2 _position;
    private Vector2 _orbitCenter;
    private float _diameter;
    private float _orbitRadius;
    private float _orbitalAngle;

    public override bool IsActive => _isActive;

    public override bool IsVisible => _isVisible;

    /// <summary>
    /// Planet GameObject
    /// </summary>
    /// <param name="position">Vector2 position of object center</param>
    /// <param name="diameter">Float diameter of object</param>
    /// <param name="orbitCenter">Vector2 position of orbital center</param>
    /// <param name="orbitRadius">Float radius from parent orbital center</param>
    public Planet(Vector2 position, float diameter, Vector2 orbitCenter, float orbitRadius)
    {
        _position = position;
        _diameter = diameter;
        _orbitCenter = orbitCenter;
        _orbitRadius = orbitRadius;
        _orbitalAngle = 0f;
    }

    public override void Draw()
    {
        if (!_isVisible)
            return;

        DrawCircleV(_position, _diameter / 2, RED); //TODO: Randomise colour
    }

    public override void Update()
    {
        float deltaTime = GetFrameTime();
        if (!_isActive)
            return;

        var f = _orbitRadius / 10;

        _orbitalAngle += (12 * deltaTime) / f;
        if (_orbitalAngle >= 360f)
            _orbitalAngle += -360f;

        float x = _orbitCenter.X + (float)(_orbitRadius * Math.Cos(_orbitalAngle));
        float y = _orbitCenter.Y + (float)(_orbitRadius * Math.Sin(_orbitalAngle));

        _position = new Vector2(x, y);

        Draw();
    }
}