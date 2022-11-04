using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Raylib_cs;

namespace GameEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class FlashHandler : Actor
    {

        private double _currentTime = 0.0;
        private bool _isFlashing = false;
        private int _numberOfFlashes;
        private float _timePerFlash;
        private int _timesFlashed;
        private Character _currentCharacter;


        public FlashHandler(string name, int numberOfFlashes, float timesPerFlash, Character currentCharacter) :base (name)
        {
            _numberOfFlashes = numberOfFlashes;
            _timePerFlash = timesPerFlash;
            _currentCharacter = currentCharacter;
        }

        public void StartFlashing(int flashCount)
        {
            _numberOfFlashes = flashCount;
            StartFlashing();
        }

        public void StartFlashing()
        {
            Console.WriteLine("Started Flashing");
            _currentCharacter.IconColor = Color.WHITE;
            _timesFlashed = 0;
            _currentTime = 0f;
            _isFlashing = true;
        }

        /// <summary>
        /// Swap the color from white to default and vice versa
        /// </summary>
        public void SwapColor()
        {
            
            if (_currentCharacter.MatchesColor(_currentCharacter.DefaultColor))
            {
                Console.WriteLine("Swapped Color to White");
                _currentCharacter.IconColor = Color.WHITE;
            }
                
            else
            {
                Console.WriteLine("Swapped Color to Default");
                _currentCharacter.IconColor = _currentCharacter.DefaultColor;
            }
                
        }


        public override void Update(double deltaTime)
        {
            // If the flash is not currently active
            if (!_isFlashing)
                return;

            _currentTime += deltaTime;
            
            // Changes the color to "flash" the character if enough time has passed.
            if (_currentTime >= _timePerFlash)
            {
                

                // Swap the color from white to default and vice versa, increase the amount of times flashed
                SwapColor();
                Console.WriteLine("Flashed");
                _currentTime -= _timePerFlash;
                Console.WriteLine(_currentTime);
                _timesFlashed++;
            }

            // If the flash has exceeded the maximum amount, or the character is not active.
            if (_timesFlashed >= _numberOfFlashes || !_currentCharacter.Active)
            {
                _currentCharacter.IconColor = _currentCharacter.DefaultColor;
                _isFlashing = false;
            }
        }

    }
}
