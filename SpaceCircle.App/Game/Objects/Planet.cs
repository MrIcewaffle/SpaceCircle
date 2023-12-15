using SpaceCircle.App.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.Objects;

public class Planet : Entity
{
    private Transform2D _transform;
    private Vector2 _orbitCenter;
    private float _diameter;
    private float _orbitRadius;
    private float _orbitalAngle;

    private Circle _sprite;

    public Planet(Vector2 orbitCenter, float diameter, float orbitRadius, Transform2D? transform = null)
    {
        _diameter = diameter;
        _orbitCenter = orbitCenter;
        _orbitRadius = orbitRadius;
        _orbitalAngle = 0f;

        if (transform != null)
            _transform = transform;
        else
            _transform = new Transform2D();

        _sprite = new Circle(_diameter / 2, Color.BLUE);

        AddComponent(_sprite);
        AddComponent(_transform);
        RegisterEntity(this);
    }

    public override void Update(float deltaTime)
    {
        if (!IsActive)
            return;

        var f = _orbitRadius / 10;

        _orbitalAngle += 12 * deltaTime / f;
        if (_orbitalAngle >= 360f)
            _orbitalAngle += -360f;

        float x = _orbitCenter.X + (float)(_orbitRadius * Math.Cos(_orbitalAngle));
        float y = _orbitCenter.Y + (float)(_orbitRadius * Math.Sin(_orbitalAngle));

        _transform.Position.X = x;
        _transform.Position.Y = y;
    }
}
