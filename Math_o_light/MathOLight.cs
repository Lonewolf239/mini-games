using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using minigames.Math_o_light.classes;

namespace minigames.Math_o_light
{
    public partial class MathOLight : Form
    {
        private const int TimeToSpawnMine = 5000, FallingMineTime = 250, AnswersToCreateBarrier = 5, MaxBarrierCount = 4;
        private readonly Random rand = new Random();
        private readonly Player player;
        private readonly MathProblem math = new MathProblem();
        private readonly List<Mine> Mines = new List<Mine>();
        private readonly List<Barrier> Barriers = new List<Barrier>();
        private readonly Bitmap Field;
        private bool HasMinus = false;
        public static int score;
        public int MaxGameScore { get; set; }
        private bool GameStarted = false;

        public MathOLight() 
        {
            InitializeComponent();
            add_mine_timer.Interval = TimeToSpawnMine;
            mines_timer.Interval = FallingMineTime;
            player = new Player() { MaxScore = MaxGameScore };
            Field = new Bitmap(field_picture.Width, field_picture.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Activate();
            MaxGameScore = MainMenu.mg3_max_score;
            score = MaxGameScore;
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                    foreach (Control text1 in text.Controls)
                    {
                        if (!text1.Name.StartsWith("C"))
                            text1.Font = new Font(text1.Font.FontFamily, text1.Font.Size * MainMenu.scale_size);
                    }
                }
                Screen screen = Screen.FromPoint(Cursor.Position);
                developer_name.Left = by.Right - developer_name.Width;
                int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
                int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
                Left = centerX - (Width / 2);
                Top = centerY - (Height / 2);
            }
            if (!MainMenu.Language)
            {
                Text = "Math-o-Light";
                Cscore_text.Text = $"max score: {MaxGameScore}";
            }
            else
                Cscore_text.Text = $"макс счёт: {MaxGameScore}";
        }

        private void Add_mine_timer_Tick(object sender, EventArgs e) => AddMine();

        private void Math_example_text_Enter(object sender, EventArgs e) => player_base_panel.Focus();

        private int GetAnswerLength() => Cmath_example_text.Text.Replace(" ", "").Split('=')[1].Length;

        private string GetAnswer()
        {
            if (GetAnswerLength() == 1)
                return Cmath_example_text.Text.Replace(" ", "").Split('=')[1];
            return Cmath_example_text.Text.Replace(" ", "").Split('=')[1].TrimStart('0');
        }

