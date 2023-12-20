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
    private PlanetDetailsComponent _detailsComponent;
    //private Vector2 _orbitCenter;
    //private float _diameter;
    //private float _orbitRadius;
    //private float _orbitalAngle;

    private Circle _sprite;

    public Planet(Vector2 orbitCenter, float diameter, float orbitRadius, Transform2D? transform = null)
    {
        _detailsComponent = new();

        _detailsComponent.PlanetStruct.Diameter = diameter;
        _detailsComponent.PlanetStruct.OrbitCenter = orbitCenter;
        _detailsComponent.PlanetStruct.OrbitRadius = orbitRadius;
        _detailsComponent.PlanetStruct.OrbitalAngle = 0f;

        if (transform != null)
            _transform = transform;
        else
            _transform = new Transform2D();

        _sprite = new Circle(_detailsComponent.PlanetStruct.Diameter / 2, Color.BLUE);

        AddComponent(_sprite);
        AddComponent(_transform);
        AddComponent(_detailsComponent);
        RegisterEntity(this);
    }

    public override void Update(float deltaTime)
    {
        if (!IsActive)//TODO:Move to base method
            return;   //

        UpdatePosition(deltaTime);

    }

    private void UpdatePosition(float deltaTime) 
    {
        var f = _detailsComponent.PlanetStruct.OrbitRadius / 10;

        _detailsComponent.PlanetStruct.OrbitalAngle += (6 * deltaTime) / f; //FIXME:Position resets at a certain points, causing object to jump positions.
        if (_detailsComponent.PlanetStruct.OrbitalAngle >= 360f)
            _detailsComponent.PlanetStruct.OrbitalAngle += -360f;

        float x = _detailsComponent.PlanetStruct.OrbitCenter.X + (float)(_detailsComponent.PlanetStruct.OrbitRadius * Math.Cos(_detailsComponent.PlanetStruct.OrbitalAngle));
        float y = _detailsComponent.PlanetStruct.OrbitCenter.Y + (float)(_detailsComponent.PlanetStruct.OrbitRadius * Math.Sin(_detailsComponent.PlanetStruct.OrbitalAngle));

        _transform.Position.X = x;
        _transform.Position.Y = y;
    }
}
