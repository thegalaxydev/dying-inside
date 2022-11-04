using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary; 

namespace GameEngine
{
    internal class UIText : Actor
    {
        private string _text;
        private Color _textColor;

        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public UIText(string name, Matrix3 transform, string text, Color textColor) : base(name, transform) 
        {
            _text = text;
            _textColor = textColor;
        }

        public override void Draw()
        {
            Raylib.DrawText(_text, (int)Position.X, (int)Position.Y, (int)Scale.X, _textColor);
        }
    }
}
