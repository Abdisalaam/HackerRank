using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<string> topics = new List<string> { "10101","11110", "00010" };

            List<int> result = Program.acmTeam(topics);           
            Console.WriteLine(string.Join(", ", result));
            //Console.WriteLine(result);          

        }
        public static long taumBday(int b, int w, int bc, int wc, int z)
        {
            long bcCost = 0;
            long wcCost = 0;

            if (bc > wc + z)
            {
                bcCost = wc + z;
            }
            else { bcCost = bc; }

            if (wc > bc + z)
            {
                wcCost = bc + z;
            }
            else
            {
                wcCost = wc;
            }
                return (b * bcCost) + (w * wcCost);
        }
        public static List<int> acmTeam(List<string> topic)
        {
            int maxTopics = 0;
            int teamCount = 0;

            // Compare every pair of people
            for (int i = 0; i < topic.Count; i++)
            {
                for (int j = i + 1; j < topic.Count; j++)
                {
                    int knownTopics = 0;

                    // Compare topic-by-topic
                    for (int k = 0; k < topic[i].Length; k++)
                    {
                        // If either person knows the topic, the team knows it
                        if (topic[i][k] == '1' || topic[j][k] == '1')
                        {
                            knownTopics++;
                        }
                    }
                    // Update maximum and count
                    if (knownTopics > maxTopics)
                    {
                        maxTopics = knownTopics;
                        teamCount = 1;   // reset count because we found a new max
                    }
                    else if (knownTopics == maxTopics)
                    {
                        teamCount++;     // another team with same max
                    }
                }
            }

            return new List<int> { maxTopics, teamCount };
        }
        public static int queensAttack(int n, int NumberOfObsticals, int QueenRow, int QueenColoum, List<List<int>> obstacles)
        {
            // Maximum possible moves in each direction (no obstacles)
            int up = n - QueenRow;
            int down = QueenRow - 1;
            int right = n - QueenColoum;
            int left = QueenColoum - 1;

            int diagnoalupLeft = Math.Min(up, left);
            int diagnoalupRight = Math.Min(up, right);
            int diagnoaldownLeft = Math.Min(down, left);
            int diagnoaldownRight = Math.Min(down, right);

            // Process obstacles
            foreach (var obstacle in obstacles)
            {
                int ObstcalRow = obstacle[0];
                int ObsticalCouloum = obstacle[1];

                // Same column
                if (ObsticalCouloum == QueenColoum)
                {
                    if (ObstcalRow > QueenRow)
                    {
                        
                        up = Math.Min(up, ObstcalRow - QueenRow - 1); 
                    }

                    else
                    { 
                        down = Math.Min(down, QueenRow - ObstcalRow - 1); 
                    }
                }

                // Same row
                else if (ObstcalRow == QueenRow)
                {
                    if (ObsticalCouloum > QueenColoum)
                    {
                        right = Math.Min(right, ObsticalCouloum - QueenColoum - 1);
                    }
                    else
                    { left = Math.Min(left, QueenColoum - ObsticalCouloum - 1); 
                    }
                }

                // Diagonals
                else if (Math.Abs(ObstcalRow - QueenRow) == Math.Abs(ObsticalCouloum - QueenColoum))
                {
                    // Up-left
                    if (ObstcalRow > QueenRow && ObsticalCouloum < QueenColoum)
                    {
                        diagnoalupLeft = Math.Min(diagnoalupLeft, ObstcalRow - QueenRow - 1);
                    }                       

                    // Up-right
                    else if (ObstcalRow > QueenRow && ObsticalCouloum > QueenColoum)
                    {
                        diagnoalupRight = Math.Min(diagnoalupRight, ObstcalRow - QueenRow - 1);
                    }
                        

                    // Down-left
                    else if (ObstcalRow < QueenRow && ObsticalCouloum < QueenColoum)
                    {
                        diagnoaldownLeft = Math.Min(diagnoaldownLeft, QueenRow - ObstcalRow - 1);
                    }
                       

                    // Down-right
                    else if (ObstcalRow < QueenRow && ObsticalCouloum > QueenColoum)
                    {
                        diagnoaldownRight = Math.Min(diagnoaldownRight, QueenRow - ObstcalRow - 1);
                    }
                        
                }
            }

            return up + down + left + right + diagnoalupLeft + diagnoalupRight + diagnoaldownLeft + diagnoaldownRight;
        }
        public static int equalizeArray(List<int> arr)
        {
            var freq = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!freq.ContainsKey(num))
                { freq[num] = 1; }
                else
                {
                    freq[num]++;
                }                    
            }
            int maxFrequency = freq.Values.Max();
            return arr.Count - maxFrequency;
        }


        public static int jumpingOnClouds(List<int> c)
        {
            int count = 0;           
            for (int i = 0; i < c.Count - 1;)
            {               
                if (i + 2 < c.Count  && c[i + 2] == 0)
                {
                    i += 2;                   
                }
                else
                {
                    i += 1;                  

                }
                count++;
            }           
            return count;
        }
        public static long repeatedString(string s, long n)
        {
           
            long length = s.Length;

            long countInS = s.Count(c => c == 'a');
            if (length == countInS)
            {
                return n;
            }

            long fullRepeats = n / length;

            long remainder = n % length;

            long countInRemainder = s.Substring(0, (int)remainder).Count(c => c == 'a');

            return (fullRepeats * countInS) + countInRemainder;

        }
        public static int nonDivisibleSubset(int k, List<int> numbers)
        {
            // Frequency array for remainders 0..k-1
            var freq = new int[k];

            // Count how many numbers fall into each remainder bucket
            foreach (var num in numbers)
            {
                freq[num % k]++;
            }

            int result = 0;

            // Remainder 0: only one allowed
            if (freq[0] > 0)
                result++;

            // Process remainder pairs (i, k - i)
            for (int i = 1; i <= k / 2; i++)
            {
                int opposite = k - i;

                // Special case: when k is even and i == k/2
                if (i == opposite)
                {
                    // Only one number with remainder k/2 can be included
                    result += 1;
                }
                else
                {
                    // Choose the larger group between remainder i and remainder (k - i)
                    result += Math.Max(freq[i], freq[opposite]);
                }
            }

            return result;
        }
        public static List<int> cutTheSticks(List<int> arr)
        {
            int count = 0;
            List<int> sticksHasbeenCut = new List<int>();
            
            for (int i = 0; i < arr.Count; i++)              
            {
                int min = arr.Where(x => x != 0)
             .DefaultIfEmpty(int.MaxValue)
             .Min();
                for (int j = 0; j < arr.Count; j++)
                {
                    
                    if (arr[j] >= min)
                    {
                        arr[j] -= min;
                        count++;
                    }
                }
                if (count != 0)
                {
                    sticksHasbeenCut.Add(count);
                }
               
                count = 0;

            }
            return sticksHasbeenCut;
        }

        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            const int DAY_FINE = 15;
            const int MONTH_FINE = 500;
            const int YEAR_FINE = 10000;

            if (y1 > y2)
                return  YEAR_FINE;

            if (y1 == y2 && m1 > m2)
                return (m1 - m2) * MONTH_FINE;

            if (y1 == y2 && m1 == m2 && d1 > d2)
                return (d1 - d2) * DAY_FINE;

            return 0;
        }

        public static int squares(int a, int b)
        {
           
            int start = (int)Math.Ceiling(Math.Sqrt(a));
            int end = (int)Math.Floor(Math.Sqrt(b));

            if (end < start)
                return 0;

            return end - start + 1;
        }
        public static string appendAndDelete(string s, string t, int k)
        {
            if (s.Length + t.Length <= k)
                return "Yes";

            int commonPrefix = 0;
            int minLength = Math.Min(s.Length, t.Length);

            while (commonPrefix < minLength && s[commonPrefix] == t[commonPrefix])
            {                
                commonPrefix++;
            }


            int requiredOps = (s.Length - commonPrefix) + (t.Length - commonPrefix);

            if (requiredOps <= k && (k - requiredOps) % 2 == 0)
                return "Yes";

            return "No";
        }
        public static void extraLongFactorials(int n)
        {
            BigInteger resulrt = 1;
            for (int i = n  ; i > 0; i--)
            {
                resulrt *= (i);
            }
            Console.WriteLine(resulrt);
        }

        public static int findDigits(int n)
        {
            int count = 0;
            int number = n;
            while (number > 0)
            {
                int digit = number % 10;
                if (digit != 0 && n % digit == 0)
                {
                    count++;
                }
                number /= 10;
            }
           
            return count;
        }
        static int jumpingOnClouds(int[] c, int k)
        {
            int energy = 100;
            int n = c.Length;
            int i = 0;

            do
            {
                
                i = (i + k) % n;
                energy -= c[i] == 1 ? 3 : 1;
            }
            while (i != 0);

            return energy;
        }

        public static List<int> permutationEquation(List<int> p)
        {
            List<int> allYs = new List<int>();
            for (int x = 1; x <= p.Count; x++)
            {
                int k = p.IndexOf(x) + 1;
                int y = p.IndexOf(k) + 1;
                allYs.Add(y);
            }
            return allYs;

        }
        public static List<int> circularArrayRotation(List<int> a, int k)
        {
            List<int> b = new List<int>();            
           
            for (int i = 0; i < a.Count; i++)
            {
                int index = (a[i] - k) % a.Count;
                if (index < 0)
                {
                    index += a.Count;
                }
                b.Add(a[index]);
            }
            return b;
        }
        public static int saveThePrisoner(int n, int m, int s)
        {
            int prisoner = 0;            
              int staringpoint = s;
                for (int i = 1; i <= m; i++)
                {

                    if (staringpoint > n)
                    {
                        staringpoint = 1;
                    }
                    prisoner = staringpoint;
                    staringpoint++;
                }            
            
            return prisoner;
            // below is the optimized solution
            //return ((s - 1 + m - 1) % n) + 1;

        }
        public static int viralAdvertising(int n)
        {
            int shared = 5;
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
               
                int liked = shared / 2;
                shared = liked * 3;
                 result += liked;
            }
            return result;
        }
        public static int beautifulDays(int i, int j, int k)
        {
            int count = 0;
            for (int day = i; day <= j; day++)
            {
                int reversedDay = int.Parse(new string(day.ToString().Reverse().ToArray()));
                if (Math.Abs(day - reversedDay) % k == 0)
                {
                   count++;
                }
            }

            return count;
        }
        public static string angryProfessor(int k, List<int> a)
        {
           
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] <= 0)
                {
                    k--;
                }
            }
            if (k <= 0)
            {
                return "NO";
            }
            return "YES";
        }
        public static int utopianTree(int n)
        {
            int height = 0;
            if (n == 0)
            {
                return 1;
            }
            if (n == 1)
            {
                return 2;
            }
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    height = 1;
                }
                if (i == 1)
                {
                    height +=  2;
                }
                if (i > 1)
                {
                    if (i % 2 == 0)
                    {
                        height *= 2;
                    }
                    else
                    {
                        height += 1;
                    }
                }
            }
            return height;
        }
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> distinctRanked = ranked.Distinct().ToList();
            List<int> result = new List<int>();

            // Start pointer from the bottom (lowest score) of the distinct leaderboard
            int index = distinctRanked.Count - 1;

            // Iterate through each score of the player
            foreach (int playerScore in player)
            {
                // Move up the leaderboard while the player's score is greater than or equal to the leaderboard score
                while (index >= 0 && playerScore >= distinctRanked[index])
                {
                    index--;
                }

                // The rank is the index + 2 because index is 0-based and we moved past the matching/lower score
                result.Add(index);
            }

            return result;
        }

        public static List<int> ClimbingLeaderboardBinary(List<int> ranked, List<int> player)
        {
            // Remove duplicates and keep descending order
            List<int> distinctRanked = ranked.Distinct().ToList();

            List<int> result = new List<int>();

            foreach (int score in player)
            {
                int rank = GetRank(distinctRanked, score);
                result.Add(rank);
            }

            return result;
        }

        // Binary search to find the correct rank
        private static int GetRank(List<int> ranked, int score)
        {
            int left = 0;
            int right = ranked.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (score == ranked[mid])
                {
                    return mid + 1; // exact match → rank = mid+1
                }
                else if (score > ranked[mid])
                {
                    right = mid - 1; // move left (toward higher scores)
                }
                else
                {
                    left = mid + 1; // move right (toward lower scores)
                }
            }

            // If not found, left is the insertion point → rank = left + 1
            return left + 1;
        }

        public static void _getTotalX(List<int> a, List<int> b)
        {
            int count = 0;

            int maxNumber = a.Max();
            int minNumber = b.Min();

            for (int i = maxNumber; i <= minNumber; i++)
            {
                bool isFactor = true;
                int currentNumber = i;

                foreach (var number in a)
                {
                    if (currentNumber % number != 0)
                    {
                        isFactor = false;
                        break;
                    }
                }
                if (isFactor)
                {
                    foreach (var number in b)
                    {
                        if (number % currentNumber != 0)
                        {
                            isFactor = false;
                            break;
                        }
                    }

                }
                if (isFactor)
                {

                    count++;
                }

            }

            Console.WriteLine(count);

        }


        public static int pickingNumbers(List<int> a)
        {
            a.Sort();

            int longest = 1;

            for (int i = 0; i < a.Count; i++)
            {
                int count = 1;

                for (int j = i + 1; j < a.Count; j++)
                {
                    if (Math.Abs(a[j] - a[i]) <= 1)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count > longest)
                {
                    longest = count;
                }
            }

            return longest;
        }

        public static int hurdleRace(int k, List<int> height)
        {
            int result = 0;
            int maxHeight = height.Max();
            if ((k >= 1 && height.Count >= 1) && (k <= 100 && height.Count <= 100))
            {
                if (k < maxHeight)
                {
                    result = Math.Abs(maxHeight - k);
                }


            }


            return result;
        }

        public static int designerPdfViewer(List<int> heights, string word)
        {
            int result = 0;
            List<char> alphabet = new List<char>
            {  
                'a','b','c','d','e','f','g','h','i','j','k','l','m',  
                'n','o','p','q','r','s','t','u','v','w','x','y','z'
            };

            int maxHeight = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int index = alphabet.IndexOf(word[i]);
                if (heights[index] > maxHeight)
                {
                    maxHeight = heights[index];
                   
                }
            }
            result = word.Length * maxHeight;
            return result;
        }


    }
}
