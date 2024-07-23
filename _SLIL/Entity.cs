using System;
using System.Linq;

namespace minigames._SLIL
{
    public abstract class Entity
    {
        public double X { get; set; }
        public double Y { get; set; }
        protected double EntityWidth;
        public int IntX { get; set; }
        public int IntY { get; set; }
        public int Texture { get; set; }
        public int[][] Animations { get; set; }
        public bool RespondsToFlashlight { get; set; }
        public int Frames = 24;
        protected readonly Random rand = new Random();

        protected abstract int GetTexture();
        protected abstract double GetEntityWidth();

        public Entity(double x, double y, int map_width)
        {
            Texture = this.GetTexture();
            EntityWidth = this.GetEntityWidth();
            RespondsToFlashlight = false;
            Texture = this.GetTexture();
            X = x;
            Y = y;
            IntX = (int)x;
            IntY = (int)y;
        }
    }

    public abstract class Creature : Entity
    {
        protected double HP { get; set; }
        public double A { get; set; }
        protected char[] ImpassibleCells;
        protected int MovesInARow;
        protected int NumberOfMovesLeft;
        public bool CanHit { get; set; }
        public bool DEAD { get; set; }
        public int RESPAWN { get; set; }
        public int MAX_MONEY;
        public int MIN_MONEY;
        public int MAX_DAMAGE;
        public int MIN_DAMAGE;
        protected int MAP_WIDTH { get; set; }
        protected int MAX_HP;
        protected const int RESPAWN_TIME = 60;

        protected abstract int GetMAX_HP();
        protected abstract int GetMAX_MONEY();
        protected abstract int GetMIN_MONEY();
        protected abstract int GetMAX_DAMAGE();
        protected abstract int GetMIN_DAMAGE();
        protected abstract char[] GetImpassibleCells();
        protected abstract int GetMovesInARow();
        protected abstract double GetMove();

        public bool DealDamage(double damage)
        {
            HP -= damage;
            if (HP <= 0)
                Kill();
            return DEAD;
        }

        public void Kill()
        {
            RESPAWN = RESPAWN_TIME;
            DEAD = true;
        }

        public void Respawn()
        {
            HP = MAX_HP;
            DEAD = false;
        }

        public Creature(double x, double y, int map_width) : base(x, y, map_width)
        {
            MAX_HP = this.GetMAX_HP();
            MAX_MONEY = this.GetMAX_MONEY();
            MIN_MONEY = this.GetMIN_MONEY();
            MAX_DAMAGE = this.GetMAX_DAMAGE();
            MIN_DAMAGE = this.GetMIN_DAMAGE();
            ImpassibleCells = this.GetImpassibleCells();
            MovesInARow = this.GetMovesInARow();
            NumberOfMovesLeft = MovesInARow;
            CanHit = false;
            HP = MAX_HP;
            Animations = new int[1][];
            Animations[0] = new int[Frames];
            for (int item = 0; item < Frames; item++)
            {
                if (item % 3 == 0)
                    Animations[0][item] = Texture;
                else
                    Animations[0][item] = Texture + 1;
            }
            A = rand.NextDouble();
            MAP_WIDTH = map_width;
        }

