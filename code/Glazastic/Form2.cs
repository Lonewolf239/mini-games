using System;
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
        }

        private void Midle_CheckedChanged(object sender, EventArgs e)
        {
            dificult_choice = 10;
        }

        private void Hard_CheckedChanged(object sender, EventArgs e)
        {
            dificult_choice = 5;
        }

        private void speed_CheckedChanged(object sender, EventArgs e)
        {
            big_speed = !big_speed;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Activate();
            if (Form1.widht_panels == 20)
                ez.Checked = true;
            else if (Form1.widht_panels == 5)
                hard.Checked = true;
            big_speed = speed.Checked = Form1.big_speed;
            if (Form1.unposible_mod)
            {
                unposible_mode = unposible.Checked = true;
                speed.Enabled = hard.Enabled = midle.Enabled = ez.Enabled = false;
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
            if (practic_mod)
                unposible.Checked = unposible.Enabled = false;
            else
                unposible.Enabled = true;
        }

        private void Unposible_CheckedChanged(object sender, EventArgs e)
        {
            unposible_mode = !unposible_mode;
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
