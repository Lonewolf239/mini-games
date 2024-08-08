namespace minigames.Math_o_light.classes
{
    public class Barrier
    {
        private const int Height = 10;
        public int HP { get; set; }
        public int Top { get; set; }
        public int Bottom { get; }

        public Barrier(int y)
        {
            Top = y;
            Bottom = Top + Height;
            HP = 3;
        }

        public int GetHeight() => Height;
    }
}