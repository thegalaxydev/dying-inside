using System;
using System.Numerics;

namespace MathLibrary
{
    public struct Vector2
    {

        private float _x, _y;

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        /// <summary>
        /// Gets the length of this vector.
        /// </summary>
        public float Magnitude
        {
            get
            {
                return MathF.Sqrt(X * X + Y * Y);
            }
        }

        /// <summary>
        /// Returns a copy of this vector that has a length of one.
        /// </summary>
        /// 
        public static float Distance(Vector2 a, Vector2 b)
        {
            return (a - b).Magnitude;
        }
        public Vector2 Normalized
        {
            get
            {
                return Magnitude > 0 ? new Vector2(X / Magnitude, Y / Magnitude) : Vector2.Zero;
            } 
        }

        /// <summary>
        /// Changes the length of this vector to have a magnitude that is equal to one.
        /// </summary>
        /// <returns>The result of the normalization.</returns>
        public Vector2 Normalize()
        {
            _x = X / Magnitude;
            _y = Y / Magnitude;

            return new Vector2(X, Y);
        }

        public static System.Numerics.Vector2 ToNumeric(Vector2 v) => new System.Numerics.Vector2(v.X, v.Y);
        
        public static System.Numerics.Vector2 ToNumeric(float x, float y)
        {
            return new System.Numerics.Vector2(x, y);
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Vector2(float xy)
        {
            _x = xy;
            _y = xy;
        }


        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);

        }
        public static Vector2 operator +(Vector2 lhs)
        {
            return new Vector2(+lhs.X, +lhs.Y);

        }

        public static Vector2 operator +(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X + rhs, lhs.Y + rhs);

        }

        public static Vector2 operator -(Vector2 lhs)
        {
            return new Vector2(-lhs.X, -lhs.Y);

        }

        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X * rhs, lhs.Y * rhs);
        }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            lhs = lhs.Normalized;
            rhs = rhs.Normalized;
            return new Vector2(lhs.X * rhs.X + lhs.Y * rhs.X);
        }

        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X / rhs, lhs.Y / rhs);
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return lhs.X * rhs.X + lhs.Y * rhs.X;
        }
        public static Vector2 One
        {
            get { return new Vector2(1, 1); }
        } 

        public static Vector2 UnitX
        { 
            get { return new Vector2(1, 0); }
        }

        public static Vector2 UnitY
        {
            get { return new Vector2(0, 1); }
        }

        public static Vector2 Zero
        {
            get { return new Vector2(0, 0); }
        }

        public void Scale(float scale)
        {
            _x *= scale;
            _y *= scale;
        }

    }
}