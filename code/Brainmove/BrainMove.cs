using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace minigames.Brainmove
{
    public partial class BrainMove : Form
    {
        public BrainMove()
        {
            InitializeComponent();
        }

        public int tile_count = 14;
        private int tiles_size = 10, i = 1;
        private Control[][] tiles =
        {
            new Control[24],
            new Control[24],
            new Control[24],
            new Control[24]
        };
        private int[][] tiles_value =
{
            new int[44],
            new int[44],
            new int[44],
            new int[44]
        };

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void BrainMove_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void BrainMove_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                developer_name.Left = Width - (developer_name.Width + 12);
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            if (!MainMenu.Language)
            {
                Text = "Brainmove";
                start_btn.Text = "START";
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            //Spawn_Tiles();
        }

        private void question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
        }

        private void Spawn_Tiles()
        {
            tiles = null;
            tiles = new Control[][]
            {
                new Control[24],
                new Control[24],
                new Control[24],
                new Control[24]
            };
        }
    }
}