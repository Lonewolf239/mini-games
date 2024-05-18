using IniReader;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._Tetris
{
    public partial class Tetris : Form
    {
        public Tetris()
        {
            InitializeComponent();
        }

        private readonly Random rand = new Random();
        private readonly Panel[][] playing_field = new Panel[20][];
        private readonly Image[] figures_list =
        { 
            Properties.Resources.figure_0, Properties.Resources.figure_1,
            Properties.Resources.figure_2, Properties.Resources.figure_3,
            Properties.Resources.figure_4, Properties.Resources.figure_5,
            Properties.Resources.figure_6, Properties.Resources.figure_7 
        };
        private int[][] field_fullness = new int[20][];
        private readonly int[][] figures =
        { 
            new int[]
            {
                1, 5,
                1, 4,
                0, 4,
                0, 5
            },
            new int[]
            {
                3, 4,
                2, 4,
                1, 4,
                0, 4
            },
            new int[]
            {
                2, 5,
                2, 4,
                1, 5,
                0, 5
            },
            new int[]
            {
                2, 5,
                2, 4,
                1, 4,
                0, 4
            },
            new int[]
            {
                1, 6,
                1, 5,
                0, 5,
                0, 4
            },
            new int[]
            {
                2, 5,
                1, 5,
                1, 4,
                0, 4
            },
            new int[]
            {
                1, 6,
                1, 5,
                1, 4,
                0, 5
            },
            new int[]
            {
                2, 5,
                1, 5,
                1, 4,
                0, 5
            },
        };
        private readonly int[] px_coordinates = new int[8];
        public static int score = 0, max_score = 0, difficult_chooce = 0;
        private int next_figure, current_figure;
        private int faling_pause = 800;
        private int[] difficult = { 800, 400, 200 };
        private enum Direction { NONE, LEFT, RIGHT };
        private Direction player;

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            T_about form = new T_about
            {
                Owner = this
            };
            form.ShowDialog();
        }

        private void Tetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            refresh_timer.Stop();
            logic_timer.Stop();
            falling_tiles_timer.Stop();
            move_tiles.Stop();
        }

        private void Tetris_Load(object sender, EventArgs e)
        {
            difficult_chooce = INIReader.GetInt(MainMenu.iniFolder, "Tetris", "difficulty");
            if (difficult_chooce < 0 || difficult_chooce > 2)
                difficult_chooce = 0;
            for (int i = 0; i < playing_field.Length; i++)
            {
                playing_field[i] = new Panel[10];
                for (int j = 0; j < playing_field[i].Length; j++)
                {
                    Panel panel = new Panel
                    {
                        Left = 16 * j,
                        Top = 16 * i,
                        Width = 15,
                        Height = 15,
                        BorderStyle = BorderStyle.FixedSingle,
                        Name = $"px_{i}_{j}"
                    };
                    playing_field[i][j] = panel;
                    game_interface.Controls.Add(panel);
                }
            }
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                    foreach (Control text1 in text.Controls)
                        text1.Font = new Font(text1.Font.FontFamily, text1.Font.Size * MainMenu.scale_size);
                }
                developer_name.Left = Width - (developer_name.Width + 12);
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            score = 0;
            max_score = MainMenu.mg13_max_score;
            score_text.Text = $"score:\n{score}\nmax score:\n{max_score}";
            if (!MainMenu.Language)
            {
                Text = "Tetris";
                start_btn.Text = "START";
            }
            Activate();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            StartGame();
        }

        private void StartGame()
        {
            game_over_text.Visible = question.Enabled = start_btn.Enabled = false;
            player = Direction.NONE;
            field_fullness = null;
            field_fullness = new int[20][];
            for (int i = 0; i < playing_field.Length; i++)
                field_fullness[i] = new int[10];
            next_figure = rand.Next(8);
            CreateFigure();
            faling_pause = falling_tiles_timer.Interval = difficult[difficult_chooce];
            refresh_timer.Start();
            logic_timer.Start();
            falling_tiles_timer.Start();
            move_tiles.Start();
        }

        private void Logic_timer_Tick(object sender, EventArgs e)
        {
            bool need_disposed;
            int deleted = 0;
            for (int i = playing_field.Length - 1; i >= 0; i--)
            {
                need_disposed = true;
                for (int j = 0; j < playing_field[i].Length; j++)
                {
                    if (field_fullness[i][j] != 1)
                    {
                        need_disposed = false;
                        break;
                    }
                }
                if (need_disposed)
                {
                    deleted++;
                    if (falling_tiles_timer.Interval > 250)
                    {
                        faling_pause -= 15;
                        falling_tiles_timer.Interval = faling_pause;
                    }
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < playing_field[k].Length; j++)
                        {
                            if (field_fullness[k][j] == 1)
                                field_fullness[k][j] = field_fullness[k - 1][j];
                        }
                    }
                    for (int j = 0; j < playing_field[0].Length; j++)
                        field_fullness[0][j] = 0;
                    i++;
                }
            }
            if (deleted > 0)
                score += deleted * 10;
            for (int j = 0; j < playing_field[0].Length; j++)
            {
                if (field_fullness[0][j] == 1)
                {
                    GameOver();
                    return;
                }
            }
        }

        private void Refresh_timer_Tick(object sender, EventArgs e)
        {
            next_figure_picture.Image = figures_list[next_figure];
            score_text.Text = $"score:\n{score}\nmax score:\n{max_score}";
            for (int i = 0; i < field_fullness.Length; i++)
            {
                for (int j = 0; j < field_fullness[i].Length; j++)
                {
                    for (int k = 0; k < px_coordinates.Length; k += 2)
                    {
                        field_fullness[px_coordinates[k]][px_coordinates[k + 1]] = 2;
                        if (field_fullness[i][j] != 1)
                            field_fullness[i][j] = 0;
                    }
                }
            }
            for (int i = 0; i < field_fullness.Length; i++)
            {
                for (int j = 0; j < field_fullness[i].Length; j++)
                {
                    if (field_fullness[i][j] == 1)
                        playing_field[i][j].BackColor = Color.DarkGray;
                    else if (field_fullness[i][j] == 2)
                        playing_field[i][j].BackColor = Color.Gainsboro;
                    else
                        playing_field[i][j].BackColor = Color.FromArgb(12, 12, 50);
                }
            }
        }

        private void CreateFigure()
        {
            current_figure = next_figure;
            for (int i = 0; i < 8; i++)
                px_coordinates[i] = figures[current_figure][i];
            for (int i = 0; i < 8; i += 2)
                field_fullness[px_coordinates[i]][px_coordinates[i + 1]] = 2;
            next_figure = rand.Next(8);
        }

        private void Falling_tiles_timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < px_coordinates.Length; i += 2)
            {
                if (field_fullness[px_coordinates[i]][px_coordinates[i + 1]] != 1)
                {
                    int y = px_coordinates[i];
                    int x = px_coordinates[i + 1];
                    try
                    {
                        if (y == playing_field.Length - 1 || field_fullness[y + 1][x] == 1)
                        {
                            for (int j = 0; j < px_coordinates.Length; j += 2)
                                field_fullness[px_coordinates[j]][px_coordinates[j + 1]] = 1;
                            score += 1;
                            CreateFigure();
                            return;
                        }
                    }
                    catch { }
                }
            }
            for (int i = 0; i < px_coordinates.Length; i += 2)
                px_coordinates[i]++;
        }

        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (!start_btn.Enabled)
            {
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                    player = Direction.LEFT;
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                    player = Direction.RIGHT;
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                    falling_tiles_timer.Interval = 100;
                else if (e.KeyCode == Keys.Space)
                {
                    if (current_figure != 0)
                    {
                        int centerY = px_coordinates[0], centerX = px_coordinates[1];
                        int[] newCoordinates = new int[8];
                        for (int i = 0; i < px_coordinates.Length; i += 2)
                        {
                            int y = px_coordinates[i] - centerY, x = px_coordinates[i + 1] - centerX, newY = -x, newX = y;
                            newCoordinates[i] = newY + centerY;
                            newCoordinates[i + 1] = newX + centerX;
                            if (newCoordinates[i] < 0 || newCoordinates[i] >= playing_field.Length || newCoordinates[i + 1] < 0 || newCoordinates[i + 1] >= playing_field[0].Length || field_fullness[newCoordinates[i]][newCoordinates[i + 1]] == 1)
                                return;
                        }
                        for (int i = 0; i < px_coordinates.Length; i += 2)
                            field_fullness[px_coordinates[i]][px_coordinates[i + 1]] = 0;
                        Array.Copy(newCoordinates, px_coordinates, 8);
                        for (int i = 0; i < px_coordinates.Length; i += 2)
                            field_fullness[px_coordinates[i]][px_coordinates[i + 1]] = 2;
                    }
                }
                if (e.KeyCode == Keys.Escape)
                    GameOver();
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                    Close();
                if (e.KeyCode == Keys.Space)
                    StartGame();
            }
        }

        private void Move_tiles_Tick(object sender, EventArgs e)
        {
            bool touched_left_edge = false, touched_right_edge = false;
            for (int i = 0; i < px_coordinates.Length; i += 2)
            {
                int y = px_coordinates[i];
                int x = px_coordinates[i + 1];
                try
                {
                    if ((x == 0 || field_fullness[y][x - 1] == 1) && player == Direction.LEFT)
                    {
                        touched_left_edge = true;
                        break;
                    }
                    if ((x == field_fullness[y].Length - 1 || field_fullness[y][x + 1] == 1) && player == Direction.RIGHT)
                    {
                        touched_right_edge = true;
                        break;
                    }
                }
                catch { }
            }
            for (int i = 0; i < px_coordinates.Length; i += 2)
            {
                switch (player)
                {
                    case Direction.LEFT:
                        if (!touched_left_edge)
                            px_coordinates[i + 1]--;
                        break;
                    case Direction.RIGHT:
                        if (!touched_right_edge)
                            px_coordinates[i + 1]++;
                        break;
                }
            }
        }

        private void Tetris_KeyUp(object sender, KeyEventArgs e)
        {
            if (!start_btn.Enabled)
            {
                if (((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && player == Direction.LEFT) ||
                    ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && player == Direction.RIGHT))
                    player = Direction.NONE;
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                    falling_tiles_timer.Interval = faling_pause;
            }
        }

        private void GameOver()
        {
            game_over_text.Visible = question.Enabled = start_btn.Enabled = true;
            refresh_timer.Stop();
            logic_timer.Stop();
            falling_tiles_timer.Stop();
            if (score > max_score)
                MainMenu.mg13_max_score = max_score = score;
            score = 0;
            score_text.Text = $"score:\n{score}\nmax score:\n{max_score}";
        }
    }
}