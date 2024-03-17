using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using minigames.Colortimer;
using minigames.Colortiles;
using minigames.Math_o_light;
using minigames._Reactor;
using minigames.Rodrocket;
using minigames.Hacker_man;
using minigames.Snake_game;
using minigames.Soundotron;

namespace minigames
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public static bool Language = false, sounds = true;
        public static int mg1_max_score = 0, mg3_max_score = 0, mg5_max_score = 0, mg6_max_score = 0, mg7_max_score = 0,
            mg8_max_score = 0;
        public static float mg4_max_score = 0;

        private void Version_label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Process.Start(new ProcessStartInfo("https://github.com/Lonewolf239") { UseShellExecute = true });
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string language = ci.Name.ToLower();
            string[] supportedLanguages = { "ru", "uk", "be", "kk", "ky" };
            bool isSupportedLanguage = Array.Exists(supportedLanguages, lang => lang.Equals(language) || lang.Equals(language.Substring(0, 2)));
            if (isSupportedLanguage)
                Language = true;
            else
            {
                glazastic_name.Text = "EyeStop";
                mg_name1.Text = "ColorTimer";
                mg_name1.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                mg_name2.Text = "ColorTiles";
                mg_name3.Text = "Math-o-Light";
                mg_name4.Text = "Reactor";
                mg_name5.Text = "RodRocket";
                mg_name6.Text = "Hackerman";
                mg_name7.Text = "Mini-Snake";
                mg_name7.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                mg_name8.Text = "Soundotron";
            }
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
        }

        private void About_mini_games_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mini-Games — коллекция из 16 офлайн мини-игр, включающая в себя как стратегические головоломки, так и динамичные аркады. " +
                "Интуитивный интерфейс обеспечивает непринужденное погружение в игру, делая сборник идеальным для быстрого развлечения в любое время.", "О приложении", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //мини-игра 10:
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
                /*
                WindowState = FormWindowState.Minimized;
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel9.BorderStyle = BorderStyle.FixedSingle;
                mg_panel9.BackColor = SystemColors.Control;
                form.ShowDialog();
                */
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
                /*
                WindowState = FormWindowState.Minimized;
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel10.BorderStyle = BorderStyle.FixedSingle;
                mg_panel10.BackColor = SystemColors.Control;
                form.ShowDialog();
                */
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
                /*
                WindowState = FormWindowState.Minimized;
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel11.BorderStyle = BorderStyle.FixedSingle;
                mg_panel11.BackColor = SystemColors.Control;
                form.ShowDialog();
                */
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
                /*
                WindowState = FormWindowState.Minimized;
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel12.BorderStyle = BorderStyle.FixedSingle;
                mg_panel12.BackColor = SystemColors.Control;
                form.ShowDialog();
                */
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
                /*
                WindowState = FormWindowState.Minimized;
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel13.BorderStyle = BorderStyle.FixedSingle;
                mg_panel13.BackColor = SystemColors.Control;
                form.ShowDialog();
                */
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
                /*
                WindowState = FormWindowState.Minimized;
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel14.BorderStyle = BorderStyle.FixedSingle;
                mg_panel14.BackColor = SystemColors.Control;
                form.ShowDialog();
                */
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
                /*
                WindowState = FormWindowState.Minimized;
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel15.BorderStyle = BorderStyle.FixedSingle;
                mg_panel15.BackColor = SystemColors.Control;
                form.ShowDialog();
                */
            }
        }
    }
}