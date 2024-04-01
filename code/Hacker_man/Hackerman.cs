using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace minigames.Hacker_man
{
    public partial class Hackerman : Form
    {
        public Hackerman()
        {
            InitializeComponent();
        }

        private const int attempts = 8;
        private int current_attempts = 0, max_score = 0;
        public static int score = 0;
        private int[] password = { 0, 0, 0, 0 }, input_password = { 0, 0, 0, 0 };
        private Random rand = new Random();
        private bool in_game = false;

        private void Hackerman_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                foreach (Control text in top_panel.Controls)
                {
                    if (text is TextBox)
                        text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                }
                developer_name.Left = Width-developer_name.Width-12;
                by_text.Left = Width - by_text.Width - 12;
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            max_score = MainMenu.mg6_max_score;
            score = 0;
            if (!MainMenu.Language)
            {
                Text = "Hackerman";
                start_btn.Text = "START";
                score_text.Text = $"score: 0\nmax score: {max_score}";
            }
            else
                score_text.Text = $"счёт: 0\nмакс. счёт: {max_score}";
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show($"После нажатия кнопки СТАРТ будет сгенерирован четырехзначный шифр. " +
                    $"Ваша задача — угадать этот шифр. У вас будет {attempts} попыток. " +
                    $"Если вы угадали число и оно стоит на своем месте, оно будет помечено зеленым цветом. " +
                    $"Если число угадано, но не стоит на своем месте, оно будет помечено желтым цветом.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"After clicking the START button, a four-digit code will be generated. " +
                    $"Your task is to guess this code. You will have {attempts} attempts. " +
                    $"If you correctly guess a number and it is in the correct position, it will be highlighted in green. " +
                    $"If the number is guessed correctly but not in the correct position, it will be highlighted in yellow.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            Control[] inputs = { num1_input, num2_input, num3_input, num4_input };
            if (!in_game)
            {
                for(int i = 0; i < inputs.Length; i++)
                {
                    inputs[i].Text = "";
                    inputs[i].BackColor = SystemColors.Window;
                    inputs[i].Enabled = true;
                }
                score = 0;
                current_attempts = attempts;
                in_game = true;
                Refresh_Text();
                top_panel.Visible = true;
                Generate_Password();
            }
            else
            {
                if (num1_input.BackColor != Color.LightCoral &&
                    num2_input.BackColor != Color.LightCoral &&
                    num3_input.BackColor != Color.LightCoral &&
                    num4_input.BackColor != Color.LightCoral &&
                    num1_input.Text != "" &&
                    num2_input.Text != "" &&
                    num3_input.Text != "" &&
                    num4_input.Text != "")
                    Check_Password();
            }
            top_panel.Focus();
        }

        private void Num1_input_TextChanged(object sender, EventArgs e)
        {
            if (num1_input.TextLength > 0)
            {
                try
                {
                    num1_input.BackColor = SystemColors.Window;
                    input_password[0] = Convert.ToInt32(num1_input.Text);
                }
                catch (Exception)
                {
                    num1_input.BackColor = Color.LightCoral;
                }
            }
        }

        private void Num2_input_TextChanged(object sender, EventArgs e)
        {
            if (num2_input.TextLength > 0)
            {
                try
                {
                    num2_input.BackColor = SystemColors.Window;
                    input_password[1] = Convert.ToInt32(num2_input.Text);
                }
                catch (Exception)
                {
                    num2_input.BackColor = Color.LightCoral;
                }
            }
        }

        private void Num3_input_TextChanged(object sender, EventArgs e)
        {
            if (num3_input.TextLength > 0)
            {
                try
                {
                    num3_input.BackColor = SystemColors.Window;
                    input_password[2] = Convert.ToInt32(num3_input.Text);
                }
                catch (Exception)
                {
                    num3_input.BackColor = Color.LightCoral;
                }
            }
        }

        private void Num4_input_TextChanged(object sender, EventArgs e)
        {
            if (num4_input.TextLength > 0)
            {
                try
                {
                    num4_input.BackColor = SystemColors.Window;
                    input_password[3] = Convert.ToInt32(num4_input.Text);
                }
                catch (Exception)
                {
                    num4_input.BackColor = Color.LightCoral;
                }
            }
        }

        private void Hackerman_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Start_btn_Click(sender, e);
        }

        private void Num1_input_Enter(object sender, EventArgs e)
        {
            num1_input.Text = "";
        }

        private void Num2_input_Enter(object sender, EventArgs e)
        {
            num2_input.Text = "";
        }

        private void Num3_input_Enter(object sender, EventArgs e)
        {
            num3_input.Text = "";
        }

        private void Num4_input_Enter(object sender, EventArgs e)
        {
            num4_input.Text = "";
        }

        private void Refresh_Text()
        {
            if (!MainMenu.Language)
            {
                if(!in_game)
                    start_btn.Text = "START";
                else
                    start_btn.Text = "ENTER";
                attemps_text.Text = $"attempts: {current_attempts}";
                score_text.Text = $"score: {score}\nmax score: {max_score}";
            }
            else
            {
                if (!in_game)
                    start_btn.Text = "СТАРТ";
                else
                    start_btn.Text = "ВВОД";
                attemps_text.Text = $"попытки: {current_attempts}";
                score_text.Text = $"счёт: {score}\nмакс. счёт: {max_score}";
            }
        }

        private void Win_timer_Tick(object sender, EventArgs e)
        {
            Control[] inputs = { num1_input, num2_input, num3_input, num4_input };
            current_attempts = attempts;
            score++;
            Refresh_Text();
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].Text = "";
                inputs[i].BackColor = SystemColors.Window;
                inputs[i].Enabled = true;
            }
            Generate_Password();
            start_btn.Enabled = true;
            win_timer.Stop();
        }

        private void Hackerman_FormClosing(object sender, FormClosingEventArgs e)
        {
            win_timer.Stop();
        }

        private void Generate_Password()
        {
            for (int i = 0; i < password.Length; i++)
                password[i] = rand.Next(0, 10);
        }

        private void Check_Password()
        {
            bool all_right = true;
            Control[] inputs = { num1_input, num2_input, num3_input, num4_input };
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == input_password[i])
                {
                    inputs[i].BackColor = Color.Lime;
                    inputs[i].Enabled = false;
                }
                else if (password.Contains(input_password[i]))
                {
                    inputs[i].BackColor = Color.Gold;
                }
            }
            for(int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i].BackColor != Color.Lime)
                    all_right = false;
            }
            if (!all_right)
            {
                current_attempts--;
                Refresh_Text();
                if (current_attempts == 0)
                {
                    if (score > max_score)
                        max_score = score;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (inputs[i].BackColor != Color.Lime)
                        {
                            inputs[i].Text = $"{password[i]}";
                            inputs[i].BackColor = Color.Red;
                            inputs[i].Enabled = false;
                        }
                    }
                    if (MainMenu.sounds)
                    {
                        PlaySound game_over = new PlaySound(@"sounds\game_over.wav");
                        game_over.Play(1);
                    }
                    in_game = false;
                    Refresh_Text();
                }
            }
            else
            {
                if (MainMenu.sounds)
                {
                    PlaySound win = new PlaySound(@"sounds\win.wav");
                    win.Play(1);
                }
                start_btn.Enabled = false;
                win_timer.Start();
            }
        }
    }
}
