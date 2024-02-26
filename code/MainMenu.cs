using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using minigames.Colortimer;

namespace minigames
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public static bool Language = false;
        public static int mg1_max_score = 0;

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
                mg_name1.Text = "Colortimer";
                mg_name1.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }

        private void Game_Closing(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            ShowIcon = true;
            Show();
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
            glazastic_panel.BackColor = Color.White;
        }

        private void Glazastic_icon_pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form1 form = new Form1();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
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
            mg_panel1.BackColor = Color.White;
        }

        private void Mg_name1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ColorTimer form = new ColorTimer();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                mg_panel1.BorderStyle = BorderStyle.FixedSingle;
                mg_panel1.BackColor = Color.White;
                form.ShowDialog();
            }
        }

        //мини-игра 3:
        private void Mg_name2_MouseEnter(object sender, EventArgs e)
        {
            mg_panel2.BorderStyle = BorderStyle.Fixed3D;
            mg_panel2.BackColor = Color.Gainsboro;
        }

        private void Mg_name2_MouseLeave(object sender, EventArgs e)
        {
            mg_panel2.BorderStyle = BorderStyle.FixedSingle;
            mg_panel2.BackColor = Color.White;
        }

        private void Mg_name2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
            }
        }

        //мини-игра 4:
        private void Mg_name3_MouseEnter(object sender, EventArgs e)
        {
            mg_panel3.BorderStyle = BorderStyle.Fixed3D;
            mg_panel3.BackColor = Color.Gainsboro;
        }

        private void Mg_name3_MouseLeave(object sender, EventArgs e)
        {
            mg_panel3.BorderStyle = BorderStyle.FixedSingle;
            mg_panel3.BackColor = Color.White;
        }

        private void Mg_name3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
            }
        }

        //мини-игра 5:
        private void Mg_name4_MouseEnter(object sender, EventArgs e)
        {
            mg_panel4.BorderStyle = BorderStyle.Fixed3D;
            mg_panel4.BackColor = Color.Gainsboro;
        }

        private void Mg_name4_MouseLeave(object sender, EventArgs e)
        {
            mg_panel4.BorderStyle = BorderStyle.FixedSingle;
            mg_panel4.BackColor = Color.White;
        }

        private void Mg_name4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
            }
        }

        //мини-игра 6:
        private void Mg_name5_MouseEnter(object sender, EventArgs e)
        {
            mg_panel5.BorderStyle = BorderStyle.Fixed3D;
            mg_panel5.BackColor = Color.Gainsboro;
        }

        private void Mg_name5_MouseLeave(object sender, EventArgs e)
        {
            mg_panel5.BorderStyle = BorderStyle.FixedSingle;
            mg_panel5.BackColor = Color.White;
        }

        private void Mg_name5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
            }
        }

        //мини-игра 7:
        private void Mg_name6_MouseEnter(object sender, EventArgs e)
        {
            mg_panel6.BorderStyle = BorderStyle.Fixed3D;
            mg_panel6.BackColor = Color.Gainsboro;
        }

        private void Mg_name6_MouseLeave(object sender, EventArgs e)
        {
            mg_panel6.BorderStyle = BorderStyle.FixedSingle;
            mg_panel6.BackColor = Color.White;
        }

        private void Mg_name6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
            }
        }

        //мини-игра 8:
        private void Mg_name7_MouseEnter(object sender, EventArgs e)
        {
            mg_panel7.BorderStyle = BorderStyle.Fixed3D;
            mg_panel7.BackColor = Color.Gainsboro;
        }

        private void Mg_name7_MouseLeave(object sender, EventArgs e)
        {
            mg_panel7.BorderStyle = BorderStyle.FixedSingle;
            mg_panel7.BackColor = Color.White;
        }

        private void Mg_name7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
            }
        }

        //мини-игра 9:
        private void Mg_icon_pic8_MouseEnter(object sender, EventArgs e)
        {
            mg_panel8.BorderStyle = BorderStyle.Fixed3D;
            mg_panel8.BackColor = Color.Gainsboro;
        }

        private void Mg_icon_pic8_MouseLeave(object sender, EventArgs e)
        {
            mg_panel8.BorderStyle = BorderStyle.FixedSingle;
            mg_panel8.BackColor = Color.White;
        }

        private void Mg_icon_pic8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
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
            mg_panel9.BackColor = Color.White;
        }

        private void Mg_name9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
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
            mg_panel10.BackColor = Color.White;
        }

        private void Mg_icon_pic10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
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
            mg_panel11.BackColor = Color.White;
        }

        private void Mg_icon_pic11_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
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
            mg_panel12.BackColor = Color.White;
        }

        private void Mg_icon_pic12_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
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
            mg_panel13.BackColor = Color.White;
        }

        private void Mg_name13_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
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
            mg_panel14.BackColor = Color.White;
        }

        private void Mg_icon_pic14_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
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
            mg_panel15.BackColor = Color.White;
        }

        private void Mg_name15_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*
                X form = new X();
                form.FormClosing += new FormClosingEventHandler(Game_Closing);
                ShowInTaskbar = false;
                ShowIcon = false;
                Hide();
                glazastic_panel.BorderStyle = BorderStyle.FixedSingle;
                glazastic_panel.BackColor = Color.White;
                form.ShowDialog();
                */
            }
        }
    }
}