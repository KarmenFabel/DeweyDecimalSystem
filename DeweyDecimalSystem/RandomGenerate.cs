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
        static void RandomNumbers()
        {
            Random rnd = new Random();
            string newLine = Environment.NewLine;
            int nums = rnd.Next(0, 1001);
            var Dewey = new List<int>();
            // txtNumbers.Text = nums.ToString();
            Dewey.Add(1);
            Dewey.Add(2);
            Dewey.Add(3);
            for (int i = 1; i <= 10; i++)
            {
                nums = rnd.Next(0, 1001);
                //txtNumbers.Text = txtNumbers.Text + newLine + nums.ToString();
               // Dewey.Add(nums);
            }
           // for (int i = 0; i < Dewey.Count; i++)

                Console.WriteLine(Dewey);
            Console.ReadLine();

        }
        static void DeweyList()
        {
            List<Decimal> Dewey = new List<Decimal>();

            for(float i = 1f; i <= 3f; i +=0.5f)
            {
                //nums
            }
        }
        
       
    }
}
//
//RandomNumbers from:
//https://www.youtube.com/watch?v=gog3_xnf86M&ab_channel=Web%26GraphicDesign-Stock%26OptionsTrading