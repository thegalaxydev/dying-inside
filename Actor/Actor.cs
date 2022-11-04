 using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace GameEngine
{
    public class Actor
    {
        private Matrix3 _transform;
        private string _name;
        private Vector2 _facing;
        private Sprite _graphic;
        private bool _active = true;
        private bool _canCollide;
        private Collider _collisionVolume;


        public Sprite Graphic
        {
            get { return _graphic; }
            set { _graphic = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public bool CanCollide 
        { 
            get { return _canCollide;} 
            set { _canCollide = value; }
        }

        public Collider CollisionVolume
        {
            get { return _collisionVolume; }
            set { _collisionVolume = value; }
        }

        public Vector2 Scale
        {
            get
            {
                float x = new Vector2(_transform.M00, _transform.M01).Magnitude;
                float y = new Vector2(_transform.M10, _transform.M11).Magnitude;
                return new Vector2(x, y);
            }
        }

        public Vector2 Facing
        {
            get { return _facing; }
            set { _facing = value; }
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_transform.M20, _transform.M21);
            }
            set
            {
                _transform.M20 = value.X;
                _transform.M21 = value.Y;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }


        public Actor(string name, Matrix3 transform, Sprite graphic)
        {
            _name = name;
            _graphic = graphic;
            _transform = transform;
        }

        public Actor(string name, Matrix3 transform)
        {
            _name = name;
            _transform = transform;
        }

        public Actor(string name)
        {
            _name = name;
        }
        public void SetScale(Vector2 v1)
        {
            Vector2 x = new Vector2(_transform.M00, _transform.M01).Normalized;
            Vector2 y = new Vector2(_transform.M10, _transform.M11).Normalized;

            x *= v1.X;
            y *= v1.Y;

            _transform.M00 = x.X;
            _transform.M01 = x.Y;

            _transform.M10 = y.X;
            _transform.M11 = y.Y;
        }

        public void Translate(float x, float y)
        {
            Position += new Vector2(x,y);
        }

        public void Translate(Vector2 direction)
        {
            //new way with operator overloading
            Position += direction;
        }


        public virtual void Start()
        {
        }

        public virtual void OnCollision(Actor other)
        {

        }

        public bool MatchesColor(Color c2)
        {
            return (_graphic.SpriteColor.r == c2.r && _graphic.SpriteColor.g == c2.g && _graphic.SpriteColor.b == c2.b);
        }

        public bool CheckCollision(Actor other)
        {
            return _collisionVolume != null ? _collisionVolume.CheckCollision(other) : false;
        }
        public virtual void Update(double deltaTime)
        {

        }

        public virtual void Draw()
        {
            if (Graphic != null)
                Graphic.Draw(_transform);
        }

        public virtual void End()
        {

        }
    }
}