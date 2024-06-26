using System.Drawing;

namespace minigames._SLIL
{
    public class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color COLOR { get; set; }

        public Pixel(int x, int y, Color color)
        {
            X = x;
            Y = y;
            COLOR = color;
        }
    }
}