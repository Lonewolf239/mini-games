using System.Drawing;

namespace minigames._SLIL
{
    public enum GunTypes { Pistol, Shotgun, SMG, Rifle, Sniper, EasterEgg, Tank }
    public enum FireTypes { Single, SemiAutomatic }
    public enum Levels { LV1 = 0, LV2 = 1, LV3 = 2 }

    public class Gun
    {
        public string[] Name { get; set; }
        public int RechargeTime { get; set; }
        public int MaxAmmoCount { get; set; }
        public int CartridgesClip { get; set; }
        public int AmmoCount { get; set; }
        public int FiringRange { get; set; }
        public int FiringRate { get; set; }
        public int BurstShots { get; set; }
        public double MaxDamage { get; set; }
        public double MinDamage { get; set; }
        public int Recoil { get; set; }
        public bool HasIt { get; set; }
        public int GunCost { get; set; }
        public int AmmoCost { get; set; }
        public int UpdateCost { get; set; }
        public int MaxAmmo { get; set; }
        public int RadiusSound { get; set; }
        public int ReloadFrames { get; set; }
        public GunTypes GunType { get; set; }
        public FireTypes FireType { get; set; }
        public Levels Level { get; set; }
        public Image[] Icon { get; set; }
        public Image[,] Images { get; set; }
        public PlaySound[,] Sounds { get; set; }
        private int Type { get; set; }

