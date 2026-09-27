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
            List<int> PickingNumbersArray = new List<int> { 1, 1, 3, 4, 4, 5, 5, 6 };

            List<int> arr = new List<int> { 2, 4 };
            List<int> heights = new List<int> { 2, 9, 4, 5, 2 };

            List<int> brr = new List<int> { 16, 32, 96 };
            List<int> ranked = new List<int> { 100, 100, 50, 40, 40, 20, 10 };
            List<int> players = new List<int> { 5, 25, 50, 120 };
            List<int> charHeights = new List<int> { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 1, 2, 5, 1, 2, 3, 4, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> arrivalTime = new List<int> { -1, -3, 4, 2 };
            List<int> beautifullDaysParameter = new List<int> { 20, 23, 6 };
            List<int> a = new List<int> { 10, 20, 30, 40 };
            List<int> queries = new List<int> { 0,2 };
            int[] cloud = new int[] { 0, 0, 1, 0, 0, 1, 1, 0 };
            string s = "hackerhappy";
            string t = "hackerrank";
            arr = new List<int> { 278, 576, 496, 727, 410, 124, 338, 149, 209, 702, 282, 718, 771, 575, 436 };
            int result = Program.nonDivisibleSubset(10,arr);

            Console.WriteLine(string.Join(", ", result));
            //Console.WriteLine(result);

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
                char aas = s[commonPrefix];
                char aat = t[commonPrefix];
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
        public static List<int> circularArrayRotation(List<int> a, int k, List<int> queries)
        {
            List<int> bOld = new List<int>();
            List<int> b = new List<int>();
            int newIndex = 0;
            int oldIndex = 0;
            for (int i = 0; i < a.Count; i++)
            {
                oldIndex = (i + k) % a.Count; // Move to left by k positions
                newIndex = (i - k) % a.Count; // Move to right by k positions
                // Adjust for negative indices
                if (newIndex < 0)
                {
                    newIndex += a.Count;
                }   
                bOld.Add(a[oldIndex]);
                b.Add(a[newIndex]);
            }
            // Below is the original code that was commented out, which calculates the result based on the queries after rotation.
            //for (int i = 0; i < queries.Count; i++)
            //{

            //    int index = (queries[i] - k) % a.Count;
            //    if (index < 0)
            //    {
            //        index += a.Count;
            //    }
            //    b.Add(a[index]);
            //}
            return bOld;
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
