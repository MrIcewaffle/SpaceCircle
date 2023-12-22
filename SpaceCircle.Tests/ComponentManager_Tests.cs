namespace SpaceCircle.Tests;

[Collection("Sequential")]
public class ComponentManager_Tests : IDisposable
{
    public ComponentManager_Tests() 
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent();
        entity.AddComponent(c1.Id, c1);
        entity.RegisterEntity(entity);
    }

    [Fact]
    public void ComponentManager_Contains_Component()
    {
        Assert.Single(Transform2DManager.Components);
    }

    [Fact]
    public void ComponentManager_Component_Matches_Entity_Component()
    {
        var entity = SceneSystem.Entities.First().Value;

        Assert.NotNull(entity);
        Assert.Single(entity.Components);
        Assert.Single(Transform2DManager.Components);

        var entity_component = (Transform2DComponent)entity.Components.First().Value;
        var manager_component = Transform2DManager.Components.First();

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
        var entity = new newEntity();
        var c2 = new Transform2DComponent() { Rotation = 5.0f };
        entity.AddComponent(c2.Id, c2);

        Assert.Equal(2, Transform2DManager.Components.Count());

        Transform2DManager.Unregister(c2);
        Assert.Single(Transform2DManager.Components);

        var c1 = Transform2DManager.Components.First();
        Assert.Equal(0.0f, c1.Rotation);
    }

    public void Dispose()
    {
        SceneSystem.Entities.Clear();
        Transform2DManager.Components.Clear();
        TestComponentManager.Components.Clear();
    }
}

internal class TestEntity : newEntity
{
    private Transform2DComponent _transform; 

    public TestEntity()
    {
        _transform = new Transform2DComponent();
        AddComponent(_transform.Id, _transform);
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