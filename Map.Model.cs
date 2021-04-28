
using System.Drawing;

namespace TheGreatAdventure
{
    public class Map
    {
        public readonly Size CellSize;
        public readonly int Width;
        public readonly int Height;

        public Map(int width, int height, Size cellSize)
        {
            Height = height;
            Width = width;
            CellSize = cellSize;
        }
        public void CreateMap(Graphics gr, Point offset)
        {
            Image floorImg = new Bitmap(Image.FromFile(@"../../floor.png"), 80, 80);

            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                gr.DrawImage(floorImg, 
                    i*80 + offset.X, 
                    j*80 + offset.Y, 
                    new Rectangle(new Point(0, 0), new Size(80, 80)), 
                    GraphicsUnit.Pixel);
        }

        public bool IsOnMap(int x, int y)
        {
            return x >= 0 && x <= (Width - 1) * CellSize.Width &&
                   y >= 0 && y <= Height * CellSize.Height - 100;
        }
    }
    
}