        public virtual void UpdateCoordinates(string map, double playerX, double playerY)
        {
            double move = this.GetMove();
            double newX = X;
            double newY = Y;
            double tempX = X;
            double tempY = Y;
            newX += Math.Sin(A) * move;
            newY += Math.Cos(A) * move;
            if (NumberOfMovesLeft > 0)
                NumberOfMovesLeft--;
            else
            {
                A = rand.NextDouble() * (Math.PI * 2);
                NumberOfMovesLeft = MovesInARow;
            }
            IntX = (int)X;
            IntY = (int)Y;
            if (!(ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX + EntityWidth / 2)])
                || ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX - EntityWidth / 2)])))
                tempX = newX;
            if (!(ImpassibleCells.Contains(map[(int)(newY + EntityWidth / 2) * MAP_WIDTH + (int)newX])
                || ImpassibleCells.Contains(map[(int)(newY - EntityWidth / 2) * MAP_WIDTH + (int)newX])))
                tempY = newY;
            if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX + EntityWidth / 2)]))
            {
                tempX -= EntityWidth / 2 - (1 - tempX % 1);
                A = rand.NextDouble() * (Math.PI * 2);
                NumberOfMovesLeft = MovesInARow;
            }
            if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX - EntityWidth / 2)]))
            {
                tempX += EntityWidth / 2 - (tempX % 1);
                A = rand.NextDouble() * (Math.PI * 2);
                NumberOfMovesLeft = MovesInARow;
            }
            if (ImpassibleCells.Contains(map[(int)(tempY + EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
            {
                tempY -= EntityWidth / 2 - (1 - tempY % 1);
                A = rand.NextDouble() * (Math.PI * 2);
                NumberOfMovesLeft = MovesInARow;
            }
            if (ImpassibleCells.Contains(map[(int)(tempY - EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
            {
                tempY += EntityWidth / 2 - (tempY % 1);
                A = rand.NextDouble() * (Math.PI * 2);
                NumberOfMovesLeft = MovesInARow;
            }
            X = tempX;
            Y = tempY;
        }
    }

    public abstract class GameObject : Entity
    {
        protected override double GetEntityWidth() => 0.4;
        protected override int GetTexture() => Texture;
        protected void AnimationsToStatic()
        {
            Animations = new int[1][];
            Animations[0] = new int[Frames];
            for (int item = 0; item < Frames; item++)
                Animations[0][item] = Texture;
        }

        public GameObject(double x, double y, int map_width) : base(x, y, map_width) 
        {
            RespondsToFlashlight = false;
            X += 0.5;
            Y += 0.5;
        }
    }

    public abstract class Enemy : Creature
    {
        protected enum Stages { Roaming, Chasing };
        protected Stages stage;
        protected double detectionRange;
        public Enemy(double x, double y, int map_width) : base(x, y, map_width)
        {
            stage = Stages.Roaming;
            CanHit = true;
        }
    }

    public class Teleport : GameObject
    {
        public Teleport(double x, double y, int map_width) : base(x, y, map_width)
        {
            Texture = 15;
            base.AnimationsToStatic();
        }
    }

    public class Man : Enemy
    {
        protected override double GetEntityWidth() => 0.4;
        protected override char[] GetImpassibleCells() 
        {
            return new char[] { '#', 'D', 'd', '=' };
        }
        protected override int GetMovesInARow() => 10;
        protected override int GetMAX_HP() => 10;
        protected override int GetTexture() => 1;
        protected override double GetMove() => 0.16;
        protected override int GetMAX_MONEY() => 10;
        protected override int GetMIN_MONEY() => 5;
        protected override int GetMAX_DAMAGE() => 35;
        protected override int GetMIN_DAMAGE() => 15;

        public Man(double x, double y, int map_width) : base (x, y, map_width) 
        {
            detectionRange = 8;
        }

        public override void UpdateCoordinates(string map, double playerX, double playerY)
        {
            bool isPlayerVisible = true;
            double distanceToPlayer = Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2));
            if (distanceToPlayer > detectionRange) isPlayerVisible = false;
            double angleToPlayer = Math.Atan2(X - playerX, Y - playerY) - Math.PI;
            if(isPlayerVisible)
            {
                double distance = 0;
                double step = 0.01;
                double rayAngleX = Math.Sin(angleToPlayer);
                double rayAngleY = Math.Cos(angleToPlayer);
                while (distance <= distanceToPlayer)
                {
                    int test_x = (int)(X + rayAngleX * distance);
                    int test_y = (int)(Y + rayAngleY * distance);
                    if(ImpassibleCells.Contains(map[test_y * MAP_WIDTH + test_x]))
                    {
                        isPlayerVisible = false;
                        break;
                    }
                    distance += step;
                }
            }
            if (stage == Stages.Roaming)
            {
                base.UpdateCoordinates(map, playerX, playerY);
                if (isPlayerVisible)
                    stage = Stages.Chasing;
                return;
            }
            if (stage == Stages.Chasing)
            {
                if(!isPlayerVisible)
                {
                    stage = Stages.Roaming;
                    NumberOfMovesLeft = MovesInARow;
                    return;
                }
                double move = this.GetMove();
                double newX = X;
                double newY = Y;
                double tempX = X;
                double tempY = Y;
                A = angleToPlayer;
                if (Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2)) <= EntityWidth) return;
                newX += Math.Sin(A) * move;
                newY += Math.Cos(A) * move;
                IntX = (int)X;
                IntY = (int)Y;
                if (!(ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX + EntityWidth / 2)])
                    || ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX - EntityWidth / 2)])))
                    tempX = newX;
                if (!(ImpassibleCells.Contains(map[(int)(newY + EntityWidth / 2) * MAP_WIDTH + (int)newX])
                    || ImpassibleCells.Contains(map[(int)(newY - EntityWidth / 2) * MAP_WIDTH + (int)newX])))
                    tempY = newY;
                if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX + EntityWidth / 2)]))
                    tempX -= EntityWidth / 2 - (1 - tempX % 1);
                if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX - EntityWidth / 2)]))
                    tempX += EntityWidth / 2 - (tempX % 1);
                if (ImpassibleCells.Contains(map[(int)(tempY + EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                    tempY -= EntityWidth / 2 - (1 - tempY % 1);
                if (ImpassibleCells.Contains(map[(int)(tempY - EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                    tempY += EntityWidth / 2 - (tempY % 1);
                X = tempX;
                Y = tempY;
            }
        }
    }

    public class Dog : Enemy
    {
        protected override double GetEntityWidth() => 0.4;
        protected override char[] GetImpassibleCells()
        {
            return new char[] { '#', 'D', 'd', '=' };
        }
        protected override int GetMovesInARow() => 10;
        protected override int GetMAX_HP() => 5;
        protected override int GetTexture() => 5;
        protected override double GetMove() => 0.125;
        protected override int GetMAX_MONEY() => 15;
        protected override int GetMIN_MONEY() => 10;
        protected override int GetMAX_DAMAGE() => 40;
        protected override int GetMIN_DAMAGE() => 25;

        public Dog(double x, double y, int map_width) : base(x, y, map_width)
        {
            detectionRange = 8;
        }

        public override void UpdateCoordinates(string map, double playerX, double playerY)
        {
            bool isPlayerVisible = true;
            double distanceToPlayer = Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2));
            if (distanceToPlayer > detectionRange) isPlayerVisible = false;
            double angleToPlayer = Math.Atan2(X - playerX, Y - playerY) - Math.PI;
            if (isPlayerVisible)
            {
                double distance = 0;
                double step = 0.01;
                double rayAngleX = Math.Sin(angleToPlayer);
                double rayAngleY = Math.Cos(angleToPlayer);
                while (distance <= distanceToPlayer)
                {
                    int test_x = (int)(X + rayAngleX * distance);
                    int test_y = (int)(Y + rayAngleY * distance);
                    if (ImpassibleCells.Contains(map[test_y * MAP_WIDTH + test_x]))
                    {
                        isPlayerVisible = false;
                        break;
                    }
                    distance += step;
                }
            }
            if (stage == Stages.Roaming)
            {
                base.UpdateCoordinates(map, playerX, playerY);
                if (isPlayerVisible)
                    stage = Stages.Chasing;
                return;
            }
            if (stage == Stages.Chasing)
            {
                if (!isPlayerVisible)
                {
                    stage = Stages.Roaming;
                    NumberOfMovesLeft = MovesInARow;
                    return;
                }
                double move = this.GetMove();
                double newX = X;
                double newY = Y;
                double tempX = X;
                double tempY = Y;
                A = angleToPlayer;
                if (Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2)) <= EntityWidth) return;
                newX += Math.Sin(A) * move;
                newY += Math.Cos(A) * move;
                IntX = (int)X;
                IntY = (int)Y;
                if (!(ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX + EntityWidth / 2)])
                    || ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX - EntityWidth / 2)])))
                    tempX = newX;
                if (!(ImpassibleCells.Contains(map[(int)(newY + EntityWidth / 2) * MAP_WIDTH + (int)newX])
                    || ImpassibleCells.Contains(map[(int)(newY - EntityWidth / 2) * MAP_WIDTH + (int)newX])))
                    tempY = newY;
                if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX + EntityWidth / 2)]))
                    tempX -= EntityWidth / 2 - (1 - tempX % 1);
                if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX - EntityWidth / 2)]))
                    tempX += EntityWidth / 2 - (tempX % 1);
                if (ImpassibleCells.Contains(map[(int)(tempY + EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                    tempY -= EntityWidth / 2 - (1 - tempY % 1);
                if (ImpassibleCells.Contains(map[(int)(tempY - EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                    tempY += EntityWidth / 2 - (tempY % 1);
                X = tempX;
                Y = tempY;
            }
        }
    }

    public class Abomination : Enemy
    {
        protected override double GetEntityWidth() => 0.4;
        protected override char[] GetImpassibleCells()
        {
            return new char[] { '#', 'D', 'd', '=' };
        }
        protected override int GetMovesInARow() => 40;
        protected override int GetMAX_HP() => 20;
        protected override int GetTexture() => 9;
        protected override double GetMove() => 0.1;
        protected override int GetMAX_MONEY() => 18;
        protected override int GetMIN_MONEY() => 12;
        protected override int GetMAX_DAMAGE() => 30;
        protected override int GetMIN_DAMAGE() => 20;

        public Abomination(double x, double y, int map_width) : base(x, y, map_width)
        {
            detectionRange = 8;
        }

        public override void UpdateCoordinates(string map, double playerX, double playerY)
        {
            bool isPlayerVisible = true;
            double distanceToPlayer = Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2));
            if (distanceToPlayer > detectionRange) isPlayerVisible = false;
            double angleToPlayer = Math.Atan2(X - playerX, Y - playerY) - Math.PI;
            if (isPlayerVisible)
            {
                double distance = 0;
                double step = 0.01;
                double rayAngleX = Math.Sin(angleToPlayer);
                double rayAngleY = Math.Cos(angleToPlayer);
                while (distance <= distanceToPlayer)
                {
                    int test_x = (int)(X + rayAngleX * distance);
                    int test_y = (int)(Y + rayAngleY * distance);
                    if (ImpassibleCells.Contains(map[test_y * MAP_WIDTH + test_x]))
                    {
                        isPlayerVisible = false;
                        break;
                    }
                    distance += step;
                }
            }
            if (stage == Stages.Roaming)
            {
                base.UpdateCoordinates(map, playerX, playerY);
                if (isPlayerVisible)
                    stage = Stages.Chasing;
                return;
            }
            if (stage == Stages.Chasing)
            {
                if (!isPlayerVisible)
                {
                    stage = Stages.Roaming;
                    NumberOfMovesLeft = MovesInARow;
                    return;
                }
                double move = this.GetMove();
                double newX = X;
                double newY = Y;
                double tempX = X;
                double tempY = Y;
                A = angleToPlayer;
                if (Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2)) <= EntityWidth) return;
                newX += Math.Sin(A) * move;
                newY += Math.Cos(A) * move;
                IntX = (int)X;
                IntY = (int)Y;
                if (!(ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX + EntityWidth / 2)])
                    || ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX - EntityWidth / 2)])))
                    tempX = newX;
                if (!(ImpassibleCells.Contains(map[(int)(newY + EntityWidth / 2) * MAP_WIDTH + (int)newX])
                    || ImpassibleCells.Contains(map[(int)(newY - EntityWidth / 2) * MAP_WIDTH + (int)newX])))
                    tempY = newY;
                if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX + EntityWidth / 2)]))
                    tempX -= EntityWidth / 2 - (1 - tempX % 1);
                if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX - EntityWidth / 2)]))
                    tempX += EntityWidth / 2 - (tempX % 1);
                if (ImpassibleCells.Contains(map[(int)(tempY + EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                    tempY -= EntityWidth / 2 - (1 - tempY % 1);
                if (ImpassibleCells.Contains(map[(int)(tempY - EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                    tempY += EntityWidth / 2 - (tempY % 1);
                X = tempX;
                Y = tempY;
            }
        }
    }
    public abstract class Friend : Creature
    {

        public Friend(double x, double y, int map_width) : base(x, y, map_width)
        {
            CanHit = false;
        }
    }
    public abstract class Pet : Friend
    {
        public double detectionRange;
        protected override double GetEntityWidth() => 0.1;
        protected override char[] GetImpassibleCells()
        {
            return new char[] { '#', 'D', 'd', '=' };
        }
        protected override int GetMovesInARow() => 0;
        protected override int GetMAX_HP() => 0;
        protected override int GetTexture() => 9;
        protected override double GetMove() => 0.2;
        protected override int GetMAX_MONEY() => 0;
        protected override int GetMIN_MONEY() => 0;
        protected override int GetMAX_DAMAGE() => 0;
        protected override int GetMIN_DAMAGE() => 0;
        public Pet(double x, double y, int map_width) : base(x, y, map_width)
        {
            detectionRange = 8.0;
        }
        public override void UpdateCoordinates(string map, double playerX, double playerY)
        {
            bool isPlayerVisible = true;
            double distanceToPlayer = Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2));
            if (distanceToPlayer > detectionRange) isPlayerVisible = false;
            double angleToPlayer = Math.Atan2(X - playerX, Y - playerY) - Math.PI;
            if (isPlayerVisible)
            {
                double distance = 0;
                double step = 0.01;
                double rayAngleX = Math.Sin(angleToPlayer);
                double rayAngleY = Math.Cos(angleToPlayer);
                while (distance <= distanceToPlayer)
                {
                    int test_x = (int)(X + rayAngleX * distance);
                    int test_y = (int)(Y + rayAngleY * distance);
                    if (ImpassibleCells.Contains(map[test_y * MAP_WIDTH + test_x]))
                    {
                        isPlayerVisible = false;
                        break;
                    }
                    distance += step;
                }
            }
            double move = this.GetMove();
            double newX = X;
            double newY = Y;
            double tempX = X;
            double tempY = Y;
            A = angleToPlayer;
            if (Math.Sqrt(Math.Pow(X - playerX, 2) + Math.Pow(Y - playerY, 2)) <= EntityWidth) return;
            newX += Math.Sin(A) * move;
            newY += Math.Cos(A) * move;
            IntX = (int)X;
            IntY = (int)Y;
            if (!(ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX + EntityWidth / 2)])
                || ImpassibleCells.Contains(map[(int)newY * MAP_WIDTH + (int)(newX - EntityWidth / 2)])))
                tempX = newX;
            if (!(ImpassibleCells.Contains(map[(int)(newY + EntityWidth / 2) * MAP_WIDTH + (int)newX])
                || ImpassibleCells.Contains(map[(int)(newY - EntityWidth / 2) * MAP_WIDTH + (int)newX])))
                tempY = newY;
            if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX + EntityWidth / 2)]))
                tempX -= EntityWidth / 2 - (1 - tempX % 1);
            if (ImpassibleCells.Contains(map[(int)tempY * MAP_WIDTH + (int)(tempX - EntityWidth / 2)]))
                tempX += EntityWidth / 2 - (tempX % 1);
            if (ImpassibleCells.Contains(map[(int)(tempY + EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                tempY -= EntityWidth / 2 - (1 - tempY % 1);
            if (ImpassibleCells.Contains(map[(int)(tempY - EntityWidth / 2) * MAP_WIDTH + (int)tempX]))
                tempY += EntityWidth / 2 - (tempY % 1);
            if(isPlayerVisible)
            {
                if(Math.Sqrt(Math.Pow(tempX - playerX, 2) + Math.Pow(tempY - playerY, 2)) >= 0.7)
                {
                    X = tempX;
                    Y = tempY;
                }
            }
            else
            {
                X = playerX+0.1; 
                Y = playerY+0.1;
            }
        }
    }
    public class SillyCat : Pet
    {
        public SillyCat(double x, double y, int map_width) : base (x, y, map_width)
        {
        }
        
    }
}