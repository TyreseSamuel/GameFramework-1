using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    delegate void Event();

    class Entity
    {
        //Events that are called when the Entity is Started, Updated, and Drawn
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        //The location of the Entity
        private Vector2 _location = new Vector2();

        //The character representing the Entity on the screen
        public char Icon { get; set; } = ' ';
        //The image representing the Entity on the screen
        public Texture2D Sprite { get; set; }
        //Whether or not this Entity returns a collision
        public bool Solid { get; set; } = false;
        //The Entity's location on the X axis
        public float X
        {
            get
            {
                return _location.x;
            }
            set
            {
                _location.x = value;
            }
        }
        //The Entity's location on the Y axis
        public float Y
        {
            get
            {
                return _location.y;
            }
            set
            {
                _location.y = value;
            }
        }
        //The Scene the Entity is currently in
        public Scene CurrentScene { get; set; }

        //Creates an Entity with default values
        public Entity()
        {

        }

        //Creates an Entity with the specified icon and default values
        public Entity(char icon)
        {
            Icon = icon;
        }

        //Creates an Entity with the specified icon and image
        public Entity(char icon, string imageName) : this(icon)
        {
            Sprite = RL.LoadTexture(imageName);
        }

        //Call the Entity's OnStart event
        public void Start()
        {
            OnStart?.Invoke();
        }

        //Call the Entity's OnUpdate event
        public void Update()
        {
            OnUpdate?.Invoke();
        }

        //Call the Entity's OnDraw event
        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