        public Gun(int type)
        {
            Type = type;
            if (Type == 0)
            {
                HasIt = true;
                Name = new[] { "Пистолет", "Pistol" };
                GunType = GunTypes.Pistol;
                FireType = FireTypes.Single;
                UpdateCost = 20;
                AmmoCost = 4;
                RechargeTime = 600;
                CartridgesClip = 8;
                MaxAmmoCount = CartridgesClip * 3;
                MaxAmmo = CartridgesClip * 6;
                FiringRange = 7;
                MaxDamage = 1.75;
                MinDamage = 1.25;
                Recoil = 10;
                FiringRate = 175;
                BurstShots = 1;
                RadiusSound = 6;
                ReloadFrames = 1;
                Icon = new[]
                {
                    /*LV1:*/ Properties.Resources.gun_1_1_icon,
                    /*LV1:*/ Properties.Resources.gun_1_2_icon,
                    /*LV1:*/ Properties.Resources.gun_1_3_icon
                };
                Images = new[,]
                {                    
                   /*LV1:*/ { Properties.Resources.gun_1_1, Properties.Resources.gun_1_1_shooted, Properties.Resources.gun_1_1_reload, Properties.Resources.gun_1_1_reload, Properties.Resources.gun_1_1, Properties.Resources.gun_1_1_run },
                   /*LV2:*/ { Properties.Resources.gun_1_2, Properties.Resources.gun_1_2_shooted, Properties.Resources.gun_1_2_reload, Properties.Resources.gun_1_2_reload_empty, Properties.Resources.gun_1_2_empty, Properties.Resources.gun_1_2_run },
                   /*LV2:*/ { Properties.Resources.gun_1_3, Properties.Resources.gun_1_3_shooted, Properties.Resources.gun_1_3_1_reload, Properties.Resources.gun_1_3_2_reload, Properties.Resources.gun_1_3, Properties.Resources.gun_1_3_run },
                };
                Sounds = new[,]
                {
                   /*LV1:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_0_1.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_0_2_reloading.wav")), new PlaySound(null) },
                   /*LV2:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_0_2.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_0_2_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_0_empty.wav")) },
                   /*LV2:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_0_3.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_0_3_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_0_3_empty.wav")) },
                };
            }
            else if (Type == 1)
            {
                Name = new[] { "Дробовик", "Shotgun" };
                GunType = GunTypes.Shotgun;
                FireType = FireTypes.Single;
                UpdateCost = 25;
                GunCost = 30;
                AmmoCost = 10;
                RechargeTime = 425;
                CartridgesClip = 2;
                MaxAmmoCount = CartridgesClip;
                MaxAmmo = CartridgesClip * 10;
                FiringRange = 4;
                MaxDamage = 3.5;
                MinDamage = 2.75;
                Recoil = 120;
                FiringRate = 200;
                BurstShots = 1;
                RadiusSound = 10;
                ReloadFrames = 2;
                Icon = new[]
                {
                    /*LV1:*/ Properties.Resources.gun_0_0_icon,
                    /*LV2:*/ Properties.Resources.gun_0_1_icon,
                    /*LV3:*/ Properties.Resources.gun_0_2_icon,
                };
                Images = new[,]
                {
                    /*LV1:*/ { Properties.Resources.gun_0_0, Properties.Resources.gun_0_0_shooted, Properties.Resources.gun_0_0_1_reload, Properties.Resources.gun_0_0_2_reload, Properties.Resources.gun_0_0_2_reload, Properties.Resources.gun_0_0_run },
                    /*LV2:*/ { Properties.Resources.gun_0_1, Properties.Resources.gun_0_1_shooted, Properties.Resources.gun_0_1_pump, Properties.Resources.gun_0_1_1_reload, Properties.Resources.gun_0_1_2_reload, Properties.Resources.gun_0_1_run },
                    /*LV3:*/ { Properties.Resources.gun_0_2, Properties.Resources.gun_0_2_shooted, Properties.Resources.gun_0_2_pump, Properties.Resources.gun_0_2_1_reload, Properties.Resources.gun_0_2_2_reload, Properties.Resources.gun_0_2_run },
                };
                Sounds = new[,]
                {
                    /*LV1:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_1.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_1_0_reloading.wav")), new PlaySound(null), new PlaySound(null) },
                    /*LV2:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_1.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_1_1_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_1_empty.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_1_shell.wav")) },
                    /*LV3:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_1.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_1_2_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_1_empty.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_1_shell.wav")) },
                };
            }
            else if (Type == 2)
            {
                Name = new[] { "Пистолет-пулемет", "Submachine gun" };
                GunType = GunTypes.SMG;
                FireType = FireTypes.SemiAutomatic;
                UpdateCost = 30;
                GunCost = 26;
                AmmoCost = 16;
                RechargeTime = 375;
                CartridgesClip = 18;
                MaxAmmoCount = CartridgesClip * 3;
                MaxAmmo = CartridgesClip * 3;
                FiringRange = 8;
                MaxDamage = 2;
                MinDamage = 1.5;
                Recoil = 35;
                FiringRate = 50;
                BurstShots = 6;
                RadiusSound = 6;
                ReloadFrames = 2;
                Icon = new[]
                {
                    /*LV1:*/ Properties.Resources.gun_3_1_icon,
                    /*LV2:*/ Properties.Resources.gun_3_2_icon,
                    /*LV3:*/ Properties.Resources.gun_3_3_icon,
                };
                Images = new[,]
                {
                    /*LV1:*/ { Properties.Resources.gun_3_1, Properties.Resources.gun_3_1_shooted, Properties.Resources.gun_3_1_1_reload, Properties.Resources.gun_3_1_2_reload, Properties.Resources.gun_3_1_run},
                    /*LV2:*/ { Properties.Resources.gun_3_2, Properties.Resources.gun_3_2_shooted, Properties.Resources.gun_3_2_1_reload, Properties.Resources.gun_3_2_2_reload, Properties.Resources.gun_3_2_run },
                    /*LV3:*/ { Properties.Resources.gun_3_3, Properties.Resources.gun_3_3_shooted, Properties.Resources.gun_3_3_1_reload, Properties.Resources.gun_3_3_2_reload, Properties.Resources.gun_3_3_run }
                };
                Sounds = new[,]
                {
                    /*LV1:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_3_1.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_3_1_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_3_empty.wav")) },
                    /*LV2:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_3_2.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_3_2_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_3_empty.wav")) },
                    /*LV3:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_3_3.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_3_3_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_3_empty.wav")) }
                };
            }
            else if (Type == 3)
            {
                Name = new[] { "Автомат", "Assault rifle" };
                GunType = GunTypes.Rifle;
                FireType = FireTypes.SemiAutomatic;
                UpdateCost = 35;
                GunCost = 38;
                AmmoCost = 20;
                RechargeTime = 700;
                CartridgesClip = 24;
                MaxAmmoCount = CartridgesClip * 2;
                MaxAmmo = CartridgesClip * 4;
                FiringRange = 8;
                MaxDamage = 3.25;
                MinDamage = 2.75;
                Recoil = 30;
                FiringRate = 100;
                BurstShots = 3;
                RadiusSound = 13;
                ReloadFrames = 2;
                Icon = new[]
                {
                    /*LV1:*/ Properties.Resources.gun_4_1_icon,
                    /*LV2:*/ Properties.Resources.gun_4_2_icon,
                    /*LV3:*/ Properties.Resources.gun_4_3_icon,
                };
                Images = new[,]
                {
                    /*LV1:*/ { Properties.Resources.gun_4_1, Properties.Resources.gun_4_1_shooted, Properties.Resources.gun_4_1_1_reload, Properties.Resources.gun_4_1_2_reload, Properties.Resources.gun_4_1_run },
                    /*LV2:*/ { Properties.Resources.gun_4_2, Properties.Resources.gun_4_2_shooted, Properties.Resources.gun_4_2_1_reload, Properties.Resources.gun_4_2_2_reload, Properties.Resources.gun_4_2_run },
                    /*LV3:*/ { Properties.Resources.gun_4_3, Properties.Resources.gun_4_3_shooted, Properties.Resources.gun_4_3_1_reload, Properties.Resources.gun_4_3_2_reload, Properties.Resources.gun_4_3_run }
                };
                Sounds = new[,]
                {
                    /*LV1:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_4.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_4_1_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_4_empty.wav")) },
                    /*LV2:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_4.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_4_1_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_4_empty.wav")) },
                    /*LV3:*/ { new PlaySound(MainMenu.CGFReader.GetFile("gun_4_3.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_4_3_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_4_empty.wav")) }
                };
            }
            else if (Type == 4)
            {
                Name = new[] { "Снайперка", "Sniper rifle" };
                GunType = GunTypes.Sniper;
                FireType = FireTypes.Single;
                GunCost = 45;
                AmmoCost = 25;
                RechargeTime = 850;
                CartridgesClip = 2;
                MaxAmmoCount = 2;
                MaxAmmo = CartridgesClip * 3;
                FiringRange = 21;
                MaxDamage = 18;
                MinDamage = 12;
                Recoil = 150;
                FiringRate = 200;
                BurstShots = 1;
                RadiusSound = 20;
                ReloadFrames = 1;
                Icon = new[]
                {
                    Properties.Resources.gun_2_icon
                };
                Images = new[,]
                {
                    { Properties.Resources.gun_2, Properties.Resources.gun_2_shooted, Properties.Resources.gun_2_reload, Properties.Resources.gun_2_aiming, Properties.Resources.gun_2_run }
                };
                Sounds = new[,]
                {
                    { new PlaySound(MainMenu.CGFReader.GetFile("gun_2.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_2_reloading.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_2_empty.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_2_aiming.wav")) }
                };
            }
            else if (Type == 5)
            {
                HasIt = false;
                GunType = GunTypes.EasterEgg;
                FireType = FireTypes.Single;
                RechargeTime = 600;
                CartridgesClip = 1;
                MaxAmmoCount = 99;
                MaxAmmo = 99;
                FiringRange = 10;
                MaxDamage = 25;
                MinDamage = 20;
                Recoil = 350;
                FiringRate = 175;
                BurstShots = 1;
                RadiusSound = 0;
                ReloadFrames = 2;
                Icon = new[]
                {
                    Properties.Resources.gun_1_1_icon
                };
                Images = new[,]
                {
                   { Properties.Resources.gun_5, Properties.Resources.gun_5_shooted, Properties.Resources.gun_5_1_reload, Properties.Resources.gun_5_2_reload, Properties.Resources.gun_5_run, Properties.Resources.gun_5_run }
                };
                Sounds = new[,]
                {
                   { new PlaySound(MainMenu.CGFReader.GetFile("gun_5.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_5_reloading.wav")), new PlaySound(null) }
                };
            }
            else if (Type == 6)
            {
                HasIt = false;
                GunType = GunTypes.Tank;
                FireType = FireTypes.Single;
                RechargeTime = 750;
                CartridgesClip = 7;
                MaxAmmoCount = CartridgesClip * 4;
                MaxAmmo = CartridgesClip * 4;
                FiringRange = 16;
                MaxDamage = 55;
                MinDamage = 50;
                Recoil = 350;
                FiringRate = 175;
                BurstShots = 1;
                RadiusSound = 0;
                ReloadFrames = 3;
                Icon = new[]
                {
                    Properties.Resources.gun_1_1_icon
                };
                Images = new[,]
                {                   
                   { Properties.Resources.gun_6, Properties.Resources.gun_6_shooted, Properties.Resources.gun_6_1_reload, Properties.Resources.gun_6_2_reload, Properties.Resources.gun_6_3_reload, Properties.Resources.gun_6 }
                };
                Sounds = new[,]
                {
                   { new PlaySound(MainMenu.CGFReader.GetFile("gun_6.wav")), new PlaySound(MainMenu.CGFReader.GetFile("gun_6_reloading.wav")), new PlaySound(null) }
                };
            }
            Level = Levels.LV1;
            AmmoCount = CartridgesClip;
        }

