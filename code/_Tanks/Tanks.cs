using IniReader;
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

namespace minigames._Tanks
{
    public partial class Tanks : Form
    {
        public Tanks()
        {
            InitializeComponent();
        }

        private enum PlayersDirection { STOP, UP, DOWN, LEFT, RIGHT };
        private PlayersDirection player1 = PlayersDirection.STOP, player2 = PlayersDirection.STOP,
            player1_look = PlayersDirection.LEFT, player2_look = PlayersDirection.LEFT;
        private readonly List<Panel> bullets = new List<Panel>();
        private int player1_hp = 3, player2_hp = 3; 
        private Image player1_originalImage, player2_originalImage;
        private Dictionary<PlayersDirection, Bitmap> player1_rotatedImages = new Dictionary<PlayersDirection, Bitmap>();
        private Dictionary<PlayersDirection, Bitmap> player2_rotatedImages = new Dictionary<PlayersDirection, Bitmap>();
        private bool player1_canShoot = false, player2_canShoot = false;
        public static int map_choice = 1;
        public static bool inverted = false;
        public static Keys[][] keys =
        {
            new Keys[] { Keys.W, Keys.Up },
            new Keys[] { Keys.S, Keys.Down },
            new Keys[] { Keys.A, Keys.Left },
            new Keys[] { Keys.D, Keys.Right },
            new Keys[] { Keys.Space, Keys.Enter }
        };
        private int[][] players_pos =
        {
            new int [] { 21, 29, 458, 216 },
            new int [] { 221, 9, 221, 218 },
            new int [] { 448, 141, 56, 64 },
            new int [] { 26, 233, 448, 122 },
        };

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            if (start_btn.Enabled)
            {
                show_settings.Location = new Point(show_settings.Left + 2, show_settings.Top + 2);
                show_settings.Size = new Size(show_settings.Height - 4, show_settings.Width - 4);
            }
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            if (start_btn.Enabled)
            {
                show_settings.Location = new Point(show_settings.Left - 2, show_settings.Top - 2);
                show_settings.Size = new Size(show_settings.Height + 4, show_settings.Width + 4);
            }
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && start_btn.Enabled)
            {
                Settings form = new Settings();
                form.ShowDialog();
            }
        }

        private void Tanks_FormClosing(object sender, FormClosingEventArgs e)
        {
            logic_timer.Enabled = player1_reloading.Enabled = player2_reloading.Enabled = bullets_timer.Enabled = player1_timer.Enabled = player2_timer.Enabled = false;
        }

        private void Tanks_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                    foreach (Control text1 in text.Controls)
                    {
                        if (text1.Name != "debug_text")
                            text1.Font = new Font(text1.Font.FontFamily, text1.Font.Size * MainMenu.scale_size);
                        foreach (Control text2 in text1.Controls)
                            text2.Font = new Font(text2.Font.FontFamily, text2.Font.Size * MainMenu.scale_size);
                    }
                }
                Screen screen = Screen.FromPoint(Cursor.Position);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            if (!MainMenu.Language)
            {
                Text = "Tanks-Game";
                start_btn.Text = "START";
            }
            Activate();
            player1_originalImage = player1_tank.Image;
            player2_originalImage = player2_tank.Image;
            try
            {
                keys[0][0] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "up_pl1", "W"));
                keys[1][0] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "down_pl1", "S"));
                keys[2][0] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "left_pl1", "A"));
                keys[3][0] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "right_pl1", "D"));
                keys[4][0] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "shot_pl1", "Space"));
                keys[0][1] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "up_pl2", "Up"));
                keys[1][1] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "down_pl2", "Down"));
                keys[2][1] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "left_pl2", "Left"));
                keys[3][1] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "right_pl2", "Right"));
                keys[4][1] = (Keys)Enum.Parse(typeof(Keys), INIReader.GetString(MainMenu.iniFolder, "Tanks", "shot_pl2", "Enter"));
            }
            catch
            {
                keys[0][0] = Keys.W;
                keys[1][0] = Keys.S;
                keys[2][0] = Keys.A;
                keys[3][0] = Keys.D;
                keys[4][0] = Keys.Space;
                keys[0][1] = Keys.Up;
                keys[1][1] = Keys.Down;
                keys[2][1] = Keys.Left;
                keys[3][1] = Keys.Right;
                keys[4][1] = Keys.Enter;
            }
            map_choice = INIReader.GetInt(MainMenu.iniFolder, "Tanks", "map", 0);
            inverted = INIReader.GetBool(MainMenu.iniFolder, "Tanks", "inverted", inverted);
            if (map_choice < 0 || map_choice > 4)
                map_choice = 0;
            player1_hp_panel.Width = player1_hp3.Right + 4;
            player2_hp_panel.Width = player2_hp3.Right + 4;
        }

        private void Tanks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == keys[0][0] || e.KeyCode == keys[1][0] || e.KeyCode == keys[2][0] || e.KeyCode == keys[3][0])
                player1 = PlayersDirection.STOP;
            if (e.KeyCode == keys[0][1] || e.KeyCode == keys[1][1] || e.KeyCode == keys[2][1] || e.KeyCode == keys[3][1])
                player2 = PlayersDirection.STOP;
        }

        private void Tanks_KeyDown(object sender, KeyEventArgs e)
        {
            if (!start_btn.Enabled)
            {
                if (e.KeyCode == keys[0][0])
                {
                    player1 = PlayersDirection.UP;
                    if (player1_look != player1)
                    {
                        player1_look = player1;
                        if (!player1_rotatedImages.ContainsKey(player1_look))
                            player1_rotatedImages[player1_look] = RotateImage(player1_originalImage, 90);
                        player1_tank.Image = player1_rotatedImages[player1_look];
                    }
                }
                if (e.KeyCode == keys[1][0])
                {
                    player1 = PlayersDirection.DOWN;
                    if (player1_look != player1)
                    {
                        player1_look = player1;
                        if (!player1_rotatedImages.ContainsKey(player1_look))
                            player1_rotatedImages[player1_look] = RotateImage(player1_originalImage, 270);
                        player1_tank.Image = player1_rotatedImages[player1_look];
                    }
                }
                if (e.KeyCode == keys[2][0])
                {
                    player1 = PlayersDirection.LEFT;
                    if (player1_look != player1)
                    {
                        player1_look = player1;
                        if (!player1_rotatedImages.ContainsKey(player1_look))
                            player1_rotatedImages[player1_look] = RotateImage(player1_originalImage, 0);
                        player1_tank.Image = player1_rotatedImages[player1_look];
                    }
                }
                if (e.KeyCode == keys[3][0])
                {
                    player1 = PlayersDirection.RIGHT;
                    if (player1_look != player1)
                    {
                        player1_look = player1;
                        if (!player1_rotatedImages.ContainsKey(player1_look))
                            player1_rotatedImages[player1_look] = RotateImage(player1_originalImage, 180);
                        player1_tank.Image = player1_rotatedImages[player1_look];
                    }
                }
                if (e.KeyCode == keys[4][0])
                    PlayerShoot(true);
                if (e.KeyCode == keys[0][1])
                {
                    player2 = PlayersDirection.UP;
                    if (player2_look != player2)
                    {
                        player2_look = player2;
                        if (!player2_rotatedImages.ContainsKey(player2_look))
                            player2_rotatedImages[player2_look] = RotateImage(player2_originalImage, 90);
                        player2_tank.Image = player2_rotatedImages[player2_look];
                    }
                }
                if (e.KeyCode == keys[1][1])
                {
                    player2 = PlayersDirection.DOWN;
                    if (player2_look != player2)
                    {
                        player2_look = player2;
                        if (!player2_rotatedImages.ContainsKey(player2_look))
                            player2_rotatedImages[player2_look] = RotateImage(player2_originalImage, 270);
                        player2_tank.Image = player2_rotatedImages[player2_look];
                    }
                }
                if (e.KeyCode == keys[2][1])
                {
                    player2 = PlayersDirection.LEFT;
                    if (player2_look != player2)
                    {
                        player2_look = player2;
                        if (!player2_rotatedImages.ContainsKey(player2_look))
                            player2_rotatedImages[player2_look] = RotateImage(player2_originalImage, 0);
                        player2_tank.Image = player2_rotatedImages[player2_look];
                    }
                }
                if (e.KeyCode == keys[3][1])
                {
                    player2 = PlayersDirection.RIGHT;
                    if (player2_look != player2)
                    {
                        player2_look = player2;
                        if (!player2_rotatedImages.ContainsKey(player2_look))
                            player2_rotatedImages[player2_look] = RotateImage(player2_originalImage, 180);
                        player2_tank.Image = player2_rotatedImages[player2_look];
                    }
                }
                if (e.KeyCode == keys[4][1])
                    PlayerShoot(false);
                if (e.KeyCode == Keys.Escape)
                {
                    player1_hp = player2_hp = 0;
                    GameOver();
                    return;
                }
            }
            else if (e.KeyCode == Keys.Space)
                StartGame();
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Player1_timer_Tick(object sender, EventArgs e)
        {
            int move = (int)MainMenu.scale_size;
            if (player1 == PlayersDirection.UP)
            {
                if (player1_tank.Top >= MainMenu.scale_size)
                {
                    player1_tank.Top -= move;
                    if (player1_tank.Bounds.IntersectsWith(player2_tank.Bounds) && player2_tank.Visible)
                        player1_tank.Top += move;
                }
            }
            else if (player1 == PlayersDirection.DOWN)
            {
                if (player1_tank.Bottom <= game_interface.Height - 6)
                {
                    player1_tank.Top += move;
                    if (player1_tank.Bounds.IntersectsWith(player2_tank.Bounds) && player2_tank.Visible)
                        player1_tank.Top -= move;
                }
            }
            else if (player1 == PlayersDirection.LEFT)
            {
                if (player1_tank.Left >= MainMenu.scale_size)
                {
                    player1_tank.Left -= move;
                    if (player1_tank.Bounds.IntersectsWith(player2_tank.Bounds) && player2_tank.Visible)
                        player1_tank.Left += move;
                }
            }
            else if (player1 == PlayersDirection.RIGHT)
            {
                if (player1_tank.Right <= game_interface.Width - 6)
                {
                    player1_tank.Left += move;
                    if (player1_tank.Bounds.IntersectsWith(player2_tank.Bounds) && player2_tank.Visible)
                        player1_tank.Left -= move;
                }
            }
        }

        private void Player2_timer_Tick(object sender, EventArgs e)
        {
            int move = (int)MainMenu.scale_size;
            if (player2 == PlayersDirection.UP)
            {
                if (player2_tank.Top >= MainMenu.scale_size)
                {
                    player2_tank.Top -= move;
                    if (player2_tank.Bounds.IntersectsWith(player1_tank.Bounds) && player1_tank.Visible)
                        player2_tank.Top += move;
                }
            }
            else if (player2 == PlayersDirection.DOWN)
            {
                if (player2_tank.Bottom <= game_interface.Height - 6)
                {
                    player2_tank.Top += move;
                    if (player2_tank.Bounds.IntersectsWith(player1_tank.Bounds) && player1_tank.Visible)
                        player2_tank.Top -= move;
                }
            }
            else if (player2 == PlayersDirection.LEFT)
            {
                if (player2_tank.Left >= MainMenu.scale_size)
                {
                    player2_tank.Left -= move;
                    if (player2_tank.Bounds.IntersectsWith(player1_tank.Bounds) && player1_tank.Visible)
                        player2_tank.Left += move;
                }
            }
            else if (player2 == PlayersDirection.RIGHT)
            {
                if (player2_tank.Right <= game_interface.Width - 6)
                {
                    player2_tank.Left += move;
                    if (player2_tank.Bounds.IntersectsWith(player1_tank.Bounds) && player1_tank.Visible)
                        player2_tank.Left -= move;
                }
            }
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            StartGame();
        }

        private void StartGame()
        {
            game_over_text.Visible = start_btn.Enabled = false;
            if (map_choice == 0)
            {
                ground_panel_1_water.Location = new Point((int)(214 * MainMenu.scale_size), -6);
                ground_panel_1_water.Size = new Size((int)(46 * MainMenu.scale_size), (int)(200 * MainMenu.scale_size));
                ground_panel_0.Location = new Point((int)(362 * MainMenu.scale_size), (int)(120 * MainMenu.scale_size));
                ground_panel_0.Size = new Size((int)(26 * MainMenu.scale_size), (int)(105 * MainMenu.scale_size));
                ground_panel_2.Location = new Point((int)(132 * MainMenu.scale_size), -6);
                ground_panel_2.Size = new Size((int)(46 * MainMenu.scale_size), (int)(156 * MainMenu.scale_size));
                ground_panel_3.Location = new Point(-6, (int)(124 * MainMenu.scale_size));
                ground_panel_3.Size = new Size((int)(62 * MainMenu.scale_size), (int)(26 * MainMenu.scale_size));
                ground_panel_4.Location = new Point((int)(380 * MainMenu.scale_size), (int)(120 * MainMenu.scale_size));
                ground_panel_4.Size = new Size((int)(78 * MainMenu.scale_size), (int)(26 * MainMenu.scale_size));
                grass_panel_0.Location = new Point((int)(298 * MainMenu.scale_size), (int)(60 * MainMenu.scale_size));
                grass_panel_0.Size = new Size((int)(212 * MainMenu.scale_size), (int)(60 * MainMenu.scale_size));
                grass_panel_1.Location = new Point((int)(298 * MainMenu.scale_size), (int)(120 * MainMenu.scale_size));
                grass_panel_1.Size = new Size((int)(64 * MainMenu.scale_size), (int)(151 * MainMenu.scale_size));
                grass_panel_2.Location = new Point((int)(178 * MainMenu.scale_size), (int)(216 * MainMenu.scale_size));
                grass_panel_2.Size = new Size((int)(120 * MainMenu.scale_size), (int)(55 * MainMenu.scale_size));
                grass_panel_3.Location = new Point((int)(132 * MainMenu.scale_size), (int)(150 * MainMenu.scale_size));
                grass_panel_3.Size = new Size((int)(46 * MainMenu.scale_size), (int)(121 * MainMenu.scale_size));
                if (!inverted)
                {
                    player1_tank.Location = new Point((int)(players_pos[0][0] * MainMenu.scale_size), (int)(players_pos[0][1] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[0][2] * MainMenu.scale_size), (int)(players_pos[0][3] * MainMenu.scale_size));
                }
                else
                {
                    player1_tank.Location = new Point((int)(players_pos[0][2] * MainMenu.scale_size), (int)(players_pos[0][3] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[0][0] * MainMenu.scale_size), (int)(players_pos[0][1] * MainMenu.scale_size));
                }
            }
            else if (map_choice == 1)
            {
                ground_panel_1_water.Location = new Point(-8, (int)(116 * MainMenu.scale_size));
                ground_panel_1_water.Size = new Size((int)(528 * MainMenu.scale_size), (int)(31 * MainMenu.scale_size));
                ground_panel_0.Location = new Point((int)(360 * MainMenu.scale_size), (int)(144 * MainMenu.scale_size));
                ground_panel_0.Size = new Size((int)(46 * MainMenu.scale_size), (int)(127 * MainMenu.scale_size));
                ground_panel_2.Location = new Point((int)(79 * MainMenu.scale_size), -6);
                ground_panel_2.Size = new Size((int)(46 * MainMenu.scale_size), (int)(122 * MainMenu.scale_size));
                ground_panel_3.Location = new Point((int)(125 * MainMenu.scale_size), (int)(189 * MainMenu.scale_size));
                ground_panel_3.Size = new Size((int)(240 * MainMenu.scale_size), (int)(26 * MainMenu.scale_size));
                ground_panel_4.Location = new Point((int)(120 * MainMenu.scale_size), (int)(47 * MainMenu.scale_size));
                ground_panel_4.Size = new Size((int)(240 * MainMenu.scale_size), (int)(26 * MainMenu.scale_size));
                grass_panel_0.Location = new Point((int)(125 * MainMenu.scale_size), (int)(150 * MainMenu.scale_size));
                grass_panel_0.Size = new Size((int)(235 * MainMenu.scale_size), (int)(36 * MainMenu.scale_size));
                grass_panel_1.Location = new Point((int)(79 * MainMenu.scale_size), (int)(150 * MainMenu.scale_size));
                grass_panel_1.Size = new Size((int)(46 * MainMenu.scale_size), (int)(121 * MainMenu.scale_size));
                grass_panel_2.Location = new Point((int)(125 * MainMenu.scale_size), (int)(76 * MainMenu.scale_size));
                grass_panel_2.Size = new Size((int)(235 * MainMenu.scale_size), (int)(36 * MainMenu.scale_size));
                grass_panel_3.Location = new Point((int)(360 * MainMenu.scale_size), 0);
                grass_panel_3.Size = new Size((int)(46 * MainMenu.scale_size), (int)(112 * MainMenu.scale_size));
                if (!inverted)
                {
                    player1_tank.Location = new Point((int)(players_pos[1][0] * MainMenu.scale_size), (int)(players_pos[1][1] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[1][2] * MainMenu.scale_size), (int)(players_pos[1][3] * MainMenu.scale_size));
                }
                else
                {
                    player1_tank.Location = new Point((int)(players_pos[1][2] * MainMenu.scale_size), (int)(players_pos[1][3] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[1][0] * MainMenu.scale_size), (int)(players_pos[1][1] * MainMenu.scale_size));
                }
            }
            else if (map_choice == 2)
            {
                ground_panel_1_water.Location = new Point(0, 0);
                ground_panel_1_water.Size = new Size((int)(512 * MainMenu.scale_size), (int)(50 * MainMenu.scale_size));
                ground_panel_0.Location = new Point((int)(402 * MainMenu.scale_size), (int)(99 * MainMenu.scale_size));
                ground_panel_0.Size = new Size((int)(110 * MainMenu.scale_size), (int)(20 * MainMenu.scale_size));
                ground_panel_2.Location = new Point((int)(288 * MainMenu.scale_size), (int)(173 * MainMenu.scale_size));
                ground_panel_2.Size = new Size((int)(22 * MainMenu.scale_size), (int)(98 * MainMenu.scale_size));
                ground_panel_3.Location = new Point((int)(107 * MainMenu.scale_size), (int)(50 * MainMenu.scale_size));
                ground_panel_3.Size = new Size((int)(24 * MainMenu.scale_size), (int)(75 * MainMenu.scale_size));
                ground_panel_4.Location = new Point((int)(380 * MainMenu.scale_size), (int)(99 * MainMenu.scale_size));
                ground_panel_4.Size = new Size((int)(22 * MainMenu.scale_size), (int)(102 * MainMenu.scale_size));
                grass_panel_0.Location = new Point(0, (int)(79 * MainMenu.scale_size));
                grass_panel_0.Size = new Size((int)(41 * MainMenu.scale_size), (int)(129 * MainMenu.scale_size));
                grass_panel_1.Location = new Point(0, (int)(208 * MainMenu.scale_size));
                grass_panel_1.Size = new Size((int)(288 * MainMenu.scale_size), (int)(63 * MainMenu.scale_size));
                grass_panel_2.Location = new Point((int)(310 * MainMenu.scale_size), (int)(229 * MainMenu.scale_size));
                grass_panel_2.Size = new Size((int)(202 * MainMenu.scale_size), (int)(42 * MainMenu.scale_size));
                grass_panel_3.Location = new Point((int)(131 * MainMenu.scale_size), (int)(55 * MainMenu.scale_size));
                grass_panel_3.Size = new Size((int)(381 * MainMenu.scale_size), (int)(44 * MainMenu.scale_size));
                if (!inverted)
                {
                    player1_tank.Location = new Point((int)(players_pos[2][0] * MainMenu.scale_size), (int)(players_pos[2][1] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[2][2] * MainMenu.scale_size), (int)(players_pos[2][3] * MainMenu.scale_size));
                }
                else
                {
                    player1_tank.Location = new Point((int)(players_pos[2][2] * MainMenu.scale_size), (int)(players_pos[2][3] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[2][0] * MainMenu.scale_size), (int)(players_pos[2][1] * MainMenu.scale_size));
                }
            }
            else if (map_choice == 3)
            {
                ground_panel_1_water.Location = new Point(0, 0);
                ground_panel_1_water.Size = new Size((int)(512 * MainMenu.scale_size), (int)(50 * MainMenu.scale_size));
                ground_panel_0.Location = new Point((int)(376 * MainMenu.scale_size), (int)(50 * MainMenu.scale_size));
                ground_panel_0.Size = new Size((int)(29 * MainMenu.scale_size), (int)(69 * MainMenu.scale_size));
                ground_panel_2.Location = new Point((int)(376 * MainMenu.scale_size), (int)(162 * MainMenu.scale_size));
                ground_panel_2.Size = new Size((int)(29 * MainMenu.scale_size), (int)(66 * MainMenu.scale_size));
                ground_panel_3.Location = new Point((int)(78 * MainMenu.scale_size), (int)(228 * MainMenu.scale_size));
                ground_panel_3.Size = new Size((int)(25 * MainMenu.scale_size), (int)(43 * MainMenu.scale_size));
                ground_panel_4.Location = new Point((int)(229 * MainMenu.scale_size), (int)(119 * MainMenu.scale_size));
                ground_panel_4.Size = new Size((int)(25 * MainMenu.scale_size), (int)(43 * MainMenu.scale_size));
                grass_panel_0.Location = new Point((int)(269 * MainMenu.scale_size), (int)(119 * MainMenu.scale_size));
                grass_panel_0.Size = new Size((int)(136 * MainMenu.scale_size), (int)(43 * MainMenu.scale_size));
                grass_panel_1.Location = new Point(0, (int)(50 * MainMenu.scale_size));
                grass_panel_1.Size = new Size((int)(376 * MainMenu.scale_size), (int)(69 * MainMenu.scale_size));
                grass_panel_2.Location = new Point(0, (int)(162 * MainMenu.scale_size));
                grass_panel_2.Size = new Size((int)(376 * MainMenu.scale_size), (int)(66 * MainMenu.scale_size));
                grass_panel_3.Location = new Point((int)(137 * MainMenu.scale_size), (int)(228 * MainMenu.scale_size));
                grass_panel_3.Size = new Size((int)(268 * MainMenu.scale_size), (int)(43 * MainMenu.scale_size));
                if (!inverted)
                {
                    player1_tank.Location = new Point((int)(players_pos[3][0] * MainMenu.scale_size), (int)(players_pos[3][1] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[3][2] * MainMenu.scale_size), (int)(players_pos[3][3] * MainMenu.scale_size));
                }
                else
                {
                    player1_tank.Location = new Point((int)(players_pos[3][2] * MainMenu.scale_size), (int)(players_pos[3][3] * MainMenu.scale_size));
                    player2_tank.Location = new Point((int)(players_pos[3][0] * MainMenu.scale_size), (int)(players_pos[3][1] * MainMenu.scale_size));
                }
            }
            ground_panel_0.Visible = ground_panel_1_water.Visible =
                ground_panel_2.Visible = ground_panel_3.Visible =
                ground_panel_4.Visible = grass_panel_0.Visible =
                grass_panel_1.Visible = grass_panel_2.Visible =
                grass_panel_3.Visible = true;
            player1_tank.Visible = player2_tank.Visible = true;
            player1 = player2 = PlayersDirection.STOP;
            player1_look = player2_look = PlayersDirection.LEFT;
            player1_rotatedImages[player1_look] = RotateImage(player1_originalImage, 0);
            player2_rotatedImages[player2_look] = RotateImage(player2_originalImage, 0);
            player1_tank.Image = player1_rotatedImages[player1_look];
            player2_tank.Image = player2_rotatedImages[player2_look];
            player1_hp = player2_hp = 3;
            reloading1.Width = reloading2.Width = 0;
            player1_canShoot = player2_canShoot = false;
            logic_timer.Enabled = player1_reloading.Enabled = player2_reloading.Enabled = bullets_timer.Enabled = player1_timer.Enabled = player2_timer.Enabled = true;
        }

        private void Logic_timer_Tick(object sender, EventArgs e)
        {
            if (player1_tank.Visible)
            {
                if (player1_hp == 1)
                {
                    player1_hp1.BackColor = Color.Tomato;
                    player1_hp2.BackColor = player1_hp3.BackColor = Color.Gainsboro;
                }
                else if (player1_hp == 2)
                {
                    player1_hp1.BackColor = player1_hp2.BackColor = Color.Tomato;
                    player1_hp3.BackColor = Color.Gainsboro;
                }
                else
                    player1_hp1.BackColor = player1_hp2.BackColor = player1_hp3.BackColor = Color.Tomato;
            }
            if (player2_tank.Visible)
            {
                if (player2_hp == 1)
                {
                    player2_hp1.BackColor = Color.Tomato;
                    player2_hp2.BackColor = player2_hp3.BackColor = Color.Gainsboro;
                }
                else if (player2_hp == 2)
                {
                    player2_hp1.BackColor = player2_hp2.BackColor = Color.Tomato;
                    player2_hp3.BackColor = Color.Gainsboro;
                }
                else
                    player2_hp1.BackColor = player2_hp2.BackColor = player2_hp3.BackColor = Color.Tomato;
            }
            foreach (Control obj in game_interface.Controls)
            {
                if (obj.Name.EndsWith("_tank"))
                {
                    foreach (Control panel in game_interface.Controls)
                    {
                        if (panel.Name.StartsWith("ground_panel"))
                        {
                            if (obj.Bounds.IntersectsWith(panel.Bounds))
                            {
                                PlayersDirection direction;
                                if (obj == player1_tank)
                                    direction = player1_look;
                                else
                                    direction = player2_look;
                                if (obj.Bottom >= panel.Top && obj.Top < panel.Top && direction == PlayersDirection.DOWN)
                                    obj.Top = panel.Top - obj.Height;
                                else if (obj.Top <= panel.Bottom && obj.Bottom > panel.Bottom && direction == PlayersDirection.UP)
                                    obj.Top = panel.Bottom;
                                else if (obj.Left <= panel.Right && obj.Right > panel.Right && direction == PlayersDirection.LEFT)
                                    obj.Left = panel.Right;
                                else if (obj.Right >= panel.Left && obj.Left < panel.Left && direction == PlayersDirection.RIGHT)
                                    obj.Left = panel.Left - obj.Width;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Bullets_timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                Panel bullet = bullets[i];
                bullet.Left += bullet.ForeColor == Color.Red ? (int)(-15 * MainMenu.scale_size) : bullet.ForeColor == Color.Blue ? (int)(15 * MainMenu.scale_size) : 0;
                bullet.Top += bullet.ForeColor == Color.White ? (int)(-15 * MainMenu.scale_size) : bullet.ForeColor == Color.Black ? (int)(15 * MainMenu.scale_size) : 0;
                bullet.BringToFront();
                foreach (Control panel in game_interface.Controls)
                {
                    if (panel is Panel && panel.Name.StartsWith("ground_panel") && !panel.Name.EndsWith("_water"))
                    {
                        if (bullet.Bounds.IntersectsWith(panel.Bounds))
                        {
                            game_interface.Controls.Remove(bullet);
                            bullets.RemoveAt(i);
                            i--;
                            break;
                        }
                    }
                }
                if (bullet.Right <= 0 || bullet.Right >= game_interface.Width || bullet.Top >= game_interface.Height || bullet.Bottom <= 0)
                {
                    game_interface.Controls.Remove(bullet);
                    bullets.RemoveAt(i);
                    i--;
                }
                if (bullet.Bounds.IntersectsWith(player2_tank.Bounds) && player2_tank.Visible && bullet.AutoScroll)
                {
                    player2_hp--;
                    if (player2_hp <= 0)
                        player2_reloading.Enabled = player2_tank.Visible = player2_canShoot = false;
                    game_interface.Controls.Remove(bullet);
                    bullets.RemoveAt(i);
                    i--;
                }
                if (bullet.Bounds.IntersectsWith(player1_tank.Bounds) && player1_tank.Visible && !bullet.AutoScroll)
                {
                    player1_hp--;
                    if (player1_hp <= 0)
                        player1_reloading.Enabled = player1_tank.Visible = player1_canShoot = false;
                    game_interface.Controls.Remove(bullet);
                    bullets.RemoveAt(i);
                    i--;
                }
                if (player1_hp == 0 || player2_hp == 0)
                    GameOver();
            }
        }

        private void GameOver()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                game_interface.Controls.Remove(bullets[i]);
                bullets.RemoveAt(i);
                i--;
            }
            ground_panel_0.Visible = ground_panel_1_water.Visible =
            ground_panel_2.Visible = ground_panel_3.Visible =
            ground_panel_4.Visible = grass_panel_0.Visible =
            grass_panel_1.Visible = grass_panel_2.Visible =
            grass_panel_3.Visible = player1_tank.Visible = player2_tank.Visible = false;
            logic_timer.Enabled = player1_reloading.Enabled = player2_reloading.Enabled = bullets_timer.Enabled = player1_timer.Enabled = player2_timer.Enabled = false;
            reloading1.Width = reloading2.Width = 0;
            start_btn.Enabled = true;
            if (player1_hp == 0 && player2_hp == 0)
            {
                game_over_text.Text = "DRAW";
                player1_hp1.BackColor = player1_hp2.BackColor = player1_hp3.BackColor = Color.Gainsboro;
                player2_hp1.BackColor = player2_hp2.BackColor = player2_hp3.BackColor = Color.Gainsboro;
            }
            else if (player1_hp == 0)
            {
                game_over_text.Text = "PLAYER 2 WIN";
                player1_hp1.BackColor = player1_hp2.BackColor = player1_hp3.BackColor = Color.Gainsboro;
            }
            else if (player2_hp == 0)
            {
                game_over_text.Text = "PLAYER 1 WIN";
                player2_hp1.BackColor = player2_hp2.BackColor = player2_hp3.BackColor = Color.Gainsboro;
            }
            game_over_text.Left = (game_interface.Width - game_over_text.Width) / 2;
            game_over_text.Top = (game_interface.Height - game_over_text.Height) / 2;
            game_over_text.Visible = true;
        }

        private void Player1_reloading_Tick(object sender, EventArgs e)
        {
            if (player1_canShoot)
                player1_reloading.Stop();
            else
            {
                reloading1.Width += (int)(1 * MainMenu.scale_size);
                if(reloading1.Width >= reloading1_background.Width)
                {
                    player1_canShoot = true;
                    player1_reloading.Stop();
                }
            }
        }

        private void Player2_reloading_Tick(object sender, EventArgs e)
        {
            if (player2_canShoot)
                player2_reloading.Stop();
            else
            {
                reloading2.Width += (int)(1 * MainMenu.scale_size);
                if (reloading2.Width >= reloading2_background.Width)
                {
                    player2_canShoot = true;
                    player2_reloading.Stop();
                }
            }
        }

        private void PlayerShoot(bool isPlayer1)
        {
            int bulletTop, bulletLeft, index, height = 3, width = 12;
            Color[] bulletColor = { Color.White, Color.Black, Color.Red, Color.Blue };
            if (isPlayer1)
            {
                if (player1_canShoot)
                {
                    bulletLeft = player1_tank.Left + (player1_tank.Width / 2);
                    bulletTop = player1_tank.Top + (player1_tank.Height / 2);
                    if (player1_look == PlayersDirection.UP)
                    {
                        height = 12;
                        width = 3;
                        index = 0;
                    }
                    else if (player1_look == PlayersDirection.DOWN)
                    {
                        height = 12;
                        width = 3;
                        index = 1;
                    }
                    else if (player1_look == PlayersDirection.LEFT)
                        index = 2;
                    else
                        index = 3;
                    player1_canShoot = false;
                    reloading1.Width = 0;
                    reloading1_background.Visible = true;
                    player1_reloading.Start();
                }
                else
                    return;
            }
            else
            {
                if (player2_canShoot)
                {
                    bulletLeft = player2_tank.Left + (player2_tank.Width / 2);
                    bulletTop = player2_tank.Top + (player2_tank.Height / 2);
                    if (player2_look == PlayersDirection.UP)
                    {
                        height = 12;
                        width = 3;
                        index = 0;
                    }
                    else if (player2_look == PlayersDirection.DOWN)
                    {
                        height = 12;
                        width = 3;
                        index = 1;
                    }
                    else if (player2_look == PlayersDirection.LEFT)
                        index = 2;
                    else
                        index = 3;
                    player2_canShoot = false;
                    reloading2.Width = 0;
                    reloading2_background.Visible = true;
                    player2_reloading.Start();
                }
                else
                    return;
            }
            bullets.Add(new Panel
            {
                Height = (int)(height * MainMenu.scale_size),
                Width = (int)(width * MainMenu.scale_size),
                Top = bulletTop,
                Left = bulletLeft,
                BackColor = Color.Orange,
                ForeColor = bulletColor[index],
                AutoScroll = isPlayer1
            });
            game_interface.Controls.Add(bullets[bullets.Count - 1]);
        }

        private Bitmap RotateImage(Image img, float rotationAngle)
        {
            int newWidth, newHeight;
            if (rotationAngle == 90 || rotationAngle == 270)
            {
                newWidth = img.Height;
                newHeight = img.Width;
            }
            else
            {
                newWidth = img.Width;
                newHeight = img.Height;
            }
            Bitmap bmp = new Bitmap(newWidth, newHeight);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
                gfx.RotateTransform(rotationAngle);
                gfx.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gfx.DrawImage(img, new Point(0, 0));
            }
            return bmp;
        }
    }
}