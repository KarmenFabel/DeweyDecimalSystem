using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DeweyDecimalSystem.Call_Numbers
{
    public partial class CallNumber
    {
        //SearchExample("210");

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
        List<string> LeafList = new List<string>();
    
        public void FindLeaf()
        {
            int i = 0;
            foreach(var item in TreeData.GetSet1() )
            {
                if(item.IsLeaf)
                {
                    i++;
                    string t = item.ToString();
                    LeafList.Add(t);
                    //int count = (int)new Random().Next(0, item + 1);
                    //return randomNodeUtil(root, count);
                }
            }
        }
        public void GetRandomThird()
        {
            FindLeaf();
            int i = DeweyLibrary.Library.rnd.Next(LeafList.Count);
            question.Text = LeafList[i];
            GetCorrectParent();

        }
        /// <summary>
        /// Adding List to array of labels
        /// </summary>
        List<Label> Labels = new List<Label>();
        public void AnswerLabelsList()
        {
            Labels.Add(answer1);
            Labels.Add(answer2);
            Labels.Add(answer3);
            Labels.Add(answer4);


        }
        
       
        public void GetCorrectParent()
        { 
            TreeNode<string> treeRoot = TreeData.GetSet1();
            TreeNode<string> found = treeRoot.FindTreeNode(node => node.Data != null && node.Data.Contains(question.Text));
            TreeNode<string> ParentOfFound = (found.Parent).Parent;
            int i = DeweyLibrary.Library.rnd.Next(Labels.Count);
            Labels[i].Text = found.Parent.ToString();
            for(var x = 0; x!=i; x++)
            {
                Labels[x].Text = ParentOfFound.Children.ToString();

            }

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
    }
   
}


//Reference:
//How to recursively populate a TreeView with JSON data
//https://stackoverflow.com/questions/39673815/how-to-recursively-populate-a-treeview-with-json-data

