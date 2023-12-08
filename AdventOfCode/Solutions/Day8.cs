using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions
{
    public class Day8
    {
        /// <summary>
        /// Starting at AAA, follow the left/right instructions. How many steps are required to reach ZZZ?
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int stepCount = 0;
            Direction direction;
            Dictionary<string, Direction> map = new();
            char[] pattern;
            MatchCollection matches;
            string key, left, right, currentStep;

            // Read data
            var lines = File.ReadAllLines(@"Inputs/day8.txt");
            pattern = lines.ElementAt(0).ToCharArray();

            for (var i = 2; i < lines.Length; i++)
            {
                matches = Regex.Matches(lines.ElementAt(i), @"([A-Z]{3}) = \(([A-Z]{3}), ([A-Z]{3})\)");
                key = matches[0].Groups[1].Value;
                left = matches[0].Groups[2].Value;
                right = matches[0].Groups[3].Value;
                map.Add(key, new Direction(left, right));
            }


            // Calculate route
            currentStep = "AAA";
            while (currentStep != "ZZZ")
            {
                direction = map[currentStep];

                if (pattern[(stepCount % pattern.Length)] == 'L')
                {
                    // go left
                    currentStep = direction.Left;
                }
                else
                {
                    // otherwise go right
                    currentStep = direction.Right;
                }

                stepCount++;
            }

            return stepCount;
        }

        private struct Direction
        {
            public Direction (string left, string right)
            {
                Left = left;
                Right = right;
            }

            public string Left { get; set; }
            public string Right { get; set; }
        }
    }
}