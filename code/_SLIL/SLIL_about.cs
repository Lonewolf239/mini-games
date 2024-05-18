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
                Text = "Rules of the game";
                control_text.Text = "Controls:";
                control_space.Text = "To open the map, press Space \\ Tab \\ M\nTo stop the game, press: ESC";
                rules_text.Text = "The goal of the game is to go through a randomly generated maze within a certain time.";
            }
            ok.Left = (Width - ok.Width) / 2;
            Activate();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
