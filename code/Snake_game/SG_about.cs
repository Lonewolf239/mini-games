using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigames.Snake_game
{
    public partial class SG_about : Form
    {
        public SG_about()
        {
            InitializeComponent();
        }

        private void SG_about_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    foreach (Control text1 in text.Controls)
                        text1.Font = new Font(text1.Font.FontFamily, text1.Font.Size * MainMenu.scale_size);
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                }
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            if (!MainMenu.Language)
            {
                Text = "Rules of the game";
                control_text.Text = "Controls:";
                control_space.Text = "To stop the game press: SPACE";
                fruit_name_text.Text = "Types of fruits:";
                red_fruit_text.Text = "regular fruit, adds 1 point when eaten";
                super_fruit_text.Text = "super fruit, adds 10 points when eaten";
                super_puper_fruit_text.Text = "distorted fruit, when consumed, brings 2 points and allows you to teleport to the mouse cursor";
                cut_fruit_text.Text = "poisonous fruit, when consumed, takes away 3 points and reduces the snake's tail by 5";
            }
            ok.Left = (Width - ok.Width) / 2;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
