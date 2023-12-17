using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.BaseObjects;

public class Component
{
    public Entity entity; //LATER: is this useful?
    public virtual void Update(float deltaTime) { }
}

public class DrawableComponent : Component 
{
    public bool Visible = true;
    public bool FixedToScreen = false;
}
