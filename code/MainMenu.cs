﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Net;
using IniReader;
using minigames.Colortimer;
using minigames.Colortiles;
using minigames.Math_o_light;
using minigames._Reactor;
using minigames.Rodrocket;
using minigames.Hacker_man;
using minigames.Snake_game;
using minigames.Soundotron;
using minigames._Fabric;
using minigames._Sudoku;
using minigames._2048;
using minigames._Ping_Pong;
using minigames._Tanks;
using minigames._Tetris;
using minigames._Sapper;
using minigames._SLIL;

namespace minigames
{
    public partial class MainMenu : Form
    {

        public static readonly string iniFolder = "config.ini";
        private readonly string current_version = "|0.2.3|";
        public static float scale_size = 1.0f;
        public static bool Language = false, sounds = true, scaled = false;
        public static int mg1_max_score = 0, mg3_max_score = 0, mg5_max_score = 0, mg6_max_score = 0, mg7_max_score = 0,
            mg8_max_score = 0, mg10_max_score = 0, mg13_max_score = 0;
        public static float mg4_max_score = 0;
        private readonly string[][] language_text =
        {
          new string[] { "Глазастик", "Секундоцвет", "Цветнашки", "Матемангнит", "Реактор", "Удочкомёт", "Хацкер", "Змейка", "Звукотрон", "СудоСага", "2048", "Пинг-Понг", "Танчики", "Тутрис", "Сапёр", "Лабезумие" },
          new string[] { "EyeStop", "ColorTimer", "ColorTiles", "Math-o-Light", "Reactor", "RodRocket", "Hackerman", "Snake", "Soundotron", "SudoSaga", "2048", "Ping-Pong", "Tanks", "Tetris", "Sapper", "Mazeness" }
        };
        private string default_config;
        private bool update_exist = false;
        private ToolTip g;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Check_Update(bool auto)
        {
            string title = "Доступно обновление!", message = $"Вышло новое обновление! Хотите установить его?\nТекущая версия: {current_version.Replace("|","")}\nАктуальная версия: ";
            if (!Check_Language())
            {
                title = "Update available!";
                message = $"New update is out! Want to install it?\nCurrent version: {current_version.Replace("|","")}\nActual version: ";
            }
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadStringCompleted += (sender, e) =>
                {
                    if (e.Error != null)
                    {
                        if (auto)
                        {
                            update_error.Visible = true;
                            update_check.Image = update_error.Image;
                        }
                        if (e.Error.HResult == -2146233079)
                        {
                            if (!auto)
                            {
                                message = "Не удалось установить соединение с сервером обновлений. Проверьте подключение к интернету.";
                                title = "Ошибка подключения";
                                if (!Language)
                                {
                                    message = "Failed to establish a connection with the update server. Please check your internet connection.";
                                    title = "Connection Error";
                                }
                                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (!auto)
                            {
                                message = $"Во время загрузки обновления произошла ошибка! {e.Error.Message}.";
                                title = $"Ошибка {e.Error.HResult}!";
                                if (!Language)
                                {
                                    message = $"An error occurred while downloading the update! {e.Error.Message}.";
                                    title = $"Error {e.Error.HResult}!";
                                }
                                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        update_error.Visible = false;
                        update_check.Image = null;
                        if (!e.Result.Contains(current_version))
                        {
                            message += e.Result.Replace("|", "");
                            if (update_exist || MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Hide();
                                WindowState = FormWindowState.Minimized;
                                Downloading _form = new Downloading();
                                Downloading.language = Check_Language();
                                _form.ShowDialog();
                            }
                            else
                            {
                                update_exist = update_error.Visible = true;
                                update_check.Image = update_error.Image;
                                update_check.Text = "Обновить Mini-Games";
                                if (!Language)
                                    update_check.Text = "Update the Mini-Games";
                            }
                        }
                        else
                        {
                            if (!auto)
                            {
                                if (Language)
                                    MessageBox.Show("У вас уже установлена последняя версия программы.", "Версия актуальная", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("You already have the latest version of the program installed.", "Version is current", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                };
                webClient.DownloadStringAsync(new Uri("https://base-escape.ru/version_MG.txt"));
            }
        }

        private void Update_check_Click(object sender, EventArgs e)
        {
            Check_Update(false);
        }

        private void Auto_update_CheckedChanged(object sender, EventArgs e)
        {
            INIReader.SetKey(iniFolder, "CONFIG", "auto_update", auto_update.Checked);
        }

        private void Update_error_MouseEnter(object sender, EventArgs e)
        {
            string title = "Внимание", message = "Не удалось проверить актуальность версии";
            if (!Language)
            {
                title = "Attention";
                message = "Failed to check the version's validity";
                if (update_exist)
                {
                    title = "Update available!";
                    message = "Please update the Mini-Games to the latest version";
                }
            }
            else
            {
                if (update_exist)
                {
                    title = "Доступно обновление!";
                    message = "Пожалуйства, обновите Mini-Games до актуальной версии";
                }
            }
            g = new ToolTip
            {
                ToolTipTitle = title,
                ToolTipIcon = ToolTipIcon.Warning
            };
            g.SetToolTip(update_error, message);
        }

        private void Update_error_MouseLeave(object sender, EventArgs e)
        {
            g.Dispose();
        }

        private bool Check_Language()
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string language = ci.Name.ToLower();
            string[] supportedLanguages = { "ru", "uk", "be", "kk", "ky" };
            return Array.Exists(supportedLanguages, lang => lang.Equals(language) || lang.Equals(language.Substring(0, 2)));
        }

        private void Bug_report_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/MiniGamesBugReport_BOT") { UseShellExecute = true });
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GitHub_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void Websyte_Click(object sender, EventArgs e)
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
            version_label.Text = $"v{current_version.Replace("|", "")} By.Lonewolf239";
            Language = Check_Language();
            default_config = $"[CONFIG]\nsounds = True\nlanguage = {Language}\nscale = 1\nauto_update = True\n[Glazastic]\ndifficulty = 1\nimpossible = False\nbig_speed = False\npractice_mode = False\nwin = 0\nlose = 0\ngames = 0\n[Colortimer]\nmax_score = 0\n[Math_o_light]\nmax_score = 0\n[Reactor]\nmax_score = 0\n[Rodrocket]\nmax_score = 0\n[Hacker_man]\nmax_score = 0\n[Snake_game]\nsize = 1\nspeed = 1\nstyle = 0\ndark_theme = 1\nwall_kills = False\nmax_score = 0\n[Soundotron]\nmax_score = 0\n[SudoSaga]\ndifficulty = 0\nprefill = True\ndeath_time = False\n[2048]\nmax_score = 0\n[FABRICA]\njump_key=W\nleft_key=A\nright_key=D\nshoot_key=Space\nrestart_key=R\npause_key=Pause\n[Tanks]\nup_pl1=W\ndown_pl1=S\nleft_pl1=A\nright_pl1=D\nshot_pl1=Space\nup_pl2=Up\ndown_pl2=Down\nleft_pl2=Left\nright_pl2=Right\nshot_pl2=Enter\n[Tetris]\nmax_score=0\ndifficulty=0";
            INIReader.CreateIniFileIfNotExist(iniFolder, default_config);
            Language = INIReader.GetBool(iniFolder, "CONFIG", "language", Language);
            sounds = INIReader.GetBool(iniFolder, "CONFIG", "sounds", true);
            scale_size = INIReader.GetSingle(iniFolder, "CONFIG", "scale", 1);
            auto_update.Checked = INIReader.GetBool(iniFolder, "CONFIG", "auto_update", true);
            if (scale_size == 1.5f || scale_size == 2 || scale_size == 3)
                SetScale();
            else
                scale_size = 1;
            mg1_max_score = INIReader.GetInt(iniFolder, "Colortimer", "max_score");
            mg3_max_score = INIReader.GetInt(iniFolder, "Math_o_light", "max_score");
            mg4_max_score = INIReader.GetSingle(iniFolder, "Reactor", "max_score");
            mg5_max_score = INIReader.GetInt(iniFolder, "Rodrocket", "max_score");
            mg6_max_score = INIReader.GetInt(iniFolder, "Hacker_man", "max_score");
            mg7_max_score = INIReader.GetInt(iniFolder, "Snake_game", "max_score");
            mg8_max_score = INIReader.GetInt(iniFolder, "Soundotron", "max_score");
            mg10_max_score = INIReader.GetInt(iniFolder, "2048", "max_score");
            mg13_max_score = INIReader.GetInt(iniFolder, "Tetris", "max_score");
            if (Language)
                russian_check.Checked = true;
            else
                Change_Language(false);
            if (auto_update.Checked)
                Check_Update(true);
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

        private void Original_Click(object sender, EventArgs e)
        {
            if (original.Checked)
            {
                scale_size = 1;
                INIReader.SetKey(iniFolder, "CONFIG", "scale", scale_size);
                O_o.Checked = anstapabal.Checked = big.Checked = scaled = false;
            }
            else
                original.Checked = true;
        }

        private void SetScale()
        {
            O_o.Checked = anstapabal.Checked = big.Checked = original.Checked = scaled = true;
            if (scale_size == 1.5f)
                O_o.Checked = anstapabal.Checked = original.Checked = false;
            else if (scale_size == 2)
                O_o.Checked = big.Checked = original.Checked = false;
            else if (scale_size == 3)
                anstapabal.Checked = big.Checked = original.Checked = false;
        }

        private void Big_Click(object sender, EventArgs e)
        {
            if (big.Checked)
            {
                scale_size = 1.5f;
                INIReader.SetKey(iniFolder, "CONFIG", "scale", scale_size);
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
                INIReader.SetKey(iniFolder, "CONFIG", "scale", scale_size);
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
                INIReader.SetKey(iniFolder, "CONFIG", "scale", scale_size);
                SetScale();
            }
            else
                O_o.Checked = true;
        }

        private void Change_Language(bool type)
        {
            INIReader.SetKey(iniFolder, "CONFIG", "language", Language);
            Control[] texts = { glazastic_name, mg_name1, mg_name2, mg_name3, mg_name4, mg_name5, mg_name6, mg_name7, mg_name8, mg_name9, mg_name10, mg_name11, mg_name12, mg_name13, mg_name14, mg_name15 };
            int index;
            if (type)
            {
                index = 0;
                russian_check.Checked = true;
                english_check.Checked = false;
                mg_name1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
                mg_name7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
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
                update.Text = "Обновление";
                update_check.Text = "Проверить наличие";
                auto_update.Text = "Авто-обновление";
                bug_report.Text = "Сообщить об ошибке";
                if (update_exist)
                    update_check.Text = "Обновить игру";
            }
            else
            {
                index = 1;
                russian_check.Checked = false;
                english_check.Checked = true;
                mg_name1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                mg_name7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
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
                update.Text = "Update";
                update_check.Text = "Check for update";
                auto_update.Text = "Auto-Update";
                bug_report.Text = "Bug Report";
                if (update_exist)
                    update_check.Text = "Update the game";
            }
            for (int i = 0; i < texts.Length; i++)
                texts[i].Text = language_text[index][i];
        }

        private void Clear_data_Click(object sender, EventArgs e)
        {
            Program.mutex.ReleaseMutex();
            Program.mutex.Dispose();
            INIReader.CreateIniFile(iniFolder, default_config);
            Application.Restart();
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
            INIReader.SetKey(iniFolder, "CONFIG", "sounds", sounds);
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

        private void GameClosing(object sender, EventArgs e)
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
            if (MG2048.score > mg10_max_score)
                mg10_max_score = MG2048.score;
            if (Tetris.score > mg13_max_score)
                mg13_max_score = Tetris.score;
            INIReader.SetKey(iniFolder, "Colortimer", "max_score", mg1_max_score);
            INIReader.SetKey(iniFolder, "Math_o_light", "max_score", mg3_max_score);
            INIReader.SetKey(iniFolder, "Reactor", "max_score", mg4_max_score);
            INIReader.SetKey(iniFolder, "Rodrocket", "max_score", mg5_max_score);
            INIReader.SetKey(iniFolder, "Hacker_man", "max_score", mg6_max_score);
            INIReader.SetKey(iniFolder, "Snake_game", "max_score", mg7_max_score);
            INIReader.SetKey(iniFolder, "Soundotron", "max_score", mg8_max_score);
            INIReader.SetKey(iniFolder, "2048", "max_score", mg10_max_score);
            INIReader.SetKey(iniFolder, "Tetris", "max_score", mg13_max_score);
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            ShowIcon = true;
            Show();
            Refresh();
        }

        private void OpenGame(Form form, Panel panel)
        {
            WindowState = FormWindowState.Minimized;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = SystemColors.Control;
            form.FormClosing += new FormClosingEventHandler(GameClosing);
            ShowInTaskbar = false;
            ShowIcon = false;
            Hide();
            form.ShowDialog();
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
                Form1 form = new Form1();
                OpenGame(form, glazastic_panel);
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
                ColorTimer form = new ColorTimer();
                OpenGame(form, mg_panel1);
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
                ColorTiles form = new ColorTiles();
                OpenGame(form, mg_panel2);
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
                MathOLight form = new MathOLight();
                OpenGame(form, mg_panel3);
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
                Reactor form = new Reactor();
                OpenGame(form, mg_panel4);
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
                RodRocket form = new RodRocket();
                OpenGame(form, mg_panel5);
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
                Hackerman form = new Hackerman();
                OpenGame(form, mg_panel6);
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
                SnakeGame form = new SnakeGame();
                OpenGame(form, mg_panel7);
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
                SoundoTron form = new SoundoTron();
                OpenGame(form, mg_panel8);
            }
        }

        //мини-игра 10: СудоСага
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
                Sudoku form = new Sudoku();
                OpenGame(form, mg_panel9);
            }
        }

        //мини-игра 11: 2048
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
                MG2048 form = new MG2048();
                OpenGame(form, mg_panel10);
            }
        }

        //мини-игра 12: Пинг-Понг
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
                Ping_Pong form = new Ping_Pong();
                OpenGame(form, mg_panel11);
            }
        }

