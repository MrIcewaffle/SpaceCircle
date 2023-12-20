using NuGet.Frameworks;
using SpaceCircle.App;

namespace SpaceCircle.Tests;

[Collection("Sequential")]
public class SceneSystem_Tests : IDisposable
{
    public SceneSystem_Tests()
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent());
        entity.RegisterEntity(entity);
    }

    [Fact]
    public void SceneSystem_Entities_Has_Single_Entity_With_Component()
    {
        Assert.Single(SceneSystem.Entities);
        var entity = SceneSystem.Entities.First().Value;

        Assert.NotNull(entity);
        Assert.Single(entity.Components);
    }

    public void Dispose()
    {
        SceneSystem.Entities.Clear();
        Transform2DSystem.Components.Clear();
    }
}

[Collection("Sequential")]
public class ComponentManager_Tests : IDisposable
{
    public ComponentManager_Tests() 
    {
        var entity = new newEntity();
        entity.AddComponent(new TestComponent());
        entity.RegisterEntity(entity);
    }

    [Fact]
    public void ComponentManager_Contains_Component()
    {
        //TODO:failing until component registration in Entity.AddComponent() is added
        Assert.Single(TestComponentManager.Components);
    }

    [Fact]
    public void ComponentManager_Component_Matches_Entity_Component()
    {
        //TODO:failing until component registration in Entity.AddComponent() is added
        var entity = SceneSystem.Entities.First().Value;

        Assert.NotNull(entity);
        Assert.Single(entity.Components);
        Assert.Single(TestComponentManager.Components);

        var entity_component = (TestComponent)entity.Components.First().Value;
        var manager_component = TestComponentManager.Components.First();

        Assert.Equal(entity_component, manager_component);
    }

    [Fact]
    public void ComponentManager_Unregister()
    { 
        //TODO:failing until component registration in Entity.AddComponent() is added
        var c2 = new TestComponent() { Text = "text" };
        Assert.Equal(2, TestComponentManager.Components.Count());

        TestComponentManager.Unregister(c2);
        Assert.Single(TestComponentManager.Components);

        var c1 = TestComponentManager.Components.First();
        Assert.Null(c1.Text);
    }

    public void Dispose()
    {
        SceneSystem.Entities.Clear();
        TestComponentManager.Components.Clear();
    }
}

internal class TestComponentManager : ComponentManager<TestComponent> { }
internal struct TestComponent
{
    public string? Text;
}