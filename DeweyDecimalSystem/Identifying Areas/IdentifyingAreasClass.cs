using System;
using System.Collections.Generic;
using System.Linq;
using DeweyLibrary;
using System.Windows.Forms;


namespace DeweyDecimalSystem
{
    public partial class IdentifyingAreas
    {
        //HashSet so that the random numbers are not repeating
        public static HashSet<int> randoms = new HashSet<int>();
        Dictionary<int, DeweyDecimalGroup> deweyDictionary = deweyGroups();
        //Creation of Dictionary
        public static  Dictionary<int, DeweyDecimalGroup> deweyGroups()
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
                deweyKey ="600 - 699",
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
            //Adding a key to the deweGrouping
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

        List<string> fourRandomDescriptions = new List<string>();
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
       
        public void DescFirst()
        {
            //List<int> randoms = Enumerable.Range(0, 9).ToList();
            List<string> sevenRandoms = new List<string>();
        
        var seven = sevenRandoms.OrderBy(a => Guid.NewGuid()).ToList();

            lblquestion.Text = Library.Description;
            lblAnswer.Text = Library.CallNumber;
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 };
            var questions = new[] { question1, lblquestion2, lblquestion3, lblquestion4 };

            Random random = new Random();
            while (randoms.Count < 7)
            {
                randoms.Add(random.Next(0, 9));
            }
            foreach (var item in randoms)
            {
                KeyValuePair<int, DeweyDecimalGroup> pair = deweyDictionary.ElementAt(item);
                sevenRandoms.Add(pair.Value.deweyKey);
                fourRandomDescriptions.Add(pair.Value.deweyDescrip);
            }

            List<string> sevenRandoms2 = Randomize(sevenRandoms);
            for (var i = 0; i != sevenRandoms2.Count; i++)
            {
               
                //foreach label add a dewey list number
                labels[i].Text = sevenRandoms2[i].ToString();
            }
            for (var i = 0; i != 4; i++)
            {
                questions[i].Text = fourRandomDescriptions[i];
            }
        }
       
            public void CalNumsFirst()
        {
            List<string> fourRandomCallNumbers = new List<string>();
            List<string> sevenRandoms = new List<string>();
            lblquestion.Text = Library.CallNumber;
            lblAnswer.Text = Library.Description;
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 };

            var questions = new[] { question1, lblquestion2, lblquestion3, lblquestion4 };

            Random random = new Random();
            
                while (randoms.Count < 7)
                {
                    randoms.Add(random.Next(0, 9));
                }
                foreach(var item in randoms)
                 {
                KeyValuePair<int, DeweyDecimalGroup> pair = deweyDictionary.ElementAt(item);
                fourRandomCallNumbers.Add(pair.Value.deweyKey);
                sevenRandoms.Add(pair.Value.deweyDescrip);
                //randoms.RemoveAt(index);
                // Console.WriteLine("key: " + pair.Key + ", value: " + pair.Value);

                 }
            for (var i = 0; i != sevenRandoms.Count; i++)
            {
                //foreach label add a dewey list number
                labels[i].Text = sevenRandoms[i];
            }
            for (var i = 0; i != 4; i++)
            {
                questions[i].Text = fourRandomCallNumbers[i].ToString();
            }



        }

        int key { get; set; }
        public void DescriptAnswers(FlowLayoutPanel panel)
        {
           
            foreach (var item in panel.Controls)
            {
                if (item is Label)
                {
                    Label label = (Label)item;
                    key = deweyDictionary.Where(pair => pair.Value.deweyDescrip == label.Text) 
                   .Select(pair => pair.Key)
                   .FirstOrDefault();
                    
                }

                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel answer = (FlowLayoutPanel)item;
                    foreach (var ans in answer.Controls)
                        if (ans is Label)
                        {
                            KeyValuePair<int, DeweyDecimalGroup> pair = deweyDictionary.ElementAt(key);
                            Label label = (Label)ans;
                            if (label.Text == pair.Value.deweyKey.ToString())
                            {

                                MessageBox.Show(label.Text + "is equal to" +
                                     key.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Incorrect" + label.Text + " is not equal to" +
                                   key.ToString());
                            }
                        }
                }
            }
        }
      
        public void CallAnswers(FlowLayoutPanel panel)
        {
           
            foreach (var item in panel.Controls)
            {
                if (item is Label)
                {
                    // pair.Value.deweyDescrip
                    Label label = (Label)item;
                    key = deweyDictionary.Where(pair => pair.Value.deweyKey.ToString() == label.Text)
                   .Select(pair => pair.Key)
                   .FirstOrDefault();
                }

                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel answer = (FlowLayoutPanel)item;
                    foreach (var ans in answer.Controls)
                        if (ans is Label)
                        {
                            Label label = (Label)ans;
                            
                                 KeyValuePair<int, DeweyDecimalGroup> pair = deweyDictionary.ElementAt(key);
                                
                            if (label.Text == pair.Value.deweyDescrip)
                            {

                                MessageBox.Show(label.Text + "is equal to" +
                                     pair.Value.deweyDescrip);
                            }
                            else
                            {
                                MessageBox.Show("Incorrect" + label.Text + " is not equal to" +
                                   pair.Value.deweyDescrip);
                            }
                        }
                }
            }
        }
        public void PanelCorrect()
        { if (lblquestion.Text==Library.CallNumber)
            {

                CallAnswers(flPanel1);
                CallAnswers(flPanel2);
                CallAnswers(flPanel6);
                CallAnswers(flPanel7);


            }
            else 
            {
                
                DescriptAnswers(flPanel1);
                DescriptAnswers(flPanel2);
                DescriptAnswers(flPanel6);
                DescriptAnswers(flPanel7);


            }
           
        }

    }



}
