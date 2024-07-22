using System;
using System.Windows.Forms;

namespace minigames._Ping_Pong
{
    public partial class PP_Info : Form
    {
        public PP_Info()
        {
            InitializeComponent();
        }

        private void PP_Info_Load(object sender, EventArgs e)
        {
            if (!MainMenu.Language)
            {
                Text = "Rules of the game";
                control_text.Text = "Control:";
                pause_text.Text = "To pause, press: SPACE";
                rules_text.Text = "The goal is to score the ball into the opponent's goal. " +
                    "The winner is the player who is the first to score a given number of points. " +
                    "After each bounce, the speed of the ball increases. " +
                    "The current ball speed is displayed by a progress bar.";
            }
            ok.Left = (Width - ok.Width) / 2;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
