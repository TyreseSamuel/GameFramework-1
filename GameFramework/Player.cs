using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Player : Entity
    {
        //Creates a new Player represented by the '@' symbol and adds movement key events
        public Player() : this('@')
        {

        }

        //Creates a new Player with the specified symbol and adds movement key events
        public Player(char icon) : base(icon)
        {
            //Bind movement methods to the arrow keys
            PlayerInput.AddKeyEvent(MoveLeft, ConsoleKey.LeftArrow);
            PlayerInput.AddKeyEvent(MoveRight, ConsoleKey.RightArrow);
            PlayerInput.AddKeyEvent(MoveUp, ConsoleKey.UpArrow);
            PlayerInput.AddKeyEvent(MoveDown, ConsoleKey.DownArrow);
        }

        //Move one space up
        private void MoveUp()
        {
            if (Y - 1 < 0)
            {
                if (CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.North);
                }
                Y = CurrentScene.SizeY - 1;
            }
            else if (!CurrentScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }

        //Move one space down
        private void MoveDown()
        {
            if (Y + 1 >= CurrentScene.SizeY)
            {
                if (CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.South);
                }
                Y = 0;
            }
            else if (!CurrentScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }

        //Move one space to the left
        private void MoveLeft()
        {
            if (X - 1 < 0)
            {
                if (CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.West);
                }
                X = CurrentScene.SizeX - 1;
            }
            else if (!CurrentScene.GetCollision(X - 1, Y))
            {
                X--;
            }
        }

        //Move one space to the right
        private void MoveRight()
        {
            if (X + 1 >= CurrentScene.SizeX)
            {
                if (CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.East);
                }
                X = 0;
            }
            else if (!CurrentScene.GetCollision(X + 1, Y))
            {
                X++;
            }
        }

        //Move the Player to the destination Room and change the Scene
        private void Travel(Room destination)
        {
            //Ensure destination is not null
            if (destination == null)
            {
                return;
            }

            //Remove the Player from its current Room
            CurrentScene.RemoveEntity(this);
            //Add the Player to the destination Room
            destination.AddEntity(this);
            //Change the Game's active Scene to the destination
            Game.CurrentScene = destination;
        }
    }
}
