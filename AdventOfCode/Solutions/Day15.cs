namespace AdventOfCode.Solutions
{
    public class Day15
    {
        /// <summary>
        /// Run the HASH algorithm on each step in the initialization sequence. What is the sum of the results?
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int currentValue, sum = 0;

            var input = File.ReadAllText(@"Inputs/day15.txt");
            var steps = input.Split(",");

            foreach (string step in steps)
            {
                currentValue = 0;
                foreach (char symbol in step)
                {
                    currentValue += (int)symbol;
                    currentValue *= 17;
                    currentValue %= 256;
                }

                sum += currentValue;
            }

            return sum;
        }
    }
}