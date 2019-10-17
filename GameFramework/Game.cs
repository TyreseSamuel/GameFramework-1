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

        private static Scene _currentScene;

        public Game()
        {
            _currentScene = new Scene();
        }

        public void Run()
        {
            Player player = new Player();
            player.X = 4;
            player.Y = 3;
            Entity enemy = new Entity('#');
            enemy.X = 4;
            enemy.Y = 5;

            _currentScene.AddEntity(enemy);
            _currentScene.AddEntity(player);

            _currentScene.Start();

            //Loop until the game is over
            while (!Gameover)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }

        public static Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
        }
    }
}
