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

        //Identifying Areas Header Labels
        public static string CallNumber = "Call Number";
        public static string Description = "Descriptions";
        //Key for Dictionary
        
        //Global random called
        public static Random rnd = new Random();

        public static decimal GetRandom(decimal min, decimal max)
        {//converts random number into a decimal
            return ((decimal)rnd.Next((int)(min * 100.00M), (int)(max * 100.00M))) / 100.00M;
        }
        public static List<decimal> RandomNumbers()
        {
            // adds a decimal number to the method that creates the Dewey List
            List<decimal> Dewey = new List<decimal>();
            //For loop loops 10 times to create 10 numbers
            for (int i = 1; i <= 10; i++)
            {


                Dewey.Add(GetRandom(100, 1000));

            }
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;

        }
       
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
    public class DeweyDecimalGroup
    {
        public int deweyKey { get; set; }
        public string deweyDescrip { get; set; }
    }
}