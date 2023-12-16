using SpaceCircle.App.Game.Managers;
using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.Objects;

public class Sun : Entity
{
    private Transform2D _transform;
    private Circle _sprite;

    public Sun(object[]? planetIds, Transform2D? transform = null, Color? color = null)
    {
        if (planetIds != null)
            RegisterPlanetConnection(planetIds);

        _transform = transform != null ? (Transform2D)transform : new Transform2D();
        _sprite = new Circle(50f, color != null ? (Color)color : Color.YELLOW);

        AddComponent(_transform);
        AddComponent(_sprite);

        RegisterEntity(this);
    }

    public override void Update(float deltaTime)
    {
        
    }

    private void RegisterPlanetConnection(object[]? planetIds)
    {
        if (planetIds != null)
        { 
            var idList = planetIds.ToList();
            int i = 1;
            foreach (var currentId in idList)
            {
                if (i >= idList.Count)
                    break;

                for (int j = i; j < idList.Count; j++) 
                {
                    Guid targetId = (Guid)idList[j];
                    ConnectionManager.Instance.onAddPlanetConnection((Guid)currentId, targetId);
                }
            }
        }
    }

}
