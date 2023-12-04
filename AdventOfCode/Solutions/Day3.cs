namespace AdventOfCode.Solutions
{
    public class Day3
    {
        /// <summary>
        /// What is the sum of all of the part numbers in the engine schematic?
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            string numberBuilder = "0";
            int sum = 0;
            bool hasAdjacentSymbol = false;

            char[][] input = File.ReadLines(@"Inputs/day3.txt").Select(x => x.ToCharArray()).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (hasAdjacentSymbol)
                {
                    sum += int.Parse(numberBuilder);
                }

                numberBuilder = "0";
                hasAdjacentSymbol = false;

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (char.IsNumber(input[i][j]))
                    {
                        if ((j == 0 || IsNumberOrDot(input[i][j-1])) && 
                            (j == input[i].Length - 1 || IsNumberOrDot(input[i][j+1])) && 
                            (i == 0 || IsNumberOrDot(input[i-1][j])) && 
                            (i == 0 || j == 0 || IsNumberOrDot(input[i-1][j-1])) &&
                            (i == 0 || j == input[i].Length - 1 || IsNumberOrDot(input[i-1][j+1])) &&
                            (i == input.Length - 1 || IsNumberOrDot(input[i+1][j])) &&
                            (i == input.Length - 1 || j == 0 || IsNumberOrDot(input[i+1][j-1])) &&
                            (i == input.Length - 1 || j == input[i].Length - 1 || IsNumberOrDot(input[i+1][j+1])))
                            {
                                
                            }
                            else
                            {
                                hasAdjacentSymbol = true;
                            }

                            numberBuilder += input[i][j];
                    }
                    else
                    {
                        if (hasAdjacentSymbol)
                        {
                            sum += int.Parse(numberBuilder);
                            numberBuilder = "0";
                            hasAdjacentSymbol = false;
                        }
                        else
                        {
                            numberBuilder = "0";
                        }
                    }
                }
            }

            return sum;
        }

        private static bool IsNumberOrDot(char value)
        {
            return char.IsNumber(value) || value == '.';
        }
    }
}