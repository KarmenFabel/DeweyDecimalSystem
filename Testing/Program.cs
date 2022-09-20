using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
       

           /* static void Main(string[] args)
            {
           //// RandomNumbers();

           // LetterList();
           // Console.WriteLine(Dewey.ToString());
            Console.WriteLine(LetterList());
            Console.ReadLine();

           





               }*/
        private static Random rnd = new Random();

        public static List<int> Dewey { get; private set; }

        //Generate 100 random numbers
        public static void ListJoin()
        {
           //  Create from beginning as one list

            
        }
        public static List<int> RandomNumbers()
            {
               
                string newLine = Environment.NewLine;
                int nums = rnd.Next(100, 1000);
                 Dewey = new List<int>();
                // txtNumbers.Text = nums.ToString();
                for (int i = 1; i <= 10; i++)
                {
                    nums = rnd.Next(100, 1000);
                    //txtNumbers.Text = txtNumbers.Text + newLine + nums.ToString();
                    Dewey.Add(nums);
                }
            for (int i = 0; i < Dewey.Count; i++);
            return Dewey;
        }
        static string RandomLetters(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
  

        }
        public static List<String> LetterList()
        {
            RandomLetters(3);
            var DeweyLetters = new List<String>();
            // txtNumbers.Text = nums.ToString();
            for (int i = 1; i <= 10; i++)
            {
                DeweyLetters.Add(RandomLetters(3));
            }
            for (int i = 0; i < DeweyLetters.Count; i++);
            return DeweyLetters;
            
        }
           
       
        }
    }
    //
   