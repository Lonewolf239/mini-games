﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MazeGenerator;
using IniReader;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Convert_Bitmap;
using System.IO;

namespace minigames._SLIL
{
    public partial class SLIL : Form
    {
        private bool isCursorVisible = true;
        public static int CustomMazeHeight;
        public static int CustomMazeWidth;
        public static bool CUSTOM = false, ShowFPS = true;
        public static int difficulty = 1, old_difficulty;
        private int inDebug = 0;
        public static double LOOK_SPEED = 1.75f;
        public static StringBuilder CUSTOM_MAP = new StringBuilder();
        public static int CUSTOM_X, CUSTOM_Y;
        private static readonly Maze MazeGenerator = new Maze();
        private readonly Random rand = new Random();
        private readonly int[] SCREEN_HEIGHT = { 128, 128 * 2 }, SCREEN_WIDTH = { 228, 228 * 2 };
        public static int resolution = 0;
        private static int MazeHeight;
        private static int MazeWidth;
        private int MAP_WIDTH, MAP_HEIGHT;
        private const int START_EASY = 5, START_NORMAL = 10, START_HARD = 15, START_VERY_HARD = 20;
        private const double DEPTH = 8;
        private const double FOV = Math.PI / 3;
        private double elapsed_time = 0;
        private const double MOVE_SPEED = 1.75d;
        private double RUN_SPEED = 0;
        private static double enemy_count;
        private static StringBuilder MAP = new StringBuilder();
        private static readonly StringBuilder DISPLAYED_MAP = new StringBuilder();
        private Bitmap SCREEN, WEAPON, BUFFER;
        private readonly Font[] consolasFont = { new Font("Consolas", 9.75F), new Font("Consolas", 16F), new Font("Consolas", 22F) };
        private readonly SolidBrush whiteBrush = new SolidBrush(Color.White);
        private readonly StringFormat rightToLeft = new StringFormat() { FormatFlags = StringFormatFlags.DirectionRightToLeft };
        private Graphics graphicsWeapon;
        private int seconds, minutes, fps;
        private enum Direction { STOP, FORWARD, BACK, LEFT, RIGHT, WALK, RUN };
        private Direction playerDirection = Direction.STOP, strafeDirection = Direction.STOP, playerMoveStyle = Direction.WALK;
        private DateTime total_time = DateTime.Now;
        private List<int> soundIndices = new List<int> { 0, 1, 2, 3, 4 };
        private int currentIndex = 0;
        private bool map_presed = false, active = true;
        private bool Paused = false;
        private Map_form form;
        private readonly PlaybackState playbackState = new PlaybackState();
        private readonly TextureCache textureCache;
        private PlaySound[,] step =
        {
            {
                new PlaySound(MainMenu.CGFReader.GetFile("step_0.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_1.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_2.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_3.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_4.wav"), false)
            },
            {
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_0.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_1.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_2.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_3.wav"), false),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_4.wav"), false)
            },
        };
        private static PlaySound[] ost;
        private PlaySound[] enemy_die =
        {
            new PlaySound(MainMenu.CGFReader.GetFile("enemy_die_0.wav"), false),
            new PlaySound(MainMenu.CGFReader.GetFile("enemy_die_1.wav"), false),
            new PlaySound(MainMenu.CGFReader.GetFile("enemy_die_2.wav"), false)
        };
        private readonly PlaySound game_over = new PlaySound(MainMenu.CGFReader.GetFile("game_over.wav"), false),
            draw = new PlaySound(MainMenu.CGFReader.GetFile("draw.wav"), false),
            buy = new PlaySound(MainMenu.CGFReader.GetFile("buy.wav"), false),
            hit = new PlaySound(MainMenu.CGFReader.GetFile("hit_player.wav"), false),
            wall = new PlaySound(MainMenu.CGFReader.GetFile("wall_interaction.wav"), false),
            tp = new PlaySound(MainMenu.CGFReader.GetFile("tp.wav"), false),
            screenshot = new PlaySound(MainMenu.CGFReader.GetFile("screenshot.wav"), false);
        private PlaySound[] door = { new PlaySound(MainMenu.CGFReader.GetFile("door_opened.wav"), false), new PlaySound(MainMenu.CGFReader.GetFile("door_closed.wav"), false) };
        //7x7
        private const string bossMap = "#########################...............##F###.................####..##...........##..###...=...........=...###...=.....E.....=...###...................###...................###.........#.........###...##.........##...###....#.........#....###...................###..#...##.#.##...#..####.....#.....#.....######...............##############D####################...#################E=...=E#################...#################$D.P.D$#################...################################",
            debugMap = @"####################.................##..=======........##..=.....=.....#..##..=....E=........##..=..====........##..=..=........D..##..=.E=...........##..====...........##........P.....=..##.................##.................##..............F..##.................##..===....#D#..#..##..=E=====#$#.#D=.##..===....###..=..##.................####################";
        public static float Volume = 0.4f;
        private static int MAX_SHOP_COUNT = 1;
        private const int WEAPONS_COUNT = 7;
        private int burst_shots = 0, reload_frames = 0;
        public static int ost_index = 0;
        private Image scope_hit = null;
        private readonly Image[] scope =
        { 
            Properties.Resources.scope,
            Properties.Resources.scope_cross,
            Properties.Resources.scope_line,
            Properties.Resources.scope_dot,
            Properties.Resources.scope_null 
        };
        private readonly Image[] scope_shotgun =
        { 
            Properties.Resources.scope_shotgun,
            Properties.Resources.scope_cross,
            Properties.Resources.scope_line,
            Properties.Resources.scope_dot,
            Properties.Resources.scope_null 
        };
        public static int scope_color = 0, scope_type = 0;
        public static bool FullScreen = false;
        private bool open_shop = false, pressed_r = false, pressed_h = false;
        private Display display;
        private readonly Gun[] GUNS = { new Flashlight(), new Knife(), new Pistol(), new Shotgun(), new SubmachineGun(), new AssaultRifle(), new SniperRifle(), new Fingershot(), new TSPitW(), new FirstAidKit() };
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        private readonly Player player = new Player();
        private ConsolePanel console_panel;
        private readonly char[] impassibleCells  = { '#', 'D', '=' };
        private const double playerWidth = 0.4;

        public SLIL(TextureCache textures)
        {
            InitializeComponent();
            textureCache = textures;
        }

        //private struct Sprite
        //{
        //    double x;
        //    double y;
        //    int texture;
        //}

        private void Settings_FormClosing(object sender, FormClosingEventArgs e) => UpdateBitmap();

        private void Chill_timer_Tick(object sender, EventArgs e) => chill_timer.Stop();

        private void Shop_panel_VisibleChanged(object sender, EventArgs e) => shop_panel.BringToFront();

        private void Stage_timer_Tick(object sender, EventArgs e) => stage_timer.Stop();

        public static void SetVolume() => ost[ost_index].SetVolume(Volume);

        private void SLIL_Activated(object sender, EventArgs e) => active = true;

        private void Pause_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            Pause();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            GameOver(-1);
        }

        public static void GoDebug(SLIL slil, int debug)
        {
            slil.GameOver(-1);
            slil.inDebug = debug;
            old_difficulty = difficulty;
            difficulty = 5;
            slil.StartGame();
        }

        public static void ChangeOst(int index)
        {
            ost[ost_index]?.Stop();
            ost_index = index;
            ost[ost_index].LoopPlay(Volume);
        }

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
                form.FormClosing += new FormClosingEventHandler(Settings_FormClosing);
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
                int i = playerMoveStyle == Direction.RUN ? 1 : 0;
                int j = soundIndices[currentIndex];
                bool completed = await step[i, j].PlayWithWait(Volume, playbackState);
                if (completed)
                    currentIndex++;
            }
        }

        private void Time_remein_Tick(object sender, EventArgs e)
        {
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
        }

        private void Status_refresh_Tick(object sender, EventArgs e)
        {
            if (!raycast.Enabled && display.SCREEN != null)
                display.SCREEN = null;
            bool shouldShowCursor = start_btn.Enabled || (player.InShop && open_shop) || console_panel.Visible || (active && start_btn.Enabled) || Paused;
            if (shouldShowCursor != isCursorVisible)
            {
                if (shouldShowCursor)
                {
                    Cursor.Show();
                    isCursorVisible = true;
                }
                else
                {
                    Cursor.Hide();
                    isCursorVisible = false;
                }
            }
            if (start_btn.Enabled)
            {
                Paused = false;
                pause_panel.Visible = false;
            }
            FullScreen = WindowState == FormWindowState.Maximized;
            if (FullScreen && start_btn.Enabled)
                bottom_panel.Visible = true;
            else if (FullScreen)
                bottom_panel.Visible = false;
            if (!reload_timer.Enabled)
                stamina_panel.Width = (int)(player.STAMINE / player.MAX_STAMINE * top_panel.Width);
            if (Paused)
            {
                pause_btn.Left = (top_panel.Width - pause_btn.Width) / 2;
                exit_btn.Left = (top_panel.Width - exit_btn.Width) / 2;
            }
            shop_money.Text = $"$: {player.Money}";
            if (player.HP <= 0 && !start_btn.Enabled)
                GameOver(0);
            try
            {
                if (!shot_timer.Enabled && !reload_timer.Enabled && !pressed_h)
                {
                    if (player.FirstAidKits.Count > 0 && player.Guns.Contains(player.FirstAidKits[0]))
                    {
                        ChangeWeapon(player.PreviousGun);
                        player.PreviousGun = player.CurrentGun;
                        player.Guns.Remove(player.FirstAidKits[0]);
                        if (player.FirstAidKits[0].AmmoCount <= 0 && player.FirstAidKits[0].MaxAmmoCount <= 0)
                            player.FirstAidKits[0].HasIt = false;
                    }
                }
                if (player.GetCurrentGun() is Flashlight)
                    shot_timer.Enabled = reload_timer.Enabled = false;
                if (player.GetCurrentGun() is TSPitW)
                {
                    stamina_panel.Visible = true;
                    if (playerMoveStyle != Direction.WALK)
                        playerMoveStyle = Direction.WALK;
                    if (player.STAMINE > 15)
                        player.STAMINE -= 15;
                }
                if (playerMoveStyle == Direction.RUN)
                {
                    if (player.GetCurrentGun() is Pistol || player.GetCurrentGun() is Shotgun || player.GetCurrentGun() is Fingershot || player.GetCurrentGun() is FirstAidKit)
                    {
                        if (player.GetCurrentGun() is Pistol && player.GetCurrentGun().AmmoCount <= 0)
                            player.MoveStyle = 6;
                        else
                            player.MoveStyle = 5;
                    }
                    else if (player.GetCurrentGun() is Flashlight)
                        player.MoveStyle = 1;
                    else if (player.GetCurrentGun() is Knife)
                        player.MoveStyle = 2;
                    else
                        player.MoveStyle = 4;
                }
                else
                {
                    if (player.GetCurrentGun() is Pistol && player.GetCurrentGun().AmmoCount <= 0 && player.GetCurrentGun().Level != Levels.LV4 && !shot_timer.Enabled && !reload_timer.Enabled)
                        player.MoveStyle = 4;
                    else
                        player.MoveStyle = 0;
                }
                if (!shot_timer.Enabled && !reload_timer.Enabled && player.GunState != player.MoveStyle && !player.Aiming)
                    player.GunState = player.MoveStyle;
                if (player.LevelUpdated && !open_shop)
                {
                    ChangeWeapon(player.CurrentGun);
                    player.LevelUpdated = false;
                }
            }
            catch { }
        }

        private void SLIL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                WindowState = WindowState == FormWindowState.Normal ? WindowState = FormWindowState.Maximized : WindowState = FormWindowState.Normal;
                if (form != null)
                {
                    map_timer.Stop();
                    form.Close();
                    form = null;
                    Opacity = 1;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (open_shop)
                {
                    open_shop = false;
                    time_remein.Start();
                    mouse_timer.Start();
                    int x = display.PointToScreen(Point.Empty).X + (display.Width / 2);
                    int y = display.PointToScreen(Point.Empty).Y + (display.Height / 2);
                    Cursor.Position = new Point(x, y);
                    shop_panel.Visible = false;
                }
                else if (console_panel.Visible)
                {
                    scope[scope_type] = GetScope(scope[scope_type]);
                    scope_shotgun[scope_type] = GetScope(scope_shotgun[scope_type]);
                    console_panel.Visible = false;
                    time_remein.Start();
                    mouse_timer.Start();
                    console_panel.command_input.Text = null;
                    display.Focus();
                    int x = display.PointToScreen(Point.Empty).X + (display.Width / 2);
                    int y = display.PointToScreen(Point.Empty).Y + (display.Height / 2);
                    Cursor.Position = new Point(x, y);
                }
                else if (start_btn.Enabled)
                    Close();
                else
                    Pause();
                return;
            }
            if (!start_btn.Enabled && !Paused)
            {
                if (!console_panel.Visible)
                {
                    if (!open_shop)
                    {
                        if (e.KeyCode == Keys.ShiftKey && player.STAMINE >= player.MAX_STAMINE / 1.75 && !player.Aiming && !reload_timer.Enabled && !chill_timer.Enabled)
                            playerMoveStyle = Direction.RUN;
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
                            map_presed = true;
                            if (form != null)
                            {
                                map_timer.Stop();
                                form.Close();
                                form = null;
                                Opacity = 1;
                                return;
                            }
                            form = new Map_form
                            {
                                Left = Right,
                                Top = Top,
                                _MAP = DISPLAYED_MAP,
                                _MazeHeight = MazeHeight,
                                _MazeWidth = MazeWidth
                            };
                            if (WindowState == FormWindowState.Maximized)
                            {
                                form.WindowState = FormWindowState.Maximized;
                                form.TopMost = false;
                                form.Show();
                                Opacity = 0.5f;
                            }
                            else
                            {
                                form.WindowState = FormWindowState.Normal;
                                form.TopMost = true;
                                form.Show();
                                Opacity = 1;
                            }
                            map_timer.Start();
                            Activate();
                        }
                        if (!shot_timer.Enabled && !reload_timer.Enabled)
                        {
                            int count = player.Guns.Count;
                            if (player.Guns.Contains(GUNS[0]))
                                count--;
                            if (e.KeyCode == Keys.F)
                                TakeFlashlight(true);
                            if (e.KeyCode == Keys.R)
                            {
                                if (player.GetCurrentGun().AmmoCount != player.GetCurrentGun().CartridgesClip && player.GetCurrentGun().MaxAmmoCount > 0)
                                {
                                    pressed_r = true;
                                    player.CanShoot = false;
                                    player.Aiming = false;
                                    int sound = 1;
                                    if (!(player.GetCurrentGun() is Shotgun))
                                    {
                                        player.GunState = 2;
                                        if (player.GetCurrentGun() is Pistol && player.GetCurrentGun().Level != Levels.LV4 && player.GetCurrentGun().AmmoCount == 0)
                                            player.GunState = 3;
                                    }
                                    else
                                    {
                                        player.GunState = 3;
                                        if (player.GetCurrentGun().Level != Levels.LV1)
                                            sound = 3;
                                    }
                                    if (MainMenu.sounds)
                                        player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), sound].Play(Volume);
                                    reload_timer.Start();
                                }
                            }
                            if (e.KeyCode == Keys.H)
                            {
                                if (player.FirstAidKits.Count > 0 && player.FirstAidKits[0].HasIt && player.HP < player.MAX_HP)
                                {
                                    TakeFlashlight(false);
                                    pressed_h = true;
                                    if (!player.Guns.Contains(player.FirstAidKits[0]))
                                        player.Guns.Add(player.FirstAidKits[0]);
                                    player.PreviousGun = player.CurrentGun;
                                    if (rand.NextDouble() <= player.CurseCureChance)
                                    {
                                        if (rand.NextDouble() <= 0.5)
                                            player.FirstAidKits[0].Level = Levels.LV2;
                                        else
                                            player.FirstAidKits[0].Level = Levels.LV3;
                                    }
                                    else
                                        player.FirstAidKits[0].Level = Levels.LV1;
                                    ChangeWeapon(player.Guns.IndexOf(player.FirstAidKits[0]));
                                    player.GunState = 1;
                                    player.Aiming = false;
                                    player.CanShoot = false;
                                    player.UseFirstMedKit = true;
                                    burst_shots = 0;
                                    shot_timer.Start();
                                    pressed_h = false;
                                }
                            }
                            if (e.KeyCode == Keys.D1)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(0);
                            }
                            if (e.KeyCode == Keys.D2 && count > 1)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(1);
                            }
                            if (e.KeyCode == Keys.D3 && count > 2)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(2);
                            }
                            if (e.KeyCode == Keys.D4 && count > 3)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(3);
                            }
                            if (e.KeyCode == Keys.D5 && count > 4)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(4);
                            }
                            if (e.KeyCode == Keys.D6 && count > 5)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(5);
                            }
                            if (e.KeyCode == Keys.D7 && count > 6)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(6);
                            }
                            if (e.KeyCode == Keys.D8 && count > 7)
                            {
                                TakeFlashlight(false);
                                ChangeWeapon(7);
                            }
                        }
                    }
                    if (e.KeyCode == Keys.B && player.InShop)
                    {
                        open_shop = !open_shop;
                        ShopInterface_panel.VerticalScroll.Value = 0;
                        if (open_shop)
                        {
                            mouse_timer.Stop();
                            time_remein.Stop();
                            shop_panel.BringToFront();
                            shop_panel.Visible = true;
                        }
                        else
                        {
                            time_remein.Start();
                            mouse_timer.Start();
                            int x = display.PointToScreen(Point.Empty).X + (display.Width / 2);
                            int y = display.PointToScreen(Point.Empty).Y + (display.Height / 2);
                            Cursor.Position = new Point(x, y);
                            shop_panel.Visible = false;
                        }
                    }
                }
                if (e.KeyCode == Keys.Oemtilde && !open_shop)
                {
                    console_panel.Visible = !console_panel.Visible;
                    if (form != null)
                    {
                        map_timer.Stop();
                        form.Close();
                        form = null;
                        Opacity = 1;
                        return;
                    }
                    if (console_panel.Visible)
                    {
                        mouse_timer.Stop();
                        time_remein.Stop();
                        console_panel.command_input.Text = null;
                        console_panel.command_input.Focus();
                        console_panel.BringToFront();
                    }
                    else
                    {
                        time_remein.Start();
                        mouse_timer.Start();
                        console_panel.command_input.Text = null;
                        display.Focus();
                        int x = display.PointToScreen(Point.Empty).X + (display.Width / 2);
                        int y = display.PointToScreen(Point.Empty).Y + (display.Height / 2);
                        Cursor.Position = new Point(x, y);
                    }
                    scope[scope_type] = GetScope(scope[scope_type]);
                    scope_shotgun[scope_type] = GetScope(scope_shotgun[scope_type]);
                }
            }
            else if (start_btn.Enabled)
            {
                if (e.KeyCode == Keys.Space)
                    StartGame();
            }
        }

        private void SLIL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                playerMoveStyle = Direction.WALK;
                if (!chill_timer.Enabled)
                    chill_timer.Start();
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up || e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                playerDirection = Direction.STOP;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left || e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                strafeDirection = Direction.STOP;
            if (!start_btn.Enabled && !Paused && !console_panel.Visible && !open_shop)
            {
                if (e.KeyCode == Keys.F12)
                    DoScreenshot();
                if (e.KeyCode == Keys.E || e.KeyCode == Keys.Enter)
                {
                    double rayA = player.A + FOV / 2 - (SCREEN_WIDTH[resolution] / 2) * FOV / SCREEN_WIDTH[resolution];
                    double ray_x = Math.Sin(rayA);
                    double ray_y = Math.Cos(rayA);
                    double distance = 0;
                    bool hit = false;
                    while (raycast.Enabled && !hit && distance <= 1)
                    {
                        distance += 0.1d;
                        int x = (int)(player.X + ray_x * distance);
                        int y = (int)(player.Y + ray_y * distance);
                        char test_wall = MAP[y * MAP_WIDTH + x];
                        switch (test_wall)
                        {
                            case '#':
                            case '=':
                            case 'F':
                            case 'E':
                                hit = true;
                                wall.Play(Volume);
                                break;
                            case 'D':
                                hit = true;
                                door[0].Play(Volume);
                                MAP[y * MAP_WIDTH + x] = 'O';
                                break;
                            case 'O':
                                hit = true;
                                if (distance < playerWidth || ((int)player.X == x && (int)player.Y == y))
                                    break;
                                door[1].Play(Volume);
                                MAP[y * MAP_WIDTH + x] = 'D';
                                break;
                        }
                    }
                }
            }
        }

        private void DoScreenshot()
        {
            string path = GetPath();
            console_panel.Log($"Screenshot successfully created and saved to path:\n<{path}<", true, true, Color.Lime);
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                BUFFER?.Save(fileStream, ImageFormat.Png);
            screenshot.Play(Volume);
        }

        private string GetPath()
        {
            DateTime dateTime = DateTime.Now;
            string path = Path.Combine("screenshots", $"screenshot_{dateTime:yyyy_MM_dd}__{dateTime:HH_mm_ss}.png");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            return path;
        }

        private void Pause()
        {
            Paused = !Paused;
            pause_panel.Visible = Paused;
            if (Paused)
            {
                time_remein.Stop();
                map_timer.Stop();
                stamina_timer.Stop();
                mouse_timer.Stop();
                enemy_timer.Stop();
                pause_panel.BringToFront();
                if (form != null)
                {
                    form.Close();
                    form = null;
                    Opacity = 1;
                }
                shop_panel.Visible = false;
            }
            else
            {
                time_remein.Start();
                stamina_timer.Start();
                mouse_timer.Start();
                enemy_timer.Start();
            }
        }

        private void TakeFlashlight(bool change)
        {
            if (player.Guns.Contains((Flashlight)GUNS[0]))
            {
                player.Guns.Remove((Flashlight)GUNS[0]);
                ChangeWeapon(player.PreviousGun);
            }
            else if (change)
            {
                player.Guns.Add((Flashlight)GUNS[0]);
                player.PreviousGun = player.CurrentGun;
                ChangeWeapon(player.Guns.IndexOf((Flashlight)GUNS[0]));
            }
        }

        private void Display_Scroll(object sender, MouseEventArgs e)
        {
            if (!start_btn.Enabled && !shot_timer.Enabled && !reload_timer.Enabled)
            {
                int new_gun = player.CurrentGun;
                if (e.Delta > 0)
                    new_gun--;
                else
                    new_gun++;
                if (new_gun < 0)
                    new_gun = player.Guns.Count - 1;
                else if (new_gun > player.Guns.Count - 1)
                    new_gun = 0;
                TakeFlashlight(false);
                ChangeWeapon(new_gun);
            }
        }

        private void SLIL_Deactivate(object sender, EventArgs e)
        {
            if (!map_presed)
            {
                strafeDirection = Direction.STOP;
                playerDirection = Direction.STOP;
                playerMoveStyle = Direction.WALK;
                active = false;
            }
            map_presed = false;
        }

        private void ChangeWeapon(int new_gun)
        {
            if ((new_gun != player.CurrentGun || player.LevelUpdated) && player.Guns[new_gun].HasIt)
            {
                if (MainMenu.sounds)
                    draw.Play(Volume);
                player.CurrentGun = new_gun;
                player.GunState = 0;
                player.Aiming = false;
                reload_timer.Interval = player.GetCurrentGun().RechargeTime;
                shot_timer.Interval = player.GetCurrentGun().FiringRate;
            }
        }

        private void Display_MouseDown(object sender, MouseEventArgs e)
        {
            if (!start_btn.Enabled && player.CanShoot && !reload_timer.Enabled && !shot_timer.Enabled)
            {
                if (!(player.GetCurrentGun() is Flashlight) && !(player.GetCurrentGun() is FirstAidKit))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (player.GetCurrentGun().MaxAmmoCount >= 0 && player.GetCurrentGun().AmmoCount > 0)
                        {
                            if (player.GetCurrentGun() is SniperRifle && !player.Aiming)
                                return;
                            if (MainMenu.sounds)
                                player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 0].Play(Volume);
                            player.GunState = 1;
                            player.Aiming = false;
                            player.CanShoot = false;
                            burst_shots = 0;
                            if (player.GetCurrentGun().FireType == FireTypes.Single)
                                BulletRayCasting();
                            shot_timer.Start();
                        }
                        else if (player.GetCurrentGun().MaxAmmoCount > 0 && player.GetCurrentGun().AmmoCount == 0)
                        {
                            player.GunState = 2;
                            if (player.GetCurrentGun() is Pistol || player.GetCurrentGun() is Shotgun)
                                player.GunState = 3;
                            player.Aiming = false;
                            reload_timer.Start();
                            if (player.GetCurrentGun() is Shotgun && player.GetCurrentGun().Level != Levels.LV1)
                                return;
                            if (MainMenu.sounds)
                                player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 1].Play(Volume);
                        }
                        else if (!(player.GetCurrentGun() is Pistol && player.GetCurrentGun().Level == Levels.LV1) &&
                            !(player.GetCurrentGun() is Shotgun && player.GetCurrentGun().Level == Levels.LV1) && MainMenu.sounds)
                            player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 2].Play(Volume);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        if (player.GetCurrentGun() is SniperRifle)
                        {
                            if (MainMenu.sounds)
                                player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 3].Play(Volume);
                            player.Aiming = !player.Aiming;
                            player.GunState = player.Aiming ? 3 : 0;
                        }
                    }
                }
            }
        }

        private void BulletRayCasting()
        {
            double rayA = player.A + FOV / 2 - (SCREEN_WIDTH[resolution] / 2) * FOV / SCREEN_WIDTH[resolution];
            double ray_x = Math.Sin(rayA);
            double ray_y = Math.Cos(rayA);
            double distance = 0;
            bool hit = false;
            int factor = player.Aiming ? 12 : 0;
            scope_hit = null;
            while (raycast.Enabled && !hit && distance < player.GetCurrentGun().FiringRange)
            {
                distance += 0.1d;
                int test_x = (int)(player.X + ray_x * distance);
                int test_y = (int)(player.Y + ray_y * distance);
                if (test_x < 0 || test_x >= (DEPTH + factor) + player.X || test_y < 0 || test_y >= (DEPTH + factor) + player.Y)
                    hit = true;
                else
                {
                    char test_wall = MAP[test_y * MAP_WIDTH + test_x];
                    double celling = (SCREEN_HEIGHT[resolution] - player.Look) / 2.25d - (SCREEN_HEIGHT[resolution] * FOV) / distance;
                    double floor = SCREEN_HEIGHT[resolution] - (celling + player.Look);
                    double mid = (celling + floor) / 2;
                    if (test_wall == '#' || test_wall == 'F' || test_wall == 'D')
                        hit = true;
                    else if (test_wall == '=' && SCREEN_HEIGHT[resolution] / 2 >= mid)
                        hit = true;
                    else if (test_wall == 'E')
                    {
                        hit = true;
                        if (SCREEN_HEIGHT[resolution] / 2 > celling && SCREEN_HEIGHT[resolution] / 2 <= floor)
                        {
                            double damage = (double)rand.Next((int)(player.GetCurrentGun().MinDamage * 100), (int)(player.GetCurrentGun().MaxDamage * 100)) / 100;
                            if (player.GetCurrentGun() is Shotgun)
                                damage *= player.GetCurrentGun().FiringRange - distance;
                            bool all_ok = false;
                            for (int i = 0; i < Enemies.Count; i++)
                            {
                                if (start_btn.Enabled)
                                    break;
                                if (Enemies[i].DEAD)
                                    continue;
                                if (Enemies[i].IntX == test_x && Enemies[i].IntY == test_y)
                                {
                                    if (Enemies[i].DealDamage(damage))
                                    {
                                        MAP[test_y * MAP_WIDTH + test_x] = '.';
                                        double multiplier = 1;
                                        if (difficulty == 3)
                                            multiplier = 1.5;
                                        player.ChangeMoney(rand.Next((int)(Enemies[i].MIN_MONEY[Enemies[i].Type] * multiplier), (int)(Enemies[i].MAX_MONEY[Enemies[i].Type] * multiplier)));
                                        player.EnemiesKilled++;
                                        if (MainMenu.sounds)
                                            enemy_die[rand.Next(0, enemy_die.Length)].Play(Volume);
                                    }
                                    else
                                    {
                                        for (double angle = 0; angle <= 6; angle += 0.001)
                                        {
                                            double d = 0;
                                            double r_x = Math.Sin(angle);
                                            double r_y = Math.Cos(angle);
                                            bool hit_wall = false;
                                            bool hit_player = false;
                                            while (d <= 6 && !hit_wall && !hit_player)
                                            {
                                                d += 0.1;
                                                int t_x = (int)(Enemies[i].IntX + r_x * d);
                                                int t_y = (int)(Enemies[i].IntY + r_y * d);
                                                char c;
                                                try
                                                {
                                                    c = MAP[t_y * MAP_WIDTH + t_x];
                                                }
                                                catch
                                                {
                                                    c = '#';
                                                }
                                                switch (c)
                                                {
                                                    case '#':
                                                    case '=':
                                                    case 'D':
                                                    case 'O':
                                                    case 'F':
                                                    case 'E':
                                                        hit_wall = true;
                                                        break;
                                                    case 'P':
                                                        hit_player = true;
                                                        Enemies[i].A = angle;
                                                        break;
                                                }
                                            }
                                            if (hit_player)
                                            {
                                                if (difficulty == 0 && player.GetCurrentGun().FireType == FireTypes.Single && !(player.GetCurrentGun() is Knife))
                                                {
                                                    MAP[(int)Enemies[i].Y * MAP_WIDTH + (int)Enemies[i].X] = '.';
                                                    Enemies[i].UpdateCoordinates(MAP.ToString());
                                                    MAP[(int)Enemies[i].Y * MAP_WIDTH + (int)Enemies[i].X] = 'E';
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    all_ok = true;
                                    scope_hit = Properties.Resources.scope_hit;
                                }
                            }
                            if (!all_ok)
                                MAP[test_y * MAP_WIDTH + test_x] = '.';
                        }
                    }
                }
            }
            if (player.Look - player.GetCurrentGun().Recoil > -360)
                player.Look -= player.GetCurrentGun().Recoil;
            else
                player.Look = -360;
        }

        private void Reload_gun_Tick(object sender, EventArgs e)
        {
            try
            {
                scope_hit = null;
                if (!start_btn.Enabled)
                {
                    int index = 1;
                    if (player.GetCurrentGun() is Shotgun && (player.GetCurrentGun().MaxAmmoCount == 0 || pressed_r))
                    {
                        if (player.GetCurrentGun().Level == Levels.LV1)
                            index = 2;
                        else
                        {
                            index = 3;
                            if (pressed_r)
                                index--;
                        }
                    }
                    if (!pressed_r && player.GetCurrentGun().AmmoCount > 0 && player.GetCurrentGun() is Shotgun)
                    {
                        player.GunState = player.MoveStyle;
                        player.CanShoot = true;
                        reload_timer.Stop();
                        reload_frames = 0;
                        return;
                    }
                    if (reload_frames >= player.GetCurrentGun().ReloadFrames - index)
                    {
                        player.GunState = player.MoveStyle;
                        pressed_r = false;
                        player.CanShoot = true;
                        player.GetCurrentGun().ReloadClip();
                        if (player.UseFirstMedKit)
                            player.HealHP(rand.Next(40, 60));
                        reload_timer.Stop();
                        reload_frames = 0;
                        return;
                    }
                    else if (player.GetCurrentGun().ReloadFrames > 1)
                        player.GunState++;
                    reload_frames++;
                    if (player.GetCurrentGun() is Shotgun && MainMenu.sounds)
                        player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 3].Play(Volume);
                }
                else
                {
                    reload_timer.Stop();
                    reload_frames = 0;
                }
            }
            catch { }
        }

        private void Shot_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (burst_shots >= player.GetCurrentGun().BurstShots)
                    shot_timer.Stop();
                else
                {
                    if (player.GetCurrentGun().FireType != FireTypes.Single)
                        player.GunState = player.GunState == 1 ? 0 : 1;
                    else
                        player.GunState = player.Aiming ? 3 : 0;
                    if (!(player.GetCurrentGun() is Knife))
                        player.GetCurrentGun().AmmoCount--;
                    if (player.GetCurrentGun().FireType != FireTypes.Single)
                        BulletRayCasting();
                    if ((player.GetCurrentGun().AmmoCount <= 0 && player.GetCurrentGun().MaxAmmoCount > 0) || player.GetCurrentGun() is FirstAidKit)
                    {
                        player.GunState = 2;
                        if (player.GetCurrentGun() is Pistol && player.GetCurrentGun().Level != Levels.LV4)
                            player.GunState = 3;
                        player.Aiming = false;
                        if (MainMenu.sounds)
                            player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 1].Play(Volume);
                        reload_timer.Start();
                    }
                    else if (player.GetCurrentGun().AmmoCount <= 0)
                    {
                        player.Aiming = false;
                        player.CanShoot = true;
                        player.GunState = player.MoveStyle;
                        if (player.GetCurrentGun() is Pistol && player.GetCurrentGun().Level != Levels.LV4)
                            player.GunState = 4;
                        else if (player.GetCurrentGun() is Shotgun)
                        {
                            if (player.GetCurrentGun().Level == Levels.LV1 || player.GetCurrentGun().MaxAmmoCount == 0)
                                player.GunState = 2;
                            else
                                player.GunState = 3;
                            if (MainMenu.sounds)
                                player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 1].Play(Volume);
                            reload_timer.Start();
                        }
                    }
                    else
                    {
                        if (player.GetCurrentGun().FireType == FireTypes.Single)
                            player.GunState = player.Aiming ? 3 : 0;
                        if (player.GetCurrentGun() is Shotgun && player.GetCurrentGun().Level != Levels.LV1)
                        {
                            player.GunState = 2;
                            if (MainMenu.sounds)
                                player.GetCurrentGun().Sounds[player.GetCurrentGun().GetLevel(), 1].Play(Volume);
                            reload_timer.Start();
                        }
                        player.CanShoot = true;
                    }
                }
                burst_shots++;
                if (!shot_timer.Enabled || player.GetCurrentGun().FireType == FireTypes.Single)
                    scope_hit = null;
            }
            catch { }
        }

        private void Enemy_timer_Tick(object sender, EventArgs e)
        {
            Parallel.For(0, Enemies.Count, i =>
            {
                if (!start_btn.Enabled)
                {
                    Enemy enemy = Enemies[i];
                    double distance = Math.Sqrt(Math.Pow(enemy.X - player.X, 2) + Math.Pow(enemy.Y - player.Y, 2));
                    if (distance <= 30)
                    {
                        if (difficulty <= 1)
                        {
                            if (enemy.DEAD && enemy.RESPAWN > 0)
                                enemy.RESPAWN--;
                            else if (enemy.DEAD && enemy.RESPAWN <= 0)
                            {
                                if (Math.Abs(enemy.X - player.X) > 1 && Math.Abs(enemy.Y - player.Y) > 1)
                                    enemy.Respawn();
                            }
                        }
                        if (!enemy.DEAD)
                        {
                            MAP[(int)enemy.Y * MAP_WIDTH + (int)enemy.X] = '.';
                            enemy.UpdateCoordinates(MAP.ToString());
                            if (enemy.Type == 1)
                                enemy.UpdateCoordinates(MAP.ToString());
                            MAP[(int)enemy.Y * MAP_WIDTH + (int)enemy.X] = 'E';
                            if (Math.Abs(enemy.X - player.X) <= 1 && Math.Abs(enemy.Y - player.Y) <= 1)
                            {
                                enemy.Kill();
                                MAP[(int)enemy.Y * MAP_WIDTH + (int)enemy.X] = '.';
                                player.DealDamage(rand.Next(enemy.MIN_DAMAGE[enemy.Type], enemy.MAX_DAMAGE[enemy.Type]));
                                if (player.HP <= 0)
                                {
                                    GameOver(0);
                                    return;
                                }
                                if (MainMenu.sounds)
                                    hit.Play(Volume);
                            }
                        }
                    }
                }
            });
        }

        private void Map_timer_Tick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                form.Left = Right;
                form.Top = Top;
            }
            form._MAP = DISPLAYED_MAP;
        }

        private void SLIL_LocationChanged(object sender, EventArgs e)
        {
            strafeDirection = Direction.STOP;
            playerDirection = Direction.STOP;
            playerMoveStyle = Direction.WALK;
        }

        private void Mouse_timer_Tick(object sender, EventArgs e)
        {
            Rectangle displayRectangle = new Rectangle
            {
                Location = display.PointToScreen(Point.Empty),
                Width = display.Width,
                Height = display.Height
            };
            Point cursorPosition = Cursor.Position;
            if (!displayRectangle.Contains(cursorPosition) && active)
                Cursor.Position = display.PointToScreen(new Point(display.Width / 2, display.Height / 2));
        }

        private void Stamina_timer_Tick(object sender, EventArgs e)
        {
            if (playerMoveStyle == Direction.RUN && playerDirection == Direction.FORWARD && !player.Aiming && !reload_timer.Enabled)
            {
                stamina_panel.Visible = true;
                if (player.STAMINE <= 0)
                    playerMoveStyle = Direction.WALK;
                else
                {
                    if (player.GetCurrentGun() is Pistol || player.GetCurrentGun() is Flashlight || player.GetCurrentGun() is Knife)
                        player.STAMINE -= 2;
                    else
                        player.STAMINE -= 3;
                }
            }
            else
            {
                playerMoveStyle = Direction.WALK;
                if (player.STAMINE >= player.MAX_STAMINE)
                {
                    stamina_panel.Width = display.Width;
                    stamina_panel.Visible = false;
                }
                else
                    player.STAMINE += 2;
            }
        }

        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            if (!start_btn.Enabled && active && !console_panel.Visible && !shop_panel.Visible)
            {
                double scale = WindowState == FormWindowState.Maximized ? 2.5 : 1;
                double x = display.Width / 2, y = display.Height / 2;
                double X = e.X - x, Y = e.Y - y;
                double size = MainMenu.scaled ? MainMenu.scale_size * 0.95 : 1;
                player.A -= (((X / x) / 10) * (LOOK_SPEED * size)) * scale;
                player.Look += (((Y / y) * 30) * (LOOK_SPEED * size)) * scale;
                if (player.Look < -360)
                    player.Look = -360;
                else if (player.Look > 360)
                    player.Look = 360;
                Cursor.Position = display.PointToScreen(new Point((int)x, (int)y));
            }
        }

        private void PlayerMove()
        {
            if (MAP[(int)player.Y * MAP_WIDTH + (int)player.X] == 'P')
            {
                MAP[(int)player.Y * MAP_WIDTH + (int)player.X] = '.';
                DISPLAYED_MAP[(int)player.Y * MAP_WIDTH + (int)player.X] = '.';
            }
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
            double moveSin = Math.Sin(player.A) * move;
            double moveCos = Math.Cos(player.A) * move;
            double strafeSin = moveSin / 1.4f;
            double strafeCos = moveCos / 1.4f;
            double newX = player.X;
            double newY = player.Y;
            double tempX = player.X;
            double tempY = player.Y;
            switch (strafeDirection)
            {
                case Direction.LEFT:
                    newX += strafeCos;
                    newY -= strafeSin;
                    break;
                case Direction.RIGHT:
                    newX -= strafeCos;
                    newY += strafeSin;
                    break;
            }
            switch (playerDirection)
            {
                case Direction.FORWARD:
                    newX += moveSin;
                    newY += moveCos;
                    break;
                case Direction.BACK:
                    newX -= moveSin;
                    newY -= moveCos;
                    break;
            }
            if (!(impassibleCells.Contains(MAP[(int)newY * MAP_WIDTH + (int)(newX + playerWidth / 2)])
                || impassibleCells.Contains(MAP[(int)newY * MAP_WIDTH + (int)(newX - playerWidth / 2)])))
                tempX = newX;
            if (!(impassibleCells.Contains(MAP[(int)(newY + playerWidth / 2) * MAP_WIDTH + (int)newX])
                || impassibleCells.Contains(MAP[(int)(newY - playerWidth / 2) * MAP_WIDTH + (int)newX])))
                tempY = newY;
            if (impassibleCells.Contains(MAP[(int)tempY * MAP_WIDTH + (int)(tempX + playerWidth / 2)]))
                tempX -= playerWidth / 2 - (1 - tempX % 1);
            if (impassibleCells.Contains(MAP[(int)tempY * MAP_WIDTH + (int)(tempX - playerWidth / 2)]))
                tempX += playerWidth / 2 - (tempX % 1);
            if (impassibleCells.Contains(MAP[(int)(tempY + playerWidth / 2) * MAP_WIDTH + (int)tempX]))
                tempY -= playerWidth / 2 - (1 - tempY % 1);
            if (impassibleCells.Contains(MAP[(int)(tempY - playerWidth / 2) * MAP_WIDTH + (int)tempX]))
                tempY += playerWidth / 2 - (tempY % 1);
            player.X = tempX;
            player.Y = tempY;
            if (MAP[(int)player.Y * MAP_WIDTH + (int)player.X] == 'F')
            {
                GameOver(1);
                return;
            }
            if (MAP[(int)player.Y * MAP_WIDTH + (int)player.X] == '$')
                player.InShop = true;
            else
                player.InShop = false;
            if (MAP[(int)player.Y * MAP_WIDTH + (int)player.X] == '.')
            {
                MAP[(int)player.Y * MAP_WIDTH + (int)player.X] = 'P';
                DISPLAYED_MAP[(int)player.Y * MAP_WIDTH + (int)player.X] = 'P';
            }
        }

        private void UpdateBitmap()
        {
            SCREEN?.Dispose();
            WEAPON?.Dispose();
            BUFFER?.Dispose();
            graphicsWeapon?.Dispose();
            SCREEN = new Bitmap(SCREEN_WIDTH[resolution], SCREEN_HEIGHT[resolution]);
            WEAPON = new Bitmap(SCREEN_WIDTH[resolution], SCREEN_HEIGHT[resolution]);
            BUFFER = new Bitmap(SCREEN_WIDTH[resolution], SCREEN_HEIGHT[resolution]);
            graphicsWeapon = Graphics.FromImage(WEAPON);
            display.ResizeImage(SCREEN_WIDTH[resolution], SCREEN_HEIGHT[resolution]);
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
                shop_money.Font = new Font(shop_money.Font.FontFamily, shop_money.Font.Size * MainMenu.scale_size);
                shop_title.Font = new Font(shop_title.Font.FontFamily, shop_title.Font.Size * MainMenu.scale_size);
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
                shop_title.Text = "SHOP";
                pause_text.Text = "PAUSE";
                pause_btn.Text = "CONTINUE";
                exit_btn.Text = "EXIT";
            }
            for (int i = WEAPONS_COUNT - 1; i >= 0; i--)
            {
                if (GUNS[i].AddToShop)
                {
                    SLIL_ShopInterface ShopInterface = new SLIL_ShopInterface()
                    {
                        index = MainMenu.Language ? 0 : 1,
                        weapon = GUNS[i],
                        buy = buy,
                        player = player,
                        BackColor = shop_panel.BackColor,
                        Dock = DockStyle.Top
                    };
                    ShopInterface_panel.Controls.Add(ShopInterface);
                }
            }
            console_panel = new ConsolePanel()
            {
                Dock = DockStyle.Fill,
                Visible = false,
                player = player,
                GUNS = GUNS,
                Enemies = Enemies
            };
            console_panel.Log("SLIL console *v1.2*\nType \"-help-\" for a list of commands...", false, false, Color.Lime);
            top_panel.Controls.Add(console_panel);
            ost = new PlaySound[]
            {
                new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_0.wav"), true),
                new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_1.wav"), true),
                new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_2.wav"), true),
                new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_3.wav"), true),
                new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_4.wav"), true),
                new PlaySound(MainMenu.CGFReader.GetFile("soul_forge.wav"), true)
            };
            LOOK_SPEED = INIReader.GetDouble(MainMenu.iniFolder, "SLIL", "look_speed", 1.75);
            ShowFPS = INIReader.GetBool(MainMenu.iniFolder, "SLIL", "show_fps", true);
            difficulty = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "difficulty", 1);
            scope_color = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "scope_color", 0);
            scope_type = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "scope_type", 0);
            resolution = INIReader.GetBool(MainMenu.iniFolder, "SLIL", "hight_resolution", false) ? 1 : 0;
            CustomMazeHeight = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "custom_maze_height", 10);
            CustomMazeWidth = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "custom_maze_width", 10);
            if (LOOK_SPEED < 2.5 || LOOK_SPEED > 10)
                LOOK_SPEED = 2.75d;
            if (difficulty < 0 || difficulty > 4)
                difficulty = 1;
            if (scope_color < 0 || scope_color > 8)
                scope_color = 0;
            if (scope_type < 0 || scope_type > 4)
                scope_type = 0;
            if (CustomMazeHeight < 2 || CustomMazeHeight > 150)
                CustomMazeHeight = 10;
            if (CustomMazeWidth < 2 || CustomMazeWidth > 150)
                CustomMazeWidth = 10;
            display = new Display() { Size = top_panel.Size, Dock = DockStyle.Fill, TabStop = false };
            display.MouseDown += new MouseEventHandler(Display_MouseDown);
            display.MouseMove += new MouseEventHandler(Display_MouseMove);
            display.MouseWheel += new MouseEventHandler(Display_Scroll);
            top_panel.Controls.Add(display);
            UpdateBitmap();
            Activate();
        }

        private void SLIL_FormClosing(object sender, FormClosingEventArgs e)
        {
            raycast.Stop();
            time_remein.Stop();
            step_sound_timer.Stop();
            map_timer.Stop();
            stamina_timer.Stop();
            mouse_timer.Stop();
            shot_timer.Stop();
            reload_timer.Stop();
            enemy_timer.Stop();
            status_refresh.Stop();
            game_over?.Dispose();
            draw?.Dispose();
            buy?.Dispose();
            hit?.Dispose();
            wall?.Dispose();
            tp?.Dispose();
            screenshot?.Dispose();
            if (!isCursorVisible)
                Cursor.Show();
            foreach (Control control in ShopInterface_panel.Controls)
            {
                if (control is SLIL_ShopInterface)
                {
                    SLIL_ShopInterface ShopInterface = control as SLIL_ShopInterface;
                    ShopInterface.cant_pressed?.Dispose();
                    ShopInterface.cant_pressed = null;
                }
            }
            FullScreen = false;
            player.Money = 15;
            for (int i = 0; i < step.GetLength(0); i++)
            {
                for (int j = 0; j < step.GetLength(1); j++)
                    step[i, j]?.Dispose();
            }
            step = null;
            for (int i = 0; i < player.Guns.Count; i++)
            {
                for (int j = 0; j < player.Guns[i].Sounds.GetLength(0); j++)
                {
                    for (int k = 0; k < player.Guns[i].Sounds.GetLength(1); k++)
                        player.Guns[i].Sounds[j, k]?.Dispose();
                }
                player.Guns[i].Sounds = null;
            }
            for (int i = 0; i < door.Length; i++)
                door[i]?.Dispose();
            door = null;
            for (int i = 0; i < ost.Length; i++)
                ost[i]?.Dispose();
            ost = null;
            for (int i = 0; i < enemy_die.Length; i++)
                enemy_die[i]?.Dispose();
            enemy_die = null;
            if (form != null)
            {
                form.Close();
                form = null;
            }
        }

        private void SLIL_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                top_panel.Dock = DockStyle.Fill;
                top_panel.BringToFront();
            }
            else
                top_panel.Dock = DockStyle.None;
        }

        private void Raycast_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            elapsed_time = (time - total_time).TotalSeconds;
            total_time = time;
            PlayerMove();
            ClearDisplayedMap();
            Pixel[][] rays = CastRaysParallel();
            DrawRaysOnScreen(rays);
            DrawWeaponGraphics();
            UpdateDisplay();
            fps = CalculateFPS(elapsed_time);
        }

        private void UpdateDisplay()
        {
            using (Graphics g = Graphics.FromImage(SCREEN))
                g.DrawImage(WEAPON, 0, 0, SCREEN.Width, SCREEN.Height);
            using (Graphics g = Graphics.FromImage(BUFFER))
            {
                g.Clear(Color.Black);
                g.DrawImage(SCREEN, 0, 0, SCREEN.Width, SCREEN.Height);
            }
            SharpDX.Direct2D1.Bitmap dxBitmap = ConvertBitmap.ToDX(SCREEN, display.renderTarget);
            display.SCREEN = dxBitmap;
            display.DrawImage();
            dxBitmap?.Dispose();
        }

        private Pixel[][] CastRaysParallel()
        {
            Pixel[][] rays = new Pixel[SCREEN_WIDTH[resolution]][];
            Parallel.For(0, SCREEN_WIDTH[resolution], x => rays[x] = CastRay(x));
            return rays;
        }

        private void DrawRaysOnScreen(Pixel[][] rays)
        {
            BitmapData data = SCREEN.LockBits(new Rectangle(0, 0, SCREEN.Width, SCREEN.Height), ImageLockMode.WriteOnly, SCREEN.PixelFormat);
            int bytesPerPixel = Bitmap.GetPixelFormatSize(SCREEN.PixelFormat) / 8;
            byte[] pixels = new byte[data.Height * data.Stride];
            Parallel.ForEach(rays, (list) =>
            {
                foreach (Pixel pixel in list)
                {
                    int i = (pixel.Y * data.Stride) + (pixel.X * bytesPerPixel);
                    Color color = GetColorForPixel(pixel);
                    pixels[i] = color.B;
                    pixels[i + 1] = color.G;
                    pixels[i + 2] = color.R;
                    if (bytesPerPixel == 4)
                        pixels[i + 3] = color.A;
                }
            });
            rays = null;
            Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            SCREEN.UnlockBits(data);
        }

        private Color GetColorForPixel(Pixel pixel)
        {
            int textureSize = 128;
            int x = 0, y = 0;
            if (pixel.TextureId < 8)
            {
                x = (int)WrapTexture((int)(pixel.TextureX * textureSize), textureSize);
                y = (int)WrapTexture((int)(pixel.TextureY * textureSize), textureSize);
            }
            return textureCache.GetTextureColor(pixel.TextureId, x, y, pixel.Blackout);
        }

        private double WrapTexture(double value, int textureSize)
        {
            value %= textureSize;
            if (value < 0)
                value += textureSize;
            return value;
        }

        private void ClearDisplayedMap()
        {
            int radius = 30;
            for (int y = Math.Max(0, (int)player.Y - radius); y < Math.Min(MAP_HEIGHT, (int)player.Y + radius + 1); y++)
            {
                for (int x = Math.Max(0, (int)player.X - radius); x < Math.Min(MAP_WIDTH, (int)player.X + radius + 1); x++)
                {
                    int index = y * MAP_WIDTH + x;
                    if (DISPLAYED_MAP[index] == '*' || DISPLAYED_MAP[index] == 'E')
                        DISPLAYED_MAP[index] = '.';
                }
            }
        }

        private void DrawWeaponGraphics()
        {
            string space_0 = "0", space_1 = "0";
            if (seconds > 9)
                space_1 = "";
            if (minutes > 9)
                space_0 = "";
            int medkit_count = 0;
            if (player.FirstAidKits.Count > 0)
                medkit_count = player.FirstAidKits[0].AmmoCount + player.FirstAidKits[0].MaxAmmoCount;
            int icon_size = resolution == 0 ? 14 : 28;
            graphicsWeapon.Clear(Color.Transparent);
            try
            {
                graphicsWeapon.DrawImage(player.GetCurrentGun().Images[player.GetCurrentGun().GetLevel(), player.GunState], 0, 0, WEAPON.Width, WEAPON.Height);
            }
            catch
            {
                try
                {
                    graphicsWeapon.DrawImage(player.GetCurrentGun().Images[player.GetCurrentGun().GetLevel(), 0], 0, 0, WEAPON.Width, WEAPON.Height);
                }
                catch { }
            }
            if (ShowFPS)
                graphicsWeapon.DrawString($"FPS: {fps}", consolasFont[resolution], whiteBrush, SCREEN_WIDTH[resolution], 0, rightToLeft);
            graphicsWeapon.DrawString($"TIME LEFT: {space_0}{minutes}:{space_1}{seconds}", consolasFont[resolution], whiteBrush, 0, 0);
            graphicsWeapon.DrawImage(Properties.Resources.hp, 2, 108 + (110 * resolution), icon_size, icon_size);
            graphicsWeapon.DrawImage(Properties.Resources.money, 2, 14 + (14 * resolution), icon_size, icon_size);
            graphicsWeapon.DrawImage(Properties.Resources.first_aid, 2, 94 + (96 * resolution), icon_size, icon_size);
            graphicsWeapon.DrawString(player.Money.ToString(), consolasFont[resolution], whiteBrush, icon_size + 2, 14 + (14 * resolution));
            graphicsWeapon.DrawString(player.HP.ToString(), consolasFont[resolution], whiteBrush, icon_size + 2, 108 + (110 * resolution));
            graphicsWeapon.DrawString(medkit_count.ToString(), consolasFont[resolution], whiteBrush, icon_size + 2, 94 + (98 * resolution));
            if (player.Guns.Count > 0 && !(player.GetCurrentGun() is FirstAidKit) && !(player.GetCurrentGun() is Flashlight) && !(player.GetCurrentGun() is Knife))
            {
                graphicsWeapon.DrawString($"{player.GetCurrentGun().MaxAmmoCount}/{player.GetCurrentGun().AmmoCount}", consolasFont[resolution], whiteBrush, 52 + (42 * resolution), 108 + (110 * resolution));
                if (player.GetCurrentGun() is SniperRifle || player.GetCurrentGun() is AssaultRifle)
                    graphicsWeapon.DrawImage(Properties.Resources.rifle_bullet, 40 + (30 * resolution), 108 + (110 * resolution), icon_size, icon_size);
                else if (player.GetCurrentGun() is Shotgun)
                    graphicsWeapon.DrawImage(Properties.Resources.shell, 40 + (30 * resolution), 108 + (110 * resolution), icon_size, icon_size);
                else
                    graphicsWeapon.DrawImage(Properties.Resources.bullet, 40 + (30 * resolution), 108 + (110 * resolution), icon_size, icon_size);
            }
            if (player.InShop)
                graphicsWeapon.DrawImage(Properties.Resources.shop, 2, 28 + (28 * resolution), icon_size, icon_size);
            if (!(player.GetCurrentGun() is SniperRifle) && !(player.GetCurrentGun() is Flashlight) && !(player.GetCurrentGun() is FirstAidKit))
            {
                if (player.GetCurrentGun() is Shotgun)
                    graphicsWeapon.DrawImage(scope_shotgun[scope_type], WEAPON.Width / 4, WEAPON.Height / 4, WEAPON.Width / 2, WEAPON.Height / 2);
                else
                    graphicsWeapon.DrawImage(scope[scope_type], WEAPON.Width / 4, WEAPON.Height / 4, WEAPON.Width / 2, WEAPON.Height / 2);
                if (scope_hit != null)
                    graphicsWeapon.DrawImage(scope_hit, WEAPON.Width / 4, WEAPON.Height / 4, WEAPON.Width / 2, WEAPON.Height / 2);
            }
            if (stage_timer.Enabled)
            {
                string text = $"STAGE: {player.Stage + 1}";
                if (inDebug == 1)
                    text = "STAGE: Debug";
                else if (inDebug == 2)
                    text = "STAGE: Debug Boss";
                else if (difficulty == 4)
                    text = "STAGE: Custom";
                SizeF textSize = graphicsWeapon.MeasureString(text, consolasFont[resolution + 1]);
                graphicsWeapon.DrawString(text, consolasFont[resolution + 1], whiteBrush, (WEAPON.Width - textSize.Width) / 2, 30 + (30 * resolution));
            }
        }

        private Image GetScope(Image scope)
        {
            Bitmap bmp = new Bitmap(scope);
            Color color = GetScopeColor(scope_color);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color current = bmp.GetPixel(x, y);
                    if (current.A != 0)
                        bmp.SetPixel(x, y, color);
                }
            }
            return bmp;
        }

        private Color GetScopeColor(int scope_color)
        {
            if (scope_color == 8)
            {
                int r = rand.Next(125, 200);
                int g = rand.Next(125, 200);
                int b = rand.Next(125, 200);
                return Color.FromArgb(r, g, b);
            }
            else
            {
                string[] col = { "Lime", "Red", "Yellow", "Blue", "Magenta", "Cyan", "Orange", "White" };
                return Color.FromName(col[scope_color]);
            }
        }

        private int CalculateFPS(double elapsedTime)
        {
            int fps = (int)(1.0 / elapsedTime);
            return fps < 0 ? 0 : fps;
        }

        private Pixel[] CastRay(int x)
        {
            Pixel[] result = new Pixel[SCREEN_HEIGHT[resolution]];
            int factor = player.Aiming ? 12 : 0;
            if (player.GetCurrentGun() is Flashlight)
                factor = 8;
            double distance = 0;
            double window_distance = 0;
            int enemy_type = 0;
            bool hit_wall = false;
            bool hit_window = false;
            bool hit_door = false;
            bool hit_finish = false;
            bool hit_enemy = false;
            bool is_bound = false;
            bool is_window_bound = false;
            double deltaA = FOV / 2 - x * FOV / SCREEN_WIDTH[resolution];
            double rayA = player.A + deltaA;
            double ray_x = Math.Sin(rayA);
            double ray_y = Math.Cos(rayA);
            while (raycast.Enabled && !hit_wall && !hit_door && !hit_finish && !hit_enemy && distance < DEPTH + factor)
            {
                distance += 0.01f;
                if (!hit_window)
                    window_distance += 0.01f;
                int test_x = (int)(player.X + ray_x * distance);
                int test_y = (int)(player.Y + ray_y * distance);
                if (test_x < 0 || test_x >= (DEPTH + factor) + player.X || test_y < 0 || test_y >= (DEPTH + factor) + player.Y)
                {
                    hit_wall = true;
                    distance = (DEPTH + factor);
                    continue;
                }
                char test_wall = MAP[test_y * MAP_WIDTH + test_x];
                switch (test_wall)
                {
                    case '#':
                        hit_wall = true;
                        is_bound = CheckBound(test_x, test_y, ray_x, ray_y, distance);
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = '#';
                        break;
                    case '=':
                        if (!hit_window)
                        {
                            hit_window = true;
                            is_window_bound = CheckBound(test_x, test_y, ray_x, ray_y, window_distance);
                            DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = '=';
                        }
                        break;
                    case 'D':
                        hit_door = true;
                        is_bound = CheckBound(test_x, test_y, ray_x, ray_y, distance);
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = 'D';
                        break;
                    case 'F':
                        hit_finish = true;
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = 'F';
                        break;
                    case 'E':
                        enemy_type = GetEnemyType(test_x, test_y);
                        if (enemy_type != -1)
                            hit_enemy = true;
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = 'E';
                        break;
                    case '.':
                    case '*':
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = '*';
                        break;
                }
            }
            double perpWallDist = distance * Math.Cos(deltaA);
            double ceiling = (SCREEN_HEIGHT[resolution] - player.Look) / 2 - (SCREEN_HEIGHT[resolution] * FOV) / perpWallDist;
            double floor = SCREEN_HEIGHT[resolution] - (ceiling + player.Look);
            double mid = (ceiling + floor) / 2;
            bool get_texture = false, get_texture_window = false;
            int side = 0;
            double wallX = 0;
            for (int y = 0; y < SCREEN_HEIGHT[resolution]; y++)
            {
                if (start_btn.Enabled)
                    break;
                int blackout = 0, textureId = 9;
                if (hit_window && y > mid)
                {
                    ceiling = (SCREEN_HEIGHT[resolution] - player.Look) / 2 - (SCREEN_HEIGHT[resolution] * FOV) / (window_distance*Math.Cos(deltaA));
                    floor = SCREEN_HEIGHT[resolution] - (ceiling + player.Look);
                }
                else
                {
                    ceiling = (SCREEN_HEIGHT[resolution] - player.Look) / 2 - (SCREEN_HEIGHT[resolution] * FOV) / perpWallDist;
                    floor = SCREEN_HEIGHT[resolution] - (ceiling + player.Look);
                }
                if (y <= ceiling)
                {
                    textureId = 7;
                    double d = (y + player.Look / 2) / (SCREEN_HEIGHT[resolution] / 2);
                    blackout = (int)(Math.Min(Math.Max(0, d * 100), 100));
                }
                else if (y >= mid && y <= floor && hit_window)
                {
                    textureId = 0;
                    if (Math.Abs(y - mid) <= 10 / window_distance || is_window_bound)
                        textureId = 8;
                    blackout = (int)(Math.Min(Math.Max(0, Math.Floor((window_distance / (DEPTH + factor)) * 100)), 100));
                }
                else if ((y < mid || !hit_window) && y > ceiling && y < floor)
                {
                    textureId = 0;
                    if (hit_finish)
                        textureId = 5;
                    else if (hit_enemy)
                    {
                        if (enemy_type == 0)
                            textureId = 1;
                        else if (enemy_type == 1)
                            textureId = 2;
                        else
                            textureId = 3;
                    }
                    else if (hit_door)
                        textureId = 4;
                    if (is_bound)
                        textureId = 8;
                    blackout = (int)(Math.Min(Math.Max(0, Math.Floor((distance / (DEPTH + factor)) * 100)), 100));
                }
                else if (y >= floor)
                {
                    textureId = 6;
                    double d = 1 - (y - (SCREEN_HEIGHT[resolution] - player.Look) / 2) / (SCREEN_HEIGHT[resolution] / 2);
                    blackout = (int)(Math.Min(Math.Max(0, d * 100), 100));
                }
                result[y] = new Pixel(x, y, blackout, distance, ceiling - floor, textureId);
                if (y < ceiling)
                {
                    int p = y - (int)(SCREEN_HEIGHT[resolution] - player.Look) / 2;
                    double rowDistance = (double)SCREEN_HEIGHT[resolution] / p;
                    rowDistance /= Math.Cos(deltaA);
                    double floorX = player.X - rowDistance * ray_x;
                    double floorY = player.Y - rowDistance * ray_y;
                    if (floorX < 0) floorX = 0;
                    if (floorY < 0) floorY = 0;
                    result[y].TextureX = floorX % 1;
                    result[y].TextureY = floorY % 1;
                    result[y].Side = 0;
                }
                else if (y >= floor)
                {
                    int p = y - (int)(SCREEN_HEIGHT[resolution] - player.Look) / 2;
                    double rowDistance = (double)SCREEN_HEIGHT[resolution] / p;
                    rowDistance /= Math.Cos(deltaA);
                    double floorX = player.X + rowDistance * ray_x;
                    double floorY = player.Y + rowDistance * ray_y;
                    if (floorX < 0) floorX = 0;
                    if (floorY < 0) floorY = 0;
                    result[y].TextureX = floorX % 1;
                    result[y].TextureY = floorY % 1;
                    result[y].Side = 0;
                }
                else
                {
                    if (y >= mid && hit_window)
                    {
                        if (!get_texture_window)
                        {
                            get_texture_window = true;
                            side = GetSide(window_distance, ray_x, ray_y);
                            if (side == -1)
                                result[y].TextureId = 9;
                            if (side == 0)
                                wallX = player.X + window_distance * ray_x;
                            else
                                wallX = player.Y + window_distance * ray_y;
                            wallX -= Math.Floor(wallX);
                        }
                    }
                    else if (hit_door || hit_enemy || hit_finish || hit_wall)
                    {
                        if (!get_texture)
                        {
                            get_texture = true;
                            side = GetSide(distance, ray_x, ray_y);
                            if (side == -1)
                                result[y].TextureId = 9;
                            if (side == 0)
                                wallX = player.X + distance * ray_x;
                            else
                                wallX = player.Y + distance * ray_y;
                            wallX -= Math.Floor(wallX);
                        }
                    }
                    else
                    {
                        result[y].TextureId = 9;
                        result[y].TextureY = 0;
                        result[y].TextureX = 0;
                        result[y].Side = 0;
                    }
                    if (get_texture || get_texture_window)
                    {
                        result[y].TextureY = (double)((double)y - ceiling) / (double)(floor - ceiling);
                        result[y].TextureX = wallX;
                        result[y].Side = side;
                    }
                }
                
            }
            return result;
        }

        private (double x, double y)? SolveSLU(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            if (a1 == 0 && a2 == 0)
                return null;
            if (a1 == 0)
                return ((c2 - b2 * (c1 / b1)) / a2, c1 / b1);
            double det = a1 * b2 - a2 * b1;
            if (Math.Abs(det) < 1e-10)
                return null;
            double y = (c2 * a1 - a2 * c1) / det;
            double x = (c1 - b1 * y) / a1;
            return (x, y);
        }

        private (double x, double y)? SolveNotCanonical(double x1, double x2, double y1, double y2, double x1_2, double x2_2, double y1_2, double y2_2)
        {
            double a1 = y1 - y2;
            double b1 = x2 - x1;
            double c1 = x1 * (y1 - y2) + y1 * (x2 - x1);
            double a2 = y1_2 - y2_2;
            double b2 = x2_2 - x1_2;
            double c2 = x1_2 * (y1_2 - y2_2) + y1_2 * (x2_2 - x1_2);
            return SolveSLU(a1, b1, c1, a2, b2, c2);
        }

        private int GetSide(double distance, double rayX, double rayY)
        {
            double x1_1 = player.X, y1_1 = player.Y;
            double x2_1 = player.X + distance * rayX, y2_1 = player.Y + distance * rayY;
            int cellY = (int)y2_1;
            int cellX = (int)x2_1;
            double x1_2, y1_2, x2_2, y2_2;
            if (-rayY < 0)
            {
                x1_2 = cellX + 1; y1_2 = cellY; x2_2 = cellX; y2_2 = cellY;
            }
            else if (rayY < 0)
            {
                x1_2 = cellX; y1_2 = cellY + 1; x2_2 = cellX + 1; y2_2 = cellY + 1;
            }
            else if (-rayX < 0)
            {
                x1_2 = cellX; y1_2 = cellY; x2_2 = cellX; y2_2 = cellY + 1;
            }
            else
            {
                x1_2 = cellX + 1; y1_2 = cellY + 1; x2_2 = cellX + 1; y2_2 = cellY;
            }
            var intersectionPoint = SolveNotCanonical(x1_1, x2_1, y1_1, y2_1, x1_2, x2_2, y1_2, y2_2);
            if (intersectionPoint == null)
                return -1;
            double x = intersectionPoint.Value.x;
            double y = intersectionPoint.Value.y;
            if (-rayY < 0 && x >= x2_2 && x <= x1_2)
                return 0;
            else if (rayY < 0 && x >= x1_2 && x <= x2_2)
                return 0;
            else if (-rayX < 0 && y >= y1_2 && y <= y2_2)
                return 1;
            else if (y >= y2_2 && y <= y1_2)
                return 1;
            return -1;
        }

        private int GetEnemyType(int x, int y)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (start_btn.Enabled)
                    break;
                if (Enemies[i].DEAD)
                    continue;
                if (Enemies[i].IntX == x && Enemies[i].IntY == y)
                    return Enemies[i].Type;
            }
            return -1;
        }

        private bool CheckBound(int test_x, int test_y, double ray_x, double ray_y, double distance)
        {
            List<(double module, double cos)> bounds = new List<(double module, double cos)>();
            for (int tx = 0; tx < 2; tx++)
            {
                for (int ty = 0; ty < 2; ty++)
                {
                    double vx = test_x + tx - player.X;
                    double vy = test_y + ty - player.Y;
                    double module_vector = Math.Sqrt(vx * vx + vy * vy);
                    double cos_a = ray_x * vx / module_vector + ray_y * vy / module_vector;
                    bounds.Add((module_vector, cos_a));
                }
            }
            bounds = bounds.OrderBy(v => v.module).ToList();
            double bound_a = 0.03 / distance;
            if (Math.Acos(bounds[0].cos) < bound_a || Math.Acos(bounds[1].cos) < bound_a)
                return true;
            return false;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            StartGame();
        }

        private void InitMap()
        {
            MAP.Clear();
            DISPLAYED_MAP.Clear();
            if (difficulty == 5)
            {
                if (inDebug == 1)
                {
                    MAP.AppendLine(debugMap);
                    DISPLAYED_MAP.AppendLine(debugMap);
                }
                else if (inDebug == 2)
                {
                    MAP.AppendLine(bossMap);
                    DISPLAYED_MAP.AppendLine(bossMap);
                }
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    for (int y = 0; y < MAP_HEIGHT; y++)
                    {
                        if (MAP[y * MAP_WIDTH + x] == 'E')
                        {
                            Enemy enemy = new Enemy(x, y, MAP_WIDTH, rand.NextDouble());
                            Enemies.Add(enemy);
                        }
                    }
                }
                return;
            }
            if (!CUSTOM)
            {
                Random random = new Random();
                StringBuilder sb = new StringBuilder();
                char[,] map = MazeGenerator.GenerateCharMap(MazeWidth, MazeHeight, '#', '=', 'D', '.', 'F', MAX_SHOP_COUNT);
                map[1, 1] = 'P';
                List<int[]> shops = new List<int[]>();
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        try
                        {
                            if ((map[x, y] == '.' || map[x, y] == '=' || map[x, y] == 'D') &&
                                (map[x + 1, y] == '#' || map[x + 1, y] == '=' || map[x + 1, y] == 'D') &&
                                (map[x, y + 1] == '#' || map[x, y + 1] == '=' || map[x, y + 1] == 'D') &&
                                ((map[x + 2, y] == '#' || map[x + 2, y] == '=' || map[x + 2, y] == 'D') ||
                                (map[x, y + 2] == '#' || map[x, y + 2] == '=' || map[x, y + 2] == 'D')))
                                map[x, y] = '#';
                        }
                        catch { }
                        if (map[x, y] == '$')
                            shops.Add(new int[] { x, y });
                    }
                }
                if (shops.Count == 0)
                {
                    if (map[3, 1] == '#')
                    {
                        map[3, 1] = '$';
                        shops.Add(new int[] { 3, 1 });
                    }
                    else if (map[1, 3] == '#')
                    {
                        map[1, 3] = '$';
                        shops.Add(new int[] { 1, 3 });
                    }
                }
                for (int i = 0; i < shops.Count; i++)
                {
                    int[] shop = shops[i];
                    int shop_x = shop[0];
                    int shop_y = shop[1];
                    for (int x = shop_x - 1; x <= shop_x + 1; x++)
                    {
                        for (int y = shop_y - 1; y <= shop_y + 1; y++)
                        {
                            if (y >= 0 && y >= map.GetLength(0) && x >= 0 && x >= map.GetLength(1))
                                continue;
                            if (x == shop_x && y == shop_y)
                                continue;
                            if (map[x, y] != 'F')
                                map[x, y] = '#';
                        }
                    }
                    try
                    {
                        if (shop_x == 3 && shop_y == 1 && map[shop_x - 1, shop_y] == '.')
                            map[shop_x - 1, shop_y] = 'D';
                        else if (shop_x == 1 && shop_y == 3 && map[shop_x, shop_y - 1] == '.')
                            map[shop_x, shop_y - 1] = 'D';
                        else if (shop_y >= 2 && shop_y < map.GetLength(0) - 1 && shop_x >= 0 && shop_x < map.GetLength(1) && map[shop_x, shop_y - 2] == '.')
                            map[shop_x, shop_y - 1] = 'D';
                        else if (shop_y >= 0 && shop_y < map.GetLength(0) - 1 && shop_x >= 0 && shop_x < map.GetLength(1) && map[shop_x, shop_y + 2] == '.')
                            map[shop_x, shop_y + 1] = 'D';
                        else if (shop_y >= 0 && shop_y < map.GetLength(0) && shop_x >= 2 && shop_x < map.GetLength(1) - 1 && map[shop_x - 2, shop_y] == '.')
                            map[shop_x - 1, shop_y] = 'D';
                        else if (shop_y >= 0 && shop_y < map.GetLength(0) && shop_x >= 0 && shop_x < map.GetLength(1) - 1 && map[shop_x + 2, shop_y] == '.')
                            map[shop_x + 1, shop_y] = 'D';
                    }
                    catch { }
                }
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        if (map[x, y] == '.' && random.NextDouble() <= enemy_count && x > 5 && y > 5)
                        {
                            Enemy enemy = new Enemy(x, y, MazeWidth * 3 + 1, rand.NextDouble());
                            Enemies.Add(enemy);
                            map[x, y] = 'E';
                        }
                        sb.Append(map[x, y]);
                    }
                }
                MAP = sb;
            }
            else if (CUSTOM)
            {
                for (int x = 0; x < CustomMazeWidth * 3 + 1; x++)
                {
                    for (int y = 0; y < CustomMazeHeight * 3 + 1; y++)
                    {
                        if (CUSTOM_MAP[y * (CustomMazeWidth * 3 + 1) + x] == 'E')
                        {
                            Enemy enemy = new Enemy(x, y, CustomMazeWidth * 3 + 1, rand.NextDouble());
                            Enemies.Add(enemy);
                        }
                    }
                }
                MAP = CUSTOM_MAP;
            }
            for (int i = 0; i < MAP.Length; i++)
            {
                if (MAP[i] == 'O')
                    MAP[i] = 'D';
            }
            DISPLAYED_MAP.Length = MAP.Length;
            for (int i = 0; i < MAP.Length; i++)
                DISPLAYED_MAP[i] = '.';
        }

        private void ResetDefault()
        {
            display.SCREEN = null;
            scope[scope_type] = GetScope(scope[scope_type]);
            scope_shotgun[scope_type] = GetScope(scope_shotgun[scope_type]);
            display.Refresh();
            int x = display.PointToScreen(Point.Empty).X + (display.Width / 2);
            int y = display.PointToScreen(Point.Empty).Y + (display.Height / 2);
            Cursor.Position = new Point(x, y);
            seconds = 0;
            if (!CUSTOM)
                player.X = player.Y = 1.5d;
            else
            {
                player.X = CUSTOM_X;
                player.Y = CUSTOM_Y;
            }
            if (player.Guns.Count == 0)
            {
                player.Guns.Add(GUNS[1]);
                player.Guns.Add(GUNS[2]);
            }
            player.SetDefault();
            player.LevelUpdated = false;
            stamina_panel.Width = display.Width;
            stamina_panel.Visible = false;
            Enemies.Clear();
            strafeDirection = playerDirection = Direction.STOP;
            playerMoveStyle = Direction.WALK;
            if (difficulty == 0)
                enemy_count = 0.07;
            else if (difficulty == 1)
                enemy_count = 0.065;
            else if (difficulty == 2)
            {
                enemy_count = 0.06;
                if (player.Guns[1].Level == Levels.LV1)
                    player.Guns[1].LevelUpdate();
            }
            else if (difficulty == 3)
            {
                enemy_count = 0.055;
                if (player.Guns[1].Level == Levels.LV1)
                    player.Guns[1].LevelUpdate();
            }
            else if (difficulty == 4)
            {
                minutes = 9999;
                MazeHeight = CustomMazeHeight;
                MazeWidth = CustomMazeWidth;
                enemy_count = 0.06;
                MAX_SHOP_COUNT = 3;
            }
            else
            {
                if (inDebug == 1)
                {
                    player.X = 9;
                    player.Y = 9;
                    MazeHeight = 6;
                    MazeWidth = 6;
                }
                else if (inDebug == 2)
                {
                    player.X = 10.5;
                    player.Y = 19.5;
                    MazeHeight = 7;
                    MazeWidth = 7;
                }
                minutes = 9999;
            }
            if (difficulty != 4 && difficulty != 5)
            {
                if (player.Stage == 0)
                {
                    minutes = START_EASY;
                    MazeHeight = MazeWidth = 10;
                    MAX_SHOP_COUNT = 2;
                }
                else if (player.Stage == 1)
                {
                    minutes = START_NORMAL;
                    MazeHeight = MazeWidth = 15;
                    MAX_SHOP_COUNT = 4;
                }
                else if (player.Stage == 2)
                {
                    minutes = START_HARD;
                    MazeHeight = MazeWidth = 20;
                    MAX_SHOP_COUNT = 6;
                }
                else if (player.Stage == 3)
                {
                    minutes = START_VERY_HARD;
                    MazeHeight = MazeWidth = 25;
                    MAX_SHOP_COUNT = 8;
                }
                else
                {
                    minutes = START_VERY_HARD;
                    MazeHeight = MazeWidth = 25;
                    MAX_SHOP_COUNT = 8;
                }
            }
            MAP_WIDTH = MazeWidth * 3 + 1;
            MAP_HEIGHT = MazeHeight * 3 + 1;
            if (MainMenu.sounds)
                ChangeOst(rand.Next(ost.Length - 1));
        }

        private void GetFirstAidKit()
        {
            if (player.FirstAidKits.Count == 0)
                player.FirstAidKits.Add((FirstAidKit)GUNS[9]);
            player.FirstAidKits[0].AmmoCount = player.FirstAidKits[0].CartridgesClip;
            player.FirstAidKits[0].MaxAmmoCount = player.FirstAidKits[0].CartridgesClip;
            player.FirstAidKits[0].HasIt = true;
        }

        private void StartGame()
        {
            ResetDefault();
            InitMap();
            try
            {
                if (MAP[(int)(player.Y + 2) * MAP_WIDTH + (int)player.X] == '.')
                    player.A = 0;
                else if (MAP[(int)(player.Y - 2) * MAP_WIDTH + (int)player.X] == '.')
                    player.A = 3;
                else if (MAP[(int)player.Y * MAP_WIDTH + (int)(player.X + 2)] == '.')
                    player.A = 1;
                else if (MAP[(int)player.Y * MAP_WIDTH + (int)(player.X - 2)] == '.')
                    player.A = 4;
            }
            catch
            {
                player.A = 0;
            }
            stage_timer.Start();
            raycast.Start();
            time_remein.Start();
            stamina_timer.Start();
            mouse_timer.Start();
            enemy_timer.Start();
            if (MainMenu.sounds)
                step_sound_timer.Start();
            game_over_text.Visible = question.Enabled = start_btn.Enabled = false;
        }

        private void ToDefault()
        {
            player.Dead = true;
            player.SetDefault();
            if (inDebug == 1)
            {
                inDebug = 0;
                difficulty = old_difficulty;
            }
            for (int i = 0; i < GUNS.Length; i++)
                GUNS[i].SetDefault();
        }

        private void GameOver(int win)
        {
            ost[ost_index]?.Stop();
            raycast.Stop();
            shot_timer.Stop();
            reload_timer.Stop();
            time_remein.Stop();
            step_sound_timer.Stop();
            map_timer.Stop();
            stamina_timer.Stop();
            mouse_timer.Stop();
            enemy_timer.Stop();
            if (form != null)
            {
                form.Close();
                form = null;
                Opacity = 1;
            }
            shop_panel.Visible = false;
            console_panel.Visible = false;
            display.SCREEN = null;
            display.Refresh();
            stamina_panel.Width = display.Width;
            stamina_panel.Visible = false;
            question.Enabled = start_btn.Enabled = true;
            if (win == 1)
            {
                if (MainMenu.sounds)
                    tp.Play(Volume);
                if (difficulty != 4)
                    player.Stage++;
                for (int i = 0; i < player.Guns.Count; i++)
                {
                    if (player.Guns[i].MaxAmmoCount == 0)
                        player.Guns[i].MaxAmmoCount = player.Guns[i].CartridgesClip;
                }
                player.ChangeMoney(50 + (5 * player.EnemiesKilled));
                GetFirstAidKit();
                StartGame();
            }
            else if (win == 0)
            {
                ToDefault();
                game_over_text.Visible = true;
                game_over_text.BringToFront();
                if (MainMenu.sounds)
                    game_over.Play(Volume);
            }
            else
                ToDefault();
        }
    }
}