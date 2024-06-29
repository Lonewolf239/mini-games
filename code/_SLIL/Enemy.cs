using SharpDX.Direct2D1;
using System;

namespace minigames._SLIL
{
    public class Enemy
    {
        private double HP { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int IntX { get; set; }
        public int IntY { get; set; }
        public double A { get; set; }
        public bool DEAD { get; set; }
        public int RESPAWN { get; set; }
        public int Type { get; set; }
        public readonly int[] MAX_MONEY = { 16, 21, 24 };
        public readonly int[] MIN_MONEY = { 9, 15, 17 };
        public readonly int[] MAX_DAMAGE = { 35, 40, 30 };
        public readonly int[] MIN_DAMAGE = { 15, 25, 20 };
        private int MAP_WIDTH { get; set; }
        private readonly int[] MAX_HP = { 10, 5, 20 };
        private const int RESPAWN_TIME = 45;
        private readonly Random rand = new Random();

        public Enemy(double x, double y, int map_width, double spawn)
        {
            if (spawn <= 0.5)
                Type = 0;
            else if (spawn > 0.5 && spawn <= 0.7)
                Type = 1;
            else
                Type = 2;
            HP = MAX_HP[Type];
            X = x;
            Y = y;
            IntX = (int)x;
            IntY = (int)y;
            A = rand.NextDouble();
            MAP_WIDTH = map_width;
        }

        public bool DealDamage(double damage)
        {
            HP -= damage;
            if (HP <= 0)
                Kill();
            return DEAD;
        }

        public void Kill()
        {
            RESPAWN = RESPAWN_TIME * 2;
            DEAD = true;
        }

        public void Respawn()
        {
            HP = MAX_HP[Type];
            DEAD = false;
        }

        public void UpdateCoordinates(string map)
        {
            float move = 1;
            if (Type == 2)
                move = 0.5f;
            X += Math.Sin(A) * move;
            Y += Math.Cos(A) * move;
            try
            {
                if (map[(int)Y * MAP_WIDTH + (int)X] == '#' || map[(int)Y * MAP_WIDTH + (int)X] == '=' || map[(int)Y * MAP_WIDTH + (int)X] == 'D' || map[(int)Y * MAP_WIDTH + (int)X] == 'O' || map[(int)Y * MAP_WIDTH + (int)X] == 'F' || map[(int)Y * MAP_WIDTH + (int)X] == 'E')
                {
                    X -= Math.Sin(A) * move;
                    Y -= Math.Cos(A) * move;
                    A -= rand.NextDouble();
                }
            }
            catch
            {
                X -= Math.Sin(A) * move;
                Y -= Math.Cos(A) * move;
                A -= rand.NextDouble();
            }
            IntX = (int)X;
            IntY = (int)Y;
        }
    }
}