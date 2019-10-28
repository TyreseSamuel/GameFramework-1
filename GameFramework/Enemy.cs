using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Enemy : Entity
    {
        private Direction _facing;
        public float Speed { get; set; } = 0.25f;

        //Creates a new Enemy represented by the 'e' symbol and rat image
        public Enemy() : this('e', "images/tile210.png")
        {

        }

        public Enemy(char icon) : this(icon, "images/tile210.png")
        {

        }

        public Enemy(string imageName) : this('e', imageName)
        {

        }

        //Creates a new Enemy with the specified symbol
        public Enemy(char icon, string imageName) : base(icon, imageName)
        {
            //Start the Enemy facing North
            _facing = Direction.North;
            //Add Move and TouchPlayer to the OnUpdate Event
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        //Check to see if the Enemy has touched a Player and remove itself if so
        private void TouchPlayer()
        {
            //Get the List of Entities in our space
            List<Entity> touched = CurrentScene.GetEntities(X, Y);

            //Check if any of them are Players
            bool hit = false;
            foreach (Entity e in touched)
            {
                if (e is Player)
                {
                    hit = true;
                    break;
                }
            }

            //If we hit a Player, remove this Enemy from the Scene
            if (hit)
            {
                CurrentScene.RemoveEntity(this);
            }
        }

        //Move in the direction the Enemy is facing
        private void Move()
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUp();
                    break;
                case Direction.South:
                    MoveDown();
                    break;
                case Direction.East:
                    MoveRight();
                    break;
                case Direction.West:
                    MoveLeft();
                    break;
            }
        }

        //Move one space up
        private void MoveUp()
        {
            //Move up if the space is clear
            if (!CurrentScene.GetCollision(X, Y - Speed))
            {
                YVelocity = -Speed;
            }
            //Otherwise change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        //Move one space down
        private void MoveDown()
        {
            //Move down if the space is clear
            if (!CurrentScene.GetCollision(X, Y + 1))
            {
                YVelocity = Speed;
            }
            //Otherwise stop and change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        //Move one space left
        private void MoveLeft()
        {
            //Move left if the space is clear
            if (!CurrentScene.GetCollision(X - Speed, Y))
            {
                XVelocity = -Speed;
            }
            //Otherwise stop and change direction
            else
            {
                XVelocity = 0f;
                _facing = Direction.North;
            }
        }

        //Move one space right
        private void MoveRight()
        {
            //Move right if the space is clear
            if (!CurrentScene.GetCollision(X + 1, Y))
            {
                XVelocity = Speed;
            }
            //Otherwise stop and change direction
            else
            {
                XVelocity = 0f;
                _facing++;
            }
        }
    }
}
