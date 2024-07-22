using IniReader;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._Tetris
{
    public partial class T_about : Form
    {
        public T_about()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                {
                    foreach (Control text1 in text.Controls)
                        text1.Font = new Font(text1.Font.FontFamily, text1.Font.Size * MainMenu.scale_size);
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
                }
                int centerX = Owner.Left + (Owner.Width - Width) / 2;
                int centerY = Owner.Top + (Owner.Height - Height) / 2;
                Location = new Point(centerX, centerY);
            }
            Activate();
            if (!MainMenu.Language)
            {
                Text = "Rules of the game";
                control_text.Text = "Controls:";
                control_space.Text = "To rotate the shape press: Space";
                rules_text.Text = "The goal of game is to manipulate the falling tetrominoes, which are made up of four blocks each. " +
                    "The player must position these tetrominoes to form a continuous horizontal line without gaps. " +
                    "When such a line is formed, it disappears, and the player earns points. " +
                    "The game continues until the tetrominoes reach the top of the playfield.";
                rules_text.Font = new Font("Microsoft Sans Serif", 13.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                difficult_text.Text = "Difficulty";
                difficult_list.Items.Clear();
                string[] dif = { "Easy", "Normal", "Hard" };
                difficult_list.Items.AddRange(dif);
            }
            ok.Left = (Width - ok.Width) / 2;
            difficult_list.SelectedIndex = Tetris.difficult_chooce;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Difficult_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tetris.difficult_chooce = difficult_list.SelectedIndex;
            INIReader.SetKey(MainMenu.iniFolder, "Tetris", "difficulty", difficult_list.SelectedIndex);
        }
    }
}