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
        private static Player _currentPlayer;
        private UIText _healthUI;

        public static Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; }
        }

        public GameManager(string name) : base(name) { }

        public override void Start() 
        {
            _healthUI = (UIText)Engine.CurrentScene.AddUI(new UIText("Health", Matrix3.Identity, "Health: " + _currentPlayer.Health, Color.WHITE));
            _healthUI.SetScale(new Vector2(25));
        
        }

        public override void Update(double deltaTime)
        {
            _healthUI.Text = "Health: " + _currentPlayer.Health;
        }




    }
}
