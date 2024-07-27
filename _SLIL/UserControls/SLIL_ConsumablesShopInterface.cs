﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._SLIL.UserControls
{
    public partial class SLIL_ConsumablesShopInterface : UserControl
    {
        public SLIL_ConsumablesShopInterface()
        {
            InitializeComponent();
        }

        public Item item;
        public int index = 0;
        public int width;
        public PlaySound buy;
        public PlaySound cant_pressed = new PlaySound(MainMenu.CGFReader.GetFile("cant_pressed.wav"), false);
        public Player player;
        public Gun[] GUNS;
        private readonly string[,] buy_text = { { "Купить", "Buy" }, { "Уже есть", "Has already" } };

        private void SLIL_ConsumablesShopInterface_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
            }
        }

        private void SLIL_ConsumablesShopInterface_VisibleChanged(object sender, EventArgs e)
        {
            Width = width;
            icon.Image = item.Icon[0];
            descryption.Text = item.Description[index];
            name.Text = item.Name[index];
            if (!item.HasIt)
                buy_button.Text = $"{buy_text[0, index]} {item.GunCost}$";
            else
                buy_button.Text = $"{buy_text[1, index]}";
        }

        private void GetFirstAidKit()
        {
            if (player.FirstAidKits.Count == 0)
                player.FirstAidKits.Add((FirstAidKit)GUNS[10]);
            player.FirstAidKits[0].AmmoCount = player.FirstAidKits[0].CartridgesClip;
            player.FirstAidKits[0].MaxAmmoCount = player.FirstAidKits[0].CartridgesClip;
            player.FirstAidKits[0].HasIt = true;
        }

        private void Buy_button_Click(object sender, EventArgs e)
        {
            icon.Focus();
            if (player.Money >= item.GunCost && !item.HasIt)
            {
                if (MainMenu.sounds)
                    buy.Play(SLIL.Volume);
                player.ChangeMoney(-item.GunCost);
                buy_button.Text = $"{buy_text[1, index]}";
                if (item is FirstAidKit)
                    GetFirstAidKit();
            }
            else if (MainMenu.sounds)
                cant_pressed?.Play(SLIL.Volume);
        }
    }
}