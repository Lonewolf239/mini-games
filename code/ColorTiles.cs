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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace minigames.Colortiles
{
    public partial class ColorTiles : Form
    {
        public ColorTiles()
        {
            InitializeComponent();
        }

        private static string[] colors = { "Black", "Green", "Yellow", "Red", "Orange", "Gray", "Purple", "Blue" };
        private readonly Color[] colorArray = Array.ConvertAll(colors, Color.FromName);
        private Random rand = new Random();
        private bool read_time = false;
        private int pos = 0;

        private void Question_Click(object sender, EventArgs e)
        {
            if (MainMenu.Language)
                MessageBox.Show("В течение нескольких секунд будут показаны цветные элементы в случайном порядке. " +
                    "Затем вам потребуется восстановить порядок, нажимая соответствующие кнопки в указанное время.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You will be shown colored elements in random order for a few seconds. " +
                    "Afterwards, you will need to restore the order by pressing the corresponding buttons within a specified time frame.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ColorTiles_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
                Text = "ColorTiles";
            else
                start_btn.Text = "СТАРТ";
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Color_btn_1_Click(object sender, EventArgs e)
        {
            Input_Color(0);
        }

        private void Color_btn_2_Click(object sender, EventArgs e)
        {
            Input_Color(1);
        }

        private void Color_btn_3_Click(object sender, EventArgs e)
        {
            Input_Color(2);
        }

        private void Color_btn_4_Click(object sender, EventArgs e)
        {
            Input_Color(3);
        }

        private void Color_btn_5_Click(object sender, EventArgs e)
        {
            Input_Color(4);
        }

        private void Color_btn_6_Click(object sender, EventArgs e)
        {
            Input_Color(5);
        }

        private void Color_btn_7_Click(object sender, EventArgs e)
        {
            Input_Color(6);
        }

        private void Color_btn_8_Click(object sender, EventArgs e)
        {
            Input_Color(7);
        }

        private void Input_Color(int index)
        {
            if (pos < 8)
            {
                Control[] answer = { answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8 };
                answer[pos].BackColor = colorArray[index];
                pos++;
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            time_left_panel.BackColor = Color.Gray;
            start_btn.Enabled = taskpanel.Visible = answer_panel.Visible = false;
            Control[] tasks = { task_1, task_2, task_3, task_4, task_5, task_6, task_7, task_8 };
            for (int i = 0; i < tasks.Length; i++)
            {
                int rand_color = rand.Next(8);
                tasks[i].BackColor = colorArray[rand_color];
            }
            Control[] answer = { answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8 };
            for (int i = 0; i < answer.Length; i++)
                answer[i].BackColor = Color.White;
            time_left_panel.Width = 400;
            time_left_panel.Visible = taskpanel.Visible = read_time = true;
            timer.Interval = 15;
            pos = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time_left_panel.Width--;
            if (time_left_panel.Width == 0)
                Logic();
        }

        private void Logic()
        {
            if (read_time)
            {
                timer.Stop();
                taskpanel.Visible = read_time = false;
                Control[] color_btn = { color_btn_1, color_btn_2, color_btn_3, color_btn_4, color_btn_5, color_btn_6, color_btn_7, color_btn_8 };
                for (int i = 0; i < color_btn.Length; i++)
                    color_btn[i].Enabled = true;
                time_left_panel.Width = 400;
                timer.Interval = 30;
                answer_panel.Visible = true;
                timer.Start();
            }
            else
            {
                bool all_right = true;
                timer.Stop();
                Control[] color_btn = { color_btn_1, color_btn_2, color_btn_3, color_btn_4, color_btn_5, color_btn_6, color_btn_7, color_btn_8 };
                for (int i = 0; i < color_btn.Length; i++)
                    color_btn[i].Enabled = false;
                Control[] answer = { answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8 };
                Control[] tasks = { task_1, task_2, task_3, task_4, task_5, task_6, task_7, task_8 };
                for (int i = 0; i < tasks.Length; i++)
                {
                    if (answer[i].BackColor != tasks[i].BackColor)
                        all_right = false;
                }
                time_left_panel.Width = 400;
                if (all_right)
                    time_left_panel.BackColor = Color.LawnGreen;
                else
                    time_left_panel.BackColor = Color.Red;
                start_btn.Enabled = taskpanel.Visible = true;
            }
        }
    }
}
