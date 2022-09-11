using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class SortTest
    {  
          private static Random rnd = new Random();
        List<int> Dewey { get; set; }
        public static void Main (String[] args)
        {
            Console.WriteLine(RandomNumbers());
           // int[] selection_sort_numbers = { 7, 45, 12, 22, 555, 1, 2, 999, 7 };
            for(int i = 0; i < RandomNumbers().Count; i++)
            {
                Console.Write(" " + RandomNumbers()[i]);
            }
            
            Console.WriteLine(" ");
            Console.WriteLine("Selecontion sort");
            Selection_Sort(RandomNumbers());
            Console.ReadLine();
            
        }
        public static void Selection_Sort(List<int> ss_arr)
        {
            //Min position to keep track of position from lowest value
            int min_position;
            //temp to conduct swap during selection sort
            int temp;

            for(int i=0; i< ss_arr.Count; i ++)
            {
                //initialize min position to index of array
                min_position = i;
                //from min positon check if next element is smaller
                for( int x =i +1; x <ss_arr.Count; x++)
                {
                    //if smaller then make new min position
                    if(ss_arr[x]< ss_arr[min_position])
                    {
                        //min position keeps track of the index that min is in 
                        min_position = x;

                    }
                }//end of inner loop
                //if min does not equal current element in loop then swap initialted
                if(min_position!=i)
                {
                    temp = ss_arr[i];
                    ss_arr[i] = ss_arr[min_position];
                    ss_arr[min_position] = temp;
                            
                }
                Console.Write(" " + ss_arr[i]);
            }
        }

        public static List<int> RandomNumbers()
        {

            string newLine = Environment.NewLine;
            int nums = rnd.Next(100, 1000);
           List<int> Dewey = new List<int>();
            // txtNumbers.Text = nums.ToString();
            for (int i = 1; i <= 10; i++)
            {
                nums = rnd.Next(100, 1000);
                //txtNumbers.Text = txtNumbers.Text + newLine + nums.ToString();
                Dewey.Add(nums);
            }
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;
            
        }
    }
}
