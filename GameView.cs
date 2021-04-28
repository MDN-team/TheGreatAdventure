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
    public partial class GameView : Form
    {
        private static Player player;
        private static Map map;
        public GameView()
        {
            InitializeComponent();
            
            map = new Map(15, 15, new Size(80, 80));

            player = new Player(new Size(100, 100), 0, 0, map);
            StartPlayerAnimation();

            KeyDown += PressKey;
            KeyUp += ReleaseKey;
            

            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var gr = e.Graphics;
            map.CreateMap(gr, offset);
            PlayAnimation(gr);
        }

       
        private void PlayAnimation(Graphics gr)
        {
            if (player.IsPressedAnyKeys)
                gr.DrawImage(player.Sprites, 
                    player.X + offset.X,
                    player.Y + offset.Y,
                    new Rectangle(new Point(460*player.CurrentFrame, 600* player.CurrentAnimation), new Size(460,590)),
                    GraphicsUnit.Pixel);
            else
                gr.DrawImage(player.Idle, 
                    player.X + offset.X, 
                    player.Y + offset.Y,
                    new Rectangle(new Point(0, 0), new Size(460,600)),
                    GraphicsUnit.Pixel);
        }
    }
}