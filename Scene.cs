using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;


namespace GameEngine
{
    internal class Scene
    {
        private Actor[] _actors;
        private Actor[] _userInterface;

        public Scene()
        {
            _actors = new Actor[0];
            _userInterface = new Actor[0];
        }

        public Actor[] Actors
        {
            get { return _actors; }
        }

        public Actor[] UserInterface
        {
            get { return _userInterface; }
        }

        public Actor AddActor(Actor actor)
        {
            Actor[] newActorArray = new Actor[_actors.Length + 1];

            for (int i = 0; i < _actors.Length; i++)
            {
                newActorArray[i] = _actors[i];
            }


            newActorArray[newActorArray.Length - 1] = actor;

            _actors = newActorArray;

            return actor;
        }

        public Actor AddUI(UIText ui)
        {
            Actor[] newActorArray = new Actor[_userInterface.Length + 1];

            for (int i = 0; i < _userInterface.Length; i++)
            {
                newActorArray[i] = _userInterface[i];
            }


            newActorArray[newActorArray.Length - 1] = ui;

            _userInterface = newActorArray;

            return ui;
        }

        public bool RemoveActor(UIText actor)
        {
            Actor[] newActorArray = new Actor[_actors.Length - 1];
            bool hasActor = false;
            for (int i = 0, j = 0; i < _actors.Length; i++)
            {
                if (_actors[i] != actor)
                {
                    j++;

                    newActorArray[j] = _actors[i];
                }
                else
                {
                    hasActor = true;
                }
            }

            if (hasActor)
            {
                _actors = newActorArray;
            }

            return hasActor;
        }

        public bool RemoveUI(int uiIndex)
        {
            if (uiIndex < 0 || uiIndex >= _userInterface.Length)
                return false;

            Actor[] newUIArray = new Actor[_userInterface.Length - 1];
            bool hasUI = false;
            for (int i = 0, j = 0; i < _userInterface.Length; i++)
            {
                if (i != uiIndex)
                {
                    j++;
                    newUIArray[j] = _userInterface[i];
                }
                else
                {
                    hasUI = true;
                }

            }
            if (hasUI)
            {
                _userInterface = newUIArray;
            }

            return hasUI;
        }

        public bool RemoveActor(int actorIndex)
        {
            if (actorIndex < 0 || actorIndex >= _actors.Length)
                return false;

            Actor[] newActorArray = new Actor[_actors.Length - 1];
            bool hasActor = false;
            for (int i = 0, j = 0; i < _actors.Length; i++)
            {
                if (i != actorIndex)
                {
                    j++;
                    newActorArray[j] = _actors[i];
                }
                else
                {
                    hasActor = true;
                }
                
            }
            if (hasActor)
            {
                _actors = newActorArray;
            }

            return hasActor;

        }

        public bool RemoveActor(Actor actor)
        {
            Actor[] newActorArray = new Actor[_actors.Length - 1];
            bool hasActor = false;
            for (int i = 0, j = 0; i < _actors.Length; i++)
            {
                if (_actors[i] != actor)
                {
                    j++;

                    newActorArray[j] = _actors[i];
                }
                else
                {
                    hasActor = true;
                }
            }

            if (hasActor)
            {
                _actors = newActorArray;
            }

            return hasActor;
        }

        public void Start()
        {
            GameManager gameManager = (GameManager)AddActor(new GameManager("MainGameManager"));

            Player player = (Player)AddActor(new Player("Player", 'A', 50, 160, Matrix3.Identity, Color.DARKBLUE));
            player.SetScale(new Vector2(50, 50));
            player.Position = new Vector2(150,150);
            GameManager.CurrentPlayer = player;

            AddActor(new Enemy("Enemy", 'E', 25, 20, 20, 50, new Matrix3(50,0,0, 0,50,0, 25,25,1), player, Color.RED));

            //Call start for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        public void Update(double deltaTime)
        {
            //Update each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Active)
                    continue;

                _actors[i].Update(deltaTime);

                if (_actors[i].CollisionVolume == null)
                    continue;

                for (int j = 0; j < _actors.Length; j++)
                {
                    if (_actors[j].CollisionVolume == null || !_actors[j].Active)
                        continue;


                    if (_actors[i] != _actors[j]) 
                    {
                        bool collided = _actors[i].CheckCollision(_actors[j]);
                        if (collided)
                            _actors[i].OnCollision(_actors[j]);
                    }
                }
            }

            //Update each UI element in the scene.
            for (int i = 0; i < _userInterface.Length; i++)
            {
                if (!_userInterface[i].Active)
                    continue;

                _userInterface[i].Update(deltaTime);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Active)
                    continue;

                _actors[i].Draw();
            }

            for (int i = 0; i < _userInterface.Length; i++)
            {
                if (!_userInterface[i].Active)
                    continue;

                _userInterface[i].Draw();
            }
        }

        public void End()
        {
            //Call end for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }
    }
}   