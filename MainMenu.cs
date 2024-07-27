using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Net;
using IniReader;
using System.IO;
using CGFReader;
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
        private readonly string current_version = "|0.4|";
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
        private bool update_exist = false, slil_opened = true, in_download = false;
        private ToolTip g, t;
        private readonly TextureCache textureCache = new TextureCache();
        public static CGF_Reader CGFReader;

        public MainMenu()
        {
            InitializeComponent();
            if (File.Exists("data.cgf"))
                CGFReader = new CGF_Reader("data.cgf");
            else
            {
                string title = "Отсутствует файл \"data.cgf\"!", message = $"Файл \"data.cgf\" отсутствует! Возможно, он был переименован, перемещен или удален. Хотите загрузить установщик еще раз?";
                if (!Check_Language())
                {
                    title = "Missing \"data.cgf\" file!";
                    message = $"The file \"data.cgf\" is missing! It may have been renamed, moved, or deleted. Do you want to download the installer again?";
                }
                if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    Hide();
                    WindowState = FormWindowState.Minimized;
                    Downloading _form = new Downloading
                    {
                        update = false,
                        language = Check_Language()
                    };
                    _form.ShowDialog();
                }
                else
                    Application.Exit();
            }
        }

        private void Check_Update(bool auto)
        {
            string title = "Доступно обновление!";
            string message = $"Вышло новое обновление! Хотите установить его?\n\n" +
                             $"Текущая версия: {current_version.Trim('|')}\n" +
                             $"Актуальная версия: ";
            string update_text = "\n\nСписок изменений:";

            if (!Check_Language())
            {
                title = "Update available!";
                message = $"New update is out! Want to install it?\n\n" +
                          $"Current version: {current_version.Trim('|')}\n" +
                          $"Actual version: ";
                update_text = "\n\nList of changes:";
            }
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
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
                        string[] lines = e.Result.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        if (lines.Length > 0 && !lines[0].Contains(current_version))
                        {
                            message += lines[0].Trim('|');
                            message += update_text;
                            bool isRussian = Check_Language();
                            for (int i = 1; i < lines.Length; i++)
                            {
                                string line = lines[i].Trim();
                                if (line.StartsWith("ru:"))
                                {
                                    if (isRussian)
                                        message += "\n• " + line.Substring(3);
                                }
                                else if (line.StartsWith("en:"))
                                {
                                    if (!isRussian)
                                        message += "\n• " + line.Substring(3);
                                }
                            }
                            if (update_exist || MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Hide();
                                in_download = true;
                                WindowState = FormWindowState.Minimized;
                                Downloading _form = new Downloading
                                {
                                    update = true,
                                    language = Check_Language()
                                };
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

        private void Bug_report_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://t.me/MiniGamesBugReport_BOT") { UseShellExecute = true });

        private void Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void GitHub_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });

        private void Websyte_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://base-escape.ru") { UseShellExecute = true });

        private void BugReport_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://t.me/+VLJzjVRg8ElkZWYy") { UseShellExecute = true });

        private void Qscvhu_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://t.me/Apsyuch") { UseShellExecute = true });

        private void Koyo_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://hipolink.me/koyomichu") { UseShellExecute = true });

        private void Fatalan_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://github.com/Fatalan") { UseShellExecute = true });

        private void Version_label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Change_list _form = new Change_list();
                _form.ShowDialog();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("sounds"))
                Directory.Delete("sounds", true);
            version_label.Text = $"v{current_version.Replace("|", "")} By.Lonewolf239";
            Language = Check_Language();
            CheckSLIL();
            INIReader.CreateIniFileIfNotExist(iniFolder);
            Language = INIReader.GetBool(iniFolder, "CONFIG", "language", Language);
            sounds = INIReader.GetBool(iniFolder, "CONFIG", "sounds", true);
            scale_size = INIReader.GetSingle(iniFolder, "CONFIG", "scale", 1);
            auto_update.Checked = INIReader.GetBool(iniFolder, "CONFIG", "auto_update", true);
            if (scale_size == 1.5f || scale_size == 2 || scale_size == 3)
                SetScale();
            else
                scale_size = 1;
            mg1_max_score = GetMaxScore("Colortimer");
            mg3_max_score = GetMaxScore("Math_o_light");
            mg4_max_score = GetMaxScore("Reactor");
            mg5_max_score = GetMaxScore("Rodrocket");
            mg6_max_score = GetMaxScore("Hacker_man");
            mg7_max_score = GetMaxScore("Snake_game");
            mg8_max_score = GetMaxScore("Soundotron");
            mg10_max_score = GetMaxScore("2048");
            mg13_max_score = GetMaxScore("Tetris");
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
                mg_panel_8.BackColor = Color.Gray;
            }
            else
            {
                mg_icon_pic8.BackgroundImage = null;
                mg_icon_pic8.Image = Properties.Resources.soundotron;
                mg_panel_8.BackColor = SystemColors.Control;
            }
        }

        private void CheckSLIL()
        {
            slil_opened = CheckWindows();
            if (!slil_opened)
            {
                mg_icon_pic15.BackgroundImage = Properties.Resources.labyrinth;
                mg_icon_pic15.Image = Properties.Resources._lock;
                mg_panel_15.BackColor = Color.Gray;
            }
        }

        private bool CheckWindows()
        {
            try
            {
                Version osVersion = Environment.OSVersion.Version;
                if (osVersion.Major >= 10 && osVersion.Build >= 10240)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private int GetMaxScore(string section)
        {
            double max_score = INIReader.GetDouble(iniFolder, section, "max_score");
            if ((max_score / 13) * 2 == Convert.ToInt32((max_score / 13) * 2))
                return (int)((max_score / 13) * 2);
            return 0;
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
            Control[] texts = { mg_name0, mg_name1, mg_name2, mg_name3, mg_name4, mg_name5, mg_name6, mg_name7, mg_name8, mg_name9, mg_name10, mg_name11, mg_name12, mg_name13, mg_name14, mg_name15 };
            int index;
            if (type)
            {
                index = 0;
                russian_check.Checked = true;
                english_check.Checked = false;
                mg_name1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
                mg_name3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
                settings.Text = "Настройки";
                sounds_on_off.Text = "Звуки";
                sounds_on_off.ToolTipText = "Включить/отключить внутриигровые звуки";
                about_mini_games.Text = "О приложении";
                language_menu.Text = "Язык";
                byLonewol239.Text = "О разработчиках";
                information.Text = "Информация";
                scale.Text = "Масштаб";
                clear_data.Text = "Стереть данные";
                exit.Text = "Выйти";
                update.Text = "Обновление";
                update_check.Text = "Проверить наличие";
                auto_update.Text = "Авто-обновление";
                bug_report.Text = "Сообщить об ошибке";
                slil_about.Text = "Лабезумие";
                fatalan.Text = "Текстурирование: Fatalan";
                qscvhu.Text = "Спрайты оружия: qscvhu";
                koyo.Text = "Спрайты врагов: koyo";
                if (update_exist)
                    update_check.Text = "Обновить игру";
            }
            else
            {
                index = 1;
                russian_check.Checked = false;
                english_check.Checked = true;
                mg_name1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                mg_name3.Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
                settings.Text = "Settings";
                sounds_on_off.Text = "Sounds";
                sounds_on_off.ToolTipText = "Enable/disable in-game sounds";
                about_mini_games.Text = "About the app";
                language_menu.Text = "Language";
                byLonewol239.Text = "About the developers";
                information.Text = "Info";
                scale.Text = "Scale";
                clear_data.Text = "Clear data";
                exit.Text = "Exit";
                update.Text = "Update";
                update_check.Text = "Check for update";
                auto_update.Text = "Auto-Update";
                bug_report.Text = "Bug Report";
                slil_about.Text = "Mazeness";
                fatalan.Text = "Texturing: Fatalan";
                qscvhu.Text = "Weapon sprites: qscvhu";
                koyo.Text = "Enemy sprites: koyo";
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
            INIReader.CreateIniFile(iniFolder);
            Application.Restart();
        }

        private void Sounds_on_off_Click(object sender, EventArgs e)
        {
            sounds = !sounds;
            if (!sounds)
            {
                mg_icon_pic8.BackgroundImage = Properties.Resources.soundotron;
                mg_icon_pic8.Image = Properties.Resources._lock;
                mg_panel_8.BackColor = Color.Gray;
            }
            else
            {
                mg_icon_pic8.BackgroundImage = null;
                mg_icon_pic8.Image =Properties.Resources.soundotron;
                mg_panel_8.BackColor = SystemColors.Control;
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
            if (!in_download)
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
                INIReader.SetKey(iniFolder, "Colortimer", "max_score", ((double)mg1_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "Math_o_light", "max_score", ((double)mg3_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "Reactor", "max_score", ((double)mg4_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "Rodrocket", "max_score", ((double)mg5_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "Hacker_man", "max_score", ((double)mg6_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "Snake_game", "max_score", ((double)mg7_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "Soundotron", "max_score", ((double)mg8_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "2048", "max_score", ((double)mg10_max_score / 2) * 13);
                INIReader.SetKey(iniFolder, "Tetris", "max_score", ((double)mg13_max_score / 2) * 13);
                Form form = sender as Form;
                form?.Dispose();
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                ShowIcon = true;
                Show();
                Refresh();
            }
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

        private void GameButton_MouseEnter(object sender, EventArgs e)
        {
            Control element = sender as Control;
            if (!sounds && (element == mg_name8 || element == mg_icon_pic8 || element == mg_panel_8))
                return;
            if (!slil_opened && (element == mg_name15 || element == mg_icon_pic15 || element == mg_panel_15))
            {
                string title = "Внимание", message = "Лабезумие доступно только на Windows 10 или более новых версиях Windows.\nПожалуйста, обновите вашу операционную систему.";
                if (!Language)
                {
                    title = "Attention";
                    message = "Mazeness is only available on Windows 10 or newer versions of Windows.\nPlease update your operating system.";
                }
                t = new ToolTip
                {
                    ToolTipTitle = title,
                    ToolTipIcon = ToolTipIcon.Warning
                };
                t.SetToolTip(element, message);
                return;
            }
            if (element is Panel)
            {
                Panel obj = element as Panel;
                obj.BorderStyle = BorderStyle.Fixed3D;
                obj.BackColor = Color.Gainsboro;
            }
            else
            {
                Control parent = element.Parent;
                Panel obj = parent as Panel;
                obj.BorderStyle = BorderStyle.Fixed3D;
                obj.BackColor = Color.Gainsboro;
            }
        }

        private void GameButton_MouseLeave(object sender, EventArgs e)
        {
            Control element = sender as Control;
            if (!sounds && (element == mg_name8 || element == mg_icon_pic8 || element == mg_panel_8))
                return;
            if (!slil_opened && (element == mg_name15 || element == mg_icon_pic15 || element == mg_panel_15))
            {
                t?.Dispose();
                return;
            }
            if (element is Panel)
            {
                Panel obj = element as Panel;
                obj.BorderStyle = BorderStyle.FixedSingle;
                obj.BackColor = SystemColors.Control;
            }
            else
            {
                Control parent = element.Parent;
                Panel obj = parent as Panel;
                obj.BorderStyle = BorderStyle.FixedSingle;
                obj.BackColor = SystemColors.Control;
            }
        }

        private void Mg_panel_0_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form1 form = new Form1();
                OpenGame(form, mg_panel_0);
            }
        }

        private void Mg_panel_1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ColorTimer form = new ColorTimer();
                OpenGame(form, mg_panel_1);
            }
        }

        private void Mg_panel_2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ColorTiles form = new ColorTiles();
                OpenGame(form, mg_panel_2);
            }
        }

        private void Mg_panel_3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MathOLight form = new MathOLight();
                OpenGame(form, mg_panel_3);
            }
        }

        private void Mg_panel_4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Reactor form = new Reactor();
                OpenGame(form, mg_panel_4);
            }
        }

        private void Mg_panel_5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RodRocket form = new RodRocket();
                OpenGame(form, mg_panel_5);
            }
        }

        private void Mg_panel_6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Hackerman form = new Hackerman();
                OpenGame(form, mg_panel_6);
            }
        }

        private void Mg_panel_7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SnakeGame form = new SnakeGame();
                OpenGame(form, mg_panel_7);
            }
        }

        private void Mg_panel_8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && sounds)
            {
                SoundoTron form = new SoundoTron();
                OpenGame(form, mg_panel_8);
            }
        }

        private void Mg_panel_9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Sudoku form = new Sudoku();
                OpenGame(form, mg_panel_9);
            }
        }

        private void Mg_panel_10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MG2048 form = new MG2048();
                OpenGame(form, mg_panel_10);
            }
        }

        private void Mg_panel_11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Ping_Pong form = new Ping_Pong();
                OpenGame(form, mg_panel_11);
            }
        }

        private void Mg_panel_12_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Tanks form = new Tanks();
                OpenGame(form, mg_panel_12);
            }
        }

        private void Mg_panel_13_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Tetris form = new Tetris();
                OpenGame(form, mg_panel_13);
            }
        }

        private void Mg_panel_14_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Sapper form = new Sapper();
                OpenGame(form, mg_panel_14);
            }
        }

        private void Mg_panel_15_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && slil_opened)
            {
                SLIL form = new SLIL(textureCache);
                OpenGame(form, mg_panel_15);
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
            if (egg == "FABRICA")
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