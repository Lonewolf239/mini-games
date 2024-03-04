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

        private static string[] colors = { "Black", "Green", "Gold", "Red", "DarkOrange", "Gray", "Purple", "Blue" };
        private readonly Color[] colorArray = Array.ConvertAll(colors, Color.FromName);
        private Random rand = new Random();
        private int read_time = 0;
        private int pos = 0, num_task;
        private float difficult = 0;
        private bool in_game = false;

        private void Question_Click(object sender, EventArgs e)
        {
            time_left_panel.Focus();
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
            time_left_panel.Focus();
            if (pos < num_task && color_btn_1.Visible)
            {
                Control[] answer = { answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8 };
                answer[pos].BackColor = colorArray[index];
                pos++;
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            time_left_panel.Focus();
            if (!in_game)
            {
                Control[] color_btn = { color_btn_1, color_btn_2, color_btn_3, color_btn_4, color_btn_5, color_btn_6, color_btn_7, color_btn_8 };
                for (int i = 0; i < color_btn.Length; i++)
                    color_btn[i].Visible = color_btn[i].Enabled = false;
                in_game = true;
                difficult = 0;
                Start_Game();
            }
            else
            {
                time_left_panel.Width = 0;
            }
        }

        private void Start_Game()
        {
            if (difficult < 1)
                num_task = 4;
            else if (difficult >= 1 && difficult < 2)
                num_task = 5;
            else if (difficult >= 2 && difficult < 3)
                num_task = 6;
            else if (difficult >= 3 && difficult < 4)
                num_task = 7;
            else
                num_task = 8;
            time_left_panel.BackColor = Color.Gray;
            if (MainMenu.Language)
                start_btn.Text = "СКИП";
            else
                start_btn.Text = "SKIP";
            taskpanel.Visible = answer_panel.Visible = false;
            Control[] tasks = { task_1, task_2, task_3, task_4, task_5, task_6, task_7, task_8 };
            for (int i = 0; i < num_task; i++)
            {
                int rand_color = rand.Next(8);
                tasks[i].BackColor = colorArray[rand_color];
                tasks[i].BackgroundImage = null;
            }
            for(int i = num_task; i < tasks.Length; i++)
            {
                tasks[i].BackColor = Color.DarkGray;
                tasks[i].BackgroundImage = denied_pic.Image;
            }
            Control[] answer = { answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8 };
            for (int i = 0; i < num_task; i++)
            {
                answer[i].BackColor = Color.Gainsboro;
                answer[i].BackgroundImage = null;
            }
            for (int i = num_task; i < answer.Length; i++)
            {
                answer[i].BackColor = Color.DarkGray;
                answer[i].BackgroundImage = denied_pic.Image;
            }
            time_left_panel.Width = 400;
            time_left_panel.Visible = taskpanel.Visible = true;
            read_time = 0;
            timer.Interval = 15;
            pos = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time_left_panel.Width--;
            if (time_left_panel.Width == 0)
            {
                if (read_time == -1)
                    read_time = 1;
                Logic();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            time_left_panel.Focus();
            if (read_time == -1)
            {
                if (pos > 0)
                    pos--;
                Control[] answer = { answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8 };
                answer[pos].BackColor = Color.Gainsboro;
            }
        }

        private void ColorTiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)49)
                Input_Color(0);
            else if (e.KeyChar == (char)50)
                Input_Color(1);
            else if (e.KeyChar == (char)51)
                Input_Color(2);
            else if (e.KeyChar == (char)52)
                Input_Color(3);
            else if (e.KeyChar == (char)53)
                Input_Color(4);
            else if (e.KeyChar == (char)54)
                Input_Color(5);
            else if (e.KeyChar == (char)55)
                Input_Color(6);
            else if (e.KeyChar == (char)56)
                Input_Color(7);
            else if (e.KeyChar == (char)8)
                Clear_btn_Click(sender, e);
            else if (e.KeyChar == (char)13)
                Start_btn_Click(sender, e);

        }

        private void Logic()
        {
            if (read_time == 0)
            {
                timer.Stop();
                taskpanel.Visible = false;
                read_time = 0;
               Control[] color_btn = { color_btn_1, color_btn_2, color_btn_3, color_btn_4, color_btn_5, color_btn_6, color_btn_7, color_btn_8 };
                for (int i = 0; i < color_btn.Length; i++)
                    color_btn[i].Visible = color_btn[i].Enabled = true;
                time_left_panel.Width = 400;
                timer.Interval = 30;
                answer_panel.Visible = true;
                read_time = -1;
                timer.Start();
            }
            else if (read_time == 1)
            {
                bool all_right = true;
                timer.Stop();
                Control[] color_btn = { color_btn_1, color_btn_2, color_btn_3, color_btn_4, color_btn_5, color_btn_6, color_btn_7, color_btn_8 };
                for (int i = 0; i < color_btn.Length; i++)
                    color_btn[i].Visible = color_btn[i].Enabled = false;
                Control[] answer = { answer_1, answer_2, answer_3, answer_4, answer_5, answer_6, answer_7, answer_8 };
                Control[] tasks = { task_1, task_2, task_3, task_4, task_5, task_6, task_7, task_8 };
                for (int i = 0; i < num_task; i++)
                {
                    if (answer[i].BackColor != tasks[i].BackColor)
                        all_right = false;
                }
                time_left_panel.Width = 400;
                taskpanel.Visible = true;
                if (all_right)
                {
                    time_left_panel.BackColor = Color.LawnGreen;
                    difficult += 0.5f;
                    read_time = 2;
                    timer.Interval = 1;
                    timer.Start();
                }
                else
                {
                    time_left_panel.BackColor = Color.Red;
                    in_game = false;
                    if (!MainMenu.Language)
                        start_btn.Text = "START";
                    else
                        start_btn.Text = "СТАРТ";
                }
            }
            else
            {
                timer.Stop();
                Start_Game();
            }
        }
    }
}
