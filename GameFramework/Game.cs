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
            _currentScene = new Scene();
        }

        //The Scene we are currently running
        public static Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
        }

        public void Run()
        {
            //Add Walls to the Scene
            _currentScene.AddEntity(new Wall(0, 0));
            _currentScene.AddEntity(new Wall(1, 0));
            _currentScene.AddEntity(new Wall(2, 2));
            _currentScene.AddEntity(new Wall(3, 0));
            _currentScene.AddEntity(new Wall(4, 0));
            _currentScene.AddEntity(new Wall(5, 0));
            //Create a Player and position it
            Player player = new Player();
            player.X = 4;
            player.Y = 3;
            //Create an enemy and position it
            Entity enemy = new Entity('e');
            enemy.X = 4;
            enemy.Y = 5;
            //Add the enemy and player to the Scene
            _currentScene.AddEntity(enemy);
            _currentScene.AddEntity(player);

            //Start the first Scene
            _currentScene.Start();
            //Update, draw, and get input until the game is over
            while (!Gameover)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }
    }
}
