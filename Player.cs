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
        public Image Sprites = new Bitmap(@"D:\C#\TheGreatAdventure\TestSprites.png");
        public Image Idle = new Bitmap(@"D:\C#\TheGreatAdventure\Idle.png");
        public bool IsPressedAnyKeys;
        public int X, Y;
        public Size Scale;
        public int CurrentFrame;
        public int CurrentAnimation = -1;
        public int Speed;

        public Player(Size scale, int x, int y)
        {
            Scale = scale;
            X = x;
            Y = y;
            Speed = 5;
        }

        public void Left()
        {
            X -= Speed;
        }
        
        public void Right()
        {
            X += Speed;
        }

        public void Up()
        {
            Y -= Speed;
        }

        public void Down()
        {
            Y += Speed;
        }
    }
}