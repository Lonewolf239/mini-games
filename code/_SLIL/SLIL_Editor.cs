using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MazeGenerator;
using minigames._Tetris;

namespace minigames._SLIL
{
    public partial class SLIL_Editor : Form
    {
        public SLIL_Editor()
        {
            InitializeComponent();
        }

        public static int MazeHeight;
        public static int MazeWidth;
        private int old_MazeHeight;
        private int old_MazeWidth;
        public static int x, y;
        private Panel[,] panels;
        private bool playerExist = false;
        private int finishCount = 0;

        private void Import_btn_Click(object sender, EventArgs e)
        {
            editor_interface.Focus();
            int maze_height, maze_width;
            string map = Clipboard.GetText();
            try
            {
                string[] MAP = map.Split(':');
                maze_height = Convert.ToInt32(MAP[0]);
                maze_width = Convert.ToInt32(MAP[1]);
                if (MAP[2].Any(c => c != '.' && c != '#' && c != '&' && c != 'P'))
                {
                    if (MainMenu.Language)
                        MessageBox.Show("Строка содержит недопустимые символы.", "Ошибка импорта карты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("The string contains invalid characters.", "Error importing map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (map.Length == 0)
                {
                    if (MainMenu.Language)
                        MessageBox.Show("Буфер обмена пуст.", "Ошибка импорта карты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("The clipboard is empty.", "Error importing map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (maze_height < 2 * 3 + 1 || maze_height > 20 * 3 + 1 || maze_width < 2 * 3 + 1 || maze_width > 20 * 3 + 1)
                {
                    if (MainMenu.Language)
                        MessageBox.Show("Неверный формат строки.", "Ошибка импорта карты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Invalid string format.", "Error importing map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                map = MAP[2];
                MazeWidth = maze_width;
                MazeHeight = maze_height;
                GenerateField(map);
            }
            catch
            {
                MazeHeight = old_MazeHeight;
                MazeWidth = old_MazeWidth;
                editor_interface.Controls.Clear();
                GenerateField();
                if (MainMenu.Language)
                    MessageBox.Show("Неверный формат строки.", "Ошибка импорта карты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Invalid string format.", "Error importing map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Export_btn_Click(object sender, EventArgs e)
        {
            editor_interface.Focus();
            try
            {
                string map = $"{MazeHeight}:{MazeWidth}:{GenerateMap()}";
                Clipboard.SetText(map);
                if (MainMenu.Language)
                    MessageBox.Show("Карта успешно скопирована в буфер обмена.", "Карта скопирована", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("The map was successfully copied to the clipboard.", "The map was copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (MainMenu.Language)
                    MessageBox.Show($"Не удалось скопировать карту в буфер обмена.\n{ex.Message}", "Ошибка копирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Could not copy the map to the clipboard.\n{ex.Message}", "Copy error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SLIL_Editor_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
            {
                Text = "Editor";
                about.Text = "1 - put up a wall\n2 - set the finish\n3 - place a player\nSpace - remove item";
            }
            old_MazeHeight = MazeHeight;
            old_MazeWidth = MazeWidth;
            if (MazeHeight != MazeWidth)
            {
                random_btn.BackColor = Color.LightGray;
                random_btn.Enabled = false;
            }
            GenerateField();
        }

        private void GenerateField(string map = "empty")
        {
            if (map == "empty")
            {
                for (int i = 0; i < MazeWidth * MazeHeight + 1; i++)
                    map += ".";
            }
            panels = null;
            editor_interface.Controls.Clear();
            int size = 15;
            if (MazeHeight < 11 && MazeWidth < 11)
                size = 30;
            else if (MazeHeight < 19 && MazeWidth < 19)
                size = 20;
            int min = Math.Min(MazeHeight, MazeWidth), max = Math.Max(MazeHeight, MazeWidth);
            panels = new Panel[min, max];
            for (int i = 0; i < min; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    Color color = Color.Black;
                    char c = map[i * min + j];
                    if (i != 0 && i != min - 1 && j != 0 && j != max - 1)
                    {
                        if (c == '.')
                            color = Color.White;
                        else if (c == '&')
                        {
                            color = Color.Lime;
                            finishCount = 1;
                        }
                        else if (c == 'P')
                        {
                            color = Color.Red;
                            playerExist = true;
                        }
                    }
                    Panel panel = new Panel
                    {
                        Height = size,
                        Width = size,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = color,
                        Left = size * j,
                        Top = size * i,
                        Name = $"panel_{i}_{j}"
                    };
                    panel.MouseEnter += new EventHandler(Panels_MouseEnter);
                    editor_interface.Controls.Add(panel);
                    panels[i, j] = panel;
                }
            }
            accept_button.Left = reset_btn.Left = random_btn.Left = import_btn.Left = export_btn.Left = editor_interface.Right + 6;
            about.Top = editor_interface.Bottom + 3;
            Width = accept_button.Right + 21;
            Height = about.Bottom + 40;
            int centerX = Owner.Left + (Owner.Width - Width) / 2;
            int centerY = Owner.Top + (Owner.Height - Height) / 2;
            Location = new Point(centerX, centerY);
        }

        private string GenerateMap()
        {
            StringBuilder MAP = new StringBuilder();
            for (int i = 0; i < panels.GetLength(0); i++)
            {
                for (int j = 0; j < panels.GetLength(1); j++)
                {
                    if (panels[i, j].BackColor == Color.Black)
                        MAP.Append("#");
                    else if (panels[i, j].BackColor == Color.White)
                        MAP.Append(".");
                    else if (panels[i, j].BackColor == Color.Lime)
                        MAP.Append("&");
                    else if (panels[i, j].BackColor == Color.Red)
                    {
                        MAP.Append("P");
                        x = j;
                        y = i;
                    }
                }
            }
            return MAP.ToString();
        }

        private void Panels_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Focus();
        }
        
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            editor_interface.Focus();
            playerExist = false;
            finishCount = 0;
            GenerateField();
        }

        private void Random_btn_Click(object sender, EventArgs e)
        {
            editor_interface.Focus();
            finishCount = 0;
            playerExist = false;
            StringBuilder sb = new StringBuilder();
            Maze MazeGenerator = new Maze();
            char[,] map = MazeGenerator.GenerateCharMap((MazeWidth - 1) / 3, (MazeHeight - 1) / 3, '#', '.', '&');
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
                    if (map[x, y] == '&')
                        finishCount++;
                    sb.Append(map[x, y]);
                }
            }
            GenerateField(sb.ToString());
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            editor_interface.Focus();
            if (!playerExist)
            {
                if (MainMenu.Language)
                    MessageBox.Show("Отсутствует игрок", "Карта не завершена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Missing player", "The map is not completed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (finishCount == 0)
            {
                if (MainMenu.Language)
                    MessageBox.Show("Отсутствует финиш", "Карта не завершена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Missing finish", "The map is not completed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SLIL.CUSTOM_MAP = GenerateMap();
            SLIL.CUSTOM = true;
            Close();
        }

        private void SLIL_Editor_KeyDown(object sender, KeyEventArgs e)
        {
            Panel panel = null;
            for (int i = 1; i < panels.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < panels.GetLength(1) - 1; j++)
                {
                    if (panels[i, j].Focused)
                        panel = panels[i, j];
                }
            }
            if (panel == null)
                return;
            if (panel.BackColor == Color.White)
            {
                if (e.KeyCode == Keys.D1)
                    panel.BackColor = Color.Black;
                else if (e.KeyCode == Keys.D2)
                {
                    panel.BackColor = Color.Lime;
                    finishCount++;
                }
                else if (e.KeyCode == Keys.D3 && !playerExist)
                {
                    panel.BackColor = Color.Red;
                    playerExist = true;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (panel.BackColor == Color.Lime)
                        finishCount--;
                    else if (panel.BackColor == Color.Red)
                        playerExist = false;
                    panel.BackColor = Color.White;
                }
            }
        }
    }
}