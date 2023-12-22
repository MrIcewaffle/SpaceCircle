using SpaceCircle.App;
using SpaceCircle.App.Systems;

namespace SpaceCircle.Tests;

[Collection("Sequential")]
public class SceneSystem_Tests : IDisposable
{
    public SceneSystem_Tests()
    {}

    [Fact]
    public void RegisterEntity()
    {
        SceneSystem.RegisterEntity(new newEntity());
        Assert.Single(SceneSystem.Entities);        
    }

    [Fact]
    public void UnregisterEntity()
    {
        var entity = new newEntity();
        var Id = entity.Id;

        SceneSystem.RegisterEntity(entity);
        Assert.Single(SceneSystem.Entities);

        SceneSystem.UnregisterEntity(Id);
        Assert.Empty(SceneSystem.Entities);
    }

    [Fact]
    public void GetEntity_NotNull()
    {
        var id = new TestEntity().Id;
        var entity = SceneSystem.GetEntity(id);

        Assert.NotNull(entity);
    }

    [Fact]
    public void GetEntity_Null()
    {
        var id = new newEntity().Id;
        var entity = SceneSystem.GetEntity(id);

        Assert.Null(entity);
    }

    [Fact]
    public void UpdateEntities()
    {
        var e1 = new TestEntity();
        var e2 = new TestEntity();

        SceneSystem.UpdateEntities(0);

        var e1Transform = e1.GetComponent<Transform2DComponent>();
        var e2Transform = e2.GetComponent<Transform2DComponent>();
        
        Assert.Equal(1.0f, e1Transform.Rotation);
        Assert.Equal(1.0f, e2Transform.Rotation);
    }

    [Fact]
    public void CleanScene()
    {
        new TestEntity();
        new TestEntity();

        SceneSystem.CleanScene();

        Assert.Empty(SceneSystem.Entities);
        Assert.Empty(Transform2DSystem.Components);
    }

    public void Dispose()
    {
        SceneSystem.Entities.Clear();
        Transform2DSystem.Components.Clear();
    }
}