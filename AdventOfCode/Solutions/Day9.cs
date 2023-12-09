namespace AdventOfCode.Solutions
{
    public class Day9
    {
        /// <summary>
        /// Analyze your OASIS report and extrapolate the next value for each history. What is the sum of these extrapolated values?
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int lastElement, sum = 0;
            List<List<int>> history;
            List<int> innerList, lastList;

            foreach (string line in File.ReadLines(@"Inputs/day9.txt"))
            {  
                history = new();
                innerList = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                history.Add(innerList);

                while (!innerList.All(x => x == 0))
                {
                    innerList = new();
                    lastList = history.Last();
                    for (var i = 0; i < lastList.Count - 1; i++)
                    {
                        innerList.Add(lastList[i+1] - lastList[i]);
                    }
                    history.Add(innerList);
                }

                lastElement = 0;
                for (var i = history.Count - 2; i >= 0; i--)
                {
                    lastElement += history.ElementAt(i).Last();
                }

                sum += lastElement;
            }

            return sum;
        }
    }
}