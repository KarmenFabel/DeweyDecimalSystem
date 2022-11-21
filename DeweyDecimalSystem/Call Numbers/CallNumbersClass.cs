using DeweyLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DeweyDecimalSystem.Call_Numbers
{
    public partial class CallNumber
    {
        /// <summary>
        /// Find if answers are correct and if round is over
        /// </summary>
        public void MessageAfterButton()
        {
            try
            {
                //Finding the Node connected to the question
                TreeNode<string> found = TreeData.GetTreeData().FindTreeNode(node => node.Data != null && node.Data.Contains(question.Text));
                //If userAnswer is equal to the parent of the question
                if (Library.UserAnswer == found.Parent.ToString())
                {
                    newProgressBar1.Increment(10);
                    if (newProgressBar1.Value == newProgressBar1.Maximum)
                    {
                        EndOfRoundMessageBox();
                        ClearLists();
                        //Implement all classes needed to reset questions
                        GetRandomLeaf();
                        TreeData.GetTreeData();
                        //get the higher level parent
                        GetRandomAnswers(2);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect. The correct answer is: " + found.Parent.ToString());
                    //Set label to correct answer
                    question.Text = Library.CorrectOption.Remove(0, 4);
                    ClearLists();
                    GetRandomLeaf();

                    //get the higher level parent
                    GetRandomAnswers(2);
                }
                TreeNode<string> foundParent = TreeData.GetTreeData().FindTreeNode(node => node.Data != null && node.Data.Contains(found.Parent.ToString()));
                //Counts buttonClicks to end when User went through all iterations
                if (!foundParent.Parent.ToString().Contains("root"))
                {
                    //Set label to correct answer
                    string questionShort = foundParent.ToString().Remove(0, 4); //Removes the code segment
                    question.Text = questionShort;
                    ClearLists();
                    //get the higher level parent
                    GetRandomAnswers(1);

                }
                else
                {
                    try
                    {
                        //Set label to correct answer
                        string questionShort = Library.CorrectOption.Remove(0, 4); //Removes the code segment
                        question.Text = questionShort;
                        ClearLists();
                        GetRandomLeaf();
                        //get the higher level parent
                        GetRandomAnswers(2);

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Oh No! Something went wrong! " + e.ToString());
                    }

                }
            }
            catch (Exception e)
            {


            }
        }
        /// <summary>
        /// Clear lists after each round
        /// </summary>
        private void ClearLists()
        {
            //Clear lists
            Library.ParentList.Clear();
            Labels.Clear();
        }
        /// <summary>
        /// End of game message asking users if they want to play again
        /// </summary>
        private void EndOfRoundMessageBox()
        {
            var title = "Weldone! You Completed the quiz! ";
            var message = "\r\n Would you like to play again?";
            var result = MessageBox.Show(
                message,   // the message to show
                title,
                MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:   // Yes button pressed continue game
                                         //reset component
                    this.InitializeComponent();
                    Library.ParentList.Clear();
                    Labels.Clear();
                    //Implement all classes needed to reset questions
                    GetRandomLeaf();
                    TreeData.GetTreeData();
                    //get the higher level parent
                    GetRandomAnswers(2);
                    break;
                case DialogResult.No:    // No button pressed to go to main menu
                    MainPage MP = new MainPage();
                    this.Hide();
                    MP.ShowDialog();
                    break;
                default:                 // Neither Yes nor No pressed (just in case)
                    MessageBox.Show("Nothing was Pressed");
                    break;
            }
        }

        /// <summary>
        /// Find lowest point of the tree
        /// </summary>
        public void FindLeaf(TreeNode<string> p, List<string> leaves)
        {
            try
            {
                int i = 0;
                foreach (var item in p.Children)
                {
                    //if item is leaf add to leaf list
                    if (item.IsLeaf)
                    {
                        i++;
                        string t = item.ToString();
                        leaves.Add(t);
                    }
                    else
                    {
                        FindLeaf(item, leaves);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Oh No! Something went wrong! " + e.ToString());
            }
        }
        /// <summary>
        /// Get a random leaf out of the leaf List
        /// </summary>
        public void GetRandomLeaf()
        {
            try
            {
                FindLeaf(TreeData.GetTreeData(), Library.LeafList);
                int i = Library.rnd.Next(Library.LeafList.Count);
                //Make Label equal to random leaf list item
                string questionShort = Library.LeafList[i].Remove(0, 4); //Removes the code segment
                question.Text = questionShort;
                //Get parents at level 2
                GetRandomAnswers(2);
            }
            catch (Exception e)
            {
                MessageBox.Show("Oh No! Something went wrong! " + e.ToString());
            }
        }

        /// <summary>
        /// Create List of the labels
        /// </summary>
        List<Label> Labels = new List<Label>();
        public void AnswerLabelsList()
        {
            try
            {
                Labels.Add(answer1);
                Labels.Add(answer2);
                Labels.Add(answer3);
                Labels.Add(answer4);
            }
            catch (Exception e)
            {
                MessageBox.Show("Oh No! Something went wrong! " + e.ToString());
            }

        }

        /// <summary>
        /// Get Random Parents and one correct Parent
        /// </summary>
        /// <param name="level"></param>
        public void GetRandomAnswers(int level)
        {
            try
            {
                //Initialize labels to list
                AnswerLabelsList();
                foreach (var item in TreeData.GetTreeData())
                {
                    if (item.Level == level)
                    {
                        string t = item.ToString();
                        Library.ParentList.Add(t);
                    }

                }
                //Create a list of random numbers to populate the labels with (as its location)
                int[] FourRandoms = new int[4];
                for (int x = 0; x < 4; x++)
                {
                    FourRandoms[x] = Library.rnd.Next(Library.ParentList.Count);
                }

                for (var x = 0; x < 4; x++)
                {
                    //use random numbers to get a random object in the list
                    Labels[x].Text = Library.ParentList[FourRandoms[x]];
                }
                ReplaceWithCorrectAnswer();

            }

            catch (Exception e)
            {
                MessageBox.Show("Oh No! Something went wrong! " + e.ToString());
            }

        }
        /// <summary>
        /// Replace one random label with the correct answer
        /// </summary>
        private void ReplaceWithCorrectAnswer()
        {
            try
            {
                //Find Correct Answer
                TreeNode<string> found = TreeData.GetTreeData().FindTreeNode(node => node.Data != null && node.Data.Contains(question.Text));

                //Get random number between 1-4
                int i = Library.rnd.Next(Labels.Count);
                //Do not add correct number if already in list
                foreach (var item in Labels)
                {
                    if (item.Text.Contains(found.Parent.ToString()))
                    {
                        return;
                    }
                }

                //Replace one label with the correct answer
                Labels[i].Text = found.Parent.ToString();
                //save correct choice 
                Library.CorrectOption = found.Parent.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Oh No! Something went wrong! " + e.ToString());
            }
        }
        /// <summary>
        /// Add to button click counter and calls Message after user chooses answer
        /// </summary>
        private void ButtonActions(Label lbl)
        {
            Library.UserAnswer = lbl.Text;
            //Each button click goes to After button actions
            MessageAfterButton();
        }
    }
}
/*
 
  ___             _    ___     __   ___   _   _       
 | __|  _ _    __| |  / _ \   / _| | __| (_) | |  ___ 
 | _|  | ' \  / _` | | (_) | |  _| | _|  | | | | / -_)
 |___| |_||_| \__,_|  \___/  |_|   |_|   |_| |_| \___|
                                                      
*/

//Reference:
//How to recursively populate a TreeView with JSON data
//https://stackoverflow.com/questions/39673815/how-to-recursively-populate-a-treeview-with-json-data
//Comment Styling
//http://www.patorjk.com/software/taag/#p=display&h=0&f=Small&t=Github
//ProgresBar
//https://stackoverflow.com/questions/22526934/check-if-progressbar-is-filled

