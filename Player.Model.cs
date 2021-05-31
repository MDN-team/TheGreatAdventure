using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGreatAdventure
{
    public class Player
    {
        public Image Sprites = new Bitmap("../../TestSprites.png");
        public Image Idle = new Bitmap("./../../Idles/IdleDown.png");

        public Dictionary<string, Image> Idles = new Dictionary<string, Image>
        {
            ["Up"] = new Bitmap("./../../Idles/IdleUp.png"),
            ["Down"] = new Bitmap("./../../Idles/IdleDown.png"),
            ["Left"] = new Bitmap("./../../Idles/IdleLeft.png"),
            ["Right"] = new Bitmap("./../../Idles/IdleRight.png")
        };
        private Map map;

        public bool IsPressedAnyKeys;
        
        public int X, Y;
        public Point ViewDirection { get; private set; }
        public int Speed;

        public Size Scale;
        public int CurrentFrame;
        public int CurrentAnimation = -1;

        public Player(Size scale, int x, int y, Map map)
        {
            Scale = scale;
            X = x;
            Y = y;
            Speed = 5;
            this.map = map;
        }
        
        public void Move(int dirX, int dirY)
        {
            var newX = dirX * Speed;
            var newY = dirY * Speed;
            if (map.IsOnMap(X + newX, Y + newY))
            {
                X += newX;
                Y += newY; 
            }
            
            ViewDirection = new Point(dirX, dirY);
        }
    }
}