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
        private static Timer changeFrame;
        private static Timer zombieStepInterval;

        private void StartAnimations()
        {
            changeFrame = new Timer();
            zombieStepInterval = new Timer();
            
            changeFrame.Tick += UpdateFrame;
            zombieStepInterval.Tick += UpdateMove;

            changeFrame.Start();
            zombieStepInterval.Start();
        }

        private void UpdateFrame(object sender, EventArgs e)
        {
            changeFrame.Interval = 100;
            if (player.CurrentFrame == 3)
                player.CurrentFrame = 0;

            player.CurrentFrame++;
            Invalidate();
        }

        private void UpdateMove(object sender, EventArgs e)
        {
            zombieStepInterval.Interval = 2000;
            
            Invalidate();
        }
        
    }
}