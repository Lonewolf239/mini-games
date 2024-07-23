using SharpDX.Direct2D1;
using System;
using System.Runtime.InteropServices;
using System.Linq;

namespace minigames._SLIL
{
    public abstract class Entity
    {
        protected double HP { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int IntX { get; set; }
        public int IntY { get; set; }
        public double A { get; set; }
        protected char[] impassibleCells;
        protected double entityWidth;
        public bool DEAD { get; set; }
        public int RESPAWN { get; set; }
        public int Texture { get; set; }
        public bool RespondsToFlashlight { get; set; }
        public int[][] Animations { get; set; }
        public int Frames = 24;
        public int MAX_MONEY;
        public int MIN_MONEY;
        public int MAX_DAMAGE;
        public int MIN_DAMAGE;
        protected int MAP_WIDTH { get; set; }
        protected int MAX_HP;
        protected const int RESPAWN_TIME = 60;
        protected readonly Random rand = new Random();

        protected abstract int GetMAX_HP();
        protected abstract int GetTexture();
        protected abstract int GetMAX_MONEY();
        protected abstract int GetMIN_MONEY();
        protected abstract int GetMAX_DAMAGE();
        protected abstract int GetMIN_DAMAGE();
        protected abstract double GetEntityWidth();
        protected abstract char[] GetImpassibleCells();
        public Entity(double x, double y, int map_width)
        {
            MAX_HP = this.GetMAX_HP();
            Texture = this.GetTexture();
            MAX_MONEY = this.GetMAX_MONEY();
            MIN_MONEY = this.GetMIN_MONEY();
            MAX_DAMAGE = this.GetMAX_DAMAGE();
            MIN_DAMAGE = this.GetMIN_DAMAGE();
            entityWidth = this.GetEntityWidth();
            impassibleCells = this.GetImpassibleCells();
            HP = MAX_HP;
            RespondsToFlashlight = false;
            Texture = this.GetTexture();
            Animations = new int[1][];
            Animations[0] = new int[Frames];
            for (int item = 0; item < Frames; item++)
            {
                if (item % 3 == 0)
                    Animations[0][item] = Texture;
                else
                    Animations[0][item] = Texture + 1;
            }
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
            HP = MAX_HP;
            DEAD = false;
        }
        protected abstract double GetMove();
        public void UpdateCoordinates(string map)
        {
            double move = this.GetMove();
            double newX = X;
            double newY = Y;
            double tempX = X;
            double tempY = Y;
            newX += Math.Sin(A) * move;
            newY += Math.Cos(A) * move;
            A += rand.NextDouble();
            //try
            //{
            //    if (map[(int)Y * MAP_WIDTH + (int)X] == '#' || map[(int)Y * MAP_WIDTH + (int)X] == '=' || map[(int)Y * MAP_WIDTH + (int)X] == 'D' || map[(int)Y * MAP_WIDTH + (int)X] == 'O' || map[(int)Y * MAP_WIDTH + (int)X] == 'F' || map[(int)Y * MAP_WIDTH + (int)X] == 'E')
            //    {
            //        newX -= Math.Sin(A) * move;
            //        newY -= Math.Cos(A) * move;
            //        A -= rand.NextDouble();
            //    }
            //}
            //catch
            //{
            //    newX -= Math.Sin(A) * move;
            //    newY -= Math.Cos(A) * move;
            //    A -= rand.NextDouble();
            //}
            IntX = (int)X;
            IntY = (int)Y;
            if (!(impassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX + entityWidth / 2)])
                || impassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX - entityWidth / 2)])))
                tempX = newX;
            if (!(impassibleCells.Contains(map[(int)(newY + entityWidth / 2) * MAP_WIDTH + (int)newX])
                || impassibleCells.Contains(map[(int)(newY - entityWidth / 2) * MAP_WIDTH + (int)newX])))
                tempY = newY;
            if (impassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX + entityWidth / 2)]))
                tempX -= entityWidth / 2 - (1 - tempX % 1);
            if (impassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX - entityWidth / 2)]))
                tempX += entityWidth / 2 - (tempX % 1);
            if (impassibleCells.Contains(map[(int)(tempY + entityWidth / 2) * MAP_WIDTH + (int)tempX]))
                tempY -= entityWidth / 2 - (1 - tempY % 1);
            if (impassibleCells.Contains(map[(int)(tempY - entityWidth / 2) * MAP_WIDTH + (int)tempX]))
                tempY += entityWidth / 2 - (tempY % 1);
            X = tempX;
            Y = tempY;
        }
    }
    public abstract class Enemy : Entity
    {
        public Enemy(double x, double y, int map_width) : base(x, y, map_width) { }
    }
    public class Man : Enemy
    {
        protected override double GetEntityWidth() => 0.4;
        protected override char[] GetImpassibleCells() 
        {
            return new char[] { '#', 'D', '=' };
        }
        protected override int GetMAX_HP() => 10;
        protected override int GetTexture() => 1;
        protected override double GetMove() => 1;
        protected override int GetMAX_MONEY() => 10;
        protected override int GetMIN_MONEY() => 5;
        protected override int GetMAX_DAMAGE() => 35;
        protected override int GetMIN_DAMAGE() => 15;
        public Man(double x, double y, int map_width) : base (x, y, map_width) 
        {
            
        }
    }
    public class Dog : Enemy
    {
        protected override double GetEntityWidth() => 0.4;
        protected override char[] GetImpassibleCells()
        {
            return new char[] { '#', 'D', '=' };
        }
        protected override int GetMAX_HP() => 5;
        protected override int GetTexture() => 5;
        protected override double GetMove() => 1;
        protected override int GetMAX_MONEY() => 15;
        protected override int GetMIN_MONEY() => 10;
        protected override int GetMAX_DAMAGE() => 40;
        protected override int GetMIN_DAMAGE() => 25;
        public Dog(double x, double y, int map_width) : base(x, y, map_width)
        {
            
        }
    }

    public class Abomination : Enemy
    {
        protected override double GetEntityWidth() => 0.4;
        protected override char[] GetImpassibleCells()
        {
            return new char[] { '#', 'D', '=' };
        }
        protected override int GetMAX_HP() => 20;
        protected override int GetTexture() => 9;
        protected override double GetMove() => 0.5;
        protected override int GetMAX_MONEY() => 18;
        protected override int GetMIN_MONEY() => 12;
        protected override int GetMAX_DAMAGE() => 30;
        protected override int GetMIN_DAMAGE() => 20;
        public Abomination(double x, double y, int map_width) : base(x, y, map_width)
        {
            
        }
    }
}