using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace GameEngine
{
    public class Character : Actor
    {
        private Color _defaultColor;
        private int _speed;

        private int _health;
        private int _maxHealth;

        private FlashHandler _flashHandler;



        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }


        public Color DefaultColor
        {
            get { return _defaultColor; }
            set { _defaultColor = value; }
        }
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        } 

        public Character(string name, char icon, int speed, int maxHealth, Matrix3 transform, Color iconColor) 
            : base(name, transform, icon, iconColor) 
        {
            _defaultColor = iconColor;
            _speed = speed;
            _health = maxHealth;
            _maxHealth = maxHealth;
            CollisionVolume = new CircleCollider(this, Scale.X);
            _flashHandler = new FlashHandler("CharacterFlash", 10, 1f, this);
            Engine.CurrentScene.AddActor(_flashHandler);
        }

        public int TakeDamage(int damage)
        {
            _health -= damage;
            _flashHandler.StartFlashing();
            if (_health <= 0)
            {
                _health = 0;
                Active = false;
            }

            return _health;

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            ((CircleCollider)CollisionVolume).CollisionRadius = Scale.X / 2f;

            if (Active)
            {

                
            }
        }


        public override void Draw()
        {
            base.Draw();
            CollisionVolume.Draw();
        }
    }
}
