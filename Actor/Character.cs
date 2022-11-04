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

        public Color DefaultColor
        {
            get { return _defaultColor; }
            set { _defaultColor = value; }
        }

        public Character(string name, Sprite graphic, Matrix3 transform, Collider collider) 
            : base(name, transform, graphic) 
        {
            _defaultColor = graphic.SpriteColor;
            CollisionVolume = collider;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

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
