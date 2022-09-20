using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    /*
     * Class Foo{
   String f1;
   Integer f2;
}

Foo[] array=new Foo[10];*/
    class SortTest
    {  
          private static Random rnd = new Random();
       
        
      
        public static void Main (String[] args)
        {
            //Console.WriteLine(DoubleRandom());
           // int[] selection_sort_numbers = { 7, 45, 12, 22, 555, 1, 2, 999, 7 };
            for(int i = 0; i < NewL().Count; i++)
            {
                Console.Write(" " + NewL()[i]);
            }
            
            Console.WriteLine(" ");
            
            Console.ReadLine();
            

        }


        // returns a random decimal value in the range [min, max)
        // allowing for steps different outcomes.
        public static decimal GetRandom(decimal min, decimal max)
        {
            return ((decimal)rnd.Next((int)(min * 100.00M), (int)(max * 100.00M))) / 100.00M;
        }
        public static List<decimal> NewL( )
        {
            List<decimal> DDewey = new List<decimal>();
            for (int i = 1; i <= 10; i++)
            {

                
                DDewey.Add(GetRandom(100, 1000));
                
            }
            for (int i = 0; i < DDewey.Count; i++) ;
            return DDewey;

        }
        public static List<double> DoubleRandom()
        {
            //private static Random rnd = new Random();
            //var random = new Random();


            List<double> DDewey = new List<double>();
            // txtNumbers.Text = nums.ToString();
            for (int i = 1; i <= 10; i++)
            {
                double nums = rnd.Next(100, 1000);

                DDewey.Add(nums);
            }
            for (int i = 0; i < DDewey.Count; i++) ;
            return DDewey;
        }
        public static List<int> NewList()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < RandomNumbers().Count; i++)
            {
                List<int>one = RandomNumbers();
                List<int>two = RandomNumbers2();
                //list.Add(one);
                

            }


            List<int> Dewey = new List<int>();
            // txtNumbers.Text = nums.ToString();
            for (int i = 1; i <= 10; i++)
            {
                int nums = rnd.Next(100, 1000);

                Dewey.Add(nums);
            }
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;

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
            //int nums = rnd.Next(100, 1000);
           List<int> Dewey = new List<int>();
            // txtNumbers.Text = nums.ToString();
            for (int i = 1; i <= 10; i++)
            {
                int nums = rnd.Next(100, 1000);
                
                Dewey.Add(nums);
            }
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;
            
        }
        public static List<int> RandomNumbers2()
        {

            string newLine = Environment.NewLine;
            //int nums = rnd.Next(100, 1000);
            List<int> Dewey = new List<int>();
            // txtNumbers.Text = nums.ToString();
            for (int i = 1; i <= 10; i++)
            {
                int nums = rnd.Next(100, 1000);

                Dewey.Add(nums);
            }
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;

        }

    }
}
