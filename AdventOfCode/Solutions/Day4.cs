namespace AdventOfCode.Solutions
{
    public class Day4
    {
        /// <summary>
        /// You have to figure out which of the numbers you have appear in the list of winning numbers. 
        /// The first match makes the card worth one point and each match after the first doubles the point value of that card.
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int points, sum = 0;
            string winningNumberStr, myNumberStr;
            List<int> winningNumbers, myNumbers;

            foreach (string line in File.ReadLines(@"Inputs/day4.txt"))
            {  
                points = 0;
                winningNumberStr = SubstringBetween(line, ":", "|").Trim();
                winningNumbers = winningNumberStr.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                myNumberStr = line[(line.IndexOf("|") +1 )..].Trim();
                myNumbers = myNumberStr.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

                foreach (var num in winningNumbers)
                {
                    if (myNumbers.Contains(num))
                    {
                        points = points == 0 ? 1 : points * 2;
                    }
                }

                sum += points;
            }

            return sum;
        }

        private static string SubstringBetween(string input, string start, string end)
        {
            int indexFrom = input.IndexOf(start) + start.Length;
            int indexTo = input.IndexOf(end);

            return input[indexFrom..indexTo];
        }
    }
}