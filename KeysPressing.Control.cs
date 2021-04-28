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
    public partial class GameView
    {
        private void PressKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.CurrentAnimation = 3;
                    player.Move(0, -1);
                    UpdateCamera();
                    break;
                case Keys.A:
                    player.CurrentAnimation = 2;
                    player.Move(-1, 0);
                    UpdateCamera();
                    break;
                case Keys.S:
                    player.CurrentAnimation = 0;
                    player.Move(0, 1);
                    UpdateCamera();
                    break;
                case Keys.D:
                    player.CurrentAnimation = 1;
                    player.Move(1, 0);
                    UpdateCamera();
                    break;
            }
            
            player.IsPressedAnyKeys = true;
        }

        private void ReleaseKey(object sender, KeyEventArgs e)
        {
            player.CurrentAnimation = -1;
            player.IsPressedAnyKeys = false;
        }
    }
}