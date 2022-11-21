using DeweyLibrary;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace DeweyDecimalSystem.Call_Numbers
{
    public class TreeData
    {
        //The Tree
        private static TreeNode<string> myTree { get; set; }
        /// <summary>
        /// Get the Path of the Json File
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            //Get json file containing all Dewey Information
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(executableLocation, "FindingCallNumberswArray.json");
            return path;
        }
        /// <summary>
        /// Get Json File Data into Tree
        /// </summary>
        /// <returns></returns>
        public static TreeNode<string> GetTreeData()
        {
            var path = Path.GetFileName(GetPath());
            string jsonFile = File.ReadAllText(path);
            var jsonObject = JsonConvert.DeserializeObject<Root>(jsonFile);
            myTree = new TreeNode<string>(jsonObject.root);
            {
                foreach (var item in jsonObject.contents)
                {
                    TreeNode<string> FirstIt = myTree.AddChild(item.callnumber + " " + item.description);
                    {
                        foreach (var newThing in item.SecondIteration)
                        {
                            TreeNode<string> ParentNodeCall = FirstIt.AddChild(newThing.callnumber + " " + newThing.description);
                            {
                                foreach (var thing in newThing.ThirdIteration)
                                {
                                    TreeNode<string> ChildNodeCall = ParentNodeCall.AddChild(thing.callnumber + " "         + thing.description);
                                 }

                            }
                        }
                    }
                }
            }
            return myTree;
        }
    }
}



