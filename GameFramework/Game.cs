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
        //The Scene we are about to go to
        private static Scene _nextScene;
        //The camera for the 3D view
        private Camera3D _camera;

        //Creates a Game and new Scene instance as its active Scene
        public Game()
        {
            RL.InitWindow(640, 480, "Hello World");
            RL.SetTargetFPS(15);

            Raylib.Vector3 cameraPosition = new Raylib.Vector3(64, 0, -100);
            Raylib.Vector3 cameraTarget = new Raylib.Vector3(64, 0, 0);
            Raylib.Vector3 cameraUp = new Raylib.Vector3(0.0f, 0.0f, 0.0f);

            _camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);
        }

        //The Scene we are currently running
        public static Scene CurrentScene
        {
            set
            {
                _nextScene = value;
            }
            get
            {
                return _currentScene;
            }
        }

        //Run the game loop
        public void Run()
        {
            //Bind Esc to exit the game (no longer needed)
            //PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape);

            Init();
            
            //Update, draw, and get input until the game is over
            while (!Gameover && !RL.WindowShouldClose())
            {
                //Start the Scene if needed
                if (_currentScene != _nextScene)
                {
                    _currentScene = _nextScene;
                    _currentScene.Start();
                }

                //Update the active Scene
                _currentScene.Update();

                //int mouseX = (RL.GetMouseX() - 320) / 16;
                //int mouseY = (RL.GetMouseY() - 240) / 16;
                //Raylib.Vector3 cameraPosition = new Raylib.Vector3(mouseX, mouseY, -100);
                //Raylib.Vector3 cameraTarget = new Raylib.Vector3(mouseX, mouseY, 0);
                //Raylib.Vector3 cameraUp = new Raylib.Vector3(0, -1, 0);

                //_camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);

                //Draw the active Scene
                RL.BeginDrawing();
                //RL.BeginMode3D(_camera);
                _currentScene.Draw();
                //RL.EndMode3D();
                RL.EndDrawing();
            }

            RL.CloseWindow();
        }
        
        //Flags the game as ready to end
        public void Quit()
        {
            Gameover = true;
        }

        //Sets up the initial game state
        private void Init()
        {
            Room startingRoom = LoadRoom("rooms/starting.txt");
            Room otherRoom = LoadRoom("rooms/other.txt");

            startingRoom.North = otherRoom;

            CurrentScene = startingRoom;
        }
        
        //Loads and returns a room from a file
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
