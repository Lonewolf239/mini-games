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

namespace minigames.Rodrocket
{
    public partial class RodRocket : Form
    {
        public RodRocket()
        {
            InitializeComponent();
        }

        private Random rand = new Random();
        private float hp = 100.0f, difficult = 0;
        private int update_need = 0, added_score = 0, max_score = 0, pause, pause_min, pause_max;
        public static int score = 0;
        private bool up = false, up_task = false;

        private void RodRocket_Load(object sender, EventArgs e)
        {
            score = 0;
            max_score = MainMenu.mg5_max_score;
            if (!MainMenu.Language)
            {
                prog_name.Text = "RodRocket";
                start_btn.Text = "START";
                score_text.Text = "score: 0";
                max_score_text.Text = $"max score: {max_score}";
            }
            else
                max_score_text.Text = $"макс. счёт: {max_score}";
        }

        private void Question_Click(object sender, EventArgs e)
        {
            right_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Ваша цель в игре — удерживать курсор в зоне определенное время, чтобы получать очки. " +
                    "Если вы выходите за пределы зоны, ваше здоровье будет уменьшаться. " +
                    "Каждые 15 очков ваше здоровье будет восстановлено. " +
                    "Если ваше здоровье опустошается, вы проигрываете.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your objective in the game is to keep the cursor within the designated zone for a certain period of time to earn points. " +
                    "If you go outside the zone, your health will decrease. " +
                    "Every 15 points earned, your health will be restored. " +
                    "If your health is depleted, you lose the game.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Score_timer_Tick(object sender, EventArgs e)
        {
            score_text.ForeColor = Color.Black;
            score_timer.Stop();
        }

        private void Hp_timer_Tick(object sender, EventArgs e)
        {
            hp_text.ForeColor = Color.Black;
            hp_timer.Stop();
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Up_btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                right_panel.Focus();
                up = true;
            }
        }

        private void Up_btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                up = false;
        }

        private void Up_btn_MouseLeave(object sender, EventArgs e)
        {
            up = false;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            hp_text.ForeColor = Color.Black;
            question.Enabled = start_btn.Enabled = false;
            up_btn.Enabled = true;
            hp = 100.0f;
            hp_text.Text = $"{hp:0}";
            hp_pic.Image = hp_icons.Images[0];
            pause = 30;
            pause_min = 40;
            pause_max = 60;
            difficult = added_score = score = update_need = 0;
            cursor_panel.Top = 166;
            task_panel.Top = 105;
            right_panel.Focus();
            game_timer.Start();
            progress_refresh.Start();
        }

        private void Progress_panel_Resize(object sender, EventArgs e)
        {
            progress_panel.Top = 176 - progress_panel.Height;
        }

        private void Progress_Refresh_Tick(object sender, EventArgs e)
        {
            if (update_need > 0)
            {
                update_need--;
                progress_panel.Height++;
            }
            if (progress_panel.Top <= 0)
            {
                difficult += 0.15f;
                if (difficult < 1)
                {
                    pause_min = 40;
                    pause_max = 60;
                }
                else if (difficult >= 1 && difficult < 2)
                {
                    pause_min = 30;
                    pause_max = 50;
                }
                else if (difficult >= 2 && difficult < 3)
                {
                    pause_min = 20;
                    pause_max = 45;
                }
                score_text.ForeColor = Color.Lime;
                score_timer.Start();
                score++;
                added_score++;
                if (added_score == 15)
                {
                    hp = 100;
                    hp_text.ForeColor = Color.Lime;
                    hp_timer.Start();
                    added_score = 0;
                    hp_text.Text = $"{hp:0}";
                    hp_pic.Image = hp_icons.Images[0];
                }
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}";
                else
                    score_text.Text = $"счёт: {score}";
                progress_panel.Height = progress_panel.Top = 0;
            }
        }

        private void Game_timer_Tick(object sender, EventArgs e)
        {
            if (pause <= 0)
            {
                if (rand.Next(2) == 1)
                    up_task = true;
                else
                    up_task = false;
                pause = rand.Next(pause_min, pause_max);
            }
            else
                pause--;
            if (up_task)
            {
                if (task_panel.Top > 0)
                    task_panel.Top--;
            }
            else
            {
                if (task_panel.Top < 105)
                    task_panel.Top++;
            }
            if (up)
            {
                if (cursor_panel.Top > 0)
                    cursor_panel.Top -= 2;
            }
            else
            {
                if (cursor_panel.Top < 166)
                    cursor_panel.Top += 2;
            }
            if (cursor_panel.Top >= task_panel.Top && cursor_panel.Bottom <= task_panel.Bottom)
            {
                update_need++;
                task_panel.BackColor = Color.Lime;
            }
            else
            {
                task_panel.BackColor = Color.LightCoral;
                hp -= 0.15f;
                if (hp < 1)
                {
                    hp = 0;
                    hp_text.Text = $"{hp:0}";
                    game_timer.Stop();
                    progress_refresh.Stop();
                    Game_Over();
                }
                else if (hp <= 20)
                    hp_text.ForeColor = Color.Red;
                else if (hp > 20 && hp < 90)
                    hp_text.ForeColor = Color.Black;
                if (hp > 80)
                    hp_pic.Image = hp_icons.Images[0];
                else if (hp > 60)
                    hp_pic.Image = hp_icons.Images[1];
                else if (hp > 40)
                    hp_pic.Image = hp_icons.Images[2];
                else if (hp > 20)
                    hp_pic.Image = hp_icons.Images[3];
                else if (hp > 1)
                    hp_pic.Image = hp_icons.Images[4];
                else
                    hp_pic.Image = hp_icons.Images[5];
                hp_text.Text = $"{hp:0}";
            }
        }

        private void Game_Over()
        {
            question.Enabled = start_btn.Enabled = true;
            up_btn.Enabled = false;
            progress_panel.Height = 0;
            if (score > max_score)
                MainMenu.mg5_max_score = max_score = score;
            if (!MainMenu.Language)
                max_score_text.Text = $"max score: {max_score}";
            else
                max_score_text.Text = $"макс. счёт: {max_score}";
        }
    }
}