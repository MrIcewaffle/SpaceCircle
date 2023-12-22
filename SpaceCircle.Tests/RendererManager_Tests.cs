using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.Tests;

public class RendererManager_Tests : IDisposable
{
    public RendererManager_Tests()
    { }

    [Fact]
    public void Register()
    { 
        var component = new CircleComponent();
        RendererManager.Register(component);

        Assert.Single(RendererManager.Components);
    }

    [Fact]
    public void Unregister_Single() 
    {
        var component = new CircleComponent();
        RendererManager.Register(component);

        Assert.Single(RendererManager.Components);

        RendererManager.Unregister(component);

        Assert.Empty(RendererManager.Components);
    }

    [Fact]
    public void Unregister_Single_Remaining()
    {
        var c1 = new CircleComponent();
        var c2 = new CircleComponent();

        RendererManager.Register(c1);
        RendererManager.Register(c2);

        Assert.Equal(2, RendererManager.Components.Count);

        RendererManager.Unregister(c1);

        Assert.Single(RendererManager.Components);
    }

    [Fact]
    public void GetComponentList_Single_Return()
    {
        var c1 = new CircleComponent();
        var c2 = new CircleComponent();
        var c3 = new RectangleComponent();

        RendererManager.Register(c1);
        RendererManager.Register(c2);
        RendererManager.Register(c3);

        var list = RendererManager.GetComponentList(typeof(RectangleComponent));

        Assert.Single(list);
    }

    [Fact]
    public void GetComponentList_Multiple_Return()
    {
        var c1 = new CircleComponent();
        var c2 = new CircleComponent();
        var c3 = new RectangleComponent();

        RendererManager.Register(c1);
        RendererManager.Register(c2);
        RendererManager.Register(c3);

        var list = RendererManager.GetComponentList(typeof(CircleComponent));

        Assert.Equal(2, list.Count);
    }

    public void Dispose() 
    {
        RendererManager.Components.Clear();
    }
}
