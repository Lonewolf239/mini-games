using IniReader;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._Sapper
{
    public partial class SP_settings : Form
    {
        public SP_settings()
        {
            InitializeComponent();
        }

        private void SP_settings_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
            }
            if (!MainMenu.Language)
            {
                Text = "Settings";
                field_size_text.Text = "Field size:";
                field_size_list.Left = field_size_text.Right + 6;
                Width = field_size_list.Right + 7 + 15;
            }
            int centerX = Owner.Left + (Owner.Width - Width) / 2;
            int centerY = Owner.Top + (Owner.Height - Height) / 2;
            Location = new Point(centerX, centerY);
            Activate();
            field_size_list.SelectedIndex = Sapper.size_type;
        }

        private void Field_size_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            field_size_text.Focus();
            Sapper.size_type = field_size_list.SelectedIndex;
        }

        private void SP_settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            INIReader.SetKey(MainMenu.iniFolder, "Sapper", "size_type", field_size_list.SelectedIndex);
        }

        private void SP_settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                Close();
        }
    }
}