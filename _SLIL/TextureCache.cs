﻿using System.Drawing;
using System.Drawing.Imaging;

namespace minigames._SLIL
{
    public class TextureCache
    {
        private readonly Image[] textures =
        { 
            Properties.Resources.wall,
            Properties.Resources.door,
            Properties.Resources.shop_door,
            Properties.Resources.teleport,
            Properties.Resources.floor,
            Properties.Resources.ceiling,
            Properties.Resources.enemy_0, //8
            Properties.Resources.enemy_0_1,
            Properties.Resources.enemy_0_2,
            Properties.Resources.enemy_0_DEAD,
            Properties.Resources.enemy_1, //12
            Properties.Resources.enemy_1_1,
            Properties.Resources.enemy_1_2,
            Properties.Resources.enemy_1_DEAD,
            Properties.Resources.enemy_2, //16
            Properties.Resources.enemy_2_1,
            Properties.Resources.enemy_2_2,
            Properties.Resources.enemy_2_DEAD,
            Properties.Resources.pet_cat_0, //20
            Properties.Resources.pet_cat_1,
            Properties.Resources.pet_cat_3,
            Properties.Resources.pet_cat_2,
            Properties.Resources.shop_man_0, //24
            Properties.Resources.shop_man_0,
            Properties.Resources.shop_man_1,
            Properties.Resources.pet_gnome_0, //27
            Properties.Resources.pet_gnome_1,
            Properties.Resources.pet_gnome_2,
            Properties.Resources.pet_energy_drink_0, //30
        };
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
            int textureCount = textures.Length + COLORS.Length;
            textureColorCache = new Color[textureCount, 101][,];
            for (int id = 0; id < COLORS.Length; id++)
            {
                Color color = COLORS[id];
                for (int blackout = 0; blackout <= 100; blackout++)
                {
                    if (blackout == 100)
                        textureColorCache[id, blackout] = GenerateBlackTexture(1, 1);
                    else
                        textureColorCache[id, blackout] = CacheColor(color, blackout);
                }
            }
            for (int id = COLORS.Length; id < textureCount; id++)
            {
                Bitmap textureBitmap = new Bitmap(textures[id - COLORS.Length]);
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
        }

        public Color GetTextureColor(int textureId, int x, int y, int blackout) => textureColorCache[textureId, blackout][x, y];

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
                    if (bytes[3] == 0)
                        colors[x, y] = Color.Transparent;
                    else
                    {
                        Color originalColor = Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
                        colors[x, y] = DarkenColor(originalColor, darkenAmount);
                    }
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