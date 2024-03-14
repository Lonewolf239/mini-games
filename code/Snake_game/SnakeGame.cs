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

namespace minigames.Snake_game
{
    public partial class SnakeGame : Form
    {
        public SnakeGame()
        {
            InitializeComponent();
        }

        private static Random rand = new Random();
        public static int score = 0, max_score = 0;
        private bool cycle_done = false, game_over = false, super_fruit_spawned = false;
        private int x = 3, y = 2, fruit_x, fruit_y, super_fruit_x, super_fruit_y, nTail;
        private int[] tailX = new int[800], tailY = new int[800];
        private enum Direction { STOP = 0, LEFT, RIGHT, UP, DOWN };
        private Direction dir;
        private Control[][] pxs =
        {
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40],
            new Control[40]
        };
        private BorderStyle[] px_border = { BorderStyle.None, BorderStyle.FixedSingle, BorderStyle.Fixed3D };
        private Color[] theme = { Color.Gainsboro, Color.FromArgb(12, 12, 50) };
        private int px_x = 16, px_y = 8, tile_size = 25, logic_interval = 500, px_style = 0, dark_theme = 0;
        public static int new_px_x = 16, new_px_y = 8, new_tile_size = 25, new_logic_interval = 500, new_px_style = 0, new_dark_theme = 0;
        public static bool new_wall_killing = false;
        private bool wall_killing = false;

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (!MainMenu.Language)
                MessageBox.Show("Mini-Snake is a classic game where you have to eat as many apples as possible and become the biggest snake)\n" +
                    "-------------------------------\nControls:\nWASD\\Arrows", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Мини-Змейка — это классическая игра, в которой вам нужно съесть как можно больше яблочек и стать самой большой змеёй)\n" +
                    "-------------------------------\nУправление:\nWASD\\Стрелочки", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            if (start_btn.Enabled)
            {
                show_settings.Size = new Size(36, 36);
                show_settings.Location = new Point(2, 203);
            }
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            if (start_btn.Enabled)
            {
                show_settings.Size = new Size(40, 40);
                show_settings.Location = new Point(0, 201);
            }
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && start_btn.Enabled)
            {
                SG_settings form = new SG_settings();
                form.FormClosing += new FormClosingEventHandler(Settings_Closing);
                form.ShowDialog();
            }
        }

        private void Settings_Closing(object sender, EventArgs e)
        {
            if (SG_settings.accepted)
            {
                px_x = new_px_x;
                px_y = new_px_y; 
                tile_size = new_tile_size;
                logic_interval = new_logic_interval;
                wall_killing = new_wall_killing;
                px_style = new_px_style;
                dark_theme = new_dark_theme;
                Draw_Interface();
            }
            else
            {
                new_px_x = px_x;
                new_px_y = px_y;
                new_tile_size = tile_size;
                new_logic_interval = logic_interval;
                new_wall_killing = wall_killing;
                new_px_style = px_style;
                new_dark_theme = dark_theme;
            }
        }

        private void SnakeGame_Load(object sender, EventArgs e)
        {
            new_px_x = 16;
            new_px_y = 8;
            new_tile_size = 25;
            new_logic_interval = 500;
            new_px_style = 0;
            new_dark_theme = 0;
            max_score = MainMenu.mg7_max_score;
            if (!MainMenu.Language)
            {
                Text = "Mini-Snake";
                start_btn.Text = "START";
                score_text.Text = $"score: 0   max score: {max_score}";
            }
            else
                score_text.Text = $"счёт: 0   макс. счёт: {max_score}";
            Draw_Interface();
        }

        private void Draw_Interface()
        {
            logic.Interval = logic_interval;
            top_panel.Controls.Clear();
            pxs = null;
            pxs = new Control[][]
            {
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40],
                new Control[40]
            };
            Panel[][] px =
            {
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40],
                new Panel[40]
            };
            for (int i = 0; i < px_y; i++)
            {
                for (int j = 0; j < px_x; j++)
                {
                    px[i][j] = new Panel
                    {
                        Size = new Size(tile_size, tile_size),
                        Location = new Point(j * tile_size, i * tile_size),
                        BackColor = theme[dark_theme],
                        BorderStyle = px_border[px_style],
                        Name = $"px_{i}_{j}"
                    };
                    pxs[i][j] = px[i][j];
                    top_panel.Controls.Add(px[i][j]);
                }
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            game_over = false;
            score = nTail = 0;
            x = rand.Next(0, px_x);
            y = rand.Next(0, px_y);
            do
            {
                fruit_x = rand.Next(0, px_x);
                fruit_y = rand.Next(0, px_y);
            } while (x != fruit_x && y != fruit_y);
            tailX = tailY = null;
            tailY =  new int[800];
            tailX = new int[800];
            dir = Direction.STOP;
            if (!MainMenu.Language)
                score_text.Text = $"score: {score}   max score: {max_score}";
            else
                score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
            top_panel.Focus();
            start_btn.Enabled = question.Enabled = false;
            logic.Start();
        }

        private void Logic_Tick(object sender, EventArgs e)
        {
            cycle_done = true;
            int prev_x = tailX[0], prev_y = tailY[0], prev2_x, prev2_y;
            tailX[0] = x;
            tailY[0] = y;
            if (!game_over)
            {
                if (dir == Direction.UP)
                    y--;
                else if (dir == Direction.DOWN)
                    y++;
                else if (dir == Direction.LEFT)
                    x--;
                else if (dir == Direction.RIGHT)
                    x++;
                if (!wall_killing)
                {
                    if (x > px_x - 1)
                        x = 0;
                    else if (x < 0)
                        x = px_x - 1;
                    else if (y > px_y - 1)
                        y = 0;
                    else if (y < 0)
                        y = px_y - 1;
                }
                else
                {
                    if (x > px_x - 1 || x < 0 || y > px_y - 1 || y < 0)
                        game_over = true;
                    if (x > px_x - 1)
                        x = px_x - 1;
                    else if (x < 0)
                        x = 0;
                    else if (y > px_y - 1)
                        y = px_y - 1;
                    else if (y < 0)
                        y = 0;
                }
            }
            Draw_Snake(game_over);
            if (game_over)
                logic.Stop();
            if (x == fruit_x && y == fruit_y)
            {
                bool not_eated = true;
                nTail++;
                score++;
                if (super_fruit_spawned)
                    not_eated = super_fruit_spawned = false;
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                fruit_x = rand.Next(0, px_x);
                fruit_y = rand.Next(0, px_y);
                do
                {
                    if (x == fruit_x && y == fruit_y)
                    {
                        fruit_x = rand.Next(0, px_x);
                        fruit_y = rand.Next(0, px_y);
                    }
                    else
                    {
                        for (int k = 0; k < nTail;)
                        {
                            if (tailX[k] == fruit_x && tailY[k] == fruit_y)
                            {
                                fruit_x = rand.Next(0, px_x);
                                fruit_y = rand.Next(0, px_y);
                            }
                            else
                                k++;
                        }
                        break;
                    }
                }
                while (true);
                if ((float)rand.Next(0, 100) / 100 <= 0.15f && not_eated)
                {
                    super_fruit_x = rand.Next(0, px_x);
                    super_fruit_y = rand.Next(0, px_y);
                    do
                    {
                        if (x == super_fruit_x && y == super_fruit_y)
                        {
                            super_fruit_x = rand.Next(0, px_x);
                            super_fruit_y = rand.Next(0, px_y);
                        }
                        else
                        {
                            for (int k = 0; k < nTail;)
                            {
                                if (tailX[k] == super_fruit_x && tailY[k] == super_fruit_y)
                                {
                                    super_fruit_x = rand.Next(0, px_x);
                                    super_fruit_y = rand.Next(0, px_y);
                                }
                                else
                                    k++;
                            }
                            break;
                        }
                    }
                    while (true);
                    super_fruit_spawned = true;
                }
            }
            if (x == super_fruit_x && y == super_fruit_y && super_fruit_spawned)
            {
                nTail++;
                score += 10;
                super_fruit_spawned = false;
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
            }
            for (int i = 0; i <= nTail; i++)
            {
                prev2_x = tailX[i];
                prev2_y = tailY[i];
                tailX[i] = prev_x;
                tailY[i] = prev_y;
                prev_x = prev2_x;
                prev_y = prev2_y;
            }
            for (int i = 1; i <= nTail; i++)
            {
                if (x == tailX[i] && tailY[i] == y)
                {
                    game_over = true;
                    break;
                }
            }
        }

        private void Draw_Snake(bool game_over)
        {
            Color head = Color.Lime;
            Color snake = Color.LightGreen;
            if (game_over)
            {
                head = Color.Tomato;
                snake = Color.LightCoral;
                Game_Over();
            }
            for (int i = 0; i < px_y; i++)
            {
                for (int j = 0; j < px_x; j++)
                {
                    if (x == j && y == i)
                        pxs[i][j].BackColor = head;
                    else if (fruit_x == j && fruit_y == i && !game_over)
                        pxs[i][j].BackColor = Color.Tomato;
                    else if (super_fruit_x == j && super_fruit_y == i && !game_over && super_fruit_spawned)
                        pxs[i][j].BackColor = Color.Purple;
                    else
                    {
                        bool print = false;
                        for (int k = 0; k < nTail; k++)
                        {
                            if (tailX[k] == j && tailY[k] == i)
                            {
                                print = true;
                                pxs[i][j].BackColor = snake;
                            }
                        }
                        if (!print)
                            pxs[i][j].BackColor = theme[dark_theme];
                    }
                }
            }
        }

        private void SnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (cycle_done)
            {
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    if (dir == Direction.RIGHT)
                        return;
                    dir = Direction.LEFT;
                }
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    if (dir == Direction.LEFT)
                        return;
                    dir = Direction.RIGHT;
                }
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                {
                    if (dir == Direction.UP)
                        return;
                    dir = Direction.DOWN;
                }
                else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                {
                    if (dir == Direction.DOWN)
                        return;
                    dir = Direction.UP;
                }
                cycle_done = false;
            }
        }

        private void Game_Over()
        {
            start_btn.Enabled = question.Enabled = true;
            if (score > max_score)
                max_score = score;
            if (!MainMenu.Language)
                score_text.Text = $"score: {score}   max score: {max_score}";
            else
                score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
        }
    }
}