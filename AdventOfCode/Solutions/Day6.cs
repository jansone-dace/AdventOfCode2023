namespace AdventOfCode.Solutions
{
    public class Day6
    {
        /// <summary>
        /// Determine the number of ways you could beat the record in each race. 
        /// /// What do you get if you multiply these numbers together?
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int index = 0, distance, winCount, product = 1;
            List<RaceData> races = new List<RaceData>();
            string fileLine, dataLine;

            // Read data from file
            var lines = File.ReadLines(@"Inputs/day6.txt");
            fileLine = lines.ElementAt(0);
            dataLine = fileLine[(fileLine.IndexOf(":") +1 )..].Trim();

            foreach (var data in dataLine.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                races.Add(new RaceData { Time = int.Parse(data) });
            }

            fileLine = lines.ElementAt(1);
            dataLine = fileLine[(fileLine.IndexOf(":") +1 )..].Trim();

            foreach (var data in dataLine.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                races.ElementAt(index).Distance = int.Parse(data);
                index++;
            }


            // Do the calculations
            foreach (var race in races)
            {
                winCount = 0;
                for (int holdDuration = 1; holdDuration < race.Time - 1; holdDuration++)
                {
                    distance = (race.Time - holdDuration) * holdDuration;
                    if (distance > race.Distance)
                        winCount++;
                }

                product *= winCount;
            }

            return product;
        }

        private class RaceData
        {
            public int Time { get; set; }
            public int Distance { get; set; }
        }
    }
}