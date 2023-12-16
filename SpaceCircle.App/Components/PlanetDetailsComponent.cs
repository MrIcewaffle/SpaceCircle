using SpaceCircle.App.Models;
using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Components;

public class PlanetDetailsComponent : Component
{
    public PlanetStruct PlanetStruct;

    public PlanetDetailsComponent() 
    {
        GenericComponentSystem.Register(this);
    }
}
