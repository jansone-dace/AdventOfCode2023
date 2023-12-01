namespace AdventOfCode.Solutions
{
    public static class Day1
    {
        /// <summary>
        /// Finds sum of values that consists of 2-digit number, where each number is made of first and last digit in a string
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int firstDigit = 0, secondDigit = 0, combinedNumber, sum = 0;

            foreach (string line in File.ReadLines(@"Inputs/day1.txt"))
            {  
                for (int i = 0; i < line.Length; i++)
                {
                    if (int.TryParse(line[i].ToString(), out firstDigit))
                    {
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(line[i].ToString(), out secondDigit))
                    {
                        break;
                    }
                }

                combinedNumber = int.Parse($"{firstDigit}{secondDigit}");
                sum += combinedNumber;
            }

            return sum;
        }

        /// <summary>
        /// Finds sum of values that consists of 2-digit number, where each number is made of first and last digit in a string.
        /// Digits can be representet both as numeric digits or textual representations in English (e.g., one, two, three, etc.)
        /// </summary>
        /// <returns></returns>
        public static int Part2()
        {
            int firstDigit = 0, secondDigit = 0, combinedNumber, sum = 0;

            foreach (string line in File.ReadLines(@"Inputs/day1.txt"))
            {  
                for (int i = 0; i < line.Length; i++)
                {
                    if (GetIntegerFromString(line[i..], out firstDigit))
                    {
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (GetIntegerFromString(line[i..], out secondDigit))
                    {
                        break;
                    }
                }

                combinedNumber = int.Parse($"{firstDigit}{secondDigit}");
                sum += combinedNumber;
            }

            return sum;
        }

        private static bool GetIntegerFromString(string input, out int digit)
        {
            if (input[0] == '1' || input.StartsWith("one"))
            {
                digit = 1;
                return true;
            }
            if (input[0] == '2' || input.StartsWith("two"))
            {
                digit = 2;
                return true;
            }
            if (input[0] == '3' || input.StartsWith("three"))
            {
                digit = 3;
                return true;
            }
            if (input[0] == '4' || input.StartsWith("four"))
            {
                digit = 4;
                return true;
            }
            if (input[0] == '5' || input.StartsWith("five"))
            {
                digit = 5;
                return true;
            }
            if (input[0] == '6' || input.StartsWith("six"))
            {
                digit = 6;
                return true;
            }
            if (input[0] == '7' || input.StartsWith("seven"))
            {
                digit = 7;
                return true;
            }
            if (input[0] == '8' || input.StartsWith("eight"))
            {
                digit = 8;
                return true;
            }
            if (input[0] == '9' || input.StartsWith("nine"))
            {
                digit = 9;
                return true;
            }

            digit = 0;
            return false;
        }
    }
}