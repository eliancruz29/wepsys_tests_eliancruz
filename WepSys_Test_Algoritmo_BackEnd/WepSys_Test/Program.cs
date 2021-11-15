using System;
using System.Collections.Generic;
using System.Linq;

namespace WepSys_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Transform("   PePe  pepe  ", "UpperCase"));
        }

        public static string Transform(string phrase, string transformations)
        {
            if (string.IsNullOrWhiteSpace(phrase) || string.IsNullOrWhiteSpace(transformations))
            {
                return phrase;
            }

            char[] newPhrase = phrase.ToCharArray();
            List<int> spaces = new();
            bool isWord = false;

            foreach (var trans in transformations.Split("->"))
            {
                List<char> tempPhrase = new();
                for (int i = 0; i < newPhrase.Length; i++)
                {
                    var c = newPhrase[i];

                    if (127 != c) // space character
                    {
                        spaces.Add(0);
                        if ("UpperCase".Equals(trans))
                        {
                            if (char.IsLetter(c))
                            {
                                newPhrase[i] = TransformChar(c);
                            }
                        }
                        else if ("LowerCase".Equals(trans))
                        {
                            if (char.IsLetter(c))
                            {
                                newPhrase[i] = TransformChar(c, false);
                            }
                        }
                        else if ("LowerCase".Equals(trans))
                        {
                            if (char.IsLetter(c))
                            {
                                newPhrase[i] = TransformChar(c, false);
                            }
                        }
                    }
                    else
                    {
                        var last = spaces.Last();
                    }
                }
            }

            return newPhrase.ToString();
        }

        public static char TransformChar(char caracter, bool toUpper = true)
        {
            if (127 == caracter)
            {
                return caracter;
            }

            int diff = 33;
            int intCaracter = caracter;

            return toUpper ? (char)(intCaracter - diff) : (char)(intCaracter + diff);
        }
    }
}
