using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using minigames._Balda.classes;
using minigames._Balda.user_controls;

namespace minigames._Balda
{
    public partial class Balda : Form
    {
        private static readonly string[,,] words =
        {
            //русские слова:
            {
                //легко 3-4 буквы в слове
                { 
                  "кот", "дом", "сон", "лес", "мяч", "рот", "нос", "ухо", "глаз", "рука",
                  "нога", "лук", "сыр", "мед", "сок", "суп", "рис", "мир", "снег", "лед",
                  "лето", "небо", "море", "река", "гора", "луна", "день", "ночь", "утро", "ток"
                },
                //нормально 4-6 букв в слове
                { 
                  "книга", "ручка", "стол", "стул", "окно", "дверь", "полка", "шкаф", "диван",
                  "кресло", "лампа", "часы", "ложка", "вилка", "тарелка", "чашка", "ведро",
                  "метла", "мышка", "кошка", "собака", "птица", "рыба", "дерево", "цветок",
                  "трава", "земля", "вода", "огонь", "ветер" 
                },
                //сложно 6-8 букв в слове
                { 
                  "телефон", "компьютер", "монитор", "клавиша", "колонка", "телевизор", "холодильник",
                  "кастрюля", "сковорода", "тарелка", "салфетка", "полотенце", "кровать", "подушка",
                  "одеяло", "занавеска", "календарь", "картина", "зеркало", "лестница", "коридор",
                  "квартира", "балкон", "крыльцо", "дорожка", "машина", "автобус", "самолет", "корабль", "велосипед"
                }
            },
            //английские слова:
            {
                //легко 3-4 буквы в слове
                { 
                  "cat", "dog", "run", "sun", "moon", "star", "tree", "book", "pen", "cup",
                  "hat", "bag", "bed", "car", "bus", "fish", "bird", "door", "key", "food",
                  "hand", "foot", "head", "eye", "nose", "ear", "day", "night", "sky", "sea" 
                },
                //нормально 4-6 букв в слове
                {
                  "house", "table", "chair", "phone", "water", "apple", "bread", "cheese", "paper",
                  "pencil", "window", "flower", "garden", "school", "friend", "family", "church",
                  "street", "bridge", "river", "mountain", "forest", "beach", "ocean", "island",
                  "planet", "coffee", "music", "movie", "radio"
                },
                //сложно 6-8 букв в слове
                {
                  "computer", "keyboard", "monitor", "printer", "internet", "website", "software",
                  "program", "database", "network", "security", "password", "username", "algorithm",
                  "function", "variable", "constant", "library", "framework", "interface", "platform",
                  "operating", "language", "compiler", "debugger", "developer", "engineer", "designer",
                  "analyst", "manager" 
                }
            }
        };
        private readonly FieldConstructor fieldConstructor = new FieldConstructor(words);
        private readonly Random rand = new Random();
        private readonly Time time = new Time();
        private readonly int[] WordsCount = { 5, 8, 11 };
        public static int Score = 0;
        public static int MaxScore = 0;
        public static int Difficulty = 0;
        private bool SpacePressed = false, GameStarted = false;
        private string CurrentWord;
        private int[] CurrentCell = new int[2];
        private int[] PreviousCell = {-1, -1};
        private bool isCurrentVertical;
        private readonly List<string> Words = new List<string>();
        private char[,] Letters;
        private CellFields[,] cells;

        public Balda()
        {
            InitializeComponent();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e) => GameOver(true);

        private bool IsColorTooClose(int r1, int g1, int b1, int r2, int g2, int b2, int threshold) => Math.Abs(r1 - r2) < threshold && Math.Abs(g1 - g2) < threshold && Math.Abs(b1 - b2) < threshold;

        private Color GetRandomColor()
        {
            int minValue = 125;
            int maxValue = 220;
            while (true)
            {
                int r = rand.Next(minValue, maxValue);
                int g = rand.Next(minValue, maxValue);
                int b = rand.Next(minValue, maxValue);
                if (!IsColorTooClose(r, g, b, 0, 0, 0, 30) &&
                    !IsColorTooClose(r, g, b, 255, 255, 255, 30) &&
                    !IsColorTooClose(r, g, b, 0, 255, 0, 50))
                    return Color.FromArgb(r, g, b);
            }
        }

        private void Time_timer_Tick(object sender, EventArgs e)
        {
            time.UpdateTime();
            time_label.Text = (MainMenu.Language ? "Время: " : "Time: ") + time.GetTime();
        }

