using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class Game
    {
        //The tilesize of the game
        public static readonly int SizeX = 16;
        public static readonly int SizeY = 16;
        //Whether or not the Game should finish Running and exit
        public static bool Gameover = false;
        //The Scene we are currently running
        private static Scene _currentScene;

        //Creates a Game and new Scene instance as its active Scene
        public Game()
        {
            RL.InitWindow(640, 480, "Hello World");
            RL.SetTargetFPS(15);
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

        public void Run()
        {
            //Bind Esc to exit the game (no longer needed)
            //PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape);

            Init();
            
            //Update, draw, and get input until the game is over
            while (!Gameover && !RL.WindowShouldClose())
            {
                _currentScene.Update();

                RL.BeginDrawing();
                _currentScene.Draw();
                RL.EndDrawing();

                PlayerInput.ReadKey();
            }

            RL.CloseWindow();
        }
        
        public void Quit()
        {
            Gameover = true;
        }

        private void Init()
        {
            Room startingRoom = LoadRoom("rooms/starting.txt");
            Room otherRoom = LoadRoom("rooms/other.txt");

            startingRoom.North = otherRoom;

            //Create a Player, position it, and add it to startingRoom
            //Player player = new Player("images/tile196.png");
            //player.X = 4;
            //player.Y = 3;
            //startingRoom.AddEntity(player);
            /*
            //Reset the Enemy's position when we enter otherRoom
            void OtherRoomStart()
            {
                enemy.X = 4;
                enemy.Y = 4;
            }
            enemy.OnStart += OtherRoomStart;

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
                startingRoom.AddEntity(new Wall(i, startingRoom.SizeY - 1));
            }
            //east walls
            for (int i = 1; i < startingRoom.SizeY - 1; i++)
            {
                startingRoom.AddEntity(new Wall(startingRoom.SizeX - 1, i));
            }
            //west walls
            for (int i = 1; i < startingRoom.SizeY - 1; i++)
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
                    otherRoom.AddEntity(new Wall(i, otherRoom.SizeY - 1));
                }
            }
            //east walls
            for (int i = 1; i < otherRoom.SizeY - 1; i++)
            {
                otherRoom.AddEntity(new Wall(otherRoom.SizeX - 1, i));
            }
            //west walls
            for (int i = 1; i < otherRoom.SizeY - 1; i++)
            {
                otherRoom.AddEntity(new Wall(0, i));
            }
            */
            CurrentScene = startingRoom;
        }
        
        private Room LoadRoom(string path)
        {
            StreamReader reader = new StreamReader(path);

            int width, height;
            Int32.TryParse(reader.ReadLine(), out width);
            Int32.TryParse(reader.ReadLine(), out height);

            Room room = new Room(width, height);

            for (int y = 0; y < height; y++)
            {
                string row = reader.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    char tile = row[x];
                    switch (tile)
                    {
                        case '1':
                            room.AddEntity(new Wall(x, y));
                            break;
                        case '@':
                            Player p = new Player();
                            p.X = x;
                            p.Y = y;
                            room.AddEntity(p);
                            break;
                        case 'e':
                            Enemy e = new Enemy();
                            e.X = x;
                            e.Y = y;
                            room.AddEntity(e);
                            break;

                    }
                }
            }

            return room;
        }
    }
}
