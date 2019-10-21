using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Game
    {
        //Whether or not the Game should finish Running and exit
        public static bool Gameover = false;
        //The Scene we are currently running
        private static Scene _currentScene;

        //Creates a Game and new Scene instance as its active Scene
        public Game()
        {
            
        }

        //The Scene we are currently running
        public static Scene CurrentScene
        {
            set
            {
                _currentScene = value;
                _currentScene.Start();
            }
            get
            {
                return _currentScene;
            }
        }

        private void Init()
        {
            Room startingRoom = new Room(8, 6);
            Room otherRoom = new Room(12, 6);
            
            Enemy enemy = new Enemy();
            void OtherRoomStart()
            {
                enemy.X = 4;
                enemy.Y = 4;
            }

            otherRoom.OnStart += OtherRoomStart;

            startingRoom.North = otherRoom;
            //Add Walls to the startingRoom
            startingRoom.AddEntity(new Wall(2, 2));
            //north walls
            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    startingRoom.AddEntity(new Wall(i, 0));
                }
            }
            //south walls
            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                startingRoom.AddEntity(new Wall(i, startingRoom.SizeY-1));
            }
            //east walls
            for (int i = 1; i < startingRoom.SizeY-1; i++)
            {
                startingRoom.AddEntity(new Wall(startingRoom.SizeX-1, i));
            }
            //west walls
            for (int i = 1; i < startingRoom.SizeY-1; i++)
            {
                startingRoom.AddEntity(new Wall(0, i));
            }
            //Add Walls to the otherRoom
            //north walls
            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                otherRoom.AddEntity(new Wall(i, 0));
            }
            //south walls
            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(i, otherRoom.SizeY-1));
                }
            }
            //east walls
            for (int i = 1; i < otherRoom.SizeY - 1; i++)
            {
                otherRoom.AddEntity(new Wall(otherRoom.SizeX-1, i));
            }
            //west walls
            for (int i = 1; i < otherRoom.SizeY - 1; i++)
            {
                otherRoom.AddEntity(new Wall(0, i));
            }

            //Create a Player, position it, and add it to startingRoom
            Player player = new Player();
            player.X = 4;
            player.Y = 3;
            startingRoom.AddEntity(player);
            //Add enemy to otherRoom
            otherRoom.AddEntity(enemy);

            CurrentScene = startingRoom;
        }

        public void Run()
        {
            //Bind Esc to exit the game
            PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape);

            Init();
            
            //Update, draw, and get input until the game is over
            while (!Gameover)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }

        public void Quit()
        {
            Gameover = true;
        }
    }
}
