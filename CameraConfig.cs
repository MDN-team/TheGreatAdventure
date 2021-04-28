using System.Drawing;
using System.Windows.Forms;

namespace TheGreatAdventure
{
    public partial class GameView
    {
        private Point offset;

        private void UpdateCamera()
        {
            if (player.Y > Height/2 &&
                player.Y < map.Height * map.CellSize.Height - Height/2 &&
                player.ViewDirection.Y == 1)
                offset.Y -= player.Speed;
            if (player.Y > Height/2 &&
                player.Y < map.Height * map.CellSize.Height - Height/2 &&
                player.ViewDirection.Y == -1)
                offset.Y += player.Speed;
            if (player.X > Width/2 && 
                player.X < map.Width * map.CellSize.Width - Width/2 &&
                player.ViewDirection.X == 1)
                offset.X -= player.Speed;
            if (player.X > Width/2 && 
                player.X < map.Width * map.CellSize.Width - Width/2 &&
                player.ViewDirection.X == -1)
                offset.X += player.Speed;
        }
    }
}