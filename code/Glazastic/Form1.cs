﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using IniReader;

namespace minigames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int win = 0, lose = 0, games = 0;
        public static int widht_panels = 10;
        public static bool big_speed = false, unposible_mod = false, practic_mod = false;
        private readonly PlaySound win_sound = new PlaySound(MainMenu.CGFReader.GetFile("win.wav"), false),
                        game_over = new PlaySound(MainMenu.CGFReader.GetFile("game_over.wav"), false);

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            Start_Stop_Game();
        }

        private void Start_Stop_Game()
        {
            if (start_btn.Text == "START" || start_btn.Text == "СТАРТ")
            {
                timer1.Start();
                progress_panel.Width = 1;
                Random rand = new Random();
                int rand_num = rand.Next(hide_panel.Width - finish_panel.Width);
                if (rand_num < 60)
                    rand_num += 60;
                finish_panel.Location = new Point(rand_num, 0);
                finish2_panel.Left = hide_panel.Left + finish_panel.Left;
                finish2_panel.BackColor = Color.Red;
                finish2_panel.Visible = true;
                if (!practic_mod)
                {
                    hide_panel.Visible = true;
                    games++;
                }
                if (!MainMenu.Language)
                    start_btn.Text = "STOP";
                else
                    start_btn.Text = "СТОП";
            }
            else
            {
                timer1.Stop();
                if (!MainMenu.Language)
                    start_btn.Text = "START";
                else
                    start_btn.Text = "СТАРТ";
                if (progress_panel.Width >= finish2_panel.Left && progress_panel.Width < (finish2_panel.Left + finish2_panel.Width))
                {
                    if (!practic_mod)
                        win++;
                    finish2_panel.BackColor = Color.LawnGreen;
                    if (MainMenu.sounds)
                        win_sound.Play(1);
                }
                else
                {
                    if (!practic_mod)
                        lose++;
                    finish2_panel.BackColor = Color.Red;
                    if (MainMenu.sounds)
                        game_over.Play(1);
                }
                hide_panel.Visible = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int add = 1;
            if (MainMenu.scaled)
                add = (int)(add * MainMenu.scale_size);
            if (!big_speed && !unposible_mod)
                progress_panel.Width += add;
            else if (big_speed && !unposible_mod)
                progress_panel.Width += add * 2;
            else
                progress_panel.Width += add * 3;
            if (progress_panel.Width >= Width)
            {
                if (!practic_mod)
                    lose++;
                timer1.Stop();
                hide_panel.Visible = false;
                if (!MainMenu.Language)
                    start_btn.Text = "START";
                else
                    start_btn.Text = "СТАРТ";
            }
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                hide_panel.Visible = false;
                if (!MainMenu.Language)
                    start_btn.Text = "START";
                else
                    start_btn.Text = "СТАРТ";
                Form2 form = new Form2();
                form.FormClosing += new FormClosingEventHandler(Form2_Closing);
                form.Owner = this;
                form.ShowDialog();
            }
        }

        private void Form2_Closing(object sender, EventArgs e)
        {
            timer1.Stop();
            win_sound?.Dispose();
            game_over?.Dispose();
            widht_panels = finish_panel.Width = finish2_panel.Width = (int)(Form2.dificult_choice * MainMenu.scale_size);
            big_speed = Form2.big_speed;
            unposible_mod = Form2.unposible_mode;
            practic_mod = Form2.practic_mod;
            if (practic_mod)
            {
                if (MainMenu.Language)
                    games_text.Text = "Режим практики";
                else
                    games_text.Text = "Practice mode";
                lose_text.Visible = accurate.Visible = false;
            }
            else
            {
                if (MainMenu.Language)
                    games_text.Text = "Выигрыш 0%";
                else
                    games_text.Text = "Winning 0%";
                lose_text.Visible = accurate.Visible = true;
            }
        }

        private void Hide_panel_VisibleChanged(object sender, EventArgs e)
        {
            float percent = 0, percent_lose = 0;
            if (games != 0)
            {
                percent = Convert.ToSingle(win) / games * 100;
                percent_lose = Convert.ToSingle(lose) / games * 100;
            }
            if (!hide_panel.Visible)
            {
                float accurate_num = Convert.ToSingle(finish2_panel.Width) / 2 + finish2_panel.Left - progress_panel.Width;
                if (MainMenu.Language)
                {
                    lose_text.Text = $"Проигрыш {percent_lose:0.#}%";
                    games_text.Text = $"Выигрыш {percent:0.#}%";
                    if (accurate_num != 0)
                        accurate.Text = $"Точность {-1 * accurate_num:0.#}px";
                    else
                        accurate.Text = "Идеальная точность";
                }
                else
                {
                    lose_text.Text = $"Loss {percent_lose:0.#}%";
                    games_text.Text = $"Winning {percent:0.#}%";
                    if (accurate_num != 0)
                        accurate.Text = $"Accuracy {-1 * accurate_num:0.#}px";
                    else
                        accurate.Text = "Perfect accuracy";
                }
            }
            else
            {
                if (MainMenu.Language)
                {
                    lose_text.Text = $"Проигрыш {percent_lose:0.#}%";
                    games_text.Text = $"Выигрыш {percent:0.#}%";
                    accurate.Text = "Точность 0px";
                }
                else
                {
                    lose_text.Text = $"Loss {percent_lose:0.#}%";
                    games_text.Text = $"Winning {percent:0.#}%";
                    accurate.Text = "Accuracy 0px";
                }
            }
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show("После нажатия кнопки СТАРТ\\Пробел сверху окна начинает ползти полоска. " +
                    "В какой-то момент она скрывается, но продолжает двигаться с той же скоростью. " +
                    "Ваша цель нажать СТАРТ\\Пробел в нужный момент, чтобы полоска остановилась на финише.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("After pressing the START\\Space button, a bar begins to crawl at the top of the window. At some point it goes into hiding, but continues to move with the same speed. " +
                    "Your goal is to press STOP\\Spacebar at the right moment so that the strip stops at the finish line.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                developer_name.Left = Width - (developer_name.Width + 10);
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            switch (INIReader.GetInt(MainMenu.iniFolder, "Glazastic", "difficulty"))
            {
                case 0:
                    widht_panels = 20;
                    break;
                case 2:
                    widht_panels = 5;
                    break;
                default:
                    widht_panels = 10;
                    break;
            }
            big_speed = INIReader.GetBool(MainMenu.iniFolder, "Glazastic", "big_speed");
            unposible_mod = INIReader.GetBool(MainMenu.iniFolder, "Glazastic", "impossible");
            practic_mod = INIReader.GetBool(MainMenu.iniFolder, "Glazastic", "practice_mode");
            win = INIReader.GetInt(MainMenu.iniFolder, "Glazastic", "win") / 13;
            lose = INIReader.GetInt(MainMenu.iniFolder, "Glazastic", "lose") / 13;
            games = INIReader.GetInt(MainMenu.iniFolder, "Glazastic", "games") / 13;
            float percent = 0, percent_lose = 0;
            if (games != 0)
            {
                percent = Convert.ToSingle(win) / games * 100;
                percent_lose = Convert.ToSingle(lose) / games * 100;
            }
            if (MainMenu.Language)
            {
                lose_text.Text = $"Проигрыш {percent_lose:0.#}%";
                games_text.Text = $"Выигрыш {percent:0.#}%";
                accurate.Text = "Точность 0px";
                start_btn.Text = "СТАРТ";
            }
            else
            {
                Text = "EyeStop";
                lose_text.Text = $"Loss {percent_lose:0.#}%";
                games_text.Text = $"Winning {percent:0.#}%";
                accurate.Text = "Accuracy 0px";
            }
            if (practic_mod)
            {
                if (MainMenu.Language)
                    games_text.Text = "Режим практики";
                else
                    games_text.Text = "Practice mode";
                lose_text.Visible = accurate.Visible = false;
            }
            else
            {
                if (MainMenu.Language)
                    games_text.Text = "Выигрыш 0%";
                else
                    games_text.Text = "Winning 0%";
                lose_text.Visible = accurate.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            INIReader.SetKey(MainMenu.iniFolder, "Glazastic", "win", win * 13);
            INIReader.SetKey(MainMenu.iniFolder, "Glazastic", "lose", lose * 13);
            INIReader.SetKey(MainMenu.iniFolder, "Glazastic", "games", games * 13);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                Start_Stop_Game();
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true});
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            show_settings.Image = Properties.Resources.setting_pressed_btn;
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            show_settings.Image = Properties.Resources.setting_btn;
        }
    }
}