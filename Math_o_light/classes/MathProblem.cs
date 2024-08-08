using System;

namespace minigames.Math_o_light.classes
{
    public class MathProblem
    {
        public string CurrentMathProblem { get; set; }
        public string CurrentAnswer { get; set; }
        private readonly Random rand = new Random();

        public MathProblem() => SetDefault();

        public void SetDefault() => CurrentMathProblem = GetNewMathProblem(0.05);

        public string GetNewMathProblem(double difficulty)
        {
            int maxNumber;
            if (difficulty < 0.3)
                maxNumber = 10;
            else
                maxNumber = (int)((1 - difficulty) * 10 + 10);
            int num1 = rand.Next(1, maxNumber);
            int num2 = rand.Next(1, maxNumber);
            int operation = rand.Next(1, 5);
            string operationSymbol;
            double answer;
            switch (operation)
            {
                case 1:
                    operationSymbol = "+";
                    answer = num1 + num2;
                    break;
                case 2:
                    operationSymbol = "-";
                    answer = num1 - num2;
                    break;
                case 3:
                    operationSymbol = "*";
                    answer = num1 * num2;
                    break;
                case 4:
                    operationSymbol = "^";
                    if (num1 >= 10)
                        num1 /= 10;
                    num2 = GetPowerForDifficulty(num2, difficulty);
                    answer = Math.Pow(num1, num2);
                    break;
                default:
                    operationSymbol = "+";
                    answer = num1 + num2;
                    break;
            }
            CurrentMathProblem = $"{num1} {operationSymbol} {num2} = ";
            CurrentAnswer = answer.ToString();
            return CurrentMathProblem;
        }

        private int GetPowerForDifficulty(int num, double difficulty)
        {
            if (difficulty <= 0.3)
                return 2;
            else if (difficulty <= 0.6)
                return 3;
            else
                return 4;
        }
    }
}