using System;
using System.Windows.Forms;

namespace minigames._SLIL
{
    public partial class SLIL_about : Form
    {
        public SLIL_about()
        {
            InitializeComponent();
        }

        private void SLIL_about_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
            {
                Text = "About game";
                control_text.Text = "Controls:";
                control_space.Text = "F11 – full screen mode\n" +
                    "F12 - take a screenshot\n" +
                    "ESC – stop the game/exit the game\n" +
                    "WASD / arrows – movement\n" +
                    "Mouse - camera control\n" +
                    "E / Enter – interaction with doors\n" +
                    "M / Tab / Space – show/hide map\n" +
                    "B – open/close the store (you can also use ESC to close)\n" +
                    "F – take out/remove the flashlight\n" +
                    "H – use first aid kit\n" +
                    "Shift (hold) – run\n" +
                    "Left mouse button – shooting\n" +
                    "Right mouse button – aiming mode\n" +
                    "1-8 / mouse wheel – change weapons";
                difficulty_title.Text = "Difficulty:";
                difficulty_about.Text = "Easy:\n" +
                    "Starting weapon: Pistol Lv2\n" +
                    "Enemies drop more money\n" +
                    "\nNormal:\n" +
                    "Starting weapon: Pistol Lv2\n" +
                    "\nHard:\n" +
                    "Starting weapon: Pistol Lv1\n" +
                    "Enemies respawn every 60 sec.\n" +
                    "\nVery hard:\n" +
                    "Starting weapon: Pistol Lv1\n" +
                    "Enemies respawn every 60 sec.\n" +
                    "Enemies are more aggressive";
                rules_text.Text = "The goal of the game is to go through a randomly generated maze within a certain time.";
            }
            ok.Left = (Width - ok.Width) / 2;
            Activate();
        }

        private void Ok_Click(object sender, EventArgs e) => Close();
    }
}