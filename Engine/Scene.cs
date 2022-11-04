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

        public Scene()
        {
            _actors = new Actor[0];
        }

        public Actor[] Actors
        {
            get { return _actors; }
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


        public Actor GetActor(string name)
        {

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
        }

        public void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Active)
                    continue;

                _actors[i].Draw();
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