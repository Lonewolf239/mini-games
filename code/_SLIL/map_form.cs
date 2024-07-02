using Convert_Bitmap;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace minigames._SLIL
{
    public partial class Map_form : Form
    {

        public StringBuilder _MAP = new StringBuilder();
        public int _MazeHeight, _MazeWidth;
        private int MAP_HEIGHT;
        private int MAP_WIDTH;
        private Bitmap screen;

        public Map_form()
        {
            InitializeComponent();
        }

        private void Map_form_Load(object sender, EventArgs e)
        {
            MAP_HEIGHT = _MazeHeight * 3 + 1;
            MAP_WIDTH = _MazeWidth * 3 + 1;
            screen = new Bitmap(MAP_WIDTH, MAP_HEIGHT);
            map_display.ResizeImage(MAP_WIDTH, MAP_HEIGHT);
            map_refresh.Start();
        }

        private void Map_form_FormClosing(object sender, FormClosingEventArgs e) => map_refresh.Stop();

        private void Map_refresh_Tick(object sender, EventArgs e)
        {
            BitmapData data = screen.LockBits(new Rectangle(0, 0, screen.Width, screen.Height), ImageLockMode.WriteOnly, screen.PixelFormat);
            int bytesPerPixel = Bitmap.GetPixelFormatSize(screen.PixelFormat) / 8;
            byte[] pixels = new byte[data.Height * data.Stride];
            Color color;
            for (int y = 0; y < MAP_HEIGHT; y++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    int i = (y * data.Stride) + (x * bytesPerPixel);
                    char mapChar = _MAP[y * MAP_WIDTH + x];
                    if (mapChar == '#')
                        color = Color.Blue;
                    else if (mapChar == '=')
                        color = Color.YellowGreen;
                    else if (mapChar == 'D' || mapChar == 'O')
                        color = Color.FromArgb(255, 165, 0);
                    else if (mapChar == 'F')
                        color = Color.Lime;
                    else if (mapChar == 'P')
                        color = Color.Red;
                    else if (mapChar == '*')
                        color = Color.FromArgb(255, 128, 128);
                    else if (mapChar == 'E')
                        color = Color.Cyan;
                    else
                        color = Color.Black;
                    pixels[i] = color.B;
                    pixels[i + 1] = color.G;
                    pixels[i + 2] = color.R;
                    if (bytesPerPixel == 4)
                        pixels[i + 3] = color.A;
                }
            }
            Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            screen.UnlockBits(data);
            map_display.SCREEN = ConvertBitmap.ToDX(screen, map_display.renderTarget);
            map_display.DrawImage();
        }
    }
}