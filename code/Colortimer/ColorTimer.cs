﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace minigames.Colortimer
{
    public partial class ColorTimer : Form
    {
        public ColorTimer()
        {
            InitializeComponent();
        }

        private static string[] colors = { "Чёрный", "Зелёный", "Жёлтый", "Красный", "Оранжевый", "Серый", "Фиолетовый", "Синий" };
        private static string[] colors1 = { "Black", "Green", "Gold", "Red", "DarkOrange", "Gray", "Purple", "Blue" };
        private readonly Color[] colorArray = Array.ConvertAll(colors1, Color.FromName);
        private readonly ContentAlignment[] content = new ContentAlignment[]
        {
            ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight,
            ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight,
            ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
        };
        private int current_color = 0, player_chose_color = 0, max_score = 0;
        public static int score = 0;
        private Random rand = new Random();
        private static float difficulty_level = 0;
        private readonly PlaySound game_over = new PlaySound(MainMenu.CGFReader.GetFile("game_over.wav"), false);

        private void Question_Click(object sender, EventArgs e)
        {
            color_text.Focus();
            if (MainMenu.Language)
                MessageBox.Show("У вас есть несколько кнопок разных цветов, и ваша задача состоит в том, чтобы в течение определенного времени нажимать кнопку нужного цвета. " +
                    "Если время истекает или вы нажимаете неправильную кнопку — вы проигрываете.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You have several buttons of different colors, and your task is to press the button of the required color within a certain time. " +
                    "If time runs out or if you press the wrong button, you will lose.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Black_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(0);
        }

        private void Green_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(1);
        }

        private void Yellow_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(2);
        }

        private void Red_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(3);
        }

        private void Orange_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(4);
        }

        private void Gray_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(5);
        }

        private void Purple_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(6);
        }

        private void Blue_btn_Click(object sender, EventArgs e)
        {
            Input_Logic(7);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int add = 1;
            if (MainMenu.scaled)
                add = (int)(add * MainMenu.scale_size);
            if (difficulty_level < 1)
                time_left.Width -= add;
            else if (difficulty_level >= 1 && difficulty_level < 2)
                time_left.Width -= add * 2;
            else if (difficulty_level >= 2 && difficulty_level < 3)
                time_left.Width -= add * 3;
            else if (difficulty_level >= 3 && difficulty_level < 4)
                time_left.Width -= add * 4;
            else if (difficulty_level >= 4 && difficulty_level < 5)
                time_left.Width -= add * 5;
            else
                time_left.Width -= add * 6;
            if (time_left.Width <= 0)
                Lose_Game();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            if (start_btn.Enabled)
            {
                color_text.Focus();
                question.Enabled = start_btn.Enabled = false;
                time_left.Width = time_left_panel.Width;
                score = 0;
                time_left.Visible = true;
                if (!MainMenu.Language)
                    combo_text.Text = $"score: {score}\nmax score: {max_score}";
                else
                    combo_text.Text = $"счёт: {score}\nмакс. счёт: {max_score}";
                Logic();
                timer1.Start();
            }
        }

        private void ColorTimer_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                foreach (Control text in btn_panel.Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                color_text.Font = new Font(color_text.Font.FontFamily, color_text.Font.Size * MainMenu.scale_size);
                developer_name.Left = Width - (developer_name.Width + 12);
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            score = 0;
            max_score = MainMenu.mg1_max_score;
            if (!MainMenu.Language)
            {
                Text = "Colortimer";
                combo_text.Text = $"\nmax score: {max_score}";
            }
            else
            {
                combo_text.Text = $"\nмакс. счёт: {max_score}";
                start_btn.Text = "СТАРТ";
            }
        }

        private void Input_Logic(int btn_index)
        {
            color_text.Focus();
            if (!start_btn.Enabled)
            {
                black_btn.Enabled = green_btn.Enabled = yellow_btn.Enabled = red_btn.Enabled = orange_btn.Enabled = gray_btn.Enabled = purple_btn.Enabled = black_btn.Enabled = false;
                player_chose_color = btn_index + 1;
                Logic();
            }
        }

        private void ColorTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            game_over?.Dispose();
        }

        private void ColorTimer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
                Input_Logic(0);
            else if (e.KeyCode == Keys.D2)
                Input_Logic(1);
            else if (e.KeyCode == Keys.D3)
                Input_Logic(2);
            else if (e.KeyCode == Keys.D4)
                Input_Logic(3);
            else if (e.KeyCode == Keys.D5)
                Input_Logic(4);
            else if (e.KeyCode == Keys.D6)
                Input_Logic(5);
            else if (e.KeyCode == Keys.D7)
                Input_Logic(6);
            else if (e.KeyCode == Keys.D8)
                Input_Logic(7);
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                Start_btn_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Logic()
        {
            int choice_color = rand.Next(8),
            rand_color = rand.Next(8),
            new_rand_color = rand.Next(8),
            rand_content = rand.Next(8);
            if (current_color == 0)
            {
                current_color = choice_color + 1;
                if (MainMenu.Language)
                    color_text.Text = colors[choice_color];
                else
                {
                    if (choice_color == 2)
                        color_text.Text = "Yellow";
                    else if (choice_color == 4)
                        color_text.Text = "Orange";
                    else
                        color_text.Text = colors1[choice_color];
                }
                color_text.ForeColor = colorArray[choice_color];
            }
            else
            {
                if (player_chose_color != 0)
                {
                    black_btn.Enabled = green_btn.Enabled = yellow_btn.Enabled = red_btn.Enabled = orange_btn.Enabled = gray_btn.Enabled = purple_btn.Enabled = black_btn.Enabled = true;
                    if (player_chose_color == current_color)
                    {
                        timer1.Stop();
                        score++;
                        if (!MainMenu.Language)
                            combo_text.Text = $"score: {score}\nmax score: {max_score}";
                        else
                            combo_text.Text = $"счёт: {score}\nмакс. счёт: {max_score}";
                        difficulty_level += 0.075f;
                        time_left.Width = time_left_panel.Width;
                        current_color = choice_color + 1;
                        if (MainMenu.Language)
                            color_text.Text = colors[choice_color];
                        else
                        {
                            if (choice_color == 2)
                                color_text.Text = "Yellow";
                            else if (choice_color == 4)
                                color_text.Text = "Orange";
                            else
                                color_text.Text = colors1[choice_color];
                        }
                        if (difficulty_level < 1)
                        {
                            color_text.ForeColor = colorArray[choice_color];
                        }
                        else if (difficulty_level >= 1 && difficulty_level < 2)
                        {
                            color_text.ForeColor = colorArray[rand_color];
                        }
                        else if (difficulty_level >= 2 && difficulty_level < 3)
                        {
                            color_text.ForeColor = colorArray[rand_color];
                            color_panel.BackColor = colorArray[new_rand_color];
                            if (rand_color == new_rand_color)
                                color_text.ForeColor = Color.White;
                        }
                        else if (difficulty_level >= 3 && difficulty_level < 4)
                        {
                            color_text.ForeColor = colorArray[rand_color];
                            color_panel.BackColor = colorArray[new_rand_color];
                            if (rand_color == new_rand_color)
                                color_text.ForeColor = Color.White;
                            color_text.TextAlign = content[rand_content];
                        }
                        else
                        {
                            color_text.ForeColor = colorArray[rand_color];
                            color_panel.BackColor = Color.FromArgb(64, colorArray[rand_color]);
                            if (rand_color == new_rand_color)
                                color_text.ForeColor = Color.White;
                            color_text.TextAlign = content[rand_content];
                        }
                        if (color_panel.BackColor == Color.Black)
                            combo_text.ForeColor = Color.White;
                        else
                            combo_text.ForeColor = SystemColors.ControlText;
                        timer1.Start();
                    }
                    else
                        Lose_Game();
                }
            }
        }

        private void Lose_Game()
        {
            timer1.Stop();
            if (score > max_score)
                MainMenu.mg1_max_score = max_score = score;
            time_left.Visible = false;
            question.Enabled = start_btn.Enabled = true;
            current_color = 0;
            player_chose_color = 0;
            difficulty_level = 0;
            color_text.TextAlign = ContentAlignment.MiddleCenter;
            color_text.ForeColor = Color.Black;
            color_panel.BackColor = Color.Gainsboro;
            if (MainMenu.Language)
                color_text.Text = "Вы проиграли...";
            else
                color_text.Text = "You lose...";
            if (MainMenu.sounds)
                game_over.Play(1);
            if (!MainMenu.Language)
                combo_text.Text = $"score: {score}\nmax score: {max_score}";
            else
                combo_text.Text = $"счёт: {score}\nмакс. счёт: {max_score}";
            score = 0;
        }
    }
}