using System.Collections.Generic;
using System.Drawing;

namespace minigames._SLIL
{
    public class TextureCache
    {
        private readonly Image[] textures = { Properties.Resources.wall };
        private readonly Dictionary<int, Color[,]> textureColorCache;

        public TextureCache()
        {
            textureColorCache = new Dictionary<int, Color[,]>();
        }

        public Color GetTextureColor(int textureId, int x, int y, int blackout)
        {
            if (!textureColorCache.ContainsKey(textureId))
            {
                Bitmap textureBitmap = LoadTextureBitmap(textureId);
                Color[,] colors = CacheTextureColors(textureBitmap);
                textureColorCache.Add(textureId, colors);
            }
            return DarkenColor(textureColorCache[textureId][x, y], blackout);
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

        private Bitmap LoadTextureBitmap(int textureId) => new Bitmap(textures[textureId]);

        private Color[,] CacheTextureColors(Bitmap textureBitmap)
        {
            int width = textureBitmap.Width;
            int height = textureBitmap.Height;
            Color[,] colors = new Color[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    colors[x, y] = textureBitmap.GetPixel(x, y);
            }
            return colors;
        }
    }
}