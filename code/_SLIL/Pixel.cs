using System.Drawing;

namespace minigames._SLIL
{
    public class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Blackout { get; set; }
        public double Distance { get; set; }
        public double WallHeight { get; set; }
        public int TextureId { get; set; }
        public Color COLOR { get; set; }
        public double TextureX { get; set; }
        public double TextureY { get; set; }
        public int Side {  get; set; }

        public Pixel(int x, int y, Color color, int blackout, double distance, double wallHeight, int textureId)
        {
            X = x;
            Y = y;
            Blackout = blackout;
            COLOR = DarkenColor(color, blackout);
            Distance = distance;
            WallHeight = wallHeight;
            TextureId = textureId;
        }

        private Color DarkenColor(Color color, float darkenPercentage)
        {
            float r = (float)color.R / 255;
            float g = (float)color.G / 255;
            float b = (float)color.B / 255;
            float darkenAmount = 1 - (darkenPercentage / 100);
            r *= darkenAmount;
            g *= darkenAmount;
            b *= darkenAmount;
            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }
    }
}