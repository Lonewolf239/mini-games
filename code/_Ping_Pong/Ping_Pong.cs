using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._Ping_Pong
{
    public partial class Ping_Pong : Form
    {
        public Ping_Pong()
        {
            InitializeComponent();
        }

        private readonly Random rand = new Random();
        private enum Direction { STOP, UP, DOWN };
        private Direction player_0_direction = Direction.STOP, player_1_direction = Direction.STOP;
        private float ball_angle, speed;
        private const float START_SPEED = 5f, MAX_SPEED = 12.5f, LOSE_SPEED_UP = 0.25f, SPEED_UP = 0.005f, RACQUET_SPEED_UP = 0.05f;
        private int pl0_score = 0, pl1_score = 0;
        private readonly PlaySound beep = new PlaySound(@"sounds\ping_pong_beep.wav"), blop = new PlaySound(@"sounds\ping_pong_blop.wav");

        private void Ping_Pong_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
            {
                Text = "Ping-Pong";
                start_btn.Text = "START";
                finish_text.Text = "Play until:";
                finish_text.Left = 173;
            }
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                foreach (Control text in top_background.Controls)
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
            Activate();
            pause_text.Location = new Point((top_panel.Width - pause_text.Width) / 2, (top_panel.Height - pause_text.Height) / 2);
            ball.Location = new Point((top_panel.Width - ball.Width) / 2, (top_panel.Height - ball.Height) / 2);
            separator.Left = (top_panel.Width - separator.Width) / 2;
        }

        private void Ping_Pong_KeyDown(object sender, KeyEventArgs e)
        {
            if (ball_timer.Enabled)
            {
                if (e.KeyCode == Keys.W)
                    player_0_direction = Direction.UP;
                if (e.KeyCode == Keys.S)
                    player_0_direction = Direction.DOWN;
                if (e.KeyCode == Keys.Up)
                    player_1_direction = Direction.UP;
                if (e.KeyCode == Keys.Down)
                    player_1_direction = Direction.DOWN;
            }
            if (e.KeyCode == Keys.Space)
            {
                if (!start_btn.Enabled)
                {
                    pause_text.Visible = !pause_text.Visible;
                    player_0_timer.Enabled = !player_0_timer.Enabled;
                    player_1_timer.Enabled = !player_1_timer.Enabled;
                    ball_timer.Enabled = !ball_timer.Enabled;
                }
                else
                    StartGame();
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (!start_btn.Enabled)
                {
                    pause_text.Text = $"GAME OVER";
                    Game_Over();
                }
                else
                    Close();
            }
        }

        private void Ping_Pong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (player_0_direction == Direction.UP)
                    player_0_direction = Direction.STOP;
            }
            if (e.KeyCode == Keys.S)
            {
                if (player_0_direction == Direction.DOWN)
                    player_0_direction = Direction.STOP;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (player_1_direction == Direction.UP)
                    player_1_direction = Direction.STOP;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (player_1_direction == Direction.DOWN)
                    player_1_direction = Direction.STOP;
            }
        }

        private void Player_0_timer_Tick(object sender, EventArgs e)
        {
            if (player_0.Top > 0 && player_0_direction == Direction.UP)
                player_0.Top -= (int)(5 * MainMenu.scale_size);
            else if (player_0.Top < top_panel.Height - player_0.Height - 5 && player_0_direction == Direction.DOWN)
                player_0.Top += 5;
        }

        private void Player_1_timer_Tick(object sender, EventArgs e)
        {
            if (player_1.Top > 0 && player_1_direction == Direction.UP)
                player_1.Top -= (int)(5 * MainMenu.scale_size);
            else if (player_1.Top < top_panel.Height - player_1.Height - 5 && player_1_direction == Direction.DOWN)
                player_1.Top += (int)(5 * MainMenu.scale_size);
        }

        private void Ping_Pong_FormClosing(object sender, FormClosingEventArgs e)
        {
            ball_timer.Enabled = color_timer.Enabled = player_0_timer.Enabled = player_1_timer.Enabled = false;
            beep?.Dispose();
            blop?.Dispose();
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            PP_Info form = new PP_Info();
            form.ShowDialog();
        }

        private void Color_timer_Tick(object sender, EventArgs e)
        {
            player_0.BackColor = player_1.BackColor = Color.Gainsboro;
            color_timer.Stop();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void StartGame()
        {
            top_panel.Focus();
            pause_text.Visible = false;
            pause_text.Text = "PAUSE";
            speed = START_SPEED;
            pause_text.Location = new Point((top_panel.Width - pause_text.Width) / 2, (top_panel.Height - pause_text.Height) / 2);
            ball_angle = rand.Next(15, 45);
            ball.Location = new Point((top_panel.Width - ball.Width) / 2, (top_panel.Height - ball.Height) / 2);
            finish_input.Enabled = question.Enabled = start_btn.Enabled = false;
            ball_timer.Enabled = player_0_timer.Enabled = player_1_timer.Enabled = true;
        }

        private void Ball_timer_Tick(object sender, EventArgs e)
        {
            double angle = ball_angle * Math.PI / 180f,
                dx = speed * (double)Math.Cos(angle),
                dy = speed * (double)Math.Sin(angle);
            Rectangle gameArea = top_panel.ClientRectangle;
            if (ball.Left + (int)dx < gameArea.Left)
            {
                ball_angle = 180 - ball_angle;
                dx = -dx;
                player_0.BackColor = Color.Red;
                color_timer.Start();
                pl1_score++;
                if (MainMenu.sounds)
                    blop.Play(0.4f);
                speed += LOSE_SPEED_UP;
            }
            else if (ball.Right + (int)dx >= gameArea.Right)
            {
                ball_angle = 180 - ball_angle;
                dx = -dx;
                player_1.BackColor = Color.Red;
                color_timer.Start();
                pl0_score++;
                if (MainMenu.sounds)
                    blop.Play(0.4f);
                speed += LOSE_SPEED_UP;
            }
            if (ball.Top + (int)dy < gameArea.Top)
            {
                ball_angle = 360 - ball_angle;
                dy = -dy;
                if (MainMenu.sounds)
                    blop.Play(0.4f);
                speed += SPEED_UP;
            }
            else if (ball.Bottom + (int)dy >= gameArea.Bottom)
            {
                ball_angle = 360 - ball_angle;
                dy = -dy;
                if (MainMenu.sounds)
                    blop.Play(0.4f);
                speed += SPEED_UP;
            }
            ball.Left += (int)(dx * MainMenu.scale_size);
            ball.Top += (int)(dy * MainMenu.scale_size);
            if (ball.Bounds.IntersectsWith(player_0.Bounds))
            {
                if (dx < 0)
                    ball_angle = 180 - ball_angle;
                ball.Left = player_0.Right;
                if (MainMenu.sounds)
                    beep.Play(0.2f);
                speed += RACQUET_SPEED_UP;
            }
            else if (ball.Bounds.IntersectsWith(player_1.Bounds))
            {
                if (dx > 0)
                    ball_angle = 180 - ball_angle;
                ball.Left = player_1.Left - ball.Width;
                if (MainMenu.sounds)
                    beep.Play(0.2f);
                speed += RACQUET_SPEED_UP;
            }
            if (speed > MAX_SPEED)
                speed = MAX_SPEED;
            speed_progress.Width = (int)(speed / 15 * speed_panel.Width);
            pl0_score_text.Text = $"PL1 score: {pl0_score}";
            pl1_score_text.Text = $"PL2 score: {pl1_score}";
            if (pl0_score >= (int)finish_input.Value)
            {
                pause_text.Text = $"PLAYER 1 WIN!";
                Game_Over();
            }
            else if (pl1_score >= (int)finish_input.Value)
            {
                pause_text.Text = $"PLAYER 2 WIN!";
                Game_Over();
            }
        }

        private void Game_Over()
        {
            pause_text.Location = new Point((top_panel.Width - pause_text.Width) / 2, (top_panel.Height - pause_text.Height) / 2);
            pl0_score = pl1_score = 0;
            pause_text.Visible = finish_input.Enabled = question.Enabled = start_btn.Enabled = true;
            ball_timer.Enabled = player_0_timer.Enabled = player_1_timer.Enabled = false;
        }
    }
}
