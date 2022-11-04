using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Diagnostics;
using MathLibrary;

namespace GameEngine
{
    internal class Enemy : Character
    {

        private Actor _target;
        private float lookDistance = 75f;
        private float lookRadius = 0.5f;
        private Vector2 _lastPosition;
        private int _attackCooldown;
        private int _baseDamage;
        private double _currentTime = 0.0;
        private bool _canAttack = true;
        
        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enemy(string name, char icon, int speed, int attackCooldown, int baseDamage, int maxHealth, Matrix3 transform, Actor target, Color iconColor) :
            base(name, icon, speed, maxHealth, transform, iconColor)
        {
            _attackCooldown = attackCooldown;
            _baseDamage = baseDamage;
            _target = target;
        }

        Vector2 GetTargetDirection()
        {
            return _target.Position - Position;
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            if (!_canAttack)
            {
                _currentTime += deltaTime;
                if (_currentTime >= _attackCooldown)
                    _canAttack = true;
            }

            if (_target != null && _target.Active)
            {
                _lastPosition = Position;
                Vector2 direction = GetTargetDirection().Normalized;
                Vector2 velocity = direction * Speed * (float)deltaTime;
                if (Vector2.Distance(Position, _target.Position) < (lookDistance) && Vector2.Dot(_target.Facing, direction) >= lookRadius)
                {
                    IconColor = Color.RED;
                    Translate(velocity);
                }
                else
                {
                    IconColor = Color.GREEN;
                }
            }
            else
            {
                IconColor = Color.GREEN;
            }
        }

        public override void OnCollision(Actor other)
        {
            Position = _lastPosition;
            Player player = other as Player;

            if (player == null)
                return;

            if (!_canAttack)
                return;
 
            _canAttack = false;
            player.TakeDamage(_baseDamage);
            _currentTime = 0.0;
        }

        public override void Draw()
        {
            base.Draw();
            float radians = MathF.Acos(lookRadius);
            Vector2 endLineDirection = new Vector2(MathF.Cos(radians), MathF.Sin(radians)) * -(lookDistance / MathF.Cos(radians * 180 / (float)Math.PI));



            Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)(Position.X + lookDistance), (int)Position.Y, IconColor);
            Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)(Position.X + endLineDirection.X), (int)(Position.Y - endLineDirection.Y), IconColor);
            Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)(Position.X + endLineDirection.X), (int)(Position.Y + endLineDirection.Y), IconColor);
            Raylib.DrawLineBezierQuad(Vector2.ToNumeric(Position.X + endLineDirection.X, Position.Y - endLineDirection.Y), 
                Vector2.ToNumeric(Position.X + endLineDirection.X, Position.Y + endLineDirection.Y), Vector2.ToNumeric(Position.X + lookDistance * 1.5f, Position.Y), 1, IconColor);
        }

    }
}