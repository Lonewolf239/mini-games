namespace minigames._Balda.classes
{
    public class Time
    {
        private int Seconds { get; set; }
        private int Minutes { get; set; }
        private string SecondsSpace { get; set; }
        private string MinutesSpace { get; set; }

        public Time() => SetDefault();

        public void SetDefault()
        {
            Seconds = 0;
            Minutes = 0;
            SecondsSpace = MinutesSpace = "0";
        }

        public string GetTime() => $"{MinutesSpace}{Minutes}:{SecondsSpace}{Seconds}";

        public void UpdateTime()
        {
            Seconds++;
            if (Seconds > 59) { Seconds = 0; Minutes++; }
            if (Minutes >= 99) { Minutes = 99; Seconds = 99; }
            SecondsSpace = Seconds < 10 ? "0" : null;
            MinutesSpace = Minutes < 10 ? "0" : null;
        }
    }
}