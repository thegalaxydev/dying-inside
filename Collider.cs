using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class Collider
    {
        private Actor _owner;

        public Actor Owner 
        {
            get { return _owner; }
        }

        public Collider(Actor owner)
        {
            _owner = owner;
        }

        public bool CheckCollision(Actor other)
        {
            if (other.CollisionVolume == null) return false;

            if (other.CollisionVolume is CircleCollider) 
            {
                return CheckCollisionCircle((CircleCollider)other.CollisionVolume);
            }

            return false;
        }

        public abstract bool CheckCollisionCircle(CircleCollider other);

        public virtual void Draw()
        {
            if (_owner == null) return;
        }
    }
}
