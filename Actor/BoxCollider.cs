using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace GameEngine
{
    public class BoxCollider : Collider
    {
        private float _width;

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private float _height;

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public Vector2 Right
        {
            get {  return Owner.Position + new Vector2(_width / 2, 0); }
        }

        public Vector2 Left
        {
            get { return Owner.Position - new Vector2(_width / 2, 0); }
        }

        public Vector2 Top
        {
            get { return Owner.Position + new Vector2(0, _height / 2); }
        }

        public Vector2 Bottom
        {
            get { return Owner.Position - new Vector2(0, _height / 2); }
        }




        public BoxCollider(Actor owner, float width, float height) : base(owner)
        {
            _width = width;
            _height = height;

        }


        public override bool CheckCollisionCircle(CircleCollider other)
        {
            return false;
        }

        public override bool CheckCollisionBox(BoxCollider other)
        {
            Vector2 max1 = Owner.Position + new Vector2(_width / 2, _height / 2);
            Vector2 min1 = Owner.Position - new Vector2(_width / 2, _height / 2);

            Vector2 max2 = other.Owner.Position + new Vector2(_width / 2, _height / 2);
            Vector2 min2 = other.Owner.Position - new Vector2(_width / 2, _height / 2);


            return !(max1.X < min2.X || max2.X < min1.X
                || max1.Y < min2.Y || max2.Y < min1.Y);
        }

        public override void Draw()
        {
            base.Draw();
            Raylib.DrawRectangleLines((int)(Owner.Position.X - Width / 2), (int)(Owner.Position.Y - Height / 2), (int)_width, (int)_height, Owner.Graphic.SpriteColor);
        }
    }
}
