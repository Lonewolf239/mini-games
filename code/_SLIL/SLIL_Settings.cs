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
                show_fps.Text = "Show FPS";
                difficulty_text.Text = "Difficulty";
                scope_type_text.Text = "Scope";
                scope_color_text.Text = "Scope color";
                height_map_text.Text = "Height";
                width_map_text.Text = "Width";
                scope_color_list.Items.Clear();
                scope_type_list.Items.Clear();
                difficulty_list.Items.Clear();
                string[] dif = { "Very hard", "Hard", "Normal", "Easy", "Custom" };
                string[] col = { "Green", "Red", "Yellow", "Blue", "Magenta", "Cyan", "Orange", "White", "Random" };
                string[] typ = { "Standard", "Cross", "Line", "Dot", "Without sight" };
                difficulty_list.Items.AddRange(dif);
                scope_color_list.Items.AddRange(col);
                scope_type_list.Items.AddRange(typ);
                look_speed.Left = look_speed_text.Right + 6;
                difficulty_list.Left = difficulty_text.Right + 6;
                scope_color_list.Left = scope_color_text.Right + 6;
                scope_type_list.Left = difficulty_list.Left;
                editor_btn.Left = height_map_input.Right + 6;
                while (scope_color_list.Right > difficulty_list.Right)
                    scope_color_list.Width--;
            }
            Width = look_speed.Right + 36;
            Height = look_speed.Bottom + 36;
            int centerX = Owner.Left + (Owner.Width - Width) / 2;
            int centerY = Owner.Top + (Owner.Height - Height) / 2;
            Location = new Point(centerX, centerY);
            look_speed.Value = (int)(SLIL.LOOK_SPEED * 100);
            difficulty_list.SelectedIndex = SLIL.old_difficulty;
            scope_color_list.SelectedIndex = SLIL.scope_color;
            scope_type_list.SelectedIndex = SLIL.scope_type;
            height_map_input.Value = SLIL.CustomMazeHeight;
            width_map_input.Value = SLIL.CustomMazeWidth;
            show_fps.Checked = SLIL.ShowFPS;
            resolution.Checked = SLIL.resolution == 1;
            SLIL.CUSTOM = false;
            if (height_map_input.Value > 20 || width_map_input.Value > 20)
                editor_btn.Enabled = false;
            else
                editor_btn.Enabled = true;
        }

        private void SLIL_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form != null)
            {
                form.Close();
                form = null;
            }
            bool showfps = show_fps.Checked;
            double speed = (double)look_speed.Value / 100;
            int index = difficulty_list.SelectedIndex;
            int scope_color = scope_color_list.SelectedIndex;
            int scope_type = scope_type_list.SelectedIndex;
            int CustomMazeHeight = (int)height_map_input.Value;
            int CustomMazeWidth = (int)width_map_input.Value;
            bool hight_resolution = resolution.Checked;
            SLIL.LOOK_SPEED = speed;
            SLIL.old_difficulty = SLIL.difficulty = index;
            SLIL.scope_color = scope_color;
            SLIL.scope_type = scope_type;
            SLIL.CustomMazeHeight = CustomMazeHeight;
            SLIL.CustomMazeWidth = CustomMazeWidth;
            SLIL.ShowFPS = showfps;
            SLIL.resolution = hight_resolution ? 1 : 0;
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "look_speed", speed);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "show_fps", showfps);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "difficulty", index);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "hight_resolution", hight_resolution);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "scope_color", scope_color);
            INIReader.SetKey(MainMenu.iniFolder, "SLIL", "scope_type", scope_type);
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
            look_speed_text.Focus();
            if (difficulty_list.SelectedIndex == 4)
                Height = width_map_input.Bottom + 44;
            else
                Height = look_speed.Bottom + 36;
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            look_speed_text.Focus();
            look_speed.Value = 175;
        }

        private void Editor_btn_Click(object sender, EventArgs e)
        {
            look_speed_text.Focus();
            SLIL_Editor form = new SLIL_Editor
            {
                Owner = this
            };
            SLIL_Editor.MazeHeight = (int)height_map_input.Value * 3 + 1;
            SLIL_Editor.MazeWidth = (int)width_map_input.Value * 3 + 1;
            form.FormClosing += Form_FormClosing;
            form.ShowDialog();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            height_map_input.Value = (SLIL_Editor.MazeHeight - 1) / 3;
            width_map_input.Value = (SLIL_Editor.MazeWidth - 1) / 3;
            SLIL.CUSTOM_X = SLIL_Editor.x;
            SLIL.CUSTOM_Y = SLIL_Editor.y;
            Close();
        }

        private void Map_input_ValueChanged(object sender, EventArgs e)
        {
            if (height_map_input.Value > 20 || width_map_input.Value > 20)
                editor_btn.Enabled = false;
            else
                editor_btn.Enabled = true;
        }

        private void Editor_btn_EnabledChanged(object sender, EventArgs e)
        {
            if (editor_btn.Enabled)
                editor_btn.BackColor = SystemColors.Control;
            else
                editor_btn.BackColor = Color.LightGray;
        }

        private void Quality_list_SelectedIndexChanged(object sender, EventArgs e) => look_speed_text.Focus();
    }
}