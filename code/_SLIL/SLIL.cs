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
using System.Threading.Tasks;

namespace minigames._SLIL
{
    public partial class SLIL : Form
    {

        private bool isCursorVisible = true;
        public static int CustomMazeHeight;
        public static int CustomMazeWidth;
        public static bool CUSTOM = false, ShowFPS = true;
        public static int difficulty = 2, old_difficulty;
        public static double LOOK_SPEED = 1.75f;
        public static StringBuilder CUSTOM_MAP = new StringBuilder();
        public static int CUSTOM_X, CUSTOM_Y;
        private static readonly Maze MazeGenerator = new Maze();
        private readonly Random rand = new Random();
        private const int SCREEN_HEIGHT = 228, SCREEN_WIDTH = 128;
        private static int MazeHeight;
        private static int MazeWidth;
        private int MAP_WIDTH;
        private const int START_EASY = 5, START_NORMAL = 10, START_HARD = 15, START_VERY_HARD = 20;
        private const double DEPTH = 8;
        private const double FOV = Math.PI / 3.25f;
        private double player_x = 1.5d, player_y = 1.5d, player_a = 0, look_a = 0, elapsed_time = 0;
        private const double MOVE_SPEED = 1.75d;
        private const double PLAYER_STAMINE = 450, PLAYER_HP = 100;
        private double RUN_SPEED = 0, STAMINE = PLAYER_STAMINE, HP = PLAYER_HP;
        private static double enemy_count;
        private static StringBuilder MAP = new StringBuilder();
        private static readonly StringBuilder DISPLAYED_MAP = new StringBuilder();
        private readonly Bitmap SCREEN = new Bitmap(SCREEN_WIDTH, SCREEN_HEIGHT);
        private readonly Bitmap WEAPON = new Bitmap(SCREEN_HEIGHT, SCREEN_WIDTH);
        private readonly Font consolasFont = new Font("Consolas", 9.25F);
        private readonly SolidBrush whiteBrush = new SolidBrush(Color.White);
        private readonly StringFormat rightToLeft = new StringFormat() { FormatFlags = StringFormatFlags.DirectionRightToLeft };
        private readonly Graphics graphicsWeapon;
        private readonly Color[] COLORS =
        {
            //ceiling:
            Color.FromArgb(100, 100, 100), 
            //walls\windows:
            Color.FromArgb(160, 160, 160),
            //finish:
            Color.Lime,
            //floor:
            Color.FromArgb(80, 80, 80),
            //door:
            Color.FromArgb(189, 183, 107),
            //enemy classic
            Color.Red,
            //enemy faster
            Color.Navy,
            //big enemy
            Color.Purple
        };
        private int seconds, minutes, fps;
        private enum Direction { STOP, FORWARD, BACK, LEFT, RIGHT, WALK, RUN };
        private Direction playerDirection = Direction.STOP, strafeDirection = Direction.STOP, playerMoveStyle = Direction.WALK;
        private DateTime total_time = DateTime.Now;
        private List<int> soundIndices = new List<int> { 0, 1, 2, 3, 4 };
        private int currentIndex = 0;
        private bool map_presed = false, active = true;
        private map_form form;
        private readonly PlaybackState playbackState = new PlaybackState();
        private PlaySound[,] step =
        {
            {
                new PlaySound(MainMenu.CGFReader.GetFile("step_0.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_1.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_2.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_3.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_4.wav"))
            },
            {
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_0.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_1.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_2.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_3.wav")),
                new PlaySound(MainMenu.CGFReader.GetFile("step_run_4.wav"))
            },
        };
        private PlaySound[] ost =
        {
            new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_0.wav")),
            new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_1.wav")),
            new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_2.wav")),
            new PlaySound(MainMenu.CGFReader.GetFile("slil_ost_3.wav"))
        };
        private PlaySound[] enemy_die = 
        {
            new PlaySound(MainMenu.CGFReader.GetFile("enemy_die_0.wav")),
            new PlaySound(MainMenu.CGFReader.GetFile("enemy_die_1.wav")),
            new PlaySound(MainMenu.CGFReader.GetFile("enemy_die_2.wav"))
        };
        private readonly PlaySound game_over = new PlaySound(MainMenu.CGFReader.GetFile("game_over.wav")),
            draw = new PlaySound(MainMenu.CGFReader.GetFile("draw.wav")),
            buy = new PlaySound(MainMenu.CGFReader.GetFile("buy.wav")),
            hit = new PlaySound(MainMenu.CGFReader.GetFile("hit_player.wav")),
            wall = new PlaySound(MainMenu.CGFReader.GetFile("wall_interaction.wav"));
        private PlaySound[] door = { new PlaySound(MainMenu.CGFReader.GetFile("door_opened.wav")), new PlaySound(MainMenu.CGFReader.GetFile("door_closed.wav")) };
        private static int MAX_SHOP_COUNT = 1;
        private const int WEAPONS_COUNT = 5;
        private int move_style = 0;
        private int current_gun = 0, gun_state = 0, burst_shots = 0, reload_frames = 0;
        public static int money = 15;
        private int ost_index = 0;
        private string cheat = "";
        private Image scope_hit = null;
        public static bool LevelUpdated = false, FullScreen = false;
        private bool can_shoot = false, aiming = false, in_shop = false, open_shop = false, pressed_r = false;
        private readonly Gun[] GUNS = { new Gun(0), new Gun(1), new Gun(2), new Gun(3), new Gun(4), new Gun(5), new Gun(6) };
        public static readonly List<Gun> guns = new List<Gun>();
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        private readonly string[] codes =
        {
            //выдать всё оружие:
            "UpUpDownDownLeftRightLeftRightBASpace",
            //прокачать всё оружие
            "IDDQD",
            //выдать максимум патронов
            "FYTLG",
            //выдать 9999 денег
            "SOTLG",
            //выдать пальцестрел
            "YHRII",
            //выдать "самый маленький пистолет в мире"
            "BIGGUY",
            //выдать 999 HP
            "GKIFK"
        };

