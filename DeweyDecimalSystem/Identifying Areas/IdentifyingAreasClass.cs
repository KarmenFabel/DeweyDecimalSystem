using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeweyLibrary;


namespace DeweyDecimalSystem
{
    public partial class IdentifyingAreas
    {

        Dictionary<int, DeweyDecimalGroup> testDictionary2 = deweyGroups();

        public static  Dictionary<int, DeweyDecimalGroup> deweyGroups()
        {
            DeweyDecimalGroup dewey1 = new DeweyDecimalGroup()
            {
                deweyKey = 001,//between 001 - 099;
                deweyDescrip = "Generalities"
            };
            DeweyDecimalGroup dewey2 = new DeweyDecimalGroup()
            {
                deweyKey = 100,//between 100 - 199;
                deweyDescrip = "Philosophy"
            };
            DeweyDecimalGroup dewey3 = new DeweyDecimalGroup()
            {
                deweyKey = 200,//between 200-299 - 099;
                deweyDescrip = "Religion"
            }; 
            DeweyDecimalGroup dewey4 = new DeweyDecimalGroup()
            {
                deweyKey = 300,//between 300 - 399;
                deweyDescrip = "Social Science"
            };
            DeweyDecimalGroup dewey5 = new DeweyDecimalGroup()
            {
                deweyKey = 400,//between 400 - 499;
                deweyDescrip = "Languages"
            };
            DeweyDecimalGroup dewey6 = new DeweyDecimalGroup()
            {
                deweyKey = 500,//between 500 - 599;
                deweyDescrip = "Natural Science"
            };
            DeweyDecimalGroup dewey7 = new DeweyDecimalGroup()
            {
                deweyKey =600,//between 600 - 699;
                deweyDescrip = "Applied Science"
            };
            DeweyDecimalGroup dewey8 = new DeweyDecimalGroup()
            {
                deweyKey = 700,//between 700 - 799;
                deweyDescrip = "Arts and Recreation"
            };
            DeweyDecimalGroup dewey9 = new DeweyDecimalGroup()
            {
                deweyKey = 800,//between 800 - 899;
                deweyDescrip = "Literature"
            };
            DeweyDecimalGroup dewey10 = new DeweyDecimalGroup()
            {
                deweyKey = 900,//between 900 - 999;
                deweyDescrip = "Geography and History"
            };
            Dictionary<int, DeweyDecimalGroup> testDictionary = new Dictionary<int, DeweyDecimalGroup>();
            testDictionary.Add(dewey1.deweyKey, dewey1);
            testDictionary.Add(dewey2.deweyKey, dewey2);
            testDictionary.Add(dewey3.deweyKey, dewey3);
            testDictionary.Add(dewey4.deweyKey, dewey4);
            testDictionary.Add(dewey5.deweyKey, dewey5);
            testDictionary.Add(dewey6.deweyKey, dewey6);
            testDictionary.Add(dewey7.deweyKey, dewey7);
            testDictionary.Add(dewey8.deweyKey, dewey8);
            testDictionary.Add(dewey9.deweyKey, dewey9);
            testDictionary.Add(dewey10.deweyKey, dewey10);
            return testDictionary;
        }
    }

  
   
}
