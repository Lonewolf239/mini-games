using SharpDX.Direct2D1;
using System.Collections.Generic;

namespace minigames._SLIL
{
    public class Player
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double A { get; set; }
        public double Look { get; set; }
        public double HP { get; set; }
        public double STAMINE { get; set; }
        public bool CanShoot { get; set; }
        public bool Aiming { get; set; }
        public bool InShop { get; set; }
        public bool UseFirstMedKit { get; set; }
        public bool Dead { get; set; }
        public int Money { get; set; }
        public int CurrentGun { get; set; }
        public int PreviousGun { get; set; }
        public int GunState { get; set; }
        public int MoveStyle { get; set; }
        public bool LevelUpdated { get; set; }
        public double CurseCureChance { get; set; }
        public readonly List<Gun> Guns = new List<Gun>();
        public readonly List<Gun> FirstAidKits = new List<Gun>();
        public double MAX_HP = 100;
        public double MAX_STAMINE = 650;

        public Player()
        {
            HP = MAX_HP;
            SetDefault();
        }

        public void SetDefault()
        {
            if (Dead)
            {
                HP = MAX_HP;
                Guns.Clear();
                FirstAidKits.Clear();
            }
            Look = 0;
            GunState = 0;
            CanShoot = true;
            Dead = false;
            InShop = false;
            Aiming = false;
            UseFirstMedKit = false;
            LevelUpdated = false;
            PreviousGun = CurrentGun = 0;
            CurseCureChance = 0.08;
            STAMINE = MAX_STAMINE;
            Money = 15;
        }

        public void HealHP(int value)
        {
            UseFirstMedKit = false;
            HP += value;
            if (HP > MAX_HP)
                HP = MAX_HP;
        }

        public void DealDamage(double value) => HP -= value;

        public void ChangeMoney(int value)
        {
            Money += value;
            if (Money > 9999)
                Money = 9999;
            else if (Money < 0)
                Money = 0;
        }
    }
}