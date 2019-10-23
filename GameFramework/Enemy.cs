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

        //Creates a new Enemy represented by the 'e' symbol
        public Enemy() : this('e')
        {

        }

        //Creates a new Enemy with the specified symbol
        public Enemy(char icon) : base(icon)
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
            if (!CurrentScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
            //Otherwise change direction
            else
            {
                _facing++;
            }
        }

        //Move one space down
        private void MoveDown()
        {
            //Move down if the space is clear
            if (!CurrentScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
            //Otherwise change direction
            else
            {
                _facing++;
            }
        }

        //Move one space left
        private void MoveLeft()
        {
            //Move left if the space is clear
            if (!CurrentScene.GetCollision(X - 1, Y))
            {
                X--;
            }
            //Otherwise change direction
            else
            {
                _facing = Direction.North;
            }
        }

        //Move one space right
        private void MoveRight()
        {
            //Move right if the space is clear
            if (!CurrentScene.GetCollision(X + 1, Y))
            {
                X++;
            }
            //Otherwise change direction
            else
            {
                _facing++;
            }
        }
    }
}
