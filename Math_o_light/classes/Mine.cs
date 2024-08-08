namespace minigames.Math_o_light.classes
{
    public class Mine
    {
        private const int Size = 20;
        public int Bottom { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        private int X { get; set; }
        private int Y { get; set; }

        public Mine(int x,int y)
        {
            X = x;
            Y = y;
            SetTBLR();
        }

        private void SetTBLR()
        {
            Top = Y - (Size / 2);
            Bottom = Y + (Size / 2);
            Left = X - (Size / 2);
            Right = X + (Size / 2);
        }

        public int GetSize() => Size;

        public void UpdateCoordinates()
        {
            Y += (int)(2 * MainMenu.scale_size);
            SetTBLR();
        }
    }
}