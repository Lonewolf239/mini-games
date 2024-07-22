﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames.Snake_game
{
    public partial class SG_settings : Form
    {
        public SG_settings()
        {
            InitializeComponent();
        }

        private bool setuped = false;
        public static bool accepted = false;

        private void Size_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setuped)
            {
                size_text.Focus();
                if (size_list.SelectedIndex == 0)
                {
                    SnakeGame.new_px_x = 40;
                    SnakeGame.new_px_y = 20;
                    SnakeGame.new_tile_size = 10;
                }
                else if (size_list.SelectedIndex == 1)
                {
                    SnakeGame.new_px_x = 16;
                    SnakeGame.new_px_y = 8;
                    SnakeGame.new_tile_size = 25;
                }
                else
                {
                    SnakeGame.new_px_x = 8;
                    SnakeGame.new_px_y = 4;
                    SnakeGame.new_tile_size = 50;
                }
            }
        }

        private void Speed_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setuped)
            {
                speed_text.Focus();
                if (speed_list.SelectedIndex == 0)
                    SnakeGame.new_logic_interval = 250;
                else if (speed_list.SelectedIndex == 1)
                    SnakeGame.new_logic_interval = 300;
                else if (speed_list.SelectedIndex == 2)
                    SnakeGame.new_logic_interval = 350;
                else
                    SnakeGame.new_logic_interval = 400;
            }
        }

        private void Walls_killing_CheckedChanged(object sender, EventArgs e)
        {
            if (setuped)
                SnakeGame.new_wall_killing = walls_killing.Checked;
        }

        private void Style_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setuped)
                SnakeGame.new_px_style = style_list.SelectedIndex;
        }

        private void Dark_theme_CheckedChanged(object sender, EventArgs e)
        {
            if (setuped)
            {
                if (dark_theme.Checked)
                    SnakeGame.new_dark_theme = 1;
                else
                    SnakeGame.new_dark_theme = 0;
            }
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            accepted = true;
            Close();
        }

        private void SG_settings_Load(object sender, EventArgs e)
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
                accept_button.Text = "Accept";
                size_text.Text = "Field size:";
                speed_text.Text = "Speed:";
                walls_killing.Text = "Walls kill";
                style_text.Text = "Style:";
                dark_theme.Text = "Dark theme";
                style_list.Items.Clear();
                string[] en_border_items = { "Classic", "Borders", "3D-Borders" };
                style_list.Items.AddRange(en_border_items);
                size_list.Left -= 40;
                speed_list.Left -= 40;
                style_list.Left -= 40;
                accept_button.Left -= 48;
                ClientSize = new Size(256, 177);
            }
            accepted = false;
            if (SnakeGame.new_px_x == 40 && SnakeGame.new_px_y == 20)
                size_list.SelectedIndex = 0;
            else if (SnakeGame.new_px_x == 16 && SnakeGame.new_px_y == 8)
                size_list.SelectedIndex = 1;
            else
                size_list.SelectedIndex = 2;
            if (SnakeGame.new_logic_interval == 250)
                speed_list.SelectedIndex = 0;
            else if (SnakeGame.new_logic_interval == 300)
                speed_list.SelectedIndex = 1;
            else if (SnakeGame.new_logic_interval == 350)
                speed_list.SelectedIndex = 2;
            else
                speed_list.SelectedIndex = 3;
            if (SnakeGame.new_dark_theme == 1)
                dark_theme.Checked = true;
            style_list.SelectedIndex = SnakeGame.new_px_style;
            walls_killing.Checked = SnakeGame.new_wall_killing;
            setuped = true;
        }
    }
}