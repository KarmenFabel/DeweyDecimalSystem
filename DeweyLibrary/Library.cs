using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DeweyLibrary
{
    public class Library
    {
        //Global random called
        public static Random rnd = new Random();
        /*
  ___                _                       ___               _        
 | _ \  ___   _ __  | |  __ _   __   ___    | _ )  ___   ___  | |__  ___
 |   / / -_) | '_ \ | | / _` | / _| / -_)   | _ \ / _ \ / _ \ | / / (_-<
 |_|_\ \___| | .__/ |_| \__,_| \__| \___|   |___/ \___/ \___/ |_\_\ /__/
             |_|                                                        
*/

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
        /*
          ___      _                _     _    __          _                     _                           
         |_ _|  __| |  ___   _ _   | |_  (_)  / _|  _  _  (_)  _ _    __ _      /_\    _ _   ___   __ _   ___
          | |  / _` | / -_) | ' \  |  _| | | |  _| | || | | | | ' \  / _` |    / _ \  | '_| / -_) / _` | (_-<
         |___| \__,_| \___| |_||_|  \__| |_| |_|    \_, | |_| |_||_| \__, |   /_/ \_\ |_|   \___| \__,_| /__/
                                                    |__/             |___/                                   
        */
        //Identifying Areas Header Labels
        public static string CallNumber = "Call Number";
        public static string Description = "Descriptions";
        //HashSet so that the random numbers are not repeating
        public static HashSet<int> randoms = new HashSet<int>();
        //Four RandomItems
       public static List<string> FourRandomItems = new List<string>();
       
        //Four Call numbers of the answers
        public static List<string> sevenRandoms = new List<string>();
        
        //Right and Wrong Point calculator
        public static int Points { get; set; }
        public static int WrongPoints { get; set; }

        public static int PointCounter()
        {
            return Points++;

        }
        public static int WrongPointCounter()
        {
            return WrongPoints++;

        }
        //Make the random answers more random so that they are not in the same order as questions
        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> randomizedList = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count); //pick a random item from the master list
                randomizedList.Add(list[index]); //place it at the end of the randomized list
                list.RemoveAt(index);
            }
            return randomizedList;
        }
        //Key for Dictionary
       public static int key { get; set; }
        public static Dictionary<int, DeweyDecimalGroup> deweyDictionary = deweyGroups();
        //Creation of Dictionary
        public static Dictionary<int, DeweyDecimalGroup> deweyGroups()
        {
            //Each part of dictionary contains both the dewey numbers with their Description
            DeweyDecimalGroup dewey1 = new DeweyDecimalGroup()
            {
                deweyKey = " 001 - 099",
                deweyDescrip = "Generalities"
            };
            DeweyDecimalGroup dewey2 = new DeweyDecimalGroup()
            {
                deweyKey = "100 - 199",
                deweyDescrip = "Philosophy"
            };
            DeweyDecimalGroup dewey3 = new DeweyDecimalGroup()
            {
                deweyKey = "200-299",
                deweyDescrip = "Religion"
            };
            DeweyDecimalGroup dewey4 = new DeweyDecimalGroup()
            {
                deweyKey = "300 - 399",
                deweyDescrip = "Social Science"
            };
            DeweyDecimalGroup dewey5 = new DeweyDecimalGroup()
            {
                deweyKey = "400 - 499",
                deweyDescrip = "Languages"
            };
            DeweyDecimalGroup dewey6 = new DeweyDecimalGroup()
            {
                deweyKey = "500 - 599",
                deweyDescrip = "Natural Science"
            };
            DeweyDecimalGroup dewey7 = new DeweyDecimalGroup()
            {
                deweyKey = "600 - 699",
                deweyDescrip = "Applied Science"
            };
            DeweyDecimalGroup dewey8 = new DeweyDecimalGroup()
            {
                deweyKey = "700 - 799",
                deweyDescrip = "Arts and Recreation"
            };
            DeweyDecimalGroup dewey9 = new DeweyDecimalGroup()
            {
                deweyKey = "800 - 899",
                deweyDescrip = "Literature"
            };
            DeweyDecimalGroup dewey10 = new DeweyDecimalGroup()
            {
                deweyKey = " 900 - 999",
                deweyDescrip = "Geography and History"
            };
            //Adding a key to the deweyGrouping
            Dictionary<int, DeweyDecimalGroup> dewDict = new Dictionary<int, DeweyDecimalGroup>();
            dewDict.Add(0, dewey1);
            dewDict.Add(1, dewey2);
            dewDict.Add(2, dewey3);
            dewDict.Add(3, dewey4);
            dewDict.Add(4, dewey5);
            dewDict.Add(5, dewey6);
            dewDict.Add(6, dewey7);
            dewDict.Add(7, dewey8);
            dewDict.Add(8, dewey9);
            dewDict.Add(9, dewey10);
            //dewDict.Add(dewey10.deweyKey, dewey10);
            return dewDict;
        }
     
    }
    public class DeweyDecimalGroup
    {
        //Strings that populate the Dictionary
        public string deweyKey { get; set; }
        public string deweyDescrip { get; set; }
    }
  
    public class Content
    {
        public string callnumber { get; set; }
        public string description { get; set; }
        public List<SecondIteration> SecondIteration { get; set; }
    }

    public class Root
    {
        public string root { get; set; }
        public List<Content> contents { get; set; }
    }

    public class SecondIteration
    {
        public string callnumber { get; set; }
        public string description { get; set; }
        public List<ThirdIteration> ThirdIteration { get; set; }
    }

    public class ThirdIteration
    {
        public string callnumber { get; set; }
        public string description { get; set; }
    }






}