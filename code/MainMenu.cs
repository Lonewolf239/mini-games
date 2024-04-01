using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using minigames.Colortimer;
using minigames.Colortiles;
using minigames.Math_o_light;
using minigames._Reactor;
using minigames.Rodrocket;
using minigames.Hacker_man;
using minigames.Snake_game;
using minigames.Soundotron;
using minigames.Brainmove;

namespace minigames
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private SizeF originalScale = new SizeF(1.0f, 1.0f);
        public static float scale_size = 1.0f;
        public static bool Language = false, sounds = true, scaled = false;
        public static int mg1_max_score = 0, mg3_max_score = 0, mg5_max_score = 0, mg6_max_score = 0, mg7_max_score = 0,
            mg8_max_score = 0;
        public static float mg4_max_score = 0;
        private string[][] language_text =
        {
          new string[] { "Глазастик", "Секундоцвет", "Цветнашки", "Матемангнит", "Реактор", "Удочкомёт", "Хацкер", "Мини-Змейка", "Звукотрон", "Мозгодвиж", "soon...", "soon...", "soon...", "soon...", "soon...", "soon..." },
          new string[] { "EyeStop", "ColorTimer", "ColorTiles", "Math-o-Light", "Reactor", "RodRocket", "Hackerman", "Mini-Snake", "Soundotron", "Brainmove", "soon...", "soon...", "soon...", "soon...", "soon...", "soon..." }
        };

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GitHub_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void WebsyteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://base-escape.ru") { UseShellExecute = true });
        }

        private void BugReport_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/+VLJzjVRg8ElkZWYy") { UseShellExecute = true });
        }

        private void Version_label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                change_list _form = new change_list();
                _form.ShowDialog();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string language = ci.Name.ToLower();
            string[] supportedLanguages = { "ru", "uk", "be", "kk", "ky" };
            bool isSupportedLanguage = Array.Exists(supportedLanguages, lang => lang.Equals(language) || lang.Equals(language.Substring(0, 2)));
            if (!File.Exists("config.ini"))
            {
                string str = "[CONFIG]\nsounds=True\nlanguage=True\nscale=1\n[Glazastic]\ndifficulty=1\nimpossible=False\nbig_speed=False\npractice_mode=False\nwin=0\nlose=0\ngames=0\n[Colortimer]\nmax_score=0\n[Math_o_light]\nmax_score=0\n[Reactor]\nmax_score=0\n[Rodrocket]\nmax_score=0\n[Hacker_man]\nmax_score=0\n[Snake_game]\nsize=1\nspeed=1\nstyle=0\ndark_theme=1\nwall_kills=False\nmax_score=0\n[Soundotron]\nmax_score=0";
                File.WriteAllText("config.ini", str);
            }
            else
            {
                isSupportedLanguage = INIReader.GetBool("config.ini", "CONFIG", "language");
                sounds = INIReader.GetBool("config.ini", "CONFIG", "sounds");
                scale_size = INIReader.GetSingle("config.ini", "CONFIG", "scale");
                if (scale_size == 1.5f || scale_size == 2 || scale_size == 3)
                    SetScale();
                else
                    scale_size = 1;
                mg1_max_score = INIReader.GetInt("config.ini", "Colortimer", "max_score");
                mg3_max_score = INIReader.GetInt("config.ini", "Math_o_light", "max_score");
                mg4_max_score = INIReader.GetSingle("config.ini", "Reactor", "max_score");
                mg5_max_score = INIReader.GetInt("config.ini", "Rodrocket", "max_score");
                mg6_max_score = INIReader.GetInt("config.ini", "Hacker_man", "max_score");
                mg7_max_score = INIReader.GetInt("config.ini", "Snake_game", "max_score");
                mg8_max_score = INIReader.GetInt("config.ini", "Soundotron", "max_score");
            }
            if (isSupportedLanguage)
            {
                russian_check.Checked = true;
                Language = true;
            }
            else
                Change_Language(false);
            sounds_on_off.Checked = sounds;
            if (!sounds)
            {
                mg_icon_pic8.BackgroundImage = Properties.Resources.soundotron;
                mg_icon_pic8.Image = Properties.Resources._lock;
                mg_panel8.BackColor = Color.Gray;
            }
            else
            {
                mg_icon_pic8.BackgroundImage = null;
                mg_icon_pic8.Image = Properties.Resources.soundotron;
                mg_panel8.BackColor = SystemColors.Control;
            }
        }

        private void Russian_check_Click(object sender, EventArgs e)
        {
            Language = true;
            Change_Language(true);
        }

        private void English_check_Click(object sender, EventArgs e)
        {
            Language = false;
            Change_Language(false);
        }

        private void Text_Scale(bool return_text)
        {
            info_menu.Font = new Font(info_menu.Font.FontFamily, 9f * scale_size);
            foreach (Control panels in interface_panel.Controls)
            {
                foreach (Control text in panels.Controls)
                {
                    if (return_text)
                        text.Font = new Font(text.Font.FontFamily, 12f);
                    else
                        text.Font = new Font(text.Font.FontFamily, 9.75f * scale_size);
                }
            }
        }

        private void Return_Original()
        {
            Text_Scale(true);
            if (Language)
            {
                mg_name1.Font = new Font(mg_name1.Font.FontFamily, 9.75f);
                mg_name7.Font = new Font(mg_name7.Font.FontFamily, 9.75f);
            }
            mg_name3.Font = new Font(mg_name3.Font.FontFamily, 9.75f);
            Scale(new SizeF(1.0f / originalScale.Width, 1.0f / originalScale.Height));
            version_label.Font = new Font(version_label.Font.FontFamily, 8.25F);
            originalScale = new SizeF(1.0f, 1.0f);
            CenterScreen();
        }

        private void Original_Click(object sender, EventArgs e)
        {
            if (original.Checked)
            {
                scale_size = 1;
                INIReader.SetKey("config.ini", "CONFIG", "scale", Convert.ToString(scale_size));
                O_o.Checked = anstapabal.Checked = big.Checked = scaled = false;
                Return_Original();
            }
            else
                original.Checked = true;
        }

        private void SetScale()
        {
            Return_Original();
            O_o.Checked = anstapabal.Checked = big.Checked = original.Checked = scaled = true;
            Text_Scale(false);
            if (scale_size == 1.5f)
                O_o.Checked = anstapabal.Checked = original.Checked = false;
            else if (scale_size == 2)
                O_o.Checked = big.Checked = original.Checked = false;
            else if (scale_size == 3)
                anstapabal.Checked = big.Checked = original.Checked = false;
            version_label.Font = new Font(version_label.Font.FontFamily, version_label.Font.Size * scale_size);
            originalScale = new SizeF(originalScale.Width * scale_size, originalScale.Height * scale_size);
            Scale(new SizeF(scale_size, scale_size));
            CenterScreen();
        }

        private void Big_Click(object sender, EventArgs e)
        {
            if (big.Checked)
            {
                scale_size = 1.5f;
                INIReader.SetKey("config.ini", "CONFIG", "scale", Convert.ToString(scale_size));
                SetScale();
            }
            else
                big.Checked = true;
        }

        private void Anstapabal_Click(object sender, EventArgs e)
        {
            if (anstapabal.Checked)
            {
                scale_size = 2;
                INIReader.SetKey("config.ini", "CONFIG", "scale", Convert.ToString(scale_size));
                SetScale();
            }
            else
                anstapabal.Checked = true;
        }

        private void O_o_Click(object sender, EventArgs e)
        {
            if (O_o.Checked)
            {
                scale_size = 3;
                INIReader.SetKey("config.ini", "CONFIG", "scale", Convert.ToString(scale_size));
                SetScale();
            }
            else
                O_o.Checked = true;
        }

        private void CenterScreen()
        {
            Screen screen = Screen.FromPoint(Cursor.Position);
            int centerX = screen.Bounds.Left + (screen.Bounds.Width / 2);
            int centerY = screen.Bounds.Top + (screen.Bounds.Height / 2);
            Left = centerX - (Width / 2);
            Top = centerY - (Height / 2);
        }

        private void Change_Language(bool type)
        {
            INIReader.SetKey("config.ini", "CONFIG", "language", Convert.ToString(Language));
            Control[] texts = { glazastic_name, mg_name1, mg_name2, mg_name3, mg_name4, mg_name5, mg_name6, mg_name7, mg_name8, mg_name9, mg_name10, mg_name11, mg_name12, mg_name13, mg_name14, mg_name15 };
            int index;
            if (type)
            {
                index = 0;
                russian_check.Checked = true;
                english_check.Checked = false;
                mg_name1.Font = new Font("Microsoft Sans Serif", 9.75F * scale_size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                mg_name7.Font = new Font("Microsoft Sans Serif", 9.75F * scale_size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                settings.Text = "Настройки";
                sounds_on_off.Text = "Звуки";
                sounds_on_off.ToolTipText = "Включить/отключить внутриигровые звуки";
                about_mini_games.Text = "О приложении";
                language_menu.Text = "Язык";
                byLonewol239.Text = "О разработчике";
                information.Text = "Информация";
                scale.Text = "Масштаб";
                clear_data.Text = "Стереть данные";
                exit.Text = "Выйти";
            }
            else
            {
                index = 1;
                russian_check.Checked = false;
                english_check.Checked = true;
                mg_name1.Font = new Font("Microsoft Sans Serif", 12F * scale_size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                mg_name7.Font = new Font("Microsoft Sans Serif", 12F * scale_size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                settings.Text = "Settings";
                sounds_on_off.Text = "Sounds";
                sounds_on_off.ToolTipText = "Enable/disable in-game sounds";
                about_mini_games.Text = "About the app";
                language_menu.Text = "Language";
                byLonewol239.Text = "About the developer";
                information.Text = "Info";
                scale.Text = "Scale";
                clear_data.Text = "Clear data";
                exit.Text = "Exit";
            }
            for (int i = 0; i < texts.Length; i++)
                texts[i].Text = language_text[index][i];
        }

        private void Clear_data_Click(object sender, EventArgs e)
        {
            string str = "[CONFIG]\nsounds=True\nlanguage=True\nscale=1\n[Glazastic]\ndifficulty=1\nimpossible=False\nbig_speed=False\npractice_mode=False\nwin=0\nlose=0\ngames=0\n[Colortimer]\nmax_score=0\n[Math_o_light]\nmax_score=0\n[Reactor]\nmax_score=0\n[Rodrocket]\nmax_score=0\n[Hacker_man]\nmax_score=0\n[Snake_game]\nsize=1\nspeed=1\nstyle=0\ndark_theme=1\nwall_kills=False\nmax_score=0\n[Soundotron]\nmax_score=0";
            File.WriteAllText("config.ini", str);
            Application.Restart();
        }

        private void Game_Closing(object sender, EventArgs e)
        {
            if (ColorTimer.score > mg1_max_score)
                mg1_max_score = ColorTimer.score;
            if (MathOLight.score > mg3_max_score)
                mg3_max_score = MathOLight.score;
            if (Reactor.score > mg4_max_score)
                mg4_max_score = Reactor.score;
            if (RodRocket.score > mg5_max_score)
                mg5_max_score = RodRocket.score;
            if (Hackerman.score > mg6_max_score)
                mg6_max_score = Hackerman.score;
            if (SnakeGame.score > mg7_max_score)
                mg7_max_score = SnakeGame.score;
            if (SoundoTron.score > mg8_max_score)
                mg8_max_score = SoundoTron.score;
            INIReader.SetKey("config.ini", "Colortimer", "max_score", Convert.ToString(mg1_max_score));
            INIReader.SetKey("config.ini", "Math_o_light", "max_score", Convert.ToString(mg3_max_score));
            INIReader.SetKey("config.ini", "Reactor", "max_score", Convert.ToString(mg4_max_score));
            INIReader.SetKey("config.ini", "Rodrocket", "max_score", Convert.ToString(mg5_max_score));
            INIReader.SetKey("config.ini", "Hacker_man", "max_score", Convert.ToString(mg6_max_score));
            INIReader.SetKey("config.ini", "Snake_game", "max_score", Convert.ToString(mg7_max_score));
            INIReader.SetKey("config.ini", "Soundotron", "max_score", Convert.ToString(mg8_max_score));
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            ShowIcon = true;
            Show();
        }

        private void Sounds_on_off_Click(object sender, EventArgs e)
        {
            sounds = !sounds;
            if (!sounds)
            {
                mg_icon_pic8.BackgroundImage = Properties.Resources.soundotron;
                mg_icon_pic8.Image = Properties.Resources._lock;
                mg_panel8.BackColor = Color.Gray;
            }
            else
            {
                mg_icon_pic8.BackgroundImage = null;
                mg_icon_pic8.Image =Properties.Resources.soundotron;
                mg_panel8.BackColor = SystemColors.Control;
            }
            INIReader.SetKey("config.ini", "CONFIG", "sounds", Convert.ToString(sounds));
        }

        private void About_mini_games_Click(object sender, EventArgs e)
        {
            if (Language)
                MessageBox.Show("Mini-Games — коллекция из 16 офлайн мини-игр, включающая в себя как стратегические головоломки, так и динамичные аркады. " +
                    "Интуитивный интерфейс обеспечивает непринужденное погружение в игру, делая сборник идеальным для быстрого развлечения в любое время.", "О приложении", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Mini-Games is a collection of 16 offline mini-games, including both strategic puzzles and dynamic arcade games. " +
                    "The intuitive interface ensures effortless immersion, making the collection ideal for quick fun anytime.", "About the app", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //мини-игра 1: Глазастик
        private void Glazastic_panel_MouseEnter(object sender, EventArgs e)
        {
            glazastic_panel.BorderStyle = BorderStyle.Fixed3D;
            glazastic_panel.BackColor = Color.Gainsboro;
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
            glazastic_panel.BackColor = SystemColors.Control;
        }

        private void Glazastic_icon_pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                Form1 form = new Form1();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 2: Секундоцвет
        private void Mg_name1_MouseEnter(object sender, EventArgs e)
        {
            mg_panel1.BorderStyle = BorderStyle.Fixed3D;
            mg_panel1.BackColor = Color.Gainsboro;
        }

        private void Mg_name1_MouseLeave(object sender, EventArgs e)
        {
            mg_panel1.BorderStyle = BorderStyle.FixedSingle;
            mg_panel1.BackColor = SystemColors.Control;
        }

        private void Mg_name1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                ColorTimer form = new ColorTimer();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel1.BorderStyle = BorderStyle.FixedSingle;
                mg_panel1.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 3: Цветнашки
        private void Mg_name2_MouseEnter(object sender, EventArgs e)
        {
            mg_panel2.BorderStyle = BorderStyle.Fixed3D;
            mg_panel2.BackColor = Color.Gainsboro;
        }

        private void Mg_name2_MouseLeave(object sender, EventArgs e)
        {
            mg_panel2.BorderStyle = BorderStyle.FixedSingle;
            mg_panel2.BackColor = SystemColors.Control;
        }

        private void Mg_name2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                ColorTiles form = new ColorTiles();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel2.BorderStyle = BorderStyle.FixedSingle;
                mg_panel2.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 4: Матемагнит
        private void Mg_name3_MouseEnter(object sender, EventArgs e)
        {
            mg_panel3.BorderStyle = BorderStyle.Fixed3D;
            mg_panel3.BackColor = Color.Gainsboro;
        }

        private void Mg_name3_MouseLeave(object sender, EventArgs e)
        {
            mg_panel3.BorderStyle = BorderStyle.FixedSingle;
            mg_panel3.BackColor = SystemColors.Control;
        }

        private void Mg_name3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                MathOLight form = new MathOLight();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel3.BorderStyle = BorderStyle.FixedSingle;
                mg_panel3.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 5: Реактор
        private void Mg_name4_MouseEnter(object sender, EventArgs e)
        {
            mg_panel4.BorderStyle = BorderStyle.Fixed3D;
            mg_panel4.BackColor = Color.Gainsboro;
        }

        private void Mg_name4_MouseLeave(object sender, EventArgs e)
        {
            mg_panel4.BorderStyle = BorderStyle.FixedSingle;
            mg_panel4.BackColor = SystemColors.Control;
        }

        private void Mg_name4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                Reactor form = new Reactor();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel4.BorderStyle = BorderStyle.FixedSingle;
                mg_panel4.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 6: Удочкомёт
        private void Mg_name5_MouseEnter(object sender, EventArgs e)
        {
            mg_panel5.BorderStyle = BorderStyle.Fixed3D;
            mg_panel5.BackColor = Color.Gainsboro;
        }

        private void Mg_name5_MouseLeave(object sender, EventArgs e)
        {
            mg_panel5.BorderStyle = BorderStyle.FixedSingle;
            mg_panel5.BackColor = SystemColors.Control;
        }

        private void Mg_name5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                RodRocket form = new RodRocket();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel5.BorderStyle = BorderStyle.FixedSingle;
                mg_panel5.BackColor = SystemColors.Control;
                form.ShowDialog();   
            }
        }

        //мини-игра 7: Хацкер
        private void Mg_name6_MouseEnter(object sender, EventArgs e)
        {
            mg_panel6.BorderStyle = BorderStyle.Fixed3D;
            mg_panel6.BackColor = Color.Gainsboro;
        }

        private void Mg_name6_MouseLeave(object sender, EventArgs e)
        {
            mg_panel6.BorderStyle = BorderStyle.FixedSingle;
            mg_panel6.BackColor = SystemColors.Control;
        }

        private void Mg_name6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                Hackerman form = new Hackerman();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel6.BorderStyle = BorderStyle.FixedSingle;
                mg_panel6.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 8: Мини-Змейка
        private void Mg_name7_MouseEnter(object sender, EventArgs e)
        {
            mg_panel7.BorderStyle = BorderStyle.Fixed3D;
            mg_panel7.BackColor = Color.Gainsboro;
        }

        private void Mg_name7_MouseLeave(object sender, EventArgs e)
        {
            mg_panel7.BorderStyle = BorderStyle.FixedSingle;
            mg_panel7.BackColor = SystemColors.Control;
        }

        private void Mg_name7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                SnakeGame form = new SnakeGame();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel7.BorderStyle = BorderStyle.FixedSingle;
                mg_panel7.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 9: Звукотрон
        private void Mg_icon_pic8_MouseEnter(object sender, EventArgs e)
        {
            if (sounds)
            {
                mg_panel8.BorderStyle = BorderStyle.Fixed3D;
                mg_panel8.BackColor = Color.Gainsboro;
            }
        }

        private void Mg_icon_pic8_MouseLeave(object sender, EventArgs e)
        {
            if (sounds)
            {
                mg_panel8.BorderStyle = BorderStyle.FixedSingle;
                mg_panel8.BackColor = SystemColors.Control;
            }
        }

        private void Mg_icon_pic8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && sounds)
            {
                WindowState = FormWindowState.Minimized;
                SoundoTron form = new SoundoTron();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel8.BorderStyle = BorderStyle.FixedSingle;
                mg_panel8.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 10: Мозгодвиж
        private void Mg_name9_MouseEnter(object sender, EventArgs e)
        {
            mg_panel9.BorderStyle = BorderStyle.Fixed3D;
            mg_panel9.BackColor = Color.Gainsboro;
        }

        private void Mg_name9_MouseLeave(object sender, EventArgs e)
        {
            mg_panel9.BorderStyle = BorderStyle.FixedSingle;
            mg_panel9.BackColor = SystemColors.Control;
        }

        private void Mg_name9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
                BrainMove form = new BrainMove();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel9.BorderStyle = BorderStyle.FixedSingle;
                mg_panel9.BackColor = SystemColors.Control;
                form.ShowDialog();
            }
        }

        //мини-игра 11:
        private void Mg_icon_pic10_MouseEnter(object sender, EventArgs e)
        {
            mg_panel10.BorderStyle = BorderStyle.Fixed3D;
            mg_panel10.BackColor = Color.Gainsboro;
        }

        private void Mg_icon_pic10_MouseLeave(object sender, EventArgs e)
        {
            mg_panel10.BorderStyle = BorderStyle.FixedSingle;
            mg_panel10.BackColor = SystemColors.Control;
        }

        private void Mg_icon_pic10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //WindowState = FormWindowState.Minimized;
                //X form = new X();
                //form.FormClosing += new FormClosingEventHandler(Game_Closing);
                //ShowInTaskbar = false;
                //ShowIcon = false;
                //Hide();
                //mg_panel10.BorderStyle = BorderStyle.FixedSingle;
                //mg_panel10.BackColor = SystemColors.Control;
                //form.ShowDialog();
            }
        }

        //мини-игра 12:
        private void Mg_icon_pic11_MouseEnter(object sender, EventArgs e)
        {
            mg_panel11.BorderStyle = BorderStyle.Fixed3D;
            mg_panel11.BackColor = Color.Gainsboro;
        }

        private void Mg_icon_pic11_MouseLeave(object sender, EventArgs e)
        {
            mg_panel11.BorderStyle = BorderStyle.FixedSingle;
            mg_panel11.BackColor = SystemColors.Control;
        }

        private void Mg_icon_pic11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //WindowState = FormWindowState.Minimized;
                //X form = new X();
                //form.FormClosing += new FormClosingEventHandler(Game_Closing);
                //ShowInTaskbar = false;
                //ShowIcon = false;
                //Hide();
                //mg_panel11.BorderStyle = BorderStyle.FixedSingle;
                //mg_panel11.BackColor = SystemColors.Control;
                //form.ShowDialog();
            }
        }

        //мини-игра 13:
        private void Mg_icon_pic12_MouseEnter(object sender, EventArgs e)
        {
            mg_panel12.BorderStyle = BorderStyle.Fixed3D;
            mg_panel12.BackColor = Color.Gainsboro;
        }

        private void Mg_icon_pic12_MouseLeave(object sender, EventArgs e)
        {
            mg_panel12.BorderStyle = BorderStyle.FixedSingle;
            mg_panel12.BackColor = SystemColors.Control;
        }

        private void Mg_icon_pic12_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //WindowState = FormWindowState.Minimized;
                //X form = new X();
                //form.FormClosing += new FormClosingEventHandler(Game_Closing);
                //ShowInTaskbar = false;
                //ShowIcon = false;
                //Hide();
                //mg_panel12.BorderStyle = BorderStyle.FixedSingle;
                //mg_panel12.BackColor = SystemColors.Control;
                //form.ShowDialog();
            }
        }

        //мини-игра 14:
        private void Mg_name13_MouseEnter(object sender, EventArgs e)
        {
            mg_panel13.BorderStyle = BorderStyle.Fixed3D;
            mg_panel13.BackColor = Color.Gainsboro;
        }

        private void Mg_name13_MouseLeave(object sender, EventArgs e)
        {
            mg_panel13.BorderStyle = BorderStyle.FixedSingle;
            mg_panel13.BackColor = SystemColors.Control;
        }

        private void Mg_name13_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //WindowState = FormWindowState.Minimized;
                //X form = new X();
                //form.FormClosing += new FormClosingEventHandler(Game_Closing);
                //ShowInTaskbar = false;
                //ShowIcon = false;
                //Hide();
                //mg_panel13.BorderStyle = BorderStyle.FixedSingle;
                //mg_panel13.BackColor = SystemColors.Control;
                //form.ShowDialog();
            }
        }

        //мини-игра 15:
        private void Mg_icon_pic14_MouseEnter(object sender, EventArgs e)
        {
            mg_panel14.BorderStyle = BorderStyle.Fixed3D;
            mg_panel14.BackColor = Color.Gainsboro;
        }

        private void Mg_icon_pic14_MouseLeave(object sender, EventArgs e)
        {
            mg_panel14.BorderStyle = BorderStyle.FixedSingle;
            mg_panel14.BackColor = SystemColors.Control;
        }

        private void Mg_icon_pic14_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //WindowState = FormWindowState.Minimized;
                //X form = new X();
                //form.FormClosing += new FormClosingEventHandler(Game_Closing);
                //ShowInTaskbar = false;
                //ShowIcon = false;
                //Hide();
                //mg_panel14.BorderStyle = BorderStyle.FixedSingle;
                //mg_panel14.BackColor = SystemColors.Control;
                //form.ShowDialog();
            }
        }

        //мини-игра 16:
        private void Mg_name15_MouseEnter(object sender, EventArgs e)
        {
            mg_panel15.BorderStyle = BorderStyle.Fixed3D;
            mg_panel15.BackColor = Color.Gainsboro;
        }

        private void Mg_name15_MouseLeave(object sender, EventArgs e)
        {
            mg_panel15.BorderStyle = BorderStyle.FixedSingle;
            mg_panel15.BackColor = SystemColors.Control;
        }

        private void Mg_name15_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //WindowState = FormWindowState.Minimized;
                //X form = new X();
                //form.FormClosing += new FormClosingEventHandler(Game_Closing);
                //ShowInTaskbar = false;
                //ShowIcon = false;
                //Hide();
                //mg_panel15.BorderStyle = BorderStyle.FixedSingle;
                //mg_panel15.BackColor = SystemColors.Control;
                //form.ShowDialog();
            }
        }
    }
}