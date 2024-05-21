using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using IniReader;

namespace minigames._Sudoku
{
    public partial class Sudoku : Form
    {
        public Sudoku()
        {
            InitializeComponent();
        }

        private readonly Random rand = new Random();
        private int x, y;
        private int[][] numbers;
        private int minutes = 0, seconds = 0, _minutes = 0, _seconds;
        public static int  difficulty = 0;
        public static bool prefill = true, death_time = false;
        private readonly PlaySound win = new PlaySound(@"sounds\win.wav"),
         game_over = new PlaySound(@"sounds\game_over.wav");

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Sudoku_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                    foreach (Control text1 in text.Controls)
                    {
                        text1.Font = new Font(text1.Font.FontFamily, text1.Font.Size * MainMenu.scale_size);
                        foreach (Control text2 in text1.Controls)
                            text2.Font = new Font(text2.Font.FontFamily, text2.Font.Size * MainMenu.scale_size);
                    }
                }
                developer_name.Left = Width - (developer_name.Width + 12);
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
            if (!MainMenu.Language)
            {
                Text = "SudoSaga";
                timer_text.Text = "Press Start";
                start_btn.Text = "START";
            }
            difficulty = INIReader.GetInt(MainMenu.iniFolder, "SudoSaga", "difficulty", 0);
            if (difficulty < 0 || difficulty > 2)
            {
                difficulty = 0;
                INIReader.SetKey(MainMenu.iniFolder, "SudoSaga", "difficulty", 0);
            }
            prefill = INIReader.GetBool(MainMenu.iniFolder, "SudoSaga", "prefill", true);
            death_time = INIReader.GetBool(MainMenu.iniFolder, "SudoSaga", "death_time", false);
        }

        private bool CheckCorrect(int x, int y, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != x && numbers[y][i] == num)
                    return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (i != y && numbers[i][x] == num)
                    return false;
            }
            int startX = (x / 3) * 3;
            int startY = (y / 3) * 3;
            for (int i = startY; i < startY + 3; i++)
            {
                for (int j = startX; j < startX + 3; j++)
                {
                    if (numbers[i][j] == num && (i != y || j != x))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void InputTextChanged(object sender, EventArgs e)
        {
            TextBox[][] inputs =
            {
                new TextBox[]
                {
                    input_1_1, input_2_1, input_3_1, input_1_2, input_2_2, input_3_2, input_1_3, input_2_3, input_3_3
                },
                new TextBox[]
                {
                    input_4_1, input_5_1, input_6_1, input_4_2, input_5_2, input_6_2, input_4_3, input_5_3, input_6_3
                },
                new TextBox[]
                {
                    input_7_1, input_8_1, input_9_1, input_7_2, input_8_2, input_9_2, input_7_3, input_8_3, input_9_3
                },
                new TextBox[]
                {
                    input_1_4, input_2_4, input_3_4, input_1_5, input_2_5, input_3_5, input_1_6, input_2_6, input_3_6
                },
                new TextBox[]
                {
                    input_4_4, input_5_4, input_6_4, input_4_5, input_5_5, input_6_5, input_4_6, input_5_6, input_6_6
                },
                new TextBox[]
                {
                    input_7_4, input_8_4, input_9_4, input_7_5, input_8_5, input_9_5, input_7_6, input_8_6, input_9_6
                },
                new TextBox[]
                {
                    input_1_7, input_2_7, input_3_7, input_1_8, input_2_8, input_3_8, input_1_9, input_2_9, input_3_9
                },
                new TextBox[]
                {
                    input_4_7, input_5_7, input_6_7, input_4_8, input_5_8, input_6_8, input_4_9, input_5_9, input_6_9
                },
                new TextBox[]
                {
                    input_7_7, input_8_7, input_9_7, input_7_8, input_8_8, input_9_8, input_7_9, input_8_9, input_9_9
                }
            };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sender == inputs[i][j])
                    {
                        try
                        {
                            if (inputs[i][j].Text.Length > 0)
                            {
                                int num = numbers[i][j] = Convert.ToInt32(inputs[i][j].Text);
                                if (!CheckCorrect(j, i, num))
                                {
                                    inputs[i][j].ForeColor = Color.Red;
                                }
                                else
                                    inputs[i][j].ForeColor = Color.Black;
                            }
                            else
                            {
                                numbers[i][j] = 0;
                                inputs[i][j].ForeColor = Color.Black;
                            }
                        }
                        catch
                        {
                            inputs[i][j].Text = null;
                        }
                    }
                }
            }
        }

        private void InputMouseClick(object sender, MouseEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!textBox.ReadOnly)
                    textBox.Text = "";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string minutes_space = "0", seconds_space = "0", minutes_space1 = "0", seconds_space1 = "0";            
            if (!death_time)
            {
                seconds++;
                if (seconds > 59)
                {
                    seconds = 0;
                    minutes++;
                }
            }
            else
            {
                seconds--;
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;
                }
                if (minutes < 0)
                {
                    if (MainMenu.Language)
                        timer_text.Text = $"Время вышло!";
                    else
                        timer_text.Text = $"Time is over!";
                    Start_btn_Click(sender, e);
                }
            }
            _seconds = 60 - seconds;
            if(_seconds > 59)
            {
                _minutes++;
                _seconds = 0;
            }
            if (seconds > 9)
                seconds_space = null;
            if (minutes > 9)
                minutes_space = null;
            if (_seconds > 9)
                seconds_space1 = null;
            if (_minutes > 9)
                minutes_space1 = null;
            if (minutes >= 0)
            {
                if (MainMenu.Language)
                {
                    if (!death_time)
                        timer_text.Text = $"Времени прошло: {minutes_space}{minutes}:{seconds_space}{seconds}";
                    else
                        timer_text.Text = $"Осталось времени: {minutes_space}{minutes}:{seconds_space}{seconds} / {minutes_space1}{_minutes}:{seconds_space1}{_seconds}";
                }
                else
                {
                    if (!death_time)
                        timer_text.Text = $"Time elapsed: {minutes_space}{minutes}:{seconds_space}{seconds}";
                    else
                        timer_text.Text = $"Time left: {minutes_space}{minutes}:{seconds_space}{seconds} / {minutes_space1}{_minutes}:{seconds_space1}{_seconds}";
                }
            }
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Заполняйте поле цифрами от 1 до 9 так, чтобы каждая цифра встречалась только один раз в каждой строке, столбце и малом квадрате 3x3.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Fill the grid with numbers from 1 to 9 so that each number appears only once in each row, column, and 3x3 mini grid.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Sudoku_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox[][] inputs =
            {
                new TextBox[]
                {
                    input_1_1, input_2_1, input_3_1, input_1_2, input_2_2, input_3_2, input_1_3, input_2_3, input_3_3
                },
                new TextBox[]
                {
                    input_4_1, input_5_1, input_6_1, input_4_2, input_5_2, input_6_2, input_4_3, input_5_3, input_6_3
                },
                new TextBox[]
                {
                    input_7_1, input_8_1, input_9_1, input_7_2, input_8_2, input_9_2, input_7_3, input_8_3, input_9_3
                },
                new TextBox[]
                {
                    input_1_4, input_2_4, input_3_4, input_1_5, input_2_5, input_3_5, input_1_6, input_2_6, input_3_6
                },
                new TextBox[]
                {
                    input_4_4, input_5_4, input_6_4, input_4_5, input_5_5, input_6_5, input_4_6, input_5_6, input_6_6
                },
                new TextBox[]
                {
                    input_7_4, input_8_4, input_9_4, input_7_5, input_8_5, input_9_5, input_7_6, input_8_6, input_9_6
                },
                new TextBox[]
                {
                    input_1_7, input_2_7, input_3_7, input_1_8, input_2_8, input_3_8, input_1_9, input_2_9, input_3_9
                },
                new TextBox[]
                {
                    input_4_7, input_5_7, input_6_7, input_4_8, input_5_8, input_6_8, input_4_9, input_5_9, input_6_9
                },
                new TextBox[]
                {
                    input_7_7, input_8_7, input_9_7, input_7_8, input_8_8, input_9_8, input_7_9, input_8_9, input_9_9
                }
            };
            if (e.KeyCode == Keys.Space)
                Start_btn_Click(sender, e);
            else if (e.KeyCode == Keys.Left)
                x--;
            else if (e.KeyCode == Keys.Right)
                x++;
            else if (e.KeyCode == Keys.Up)
                y--;
            else if (e.KeyCode == Keys.Down)
                y++;
            else if (e.KeyCode == Keys.Escape)
                Close();
            if (x < 0)
                x = 8;
            if (x > 8)
                x = 0;
            if (y < 0)
                y = 8;
            if (y > 8)
                y = 0;
            inputs[y][x].Focus();
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                show_settings.Size = new Size(show_settings.Width - 4, show_settings.Height - 4);
                show_settings.Location = new Point(2, show_settings.Top + 2);
            }
        }

        private void Sudoku_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            win?.Dispose();
            game_over?.Dispose();
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                show_settings.Size = new Size(show_settings.Width + 4, show_settings.Height + 4);
                show_settings.Location = new Point(0, show_settings.Top - 2);
            }
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (!timer.Enabled)
            {
                SS_Settings form = new SS_Settings
                {
                    Owner = this
                };
                form.ShowDialog();
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            TextBox[][] inputs =
            {
                new TextBox[]
                {
                    input_1_1, input_2_1, input_3_1, input_1_2, input_2_2, input_3_2, input_1_3, input_2_3, input_3_3
                },
                new TextBox[]
                {
                    input_4_1, input_5_1, input_6_1, input_4_2, input_5_2, input_6_2, input_4_3, input_5_3, input_6_3
                },
                new TextBox[]
                {
                    input_7_1, input_8_1, input_9_1, input_7_2, input_8_2, input_9_2, input_7_3, input_8_3, input_9_3
                },
                new TextBox[]
                {
                    input_1_4, input_2_4, input_3_4, input_1_5, input_2_5, input_3_5, input_1_6, input_2_6, input_3_6
                },
                new TextBox[]
                {
                    input_4_4, input_5_4, input_6_4, input_4_5, input_5_5, input_6_5, input_4_6, input_5_6, input_6_6
                },
                new TextBox[]
                {
                    input_7_4, input_8_4, input_9_4, input_7_5, input_8_5, input_9_5, input_7_6, input_8_6, input_9_6
                },
                new TextBox[]
                {
                    input_1_7, input_2_7, input_3_7, input_1_8, input_2_8, input_3_8, input_1_9, input_2_9, input_3_9
                },
                new TextBox[]
                {
                    input_4_7, input_5_7, input_6_7, input_4_8, input_5_8, input_6_8, input_4_9, input_5_9, input_6_9
                },
                new TextBox[]
                {
                    input_7_7, input_8_7, input_9_7, input_7_8, input_8_8, input_9_8, input_7_9, input_8_9, input_9_9
                }
            };
            top_panel.Focus();
            if (!timer.Enabled)
            {
                square_1.Enabled = square_2.Enabled = square_3.Enabled = square_4.Enabled = square_5.Enabled = square_6.Enabled = square_7.Enabled = square_8.Enabled = square_9.Enabled = true;
                seconds = 0;
                if (!death_time)
                    minutes = 0;
                else
                    minutes = 20 - 5 * difficulty;
                numbers = new int[9][];
                for (int i = 0; i < 9; i++)
                    numbers[i] = new int[9];
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (rand.NextDouble() <= 0.06f && prefill)
                        {
                            int new_num = rand.Next(1, 10);
                            while (!CheckCorrect(j, i, new_num))
                                new_num = rand.Next(1, 10);
                            numbers[i][j] = new_num;
                            inputs[i][j].Text = numbers[i][j].ToString();
                            inputs[i][j].BackColor = Color.LightGray;
                            inputs[i][j].ReadOnly = true;
                            inputs[i][j].Enabled = false;
                        }
                        else
                        {
                            inputs[i][j].BackColor = BackColor;
                            inputs[i][j].Text = null;
                            inputs[i][j].ReadOnly = false;
                            inputs[i][j].Enabled = true;
                        }
                        inputs[i][j].TextChanged += new EventHandler(InputTextChanged);
                        inputs[i][j].MouseClick += new MouseEventHandler(InputMouseClick);
                    }
                }
                if (MainMenu.Language)
                {
                    if (!death_time)
                        timer_text.Text = $"Времени прошло: 00:00";
                    else
                        timer_text.Text = $"Осталось времени: {minutes}:00 / 00:00";
                    start_btn.Text = "СТОП";
                }
                else
                {
                    if (!death_time)
                        timer_text.Text = $"Time elapsed: 00:00";
                    else
                        timer_text.Text = $"Time left: {minutes}:00 / 00:00";
                    start_btn.Text = "STOP";
                }
                inputs[4][4].Focus();
                x = y = 4;
                timer.Start();
            }
            else
            {
                square_1.Enabled = square_2.Enabled = square_3.Enabled = square_4.Enabled = square_5.Enabled = square_6.Enabled = square_7.Enabled = square_8.Enabled = square_9.Enabled = false;
                if (MainMenu.Language)
                    start_btn.Text = "СТАРТ";
                else
                    start_btn.Text = "START";
                timer.Stop();
                bool all_ok = true;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (inputs[i][j].Text == "" || inputs[i][j].ForeColor == Color.Red)
                        {
                            all_ok = false;
                            break;
                        }
                    }
                    if (!all_ok)
                        break;
                }
                if (all_ok)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            inputs[i][j].BackColor = Color.Lime;
                        }
                    }
                    if (MainMenu.sounds)
                        win.Play(1);
                }
                else
                {
                    if (MainMenu.sounds)
                        game_over.Play(1);
                }
                
            }
        }
    }
}