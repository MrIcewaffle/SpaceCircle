using SpaceCircle.App.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.Objects;

public class newPlanet : newEntity
{
    private Transform2DComponent _transform;
    private CircleComponent _circle;

    public newPlanet()
    { 
        _transform = new Transform2DComponent();
        _circle = new CircleComponent() { Radius = 10f, Color = Color.BLUE };

        AddComponent(_transform.Id, _transform);
        AddComponent(_circle.Id, _circle);
        RegisterEntity(this);
    }

    public override void Update(float deltaTime)
    {
        _transform.Position.X += 1.0f;
    }
}
