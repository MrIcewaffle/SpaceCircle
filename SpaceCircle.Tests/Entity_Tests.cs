namespace SpaceCircle.Tests;

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
        Assert.Empty(Transform2DManager.Components);
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
        var c1 = new Transform2DComponent();
        entity.AddComponent(c1.Id, c1);

        Assert.Single(entity.Components);
        Assert.Single(Transform2DManager.Components);
    }

    [Fact]
    public void RemoveComponent()
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent();

        entity.AddComponent(c1.Id, c1);
        Assert.Single(entity.Components);
        Assert.Single(Transform2DManager.Components);

        entity.RemoveComponent(c1);

        Assert.Empty(entity.Components);
        Assert.Empty(Transform2DManager.Components);
    }

    [Fact]
    public void HasComponent_True()
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent();
        entity.AddComponent(c1.Id, c1);

        Assert.True(entity.HasComponent(typeof(Transform2DComponent)));
    }

    [Fact]
    public void HasComponent_Type_True()
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent();
        entity.AddComponent(c1.Id, c1);

        Assert.True(entity.HasComponent<Transform2DComponent>());
    }

    [Fact]
    public void HasComponent_False()
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent();
        entity.AddComponent(c1.Id, c1);

        Assert.False(entity.HasComponent(typeof(TestComponent)));
    }

    [Fact]
    public void HasComponent_Type_False()
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent();
        entity.AddComponent(c1.Id, c1);

        Assert.False(entity.HasComponent<TestComponent>());
    }

    [Fact]
    public void GetComponent()
    {
        var entity = new newEntity();
        var c1 = new Transform2DComponent() { Rotation = 5.0f };
        entity.AddComponent(c1.Id, c1);

        var component = entity.GetComponent<Transform2DComponent>();
        Assert.Equal(5.0f, component.Rotation);
    }

    public void Dispose()
    {
        SceneSystem.Entities.Clear();
        Transform2DManager.Components.Clear();
    }
}