        public SLIL()
        {
            InitializeComponent();
            graphicsWeapon = Graphics.FromImage(WEAPON);
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
                bool completed = await step[i, j].PlayWithWait(0.45f, playbackState);
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
            if (!raycast.Enabled && display.BackgroundImage != null && display.Image != null)
                display.BackgroundImage = display.Image = null;
            bool shouldShowCursor = start_btn.Enabled || (in_shop && open_shop) || (active && start_btn.Enabled);
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
            FullScreen = WindowState == FormWindowState.Maximized;
            if (!reload_timer.Enabled)
                stamina_panel.Width = (int)(STAMINE / PLAYER_STAMINE * top_panel.Width);
            if (MainMenu.Language)
                shop_money.Text = $"$: {money}";
            else
                shop_money.Text = $"$: {money}";
            try
            {
                if (guns[current_gun].GunType == GunTypes.Tank)
                {
                    stamina_panel.Visible = true;
                    if (playerMoveStyle != Direction.WALK)
                        playerMoveStyle = Direction.WALK;
                    if (STAMINE > 15)
                        STAMINE -= 15;
                }
                if (playerMoveStyle == Direction.RUN)
                {
                    if (guns[current_gun].GunType == GunTypes.Pistol || guns[current_gun].GunType == GunTypes.Shotgun || guns[current_gun].GunType == GunTypes.EasterEgg)
                        move_style = 5;
                    else
                        move_style = 4;
                }
                else
                {
                    if (guns[current_gun].GunType == GunTypes.Pistol && guns[current_gun].AmmoCount <= 0 && guns[current_gun].Level != Levels.LV3 && !shot_timer.Enabled && !reload_timer.Enabled)
                        move_style = 4;
                    else
                        move_style = 0;
                }
                if (!shot_timer.Enabled && !reload_timer.Enabled && gun_state != move_style && !aiming)
                    gun_state = move_style;
                if (LevelUpdated && !open_shop)
                {
                    ChangeWeapon(current_gun);
                    LevelUpdated = false;
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
                else if (start_btn.Enabled)
                    Close();
                else
                    GameOver(-1);
                return;
            }
            if (!start_btn.Enabled)
            {
                if (!open_shop)
                {
                    if (e.KeyCode == Keys.ShiftKey && playerDirection == Direction.FORWARD && STAMINE >= PLAYER_STAMINE / 1.75 && !aiming && !reload_timer.Enabled)
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
                        form = new map_form
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
                    if (e.KeyCode == Keys.R && !reload_timer.Enabled && !shot_timer.Enabled)
                    {
                        if (guns[current_gun].AmmoCount != guns[current_gun].CartridgesClip && guns[current_gun].MaxAmmoCount > 0)
                        {
                            pressed_r = true;
                            can_shoot = false;
                            aiming = false;
                            int sound = 1;
                            if (guns[current_gun].GunType != GunTypes.Shotgun)
                            {
                                gun_state = 2;
                                if (guns[current_gun].GunType == GunTypes.Pistol && guns[current_gun].Level != Levels.LV3 && guns[current_gun].AmmoCount == 0)
                                    gun_state = 3;
                            }
                            else
                            {
                                gun_state = 3;
                                if (guns[current_gun].Level != Levels.LV1)
                                    sound = 3;
                            }
                            if (MainMenu.sounds)
                                guns[current_gun].Sounds[guns[current_gun].GetLevel(), sound].Play(0.4f);
                            reload_timer.Start();
                        }
                    }
                    if (e.KeyCode == Keys.E || e.KeyCode == Keys.Enter)
                    {
                        double x = player_x + Math.Sin(player_a);
                        double y = player_y + Math.Cos(player_a);
                        if (MAP[(int)y * MAP_WIDTH + (int)x] == 'D')
                        {
                            door[0].Play(0.4f);
                            MAP[(int)y * MAP_WIDTH + (int)x] = 'O';
                        }
                        else if (MAP[(int)y * MAP_WIDTH + (int)x] == 'O')
                        {
                            door[1].Play(0.4f);
                            MAP[(int)y * MAP_WIDTH + (int)x] = 'D';
                        }
                        else if (MainMenu.sounds)
                            wall.Play(0.4f);
                    }
                    if (!shot_timer.Enabled && !reload_timer.Enabled)
                    {
                        if (e.KeyCode == Keys.D1)
                            ChangeWeapon(0);
                        if (e.KeyCode == Keys.D2 && guns.Count > 1)
                            ChangeWeapon(1);
                        if (e.KeyCode == Keys.D3 && guns.Count > 2)
                            ChangeWeapon(2);
                        if (e.KeyCode == Keys.D4 && guns.Count > 3)
                            ChangeWeapon(3);
                        if (e.KeyCode == Keys.D5 && guns.Count > 4)
                            ChangeWeapon(4);
                        if (e.KeyCode == Keys.D6 && guns.Count > 5)
                            ChangeWeapon(5);
                        if (e.KeyCode == Keys.D7 && guns.Count > 6)
                            ChangeWeapon(6);
                    }
                }
                if (e.KeyCode == Keys.B && in_shop)
                {
                    open_shop = !open_shop;
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
            else
            {
                if (e.KeyCode == Keys.Space)
                    StartGame();
            }
            cheat += e.KeyCode.ToString();
            if (e.KeyCode == Keys.Back)
                cheat = null;
            if (cheat == codes[0])
            {
                money = 9999;
                for (int i = 0; i < GUNS.Length; i++)
                {
                    if (GUNS[i].GunType != GunTypes.EasterEgg && GUNS[i].GunType != GunTypes.Tank)
                    {
                        GUNS[i].MaxAmmoCount = GUNS[i].MaxAmmo;
                        if (i > 0)
                        {
                            GUNS[i].HasIt = true;
                            if (!guns.Contains(GUNS[i]))
                                guns.Add(GUNS[i]);
                        }
                    }
                }
                cheat = null;
            }
            else if (cheat == codes[1])
            {
                for (int i = 0; i < guns.Count; i++)
                    guns[i].LevelUpdate();
                LevelUpdated = true;
                cheat = null;
            }
            else if (cheat == codes[2])
            {
                for (int i = 0; i < guns.Count; i++)
                {
                    if (GUNS[i].GunType != GunTypes.EasterEgg)
                        guns[i].MaxAmmoCount = guns[i].MaxAmmo;
                }
                cheat = null;
            }
            else if (cheat == codes[3])
            {
                money = 9999;
                cheat = null;
            }
            else if (cheat == codes[4])
            {
                if (!GUNS[5].HasIt)
                {
                    GUNS[5].HasIt = true;
                    GUNS[5].MaxAmmoCount = GUNS[5].MaxAmmo;
                    if (!guns.Contains(GUNS[5]))
                        guns.Add(GUNS[5]);
                }
                cheat = null;
            }
            else if (cheat == codes[5])
            {
                if (!GUNS[6].HasIt)
                {
                    GUNS[6].HasIt = true;
                    GUNS[6].MaxAmmoCount = GUNS[6].MaxAmmo;
                    if (!guns.Contains(GUNS[6]))
                        guns.Add(GUNS[6]);
                }
                cheat = null;
            }
            else if (cheat == codes[6])
            {
                HP = 999;
                cheat = null;
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

        private void Display_Scroll(object sender, MouseEventArgs e)
        {
            if (!shot_timer.Enabled && !reload_timer.Enabled)
            {
                int new_gun = current_gun;
                if (e.Delta > 0)
                    new_gun--;
                else
                    new_gun++;
                if (new_gun < 0)
                    new_gun = guns.Count - 1;
                else if (new_gun > guns.Count - 1)
                    new_gun = 0;
                ChangeWeapon(new_gun);
            }
        }

        private void SLIL_Activated(object sender, EventArgs e) => active = true;

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
            if ((new_gun != current_gun || LevelUpdated) && guns[new_gun].HasIt)
            {
                if (MainMenu.sounds)
                    draw.Play(0.4f);
                current_gun = new_gun;
                aiming = false;
                gun_state = move_style;
                reload_timer.Interval = guns[current_gun].RechargeTime;
                shot_timer.Interval = guns[current_gun].FiringRate;
            }
        }

        private void Display_MouseDown(object sender, MouseEventArgs e)
        {
            if (can_shoot && !reload_timer.Enabled && !shot_timer.Enabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (guns[current_gun].MaxAmmoCount >= 0 && guns[current_gun].AmmoCount > 0)
                    {
                        if (guns[current_gun].GunType == GunTypes.Sniper && !aiming)
                            return;
                        if (MainMenu.sounds)
                            guns[current_gun].Sounds[guns[current_gun].GetLevel(), 0].Play(0.4f);
                        gun_state = 1;
                        aiming = false;
                        can_shoot = false;
                        burst_shots = 0;
                        if (guns[current_gun].FireType == FireTypes.Single)
                            BulletRayCasting();
                        look_a -= guns[current_gun].Recoil;
                        shot_timer.Start();
                    }
                    else if (guns[current_gun].MaxAmmoCount > 0 && guns[current_gun].AmmoCount == 0)
                    {
                        gun_state = 2;
                        if (guns[current_gun].GunType == GunTypes.Pistol || guns[current_gun].GunType == GunTypes.Shotgun)
                            gun_state = 3;
                        aiming = false;
                        reload_timer.Start();
                        if (guns[current_gun].GunType == GunTypes.Shotgun && guns[current_gun].Level != Levels.LV1)
                            return;
                        if (MainMenu.sounds)
                            guns[current_gun].Sounds[guns[current_gun].GetLevel(), 1].Play(0.4f);
                    }
                    else if (!(guns[current_gun].GunType == GunTypes.Pistol && guns[current_gun].Level == Levels.LV1) &&
                        !(guns[current_gun].GunType == GunTypes.Shotgun && guns[current_gun].Level == Levels.LV1) && MainMenu.sounds)
                        guns[current_gun].Sounds[guns[current_gun].GetLevel(), 2].Play(0.4f);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (guns[current_gun].GunType == GunTypes.Sniper)
                    {
                        if (MainMenu.sounds)
                            guns[current_gun].Sounds[guns[current_gun].GetLevel(), 3].Play(0.4f);
                        aiming = !aiming;
                        gun_state = aiming ? 3 : 0;
                    }
                }
            }
        }

        private void BulletRayCasting()
        {
            double rayA = player_a + FOV / 2 - (SCREEN_WIDTH / 2) * FOV / SCREEN_WIDTH;
            double ray_x = Math.Sin(rayA);
            double ray_y = Math.Cos(rayA);
            double distance = 0;
            bool hit = false;
            int factor = aiming ? 12 : 0;
            scope_hit = null;
            while (!hit && distance < guns[current_gun].FiringRange)
            {
                if (start_btn.Enabled)
                    break;
                distance += 0.1d;
                int test_x = (int)(player_x + ray_x * distance);
                int test_y = (int)(player_y + ray_y * distance);
                if (test_x < 0 || test_x >= (DEPTH + factor) + player_x || test_y < 0 || test_y >= (DEPTH + factor) + player_y)
                    hit = true;
                else
                {
                    char test_wall = MAP[test_y * MAP_WIDTH + test_x];
                    double celling = (SCREEN_HEIGHT - look_a) / 2.25d - (SCREEN_HEIGHT * FOV) / distance;
                    double floor = SCREEN_HEIGHT - (celling + look_a);
                    double mid = (celling + floor) / 2;
                    if (test_wall == '#' || test_wall == 'F' || test_wall == 'D')
                        hit = true;
                    else if (test_wall == '=' && SCREEN_HEIGHT / 2 >= mid)
                        hit = true;
                    else if (test_wall == 'E')
                    {
                        hit = true;
                        if (SCREEN_HEIGHT / 2 > celling && SCREEN_HEIGHT / 2 <= floor)
                        {
                            double damage = (double)rand.Next((int)(guns[current_gun].MinDamage * 100), (int)(guns[current_gun].MaxDamage * 100)) / 100;
                            if (guns[current_gun].GunType == GunTypes.Shotgun)
                                damage *= guns[current_gun].FiringRange - distance;
                            bool all_ok = false;
                            for (int i = 0; i < Enemies.Count; i++)
                            {
                                if (Enemies[i].DEAD)
                                    continue;
                                if (Enemies[i].IntX == test_x && Enemies[i].IntY == test_y)
                                {
                                    if (Enemies[i].DealDamage(damage))
                                    {
                                        MAP[test_y * MAP_WIDTH + test_x] = '.';
                                        money += rand.Next(Enemies[i].MIN_MONEY[Enemies[i].Type], Enemies[i].MAX_MONEY[Enemies[i].Type]);
                                        if (MainMenu.sounds)
                                            enemy_die[rand.Next(0, enemy_die.Length)].Play(0.4f);
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
        }

        private void Reload_gun_Tick(object sender, EventArgs e)
        {
            try
            {
                scope_hit = null;
                if (!start_btn.Enabled)
                {
                    int index = 1;
                    if (guns[current_gun].GunType == GunTypes.Shotgun && (guns[current_gun].MaxAmmoCount == 0 || pressed_r))
                    {
                        if (guns[current_gun].Level == Levels.LV1)
                            index = 2;
                        else
                        {
                            index = 3;
                            if (pressed_r)
                                index--;
                        }
                    }
                    if (!pressed_r && guns[current_gun].AmmoCount > 0 && guns[current_gun].GunType == GunTypes.Shotgun)
                    {
                        gun_state = move_style;
                        can_shoot = true;
                        reload_timer.Stop();
                        reload_frames = 0;
                        return;
                    }
                    if (reload_frames >= guns[current_gun].ReloadFrames - index)
                    {
                        gun_state = move_style;
                        pressed_r = false;
                        can_shoot = true;
                        guns[current_gun].ReloadClip();
                        reload_timer.Stop();
                        reload_frames = 0;
                        return;
                    }
                    else if (guns[current_gun].ReloadFrames > 1)
                        gun_state++;
                    reload_frames++;
                    if (guns[current_gun].GunType == GunTypes.Shotgun && MainMenu.sounds)
                        guns[current_gun].Sounds[guns[current_gun].GetLevel(), 3].Play(0.4f);
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
                if (burst_shots >= guns[current_gun].BurstShots)
                    shot_timer.Stop();
                else
                {
                    if (guns[current_gun].BurstShots > 1)
                        look_a -= guns[current_gun].Recoil;
                    if (guns[current_gun].FireType != FireTypes.Single)
                        gun_state = gun_state == 1 ? 0 : 1;
                    else
                        gun_state = aiming ? 3 : 0;
                    guns[current_gun].AmmoCount--;
                    if (look_a > -165 && look_a < 204 && guns[current_gun].FireType != FireTypes.Single)
                        BulletRayCasting();
                    if (guns[current_gun].AmmoCount <= 0 && guns[current_gun].MaxAmmoCount > 0)
                    {
                        gun_state = 2;
                        if (guns[current_gun].GunType == GunTypes.Pistol && guns[current_gun].Level != Levels.LV3)
                            gun_state = 3;
                        aiming = false;
                        if (MainMenu.sounds)
                            guns[current_gun].Sounds[guns[current_gun].GetLevel(), 1].Play(0.4f);
                        reload_timer.Start();
                    }
                    else if (guns[current_gun].AmmoCount <= 0)
                    {
                        aiming = false;
                        can_shoot = true;
                        gun_state = move_style;
                        if (guns[current_gun].GunType == GunTypes.Pistol && guns[current_gun].Level != Levels.LV3)
                            gun_state = 4;
                        else if (guns[current_gun].GunType == GunTypes.Shotgun)
                        {
                            if (guns[current_gun].Level == Levels.LV1 || guns[current_gun].MaxAmmoCount == 0)
                                gun_state = 2;
                            else
                                gun_state = 3;
                            if (MainMenu.sounds)
                                guns[current_gun].Sounds[guns[current_gun].GetLevel(), 1].Play(0.4f);
                            reload_timer.Start();
                        }
                    }
                    else
                    {
                        if (guns[current_gun].FireType == FireTypes.Single)
                            gun_state = aiming ? 3 : 0;
                        if (guns[current_gun].GunType == GunTypes.Shotgun && guns[current_gun].Level != Levels.LV1)
                        {
                            gun_state = 2;
                            if (MainMenu.sounds)
                                guns[current_gun].Sounds[guns[current_gun].GetLevel(), 1].Play(0.4f);
                            reload_timer.Start();
                        }
                        can_shoot = true;
                    }
                }
                burst_shots++;
                if (!shot_timer.Enabled || guns[current_gun].FireType == FireTypes.Single)
                    scope_hit = null;
            }
            catch { }
        }

        private void Enemy_timer_Tick(object sender, EventArgs e)
        {
            Parallel.For(0, Enemies.Count, i =>
            {
                Enemy enemy = Enemies[i];
                if (enemy.DEAD && enemy.RESPAWN > 0)
                    enemy.RESPAWN--;
                else if (enemy.DEAD && enemy.RESPAWN <= 0)
                    enemy.Respawn();
                if (!enemy.DEAD)
                {
                    MAP[(int)enemy.Y * MAP_WIDTH + (int)enemy.X] = '.';
                    enemy.UpdateCoordinates(MAP.ToString());
                    if (enemy.Type == 1)
                        enemy.UpdateCoordinates(MAP.ToString());
                    MAP[(int)enemy.Y * MAP_WIDTH + (int)enemy.X] = 'E';
                    if (Math.Abs(enemy.X - player_x) <= 1 && Math.Abs(enemy.Y - player_y) <= 1)
                    {
                        enemy.Kill();
                        MAP[(int)enemy.Y * MAP_WIDTH + (int)enemy.X] = '.';
                        HP -= rand.Next(enemy.MIN_DAMAGE[enemy.Type], enemy.MAX_DAMAGE[enemy.Type]);
                        if (HP <= 0)
                        {
                            GameOver(0);
                            return;
                        }
                        if (MainMenu.sounds)
                            hit.Play(0.4f);
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
            if (playerMoveStyle == Direction.RUN && playerDirection == Direction.FORWARD && !aiming && !reload_timer.Enabled)
            {
                stamina_panel.Visible = true;
                if (STAMINE <= 0)
                    playerMoveStyle = Direction.WALK;
                else
                    STAMINE -= 3;
            }
            else
            {
                playerMoveStyle = Direction.WALK;
                if (STAMINE >= PLAYER_STAMINE)
                {
                    stamina_panel.Width = display.Width;
                    stamina_panel.Visible = false;
                }
                else
                    STAMINE += 2;
            }
        }

        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            if (!start_btn.Enabled && active)
            {
                int scale = WindowState == FormWindowState.Maximized ? 3 : 1;
                double x = display.Width / 2, y = display.Height / 2;
                double X = e.X - x, Y = e.Y - y;
                double size = MainMenu.scaled ? MainMenu.scale_size * 0.95 : 1;
                player_a -= (((X / x) / 10) * (LOOK_SPEED * size)) * scale;
                look_a += (((Y / y) * 30) * (LOOK_SPEED * size)) * scale;
                if (look_a < -360)
                    look_a = -360;
                else if (look_a > 360)
                    look_a = 360;
                Cursor.Position = display.PointToScreen(new Point((int)x, (int)y));
            }
        }

        private void PlayerMove()
        {
            if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'P')
            {
                MAP[(int)player_y * MAP_WIDTH + (int)player_x] = '.';
                DISPLAYED_MAP[(int)player_y * MAP_WIDTH + (int)player_x] = '.';
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
            switch (strafeDirection)
            {
                case Direction.LEFT:
                    player_x += Math.Cos(player_a) * move / 1.4f;
                    player_y -= Math.Sin(player_a) * move / 1.4f;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '=' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'D')
                    {
                        player_x -= Math.Cos(player_a) * move / 1.4f;
                        player_y += Math.Sin(player_a) * move / 1.4f;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'F')
                    {
                        GameOver(1);
                        return;
                    }
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '$')
                        in_shop = true;
                    else
                        in_shop = false;
                    break;
                case Direction.RIGHT:
                    player_x -= Math.Cos(player_a) * move / 1.4f;
                    player_y += Math.Sin(player_a) * move / 1.4f;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '=' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'D')
                    {
                        player_x += Math.Cos(player_a) * move / 1.4f;
                        player_y -= Math.Sin(player_a) * move / 1.4f;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'F')
                    {
                        GameOver(1);
                        return;
                    }
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '$')
                        in_shop = true;
                    else
                        in_shop = false;
                    break;
            }
            switch (playerDirection)
            {
                case Direction.FORWARD:
                    player_x += Math.Sin(player_a) * move;
                    player_y += Math.Cos(player_a) * move;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '=' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'D')
                    {
                        player_x -= Math.Sin(player_a) * move;
                        player_y -= Math.Cos(player_a) * move;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'F')
                    {
                        GameOver(1);
                        return;
                    }
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '$')
                        in_shop = true;
                    else
                        in_shop = false;
                    break;
                case Direction.BACK:
                    player_x -= Math.Sin(player_a) * move;
                    player_y -= Math.Cos(player_a) * move;
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '#' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '=' || MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'D')
                    {
                        player_x += Math.Sin(player_a) * move;
                        player_y += Math.Cos(player_a) * move;
                    }
                    else if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == 'F')
                    {
                        GameOver(1);
                        return;
                    }
                    if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '$')
                        in_shop = true;
                    else
                        in_shop = false;
                    break;
            }
            if (MAP[(int)player_y * MAP_WIDTH + (int)player_x] == '.')
            {
                MAP[(int)player_y * MAP_WIDTH + (int)player_x] = 'P';
                DISPLAYED_MAP[(int)player_y * MAP_WIDTH + (int)player_x] = 'P';
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
            }
            for (int i = 0; i < WEAPONS_COUNT; i++)
            {
                if (GUNS[i].GunType != GunTypes.EasterEgg)
                {
                    SLIL_ShopInterface ShopInterface = new SLIL_ShopInterface()
                    {
                        Left = 6,
                        Top = 82 * i,
                        width = shop_panel.Width - 30,
                        index = MainMenu.Language ? 0 : 1,
                        weapon = GUNS[i],
                        buy = buy,
                        BackColor = shop_panel.BackColor
                    };
                    ShopInterface_panel.Controls.Add(ShopInterface);
                }
            }
            LOOK_SPEED = INIReader.GetDouble(MainMenu.iniFolder, "SLIL", "look_speed", 1.75);
            ShowFPS = INIReader.GetBool(MainMenu.iniFolder, "SLIL", "show_fps", true);
            difficulty = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "difficulty", 1);
            CustomMazeHeight = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "custom_maze_height", 10);
            CustomMazeWidth = INIReader.GetInt(MainMenu.iniFolder, "SLIL", "custom_maze_width", 10);
            if (LOOK_SPEED < 2.5 || LOOK_SPEED > 10)
                LOOK_SPEED = 2.75d;
            if (difficulty < 0 || difficulty > 4)
                difficulty = 1;
            if (CustomMazeHeight < 2 || CustomMazeHeight > 150)
                CustomMazeHeight = 10;
            if (CustomMazeWidth < 2 || CustomMazeWidth > 150)
                CustomMazeWidth = 10;
            old_difficulty = difficulty;
            game_over_text.Size = display.Size;
            game_over_text.Location = new Point(0, display.Top);
            shop_panel.Size = display.Size;
            shop_panel.Location = new Point(0, display.Top);
            shop_money.Left = (shop_panel.Width - shop_money.Width) / 2;
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
            foreach (Control control in ShopInterface_panel.Controls)
            {
                if(control is SLIL_ShopInterface)
                {
                    SLIL_ShopInterface ShopInterface = control as SLIL_ShopInterface;
                    ShopInterface.cant_pressed?.Dispose();
                    ShopInterface.cant_pressed = null;
                }
            }
            FullScreen = false;
            money = 15;
            for (int i = 0; i < step.GetLength(0); i++)
            {
                for (int j = 0; j < step.GetLength(1); j++)
                    step[i, j]?.Dispose();
            }
            step = null;
            for (int i = 0; i < guns.Count; i++)
            {
                for (int j = 0; j < guns[i].Sounds.GetLength(0); j++)
                {
                    for (int k = 0; k < guns[i].Sounds.GetLength(1); k++)
                        guns[i].Sounds[j, k]?.Dispose();
                }
                guns[i].Sounds = null;
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

        private Color DarkenColor(Color color, float darkenPercentage)
        {
            float r = (float)color.R / 255;
            float g = (float)color.G / 255;
            float b = (float)color.B / 255;
            float darkenAmount = 1 - (darkenPercentage / 100);
            r *= darkenAmount;
            g *= darkenAmount;
            b *= darkenAmount;
            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
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
            display.BackgroundImage = SCREEN;
            display.Image = WEAPON;
            display.Refresh();
            fps = CalculateFPS(elapsed_time);
        }

        private Pixel[][] CastRaysParallel()
        {
            Pixel[][] rays = new Pixel[SCREEN_WIDTH][];
            Parallel.For(0, SCREEN_WIDTH, x => rays[x] = CastRay(x));
            return rays;
        }

        private void DrawRaysOnScreen(Pixel[][] rays)
        {
            foreach (Pixel[] list in rays)
            {
                foreach (Pixel pixel in list)
                    SCREEN.SetPixel(pixel.X, pixel.Y, pixel.COLOR);
            }
        }

        private void ClearDisplayedMap()
        {
            for (int i = 0; i < DISPLAYED_MAP.Length; i++)
            {
                if (DISPLAYED_MAP[i] == '*')
                    DISPLAYED_MAP[i] = '.';
            }
        }

        private void DrawWeaponGraphics()
        {
            string space_0 = "0", space_1 = "0";
            if (seconds > 9)
                space_1 = "";
            if (minutes > 9)
                space_0 = "";
            try
            {
                graphicsWeapon.Clear(Color.Transparent);
                graphicsWeapon.DrawImage(guns[current_gun].Images[guns[current_gun].GetLevel(), gun_state], 0, 0, WEAPON.Width, WEAPON.Height);
                graphicsWeapon.DrawImage(Properties.Resources.hp, 2, 108, 14, 14);
                if (ShowFPS)
                    graphicsWeapon.DrawString($"FPS: {fps}", consolasFont, whiteBrush, 228, 0, rightToLeft);
                graphicsWeapon.DrawString($"TIME LEFT: {space_0}{minutes}:{space_1}{seconds}", consolasFont, whiteBrush, 0, 0);
                graphicsWeapon.DrawImage(Properties.Resources.money, 2, 14, 14, 14);
                graphicsWeapon.DrawString(money.ToString(), consolasFont, whiteBrush, 16, 14);
                graphicsWeapon.DrawString(HP.ToString(), consolasFont, whiteBrush, 16, 108);
                graphicsWeapon.DrawString($"{guns[current_gun].MaxAmmoCount}/{guns[current_gun].AmmoCount}", consolasFont, whiteBrush, 54, 108);
                if (guns.Count > 0)
                {
                    if (guns[current_gun].GunType == GunTypes.Sniper || guns[current_gun].GunType == GunTypes.Rifle)
                        graphicsWeapon.DrawImage(Properties.Resources.rifle_bullet, 40, 108, 14, 14);
                    else if (guns[current_gun].GunType == GunTypes.Shotgun)
                        graphicsWeapon.DrawImage(Properties.Resources.shell, 40, 108, 14, 14);
                    else
                        graphicsWeapon.DrawImage(Properties.Resources.bullet, 40, 108, 14, 14);
                }
                if (in_shop)
                    graphicsWeapon.DrawImage(Properties.Resources.shop, 2, 28, 14, 14);
                if (guns[current_gun].GunType != GunTypes.Sniper)
                {
                    if (guns[current_gun].GunType == GunTypes.Shotgun)
                        graphicsWeapon.DrawImage(Properties.Resources.scope_shotgun, 0, 0, WEAPON.Width, WEAPON.Height);
                    else
                        graphicsWeapon.DrawImage(Properties.Resources.scope, 0, 0, WEAPON.Width, WEAPON.Height);
                    if (scope_hit != null)
                        graphicsWeapon.DrawImage(scope_hit, 0, 0, WEAPON.Width, WEAPON.Height);
                }
            }
            catch
            {
                try
                {
                    graphicsWeapon.Clear(Color.Transparent);
                    graphicsWeapon.DrawImage(guns[current_gun].Images[guns[current_gun].GetLevel(), 0], 0, 0, WEAPON.Width, WEAPON.Height);
                    graphicsWeapon.DrawImage(Properties.Resources.hp, 2, 108, 14, 14);
                    if (ShowFPS)
                        graphicsWeapon.DrawString($"FPS: {fps}", consolasFont, whiteBrush, 228, 0, rightToLeft);
                    graphicsWeapon.DrawString($"TIME LEFT: {space_0}{minutes}:{space_1}{seconds}", consolasFont, whiteBrush, 0, 0);
                    graphicsWeapon.DrawImage(Properties.Resources.money, 2, 14, 14, 14);
                    graphicsWeapon.DrawString(money.ToString(), consolasFont, whiteBrush, 16, 14);
                    graphicsWeapon.DrawString(HP.ToString(), consolasFont, whiteBrush, 16, 108);
                    graphicsWeapon.DrawString($"{guns[current_gun].MaxAmmoCount}/{guns[current_gun].AmmoCount}", consolasFont, whiteBrush, 54, 108);
                    if (guns.Count > 0)
                    {
                        if (guns[current_gun].GunType == GunTypes.Sniper || guns[current_gun].GunType == GunTypes.Rifle)
                            graphicsWeapon.DrawImage(Properties.Resources.rifle_bullet, 40, 108, 14, 14);
                        else if (guns[current_gun].GunType == GunTypes.Shotgun)
                            graphicsWeapon.DrawImage(Properties.Resources.shell, 40, 108, 14, 14);
                        else
                            graphicsWeapon.DrawImage(Properties.Resources.bullet, 40, 108, 14, 14);
                    }
                    if (in_shop)
                        graphicsWeapon.DrawImage(Properties.Resources.shop, 2, 28, 14, 14);
                    if (guns[current_gun].GunType != GunTypes.Sniper)
                    {
                        if (guns[current_gun].GunType == GunTypes.Shotgun)
                            graphicsWeapon.DrawImage(Properties.Resources.scope_shotgun, 0, 0, WEAPON.Width, WEAPON.Height);
                        else
                            graphicsWeapon.DrawImage(Properties.Resources.scope, 0, 0, WEAPON.Width, WEAPON.Height);
                        if (scope_hit != null)
                            graphicsWeapon.DrawImage(scope_hit, 0, 0, WEAPON.Width, WEAPON.Height);
                    }
                }
                catch { }
            }
        }

        private int CalculateFPS(double elapsedTime)
        {
            int fps = (int)(1 / elapsedTime);
            return fps < 0 ? 0 : fps;
        }

        private Pixel[] CastRay(int x)
        {
            Pixel[] result = new Pixel[SCREEN_HEIGHT];
            int factor = aiming ? 12 : 0;
            double distance = 0f;
            double window_distance = 0f;
            int enemy_type = 0;
            bool hit_wall = false;
            bool hit_window = false;
            bool hit_door = false;
            bool hit_finish = false;
            bool hit_enemy = false;
            bool is_bound = false;
            bool is_window_bound = false;
            bool is_door_bound = false;
            double rayA = player_a + FOV / 2 - x * FOV / SCREEN_WIDTH;
            double ray_x = Math.Sin(rayA);
            double ray_y = Math.Cos(rayA);
            while (raycast.Enabled && !hit_wall && !hit_door && !hit_finish && !hit_enemy && distance < DEPTH + factor)
            {
                distance += 0.1f;
                if (!hit_window)
                    window_distance += 0.1f;
                int test_x = (int)(player_x + ray_x * distance);
                int test_y = (int)(player_y + ray_y * distance);
                if (test_x < 0 || test_x >= (DEPTH + factor) + player_x || test_y < 0 || test_y >= (DEPTH + factor) + player_y)
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
                        is_door_bound = CheckBound(test_x, test_y, ray_x, ray_y, distance);
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = 'D';
                        break;
                    case 'F':
                        hit_finish = true;
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = 'F';
                        break;
                    case 'E':
                        hit_enemy = true;
                        enemy_type = GetEnemyType(test_x, test_y);
                        break;
                    case '.':
                    case '*':
                        DISPLAYED_MAP[test_y * MAP_WIDTH + test_x] = '*';
                        break;
                }
            }
            double celling = (SCREEN_HEIGHT - look_a) / 2.25d - (SCREEN_HEIGHT * FOV) / distance;
            double floor = SCREEN_HEIGHT - (celling + look_a);
            double mid = (celling + floor) / 2;
            for (int y = 0; y < SCREEN_HEIGHT; y++)
            {
                Color color = Color.Black;
                if (hit_window && y > mid)
                {
                    celling = (SCREEN_HEIGHT - look_a) / 2.25d - (SCREEN_HEIGHT * FOV) / window_distance;
                    floor = SCREEN_HEIGHT - (celling + look_a);
                }
                else
                {
                    celling = (SCREEN_HEIGHT - look_a) / 2.25d - (SCREEN_HEIGHT * FOV) / distance;
                    floor = SCREEN_HEIGHT - (celling + look_a);
                }
                if (y <= celling)
                {
                    double d = ((y + look_a / 2) / (SCREEN_HEIGHT / 2));
                    if (d < 0.15d)
                        color = COLORS[0];
                    else if (d < 0.3d)
                        color = DarkenColor(COLORS[0], 20);
                    else if (d < 0.45d)
                        color = DarkenColor(COLORS[0], 40);
                    else if (d < 0.6d)
                        color = DarkenColor(COLORS[0], 60);
                    else if (d < 0.65d)
                        color = DarkenColor(COLORS[0], 80);
                    else
                        color = Color.Black;
                }
                else if (y >= mid && y <= floor && hit_window)
                {
                    if (Math.Abs(y - mid) <= 5 || is_window_bound)
                    {
                        if (window_distance < (DEPTH + factor) * 0.15)
                            color = DarkenColor(Color.White, 15);
                        else if (window_distance < (DEPTH + factor) * 0.3)
                            color = DarkenColor(Color.White, 30);
                        else if (window_distance < (DEPTH + factor) * 0.45)
                            color = DarkenColor(Color.White, 45);
                        else if (window_distance < (DEPTH + factor) * 0.6)
                            color = DarkenColor(Color.White, 60);
                        else if (window_distance < (DEPTH + factor) * 0.75)
                            color = DarkenColor(Color.White, 75);
                        else if (window_distance < (DEPTH + factor) * 0.9)
                            color = DarkenColor(Color.White, 90);
                        else
                            color = Color.Black;
                    }
                    else if (window_distance < (DEPTH + factor) * 0.15)
                        color = DarkenColor(COLORS[1], 15);
                    else if (window_distance < (DEPTH + factor) * 0.3)
                        color = DarkenColor(COLORS[1], 30);
                    else if (window_distance < (DEPTH + factor) * 0.45)
                        color = DarkenColor(COLORS[1], 45);
                    else if (window_distance < (DEPTH + factor) * 0.6)
                        color = DarkenColor(COLORS[1], 60);
                    else if (window_distance < (DEPTH + factor) * 0.75)
                        color = DarkenColor(COLORS[1], 75);
                    else if (window_distance < (DEPTH + factor) * 0.9)
                        color = DarkenColor(COLORS[1], 90);
                    else
                        color = Color.Black;
                }
                else if ((y < mid || !hit_window) && y > celling && y <= floor)
                {
                    int index = 1;
                    if (hit_finish)
                        index = 2;
                    else if (hit_enemy)
                    {
                        if (enemy_type == 0)
                            index = 5;
                        else if (enemy_type == 1)
                            index = 6;
                        else
                            index = 7;
                    }
                    else if (hit_door)
                        index = 4;
                    if (is_bound || is_door_bound)
                    {
                        Color bound = Color.White;
                        if (is_door_bound)
                            bound = Color.FromArgb(230, 223, 174);
                        if (distance < (DEPTH + factor) * 0.15)
                            color = DarkenColor(bound, 15);
                        else if (distance < (DEPTH + factor) * 0.3)
                            color = DarkenColor(bound, 30);
                        else if (distance < (DEPTH + factor) * 0.45)
                            color = DarkenColor(bound, 45);
                        else if (distance < (DEPTH + factor) * 0.6)
                            color = DarkenColor(bound, 60);
                        else if (distance < (DEPTH + factor) * 0.75)
                            color = DarkenColor(bound, 75);
                        else if (distance < (DEPTH + factor) * 0.9)
                            color = DarkenColor(bound, 90);
                        else
                            color = Color.Black;
                    }
                    else if (distance < (DEPTH + factor) * 0.15)
                        color = DarkenColor(COLORS[index], 15);
                    else if (distance < (DEPTH + factor) * 0.3)
                        color = DarkenColor(COLORS[index], 30);
                    else if (distance < (DEPTH + factor) * 0.45)
                        color = DarkenColor(COLORS[index], 45);
                    else if (distance < (DEPTH + factor) * 0.6)
                        color = DarkenColor(COLORS[index], 60);
                    else if (distance < (DEPTH + factor) * 0.75)
                        color = DarkenColor(COLORS[index], 75);
                    else if (distance < (DEPTH + factor) * 0.9)
                        color = DarkenColor(COLORS[index], 90);
                    else
                        color = Color.Black;
                }
                else if (y > floor)
                {
                    double d = 1 - (y - (SCREEN_HEIGHT - look_a) / 2) / (SCREEN_HEIGHT / 2);
                    if (d < 0.15d)
                        color = COLORS[3];
                    else if (d < 0.3d)
                        color = DarkenColor(COLORS[3], 20);
                    else if (d < 0.45d)
                        color = DarkenColor(COLORS[3], 40);
                    else if (d < 0.6d)
                        color = DarkenColor(COLORS[3], 60);
                    else if (d < 0.65d)
                        color = DarkenColor(COLORS[3], 80);
                    else
                        color = Color.Black;
                }
                result[y] = new Pixel(x, y, color);
            }
            return result;
        }

        private int GetEnemyType(int x, int y)
        {
            int enemy_type = 0;
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].DEAD)
                    continue;
                if (Enemies[i].IntX == x && Enemies[i].IntY == y)
                {
                    enemy_type = Enemies[i].Type;
                    break;
                }
            }
            return enemy_type;
        }

        private bool CheckBound(int test_x, int test_y, double ray_x, double ray_y, double distance)
        {
            bool is_bound = false;
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
            return is_bound;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            StartGame();
        }

        private void InitMap()
        {
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
            else
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
            cheat = null;
            display.BackgroundImage = display.Image = null;
            display.Refresh();
            int x = display.PointToScreen(Point.Empty).X + (display.Width / 2);
            int y = display.PointToScreen(Point.Empty).Y + (display.Height / 2);
            Cursor.Position = new Point(x, y);
            seconds = 0;
            if (!CUSTOM)
                player_x = player_y = 1.5d;
            else
            {
                player_x = CUSTOM_X;
                player_y = CUSTOM_Y;
            }
            if (guns.Count == 0)
                guns.Add(GUNS[0]);
            look_a = 0;
            gun_state = 0;
            can_shoot = true;
            in_shop = false;
            LevelUpdated = false;
            STAMINE = PLAYER_STAMINE;
            stamina_panel.Width = display.Width;
            stamina_panel.Visible = false;
            Enemies.Clear();
            strafeDirection = playerDirection = Direction.STOP;
            playerMoveStyle = Direction.WALK;
            if (difficulty == 0)
            {
                minutes = START_VERY_HARD;
                MazeHeight = MazeWidth = 25;
                enemy_count = 0.07;
                MAX_SHOP_COUNT = 8;
            }
            else if (difficulty == 1)
            {
                minutes = START_HARD;
                MazeHeight = MazeWidth = 20;
                enemy_count = 0.065;
                MAX_SHOP_COUNT = 6;
            }
            else if (difficulty == 2)
            {
                minutes = START_NORMAL;
                MazeHeight = MazeWidth = 15;
                enemy_count = 0.06;
                MAX_SHOP_COUNT = 4;
                if (guns[0].Level == Levels.LV1)
                    guns[0].LevelUpdate();
            }
            else if (difficulty == 3)
            {
                minutes = START_EASY;
                MazeHeight = MazeWidth = 10;
                enemy_count = 0.055;
                MAX_SHOP_COUNT = 2;
                if (guns[0].Level == Levels.LV1)
                    guns[0].LevelUpdate();
            }
            else
            {
                minutes = 9999;
                MazeHeight = CustomMazeHeight;
                MazeWidth = CustomMazeWidth;
                enemy_count = 0.06;
                MAX_SHOP_COUNT = 3;
            }
            MAP_WIDTH = MazeWidth * 3 + 1;
            if (MainMenu.sounds)
            {
                ost_index = rand.Next(ost.Length);
                ost[ost_index].LoopPlay(0.4f);
            }
        }

        private void StartGame()
        {
            ResetDefault();
            InitMap();
            try
            {
                if (MAP[(int)(player_y + 2) * MAP_WIDTH + (int)player_x] == '.')
                    player_a = 0;
                else if (MAP[(int)(player_y - 2) * MAP_WIDTH + (int)player_x] == '.')
                    player_a = 3;
                else if (MAP[(int)player_y * MAP_WIDTH + (int)(player_x + 2)] == '.')
                    player_a = 1;
                else if (MAP[(int)player_y * MAP_WIDTH + (int)(player_x - 2)] == '.')
                    player_a = 4;
            }
            catch
            {
                player_a = 0;
            }
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
            HP = PLAYER_HP;
            money = 15;
            guns.Clear();
            for (int i = 0; i < GUNS.Length; i++)
                GUNS[i].SetDefault();
            current_gun = 0;
            gun_state = 0;
        }

        private void GameOver(int win)
        {
            ost[ost_index]?.Stop();
            raycast.Stop();
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
            in_shop = false;
            aiming = false;
            shop_panel.Visible = false;
            display.Refresh();
            stamina_panel.Width = display.Width;
            can_shoot = false;
            stamina_panel.Visible = false;
            question.Enabled = start_btn.Enabled = true;
            if (win == 1)
            {
                if (difficulty > 0 && difficulty != 4)
                    difficulty--;
                for (int i = 0; i < guns.Count; i++)
                {
                    if (guns[i].MaxAmmoCount == 0)
                        guns[i].MaxAmmoCount = guns[i].CartridgesClip;
                }
                money += 100;
                HP += 50;
                if (HP > PLAYER_HP)
                    HP = PLAYER_HP;
                StartGame();
            }
            else if (win == 0)
            {
                ToDefault();
                game_over_text.Visible = true;
                game_over_text.BringToFront();
                if (MainMenu.sounds)
                    game_over.Play(0.4f);
                difficulty = old_difficulty;
            }
            else
                ToDefault();
        }
    }
}