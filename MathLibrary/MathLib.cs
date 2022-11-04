using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct MathLib
    {
        public static float Rad(float degrees)
        {
            return (float)(degrees * (Math.PI / 180));
        }

        public static float Deg(float rad)
        {
            return (float)(rad * 180 / Math.PI);
        }
    }
}
