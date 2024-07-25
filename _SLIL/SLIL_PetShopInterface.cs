using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._SLIL
{
    public partial class SLIL_PetShopInterface : UserControl
    {
        public SLIL_PetShopInterface()
        {
            InitializeComponent();
        }

        public Pet pet;
        public int index = 0;
        public int width;
        public PlaySound buy;
        public PlaySound cant_pressed = new PlaySound(MainMenu.CGFReader.GetFile("cant_pressed.wav"), false);
        public Player player;
        private readonly string[,] buy_text = { { "Купить", "Buy" }, { "Недоступно", "Not available" } };

        private void SLIL_PetShopInterface_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
            }
        }

        private void SLIL_PetShopInterface_VisibleChanged(object sender, EventArgs e)
        {
            Width = width;
            name.Text = pet.Name[index];
            icon.Image = pet.ShopIcon;
            descryption.Text = pet.Descryption[index];
            descryption.Width = Width - descryption.Left - 20;
            if (player.PET == null)
                buy_button.Text = $"{buy_text[0, index]} ${pet.Cost}";
            else
                buy_button.Text = $"{buy_text[1, index]}";
        }

        private void Buy_button_Click(object sender, EventArgs e)
        {
            icon.Focus();
            if (player.PET == null && player.Money >= pet.Cost)
            {
                if (MainMenu.sounds)
                    buy.Play(SLIL.Volume);
                player.ChangeMoney(-pet.Cost);
                (Parent.FindForm() as SLIL).AddPet(pet.Index);
            }
            else
            {
                if (MainMenu.sounds)
                    cant_pressed?.Play(SLIL.Volume);
            }
        }

        private void SLIL_PetShopInterface_SizeChanged(object sender, EventArgs e) => descryption.Width = Width - descryption.Left - 20;
    }
}