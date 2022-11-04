using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// A 3x3 collection of floats.
    /// </summary>
    public struct Matrix3
    {
        public float M00, M01, M02;
        public float M10, M11, M12;
        public float M20, M21, M22;


        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        public static Matrix3 Identity
        {
            get { return new Matrix3(1, 0, 0, 
                                     0, 1, 0, 
                                     0, 0, 1); }
        }

        public void Scale(Vector2 scale)
        {
            M00 *= scale.X;
            M01 *= scale.X;

            M10 *= scale.Y;
            M11 *= scale.Y;
        }


        public static Vector2[] ToVectorArray(Matrix3 m)
        {
            Vector2[] result = new Vector2[3]
            {
                new Vector2(m.M00, m.M01),
                new Vector2(m.M10, m.M11),
                new Vector2(m.M20, m.M21)
            };


            return result;
        }

  

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.M00 + rhs.M00, lhs.M01 + rhs.M01, lhs.M02 + rhs.M02,
                               lhs.M10 + rhs.M10, lhs.M11 + rhs.M11, lhs.M02 + rhs.M12,
                               lhs.M20 + rhs.M20, lhs.M21 + rhs.M21, lhs.M22 + rhs.M22);
        }

        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.M00 - rhs.M00, lhs.M01 - rhs.M01, lhs.M02 - rhs.M02,
                               lhs.M10 - rhs.M10, lhs.M11 - rhs.M11, lhs.M02 - rhs.M12,
                               lhs.M20 - rhs.M20, lhs.M21 - rhs.M21, lhs.M22 - rhs.M22);
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            float m00 = (lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * lhs.M20);
            float m01 = (lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * lhs.M21);
            float m02 = (lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * lhs.M22);

            float m10 = (lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * lhs.M20);
            float m11 = (lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * lhs.M21);
            float m12 = (lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * lhs.M22);

            float m20 = (lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * lhs.M20);
            float m21 = (lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * lhs.M21);
            float m22 = (lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * lhs.M22);

            return new Matrix3(m00,m01,m02,m10,m11,m12,m20,m21,m22);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               