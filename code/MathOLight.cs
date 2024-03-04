using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigames.Math_o_light
{
    public partial class MathOLight : Form
    {
        public MathOLight()
        {
            InitializeComponent();
        }

        private float input_num = 0, difficulty_level = 0,
            num1 = 0, num2 = 0, result;
        private int score = 0, max_score = 0, choice_for_logic = 0;
        private char[] math_list = { '+', '-', '*' };
        private char math_doing = ' ';
        private bool in_game = false, fast = false;
        private Random rand = new Random();

        private void MathOLight_Load(object sender, EventArgs e)
        {
            max_score = MainMenu.mg3_max_score;
            if (!MainMenu.Language)
            {
                Text = "Math-o-Light";
                input_text.Text = "Enter your answer:";
                start_btn.Text = "START";
                score_text.Text = $"score: {score}\r\nmax. score: {max_score}\r\n";
            }
            else
                score_text.Text = $"счёт: {score}\r\nмакс. счёт: {max_score}\r\n";
        }

        private void Question_Click(object sender, EventArgs e)
        {
            if (MainMenu.Language)
                MessageBox.Show("В верхней части окна появляется математическое уравнение, и вашей задачей будет решить его как можно быстрее. " +
                    "У вас будет ограниченное время на ввод ответа.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("A mathematical equation appears at the top of the window, and your task is to solve it as quickly as possible. " +
                    "You will have limited time to enter your answer.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            input.Text = "";
            difficulty_level = 0;
            start_btn.Enabled = false;
            Logic(0);
        }

        private void MathOLight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                MouseEventArgs args = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                Enter_btn_MouseClick(null, args);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (fast)
                time_left.Width -= 10;
            else
                time_left.Width--;
            if (time_left.Width == 0)
            {
                Logic(choice_for_logic);
            }
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (input.Text != "")
            {
                int savedCursorPosition = input.SelectionStart;
                input.Text = input.Text.Replace('.', ',');
                input.SelectionStart = savedCursorPosition;
                try
                {
                    input_num = Convert.ToSingle(input.Text);
                    input.BackColor = Color.White;
                }
                catch (Exception)
                {
                    input.BackColor = Color.LightCoral;
                }
            }
        }

        private void Enter_btn_MouseEnter(object sender, EventArgs e)
        {
            enter_btn.Size = new Size(76, 36);
            enter_btn.Location = new Point(232, 121);
        }

        private void Enter_btn_MouseLeave(object sender, EventArgs e)
        {
            enter_btn.Size = new Size(80, 40);
            enter_btn.Location = new Point(230, 119);
        }

        private void Enter_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && input.BackColor == Color.White && in_game)
            {
                input.Text = "";
                Logic(1);
            }
        }

        private void Game_Over()
        {
            timer.Stop();
            time_left_panel.Visible = false;
            if (score > max_score)
                MainMenu.mg3_max_score = max_score = score;
            score = 0;
            task_text.ForeColor = Color.Red;
            start_btn.Enabled = true;
        }

        private void Logic(int choice)
        {
            if (choice == 0)
            {
                fast = false;
                timer.Interval = 40;
                in_game = true;
                task_text.ForeColor = Color.Black;
                int max_num = 10, max_math = 3;
                if (difficulty_level < 1)
                {
                    max_math = 1;
                    max_num = 0;
                }
                else if (difficulty_level >= 1 && difficulty_level < 2)
                {
                    max_math = 2;
                    max_num += 5;
                }
                else if (difficulty_level >= 2 && difficulty_level < 3)
                    max_num += 10;
                else if (difficulty_level >= 3 && difficulty_level < 4)
                    max_num += 15;
                else if (difficulty_level >= 4 && difficulty_level < 5)
                    max_num += 20;
                else
                    max_num += 25;
                num1 = max_num+ rand.Next(10);
                num2 = max_num + rand.Next(10);
                math_doing = math_list[rand.Next(max_math)];
                if (math_doing == '+')
                    result = num1 + num2;
                else if (math_doing == '-')
                    result = num1 - num2;
                else
                {
                    num1 = rand.Next(10);
                    num2 = rand.Next(10);
                    result = num1 * num2;
                }
                task_text.Text = $"{num1} {math_doing} {num2} = ?";
                time_left.Width = 345;
                choice_for_logic = 1;
                time_left_panel.Visible = true;
                timer.Start();
            }
            else
            {
                in_game = false;
                timer.Stop();
                time_left_panel.Text = "";
                task_text.Text = $"{num1} {math_doing} {num2} = {result}";
                if (input_num == result)
                {
                    fast = true;
                    time_left.Width = 345;
                    choice_for_logic = 0;
                    timer.Start();
                    difficulty_level += 0.75f;
                    input_num = 0;
                    score++;
                    task_text.ForeColor = Color.LawnGreen;
                }
                else
                    Game_Over();
                score_text.Text = (MainMenu.Language)?$"счёт: {score}\r\nмакс. счёт: {max_score}\r\n":$"score: {score}\r\nmax. score: {max_score}\r\n";
            }
        }
    }
}
