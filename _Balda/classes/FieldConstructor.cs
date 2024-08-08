using System;
using System.Collections.Generic;
using System.Linq;

namespace minigames._Balda.classes
{
    internal class FieldConstructor
    {
        private int FieldSize;
        private char[,] Field;
        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string[,,] Words;
        private int Wordscount;
        private string[] CurrentWords;
        private readonly Random rand;
        private int Difficulty;
        private bool Language;

        public FieldConstructor(string[,,] words)
        {
            Words = words;
            rand = new Random();
            GenerateCurrentWords();
        }

        public (char[,], string[]) CreateNewField(int size, bool language, int words_count, int difficulty)
        {
            FieldSize = size;
            Language = language;
            Wordscount = words_count;
            Difficulty = difficulty;
            Field = new char[FieldSize, FieldSize];
            GenerateField();
            return (Field, CurrentWords);
        }

        private void GenerateCurrentWords()
        {
            List<string> wordscopy = new List<string>();
            for (int i = 0; i < 30; i++)
                wordscopy.Add(Words[Language ? 0 : 1, Difficulty, i]);
            string[] currentWords = new string[Wordscount];
            for (int i = 0; i < Wordscount; i++)
            {
                int random = rand.Next(0, wordscopy.Count);
                currentWords[i] = wordscopy[random].ToUpper();
                wordscopy.Remove(wordscopy[random]);
            }
            CurrentWords = currentWords.ToArray();
        }

        private static bool SpaceOccupiedHorizontal(char[,] field, ref int iterator, ref int cycles, string word, int x, int y)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (field[x + i, y] != 0)
                {
                    cycles++;
                    iterator--;
                    return true;
                }
            }
            return false;
        }

        private static bool SpaceOccupiedVertical(char[,] field, ref int iterator, ref int cycles, string word, int x, int y)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (field[x, y + i] != 0)
                {
                    cycles++;
                    iterator--;
                    return true;
                }
            }
            return false;
        }

        private void GenerateField()
        {
            GenerateCurrentWords();
            for (int iterator = 0, cycles = 0; iterator < CurrentWords.Length; iterator++)
            {
                string word = CurrentWords[iterator];
                if (cycles > 200)
                {
                    Field = new char[FieldSize, FieldSize];
                    iterator = -1;
                    cycles = 0;
                    continue;
                }
                bool isVertical = rand.Next() % 2 == 1;
                bool backwards = rand.Next() % 2 == 1;
                if (backwards && !isVertical)
                {
                    char[] charArray = word.ToCharArray();
                    Array.Reverse(charArray);
                    word = new string(charArray);
                }
                if (isVertical)
                {
                    int x = rand.Next(0, FieldSize);
                    int y = rand.Next(0, FieldSize - word.Length);
                    if (SpaceOccupiedVertical(Field, ref iterator, ref cycles, word, x, y)) continue;
                    for (int i = 0; i < word.Length; i++)
                    {
                        Field[x, y] = word[i];
                        y++;
                    }
                }
                else
                {
                    int x = rand.Next(0, FieldSize - word.Length);
                    int y = rand.Next(0, FieldSize);
                    if (SpaceOccupiedHorizontal(Field, ref iterator, ref cycles, word, x, y)) continue;
                    for (int i = 0; i < word.Length; i++)
                    {
                        Field[x, y] = word[i];
                        x++;
                    }
                }
            }
            for (int x = 0; x < FieldSize; x++)
            {
                for (int y = 0; y < FieldSize; y++)
                {
                    if (Field[x, y] == 0)
                    {
                        if (Language)
                            Field[x, y] = RussianAlphabet[rand.Next(0, RussianAlphabet.Length)];
                        else
                            Field[x, y] = EnglishAlphabet[rand.Next(0, EnglishAlphabet.Length)];
                    }
                }
            }
        }
    }
}