        public void SetDefault()
        {
            Level = Levels.LV1;
            ApplyUpdate();
            if (Type != 0)
                HasIt = false;
        }

        public void ReloadClip()
        {
            MaxAmmoCount += AmmoCount;
            AmmoCount = 0;
            if (MaxAmmoCount >= CartridgesClip)
            {
                AmmoCount = CartridgesClip;
                MaxAmmoCount -= CartridgesClip;
            }
            else
            {
                AmmoCount = MaxAmmoCount;
                MaxAmmoCount = 0;
            }
        }

        public int GetLevel()
        {
            switch (Level)
            {
                case Levels.LV1:
                    return 0;
                case Levels.LV2:
                    return 1;
                default:
                    return 2;
            }
        }

        private void ApplyUpdate()
        {
            if (Type == 0)
            {
                if (Level == Levels.LV1)
                {
                    RechargeTime = 600;
                    CartridgesClip = 8;
                    MaxAmmoCount = CartridgesClip * 3;
                    MaxAmmo = CartridgesClip * 6;
                    FiringRange = 7;
                    MaxDamage = 1.75;
                    MinDamage = 1.25;
                    Recoil = 10;
                    FiringRate = 175;
                    BurstShots = 1;
                    RadiusSound = 6;
                    ReloadFrames = 1;
                }
                else if (Level == Levels.LV2)
                {
                    RechargeTime = 350;
                    CartridgesClip = 12;
                    MaxAmmoCount = CartridgesClip * 3;
                    MaxAmmo = CartridgesClip * 7;
                    FiringRange = 8;
                    MaxDamage = 2.75;
                    MinDamage = 2.5;
                    Recoil = 20;
                    FiringRate = 175;
                    BurstShots = 1;
                    RadiusSound = 7;
                    ReloadFrames = 1;
                }
                else
                {
                    RechargeTime = 400;
                    CartridgesClip = 6;
                    MaxAmmoCount = CartridgesClip * 2;
                    MaxAmmo = CartridgesClip * 6;
                    FiringRange = 9;
                    MaxDamage = 10.5;
                    MinDamage = 5;
                    Recoil = 35;
                    FiringRate = 225;
                    BurstShots = 1;
                    RadiusSound = 10;
                    ReloadFrames = 2;
                }
                MaxAmmoCount = CartridgesClip * 3;
            }
            else if (Type == 1)
            {
                if (Level == Levels.LV1)
                {
                    RechargeTime = 425;
                    CartridgesClip = 2;
                    MaxAmmoCount = CartridgesClip;
                    MaxAmmo = CartridgesClip * 5;
                    FiringRange = 7;
                    MaxDamage = 3.5;
                    MinDamage = 2.75;
                    Recoil = 120;
                    FiringRate = 200;
                    BurstShots = 1;
                    RadiusSound = 10;
                    ReloadFrames = 2;
                }
                else if (Level == Levels.LV2)
                {
                    RechargeTime = 425;
                    CartridgesClip = 6;
                    MaxAmmoCount = CartridgesClip * 2;
                    MaxAmmo = CartridgesClip * 7;
                    FiringRange = 6;
                    MaxDamage = 4.75;
                    MinDamage = 3.25;
                    Recoil = 80;
                    FiringRate = 200;
                    BurstShots = 1;
                    RadiusSound = 10;
                    ReloadFrames = 3;
                }
                else
                {
                    RechargeTime = 425;
                    CartridgesClip = 14;
                    MaxAmmoCount = CartridgesClip * 2;
                    MaxAmmo = CartridgesClip * 4;
                    FiringRange = 5;
                    MaxDamage = 6.25;
                    MinDamage = 5.25;
                    Recoil = 135;
                    FiringRate = 200;
                    BurstShots = 1;
                    RadiusSound = 10;
                    ReloadFrames = 3;
                }
                MaxAmmoCount = CartridgesClip * 2;
            }
            else if (Type == 2)
            {
                if (Level == Levels.LV1)
                {
                    RechargeTime = 375;
                    CartridgesClip = 18;
                    MaxAmmoCount = CartridgesClip * 3;
                    MaxAmmo = CartridgesClip * 6;
                    FiringRange = 8;
                    MaxDamage = 2;
                    MinDamage = 1.5;
                    Recoil = 35;
                    FiringRate = 50;
                    BurstShots = 6;
                    RadiusSound = 6;
                    ReloadFrames = 2;
                }
                else if (Level == Levels.LV2)
                {
                    RechargeTime = 350;
                    CartridgesClip = 30;
                    MaxAmmoCount = CartridgesClip * 3;
                    MaxAmmo = CartridgesClip * 6;
                    FiringRange = 8;
                    MaxDamage = 2.5;
                    MinDamage = 1.75;
                    Recoil = 15;
                    FiringRate = 50;
                    BurstShots = 3;
                    RadiusSound = 6;
                    ReloadFrames = 2;
                }
                else
                {
                    RechargeTime = 350;
                    CartridgesClip = 30;
                    MaxAmmoCount = CartridgesClip * 3;
                    MaxAmmo = CartridgesClip * 6;
                    FiringRange = 8;
                    MaxDamage = 2.7;
                    MinDamage = 1.95;
                    Recoil = 25;
                    FiringRate = 25;
                    BurstShots = 6;
                    RadiusSound = 6;
                    ReloadFrames = 2;
                }
                MaxAmmoCount = CartridgesClip * 1;
            }
            else if (Type == 3)
            {
                if (Level == Levels.LV1)
                {
                    FireType = FireTypes.SemiAutomatic;
                    RechargeTime = 700;
                    CartridgesClip = 24;
                    MaxAmmoCount = CartridgesClip * 3;
                    MaxAmmo = CartridgesClip * 5;
                    FiringRange = 8;
                    MaxDamage = 2.5;
                    MinDamage = 2;
                    Recoil = 30;
                    FiringRate = 100;
                    BurstShots = 3;
                    RadiusSound = 13;
                    ReloadFrames = 2;
                }
                else if (Level == Levels.LV2)
                {
                    FireType = FireTypes.SemiAutomatic;
                    RechargeTime = 450;
                    CartridgesClip = 24;
                    MaxAmmoCount = CartridgesClip * 3;
                    MaxAmmo = CartridgesClip * 5;
                    FiringRange = 8;
                    MaxDamage = 3.25;
                    MinDamage = 2.75;
                    Recoil = 25;
                    FiringRate = 100;
                    BurstShots = 3;
                    RadiusSound = 13;
                    ReloadFrames = 2;
                }
                else
                {
                    FireType = FireTypes.Single;
                    RechargeTime = 400;
                    CartridgesClip = 20;
                    MaxAmmoCount = CartridgesClip * 2;
                    MaxAmmo = CartridgesClip * 4;
                    FiringRange = 8;
                    MaxDamage = 4.5;
                    MinDamage = 3.5;
                    Recoil = 40;
                    FiringRate = 100;
                    BurstShots = 1;
                    RadiusSound = 13;
                    ReloadFrames = 2;
                }
            }
            else if (Type == 4)
                MaxAmmoCount = 1;
            AmmoCount = CartridgesClip;
        }

        public void LevelUpdate()
        {
            if (Level != Levels.LV3 && GunType != GunTypes.Sniper && GunType != GunTypes.EasterEgg && GunType != GunTypes.Tank)
            {
                Level++;
                UpdateCost += 15;
                ApplyUpdate();
            }
        }
    }
}