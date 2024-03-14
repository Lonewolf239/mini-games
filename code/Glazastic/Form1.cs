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

namespace lazastic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int win = 0, lose = 0, games = 0;
        public static int widht_panels = 10;
        public static bool big_speed = false, unposible_mod = false;

        private void Start_btn_Click(object sender, EventArgs e)
        {
            Start_Stop_Game();
        }

        private void Start_Stop_Game()
        {
            if (start_btn.Text == "START")
            {
                timer1.Start();
                progress_panel.Width = 1;
                Random rand = new Random();
                int rand_num = rand.Next(hide_panel.Width);
                finish_panel.Location = new Point(rand_num, 0);
                finish2_panel.Left = 90 + finish_panel.Left;
                finish2_panel.BackColor = Color.Red;
                finish2_panel.Visible = true;
                hide_panel.Visible = true;
                start_btn.Text = "STOP";
                games++;
            }
            else
            {
                timer1.Stop();
                hide_panel.Visible = false;
                start_btn.Text = "START";
                if (progress_panel.Width >= finish2_panel.Left && progress_panel.Width < (finish2_panel.Left + finish2_panel.Width))
                {
                    win++;
                    finish2_panel.BackColor = Color.LawnGreen;
                }
                else
                {
                    lose++;
                    finish2_panel.BackColor = Color.Red;
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!big_speed && !unposible_mod)
                progress_panel.Width++;
            else if (big_speed && !unposible_mod)
                progress_panel.Width += 2;
            else
                progress_panel.Width += 3;
            if (progress_panel.Width >= Width)
            {
                lose++;
                timer1.Stop();
                hide_panel.Visible = false;
                start_btn.Text = "START";
            }
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                hide_panel.Visible = false;
                start_btn.Text = "START";
                Form2 form = new Form2();
                form.FormClosing += new FormClosingEventHandler(Form2_Closing);
                form.ShowDialog();
            }
        }

        private void Form2_Closing(object sender, EventArgs e)
        {
            widht_panels = finish_panel.Width = finish2_panel.Width = Form2.dificult_choice;
            big_speed = Form2.big_speed;
            unposible_mod = Form2.unposible_mode;
        }

        private void Hide_panel_VisibleChanged(object sender, EventArgs e)
        {
            float percent = 0;
            if (games != 0)
                percent = Convert.ToSingle(win) / games * 100;
            win_text.Text = "Вы выиграли " + Convert.ToString(win) + " раз";
            lose_text.Text = "Вы проиграли " + Convert.ToString(lose) + " раз";
            games_text.Text = "Выигрыш " + percent.ToString("0.#") + "%";
        }

        private void Question_Click(object sender, EventArgs e)
        {
            MessageBox.Show("После нажатия кнопки \"START\" сверху окна начинает ползти полоска. В какой-то момент она скрывается. " +
                "Ваша цель нажать \"STOP\" в нужный момент, чтобы полоска остановилась на финише.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)32)
                Start_Stop_Game();
        }

        private void start_btn_MouseLeave(object sender, EventArgs e)
        {
            top_panel.Focus();
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true});
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            show_settings.Location = new Point(2, 93);
            show_settings.Size = new Size(36, 36);
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            show_settings.Location = new Point(0, 92);
            show_settings.Size = new Size(40, 40);
        }
    }
}