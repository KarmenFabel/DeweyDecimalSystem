using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DeweyLibrary;
using System.Linq;

namespace DeweyDecimalSystem.Call_Numbers
{
    public partial class CallNumber
    {
        //The Correct option of the four labels
        public string CorrectOption { get; set; }
        //A list of all available leaves
        List<string> LeafList = new List<string>();
        //A list of all possible parents of the Correct option
        List<string> ParentList = new List<string>();
        private static TreeNode<string> myTree { get; set; }

        public void MessageAfterButton()
        {
            //Finding the Node connected to the question
            TreeNode<string> found = GetTreeData().FindTreeNode(node => node.Data != null && node.Data.Contains(question.Text));
            //If userAnswer is equal to the parent of the question
            if (UserAnswer == found.Parent.ToString())
            {
                
                //MessageBox.Show("Correct! " + UserAnswer +" is in the" + found.Parent.ToString() + " Category");
                newProgressBar1.Increment(1);
                if (newProgressBar1.Value == 10)
                {
                    

                    MessageBox.Show("Weldone! You Completed the quiz! " );

                }
            } 
            else
            {
                MessageBox.Show("Incorrect. The correct answer is: " + found.Parent.ToString());
            }
            TreeNode<string> foundParent =  GetTreeData().FindTreeNode(node => node.Data != null && node.Data.Contains(found.Parent.ToString()));
            //Counts buttonClicks to end when User went through all iterations
            if (!foundParent.Parent.ToString().Contains("root"))
            {
                //Set label to correct answer
                question.Text = CorrectOption;
                //Clear lists
                ParentList.Clear();
                Labels.Clear();

                //get the higher level parent
                GetRandomAnswers(1);

            }
            else
            {
                
                MessageBox.Show("Weldone! You completed the round!");
                //Set label to correct answer
                question.Text = CorrectOption;
                //Clear lists
                ParentList.Clear();
                Labels.Clear();
             
                GetRandomLeaf();
                buttonClicks = 0;
                //get the higher level parent
                GetRandomAnswers(2);


            }
        }
        
        public static string GetPath()
        {
            //Get json file containing all Dewey Information
            string executableLocation = Path.GetDirectoryName(
        Assembly.GetExecutingAssembly().Location);
           // string path = Path.Combine(executableLocation, "FindingCallNumbers.json");
            string path = Path.Combine(executableLocation, "FindingCallNumberswArray.json");
            return path;
        }

       
       
      
       // private static TreeNode<string> ParentNode;
        public static TreeNode<string> GetTreeData()
        {
            var path = Path.GetFileName(GetPath());
            string jsonFile = File.ReadAllText(path);
            var jsonObject = JsonConvert.DeserializeObject<Root>(jsonFile);
            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

          
            myTree = new TreeNode<string>(jsonObject.root);
            {
                foreach (var item in jsonObject.contents)
                {

                    TreeNode<string> FirstIt = myTree.AddChild(item.callnumber + " " + item.description);
                    //myTree = new TreeNode<string>(); 
                    {
                        foreach (var newThing in item.SecondIteration)
                        {
                            TreeNode<string> ParentNodeCall = FirstIt.AddChild(newThing.callnumber + " " + newThing.description);
                            //TreeNode<string> ParentNodeDesc = myTree.AddChild(item.SecondIteration.description);
                            {
                                foreach (var thing in newThing.ThirdIteration)
                                {
                                    

                                    TreeNode<string> ChildNodeCall = ParentNodeCall.AddChild(thing.callnumber + " " + thing.description);
                                    // TreeNode<string> ChildNodeDesc= ParentNodeCall.AddChild(thing.description);
                                }

                            }
                        }
                        


                    }
                }
            }
           
            return myTree;

            }
 
       
        
    /// <summary>
    /// Find lowest point of the tree
    /// </summary>
        public void FindLeaf(TreeNode<string> p, List<string> leaves)
        {
            
            int i = 0;
            foreach(var item in p.Children)
            {
                //if item is leaf add to leaf list
                if(item.IsLeaf)
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
       /// <summary>
       /// Get a random leaf out of the leaf List
       /// </summary>
        public void GetRandomLeaf()
        {
            
            FindLeaf(myTree, LeafList);
            int i = Library.rnd.Next(LeafList.Count);
            //Make Label equal to random leaf list item
            

            string questionShort = LeafList[i].Remove(0, 4); //Removes the code segment
            question.Text = questionShort;
            //Get parents at level 2
            GetRandomAnswers(2);

        }

        /// <summary>
        /// Create List of the labels
        /// </summary>
        List<Label> Labels = new List<Label>();
        public void AnswerLabelsList()
        {
            Labels.Add(answer1);
            Labels.Add(answer2);
            Labels.Add(answer3);
            Labels.Add(answer4);
        }
     
       
       /// <summary>
       /// Get Random Parents and one correct Parent
       /// </summary>
       /// <param name="level"></param>
        public void GetRandomAnswers( int level)
        {
            
            //Initialize labels to list
            AnswerLabelsList();
            foreach (var item in GetTreeData())
            {
                //If the item is at the correct level add to Parent List
                if (item.Level == level)
                {
                    string t = item.ToString();
                    ParentList.Add(t);
                }

            }
            int i = Library.rnd.Next(ParentList.Count);
            foreach (var item in Labels)
            {
                item.Text =(ParentList[i]);
            }
            //Make Label equal to random leaf list item
            //question.Text = LeafList[i];
            //Add Parentlist to Labels
            for (var x = 0; x < 4; x++)
            {
                Labels[x].Text = ParentList[x];
            }

            ReplaceWithCorrectAnswer();

        }

        private void ReplaceWithCorrectAnswer()
        {
            //Find Correct Answer
            TreeNode<string> found = GetTreeData().FindTreeNode(node => node.Data != null && node.Data.Contains(question.Text));
           
            //Get random number between 1-4
            int i = Library.rnd.Next(Labels.Count);
           /* foreach( var item in Labels)
            {
                if (item.Text.Contains(found.Parent.ToString()))
                {
                    return;
                }
                return;

            }*/
          
   //Replace one label with the correct answer
            
           
                Labels[i].Text = found.Parent.ToString();
            //save correct choice 
            CorrectOption = found.Parent.ToString();
        }

        public static string SearchExample(string searchItem)
        {
            TreeNode<string> treeRoot = TreeData.GetSet1();
            TreeNode<string> found = treeRoot.FindTreeNode(node => node.Data != null && node.Data.Contains(searchItem));

            if (found != null)
            {
                Console.WriteLine("Found: " + found);
                Console.ReadLine();
                return found.ToString();

            }
            else
            {
                return "Not found";
                Console.WriteLine("Not found: " + searchItem);
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Add to button click counter and calls Message after user chooses answer
        /// </summary>
        private void ButtonActions(Label lbl)
        {
            UserAnswer = lbl.Text;
            MessageAfterButton();
            buttonClicks++;
        }
    }
   
}


//Reference:
//How to recursively populate a TreeView with JSON data
//https://stackoverflow.com/questions/39673815/how-to-recursively-populate-a-treeview-with-json-data

