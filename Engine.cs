using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;
using System.Diagnostics;


namespace GameEngine
{
    static class Engine
    {
        private const int SCREEN_WIDTH = 800;
        private const int SCREEN_HEIGHT = 450;
        private static Scene _currentScene;
        private static Scene[] _scenes;
        private static Stopwatch _stopwatch;
        
        public static Scene CurrentScene
        {
            get { return _currentScene; }
        }

        public static Vector2 ScreenDimensions
        {
            get
            {
                return new Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
            }
        }
        /// <summary>
        /// Called to begin the application.
        /// </summary>
        public static void Run()
        {
            //Calls start for the current scene.
            Start();

            //Start a new stopwatch to keep track of the time that's passed.
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            //Initialize default variables for calculating deltatime.
            double currentTime = 0;
            double lastTime = 0;
            double deltaTime = 0;

            //Loop until the application is told to close.
            while (!Raylib.WindowShouldClose())
            {
                //Store the current time that has passed since the game started in seconds.
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0;

                //Subtract last time from current time to find delta time.
                deltaTime = currentTime - lastTime;

                //Update the current scene.
                Update(deltaTime);
                //Draw the current scene.
                Draw();

                //Store the current time for the next delta time calculation.
                lastTime = currentTime;
            }

            End();
        }

        //Performed once when the game begins

        private static Scene AddScene(Scene scene)
        {
            Scene[] newSceneArray = new Scene[_scenes.Length + 1];
            for (int i = 0; i < _scenes.Length; i++)
            {
                newSceneArray[i] = _scenes[i];
            }

            newSceneArray[newSceneArray.Length - 1] = scene;

            return scene;
        }

        public static void SetCurrentScene(int sceneIndex)
        {
            Math.Clamp(sceneIndex, 0, _scenes.Length);
            _currentScene = _scenes[sceneIndex];
        }

        private static void Start()
        {
            Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "Engine");
            Raylib.SetTargetFPS(45);

            _scenes = new Scene[0];

            _currentScene = AddScene(new Scene());

            _currentScene.Start();

        }

        //Repeated until the game ends
        private static void Update(double deltaTime)
        {
            _currentScene.Update(deltaTime);
            
        }

        //Updates visuals every game loop
        private static void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawFPS(SCREEN_WIDTH - 100, 0);
            _currentScene.Draw();

            Raylib.EndDrawing();
        }

        //Performed once when the game ends
        private static void End()
        {
            _currentScene.End();
        }
    }
}