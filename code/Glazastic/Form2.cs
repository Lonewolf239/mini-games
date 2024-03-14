using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lazastic
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static int dificult_choice = 10;
        public static bool big_speed = false, unposible_mode = false;

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
            if (Form1.widht_panels == 20)
                ez.Checked = true;
            else if (Form1.widht_panels == 5)
                hard.Checked = true;
            speed.Checked = Form1.big_speed;
            if (Form1.unposible_mod)
            {
                unposible_mode = unposible.Checked = true;
                speed.Enabled = hard.Enabled = midle.Enabled = ez.Enabled = false;
            }
        }

        private void Unposible_CheckedChanged(object sender, EventArgs e)
        {
            unposible_mode = !unposible_mode;
            if (unposible_mode)
            {
                speed.Enabled = hard.Enabled = midle.Enabled = ez.Enabled = false;
                dificult_choice = 2;
            }
            else
            {
                speed.Enabled = hard.Enabled = midle.Enabled = ez.Enabled = true;
                dificult_choice = 10;
            }
        }
    }
}
