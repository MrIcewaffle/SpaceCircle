using SpaceCircle.App;
using SpaceCircle.App.Systems;

namespace SpaceCircle.Tests;

[Collection("Sequential")]
public class ComponentManager_Tests : IDisposable
{
    public ComponentManager_Tests() 
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent());
        entity.RegisterEntity(entity);
    }

    [Fact]
    public void ComponentManager_Contains_Component()
    {
        //TODO:failing until component registration in Entity.AddComponent() is added
        Assert.Single(Transform2DSystem.Components);
    }

    [Fact]
    public void ComponentManager_Component_Matches_Entity_Component()
    {
        //TODO:failing until component registration in Entity.AddComponent() is added
        var entity = SceneSystem.Entities.First().Value;

        Assert.NotNull(entity);
        Assert.Single(entity.Components);
        Assert.Single(Transform2DSystem.Components);

        var entity_component = (Transform2DComponent)entity.Components.First().Value;
        var manager_component = Transform2DSystem.Components.First();

        Assert.Equal(entity_component, manager_component);
    }

    [Fact]
    public void ComponentManager_Register()
    {
        var component = new TestComponent() { Text = "test" };
        TestComponentManager.Register(component);

        Assert.Single(TestComponentManager.Components);
    }

    [Fact]
    public void ComponentManager_Unregister()
    { 
        //TODO:failing until component registration in Entity.AddComponent() is added
        var entity = new newEntity();
        var c2 = new Transform2DComponent() { Rotation = 5.0f };
        entity.AddComponent(c2);

        Assert.Equal(2, Transform2DSystem.Components.Count());

        Transform2DSystem.Unregister(c2);
        Assert.Single(Transform2DSystem.Components);

        var c1 = Transform2DSystem.Components.First();
        Assert.Equal(0.0f, c1.Rotation);
    }

    public void Dispose()
    {
        SceneSystem.Entities.Clear();
        Transform2DSystem.Components.Clear();
        TestComponentManager.Components.Clear();
    }
}

internal class TestEntity : newEntity
{
    private Transform2DComponent _transform; 

    public TestEntity()
    {
        _transform = new Transform2DComponent();
        AddComponent(_transform);
        RegisterEntity(this);
    }

    public override void Update(float deltaTime)
    {
        _transform.Rotation += 1.0f;
    }
}

internal class TestComponentManager : ComponentManager<TestComponent> { }
internal class TestComponent
{
    public string? Text;
}