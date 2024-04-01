using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static int dificult_choice = 10;
        public static bool big_speed = false, unposible_mode = false, practic_mod = false;

        private void Ez_CheckedChanged(object sender, EventArgs e)
        {
            dificult_choice = 20;
            INIReader.SetKey("config.ini", "Glazastic", "difficulty", "0");
        }

        private void Midle_CheckedChanged(object sender, EventArgs e)
        {
            dificult_choice = 10;
            INIReader.SetKey("config.ini", "Glazastic", "difficulty", "1");
        }

        private void Hard_CheckedChanged(object sender, EventArgs e)
        {
            dificult_choice = 5;
            INIReader.SetKey("config.ini", "Glazastic", "difficulty", "2");
        }

        private void speed_CheckedChanged(object sender, EventArgs e)
        {
            big_speed = !big_speed;
            INIReader.SetKey("config.ini", "Glazastic", "big_speed", Convert.ToString(big_speed));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in dificult_panel.Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                foreach (Control text in settings_panel.Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            if (Form1.widht_panels == 20)
                ez.Checked = true;
            else if (Form1.widht_panels == 5)
                hard.Checked = true;
            big_speed = speed.Checked = Form1.big_speed;
            if (Form1.unposible_mod)
            {
                unposible_mode = unposible.Checked = true;
                practic_mode.Enabled = speed.Enabled = hard.Enabled = midle.Enabled = ez.Enabled = false;
                dificult_choice = 2;
            }
            practic_mod = practic_mode.Checked = Form1.practic_mod;
            if (practic_mod)
                unposible.Enabled = false;
            if (!MainMenu.Language)
            {
                Text = "Difficulty settings";
                ez.Text = "Easily";
                midle.Text = "Average";
                hard.Text = "Hard";
                speed.Text = "High speed";
                practic_mode.Text = "Practice mode";
            }
        }

        private void practic_mode_CheckedChanged(object sender, EventArgs e)
        {
            practic_mod = !practic_mod;
            INIReader.SetKey("config.ini", "Glazastic", "practice_mode", Convert.ToString(practic_mod));
            if (practic_mod)
                unposible.Checked = unposible.Enabled = false;
            else
                unposible.Enabled = true;
        }

        private void Unposible_CheckedChanged(object sender, EventArgs e)
        {
            unposible_mode = !unposible_mode;
            INIReader.SetKey("config.ini", "Glazastic", "impossible", Convert.ToString(unposible_mode));
            if (unposible_mode)
            {
                practic_mode.Enabled = speed.Checked = speed.Enabled = hard.Enabled = midle.Enabled = ez.Enabled = false;
                dificult_choice = 2;
            }
            else
            {
                practic_mode.Enabled = speed.Enabled = hard.Enabled = midle.Enabled = ez.Enabled = true;
                dificult_choice = 10;
            }
        }
    }
}
