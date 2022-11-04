using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace GameEngine
{
    public class Player : Character
    {

        private Vector2 _lastPosition;
        private int _speed;

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Player(string name, Sprite graphic, int speed, Matrix3 transform, Collider collider) :
            base(name, graphic, transform, collider)
        {
            _speed = speed;
        }

        public override void OnCollision(Actor other)
        {
            Position = _lastPosition;
        }

        public override void Update(double deltaTime)
        {

        }


    }
}