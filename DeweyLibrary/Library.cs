using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyLibrary
{

    public class Library
    {
        public static int ticks;
        public static Random rnd = new Random();

        public static decimal GetRandom(decimal min, decimal max)
        {
            return ((decimal)rnd.Next((int)(min * 100.00M), (int)(max * 100.00M))) / 100.00M;
        }
        public static List<decimal> RandomNumbers()
        {
            List<decimal> Dewey = new List<decimal>();
            for (int i = 1; i <= 10; i++)
            {


                Dewey.Add(GetRandom(100, 1000));

            }
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;

        }
        /*
        /// <summary>
        /// List method to create a random List
        /// </summary>
        /// <returns>dewey</returns>
        /// 
        public static List<int> RandomNumbers()
        {
            List<int> dewey = new List<int>();

            for (int i = 1; i <= 10; i++)
            {
                int nums = rnd.Next(100, 1000);
                dewey.Add(nums);
            }
            for (int i = 0; i < dewey.Count; i++) ;
            return dewey;
        }
        */
        /// <summary>
        /// Selection Sort method
        /// </summary>
        /// <param name="sorted"></param>
        /// <returns></returns>
        public static List<decimal> Sorted(List<decimal> sorted)
        {
            int j;
            int minIndex;
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                minIndex = i;
                for (j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[j] < sorted[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    decimal temp = sorted[minIndex];
                    sorted[minIndex] = sorted[i];
                    sorted[i] = temp;
                }
            }
            return sorted;
        }

       public static int splitsec = 0;
        public static int secs = 0;
       public static int mins = 0;
    }
}