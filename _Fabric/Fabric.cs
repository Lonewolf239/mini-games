using IniReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigames._Fabric
{
    public partial class Fabric : Form
    {
        public Fabric()
        {
            InitializeComponent();
        }

        private Random rand = new Random();
        private enum PlayerDirection { Stop, Left, Right }
        private PlayerDirection playerDirection;
        private bool[] enemys_left = { false, true, false, true, false };
        private bool isJumping = false, hasJumped = false, isFacingLeft = false, isKeyPressed = false, canJump = false, in_rebind = false;
        private int JUMP_HEIGHT = 176;
        private float hp = 100, boss_hp = 100;
        private int bulletCount = 0, bulletRemein = 4, enemyCount = 5, fallSpeed = 3, jumpHeight = 0, rebinding = 0;
        private string restore_name = null, cheat = null;
        private Keys[] keys = { Keys.W, Keys.A, Keys.D, Keys.Space, Keys.R, Keys.Pause };
        private List<Panel> bullets;
        private Button btn;
        private int[] objFallSpeed;

        private void Fabric_Shown(object sender, EventArgs e)
        {
            Activate();
            player_timer.Start();
            bullets = new List<Panel>();
        }

        private void Fabric_FormClosing(object sender, FormClosingEventArgs e)
        {
            player_timer.Stop();
        }

        private void Fabric_KeyDown(object sender, KeyEventArgs e)
        {
            if (!in_rebind)
            {
                if (player_timer.Enabled)
                {
                    cheat += e.KeyCode.ToString();
                    if (e.KeyCode == keys[0])
                    {
                        if (player.Visible)
                        {
                            if (!hasJumped && canJump)
                                isKeyPressed = isJumping = true;
                        }
                    }
                    if (e.KeyCode == keys[1])
                    {
                        if (player.Visible)
                        {
                            if (!isFacingLeft)
                            {
                                player.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                                player.Invalidate();
                            }
                            isKeyPressed = isFacingLeft = true;
                            playerDirection = PlayerDirection.Left;
                        }
                    }
                    if (e.KeyCode == keys[2])
                    {
                        if (player.Visible)
                        {
                            if (isFacingLeft)
                            {
                                player.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                                player.Invalidate();
                            }
                            isKeyPressed = true;
                            isFacingLeft = false;
                            playerDirection = PlayerDirection.Right;
                        }
                    }
                    if (e.KeyCode == keys[3])
                    {
                        if (player.Visible)
                        {
                            if (bulletCount < 10 && bulletRemein > 0)
                            {
                                Color bulletColor = isFacingLeft ? Color.Black : Color.White;
                                int bulletLeft = isFacingLeft ? player.Left - 12 : player.Left + player.Width + 12;
                                bullets.Add(new Panel
                                {
                                    Height = (int)(3 * MainMenu.scale_size),
                                    Width = (int)(12 * MainMenu.scale_size),
                                    Top = player.Top + (player.Height + (int)(12 * MainMenu.scale_size) / (int)(3 * MainMenu.scale_size)) / 2,
                                    Left = bulletLeft,
                                    BackColor = Color.Orange,
                                    ForeColor = bulletColor
                                });
                                Controls.Add(bullets[bulletCount]);
                                bulletCount++;
                                bulletRemein--;
                            }
                        }
                    }
                    if (e.KeyCode == Keys.Delete)
                        cheat = null;
                    if (cheat == "UpDownUpDownLeftRightADSpace")
                    {
                        bulletRemein = 999;
                        hp = 999;
                    }
                }
                if (e.KeyCode == keys[4])
                {
                    Close();
                    Fabric form = new Fabric();
                    form.Show();
                }
                if (e.KeyCode == keys[5])
                {
                    player_timer.Enabled = !player_timer.Enabled;
                    debug_text.Text = $"DEBUG:\nBullet Count: {bulletCount}\nBullet Remein: {bulletRemein}\nEnemy Count: {enemyCount}\nPosition:\nX: {player.Left}\nY: {Height - player.Top}\nHeight: {jumpHeight}\nPAUSE";
                }
                if (e.KeyCode == Keys.Escape)
                    Close();
            }
            else
            {
                if (e.KeyCode != Keys.Escape)
                {
                    btn.Text = e.KeyCode.ToString();
                    keys[rebinding] = e.KeyCode;
                    in_rebind = rebind_task.Visible = false;
                    INIReader.SetKey(MainMenu.iniFolder, "FABRICA", "jump_key", keys[0]);
                    INIReader.SetKey(MainMenu.iniFolder, "FABRICA", "left_key", keys[1]);
                    INIReader.SetKey(MainMenu.iniFolder, "FABRICA", "right_key", keys[2]);
                    INIReader.SetKey(MainMenu.iniFolder, "FABRICA", "shoot_key", keys[3]);
                    INIReader.SetKey(MainMenu.iniFolder, "FABRICA", "restart_key", keys[4]);
                    INIReader.SetKey(MainMenu.iniFolder, "FABRICA", "pause_key", keys[5]);
                }
                else
                {
                    btn.Text = restore_name;
                    in_rebind = rebind_task.Visible = false;
                }
            }
        }

        private void Fabric_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyPressed = canJump = isJumping = false;
        }

        private void Player_timer_Tick(object sender, EventArgs e)
        {
            bool[] enemys_hit_wall = { false, false, false, false, false };
            int obj_index = 0;
            foreach (Control obj in Controls)
            {
                if (!(obj is Panel) && !(obj is Label) && obj != player && !obj.Name.StartsWith("teleport") && !obj.Name.EndsWith("icon"))
                {
                    bool isOnGround = false;
                    foreach (Control panel in Controls)
                    {
                        if (panel is Panel && panel.Name.StartsWith("ground_panel"))
                        {
                            if (obj.Bottom >= panel.Top && obj.Bottom < panel.Bottom && obj.Right > panel.Left && obj.Left < panel.Right && !panel.Name.EndsWith("_"))
                            {
                                isOnGround = true;
                                obj.Top = panel.Top - obj.Height;
                                break;
                            }
                        }
                    }
                    if (!isOnGround)
                    {
                        obj.Top += (int)(objFallSpeed[obj_index] * MainMenu.scale_size);
                        objFallSpeed[obj_index]++;
                    }
                    else
                        objFallSpeed[obj_index] = (int)(3 * MainMenu.scale_size);
                    foreach (Control panel in Controls)
                    {
                        if (panel is Panel && panel.Name.StartsWith("ground_panel"))
                        {
                            if (obj.Bottom >= panel.Top && obj.Bottom < panel.Bottom && obj.Right > panel.Left && obj.Left < panel.Right && !panel.Name.EndsWith("_"))
                            {
                                obj.Top = panel.Top - obj.Height;
                                break;
                            }
                        }
                    }
                    obj_index++;
                }
            }
            foreach (Control obj in Controls)
            {
                if (!(obj is Panel) && !(obj is Label) && obj != player && obj.Name.StartsWith("enemy") && !obj.Name.EndsWith("icon"))
                {
                    foreach (Control panel in Controls)
                    {
                        if (panel is Panel && panel.Name.StartsWith("ground_panel"))
                        {
                            if (obj.Right > panel.Left && obj.Left < panel.Right && obj.Bottom > panel.Top && obj.Top < panel.Bottom)
                            {
                                string[] parts;
                                parts = obj.Name.Split('_');
                                enemys_hit_wall[Convert.ToInt32(parts[1]) - 1] = true;
                                break;
                            }
                        }
                    }
                }
            }
            bool playerOnGround = false;
            bool playerHitWall = false;
            int playerSpeed = (int)(3 * MainMenu.scale_size); ;
            foreach (Control obj in Controls)
            {
                if (!(obj is Label) && !obj.Name.StartsWith("teleport") && !obj.Name.StartsWith("ground_panel") && !obj.Name.EndsWith("icon") && !obj.Name.EndsWith("interface"))
                {
                    foreach (Control teleport in Controls)
                    {
                        if (teleport.Name.StartsWith("teleport"))
                        {
                            if (obj.Bounds.IntersectsWith(teleport.Bounds))
                            {
                                Control[] teleports = { teleport_0, teleport_1, teleport_2, teleport_3 };
                                string[] parts = teleport.Name.Split('_');
                                int index;
                                if (Convert.ToInt32(parts[1]) == 0)
                                    index = 1;
                                else if (Convert.ToInt32(parts[1]) == 1)
                                    index = 0;
                                else if (Convert.ToInt32(parts[1]) == 2)
                                    index = 3;
                                else
                                    index = 2;
                                Control current_teleport = teleports[index];
                                obj.Location = current_teleport.Location;
                                obj.Left = index == 1 || index == 3 ? obj.Left + current_teleport.Width + 6 : obj.Left - obj.Width - 6;
                                obj.Top += !obj.Name.Contains("boss") ? current_teleport.Height / 2 : 0;
                            }
                        }
                    }
                }
            }
            foreach (Control panel in Controls)
            {
                if (panel is Panel && panel.Name.StartsWith("ground_panel"))
                {
                    if (player.Bottom >= panel.Top && player.Bottom < panel.Bottom && player.Right - (player.Width / 6) > panel.Left && player.Left + (player.Width / 6) < panel.Right && !panel.Name.EndsWith("_"))
                    {
                        playerOnGround = true;
                        player.Top = panel.Top - player.Height;
                    }
                    else if (player.Right > panel.Left && player.Left < panel.Right && player.Bottom > panel.Top && player.Top < panel.Bottom)
                    {
                        playerHitWall = true;
                        if (playerDirection == PlayerDirection.Stop && !isJumping)
                            player.Top = panel.Top - player.Height;
                        if (player.Right > panel.Left && player.Left < panel.Left)
                            player.Left = panel.Left - player.Width;
                        else if (player.Left < panel.Right && player.Right > panel.Right)
                            player.Left = panel.Right;
                        else if (player.Top < panel.Bottom && player.Bottom > panel.Top)
                        {
                            player.Top = panel.Bottom;
                            isJumping = canJump = false;
                        }
                    }
                }
            }
            if (!playerOnGround && !playerHitWall)
            {
                if (!isJumping)
                {
                    player.Top += (int)(fallSpeed * MainMenu.scale_size);
                    fallSpeed++;
                }
                else
                    jumpHeight += (int)(7 * MainMenu.scale_size);

            }
            else if (playerHitWall)
                playerSpeed = 0;
            else
            {
                hasJumped = false;
                canJump = true;
                playerSpeed = (int)(3 * MainMenu.scale_size);
                fallSpeed = (int)(3 * MainMenu.scale_size);
                jumpHeight = 0;
            }
            PictureBox[] bullets_box = { bullets_box_0, bullets_box_1 };
            foreach (PictureBox box in bullets_box)
            {
                if (player.Bounds.IntersectsWith(box.Bounds) && box.Visible && player.Visible)
                {
                    box.Visible = false;
                    bulletRemein += 4;
                }
            }
            if (isJumping)
            {
                if (jumpHeight <= JUMP_HEIGHT)
                    player.Top -= (int)(5 * MainMenu.scale_size);
                else
                {
                    isJumping = false;
                    hasJumped = true;
                }
            }
            if (!isKeyPressed)
            {
                playerSpeed = 0;
                playerDirection = PlayerDirection.Stop;
            }
            switch (playerDirection)
            {
                case PlayerDirection.Left:
                    player.Left -= playerSpeed;
                    break;
                case PlayerDirection.Right:
                    player.Left += playerSpeed;
                    break;
            }
            PictureBox[] enemys = { enemy_1, enemy_2, enemy_3, enemy_4, enemyboss_5 };
            for (int i = 0; i < bulletCount; i++)
            {
                Panel bullet = bullets[i];
                bullet.Left += bullet.ForeColor == Color.Black ? (int)(-15 * MainMenu.scale_size) : (int)(15 * MainMenu.scale_size);
                foreach (Control panel in Controls)
                {
                    if (panel is Panel && panel.Name.StartsWith("ground_panel"))
                    {
                        if (bullet.Left + bullet.Width <= 0 || bullet.Left + bullet.Width >= Width || bullet.Bounds.IntersectsWith(panel.Bounds))
                        {
                            Controls.Remove(bullet);
                            bullets.RemoveAt(i);
                            bulletCount--;
                            i--;
                            break;
                        }
                    }
                }
                for (int j = 0; j < enemys.Length; j++)
                {
                    if (bullet.Bounds.IntersectsWith(enemys[j].Bounds) && enemys[j].Visible)
                    {
                        if (enemys[j].Name != "enemyboss_5")
                        {
                            enemys[j].Visible = false;
                            enemyCount--;
                        }
                        else
                        {
                            boss_hp -= 18.562857f;
                            if (boss_hp <= 0)
                            {
                                enemys[j].Visible = false;
                                enemyCount--;
                            }
                        }
                        Controls.Remove(bullet);
                        bullets.RemoveAt(i);
                        bulletCount--;
                        i--;
                        break;
                    }
                }
            }
            for (int j = 0; j < enemys.Length; j++)
            {
                if (enemys[j].Visible)
                {
                    if (player.Bounds.IntersectsWith(enemys[j].Bounds) && player.Visible && hp < 999)
                        hp -= 1.75f;
                    if (hp <= 0)
                    {
                        hp = 0;
                        player.Visible = false;
                    }
                    if (enemys_hit_wall[j])
                    {
                        enemys[j].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        enemys[j].Invalidate();
                        enemys_left[j] = !enemys_left[j];
                        if (enemys_left[j])
                            enemys[j].Left -= (int)(3 * MainMenu.scale_size);
                        else
                            enemys[j].Left += (int)(3 * MainMenu.scale_size);
                    }
                    else
                    {
                        if (enemys[j].Name != "enemyboss_5")
                        {
                            if (enemys_left[j])
                                enemys[j].Left -= (int)(3 * MainMenu.scale_size);
                            else
                                enemys[j].Left += (int)(3 * MainMenu.scale_size);
                        }
                        else
                        {
                            if (enemys_left[j])
                                enemys[j].Left -= (int)(2 * MainMenu.scale_size);
                            else
                                enemys[j].Left += (int)(2 * MainMenu.scale_size);
                        }
                    }
                }
            }
            Control[] medkits = { medkit_0 };
            for (int i = 0; i < medkits.Length; i++)
            {
                if (player.Bounds.IntersectsWith(medkits[i].Bounds) && player.Visible && medkits[i].Visible)
                {
                    medkits[i].Visible = false;
                    hp = 100;
                }
            }
            hp_interface.Width = (int)((double)hp / 100 * hp_panel_interface.Width);
            boss_hp_interface.Width = (int)((double)boss_hp / 100 * boss_hp_panel_interface.Width);
            if (bulletRemein == 0 && enemyCount != 0 && !bullets_box_0.Visible && !bullets_box_1.Visible)
            {
                bullets_box_0.Location = new Point(rand.Next(ground_panel_4_.Left, Width - (ground_panel_5_.Left + bullets_box_0.Width)) + rand.Next(ground_panel_4_.Left, Width - (ground_panel_5_.Left + bullets_box_0.Width)), -bullets_box_0.Height);
                bullets_box_0.Visible = true;
            }
            string mgs = null, boss = null;
            if (!player.Visible)
                mgs = "YOU DEAD";
            else if (enemyCount == 1)
                enemyboss_5.Visible = true;
            else if (!player_timer.Enabled)
                mgs = "PAUSE";
            else if (boss_hp <= 0)
                mgs = "YOU WIN";
            if (enemyboss_5.Visible)
                label1.Visible = boss_hp_panel_interface.Visible = true;
            debug_text.Text = $"DEBUG:\nBullet Count: {bulletCount}\nBullet Remein: {bulletRemein}\nEnemy Count: {enemyCount}\nPosition:\nX: {player.Left}\nY: {Height-player.Top}\nHeight: {jumpHeight}\n{boss}{mgs}";
            Invalidate();
        }

        private void Fabric_Load(object sender, EventArgs e)
        {
            Button[] btns = { jump_btn, left_btn, right_btn, shoot_btn, restart_btn, pause_btn };
            try
            {
                btns[0].Text = INIReader.GetString(MainMenu.iniFolder, "FABRICA", "jump_key", Keys.W.ToString());
                keys[0] = (Keys)Enum.Parse(typeof(Keys), btns[0].Text);
                btns[1].Text = INIReader.GetString(MainMenu.iniFolder, "FABRICA", "left_key", Keys.A.ToString());
                keys[1] = (Keys)Enum.Parse(typeof(Keys), btns[1].Text);
                btns[2].Text = INIReader.GetString(MainMenu.iniFolder, "FABRICA", "right_key", Keys.D.ToString());
                keys[2] = (Keys)Enum.Parse(typeof(Keys), btns[2].Text);
                btns[3].Text = INIReader.GetString(MainMenu.iniFolder, "FABRICA", "shoot_key", Keys.Space.ToString());
                keys[3] = (Keys)Enum.Parse(typeof(Keys), btns[3].Text);
                btns[4].Text = INIReader.GetString(MainMenu.iniFolder, "FABRICA", "restart_key", Keys.R.ToString());
                keys[4] = (Keys)Enum.Parse(typeof(Keys), btns[4].Text);
                btns[5].Text = INIReader.GetString(MainMenu.iniFolder, "FABRICA", "pause_key", Keys.Pause.ToString());
                keys[5] = (Keys)Enum.Parse(typeof(Keys), btns[5].Text);
            }
            catch
            {
                btns[0].Text = Keys.W.ToString();
                keys[0] = (Keys)Enum.Parse(typeof(Keys), btns[0].Text);
                btns[1].Text = Keys.A.ToString();
                keys[1] = (Keys)Enum.Parse(typeof(Keys), btns[1].Text);
                btns[2].Text = Keys.D.ToString();
                keys[2] = (Keys)Enum.Parse(typeof(Keys), btns[2].Text);
                btns[3].Text = Keys.Space.ToString();
                keys[3] = (Keys)Enum.Parse(typeof(Keys), btns[3].Text);
                btns[4].Text = Keys.R.ToString();
                keys[4] = (Keys)Enum.Parse(typeof(Keys), btns[4].Text);
                btns[5].Text = Keys.Pause.ToString();
                keys[5] = (Keys)Enum.Parse(typeof(Keys), btns[5].Text);
            }
            enemy_2.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            enemy_2.Invalidate();
            enemy_4.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            enemy_4.Invalidate();
            int count = 0;
            foreach (Control obj in Controls)
            {
                if (!(obj is Panel) && !(obj is Label) && obj != player && !obj.Name.StartsWith("teleport") && !obj.Name.EndsWith("icon"))
                    count++;
            }
            objFallSpeed = new int[count];
            Activate();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            Button[] btns = { jump_btn, left_btn, right_btn, shoot_btn, restart_btn, pause_btn };
            ground_panel_0.Focus();
            player_timer.Enabled = false;
            btn = sender as Button;
            for (int i = 0; i < btns.Length; i++)
            {
                if (btn == btns[i])
                    rebinding = i;
            }
            restore_name = btn.Text;
            btn.Text = "...";
            debug_text.Text = $"DEBUG:\nBullet Count: {bulletCount}\nBullet Remein: {bulletRemein}\nEnemy Count: {enemyCount}\nPosition:\nX: {player.Left}\nY: {Height - player.Top}\nHeight: {jumpHeight}\nPAUSE";
            in_rebind = rebind_task.Visible = true;
        }
    }
}