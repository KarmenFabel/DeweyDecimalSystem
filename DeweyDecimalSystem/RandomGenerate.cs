using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalSystem
{
    class RandomGenerate
    {

        //Generate 100 random numbers
        
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
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;
        }

    }
}
//
//RandomNumbers from:
//https://www.youtube.com/watch?v=gog3_xnf86M&ab_channel=Web%26GraphicDesign-Stock%26OptionsTrading