        private void Progressbar_timer_Tick(object sender, EventArgs e)
        {
            hp_progressbar.Width = (int)((double)player.HP / player.GetMaxHP() * hp_progressbar_background.Width);
            barrier_progressbar.Width = (int)((double)player.SolvedMathProblems / AnswersToCreateBarrier * barrier_progressbar_background.Width);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if (key == Keys.Space)
                StartGame();
            if (GameStarted)
            {
                if (key == Keys.Back)
                    ClearAnswer(false);
                else if (key == Keys.Enter)
                    CheckAnswer();
                else if (key == Keys.OemMinus)
                    AddCharToAnswer("-");
                else if (key.ToString().StartsWith("D"))
                {
                    string num = key.ToString().Trim('D');
                    if (num.Length == 1)
                        AddCharToAnswer(num);
                }
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            player_base_panel.Focus();
            ClearAnswer(true);
        }

        private void ClearAnswer(bool all)
        {
            if (GameStarted)
            {
                Cmath_example_text.BackColor = Color.Gainsboro;
                if (all)
                {
                    HasMinus = false;
                    Cmath_example_text.Text = math.CurrentMathProblem;
                }
                else if (GetAnswerLength() > 0)
                    Cmath_example_text.Text = Cmath_example_text.Text.Remove(Cmath_example_text.Text.Length - 1, 1);
                if (GetAnswerLength() == 0)
                {
                    HasMinus = false;
                    Cmath_example_text.Text = math.CurrentMathProblem;
                }
            }
        }

        private void KeyboardButton_Click(object sender, EventArgs e)
        {
            player_base_panel.Focus();
            if (GameStarted)
                AddCharToAnswer((sender as Button).Name.Split('_')[1]);
        }

        private void AddCharToAnswer(string value)
        {
            if (Cmath_example_text.BackColor == Color.Tomato)
            {
                Cmath_example_text.Text = math.CurrentMathProblem;
                Cmath_example_text.BackColor = Color.Gainsboro;
            }
            if (value == "-" && HasMinus)
                return;
            else if (value == "-")
                HasMinus = true;
            if (value == "0" && (GetAnswerLength() == 0 && math.CurrentAnswer != "0"))
                return;
            if (Cmath_example_text.Text.Length < Cmath_example_text.MaxLength)
                Cmath_example_text.Text += value;
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            player_base_panel.Focus();
            CheckAnswer();
        }

        private void CheckAnswer()
        {
            if (GameStarted)
            {
                HasMinus = false;
                if (GetAnswer() == math.CurrentAnswer)
                {
                    player.SolvedMathProblems++;
                    AddBarrier();
                    player.Score++;
                    Cmath_example_text.Text = math.GetNewMathProblem(player.Difficulty);
                    player.Difficulty += 0.01;
                }
                else
                    Cmath_example_text.BackColor = Color.Tomato;
            }
        }

        private void AddBarrier()
        {
            if (player.SolvedMathProblems >= AnswersToCreateBarrier && Barriers.Count < MaxBarrierCount)
            {
                int newY = 245;
                if (Barriers.Count > 0)
                {
                    Barrier topBarrier = Barriers[0];
                    newY = topBarrier.Top - topBarrier.GetHeight() - 5;
                }
                Barriers.Insert(0, new Barrier(newY));
                player.SolvedMathProblems = 0;
                Barriers.Sort((b1, b2) => b1.Top.CompareTo(b2.Top));
            }
        }

        private void Refresh_timer_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(Field))
            {
                g.Clear(Color.Gainsboro);
                for (int i = 0; i < Mines.Count; i++)
                {
                    Mine mine = Mines[i];
                    g.DrawImage(Properties.Resources.mine, mine.Left, mine.Top, mine.GetSize(), mine.GetSize());
                }
                for (int i = 0; i < Barriers.Count; i++)
                {
                    Barrier barrier = Barriers[i];
                    if (barrier.HP == 3)
                        g.DrawLine(new Pen(Color.FromArgb(137, 207, 240), barrier.GetHeight()), 0, barrier.Top, Field.Width, barrier.Top);
                    else if (barrier.HP == 2)
                        g.DrawLine(new Pen(Color.Yellow, barrier.GetHeight()), 0, barrier.Top, Field.Width, barrier.Top);
                    else
                        g.DrawLine(new Pen(Color.Red, barrier.GetHeight()), 0, barrier.Top, Field.Width, barrier.Top);

                }
            }
            Cscore_text.Text = $"счёт: {player.Score}";
            field_picture.Image = Field;
        }

        private void Mines_timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Mines.Count; i++)
            {
                Mine mine = Mines[i];
                mine.UpdateCoordinates();
                if (Barriers.Count > 0 && mine.Bottom >= Barriers[0].Top)
                {
                    if (Barriers[0].HP <= 1)
                        Barriers.RemoveAt(0);
                    else
                        Barriers[0].HP--;
                    player.Score += rand.Next(1, 6);
                    Mines.Remove(mine);
                    if (i > 0) i--;
                }
                else if (mine.Bottom >= Field.Height)
                {
                    Mines.Remove(mine);
                    if (player.DealDamage(rand.Next(20, 25)))
                        GameOver();
                    if (i > 0) i--;
                }
            }
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (player.Score > MaxGameScore)
            {
                refresh_timer.Stop();
                mines_timer.Stop();
                add_mine_timer.Stop();
                MaxGameScore = player.Score;
            }
            score = MaxGameScore;
        }

        private void Question_Click(object sender, EventArgs e)
        {
            player_base_panel.Focus();
            string message = "1. На игровом поле отображается калькулятор с числами и операциями (+, -, *, ^)." +
                "\n2. С верхней части экрана падают мины, угрожающие калькулятору." +
                "\n3. У вас есть определенное количество очков здоровья (ХП)." +
                "\n4. Ваша задача - решать математические примеры, вводя правильный ответ на калькуляторе." +
                "\n5. При касании мины калькулятора, вы теряете некоторое количество ХП." +
                "\n6. После 5 правильно решенных примеров создается защитный барьер." +
                "\n7. Барьер может выдержать 3 попадания мин, прежде чем разрушится." +
                "\n8. Игра продолжается до тех пор, пока у вас не закончится ХП или вы не решите выйти." +
                "\n9. Ваша цель - продержаться как можно дольше, решая примеры и создавая защитные барьеры!" +
                "\n10. Со временем сложность увеличивается." +
                "\nУдачи и помните: быстрота и точность - ключ к победе!",
                title = "Правила игры";
            if (!MainMenu.Language)
            {
                message = "1. The game field displays a calculator with numbers and operations (+, -, *, ^)." +
                "\n2. Mines fall from the top of the screen, threatening the calculator." +
                "\n3. You have a certain amount of health points (HP)." +
                "\n4. Your task is to solve math problems by entering the correct answer on the calculator." +
                "\n5. When you touch the calculator with a mine, you lose some HP." +
                "\n6. After 5 correctly solved problems, a protective barrier is created." +
                "\n7. The barrier can withstand 3 mine hits before it collapses." +
                "\n8. The game continues until you run out of HP or decide to quit." +
                "\n9. Your goal is to hold out as long as possible by solving problems and creating protective barriers!" +
                "\n10. The difficulty increases over time." +
                "\nGood luck and remember: speed and accuracy are the keys to victory!";
                title = "Rules of the game";
            }
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StartGame()
        {
            start_btn.Enabled = false;
            GameStarted = true;
            Barriers.Clear();
            Mines.Clear();
            player.SetDefault();
            math.SetDefault();
            refresh_timer.Start();
            mines_timer.Start();
            add_mine_timer.Start();
            Cmath_example_text.Text = math.CurrentMathProblem;
            AddMine();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            player_base_panel.Focus();
            StartGame();
        }

        private void Minus_btn_Click(object sender, EventArgs e)
        {
            player_base_panel.Focus();
            AddCharToAnswer("-");
        }

        private void AddMine()
        {
            if (Mines.Count <= 5)
            {
                int x = rand.Next(0, Field.Width - 10), y = 0;
                Mines.Add(new Mine(x, y));
            }
        }

        private void GameOver()
        {
            start_btn.Enabled = true;
            GameStarted = false;
            refresh_timer.Stop();
            mines_timer.Stop();
            add_mine_timer.Stop();
            if (player.MaxScore > MaxGameScore)
                MaxGameScore = player.MaxScore;
        }
    }
}