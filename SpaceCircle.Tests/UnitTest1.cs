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
public class Entity_Tests : IDisposable
{
    public Entity_Tests()
    {}

    [Fact]
    public void Update()
    {
        var entity = new TestEntity();
        entity.Update(0.0f);

        var component = entity.GetComponent<Transform2DComponent>();
        Assert.Equal(1.0f, component.Rotation);
    }

    [Fact]
    public void Destroy()
    {
        var entity = new TestEntity();
        entity.Destroy();

        Assert.Empty(entity.Components);
        Assert.Empty(SceneSystem.Entities);
        Assert.Empty(Transform2DSystem.Components);
    }

    [Fact]
    public void RegisterEntity()
    {
        var entity = new newEntity();
        entity.RegisterEntity(entity);

        Assert.Single(SceneSystem.Entities);
        Assert.Equal(entity, SceneSystem.Entities.First().Value);
    }

    [Fact]
    public void AddComponent()
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent());

        Assert.Single(entity.Components);
        Assert.Single(Transform2DSystem.Components);
    }

    [Fact]
    public void RemoveComponent()
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent();

        entity.AddComponent(c1);
        Assert.Single(entity.Components);
        Assert.Single(Transform2DSystem.Components);

        entity.RemoveComponent(c1);

        Assert.Empty(entity.Components);
        Assert.Empty(Transform2DSystem.Components);
    }

    [Fact]
    public void HasComponent_True()
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent());

        Assert.True(entity.HasComponent(typeof(Transform2DComponent)));
    }

    [Fact]
    public void HasComponent_Type_True()
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent());

        Assert.True(entity.HasComponent<Transform2DComponent>());
    }

    [Fact]
    public void HasComponent_False()
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent());

        Assert.False(entity.HasComponent(typeof(TestComponent)));
    }

    [Fact]
    public void HasComponent_Type_False()
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent());

        Assert.False(entity.HasComponent<TestComponent>());
    }

    [Fact]
    public void GetComponent()
    {
        var entity = new newEntity();
        entity.AddComponent(new Transform2DComponent() { Rotation = 5.0f });

        var component = entity.GetComponent<Transform2DComponent>();
        Assert.Equal(5.0f, component.Rotation);
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