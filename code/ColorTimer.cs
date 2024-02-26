using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private static string[] colors1 = { "Black", "Green", "Yellow", "Red", "Orange", "Gray", "Purple", "Blue" };
        private Color[] colorArray = Array.ConvertAll(colors1, Color.FromName);
        private ContentAlignment[] content = new ContentAlignment[]
        {
            ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight,
            ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight,
            ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
        };
        private int current_color = 0, player_chose_color = 0, score = 0, max_score = 0;
        private Random rand = new Random();
        private static float difficulty_level = 0;

        private void Question_Click(object sender, EventArgs e)
        {
            if (MainMenu.Language)
                MessageBox.Show("У вас есть несколько кнопок разных цветов, и ваша задача состоит в том, чтобы в течение определенного времени нажимать кнопку нужного цвета. " +
                    "Если время истекает или если вы нажимаете неправильную кнопку, то вы проигрываете.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (difficulty_level < 1)
                time_left.Width--;
            else if (difficulty_level >= 1 && difficulty_level < 2)
                time_left.Width -= 2;
            else if (difficulty_level >= 2 && difficulty_level < 3)
                time_left.Width -= 3;
            else if (difficulty_level >= 3 && difficulty_level < 4)
                time_left.Width -= 4;
            else if (difficulty_level >= 4 && difficulty_level < 5)
                time_left.Width -= 5;
            else
                time_left.Width -= 6;
            if (time_left.Width <= 0)
                Lose_Game();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            start_btn.Enabled = false;
            time_left.Width = 400;
            time_left.Visible = true;
            combo_text.Text = $"score: 0\nmax score: {max_score}";
            Logic();
            timer1.Start();
        }

        private void ColorTimer_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
                Text = "Colortimer";
            max_score = MainMenu.mg1_max_score;
            combo_text.Text = $"\nmax score: {max_score}";
        }

        private void Input_Logic(int btn_index)
        {
            if (!start_btn.Enabled)
            {
                black_btn.Enabled = green_btn.Enabled = yellow_btn.Enabled = red_btn.Enabled = orange_btn.Enabled = gray_btn.Enabled = purple_btn.Enabled = black_btn.Enabled = false;
                player_chose_color = btn_index + 1;
                Logic();
            }
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
                    color_text.Text = colors1[choice_color];
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
                        combo_text.Text = $"score: {score}\nmax score: {max_score}";
                        difficulty_level += 0.075f;
                        time_left.Width = 400;
                        current_color = choice_color + 1;
                        if (MainMenu.Language)
                            color_text.Text = colors[choice_color];
                        else
                            color_text.Text = colors1[choice_color];
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
            start_btn.Enabled = true;
            score = 0;
            current_color = 0;
            player_chose_color = 0;
            difficulty_level = 0;
            color_text.TextAlign = ContentAlignment.MiddleCenter;
            color_text.ForeColor = Color.Black;
            color_panel.BackColor = Color.Gainsboro;
            color_text.Text = "You lose...";
            combo_text.Text = $"\nmax score: {max_score}";
        }
    }
}
