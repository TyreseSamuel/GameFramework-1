using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Scene
    {
        private List<Entity> _entities = new List<Entity>();
        private int _sizeX;
        private int _sizeY;

        public Scene()
        {
            _sizeX = 24;
            _sizeY = 6;
        }

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public int SizeX
        {
            get
            {
                return _sizeX;
            }
        }

        public int SizeY
        {
            get
            {
                return _sizeY;
            }
        }

        public void Start()
        {
            foreach (Entity e in _entities)
            {
                e.Start();
            }
        }

        public void Update()
        {
            foreach (Entity e in _entities)
            {
                e.Update();
            }
        }

        public void Draw()
        {
            //Clear the screen
            Console.Clear();

            //Create the display buffer
            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                //Call the Entity's Draw events
                e.Draw();
                //Position each Entity's icon in the display
                if (e.X >= 0 && e.X < _sizeX
                    && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[e.X, e.Y] = e.Icon;
                }
            }

            //Render the display buffer to the screen
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    Console.Write(display[x, y]);
                }
                Console.WriteLine();
            }
        }

        //Add an Entity to the Scene
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.CurrentScene = this;
        }

        //Remove an Entity from the Scene
        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
            entity.CurrentScene = null;
        }

        //Clear the Scene of Entities
        public void ClearEntities()
        {
            foreach (Entity e in _entities)
            {
                e.CurrentScene = null;
            }
            _entities.Clear();
        }
    }
}
