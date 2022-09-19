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
        public static Random rnd = new Random();
        /// <summary>
        /// List method to create a random List
        /// </summary>
        /// <returns>dewey</returns>
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
        /// <summary>
        /// Selection Sort method
        /// </summary>
        /// <param name="sorted"></param>
        /// <returns></returns>
        public static List<int> Sorted(List<int> sorted)
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
                    int temp = sorted[minIndex];
                    sorted[minIndex] = sorted[i];
                    sorted[i] = temp;
                }
            }
            return sorted;
        }
       

    }
}

