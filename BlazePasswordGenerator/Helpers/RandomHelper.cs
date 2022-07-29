using System;
using System.Security.Cryptography;

namespace BlazePasswordGenerator.Helpers
{
	public class RandomHelper
	{
        private readonly Random? random;

        public RandomHelper()
        {
            random = new Random();
        }

        public string GetRandomNumber()
        {
            if (random is not null)
                return random.Next(0, 9).ToString();
            else return "0";
        }

        public char GetRandomChar(bool includeUpper)
        {
            Char[] charsLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Char[] charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            if (random is null) return 'a';

            if (includeUpper)
            {
                int index = random.Next(0, 25);
                return charsUpper[index];
            }
            else
            {
                int index = random.Next(0, 25);
                return charsLower[index];
            }
        }

        public char GetRandomSymbols()
        {
            if (random is null) return '!';

            Char[] charSymbols = "$%#@!*;:".ToCharArray();
            int index = random.Next(charSymbols.Length);
            return charSymbols[index];
        }

        public string GeneratePassword(List<string> filters, int length)
        {
            int randomChoice = 0;
            string generatedPassword = string.Empty;

            if (filters is not null && random is not null)
            {
                for (int i = 0; i < length; i++)
                {
                    randomChoice = random!.Next(0, filters.Count);
                    switch (filters[randomChoice])
                    {
                        case "upper":
                            generatedPassword += GetRandomChar(true); 
                            break;
                        case "numbers":
                            generatedPassword += GetRandomNumber();
                            break;
                        case "symbols":
                            generatedPassword += GetRandomSymbols();
                            break;
                        case "lower":
                            generatedPassword += GetRandomChar(false);
                            break;
                        default:
                            break;

                    }
                }
            }

            return generatedPassword;
        }
    }
}