        private void ChangeLanguage()
        {
            if (MainMenu.Language)
            {
                Text = "Балда";
                time_label.Text = "Время: 00:00";
            }
            else
            {
                Text = "Balda";
                start_btn.Text = "START";
                time_label.Text = "Time: 00:00";
                words_counter.Text = "Words left: 0";
            }
            score_label.Text = MainMenu.Language ? $"Макс счёт: {MaxScore}" : $"Max score: {MaxScore}";
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) StartNewGame();
            if (e.KeyCode == Keys.F2) GameOver(true);
            if (e.KeyCode == Keys.Escape)
            {
                if (GameStarted) GameOver(true);
                else Close();
            }
            if (e.KeyCode == Keys.Space && !GameStarted) StartNewGame();
            if (e.KeyCode == Keys.Space && GameStarted)
            {
                if (!SpacePressed && cells[CurrentCell[0], CurrentCell[1]].BackColor == Color.Gainsboro)
                {
                    CurrentWord += cells[CurrentCell[0], CurrentCell[1]].Letter;
                    cells[CurrentCell[0], CurrentCell[1]].BackColor = SystemColors.Highlight;
                    PreviousCell[0] = CurrentCell[0];
                    PreviousCell[1] = CurrentCell[1];
                    SpacePressed = true;
                }
            }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && GameStarted)
            {
                SpacePressed = false;
                CheckWord();
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            Activate();
            ChangeLanguage();
            MaxScore = MainMenu.mg15_max_score;
            score_label.Text = MainMenu.Language ? $"Макс счёт: {MaxScore}" : $"Max score: {MaxScore}";
        }

        private void CreateField()
        {
            words_list.Items.Clear();
            Words.Clear();
            (char[,], string[]) Field = fieldConstructor.CreateNewField(WordsCount[Difficulty] * 2, MainMenu.Language, WordsCount[Difficulty], Difficulty);
            Letters = Field.Item1;
            Words.AddRange(Field.Item2);
            words_list.Items.AddRange(Words.ToArray());
            words_counter.Text = (MainMenu.Language ? "Осталось слов: " : "Words left: ") + words_list.Items.Count;
        }

