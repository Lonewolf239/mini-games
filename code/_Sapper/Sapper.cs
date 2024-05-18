using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigames._Sapper
{
    public partial class Sapper : Form
    {
        public Sapper()
        {
            InitializeComponent();
        }

        private Panel[][] panels;
        public static int height = 8, width = 8, size = 45, bombs_count = 0;
        //8x8 size - 45 bombs = ~20%
        //12x12 size = 30 bombs = 22
        //18x18 size = 20 bombs = 49
        //24x24 size = 15 bombs = 86

        private void Sapper_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                Screen screen = Screen.FromPoint(Cursor.Position);
                developer_name.Left = Width - (developer_name.Width + 12);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            if (!MainMenu.Language)
            {
                Text = "Sapper";
                start_btn.Text = "START";
            }
            Activate();
            GenerateField();
        }

        private void GenerateField()
        {
            panels = null;
            panels = new Panel[height][];
            for (int i = 0; i < height; i++)
            {
                panels[i] = new Panel[width];
                for (int j = 0; j < panels[i].Length; j++)
                {
                    panels[i][j] = new Panel
                    {
                        BackColor = Color.Gray,
                        BorderStyle = BorderStyle.FixedSingle,
                        Width = (int)(size * MainMenu.scale_size),
                        Height = (int)(size * MainMenu.scale_size),
                        Top = (int)(size * MainMenu.scale_size) * i,
                        Left = (int)(size * MainMenu.scale_size) * j
                    };
                    top_panel.Controls.Add(panels[i][j]);
                }
            }
        }
    }
}