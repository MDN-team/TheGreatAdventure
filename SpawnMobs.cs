using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheGreatAdventure
{
    public partial class GameView
    {
        private List<Zombie> mobs = new List<Zombie>();
        private int mobsCount;
        public void SpawnMobs()
        {
            var rnd = new Random();
            if (mobsCount < 2)
            {
                for (var i = 0; i < mobsCount; i++)
                {
                    var spawnX = player.X + rnd.Next(200, 500);
                    var spawnY = player.Y + rnd.Next(200, 500);
                    mobs.Add(new Zombie(spawnX, spawnY));
                }
            }
        }
    }
}