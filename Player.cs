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

        public Player(string name, char icon, int speed, int maxHealth, Matrix3 transform, Color iconColor) :
            base(name, icon, speed, maxHealth, transform, iconColor)
        {

        }

        public override void OnCollision(Actor other)
        {
            Position = _lastPosition;
        }

        public override void Update(double deltaTime)
        {

            base.Update(deltaTime);
            _lastPosition = Position;
            Vector2 direction = Input.GetMoveInput();
            base.Facing = Vector2.UnitX;
            Vector2 velocity = direction.Normalized * Speed * (float)deltaTime;

            Translate(velocity);

        }


    }
}