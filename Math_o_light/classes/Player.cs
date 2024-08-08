namespace minigames.Math_o_light.classes
{
    public class Player
    {
        private const int MaxHP = 100;
        public int HP { get; set; }
        public int SolvedMathProblems { get; set; }
        public double Difficulty { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }

        public Player()
        {
            SetDefault();
        }

        public int GetMaxHP() => MaxHP;

        public void SetDefault()
        {
            HP = MaxHP;
            SolvedMathProblems = 0;
            Difficulty = 0.1;
        }

        private bool Dead()
        {
            if (Score > MaxScore)
                MaxScore = Score;
            Score = 0;
            return true;
        }

        public bool DealDamage(int value)
        {
            HP -= value;
            if (HP <= 0) return Dead();
            return false;
        }

        public void HealHP(int value)
        {
            HP += value;
            if (HP > MaxHP)
                HP = MaxHP;
        }
    }
}