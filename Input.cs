using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace GameEngine
{
    internal class Input
    {
        public static Vector2 GetMoveInput()
        {

            int xDirection = -Raylib.IsKeyDown(KeyboardKey.KEY_A) + Raylib.IsKeyDown(KeyboardKey.KEY_D);
            int yDirection = -Raylib.IsKeyDown(KeyboardKey.KEY_W) + Raylib.IsKeyDown(KeyboardKey.KEY_S);


            return new Vector2(xDirection,yDirection); 
        }
    }
} 