using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames.Snake_game
{
    public partial class SG_about : Form
    {
        public SG_about()
        {
            InitializeComponent();
        }

        private how_tp how_Tp;

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
                int centerX = Owner.Left + (Owner.Width - Width) / 2;
                int centerY = Owner.Top + (Owner.Height - Height) / 2;
                Location = new Point(centerX, centerY);
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


        private void Super_puper_fruit_panel_MouseEnter(object sender, EventArgs e)
        {
            if (how_Tp != null)
                return;
            how_Tp = new how_tp();
            how_Tp.Left = Cursor.Position.X - 50;
            how_Tp.Top = Cursor.Position.Y - how_Tp.Height - 20;
            how_Tp.Show();
        }

        private void Super_puper_fruit_panel_MouseLeave(object sender, EventArgs e)
        {
            if (how_Tp != null)
            {
                how_Tp.Close();
                how_Tp = null;
            }
        }
    }
}