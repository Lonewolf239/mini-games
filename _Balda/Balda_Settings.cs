using System;
using System.Windows.Forms;

namespace minigames._Balda
{
    public partial class Balda_Settings : Form
    {
        public Balda_Settings()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) => Close();

        private void Balda_Settings_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
            {
                Text = "Settings";
                label1.Text = "Difficulty:";
                comboBox1.Items.Clear();
                string[] dif = { "Easy", "Normal", "Hard" };
                comboBox1.Items.AddRange(dif);
            }
            comboBox1.SelectedIndex = Balda.Difficulty;
        }

        private void Balda_Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
                Close();
        }

        private void Balda_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Balda.Difficulty = comboBox1.SelectedIndex;
        }
    }
}