using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._2048
{
    public partial class MG2048 : Form
    {
        public MG2048()
        {
            InitializeComponent();
        }

        private readonly Random rand = new Random();
        public static int score = 0, max_score = 0;
        private Control[][] tiles =
        {
            new Control[4],
            new Control[4],
            new Control[4],
            new Control[4]
        };
        private readonly PlaySound win = new PlaySound(MainMenu.CGFReader.GetFile("win.wav"), false),
                        game_over = new PlaySound(MainMenu.CGFReader.GetFile("game_over.wav"), false);

        private void MG2048_Load(object sender, EventArgs e)
        {
            score = 0;
            max_score = MainMenu.mg10_max_score;
            Panel[][] panels =
            {
                new Panel[4],
                new Panel[4],
                new Panel[4],
                new Panel[4]
            };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    panels[i][j] = new Panel
                    {
                        Width = 60,
                        Height = 60,
                        Top = 63 * i,
                        Left = 63 * j,
                        BackColor = Color.FromArgb(187, 173, 160),
                        BorderStyle = BorderStyle.FixedSingle,
                        Name = $"tile_panel_{i}_{j}"
                    };
                    tiles[i][j] = new Label
                    {
                        AutoSize = false,
                        Width = 60,
                        Height = 60,
                        ForeColor = Color.Black,
                        Font = new Font(FontFamily.GenericSansSerif, 14F * MainMenu.scale_size),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Name = $"tile_{i}_{j}"

                    };
                    panels[i][j].Controls.Add(tiles[i][j]);
                    game_interface.Controls.Add(panels[i][j]);
                }
            }
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
            score_text.Text = $"счёт: {score}\nмакс. счёт: {max_score}";
            if (!MainMenu.Language)
            {
                start_btn.Text = "START";
                score_text.Text = $"score: {score}\nmax score: {max_score}";
            }
            Activate();
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Нажатием стрелок или WASD игрок сбрасывает плитки в стороны. " +
                    "После хода появляется новая плитка номиналом \"2\". " +
                    "Плитки одного номинала соединяются. " +
                    "За соединение очки увеличиваются. " +
                    "Игра заканчивается поражением, если ход невозможен.", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("By pressing the arrows or WASD, the player throws the tiles to the sides. " +
                    "After the move, a new tile with a value of \"2\" appears. " +
                    "Tiles of the same value are connected. " +
                    "For connecting, points increase. " +
                    "The game ends in defeat if a move is not possible.", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            top_panel.Focus();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    tiles[i][j].Text = null;
            }
            SpawnNewTiles();
            SpawnNewTiles();
            RecolorTiles();
            start_btn.Enabled = question.Enabled = false;
        }

        private void MG2048_KeyDown(object sender, KeyEventArgs e)
        {
            if (!start_btn.Enabled)
            {
                if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                {
                    MoveTiles(0);
                }
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                {
                    MoveTiles(1);
                }
                else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    MoveTiles(2);
                }
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    MoveTiles(3);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (score > max_score)
                    MainMenu.mg10_max_score = score;
                Close();
            }
            else if (e.KeyCode == Keys.Space) 
            {
                if (start_btn.Enabled)
                    StartGame();
            }
        }

        private void MoveTiles(int direction)
        {
            int[][] numbers =
            {
                new int[4],
                new int[4],
                new int[4],
                new int[4]
            };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    try
                    {
                        numbers[i][j] = Convert.ToInt32(tiles[i][j].Text);
                    }
                    catch
                    {
                        numbers[i][j] = 0;
                    }
                }
            }
            // up
            if (direction == 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    int k = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (numbers[i][j] != 0)
                        {
                            if (k != 0 && numbers[k - 1][j] == numbers[i][j])
                            {
                                numbers[k - 1][j] *= 2;
                                score++;
                                numbers[i][j] = 0;
                            }
                            else
                            {
                                numbers[k][j] = numbers[i][j];
                                if (i != k)
                                    numbers[i][j] = 0;
                                k++;
                            }
                        }
                    }
                }
            }
            //down
            else if (direction == 1)
            {
                for (int j = 0; j < 4; j++)
                {
                    int k = 3;
                    for (int i = 3; i >= 0; i--)
                    {
                        if (numbers[i][j] != 0)
                        {
                            if (k != 3 && numbers[k + 1][j] == numbers[i][j])
                            {
                                numbers[k + 1][j] *= 2;
                                score++;
                                numbers[i][j] = 0;
                            }
                            else
                            {
                                numbers[k][j] = numbers[i][j];
                                if (i != k)
                                    numbers[i][j] = 0;
                                k--;
                            }
                        }
                    }
                }
            }
            //left
            else if (direction == 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    int k = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (numbers[i][j] != 0)
                        {
                            if (k != 0 && numbers[i][k - 1] == numbers[i][j])
                            {
                                numbers[i][k - 1] *= 2;
                                score++;
                                numbers[i][j] = 0;
                            }
                            else
                            {
                                numbers[i][k] = numbers[i][j];
                                if (j != k)
                                    numbers[i][j] = 0;
                                k++;
                            }
                        }
                    }
                }
            }
            //right
            else if (direction == 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    int k = 3;
                    for (int j = 3; j >= 0; j--)
                    {
                        if (numbers[i][j] != 0)
                        {
                            if (k != 3 && numbers[i][k + 1] == numbers[i][j])
                            {
                                numbers[i][k + 1] *= 2;
                                score++;
                                numbers[i][j] = 0;
                            }
                            else
                            {
                                numbers[i][k] = numbers[i][j];
                                if (j != k)
                                    numbers[i][j] = 0;
                                k--;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (numbers[i][j] != 0)
                        tiles[i][j].Text = numbers[i][j].ToString();
                    else
                        tiles[i][j].Text = null;
                }
            }
            score_text.Text = $"счёт: {score}\nмакс. счёт: {max_score}";
            if (!MainMenu.Language)
                score_text.Text = $"score: {score}\nmax score: {max_score}";
            SpawnNewTiles();
            RecolorTiles();
        }

        private void MG2048_FormClosing(object sender, FormClosingEventArgs e)
        {
            win?.Dispose();
            game_over?.Dispose();
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void SpawnNewTiles()
        {
            bool find_2048 = false;
            List<string> empty_tiles = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tiles[i][j].Text.Length == 0)
                        empty_tiles.Add($"{i}:{j}");
                    else if (tiles[i][j].Text == "2048")
                        find_2048 = true;
                }
            }
            if (!find_2048)
            {
                if (empty_tiles.Count > 0)
                {
                    string[] empty_tile = empty_tiles[rand.Next(0, empty_tiles.Count)].Split(':');
                    tiles[Convert.ToInt32(empty_tile[0])][Convert.ToInt32(empty_tile[1])].Text = "2";
                }
                else
                {
                    question.Enabled = start_btn.Enabled = true;
                    game_over.Play(1);
                    if (score > max_score)
                        MainMenu.mg10_max_score = max_score = score;
                    score = 0;
                }
            }
            else
            {
                question.Enabled = start_btn.Enabled = true;
                win.Play(1);
                if (score > max_score)
                    MainMenu.mg10_max_score = max_score = score;
                score = 0;
            }
        }

        private void RecolorTiles()
        {
            for (int i = 0; i < 4; i++)
            {
                foreach (Control tile in tiles[i])
                {
                    if (tile.Text == "")
                        tile.BackColor = Color.FromArgb(187, 173, 160);
                    else if (tile.Text == "2")
                        tile.BackColor = Color.FromArgb(238, 228, 218);
                    else if (tile.Text == "4")
                        tile.BackColor = Color.FromArgb(237, 224, 200);
                    else if (tile.Text == "8")
                        tile.BackColor = Color.FromArgb(242, 177, 121);
                    else if (tile.Text == "16")
                        tile.BackColor = Color.FromArgb(245, 149, 99);
                    else if (tile.Text == "32")
                        tile.BackColor = Color.FromArgb(246, 124, 95);
                    else if (tile.Text == "64")
                        tile.BackColor = Color.FromArgb(246, 94, 59);
                    else if (tile.Text == "128")
                        tile.BackColor = Color.FromArgb(237, 207, 114);
                    else if (tile.Text == "256")
                        tile.BackColor = Color.FromArgb(237, 204, 97);
                    else if (tile.Text == "512")
                        tile.BackColor = Color.FromArgb(237, 200, 80);
                    else if (tile.Text == "1024")
                        tile.BackColor = Color.FromArgb(237, 197, 63);
                    else
                        tile.BackColor = Color.FromArgb(227, 135, 23);
                }
            }
        }
    }
}