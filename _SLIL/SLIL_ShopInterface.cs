﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace minigames._SLIL
{
    public partial class SLIL_ShopInterface : UserControl
    {
        public SLIL_ShopInterface()
        {
            InitializeComponent();
        }

        public Gun weapon;
        public int index = 0;
        public int width;
        public PlaySound buy;
        public PlaySound cant_pressed = new PlaySound(MainMenu.CGFReader.GetFile("cant_pressed.wav"), false);
        public Player player;
        private readonly string[,] buy_text = { { "Купить оружие", "Купить патроны" }, { "Buy weapons", "Buy ammo" } };

        private void SLIL_ShopInterface_Load(object sender, EventArgs e)
        {
            if (MainMenu.scaled)
            {
                Scale(new SizeF(MainMenu.scale_size, MainMenu.scale_size));
                foreach (Control text in Controls)
                    text.Font = new Font(text.Font.FontFamily, text.Font.Size * MainMenu.scale_size);
            }
        }

        private void Buy_button_Click(object sender, EventArgs e)
        {
            weapon_icon.Focus();
            if (weapon.HasIt)
            {
                if (player.Money >= weapon.AmmoCost && weapon.MaxAmmoCount + weapon.AmmoCount <= weapon.MaxAmmo)
                {
                    if (MainMenu.sounds)
                        buy.Play(SLIL.Volume);
                    player.ChangeMoney(-weapon.AmmoCost);
                    weapon.MaxAmmoCount += weapon.CartridgesClip;
                    ammo_count.Text = index == 0 ? $"Патроны: {weapon.MaxAmmoCount}/{weapon.AmmoCount}" : $"Ammo: {weapon.MaxAmmoCount}/{weapon.AmmoCount}";
                }
                else if (MainMenu.sounds)
                    cant_pressed?.Play(SLIL.Volume);
            }
            else
            {
                if (player.Money  >= weapon.GunCost)
                {
                    if (MainMenu.sounds)
                        buy.Play(SLIL.Volume);
                    player.ChangeMoney(-weapon.GunCost);
                    weapon.SetDefault();
                    player.Guns.Add(weapon);
                    weapon.HasIt = true;
                    buy_button.Text = buy_text[index, weapon.HasIt ? 1 : 0] + $" ${weapon.AmmoCost}";
                    ammo_count.Text = index == 0 ? $"Патроны: {weapon.MaxAmmoCount}/{weapon.AmmoCount}" : $"Ammo: {weapon.MaxAmmoCount}/{weapon.AmmoCount}";
                    update_button.Left = buy_button.Right + 6;
                    update_button.Visible = !(weapon is SniperRifle);
                }
                else if (MainMenu.sounds)
                    cant_pressed?.Play(SLIL.Volume);
            }
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            weapon_icon.Focus();
            if (player.Money  >= weapon.UpdateCost)
            {
                if (MainMenu.sounds)
                    buy.Play(SLIL.Volume);
                player.ChangeMoney(-weapon.UpdateCost);
                weapon.LevelUpdate();
                player.LevelUpdated = true;
                weapon_name.Text = weapon.Name[index] + $" {weapon.Level}";
                weapon_icon.Image = weapon.Icon[weapon.GetLevel()];
                update_button.Text = $"${weapon.UpdateCost}";
                damage_text.Text = index == 0 ? $"Урон: {weapon.MinDamage}-{weapon.MaxDamage}" : $"Damage: {weapon.MinDamage}-{weapon.MaxDamage}";
                ammo_count.Text = index == 0 ? $"Патроны: {weapon.MaxAmmoCount}/{weapon.AmmoCount}" : $"Ammo: {weapon.MaxAmmoCount}/{weapon.AmmoCount}";
                ammo_count.Left = damage_text.Right;
                update_button.Visible = weapon.CanUpdate();
            }
            else if (MainMenu.sounds)
                cant_pressed?.Play(SLIL.Volume);
        }

        private void SLIL_ShopInterface_VisibleChanged(object sender, EventArgs e)
        {
            int cost = weapon.HasIt ? weapon.AmmoCost : weapon.GunCost;
            string ammo = weapon.HasIt ? $"{weapon.MaxAmmoCount}/{weapon.AmmoCount}" : "0/0";
            weapon_name.Text = !(weapon is SniperRifle) ? weapon.Name[index] + $" {weapon.Level}" : weapon.Name[index];
            weapon_icon.Image = weapon.Icon[weapon.GetLevel()];
            ammo_count.Text = index == 0 ? $"Патроны: {ammo}" : $"Ammo: {ammo}";
            buy_button.Text = buy_text[index, weapon.HasIt ? 1 : 0] + $" ${cost}";
            update_button.Text = $"${weapon.UpdateCost}";
            damage_text.Text = index == 0 ? $"Урон: {weapon.MinDamage}-{weapon.MaxDamage}" : $"Damage: {weapon.MinDamage}-{weapon.MaxDamage}";
            ammo_count.Left = damage_text.Right;
            update_button.Left = buy_button.Right + 6;
            update_button.Visible = weapon.CanUpdate() && weapon.HasIt && !(weapon is SniperRifle);
            Width = width;
        }
    }
}