using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace minigames._SLIL
{
    public partial class map_form : Form
    {

        public StringBuilder _MAP = new StringBuilder();
        public int _MazeHeight, _MazeWidth;
        private int MAP_HEIGHT;
        private int MAP_WIDTH;
        private Bitmap screen;

        public map_form()
        {
            InitializeComponent();
        }

        private void Map_form_Load(object sender, EventArgs e)
        {
            MAP_HEIGHT = _MazeHeight * 3 + 1;
            MAP_WIDTH = _MazeWidth * 3 + 1;
            screen = new Bitmap(MAP_WIDTH, MAP_HEIGHT);
            map_refresh.Start();
        }

        private void Map_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            map_refresh.Stop();
        }

        private void Map_refresh_Tick(object sender, EventArgs e)
        {
            for (int y = 0; y < MAP_HEIGHT; y++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    char mapChar = _MAP[y * MAP_WIDTH + x];
                    if (mapChar == '#')
                        screen.SetPixel(x, y, Color.Blue);
                    else if (mapChar == '=')
                        screen.SetPixel(x, y, Color.YellowGreen);
                    else if (mapChar == 'D' || mapChar == 'O')
                        screen.SetPixel(x, y, Color.FromArgb(255, 165, 0));
                    else if (mapChar == 'F')
                        screen.SetPixel(x, y, Color.Lime);
                    else if (mapChar == 'P')
                        screen.SetPixel(x, y, Color.Red);
                    else if (mapChar == '*')
                        screen.SetPixel(x, y, Color.FromArgb(255, 128, 128));
                    else
                        screen.SetPixel(x, y, Color.Black);
                }
            }
            map_picturebox.Image = screen;
        }
    }
}