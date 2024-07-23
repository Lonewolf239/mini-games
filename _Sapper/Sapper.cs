using IniReader;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace minigames._Sapper
{
    public partial class Sapper : Form
    {
        public Sapper()
        {
            InitializeComponent();
        }

        private readonly Random rand = new Random();
        private bool in_game = false;
        private Panel[][] panels;
        private int[][] field;
        private readonly int[][] sizes =
        {
            new int[]{ 8, 45, 13, 18 },
            new int[]{ 12, 30, 22, 14 },
            new int[]{ 18, 20, 49, 10 },
            new int[]{ 24, 15, 86, 8 },
        };
        private readonly Color[] text_color =
        {
            Color.FromArgb(0, 0, 255), Color.Lime,
            Color.FromArgb(255, 0, 0), Color.FromArgb(0, 0, 128),
            Color.FromArgb(128, 0, 0), Color.FromArgb(0, 128, 128),
            Color.FromArgb(0, 0, 0), Color.FromArgb(64, 64, 64)
        };
        public static int size_type = 0;
        private readonly PlaySound win = new PlaySound(MainMenu.CGFReader.GetFile("win.wav"), false),
            explosion = new PlaySound(MainMenu.CGFReader.GetFile("explosion.wav"), false);

        private void Sapper_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                Screen screen = Screen.FromPoint(Cursor.Position);
                developer_name.Left = Width - (developer_name.Width + 12);
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            if (!MainMenu.Language)
            {
                Text = "Sapper";
                start_btn.Text = "START";
            }
            Activate();
            size_type = INIReader.GetInt(MainMenu.iniFolder, "Sapper", "size_type");
            if (size_type < 0 || size_type > 3)
                size_type = 0;
        }

        private void GenerateTiles()
        {
            for (int y = 0; y < sizes[size_type][0]; y++)
            {
                for (int x = 0; x < sizes[size_type][0]; x++)
                {
                    if (field[y][x] != -1)
                    {
                        int startX = x > 0 ? x - 1 : x;
                        int startY = y > 0 ? y - 1 : y;
                        int endX = x > 0 ? startX + 3 : startX + 2;
                        int endY = y > 0 ? startY + 3 : startY + 2;
                        int bomb_neer = 0;
                        for (int i = startX; i < endX; i++)
                        {
                            if (i < sizes[size_type][0])
                            {
                                for (int j = startY; j < endY; j++)
                                {
                                    if (j < sizes[size_type][0])
                                    {
                                        if (field[j][i] == -1)
                                            bomb_neer++;
                                    }
                                }
                            }
                        }
                        field[y][x] = bomb_neer;
                        if (bomb_neer > 0)
                        {
                            Label label = new Label
                            {
                                Dock = DockStyle.Fill,
                                Font = new Font("Consolas", sizes[size_type][3] * MainMenu.scale_size),
                                ForeColor = text_color[bomb_neer - 1],
                                TextAlign = ContentAlignment.MiddleCenter,
                                Text = $"{bomb_neer}",
                                Name = $"panelI{y}_{x}",
                                Visible = false
                            };
                            label.MouseClick += new MouseEventHandler(Label_MouseClick);
                            panels[y][x].Controls.Add(label);
                        }
                    }
                }
            }
        }

        private void GenerateBombs()
        {
            int generated = 0;
            while (generated < sizes[size_type][2])
            {
                int x = rand.Next(sizes[size_type][0]);
                int y = rand.Next(sizes[size_type][0]);
                if (field[y][x] == 0)
                {
                    field[y][x] = -1;
                    generated++;
                }
            }
        }

        private void GenerateField()
        {
            top_panel.Controls.Clear();
            panels = null;
            field = null;
            panels = new Panel[sizes[size_type][0]][];
            field = new int[sizes[size_type][0]][];
            for (int i = 0; i < sizes[size_type][0]; i++)
            {
                field[i] = new int[sizes[size_type][0]];
                panels[i] = new Panel[sizes[size_type][0]];
                for (int j = 0; j < panels[i].Length; j++)
                {
                    panels[i][j] = new Panel
                    {
                        BackColor = Color.Silver,
                        BorderStyle = BorderStyle.Fixed3D,
                        Width = (int)(sizes[size_type][1] * MainMenu.scale_size),
                        Height = (int)(sizes[size_type][1] * MainMenu.scale_size),
                        Top = (int)(sizes[size_type][1] * MainMenu.scale_size) * i,
                        Left = (int)(sizes[size_type][1] * MainMenu.scale_size) * j,
                        Name = $"panelI{i}_{j}",
                        BackgroundImageLayout = ImageLayout.Zoom
                    };
                    panels[i][j].MouseClick += new MouseEventHandler(Panel_MouseClick);
                    panels[i][j].MouseEnter += new EventHandler(Panel_MouseEnter);
                    top_panel.Controls.Add(panels[i][j]);
                }
            }
            GenerateBombs();
            GenerateTiles();
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            Label panel = sender as Label;
            int[] index = GetPanel(panel.Name);
            Panel_Click(index[0], index[1], e.Button);
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Focus();
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            int[] index = GetPanel(panel.Name);
            Panel_Click(index[0], index[1], e.Button);
        }

        private int[] GetPanel(string name)
        {
            string[] index = name.Split('I');
            index = index[1].Split('_');
            int[] result = { Convert.ToInt32(index[1]), Convert.ToInt32(index[0]) };
            return result;
        }

        private void Panel_Click(int x, int y, MouseButtons button)
        {
            if (in_game)
            {
                if (button == MouseButtons.Left)
                {
                    if (panels[y][x].BackgroundImage == null)
                    {
                        if (field[y][x] != -1)
                        {
                            RevealCell(x, y);
                            if (IsGameWon())
                            {
                                if (MainMenu.sounds)
                                    win.Play(1);
                                ShowMines();
                            }
                        }
                        else
                        {
                            panels[y][x].BackgroundImage = Properties.Resources.explosion;
                            if (MainMenu.sounds)
                                explosion.Play(0.15f);
                            ShowMines();
                        }
                    }
                }
                else if (button == MouseButtons.Right)
                {
                    if (panels[y][x].BackColor != Color.Gray)
                    {
                        if (panels[y][x].BackgroundImage == null)
                            panels[y][x].BackgroundImage = Properties.Resources.flag;
                        else
                            panels[y][x].BackgroundImage = null;
                    }
                }
            }
        }

        private bool IsGameWon()
        {
            for (int i = 0; i < panels.Length; i++)
            {
                for (int j = 0; j < panels[i].Length; j++)
                {
                    if (field[i][j] != -1 && panels[i][j].BackColor != Color.Gray)
                        return false;
                }
            }
            return true;
        }

        private void RevealCell(int x, int y)
        {
            if (x < 0 || x >= panels[0].Length || y < 0 || y >= panels.Length || panels[y][x].BackColor == Color.Gray)
                return;
            panels[y][x].BackColor = Color.Gray;
            panels[y][x].BackgroundImage = null;
            panels[y][x].BorderStyle = BorderStyle.FixedSingle;
            if (field[y][x] > 0)
            {
                Label label = panels[y][x].Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                    label.Visible = true;
            }
            else if (field[y][x] == 0)
            {
                RevealCell(x - 1, y - 1);
                RevealCell(x, y - 1);
                RevealCell(x + 1, y - 1);
                RevealCell(x - 1, y);
                RevealCell(x + 1, y);
                RevealCell(x - 1, y + 1);
                RevealCell(x, y + 1);
                RevealCell(x + 1, y + 1);
            }
        }

        private void ShowMines()
        {
            for (int i = 0; i < panels.Length; i++)
            {
                for (int j = 0; j < panels[i].Length; j++)
                {
                    if (field[i][j] == -1)
                    {
                        panels[i][j].BackColor = Color.Red;
                        if (panels[i][j].BackgroundImage == null)
                            panels[i][j].BackgroundImage = Properties.Resources.mine;
                    }
                }
            }
            in_game = false;
            question.Enabled = start_btn.Enabled = true;
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            StartGame();
        }
        private void StartGame()
        {
            question.Enabled = start_btn.Enabled = false;
            in_game = true;
            GenerateField();
        }

        private void Question_Click(object sender, EventArgs e)
        {
            top_panel.Focus();
            if (MainMenu.Language)
                MessageBox.Show("Цель игры - открыть все клетки, не содержащие мины. " +
                    "Число на клетке показывает, сколько мин находится в соседних клетках. " +
                    "Используйте эту информацию, чтобы определить расположение мин. " +
                    "Клик левой кнопкой мыши открывает клетку, клик правой - ставит флажок. " +
                    "Будьте осторожны и не нажимайте на клетки с минами!", "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("The goal of the game is to uncover all the cells that do not contain mines. " +
                    "The number on a cell shows how many mines are in the neighboring cells. " +
                    "Use this information to determine the location of the mines. " +
                    "Left-click opens a cell, right-click places a flag. " +
                    "Be careful not to click on cells with mines!", "Rules of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Show_settings_MouseEnter(object sender, EventArgs e)
        {
            if (!in_game)
                show_settings.Image = Properties.Resources.setting_pressed_btn;
        }

        private void Sapper_FormClosing(object sender, FormClosingEventArgs e)
        {
            win?.Dispose();
            explosion?.Dispose();
        }

        private void Sapper_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!in_game)
                    Close();
                else
                    ShowMines();
            }
            if (e.KeyCode == Keys.Space && !in_game)
                StartGame();
            if (in_game)
            {
                Panel panel = null;
                for (int i = 0; i < panels.Length; i++)
                {
                    for (int j = 0; j < panels[i].Length; j++)
                    {
                        if (panels[i][j].Focused)
                            panel = panels[i][j];
                    }
                }
                if (panel != null)
                {
                    int[] index = GetPanel(panel.Name);
                    Panel_Click(index[0], index[1], MouseButtons.Right);
                }
            }
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && !in_game)
            {
                SP_settings form = new SP_settings
                {
                    Owner = this
                };
                form.ShowDialog();
            }
        }

        private void Show_settings_MouseLeave(object sender, EventArgs e)
        {
            if (!in_game)
                show_settings.Image = Properties.Resources.setting_btn;
        }
    }
}