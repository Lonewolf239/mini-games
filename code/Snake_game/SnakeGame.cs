using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace minigames.Snake_game
{
    public partial class SnakeGame : Form
    {
        public SnakeGame()
        {
            InitializeComponent();
        }

        private PlaySound ost, sound;
        private static readonly Random rand = new Random();
        public static int score = 0, max_score = 0;
        private bool cycle_done = false, game_over = false, super_fruit_spawned = false, super_puper_fruit_spawned = false, can_tp = false, teleported = false, in_game = false;
        private int x = 3, y = 2, fruit_x, fruit_y, super_fruit_x, super_fruit_y, super_puper_fruit_x, super_puper_fruit_y, nTail;
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
        private readonly BorderStyle[] px_border = { BorderStyle.None, BorderStyle.FixedSingle, BorderStyle.Fixed3D };
        private readonly Color[] theme = { Color.Gainsboro, Color.FromArgb(12, 12, 50) };
        private int px_x = 16, px_y = 8, tile_size = 25, logic_interval = 500, px_style = 0, dark_theme = 0;
        public static int new_px_x = 16, new_px_y = 8, new_tile_size = 25, new_logic_interval = 500, new_px_style = 0, new_dark_theme = 0;

        private void SnakeGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            ost?.Dispose();
            sound?.Dispose();
            logic.Stop();
        }

        public static bool new_wall_killing = false;
        private bool wall_killing = false;

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (!MainMenu.Language)
                MessageBox.Show("\"Mini-Snake\" is a classic game, where your goal is to eat as many apples as possible and become the biggest snake.\n" +
                    "-------------------------------\nControls:\nUse WASD or arrow keys to control the snake.\n" +
                    "-------------------------------\nTypes of fruits:" +
                    "\n- Red: regular fruit, adds 1 point when eaten." +
                    "\n- Violet: super-fruit, adds 10 points when eaten." +
                    "\n- Blue: Distorted fruits, when eaten, are worth 2 points and allow you to teleport to the mouse cursor.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("\"Мини-Змейка\" - это классическая игра, в которой ваша задача состоит в том, чтобы съесть как можно больше яблок и стать самой большой змеей.\n" +
                    "-------------------------------\nУправление:\nИспользуйте клавиши WASD или стрелки для управления змейкой.\n" +
                    "-------------------------------\nВиды фруктов:" +
                    "\n- Красные: обычные фрукты, при съедении приносят 1 очко." +
                    "\n- Фиолетовые: супер-фрукты, каждый из которых приносит 10 очков." +
                    "\n- Синие: искаженные фрукты, при съедении приносят 2 очка и позволяют телепортироваться к курсору мыши.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            if (!in_game)
            {
                show_settings.Size = new Size(show_settings.Width - 4, show_settings.Height - 4);
                show_settings.Location = new Point(2, show_settings.Top + 2);
            }
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            if (!in_game)
            {
                show_settings.Size = new Size(show_settings.Width + 4, show_settings.Height + 4);
                show_settings.Location = new Point(0, show_settings.Top - 2);
            }
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !in_game)
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
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    if (text is Button)
                        text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                    else
                        text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                }
                developer_name.Left = Width - developer_name.Width - 12;
                developer_name.Top += 4;
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            Activate();
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
                    px[i][j].MouseClick += new MouseEventHandler(Tile_Clicked);
                    pxs[i][j] = px[i][j];
                    if (MainMenu.scaled)
                        pxs[i][j].Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                    top_panel.Controls.Add(px[i][j]);
                }
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            Start_Game();
        }

        private void Start_Game()
        {
            if (!in_game)
            {
                game_over = false;
                in_game = true;
                score = nTail = 0;
                x = rand.Next(0, px_x);
                y = rand.Next(0, px_y);
                do
                {
                    fruit_x = rand.Next(0, px_x);
                    fruit_y = rand.Next(0, px_y);
                } while (x == fruit_x && y == fruit_y);
                tailX = tailY = null;
                tailY = new int[800];
                tailX = new int[800];
                dir = Direction.STOP;
                if (!MainMenu.Language)
                {
                    start_btn.Text = "STOP";
                    score_text.Text = $"score: {score}   max score: {max_score}";
                }
                else
                {
                    start_btn.Text = "СТОП";
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                }
                question.Enabled = false;
                logic.Start();
                if (MainMenu.sounds)
                {
                    ost?.Dispose();
                    ost = new PlaySound(@"sounds\snake_game_ost.wav");
                    ost.LoopPlay(0.4f);
                }
            }
            else
            {

                if (!MainMenu.Language)
                    start_btn.Text = "START";
                else
                    start_btn.Text = "СТАРТ";
                in_game = false;
                game_over = true;
            }
        }

        private void Spawn_Fruit(bool spawn_supers)
        {
            if (spawn_supers)
            {
                double posibly = rand.NextDouble();
                if (posibly <= 0.20f)
                {
                    super_fruit_x = rand.Next(0, px_x);
                    super_fruit_y = rand.Next(0, px_y);
                    super_fruit_spawned = true;
                }
                else if (posibly > 0.20f && posibly <= 0.45f && !can_tp)
                {
                    super_puper_fruit_x = rand.Next(0, px_x);
                    super_puper_fruit_y = rand.Next(0, px_y);
                    super_puper_fruit_spawned = true;
                }
            }
            fruit_x = rand.Next(0, px_x);
            fruit_y = rand.Next(0, px_y);
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
            if (game_over)
                can_tp = false;
            Draw_Snake(game_over);
            teleported = false;
            if (game_over)
                logic.Stop();
            if (x == fruit_x && y == fruit_y)
            {
                bool eated = true;
                nTail++;
                score++;
                if (MainMenu.sounds)
                {
                    sound = new PlaySound(@"sounds\apple.wav");
                    sound.Play(0.4f);
                }
                if (super_fruit_spawned)
                    eated = super_fruit_spawned = false;
                else if (super_puper_fruit_spawned)
                    eated = super_puper_fruit_spawned = false;
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                Spawn_Fruit(eated);
            }
            else if (x == super_fruit_x && y == super_fruit_y && super_fruit_spawned)
            {
                nTail++;
                score += 10;
                super_fruit_spawned = false;
                if (MainMenu.sounds)
                {
                    sound = new PlaySound(@"sounds\apple.wav");
                    sound.Play(0.4f);
                }
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                Spawn_Fruit(false);
            }
            else if (x == super_puper_fruit_x && y == super_puper_fruit_y && super_puper_fruit_spawned)
            {
                nTail++;
                score+=2;
                can_tp = true;
                super_puper_fruit_spawned = false;
                if (MainMenu.sounds)
                {
                    sound = new PlaySound(@"sounds\apple.wav");
                    sound.Play(0.4f);
                }
                if (!MainMenu.Language)
                    score_text.Text = $"score: {score}   max score: {max_score}";
                else
                    score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
                Spawn_Fruit(false);
            }
            for (int i = 0; i <= nTail; i++)
            {
                prev2_x = tailX[i]; prev2_y = tailY[i];
                tailX[i] = prev_x; tailY[i] = prev_y;
                prev_x = prev2_x; prev_y = prev2_y;
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
            Color head = Color.FromArgb(0, 255, 0);
            Color snake = Color.FromArgb(144, 238, 144);
            if (game_over)
            {
                head = Color.Tomato;
                snake = Color.LightCoral;
                Game_Over();
            }
            if (can_tp)
            {
                head = Color.FromArgb(82, 135, 158);
                snake = Color.FromArgb(72, 119, 136);
            }
            for (int i = 0; i < px_y; i++)
            {
                for (int j = 0; j < px_x; j++)
                {
                    if (can_tp)
                        pxs[i][j].Cursor = Cursors.Hand;
                    else
                        pxs[i][j].Cursor = Cursors.Default;
                    if (x == j && y == i)
                        pxs[i][j].BackColor = head;
                    else if (fruit_x == j && fruit_y == i && !game_over)
                        pxs[i][j].BackColor = Color.Tomato;
                    else if (super_fruit_x == j && super_fruit_y == i && !game_over && super_fruit_spawned)
                        pxs[i][j].BackColor = Color.Purple;
                    else if (super_puper_fruit_x == j && super_puper_fruit_y == i && !game_over && super_puper_fruit_spawned)
                        pxs[i][j].BackColor = Color.Navy;
                    else if (pxs[i][j].BackColor == Color.Orange || pxs[i][j].BackColor == Color.LightBlue)
                    {
                        bool print = false;
                        for (int k = 0; k < nTail; k++)
                        {
                            if ((tailX[k] == j && tailY[k] == i) || (x == j && x == i) || teleported)
                                print = true;
                        }
                        if (print)
                            continue;
                        else
                            pxs[i][j].BackColor = theme[dark_theme];
                    }
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
                else if (e.KeyCode == Keys.Space)
                {
                    if (start_btn.Enabled)
                        Start_Game();
                }
                cycle_done = false;
            }
        }

        private void Tile_Clicked(object sender, MouseEventArgs e)
        {
            if (can_tp && !game_over)
            {
                for (int i = 0; i < px_y; i++)
                {
                    for (int j = 0; j < px_x; j++)
                    {
                        if (sender == pxs[i][j])
                        {
                            PlaySound tp = new PlaySound(@"sounds\tp.wav");
                            tp.Play(0.5f);
                            pxs[y][x].BackColor = theme[dark_theme];
                            pxs[tailY[1]][tailX[1]].BackColor = Color.Orange;
                            x = j; y = i;
                            pxs[y][x].BackColor = Color.Lime;
                            pxs[i][j].BackColor = Color.LightBlue;
                            can_tp = false;
                            teleported = true;
                            break;
                        }
                    }
                }
            }
        }

        private void Game_Over()
        {
            ost?.Dispose();
            question.Enabled = true;
            if (score > max_score)
                max_score = score;
            if (!MainMenu.Language)
                score_text.Text = $"score: {score}   max score: {max_score}";
            else
                score_text.Text = $"счёт: {score}   макс. счёт: {max_score}";
        }
    }
}