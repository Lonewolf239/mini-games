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

namespace minigames._Reactor
{
    public partial class Reactor : Form
    {
        public Reactor()
        {
            InitializeComponent();
        }

        private Random rand = new Random();
        private bool[] trap_btn = { false, false, false, false, false, false, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false,
            false, false, false, false, false, false };
        private int[] station = {
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0
        };
        private bool in_game = false;

        private void Reactor_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
            {
                Text = "Reactor";
                start_btn.Text = "START";
            }
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].MouseClick += new MouseEventHandler(Cold_btn_MouseClick);
            }
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Ваша цель — предотвратить перегрев реактора, нажимая кнопку запуска охлаждения в нужный момент. " +
                    "Если кнопка зеленая, необходимо нажать ее как можно скорее. Если кнопка синяя, нужно дождаться, пока она не станет желтой, и только затем нажать на нее. " +
                    "Если не успеваете нажать вовремя или нажимаете на синюю кнопку — вы проиграли.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your goal is to prevent the reactor from overheating by pressing the cooling start button at the right moment. " +
                    "If the button is green, you need to press it as soon as possible. " +
                    "If the button is blue, you must wait until it turns yellow and only then press it. If you fail to press in time or press the blue button — you lose.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
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

        private void Btn_Click(int index)
        {
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            if (trap_btn[index])
                Game_Over();
            else
            {
                station[index] = 0;
                btns[index].Visible = false;
            }
        }

        private void Game_Over()
        {
            in_game = false;
            wait_timer.Stop();
            question.Enabled = start_btn.Enabled = true;
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Visible = false;
                station[i] = 0;
                trap_btn[i] = false;
            }
            top_panel.BackColor = Color.Red;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            top_panel.BackColor = Color.FromArgb(255, 12, 12, 50);
            question.Enabled = start_btn.Enabled = false;
            in_game = true;
            Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
            for (int i = 0; i < btns.Length; i++)
            {
                if (rand.Next(100) <= 10 && !btns[i].Visible)
                {
                    if (rand.Next(100) <= 25)
                    {
                        btns[i].BackgroundImage = btn_images.Images[3];
                        trap_btn[i] = true;
                    }
                    else
                    {
                        btns[i].BackgroundImage = btn_images.Images[0];
                        trap_btn[i] = false;
                    }
                    btns[i].Visible = true;
                }
            }
            wait_timer.Start();
        }

        private void Spawn_btns()
        {
            if (in_game)
            {
                Control[] btns = { cold_btn1, cold_btn2, cold_btn3, cold_btn4, cold_btn5, cold_btn6, cold_btn7, cold_btn8, cold_btn9, cold_btn10,
            cold_btn11, cold_btn12, cold_btn13, cold_btn14, cold_btn15, cold_btn16, cold_btn17, cold_btn18, cold_btn19, cold_btn20,
            cold_btn21, cold_btn22, cold_btn23, cold_btn24, cold_btn25, cold_btn26, cold_btn27, cold_btn28, cold_btn29, cold_btn30,
            cold_btn31, cold_btn32, cold_btn33, cold_btn34, cold_btn35, cold_btn36 };
                for (int i = 0; i < btns.Length; i++)
                {
                    if (rand.Next(100) <= 4 && !btns[i].Visible)
                    {
                        if (rand.Next(100) <= 25)
                        {
                            btns[i].BackgroundImage = btn_images.Images[3];
                            trap_btn[i] = true;
                        }
                        else
                        {
                            btns[i].BackgroundImage = btn_images.Images[0];
                            trap_btn[i] = false;
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
                    if (btns[i].Visible)
                    {
                        if (btns[i].Visible)
                            station[i]++;
                        if (station[i] == 4 && btns[i].Visible)
                        {
                            Game_Over();
                        }
                        else if (station[i] == 4 && !btns[i].Visible)
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
                        }
                        else if (station[i] == 1)
                        {
                            btns[i].BackgroundImage = btn_images.Images[0];
                            trap_btn[i] = false;
                        }
                    }
                }
                wait_timer.Start();
            }
        }

        private void Wait_timer_Tick(object sender, EventArgs e)
        {
            wait_timer.Stop();
            Refresh_cold();
            Spawn_btns();
        }

    }
}