namespace AdventOfCode.Solutions
{
    
    public class Day7
    {
        /// <summary>
        /// Find the rank of every hand in your set. What are the total winnings?
        /// </summary>
        /// <returns></returns>
        public static long Part1()
        {
            long winning, sum = 0;
            string[] data;
            List<Game> games = new List<Game>();
            Game game;
            CustomSort customSort = new CustomSort();

            foreach (string line in File.ReadLines(@"Inputs/day7.txt"))
            {  
                data = line.Split(" ");
                game = new Game
                {
                    Hand = data[0],
                    Bid = int.Parse(data[1]),
                    Type = GetHandType(data[0])
                };
                
                games.Add(game);
            }

            games = games.OrderByDescending(x => x.Type).ThenByDescending(x => x.Hand, customSort).ToList();
            for (var i = 0; i < games.Count; i++)
            {
                winning = games[i].Bid * (i+1);
                sum += winning;
            }

            return sum;
        }

        private class Game
        {
            public string Hand { get; set; } = string.Empty;
            public int Bid { get; set; }
            public HandType Type { get; set; }
        }

        private enum HandType
        {
            FiveOfAKind,
            FourOfAKind,
            FullHouse,
            ThreeOfAKind,
            TwoPair,
            OnePair,
            HighCard
        }

        private static HandType GetHandType(string hand)
        {
            var letters = hand.GroupBy(x => x).Select(x => new Characters(x.Key, x.Count())).ToList();

            if (letters.Count == 1 && letters[0].Count == 5)
            {
                return HandType.FiveOfAKind;
            }
            if (letters.Count == 2 && letters.Any(x => x.Count == 4))
            {
                return HandType.FourOfAKind;
            }
            if (letters.Count == 2 && letters.Any(x => x.Count == 3))
            {
                return HandType.FullHouse;
            }
            if (letters.Count == 3 && letters.Any(x => x.Count == 3))
            {
                return HandType.ThreeOfAKind;
            }
            if (letters.Count == 3 && letters.Where(x => x.Count == 2).Count() == 2)
            {
                return HandType.TwoPair;
            }
            if (letters.Count == 4 && letters.Any(x => x.Count == 2))
            {
                return HandType.OnePair;
            }

            return HandType.HighCard;
        }

        private struct Characters
        {
            public Characters(char character, int count)
            {
                Character = character;
                Count = count;
            }

            public char Character { get; }
            public int Count { get; }
        }

        private class CustomSort : IComparer<string>
        {
            public const string Order = "AKQJT98765432";

            public int Compare(string? a, string? b)
            {
                if (a == null)
                {
                    return b == null ? 0 : -1;
                }

                if (b == null)
                {
                    return 1;
                }

                int minLength = Math.Min(a.Length, b.Length);

                for (var i = 0; i < minLength; i++)
                {
                    int i1 = Order.IndexOf(a[i]);
                    int i2 = Order.IndexOf(b[i]);

                    if (i1 == -1)
                    {
                        throw new Exception(a);
                    }

                    if (i2 == -1)
                    {
                        throw new Exception(b);
                    }

                    int cmp = i1.CompareTo(i2);
                    if (cmp != 0)
                    {
                        return cmp;
                    }
                }

                return a.Length.CompareTo(b.Length);
            }
        }
    }
}