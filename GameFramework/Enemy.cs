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

        public Enemy() : this('e')
        {

        }

        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        private void TouchPlayer()
        {
            List<Entity> touched;
            touched = CurrentScene.GetEntities(X, Y);

            bool hit = false;
            foreach (Entity e in touched)
            {
                if (e is Player)
                {
                    hit = true;
                    break;
                }
            }

            if (hit)
            {
                CurrentScene.RemoveEntity(this);
            }
        }

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

        private void MoveUp()
        {
            if (!CurrentScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
            else
            {
                _facing++;
            }
        }

        private void MoveDown()
        {
            if (!CurrentScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
            else
            {
                _facing++;
            }
        }

        private void MoveLeft()
        {
            if (!CurrentScene.GetCollision(X - 1, Y))
            {
                X--;
            }
            else
            {
                _facing = Direction.North;
            }
        }

        private void MoveRight()
        {
            if (!CurrentScene.GetCollision(X + 1, Y))
            {
                X++;
            }
            else
            {
                _facing++;
            }
        }
    }
}
