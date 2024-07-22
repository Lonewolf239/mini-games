using System;
using System.Drawing;
using System.Windows.Forms;
using IniReader;

namespace minigames._Sudoku
{
    public partial class SS_Settings : Form
    {
        public SS_Settings()
        {
            InitializeComponent();
        }

        private bool loaded = false;

        private void SS_Settings_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    if (text is Button)
                        text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                    else
                        text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                }
                int centerX = Owner.Left + (Owner.Width - Width) / 2;
                int centerY = Owner.Top + (Owner.Height - Height) / 2;
                Location = new Point(centerX, centerY);
            }
            Activate();
            if (!MainMenu.Language)
            {
                Text = "Settings";
                difficulty_text.Text = "Game difficulty:";
                disable_prefill.Text = "Automatic prefill";
                death_timer.Text = "Racing against time";
                accept_button.Text = "Accept";
                string[] difficulty_names = { "Hard", "Normally", "Easily" };
                difficulty_list.Items.Clear();
                difficulty_list.Items.AddRange(difficulty_names);
                difficulty_list.Left = difficulty_text.Width + 5;
                accept_button.Left = death_timer.Width + 8;
                Width = accept_button.Left + accept_button.Width + 16;
                difficulty_list.Width = Width - difficulty_list.Left - 16;
            }
            difficulty_list.SelectedIndex = 2 - Sudoku.difficulty;
            disable_prefill.Checked = Sudoku.prefill;
            death_timer.Checked = difficulty_list.Enabled = Sudoku.death_time;
            loaded = true;
        }

        private void Difficulty_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                Sudoku.difficulty = 2 - difficulty_list.SelectedIndex;
                INIReader.SetKey(MainMenu.iniFolder, "SudoSaga", "difficulty", Sudoku.difficulty);
            }
        }

        private void Disable_prefill_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                Sudoku.prefill = !Sudoku.prefill;
                INIReader.SetKey(MainMenu.iniFolder, "SudoSaga", "prefill", Sudoku.prefill);
            }
        }

        private void Death_timer_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                difficulty_list.Enabled = !difficulty_list.Enabled;
                Sudoku.death_time = !Sudoku.death_time;
                INIReader.SetKey(MainMenu.iniFolder, "SudoSaga", "death_time", Sudoku.death_time);
            }
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}