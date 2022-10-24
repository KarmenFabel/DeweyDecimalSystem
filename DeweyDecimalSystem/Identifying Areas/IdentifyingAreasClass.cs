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
        /// Score and total questions answered are added to string
        /// </summary>
        /// <returns></returns>
        public static String Score()
        {
            String score = Library.Points.ToString() + "/" + (Library.Points + Library.WrongPoints).ToString();
            return score;
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
        /// <summary>
        /// Getting the Values for the callnumbers as questions and  Description as answers
        /// </summary>
        /// <param name="i"></param>
        public void CallAnswer(int i)
        {
            KeyValuePair<int, DeweyDecimalGroup> pair = Library.deweyDictionary.ElementAt(i);
            Library.sevenRandoms.Add(pair.Value.deweyDescrip);
            Library.FourRandomItems.Add(pair.Value.deweyKey);
        }
        /// <summary>
        /// Getting the Values for the Description as questions and   callnumbers as answers
        /// </summary>
        /// <param name="i"></param>
        public void DescAnswer(int i)
        {
            KeyValuePair<int, DeweyDecimalGroup> pair = Library.deweyDictionary.ElementAt(i);
            Library.sevenRandoms.Add(pair.Value.deweyKey);
            Library.FourRandomItems.Add(pair.Value.deweyDescrip);
        }
        /// <summary>
        /// Populating the call numbers as questions and Descriptions as answers
        /// </summary>
        public void CalNumsFirst()
        {
            PopulatingLabels(Library.CallNumber, Library.Description);

        }
        /// <summary>
        /// Populating the call numbers as questions and Descriptions as answers
        /// </summary>
        public void DescFirst()
        {
            PopulatingLabels(Library.Description, Library.CallNumber);
        }
        /// <summary>
        /// Finding Answers
        /// </summary>
        /// <param name="panel"></param>
        
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
        /// <summary>
        /// Add Points correct where call numbers are questions
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="label"></param>
        private  void AddPointsCallNumAnswered(KeyValuePair<int, DeweyDecimalGroup> pair, Label label)
        {
            if (label.Text == pair.Value.deweyDescrip)
            {
                Library.PointCounter();
                Console.WriteLine(label.Text + "is equal to" +
                     pair.Value.deweyDescrip);
                Score();
                timer1.Start();
            }
            else
            {
                Library.WrongPointCounter();
                Console.WriteLine("Incorrect" + label.Text + " is not equal to" +
                   pair.Value.deweyDescrip);
                timer1.Start();
            }
        }

        /// <summary>
        /// Add Points correct where description are questions
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="label"></param>
        private void AddPointsDescriptionAnswered(KeyValuePair<int, DeweyDecimalGroup> pair, Label label)
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
        /// <summary>
        /// find either call number as questions or description as questions
        /// </summary>
        /// <param name="item"></param>

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
        /// <summary>
        /// Find the key of the question label if Call numbers are questions
        /// </summary>
        /// <param name="item"></param>
        private void CallIsQuestion(object item)
        {
            // pair.Value.deweyDescrip
            Label label = (Label)item;
            Library.key = Library.deweyDictionary.Where(pair => pair.Value.deweyKey.ToString() == label.Text)
           .Select(pair => pair.Key)
           .FirstOrDefault();
        }

        /// <summary>
        /// Find the key of the question label if Description are questions
        /// </summary>
        /// <param name="item"></param>
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
        /// <summary>
        /// Clear screen to add panels back in place and clear Lists
        /// </summary>
        private void ButtonClickClear()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            Library.FourRandomItems.Clear();
            Library.sevenRandoms.Clear();
        }
        /// <summary>
        /// End Message 
        /// </summary>
        private void EndScoreMessage()
        {
            
            MessageBox.Show("You got " + Library.Points.ToString() + " Correct \r\n\r\n and you got " +
                            Library.WrongPoints.ToString() );
           //Clear points if user goes to main screen and then go back to this page
            Library.Points =0;
            Library.WrongPoints =0;
           
        }


    }
}
//References:
//Randomize List:
//https://stackoverflow.com/questions/273313/randomize-a-listt
