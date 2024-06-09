using IniReader;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._SLIL
{
    public partial class SLIL_Settings : Form
    {
        public SLIL_Settings()
        {
            InitializeComponent();
        }

        private look_speed_percent form;

        private void Look_speed_Enter(object sender, EventArgs e) => look_speed_text.Focus();

        private void SLIL_Settings_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
            {
                Text = "Settings";
                look_speed_text.Text = "Sensitivity";
                difficulty_text.Text = "Difficulty";
                show_finish.Text = "Show finish";
                reset_btn.Text = "Reset";
                difficulty_list.Items.Clear();
                string[] dif = { "Very hard", "Hard", "Normal", "Easy", "Custom" };
                difficulty_list.Items.AddRange(dif);
            }
            look_speed.Left = look_speed_text.Right + 6;
            difficulty_list.Left = look_speed.Left - 22;
            reset_btn.Left = difficulty_list.Right - reset_btn.Width;
            Width = look_speed.Right + 36;
            Height = show_finish.Bottom + 48;
            int centerX = Owner.Left + (Owner.Width - Width) / 2;
            int centerY = Owner.Top + (Owner.Height - Height) / 2;
            Location = new Point(centerX, centerY);
            look_speed.Value = (int)(SLIL.LOOK_SPEED * 100);
            difficulty_list.SelectedIndex = SLIL.old_difficulty;
            show_finish.Checked = SLIL.SHOW_FINISH;
            height_map_input.Value = SLIL.CustomMazeHeight;
            width_map_input.Value = SLIL.CustomMazeWidth;
        }

        private void SLIL_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form != null)
            {
                form.Close();
                form = null;
            }
            double speed = (double)look_speed.Value / 100;
            int index = difficulty_list.SelectedIndex;
            int CustomMazeHeight = (int)height_map_input.Value;
            int CustomMazeWidth = (int)width_map_input.Value;
            bool _show_finish = show_finish.Checked;
            SLIL.LOOK_SPEED = speed;
            SLIL.old_difficulty = SLIL.difficulty = index;
            SLIL.SHOW_FINISH = _show_finish;
            SLIL.CustomMazeHeight = CustomMazeHeight;
            SLIL.CustomMazeWidth = CustomMazeWidth;
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "look_speed", speed);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "difficulty", index);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "show_finish", _show_finish);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "custom_maze_height", CustomMazeHeight);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "custom_maze_width", CustomMazeWidth);
        }

        private void Look_speed_Scroll(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new look_speed_percent();
                form.Left = Cursor.Position.X - (form.Width / 2);
                form.Top = look_speed.PointToScreen(Point.Empty).Y - form.Height;
                form.Show();
            }
            form.BringToFront();
            form.Left = Cursor.Position.X - (form.Width / 2);
            form.Top = look_speed.PointToScreen(Point.Empty).Y - form.Height;
            form.text.Text = $"{(double)look_speed.Value / 100}";
            form.Size = form.text.Size;
        }

        private void Look_speed_MouseUp(object sender, MouseEventArgs e)
        {
            if (form != null)
            {
                form.Close();
                form = null;
                Activate();
            }
        }

        private void SLIL_Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                Close();
        }

        private void Difficulty_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (difficulty_list.SelectedIndex == 0 || difficulty_list.SelectedIndex == 1)
                show_finish.Enabled = show_finish.Checked = false;
            else 
                show_finish.Enabled = true;
            if (difficulty_list.SelectedIndex == 4)
                Height = width_map_input.Bottom + 48;
            else
                Height = show_finish.Bottom + 48;
        }

        private void Reset_btn_Click(object sender, EventArgs e) => look_speed.Value = 175;
    }
}