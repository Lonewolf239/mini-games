using System.Drawing;
using System.Drawing.Imaging;

namespace minigames._SLIL
{
    public class TextureCache
    {
        private readonly Image[] textures =
        { 
            Properties.Resources.wall,
            Properties.Resources.enemy_0,
            Properties.Resources.enemy_1, 
            Properties.Resources.enemy_2,
            Properties.Resources.door,
            Properties.Resources.teleport,
            Properties.Resources.floor,
            Properties.Resources.ceiling,
            Properties.Resources.enemy_01,
            Properties.Resources.enemy_02,
        };
        public int LastTexture { get; }
        private readonly Color[] COLORS =
        {
            //bound
            Color.FromArgb(80,80,80),
            //dark
            Color.Black
        };
        private readonly Color[,][,] textureColorCache;

        public TextureCache()
        {
            LastTexture = textures.Length;
            int textureCount = textures.Length + COLORS.Length;
            textureColorCache = new Color[textureCount, 101][,];
            for (int id = 0; id < textures.Length; id++)
            {
                Bitmap textureBitmap = new Bitmap(textures[id]);
                BitmapData bitmapData = textureBitmap.LockBits(new Rectangle(0, 0, textureBitmap.Width, textureBitmap.Height), ImageLockMode.ReadOnly, textureBitmap.PixelFormat);
                int bytesPerPixel = Bitmap.GetPixelFormatSize(textureBitmap.PixelFormat) / 8;
                int byteCount = bitmapData.Stride * textureBitmap.Height;
                byte[] pixels = new byte[byteCount];
                System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, pixels, 0, byteCount);
                textureBitmap.UnlockBits(bitmapData);
                for (int blackout = 0; blackout <= 100; blackout++)
                {
                    float darkenAmount = 1 - (blackout / 100f);
                    if (blackout == 100)
                        textureColorCache[id, blackout] = GenerateBlackTexture(textureBitmap.Width, textureBitmap.Height);
                    else
                        textureColorCache[id, blackout] = CacheTextureColors(pixels, bitmapData.Stride, textureBitmap.Width, textureBitmap.Height, bytesPerPixel, darkenAmount);
                }
            }
            for (int id = textures.Length; id < textureCount; id++)
            {
                Color color = COLORS[id - textures.Length];
                for (int blackout = 0; blackout <= 100; blackout++)
                {
                    if (blackout == 100)
                        textureColorCache[id, blackout] = GenerateBlackTexture(1, 1);
                    else
                        textureColorCache[id, blackout] = CacheColor(color, blackout);
                }
            }
        }

        public Color GetTextureColor(int textureId, int x, int y, int blackout) {
            if (textureId == 1488) return Color.Black;
            return textureColorCache[textureId, blackout][x, y];
        }

        private Color[,] GenerateBlackTexture(int width, int height)
        {
            Color[,] blackTexture = new Color[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    blackTexture[x, y] = Color.Black;
            }
            return blackTexture;
        }

        private Color[,] CacheTextureColors(byte[] pixels, int stride, int width, int height, int bytesPerPixel, float darkenAmount)
        {
            Color[,] colors = new Color[width, height];
            for (int y = 0; y < height; y++)
            {
                int rowOffset = y * stride;
                for (int x = 0; x < width; x++)
                {
                    int offset = rowOffset + x * bytesPerPixel;
                    byte[] bytes = new byte[4];
                    bytes[0] = pixels[offset];
                    bytes[1] = pixels[offset + 1];
                    bytes[2] = pixels[offset + 2];
                    if (bytesPerPixel == 4)
                        bytes[3] = pixels[offset + 3];
                    Color originalColor = Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
                    colors[x, y] = DarkenColor(originalColor, darkenAmount);
                }
            }
            return colors;
        }

        private Color[,] CacheColor(Color color, int blackout)
        {
            float darkenAmount = 1 - (blackout / 100f);
            return new Color[,] { { DarkenColor(color, darkenAmount) } };
        }

        private Color DarkenColor(Color color, float darkenAmount) => Color.FromArgb((int)(color.R * darkenAmount), (int)(color.G * darkenAmount), (int)(color.B * darkenAmount));
    }
}