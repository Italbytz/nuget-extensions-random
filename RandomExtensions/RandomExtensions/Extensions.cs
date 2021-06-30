using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomExtensions
{
    public static class Extensions
    {
        // Return a random value between 0 inclusive and max exclusive.
        public static double NextDouble(this Random rand, double max)
        {
            return rand.NextDouble() * max;
        }

        // Return a random value between min inclusive and max exclusive.
        public static double NextDouble(this Random rand,
            double min, double max)
        {
            return min + (rand.NextDouble() * (max - min));
        }

        public static int RollDie(this Random rand, int sides)
        {
            return rand.Next(0, sides) + 1;
        }

        public static void Shuffle<T>(this Random rand, T[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        public static T RandomElement<T>(this Random rand, T[] array)
        {
            return array[rand.Next(0, array.Length)];
        }

        public static int[] NextIntArray(this Random rand, int size, int min, int max)
        {
            return Enumerable
                .Repeat(0, size)
                .Select(i => rand.Next(min, max + 1))
                .ToArray();
        }

        public static int[] NextUniqueIntArray(this Random rand, int size, int min, int max)
        {
            if (size > max) throw new Exception("Size is not allowed to be more than max");
            var orderedList = Enumerable.Range(min, max + 1);
            return orderedList.OrderBy(c => rand.Next()).Take(size).ToArray();
        }

        public static string[] ShuffledStrings(this Random rand, string[] arr)
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            foreach (string s in arr)
            {
                list.Add(new KeyValuePair<int, string>(rand.Next(), s));
            }
            var sorted = from item in list
                         orderby item.Key
                         select item;
            string[] result = new string[arr.Length];
            int index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            return result;
        }
    }
}
