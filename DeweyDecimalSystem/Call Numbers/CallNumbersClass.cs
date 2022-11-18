using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DeweyLibrary;

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
        //TreeData
        TreeNode<string> treeRoot = TreeData.GetSet1();
        public void MessageAfterButton()
        {
            //Finding the Node connected to the question
            TreeNode<string> found = treeRoot.FindTreeNode(node => node.Data != null && node.Data.Contains(question.Text));
            //If userAnswer is equal to the parent of the question
            if (UserAnswer == found.Parent.ToString())
            {
                
                MessageBox.Show("Correct! " + UserAnswer +" is in the" + found.Parent.ToString() + " Category");
            } 
            else
            {
                MessageBox.Show("Incorrect. The correct answer is: " + found.Parent.ToString());
            }
            //Counts buttonClicks to end when User went through all iterations
            if(buttonClicks<1)
            {
                //Set label to correct answer
                question.Text = CorrectOption;
                //Clear lists
                ParentList.Clear();
                Labels.Clear();
                //get the higher level parent
                GetRandomAnswers(1);

            }else
            {
                MessageBox.Show("Weldone! You completed the round!");
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

        public void readJSON()
        {
            using (var reader = new StreamReader(GetPath()))
            using (var jsonReader = new JsonTextReader(reader))
            {
                JToken root = JToken.Load(jsonReader);
                DisplayTreeView(root, Path.GetFileNameWithoutExtension(GetPath()));
            }
        }
       
        private void DisplayTreeView(JToken root, string rootName)
        {
           // treeView1.BeginUpdate();
            try
            {
               // treeView1.Nodes.Clear();
                var tNode = treeView1.Nodes[treeView1.Nodes.Add(new TreeNode(rootName))];
                tNode.Tag = root;

                AddNode(root, tNode);

                treeView1.ExpandAll();
            }
            finally
            {
                treeView1.EndUpdate();
            }
        }
       
        private void AddNode(JToken token, TreeNode inTreeNode)
              {
                  if (token == null)
                      return;
                  if (token is JValue)
                  {
                      var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
                      childNode.Tag = token;
                  }
                  else if (token is JObject)
                  {
                      var obj = (JObject)token;
                      foreach (var property in obj.Properties())
                      {
                          var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(property.Name))];
                          childNode.Tag = property;
                          AddNode(property.Value, childNode);
                      }
                  }
                  else if (token is JArray)
                  {
                      var array = (JArray)token;
                      for (int i = 0; i < array.Count; i++)
                      {
                          var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(i.ToString()))];
                          childNode.Tag = array[i];
                          AddNode(array[i], childNode);
                      }
                  }
                  else
                  {
                      Debug.WriteLine(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
                  }
              }
        public static TreeNode<string> GetSet2()
        {
            var path = Path.GetFileName(GetPath());
            string jsonFile = File.ReadAllText(path);
          
            var jsonObject = JsonConvert.DeserializeObject<List<DeweyLibrary.Root>>(jsonFile);
            
            foreach (var item in jsonObject)
            {
               
                myTree = new TreeNode<string>(item.callnumber + item.description);
                {
                    myTree.AddChild(item.SecondIteration.callnumber );
                    myTree.AddChild(item.SecondIteration.description);
                  
                  

                }

                /* new TreeNode<string>(item.callnumber + item.description);
                {
                   
                    new TreeNode<string>(item.SecondIteration.callnumber + item.SecondIteration.description);
                    { 
                      // new TreeNode<DeweyLibrary.ThirdIteration>(item.SecondIteration.ThirdIteration.ToArray());
                        //new TreeNode<string> node1 = root.AddChild("000 Tester");
                    }
                }*/
                

            }
            return myTree;

            }
       public static TreeNode<string> Call;
        private static TreeNode<string> myTree;

        public void CreateTree()
        {
            var path = Path.GetFileName(GetPath());
            string jsonFile = File.ReadAllText(path);

            //var jsonObject = JsonConvert.DeserializeObject<List<DeweyLibrary.Root>>(jsonFile);
          
            var tNode = treeView1.Nodes[treeView1.Nodes.Add(new TreeNode(jsonFile))];
            tNode.Tag = jsonFile;
            // TreeNode<string> root = new TreeNode<string>("root");
           
        }
        
    /// <summary>
    /// Find lowest point of the tree
    /// </summary>
        public void FindLeaf()
        {
            int i = 0;
            foreach(var item in TreeData.GetSet1() )
            {
                //if item is leaf add to leaf list
                if(item.IsLeaf)
                {
                    i++;
                    string t = item.ToString();
                    LeafList.Add(t);
                }
            }
        }
       /// <summary>
       /// Get a random leaf out of the leaf List
       /// </summary>
        public void GetRandomLeaf()
        {
            FindLeaf();
            int i = Library.rnd.Next(LeafList.Count);
            //Make Label equal to random leaf list item
            question.Text = LeafList[i];
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
            foreach (var item in TreeData.GetSet1())
            {
                //If the item is at the correct level add to Parent List
                if (item.Level == level)
                {
                    string t = item.ToString();
                    ParentList.Add(t);
                }

            }
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
            TreeNode<string> found = treeRoot.FindTreeNode(node => node.Data != null && node.Data.Contains(question.Text));
            //Find Parent of Correct Answer
            TreeNode<string> ParentOfFound = (found.Parent).Parent;
            //Get random number between 1-4
            int i = Library.rnd.Next(Labels.Count);
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

