using System;
using System.Diagnostics;
using System.Drawing;
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
        private int max_score = 0, choice_for_logic = 0;
        public static int score = 0;
        private char[] math_list = { '+', '-', '*' };
        private char math_doing = ' ';
        private bool in_game = false, fast = false;
        private Random rand = new Random();

        private void MathOLight_Load(object sender, EventArgs e)
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
            max_score = MainMenu.mg3_max_score;
            score = 0;
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
            top_panel.Focus();
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
            top_panel.Focus();
            input.Text = "";
            difficulty_level = score = 0;
            question.Enabled = start_btn.Enabled = false;
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
            int minus = 1;
            if (MainMenu.scaled)
                minus = (int)(minus * MainMenu.scale_size);
            if (fast)
                time_left.Width -= minus * 10;
            else
                time_left.Width -= minus;
            if (time_left.Width == 0)
            {
                Logic(choice_for_logic);
            }
        }

        private void MathOLight_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
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
            enter_btn.Size = new Size(enter_btn.Width - 4, enter_btn.Height - 4);
            enter_btn.Location = new Point(enter_btn.Left + 2, enter_btn.Top + 2);
        }

        private void Enter_btn_MouseLeave(object sender, EventArgs e)
        {
            enter_btn.Size = new Size(enter_btn.Width + 4, enter_btn.Height + 4);
            enter_btn.Location = new Point(enter_btn.Left - 2, enter_btn.Top - 2);
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
            if (MainMenu.sounds)
            {
                PlaySound game_over = new PlaySound(@"sounds\game_over.wav");
                game_over.Play(1);
            }
            question.Enabled = start_btn.Enabled = true;
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
                time_left.Width = time_left_panel.Width;
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
                    time_left.Width = time_left_panel.Width;
                    choice_for_logic = 0;
                    timer.Start();
                    difficulty_level += 0.75f;
                    input_num = 0;
                    score++;
                    task_text.ForeColor = Color.LawnGreen;
                    if (MainMenu.sounds)
                    {
                        PlaySound win = new PlaySound(@"sounds\win.wav");
                        win.Play(1);
                    }
                }
                else
                    Game_Over();
                score_text.Text = (MainMenu.Language)?$"счёт: {score}\r\nмакс. счёт: {max_score}\r\n":$"score: {score}\r\nmax. score: {max_score}\r\n";
            }
        }
    }
}
