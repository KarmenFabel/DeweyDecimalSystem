using System;
using System.Collections.Generic;
using System.Linq;
using DeweyLibrary;
using System.Windows.Forms;


namespace DeweyDecimalSystem
{
    public partial class IdentifyingAreas
    {

        Dictionary<int, DeweyDecimalGroup> deweyDictionary = deweyGroups();

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
        public void DescFirst()
        {
            List<int> randoms = Enumerable.Range(0, 9).ToList();
            List<int> sevenRandoms = new List<int>();

            lblquestion.Text = Library.Description;
            lblAnswer.Text = Library.CallNumber;
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 };
            var questions = new[] { question1, lblquestion2, lblquestion3, lblquestion4 };

            Random random = new Random();
            for (int i = 0; i < 7; ++i)
            {
                int index = random.Next(0, randoms.Count);
                //make first number 001 
                if (index == 0)
                {
                     string convert = "001";
                    sevenRandoms.Add(Int32.Parse(convert));
                    //sevenRandoms.Add(index);
                    KeyValuePair<int, DeweyDecimalGroup> pair = deweyDictionary.ElementAt(index);
                    fourRandomDescriptions.Add(pair.Value.deweyDescrip);
                }
                else
                {
                    string convert = randoms[index].ToString() + "00";
                    sevenRandoms.Add(Int32.Parse(convert));
                    KeyValuePair<int, DeweyDecimalGroup> pair = deweyDictionary.ElementAt(index);
                    fourRandomDescriptions.Add(pair.Value.deweyDescrip);
                }
                randoms.RemoveAt(index);
                // Console.WriteLine("key: " + pair.Key + ", value: " + pair.Value);

            }
            for (var i = 0; i != sevenRandoms.Count; i++)
            {
                //foreach label add a dewey list number
                labels[i].Text = sevenRandoms[i].ToString();
            }
            for (var i = 0; i != 4; i++)
            {
                questions[i].Text = fourRandomDescriptions[i];
            }



        }
        List<int> fourRandomCallNumbers = new List<int>();
        public void CalNumsFirst()
        {
            List<int> randoms = Enumerable.Range(0, 9).ToList();
            List<string> sevenRandoms = new List<string>();

            lblquestion.Text = Library.CallNumber;
            lblAnswer.Text = Library.Description;
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 };

            var questions = new[] { question1, lblquestion2, lblquestion3, lblquestion4 };

            Random random = new Random();
            for (int i = 0; i < 7; ++i)
            {
                int index = random.Next(0, randoms.Count);
                //make first number 001 
                if (index == 0)
                {
                    // string convert = "001";
                    //sevenRandoms.Add(Int32.Parse(convert));
                    KeyValuePair<int, DeweyDecimalGroup> pair
                        = deweyDictionary.ElementAt(index);
                    sevenRandoms.Add(pair.Value.deweyDescrip);
                    fourRandomCallNumbers.Add(index);
                }
                else
                {
                    string convert = randoms[index].ToString() + "00";
                    fourRandomCallNumbers.Add(Int32.Parse(convert));
                    KeyValuePair<int, DeweyDecimalGroup> pair = deweyDictionary.ElementAt(index);
                    sevenRandoms.Add(pair.Value.deweyDescrip);

                }
                randoms.RemoveAt(index);
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