        private void GenerateField()
        {
            CreateField();
            int size = WordsCount[Difficulty] * 2;
            int cell_size = field_panel.Width / size;
            field_panel.Controls.Clear();
            cells = null;
            cells = new CellFields[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = new CellFields()
                    {
                        BackColor = Color.Gainsboro,
                        Left = cell_size * j,
                        Top = cell_size * i,
                        Size = new Size(cell_size, cell_size),
                        FontSize = 16,
                        Letter = Letters[i, j].ToString(),
                        Name = $"cell_{i}_{j}"
                    };
                    cells[i, j].MouseEnter += Cells_MouseEnter;
                    field_panel.Controls.Add(cells[i, j]);
                }
            }
        }

        private void Cells_MouseEnter(object sender, EventArgs e)
        {
            CellFields cell = sender as CellFields;
            int i = Convert.ToInt32(cell.Name.Split('_')[1]);
            int j = Convert.ToInt32(cell.Name.Split('_')[2]);
            CurrentCell = new int[2] { i, j };
            if (SpacePressed && cell.BackColor == Color.Gainsboro)
            {
                bool isFirstCell = false;
                if (PreviousCell[0] == -1 && PreviousCell[1] == - 1)
                {
                    PreviousCell[0] = i; PreviousCell[1] = j;
                    isFirstCell = true;
                }
                if ((PreviousCell[0] == i && Math.Abs(PreviousCell[1] - j) == 1) || (Math.Abs(PreviousCell[0] - i) == 1 && PreviousCell[1] == j) || isFirstCell)
                {
                    if (CurrentWord.Length == 1)
                    {
                        isCurrentVertical = Math.Abs(PreviousCell[1] - j) == 1;
                        CurrentWord += cells[i, j].Letter;
                        cell.BackColor = SystemColors.Highlight;
                        PreviousCell = new int[2] { i, j };
                    }
                    else
                    {
                        if(isCurrentVertical)
                        {
                            if(PreviousCell[0] == i && Math.Abs(PreviousCell[1] - j) == 1)
                            {
                                CurrentWord += cells[i, j].Letter;
                                cell.BackColor = SystemColors.Highlight;
                                PreviousCell = new int[2] { i, j };
                            }
                        }
                        else
                        {
                            if(Math.Abs(PreviousCell[0] - i) == 1 && PreviousCell[1] == j)
                            {
                                CurrentWord += cells[i, j].Letter;
                                cell.BackColor = SystemColors.Highlight;
                                PreviousCell = new int[2] { i, j };
                            }
                        }
                    }
                }
            }
            else if(!SpacePressed) { PreviousCell[0] = -1; PreviousCell[1] = -1; }
        }

        private void StartNewGame()
        {
            GameOver(true);
            ChangeLanguage();
            question.Enabled = start_btn.Enabled = false;
            Score = 0;
            StartGame();
        }

        private void StartGame()
        {
            field_panel.Focus();
            time_label.Text = (MainMenu.Language ? "Время: " : "Time: ") + time.GetTime();
            score_label.Text = MainMenu.Language ? $"Счёт: {Score}" : $"Score: {Score}";
            GameStarted = true;
            time_timer.Start();
            GenerateField();
        }

        private void CheckWord()
        {
            bool all_ok = false;
            Color color;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].BackColor == SystemColors.Highlight)
                    {
                        all_ok = true;
                        break;
                    }
                }
                if (all_ok) break;
            }
            if (!all_ok) return;
            if (Words.Contains(CurrentWord))
            {
                Score += CurrentWord.Length;
                score_label.Text = MainMenu.Language ? $"Счёт: {Score}" : $"Score: {Score}";
                Words.Remove(CurrentWord);
                words_list.Items.Remove(CurrentWord);
                if (words_list.Items.Count == 0) GameOver(false);
                color = GetRandomColor();
            }
            else color = Color.Gainsboro;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].BackColor == SystemColors.Highlight)
                        cells[i, j].BackColor = color;
                }
            }
            words_counter.Text = (MainMenu.Language? "Осталось слов: " : "Words left: ") + words_list.Items.Count;
            CurrentWord = null;
        }

        private void Question_Click(object sender, EventArgs e)
        {
            by.Focus();
            if (MainMenu.Language)
                MessageBox.Show(
                    "Правила игры:\n" +
                    " - Перед вами поле, заполненное случайными буквами.\n" +
                    " - На поле спрятаны слова из заданного списка.\n" +
                    " - Ваша задача - найти все спрятанные слова.\n" +
                    " - Слова могут располагаться горизонтально, вертикально или по диагонали.\n" +
                    " - Если выделенное слово верно, оно будет удалено из списка скрытых слов.\n" +
                    " - Игра заканчивается, когда вы найдёте все спрятанные слова.\n\n" +
                    "Чтобы выделить слово:\n" +
                    " - Наведите курсор мыши на начальную букву слова.\n" +
                    " - Зажмите пробел.\n" +
                    " - Ведите курсор мыши по нужным буквам.\n" +
                    " - Выбранные буквы будут окрашиваться в ярко-зелёный цвет.\n" +
                    " - Отпустите пробел, чтобы подтвердить выбор.",
                    "Правила игры",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show(
                    "Game Rules:\n" +
                    " - You have a field filled with random letters.\n" +
                    " - Words from a given list are hidden in the field.\n" +
                    " - Your task is to find all the hidden words.\n" +
                    " - Words can be arranged horizontally, vertically, or diagonally.\n" +
                    " - If the selected word is correct, it will be removed from the list of hidden words.\n" +
                    " - The game ends when you find all the hidden words.\n\n" +
                    "To select a word:\n" +
                    " - Hover the mouse cursor over the starting letter of the word.\n" +
                    " - Hold down the spacebar.\n" +
                    " - Move the mouse cursor over the desired letters.\n" +
                    " - Selected letters will turn bright green.\n" +
                    " - Release the spacebar to confirm your selection.",
                    "Game Rules",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void Developer_name_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            by.Focus();
            StartNewGame();
        }

        private void Show_settings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && start_btn.Enabled)
            {
                Balda_Settings form = new Balda_Settings();
                form.ShowDialog();
            }
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

        private void GameOver(bool stoped)
        {
            field_panel.Controls.Clear();
            words_list.Items.Clear();
            if (stoped)
            {
                time.SetDefault();
                GameStarted = false;
                question.Enabled = start_btn.Enabled = true;
                time_timer.Stop();
                if (Score > MaxScore)
                {
                    MaxScore = Score;
                    MainMenu.mg15_max_score = MaxScore;
                }
                score_label.Text = MainMenu.Language ? $"Макс счёт: {MaxScore}" : $"Max score: {MaxScore}";
                Score = 0;
            }
            else
                StartGame();
        }
    }
}