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

        //Move one space to the up
        private void MoveUp()
        {
            if (!CurrentScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }

        //Move one space to the down
        private void MoveDown()
        {
            if (!CurrentScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }

        //Move one space to the left
        private void MoveLeft()
        {
            if (!CurrentScene.GetCollision(X - 1, Y))
            {
                X--;
            }
        }

        //Move one space to the right
        private void MoveRight()
        {
            if (!CurrentScene.GetCollision(X + 1, Y))
            {
                X++;
            }
        }
    }
}
