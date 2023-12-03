namespace GameObjects
{
    public class Planet : ObjectBase
    {
        public string Name;

        private Vector2 orbitCenter;
        private Vector2 position;
        private float orbitRadius;
        private float radius;
        private Color baseColor;

        private float speed;
        private float orbitPos;

        private Rectangle collider;

        //update gui flags
        private bool hover;
        private bool selected;

        public Planet(Vector2 origin, Vector2 startPos, float distance, float radius, Color color, float speed, float startOrbit = 0)
        {
            orbitCenter = origin;
            position = startPos;
            orbitRadius = distance;
            this.radius = radius;
            baseColor = color;
            this.speed = speed;
            if (startOrbit > 0)
                orbitPos = startOrbit;

            collider = new Rectangle { X = position.X - radius, Y = position.Y - radius, width = radius*2, height = radius*2 };

            Name = "Test Planet";
        }
        public override void Draw()
        {
            //draw planet first
            DrawCircleV(position, radius, baseColor);

            //--- gui ---
            //hover
            if (hover | selected)
            {
                DrawText(Name, collider.X + ((radius*2) + 5), collider.Y, 10f, DARKGRAY);
                DrawRectangleLines((int)collider.X, (int)collider.Y, (int)radius*2, (int)radius*2, DARKGRAY);
            }
        }

        public override void Update()
        {
            //check mouse position to show UI before updating location
            Vector2 mousePos = GetMousePosition();

            if (CheckCollisionPointRec(mousePos, collider))
            {
                if (IsMouseButtonDown(MOUSE_LEFT_BUTTON))
                  selected = !selected;
                //else something?
                hover = true;
            }
            else
                hover = false;

            orbitPos += speed;
            if (orbitPos >= 360.0f)
                orbitPos += -360.0f;
            
            float x = orbitCenter.X + (float)(orbitRadius * Math.Cos(orbitPos));
            float y = orbitCenter.Y + (float)(orbitRadius * Math.Sin(orbitPos));

            position.X = x;
            collider.X = x - radius;
            position.Y = y;
            collider.Y = y - radius;
        }
    }
}