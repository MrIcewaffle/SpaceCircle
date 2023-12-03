namespace Models
{
   public abstract class SceneBase
    {
        public abstract void Draw();
        public abstract void Update();
        public abstract int SwitchToScene();
    }
}