using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGreatAdventure
{
    public partial class Form1 : Form
    {
        private Player player;
        private Timer playerAnimation = new Timer();
        private Timer playerMovement = new Timer();

        private Point delta;
        private int partOfMap = 80;
        private const int width = 15;
        private const int height = 15;
        public Form1()
        {
            InitializeComponent();

            player = new Player(new Size(100, 100), 0, 0);
            
            playerAnimation.Tick += UpdateAnimation;
            playerMovement.Interval = 1;
            playerMovement.Tick += UpdateMovement;
            
            playerAnimation.Start();
            playerMovement.Start();

            delta = new Point(0, 0);
            
            KeyDown += PressKey;
            KeyUp += ReleaseKey;

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var gr = e.Graphics;

            CreateMap(gr);
            PlayAnimation(gr);
        }

        private void CreateMap(Graphics gr)
        {
            var width = 15;
            var height = 15;
            Image floorImg = new Bitmap(Image.FromFile(@"../../floor.png"), 80, 80);

            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    gr.DrawImage(floorImg, 
                        i*80 + delta.X, 
                        j*80 + delta.Y, 
                        new Rectangle(new Point(0, 0), new Size(80, 80)), 
                        GraphicsUnit.Pixel);
        }

        private void PressKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "W":
                    player.CurrentAnimation = 3;
                    break;
                case "A":
                    player.CurrentAnimation = 2;
                    break;
                case "S" :
                    player.CurrentAnimation = 0;
                    break;
                case "D":
                    player.CurrentAnimation = 1;
                    break;
            }

            player.IsPressedAnyKeys = true;
        }
        private void ReleaseKey(object sender, KeyEventArgs e)
        {
            player.IsPressedAnyKeys = false;
            player.CurrentAnimation = -1;
        }

        private void PlayAnimation(Graphics gr)
        {
            if (player.IsPressedAnyKeys)
                gr.DrawImage(player.Sprites, 
                    player.X + delta.X,
                    player.Y + delta.Y,
                    new Rectangle(new Point(460*player.CurrentFrame, 600* player.CurrentAnimation), new Size(460,590)),
                    GraphicsUnit.Pixel);
            else
                gr.DrawImage(player.Idle, 
                    player.X + delta.X, 
                    player.Y + delta.Y,
                    new Rectangle(new Point(0, 0), new Size(460,600)),
                    GraphicsUnit.Pixel);
        }

        private void UpdateMovement(object sender, EventArgs e)
        {
            switch (player.CurrentAnimation)
            {
                case 0:
                    player.Down();
                    if (player.Y > Height/2 && player.Y < partOfMap * height - Height/2)
                        delta.Y -= player.Speed;
                    break;
                case 1:
                    player.Right();
                    if (player.X > Width/2 && player.X < partOfMap * width - Width/2)
                        delta.X -= player.Speed;
                    break;
                case 2:
                    player.Left();
                    if (player.X > Width/2 && player.X < partOfMap * width - Width/2)
                        delta.X += player.Speed;
                    break;
                case 3:
                    player.Up();
                    if (player.Y > Height/2 && player.Y < partOfMap * height - Height/2)
                        delta.Y += player.Speed;
                    break;
            }
        }

        private void UpdateAnimation(object sender, EventArgs e)
        {
            playerAnimation.Interval = 100;
            if (player.CurrentFrame == 3) 
                player.CurrentFrame = 0;

            player.CurrentFrame++;
            Invalidate();
        }
    }
    
}