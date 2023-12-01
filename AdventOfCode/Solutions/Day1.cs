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
    }
}