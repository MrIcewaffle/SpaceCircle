using SpaceCircle.App.Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.Scenes;

public class newDebugScene : newScene
{
    public override void Initialise() //Create initial scene components, such as ui and starting entities
    {
        new newPlanet();
    }
}
