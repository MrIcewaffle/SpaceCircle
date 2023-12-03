namespace GUI
{
    public class Button : ObjectBase
    {
        private Rectangle btnBounds;
        private string btnText;
        private bool pressed;
        public Button(Rectangle bounds, string text)
        {
            btnBounds = bounds;
            btnText = text;
        }

        public bool Pressed()
        {
            return pressed;
        }
        public override void Draw()
        {
            pressed = GuiButton(btnBounds, btnText);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}