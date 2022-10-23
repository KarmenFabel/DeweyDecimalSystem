using System;
using System.Collections.Generic;
using System.Linq;
using DeweyLibrary;
using System.Windows.Forms;


namespace DeweyDecimalSystem
{
    public partial class IdentifyingAreas
    {
        /// <summary>
        /// All Labels to array 
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="questions"></param>
        private void AllLabels(out Label[] labels, out Label[] questions)
        {
            labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 };
            questions = new[] { question1, lblquestion2, lblquestion3, lblquestion4 };
        }
        /// <summary>
        /// Add Dictionary values to Labels
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        public void PopulatingLabels(String question, String answer)
        {
            lblquestion.Text = question;
            lblAnswer.Text = answer;
            Label[] labels, questions;
            AllLabels(out labels, out questions);

            while (Library.randoms.Count < 7)
            {
                Library.randoms.Add(Library.rnd.Next(0, 9));
            }
            foreach (var item in Library.randoms)
            {
                if (lblquestion.Text == Library.Description)
                {
                    DescAnswer(item);
                }
                else
                {
                    CallAnswer(item);
                }
            }
            //Make answers appear in random order
            List<string> sevenRandoms2 = Library.Randomize(Library.sevenRandoms);
            for (var i = 0; i != sevenRandoms2.Count; i++)
            {
                //foreach label add a dewey list number
                labels[i].Text = sevenRandoms2[i].ToString();
            }
            for (var i = 0; i != 4; i++)
            {
                questions[i].Text = Library.FourRandomItems[i];
            }
        }
        public void CallAnswer(int i)
        {
            KeyValuePair<int, DeweyDecimalGroup> pair = Library.deweyDictionary.ElementAt(i);
            Library.sevenRandoms.Add(pair.Value.deweyDescrip);
            Library.FourRandomItems.Add(pair.Value.deweyKey);
        }
        public void DescAnswer(int i)
        {
            KeyValuePair<int, DeweyDecimalGroup> pair = Library.deweyDictionary.ElementAt(i);
            Library.sevenRandoms.Add(pair.Value.deweyKey);
            Library.FourRandomItems.Add(pair.Value.deweyDescrip);
        }
        public void CalNumsFirst()
        {
            PopulatingLabels(Library.CallNumber, Library.Description);

        }
        public void DescFirst()
        {
            PopulatingLabels(Library.Description, Library.CallNumber);
        }
        
        public void Answers(FlowLayoutPanel panel)
        {
            foreach (var item in panel.Controls)
            {
                FindQuestions(item);

                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel answer = (FlowLayoutPanel)item;
                    foreach (var ans in answer.Controls)
                        if (ans is Label)
                        {
                            KeyValuePair<int, DeweyDecimalGroup> pair = Library.deweyDictionary.ElementAt(Library.key);
                            Label label = (Label)ans;
                            if (lblquestion.Text == Library.Description)
                            {
                                AddPointsDescriptionAnswered(pair, label);

                            }
                            else
                            {
                                AddPointsCallNumAnswered(pair, label);

                            }

                        }
                }
            }
        }

        private static void AddPointsCallNumAnswered(KeyValuePair<int, DeweyDecimalGroup> pair, Label label)
        {
            if (label.Text == pair.Value.deweyDescrip)
            {
                Library.PointCounter();
                Console.WriteLine(label.Text + "is equal to" +
                     pair.Value.deweyDescrip);
            }
            else
            {
                Library.WrongPointCounter();
                Console.WriteLine("Incorrect" + label.Text + " is not equal to" +
                   pair.Value.deweyDescrip);
            }
        }

        private static void AddPointsDescriptionAnswered(KeyValuePair<int, DeweyDecimalGroup> pair, Label label)
        {
            if (label.Text == pair.Value.deweyKey.ToString())
            {
                Library.PointCounter();
                Console.WriteLine(label.Text + "is equal to" +
                     Library.key.ToString());
            }
            else
            {
                Library.WrongPointCounter();
                Console.WriteLine("Incorrect" + label.Text + " is not equal to" +
                   Library.key.ToString());
            }
        }

        private void FindQuestions(object item)
        {
            if (item is Label)
            {
                if (lblquestion.Text == Library.Description)
                {
                    DescriptionIsQuestion(item);
                }
                else
                {
                    CallIsQuestion(item);
                }
            }
        }

        private void CallIsQuestion(object item)
        {
            // pair.Value.deweyDescrip
            Label label = (Label)item;
            Library.key = Library.deweyDictionary.Where(pair => pair.Value.deweyKey.ToString() == label.Text)
           .Select(pair => pair.Key)
           .FirstOrDefault();
        }

        private void DescriptionIsQuestion(object item)
        {
            Label label = (Label)item;
            Library.key = Library.deweyDictionary.Where(pair => pair.Value.deweyDescrip == label.Text)
           .Select(pair => pair.Key)
           .FirstOrDefault();
        }
        public void PanelCorrect()
        { 
                Answers(flPanel1);
                Answers(flPanel2);
                Answers(flPanel6);
                Answers(flPanel7);
        }

        private void ButtonClickClear()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            Library.FourRandomItems.Clear();
            Library.sevenRandoms.Clear();
        }
        private static void EndScoreMessage()
        {
            MessageBox.Show("You got " + Library.Points.ToString() + " Correct \r\n\r\n and you got " +
                            Library.WrongPoints.ToString() + " incorrect");
        }


    }
}
//References:
//Randomize List:
//https://stackoverflow.com/questions/273313/randomize-a-listt
