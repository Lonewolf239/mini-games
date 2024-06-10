using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MazeGenerator;
using IniReader;
using System.Diagnostics;

namespace minigames._SLIL
{
    public partial class SLIL : Form
    {
        public SLIL()
        {
            InitializeComponent();
        }

        public static int CustomMazeHeight;
        public static int CustomMazeWidth;
        public static bool SHOW_FINISH = true, CUSTOM = false;
        public static int difficulty = 2, old_difficulty;
        public static double LOOK_SPEED = 1.75f;
        public static string CUSTOM_MAP;
        public static int CUSTOM_X, CUSTOM_Y;
        private static readonly Maze MazeGenerator = new Maze();
        private readonly Random rand = new Random();
        private const int SCREEN_HEIGHT = 228, SCREEN_WIDTH = 450;
        private static int MazeHeight;
        private static int MazeWidth;
        private int MAP_WIDTH;
        private const int START_EASY = 5, START_NORMAL = 10, START_HARD = 15, START_VERY_HARD = 20;
        private const double DEPTH = 8;
        private const double FOV = Math.PI / 3.25f;
        private double player_x = 1.5d, player_y = 1.5d, player_a = 0;
        private const double MOVE_SPEED = 1.75d;
        private double RUN_SPEED = 0;
        private static string MAP = "";
        private readonly Bitmap SCREEN = new Bitmap(SCREEN_WIDTH, SCREEN_HEIGHT);
        private int seconds, minutes, fps;
        private enum Direction { STOP, FORWARD, BACK, LEFT, RIGHT, WALK, RUN };
        private Direction playerDirection = Direction.STOP, strafeDirection = Direction.STOP, playerMoveStyle = Direction.WALK;
        private DateTime total_time = DateTime.Now;
        private List<int> soundIndices = new List<int> { 0, 1, 2, 3, 4};
        private int currentIndex = 0;
        private bool show_finish = true, map_presed = false;
        private map_form form;
        private readonly PlaybackState playbackState = new PlaybackState();
        private PlaySound[] step =
        { 
            new PlaySound(@"sounds\step_0.wav"), 
            new PlaySound(@"sounds\step_1.wav"), 
            new PlaySound(@"sounds\step_2.wav"),
            new PlaySound(@"sounds\step_3.wav"),
            new PlaySound(@"sounds\step_4.wav")
        };
        private readonly PlaySound game_over = new PlaySound(@"sounds\game_over.wav");

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            if (start_btn.Enabled)
                show_settings.Image = Properties.Resources.setting_pressed_btn;
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            if (start_btn.Enabled)
                show_settings.Image = Properties.Resources.setting_btn;
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && start_btn.Enabled)
            {
                SLIL_Settings form = new SLIL_Settings
                {
                    Owner = this
                };
                form.ShowDialog();
            }
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            SLIL_about form = new SLIL_about();
            form.ShowDialog();
        }

        private async void Step_sound_timer_Tick(object sender, EventArgs e)
        {
            if ((playerDirection != Direction.STOP || strafeDirection != Direction.STOP) && !playbackState.IsPlaying)
            {
                if (currentIndex >= soundIndices.Count)
                {
                    soundIndices = soundIndices.OrderBy(x => rand.Next()).ToList();
                    currentIndex = 0;
                }
                int index = soundIndices[currentIndex];
                bool completed = await step[index].PlayWithWait(0.45f, playbackState);
                if (completed)
                    currentIndex++;
            }
        }

        private void Time_remein_Tick(object sender, EventArgs e)
        {
            string space_0 = "0", space_1 = "0";
            seconds--;
            if (seconds < 0)
            {
                if (minutes > 0)
                {
                    minutes--;
                    seconds = 59;
                }
                else
                {
                    seconds = 0;
                    GameOver(0);
                }
            }
            if (seconds > 9)
                space_1 = "";
            if (minutes > 9)
                space_0 = "";
            status_text.Text = $"FPS: {fps} | TIME LEFT: {space_0}{minutes}:{space_1}{seconds}";
        }

        private void SLIL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (stamina_panel.Width >= (int)(275 * MainMenu.scale_size))
                    playerMoveStyle = Direction.RUN;
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                playerDirection = Direction.FORWARD;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                playerDirection = Direction.BACK;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                strafeDirection = Direction.LEFT;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                strafeDirection = Direction.RIGHT;
            if (e.KeyCode == Keys.M || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Space)
            {
                if (!start_btn.Enabled)
                {
                    map_presed = true;
                    if (form != null)
                    {
                        map_timer.Stop();
                        form.Close();
                        form = null;
                        return;
                    }
                    form = new map_form
                    {
                        Left = Right,
                        Top = Top,
                        _MAP = MAP,
                        _MazeHeight = MazeHeight,
                        _MazeWidth = MazeWidth,
                        _player_x = player_x,
                        _player_y = player_y
                    };
                    map_timer.Start();
                    form.Show();
                    Activate();
                }
            }
            if (e.KeyCode == Keys.Space && start_btn.Enabled)
                StartGame();
            if (e.KeyCode == Keys.Escape)
            {
                if (start_btn.Enabled)
                    Close();
                else
                    GameOver(-1);
            }
        }

        private void SLIL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                playerMoveStyle = Direction.WALK;
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up || e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                playerDirection = Direction.STOP;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left || e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                strafeDirection = Direction.STOP;
        }

        private void Map_timer_Tick(object sender, EventArgs e)
        {
            form.Left = Right;
            form.Top = Top;
            form._player_x = player_x;
            form._player_y = player_y;
            form.show_finish = show_finish;
        }

        private void SLIL_LocationChanged(object sender, EventArgs e) => strafeDirection = playerDirection = Direction.STOP;

        private void Mouse_timer_Tick(object sender, EventArgs e)
        {
            Rectangle displayRectangle = new Rectangle
            {
                Location = display.PointToScreen(Point.Empty),
                Width = display.Width,
                Height = display.Height
            };
            Point cursorPosition = Cursor.Position;
            if (!displayRectangle.Contains(cursorPosition))
                Cursor.Position = display.PointToScreen(new Point(display.Width / 2, display.Height / 2));
        }

        private void SLIL_Deactivate(object sender, EventArgs e)
        {
            if (!map_presed)
            {
                strafeDirection = playerDirection = Direction.STOP;
                playerMoveStyle = Direction.WALK;
            }
            map_presed = false;
        }

        private void Stamina_timer_Tick(object sender, EventArgs e)
        {
            if (playerMoveStyle == Direction.RUN && playerDirection == Direction.FORWARD)
            {
                stamina_panel.Visible = true;
                stamina_panel.Width -= (int)(3 * MainMenu.scale_size);
                if (stamina_panel.Width == 0)
                    playerMoveStyle = Direction.WALK;
            }
            else
            {
                stamina_panel.Width += (int)(2 * MainMenu.scale_size);
                if (stamina_panel.Width >= display.Width)
                {
                    stamina_panel.Width = display.Width;
                    stamina_panel.Visible = false;
                }
            }
        }

        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            if (!start_btn.Enabled)
            {
                int x = display.Width / 2;
                int X = e.X - x;
                player_a -= ((X / (double)x) / 10) * LOOK_SPEED;
                Cursor.Position = display.PointToScreen(new Point(x, display.Height / 2));
            }
        }

        private void PlayerMove(double elapsed_time)
        {
            switch (playerMoveStyle)
            {
                case Direction.RUN:
                    if (playerDirection == Direction.FORWARD)
                        RUN_SPEED = 2.25f;
                    else
                        RUN_SPEED = 1;
                    break;
                case Direction.WALK:
                    RUN_SPEED = 1;
                    break;
            }
            double move = MOVE_SPEED * RUN_SPEED * elapsed_time;
            switch (strafeDirection)
            {
                case Direction.LEFT:
                    player_x += Math.Cos(player_a) * move / 1.4f;
                    player_y -= Math.Sin(player_a) * move / 1.4f;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#')
                    {
                        player_x -= Math.Cos(player_a) * move / 1.4f;
                        player_y += Math.Sin(player_a) * move / 1.4f;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '&')
                    {
                        GameOver(1);
                        return;
                    }
                    break;
                case Direction.RIGHT:
                    player_x -= Math.Cos(player_a) * move / 1.4f;
                    player_y += Math.Sin(player_a) * move / 1.4f;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#')
                    {
                        player_x += Math.Cos(player_a) * move / 1.4f;
                        player_y -= Math.Sin(player_a) * move / 1.4f;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '&')
                    {
                        GameOver(1);
                        return;
                    }
                    break;
            }
            switch (playerDirection)
            {
                case Direction.FORWARD:
                    player_x += Math.Sin(player_a) * move;
                    player_y += Math.Cos(player_a) * move;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#')
                    {
                        player_x -= Math.Sin(player_a) * move;
                        player_y -= Math.Cos(player_a) * move;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '&')
                    {
                        GameOver(1);
                        return;
                    }
                    break;
                case Direction.BACK:
                    player_x -= Math.Sin(player_a) * move;
                    player_y -= Math.Cos(player_a) * move;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#')
                    {
                        player_x += Math.Sin(player_a) * move;
                        player_y += Math.Cos(player_a) * move;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '&')
                    {
                        GameOver(1);
                        return;
                    }
                    break;
            }
        }

        private void SLIL_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                    foreach (Control text1 in text.Controls)
                        text1.Font = new Font(text1.Font.FontFamily, text1.Font.Size * MainMenu.scale_size);
                }
                Screen screen = Screen.FromPoint(Cursor.Position);
                developer_name.Left = Width - (developer_name.Width + 12);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            if (!MainMenu.Language)
            {
                Text = "Mazeness";
                start_btn.Text = "START";
            }
            LOOK_SPEED = INIReader.GetDouble(MainMenu.iniFolder, "SLIL", "look_speed", 1.75);
            difficulty = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "difficulty", 1);
            SHOW_FINISH = INIReader.GetBool(MainMenu.iniFolder, "SLIL", "show_finish", true);
            CustomMazeHeight = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "custom_maze_height", 10);
            CustomMazeWidth = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "custom_maze_width", 10);
            if (LOOK_SPEED < 1 || LOOK_SPEED > 4.5d)
                LOOK_SPEED = 1.75d;
            if (difficulty < 0 || difficulty > 4)
                difficulty = 1;
            if (CustomMazeHeight < 2 || CustomMazeHeight > 150)
                CustomMazeHeight = 10;
            if (CustomMazeWidth < 2 || CustomMazeWidth > 150)
                CustomMazeWidth = 10;
            old_difficulty = difficulty;
            Activate();
        }

        private static void InitMap()
        {
            if (!CUSTOM)
            {
                StringBuilder sb = new StringBuilder();
                char[,] map = MazeGenerator.GenerateCharMap(MazeWidth, MazeHeight, '#', '.', '&');
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        try
                        {
                            if (map[x, y] == '.' && map[x + 1, y] == '#' && map[x, y + 1] == '#' && (map[x + 2, y] == '#' || map[x, y + 2] == '#'))
                                map[x, y] = '#';
                        }
                        catch { }
                        sb.Append(map[x, y]);
                    }
                }
                MAP = sb.ToString();
            }
            else
                MAP = CUSTOM_MAP;
        }

        private void SLIL_FormClosing(object sender, FormClosingEventArgs e)
        {
            raycast.Stop();
            time_remein.Stop();
            step_sound_timer.Stop();
            map_timer.Stop();
            stamina_timer.Stop();
            game_over?.Dispose();
            for (int i = 0; i < step.Length; i++)
                step[i]?.Dispose();
            step = null;
            if (form != null)
            {
                form.Close();
                form = null;
            }
        }

        private void Raycast_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            double elapsed_time = (time - total_time).TotalSeconds;
            total_time = DateTime.Now;
            PlayerMove(elapsed_time);
            Color color;
            //Ray Casting
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                double rayA = player_a + FOV / 2 - x * FOV / SCREEN_WIDTH;
                double ray_x = Math.Sin(rayA);
                double ray_y = Math.Cos(rayA);
                double distance = 0;
                bool hit_wall = false;
                bool is_bound = false;
                bool hit_finish = false;
                while (!hit_wall && !hit_finish && distance < DEPTH)
                {
                    distance += 0.1d;
                    int test_x = (int)(player_x + ray_x * distance);
                    int test_y = (int)(player_y + ray_y * distance);
                    if (test_x < 0 || test_x >= DEPTH + player_x || test_y < 0 || test_y >= DEPTH + player_y)
                    {
                        hit_wall = true;
                        distance = DEPTH;
                    }
                    else
                    {
                        char test_wall = MAP[test_y * MAP_WIDTH + test_x];
                        if (test_wall == '#')
                        {
                            hit_wall = true;
                            List<(double module, double cos)> bounds = new List<(double module, double cos)>();
                            for (int tx = 0; tx < 2; tx++)
                            {
                                for (int ty = 0; ty < 2; ty++)
                                {
                                    double vx = test_x + tx - player_x;
                                    double vy = test_y + ty - player_y;
                                    double module_vector = Math.Sqrt(vx * vx + vy * vy);
                                    double cos_a = ray_x * vx / module_vector + ray_y * vy / module_vector;
                                    bounds.Add((module_vector, cos_a));
                                }
                            }
                            bounds = bounds.OrderBy(v => v.module).ToList();
                            double bound_a = 0.03 / distance;
                            if (Math.Acos(bounds[0].cos) < bound_a || Math.Acos(bounds[1].cos) < bound_a)
                                is_bound = true;
                        }
                        else if (test_wall == '&')
                            hit_finish = true;
                    }
                }
                if (is_bound)
                    color = Color.White;
                else if (distance < DEPTH / 4)
                    color = Color.Silver;
                else if (distance < DEPTH / 3)
                    color = Color.DarkGray;
                else if (distance < DEPTH / 2)
                    color = Color.Gray;
                else if (distance < DEPTH)
                    color = Color.DimGray;
                else
                    color = Color.Black;
                int celling = (int)(SCREEN_HEIGHT / 2.25d - (SCREEN_HEIGHT * FOV) / distance);
                int floor = SCREEN_HEIGHT - celling;
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    if (y <= celling)
                        SCREEN.SetPixel(x, y, Color.LightSlateGray);
                    else if (y > celling && y <= floor)
                    {
                        if (!hit_finish)
                            SCREEN.SetPixel(x, y, color);
                        else
                            SCREEN.SetPixel(x, y, Color.Lime);
                    }
                    else
                    {
                        double d = 1 - (y - SCREEN_HEIGHT / 2d) / (SCREEN_HEIGHT / 2d);
                        if (d < 0.25d)
                            SCREEN.SetPixel(x, y, Color.FromArgb(80, 80, 80));
                        else if (d < 0.50d)
                            SCREEN.SetPixel(x, y, Color.FromArgb(60, 60, 60));
                        else if (d < 0.735d)
                            SCREEN.SetPixel(x, y, Color.FromArgb(40, 40, 40));
                        else
                            SCREEN.SetPixel(x, y, Color.Black);
                    }
                }
                fps = (int)(1 / elapsed_time);
            }
            display.Image = SCREEN;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            StartGame();
        }

        private void ResetDefault()
        {
            game_over_text.Visible = question.Enabled = start_btn.Enabled = false;
            int x = display.PointToScreen(Point.Empty).X + (display.Width / 2);
            int y = display.PointToScreen(Point.Empty).Y + (display.Height / 2);
            Cursor.Position = new Point(x, y);
            Cursor.Hide();
            seconds = 0;
            if (!CUSTOM)
                player_x = player_y = 1.5d;
            else
            {
                player_x = CUSTOM_X;
                player_y = CUSTOM_Y;
            }
            player_a = 0;
            stamina_panel.Width = display.Width;
            stamina_panel.Visible = false;
            strafeDirection = playerDirection = Direction.STOP;
            playerMoveStyle = Direction.WALK;
            if (difficulty == 0)
            {
                minutes = START_VERY_HARD;
                MazeHeight = MazeWidth = 25;
                show_finish = false;
            }
            else if (difficulty == 1)
            {
                minutes = START_HARD;
                MazeHeight = MazeWidth = 20;
                show_finish = false;
            }
            else if (difficulty == 2)
            {
                minutes = START_NORMAL;
                MazeHeight = MazeWidth = 15;
                show_finish = SHOW_FINISH;
            }
            else if (difficulty == 3)
            {
                minutes = START_EASY;
                MazeHeight = MazeWidth = 10;
                show_finish = SHOW_FINISH;
            }
            else
            {
                minutes = 9999;
                MazeHeight = CustomMazeHeight;
                MazeWidth = CustomMazeWidth;
                show_finish = SHOW_FINISH;
            }
            MAP_WIDTH = MazeWidth * 3 + 1;
        }

        private void StartGame()
        {
            ResetDefault();
            InitMap();
            string space_0 = "0", space_1 = "0";
            if (seconds > 9)
                space_1 = "";
            if (minutes > 9)
                space_0 = "";
            status_text.Text = $"FPS: {fps} | TIME LEFT: {space_0}{minutes}:{space_1}{seconds}";
            raycast.Start();
            time_remein.Start();
            stamina_timer.Start();
            mouse_timer.Start();
            if (MainMenu.sounds)
                step_sound_timer.Start();
        }

        private void GameOver(int win)
        {
            raycast.Stop();
            time_remein.Stop();
            step_sound_timer.Stop();
            map_timer.Stop();
            stamina_timer.Stop();
            mouse_timer.Stop();
            stamina_panel.Width = display.Width;
            stamina_panel.Visible = false;
            if (form != null)
            {
                form.Close();
                form = null;
            }
            question.Enabled = start_btn.Enabled = true;
            status_text.Text = "";
            if (win == 1)
            {
                if (difficulty > 0 && difficulty != 4)
                    difficulty--;
                StartGame();
            }
            else if(win == 0)
            {
                game_over_text.Visible = true;
                if (MainMenu.sounds)
                    game_over.Play(1);
                difficulty = old_difficulty;
            }
            display.Image = null;
            Cursor.Show();
        }
    }
}