using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Player : Entity
    {
        public Player() : this('@')
        {

        }

        public Player(char icon) : base(icon)
        {
            PlayerInput.AddKeyEvent(MoveLeft, ConsoleKey.LeftArrow);
            PlayerInput.AddKeyEvent(MoveRight, ConsoleKey.RightArrow);
            PlayerInput.AddKeyEvent(MoveUp, ConsoleKey.UpArrow);
            PlayerInput.AddKeyEvent(MoveDown, ConsoleKey.DownArrow);
        }

        //Move one space to the up
        private void MoveUp()
        {
            if (Y > 0)
            {
                Y--;
            }
        }

        //Move one space to the down
        private void MoveDown()
        {
            if (Y < CurrentScene.SizeY - 1)
            {
                Y++;
            }
        }

        //Move one space to the left
        private void MoveLeft()
        {
            if (X > 0)
            {
                X--;
            }
        }

        //Move one space to the right
        private void MoveRight()
        {
            if (X < CurrentScene.SizeX-1)
            {
                X++;
            }
        }
    }
}
