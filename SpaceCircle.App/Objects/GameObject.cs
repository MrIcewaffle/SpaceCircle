namespace SpaceCircle.App.Objects;

public abstract class GameObject
{
    protected bool _isActive = true;
    protected bool _isVisible = true;
    public abstract bool IsActive { get; }
    public abstract bool IsVisible { get; }

    public virtual void Destroy()
    { }

    public virtual void Draw()
    { }

    public virtual void Update()
    { }
}