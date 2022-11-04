using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;


namespace GameEngine
{
    internal class GameManager : Actor
    {
        private static Player _playerCharacter;

        public static Player PlayerCharacter
        {
            get { return _playerCharacter; }
            set { _playerCharacter = value; }
        }

        public GameManager(string name) : base(name) { }

        public override void Start() 
        {
        
        }


        public override void Update(double deltaTime)
        {

        }

        public override void Draw()
        {
            
        }





    }
}
