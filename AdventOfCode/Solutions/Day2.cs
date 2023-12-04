using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions
{
    public class Day2
    {
        /// <summary>
        /// Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. 
        /// What is the sum of the IDs of those games?
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int gameId = 0, possibleGameSum = 0;

            foreach (string line in File.ReadLines(@"Inputs/day2.txt"))
            {  
                gameId++;

                var redMatches = Regex.Matches(line, @"\d+ red");
                if (!IsCubeCountPossible(redMatches, 12))
                    continue;

                var greenMatches = Regex.Matches(line, @"\d+ green");
                if (!IsCubeCountPossible(greenMatches, 13))
                    continue;

                var blueMatches = Regex.Matches(line, @"\d+ blue");
                if (!IsCubeCountPossible(blueMatches, 14))
                    continue;

                possibleGameSum += gameId;
            }

            return possibleGameSum;
        }

        /// <summary>
        /// For each game, find the minimum set of cubes that must have been present. 
        /// What is the sum of the power of these sets?
        /// </summary>
        /// <returns></returns>
        public static int Part2()
        {
            int maxRed, maxGreen, maxBlue, powers, powerSum = 0;

            foreach (string line in File.ReadLines(@"Inputs/day2.txt"))
            {  

                var redMatches = Regex.Matches(line, @"\d+ red");
                maxRed = BiggestMuchValue(redMatches);

                var greenMatches = Regex.Matches(line, @"\d+ green");
                maxGreen = BiggestMuchValue(greenMatches);

                var blueMatches = Regex.Matches(line, @"\d+ blue");
                maxBlue = BiggestMuchValue(blueMatches);

                powers = maxRed * maxGreen * maxBlue;
                powerSum += powers;
            }

            return powerSum;
        }

        private static bool IsCubeCountPossible(MatchCollection matches, int maxCubeCount)
        {
            foreach (Match match in matches)
            {
                var numStr = Regex.Match(match.Value, @"\d+").Value;
                var count = int.Parse(numStr);
                if (count > maxCubeCount)
                {
                    return false;
                }
            }

            return true;
        }

        private static int BiggestMuchValue(MatchCollection matches)
        {
            int maxValue = 0;

            foreach (Match match in matches)
            {
                var numStr = Regex.Match(match.Value, @"\d+").Value;
                var number = int.Parse(numStr);
                if (number > maxValue)
                    maxValue = number;
            }

            return maxValue;
        }
    }
}