using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._Reactor
{
    public partial class Reactor : Form
    {
        public Reactor()
        {
            InitializeComponent();
        }

        private Random rand = new Random();
        private int[] trap_btn = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0 };
        private int[] station = {
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0
        };
        private bool in_game = false, bonus_created = false, in_bonus = false;
        private float max_score = 0, overload = 5, old_overload, pause;
        public static float score = 0;
        private ToolTip tip;
        private readonly PlaySound boop = new PlaySound(MainMenu.CGFReader.GetFile("boop.wav"), false),
         explosion = new PlaySound(MainMenu.CGFReader.GetFile("explosion.wav"), false);

        private void Reactor_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                foreach (Control text in top_panel.Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                developer_name.Left = Width - (developer_name.Width + 12);
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            score = 0;
            max_score = MainMenu.mg4_max_score;
            if (!MainMenu.Language)
            {
                Text = "Reactor";
                start_btn.Text = "START";
                score_text.Text = $" score: {score:0.#}     max score: {max_score:0.#}     overload: {overload:0.##}%";
            }
            else
                score_text.Text = $" счёт: {score:0.#}     макс. счёт: {max_score:0.#}     перегрузка: {overload:0.##}%";
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].MouseClick += new MouseEventHandler(Cold_btn_MouseClick);
                btns[i].VisibleChanged += new EventHandler(Cold_btn_VisibleChanged);
            }
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Ваша цель — предотвратить перегрев реактора, нажимая кнопку запуска охлаждения в нужный момент. " +
                    "Если кнопка зеленая, необходимо нажать ее как можно скорее. Если кнопка синяя, нужно дождаться, пока она не станет желтой, и только затем нажать на нее. " +
                    "Если вы не успеваете нажать вовремя или нажмете на синюю кнопку — вы проиграете.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your goal is to prevent the reactor from overheating by pressing the cooling button at the right time. " +
                    "If the button is green, you need to press it as soon as possible. " +
                    "If the button is blue, you need to wait until it turns yellow before clicking on it. " +
                    "If you don't manage to click in time or click on the blue button, you will lose.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Cold_btn_VisibleChanged(object sender, EventArgs e)
        {
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            for(int i = 0; i < btns.Length; i++)
            {
                if (btns[i].Visible)
                    btns[i].Cursor = Cursors.Hand;
                else
                    btns[i].Cursor = Cursors.Default;
            }
        }

        private void Cold_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox clickedButton && e.Button == MouseButtons.Left)
            {
                Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
                for (int i = 0; i < btns.Length; i++)
                {
                    if (clickedButton.Name == btns[i].Name)
                    {
                        Btn_Click(i);
                        break;
                    }
                }
            }
        }

        private void Btn_Click(int i)
        {
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            if (MainMenu.sounds)
                boop.Play(1);
            if (trap_btn[i] == 1)
                Game_Over();
            else if (trap_btn[i] == 0)
            {
                if (station[i] < 2)
                {
                    if (!in_bonus)
                    {
                        score++;
                        overload -= 0.01f;
                    }
                    else
                        score += 2;
                    if (overload <= 1)
                        overload = 1;
                }
                else if (station[i] == 2)
                {
                    score += 0.5f;
                    if (!in_bonus)
                        overload += 0.02f;
                }
                else if (station[i] == 3)
                {
                    score += 0.2f;
                    if (!in_bonus)
                        overload += 0.05f;
                }
            }
            else
            {
                bonus_time.Width = bonus_time_panel.Width;
                bonus_time.Visible = in_bonus = true;
                refresh_timer.Interval = 1000;
                old_overload = overload;
                overload = 100;
                wait_timer.Stop();
                for (int j = 0; j < btns.Length; j++)
                    btns[j].Visible = false;
            }
            pause = (pause >= 1) ? 1 : pause + 0.075f;
            if (!MainMenu.Language)
                score_text.Text = $" score: {score:0.#}     max score: {max_score:0.#}     overload: {overload:0.##}%";
            else
                score_text.Text = $" счёт: {score:0.#}     макс. счёт: {max_score:0.#}     перегрузка: {overload:0.##}%";
            station[i] = 0;
            btns[i].Visible = false;
        }

        private void Game_Over()
        {
            if (score > max_score)
            {
                max_score = score;
                MainMenu.mg4_max_score = max_score;
            }
            in_game = false;
            wait_timer.Stop();
            refresh_timer.Stop();
            question.Enabled = start_btn.Enabled = true;
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Visible = false;
                station[i] = 0;
                trap_btn[i] = 0;
            }
            if (MainMenu.sounds)
                explosion.Play(0.4f);
            top_panel.BackColor = Color.Black;
            top_panel.BackgroundImage = lose_pic.Image;
            if (!MainMenu.Language)
                score_text.Text = $" score: {score:0.#}     max score: {max_score:0.#}     overload: {overload:0.##}%";
            else
                score_text.Text = $" счёт: {score:0.#}     макс. счёт: {max_score:0.#}     перегрузка: {overload:0.##}%";
        }

        private void StartGame()
        {
            top_panel.BackgroundImage = null;
            top_panel.BackColor = Color.FromArgb(12, 12, 50);
            pause = score = 0;
            overload = 5;
            if (!MainMenu.Language)
                score_text.Text = $" score: {score:0.#}     max score: {max_score:0.#}     overload: {overload:0.##}%";
            else
                score_text.Text = $" счёт: {score:0.#}     макс. счёт: {max_score:0.#}     перегрузка: {overload:0.##}%";
            bonus_created = in_bonus = question.Enabled = start_btn.Enabled = false;
            in_game = true;
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            for (int i = 0; i < btns.Length; i++)
            {
                if (rand.Next(10001) / 100 <= overload && !btns[i].Visible)
                {
                    if (rand.Next(100) <= 25)
                    {
                        btns[i].BackgroundImage = btn_images.Images[3];
                        trap_btn[i] = 1;
                    }
                    else
                    {
                        btns[i].BackgroundImage = btn_images.Images[0];
                        trap_btn[i] = 0;
                    }
                    btns[i].Visible = true;
                }
            }
            wait_timer.Start();
            refresh_timer.Start();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            StartGame();
        }

        private void Spawn_btns()
        {
            if (in_game)
            {
                Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
                if (in_bonus && !bonus_timer.Enabled)
                    bonus_timer.Start();
                for (int i = 0; i < btns.Length; i++)
                {
                    if (rand.Next(10001)/100 <= overload && !btns[i].Visible)
                    {
                        int spawn = rand.Next(100);
                        if (spawn <= 25)
                        {
                            if (!in_bonus)
                            {
                                btns[i].BackgroundImage = btn_images.Images[3];
                                trap_btn[i] = 1;
                            }
                            else
                            {
                                btns[i].BackgroundImage = btn_images.Images[0];
                                trap_btn[i] = 0;
                            }
                        }
                        else if (spawn > 25 && spawn <= 30)
                        {
                            if (!bonus_created && pause == 1)
                            {
                                bonus_created = true;
                                btns[i].BackgroundImage = btn_images.Images[4];
                                trap_btn[i] = -1;
                            }
                            else
                            {
                                btns[i].BackgroundImage = btn_images.Images[0];
                                trap_btn[i] = 0;
                            }
                        }
                        else
                        {
                            btns[i].BackgroundImage = btn_images.Images[0];
                            trap_btn[i] = 0;
                        }
                        btns[i].Visible = true;
                    }
                }
            }
        }

        private void Refresh_cold()
        {
            if (in_game)
            {
                Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
                for (int i = 0; i < btns.Length; i++)
                {
                    if (btns[i].Visible && trap_btn[i] != -1)
                    {
                        station[i]++;
                        if (station[i] == 4)
                        { 
                            Game_Over();
                        }
                        else if (station[i] == 4)
                        {
                            station[i] = 0;
                        }
                        else if (station[i] == 3)
                        {
                            btns[i].BackgroundImage = btn_images.Images[2];
                        }
                        else if (station[i] == 2)
                        {
                            btns[i].BackgroundImage = btn_images.Images[1];
                            trap_btn[i] = 0;
                        }
                        else if (station[i] == 1 && trap_btn[i] == 0)
                        {
                            btns[i].BackgroundImage = btn_images.Images[0];
                        }
                    }
                    else if (btns[i].Visible && trap_btn[i] == -1)
                    {
                        station[i]++;
                        if (station[i] == 4)
                        {
                            btns[i].Visible = false;
                            bonus_created = false;
                            pause = trap_btn[i] = 0;
                        }
                        else if (station[i] == 3)
                        {
                            btns[i].BackgroundImage = btn_images.Images[6];
                        }
                        else if (station[i] == 2)
                        {
                            btns[i].BackgroundImage = btn_images.Images[5];
                        }
                    }

                }
            }
        }

        private void Reactor_FormClosing(object sender, FormClosingEventArgs e)
        {
            wait_timer.Stop();
            refresh_timer.Stop();
            bonus_timer.Stop();
            explosion?.Dispose();
            boop?.Dispose();
        }

        private void Reactor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && start_btn.Enabled)
                StartGame();
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Score_text_MouseHover(object sender, EventArgs e)
        {
            tip = new ToolTip();
            string msg;
            tip.ToolTipIcon = ToolTipIcon.Info;
            if (!MainMenu.Language)
            {
                tip.ToolTipTitle = "Hint";
                msg = "Overload is the chance with which new cooling buttons will appear\n" +
                    "Green:  -0.01%  +1pt\n" +
                    "Yellow: +0.02%  +0.5pt\n" +
                    "Red:    +0.05%  +0.2pt";
            }
            else
            {
                tip.ToolTipTitle = "Подсказка";
                msg = "Перегрузка - шанс появления новых кнопок охлаждения\n" +
                    "Зелёный: -0.01%  +1pt\n" +
                    "Жёлтый:  +0.02%  +0.5pt\n" +
                    "Красный: +0.05%  +0.2pt";
            }
            tip.SetToolTip(score_text, msg);
        }

        private void Refresh_timer_Tick(object sender, EventArgs e)
        {
            Spawn_btns();
        }

        private void Bonus_timer_Tick(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
                bonus_time.Width -= 6;
            else
                bonus_time.Width -= 3;
            if (bonus_time.Width <= 0)
            {
                bonus_timer.Stop();
                refresh_timer.Stop();
                Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
                for (int i = 0; i < btns.Length; i++)
                {
                    btns[i].Visible = false;
                    station[i] = 0;
                    trap_btn[i] = 0;
                }
                bonus_created = in_bonus = bonus_time.Visible = false;
                refresh_timer.Interval = 1500;
                pause = 0;
                overload = old_overload;
                if (!MainMenu.Language)
                    score_text.Text = $" score: {score:0.#}     max score: {max_score:0.#}     overload: {overload:0.##}%";
                else
                    score_text.Text = $" счёт: {score:0.#}     макс. счёт: {max_score:0.#}     перегрузка: {overload:0.##}%";
                wait_timer.Start();
                refresh_timer.Start();
            }
        }

        private void Wait_timer_Tick(object sender, EventArgs e)
        {
            Refresh_cold();
        }

        private void Score_text_MouseLeave(object sender, EventArgs e)
        {
            tip?.Dispose();
        }
    }
}