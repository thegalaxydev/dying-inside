using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace GameEngine
{
    public class CircleCollider : Collider
    {
        private float _collisionRadius;

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }
        }    

        public CircleCollider(Actor owner, float radius) : base(owner) 
        {
            _collisionRadius = radius;
        }
                                                                         

        public override bool CheckCollisionCircle(CircleCollider other)
        {
            return Vector2.Distance(other.Owner.Position, Owner.Position) <= other.CollisionRadius + CollisionRadius;
        }

        public override bool CheckCollisionBox(BoxCollider other)
        {
            return false;
        }

        public override void Draw()
        {
            base.Draw();
            Raylib.DrawCircleLines((int)Owner.Position.X, (int)Owner.Position.Y, _collisionRadius, Owner.Graphic.SpriteColor);
        }
    }
}
