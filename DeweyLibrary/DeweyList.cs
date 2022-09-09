using System;
using System.Collections.Generic;

namespace DeweyLibrary
{
    public class DeweyList
    {
        private static Random rnd = new Random();
        public static List<int> RandomNumbers()
        {
            string newLine = Environment.NewLine;
            int nums = rnd.Next(100, 1000);
            var Dewey = new List<int>();
           
            for (int i = 1; i <= 10; i++)
            {
                nums = rnd.Next(100, 1000);
                Dewey.Add(nums);
            }
            for (int i = 0; i < Dewey.Count; i++);
            return Dewey;
        }
    }

}