        //мини-игра 13: Танчики
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
                Tanks form = new Tanks();
                OpenGame(form, mg_panel12);
            }
        }

        //мини-игра 14: Тетрис
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
                Tetris form = new Tetris();
                OpenGame(form, mg_panel13);
            }
        }

        //мини-игра 15: Сапёр
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
                //Sapper form = new Sapper();
                //OpenGame(form, mg_panel14);
            }
        }

        //мини-игра 16: Лабезумие
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
                SLIL form = new SLIL();
                OpenGame(form, mg_panel15);
            }
        }

        private string egg = "";
        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                string message = "Вы уверены, что хотите выйти из игры?", title = "Подтверждение выхода";
                if (!Language)
                {
                    message = "Are you sure you want to exit the game?";
                    title = "Exit confirmation";
                }
                if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();

            }
            if (e.KeyCode == Keys.Back)
            {
                egg = null;
                return;
            }
            egg += e.KeyCode;
            if (egg == "TANK")
            {
                TopMost = false;
                egg = null;
                test form = new test();
                form.ShowDialog();
                TopMost = true;
            }
            else if (egg == "FABRICA")
            {
                TopMost = false;
                egg = null;
                Fabric form = new Fabric();
                form.ShowDialog();
                TopMost = true;
            }
        }
    }
}