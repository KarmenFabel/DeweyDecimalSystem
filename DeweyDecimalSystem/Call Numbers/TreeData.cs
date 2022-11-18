using DeweyLibrary;
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
    public class TreeData
    {
        public static string GetPath()
        {
            //Get json file containing all Dewey Information
            string executableLocation = Path.GetDirectoryName(
        Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(executableLocation, "FindingCallNumbers.json");
            return path;
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

        public static TreeNode<string> GetSet1()
        {

            
            /*
            var path = Path.GetFileName(GetPath());
            string jsonFile = File.ReadAllText(path);
           

            var jsonObject = JsonConvert.DeserializeObject<List<Root>>(jsonFile);
            //var newJsonObj = JsonConvert.DeserializeObject(jsonFile);

            //var tree = new TreeNode ("root")
            foreach (var thing in jsonObject)
            {
                TreeNode<Root> tree = new TreeNode<DeweyLibrary.Root>(thing.callnumber + thing.description);
                {
                    foreach (var item in tree)
                    {
                        new TreeNode<string>(item.callnumber + item.description);


                    }
                }
            }*/
           

            var path = Path.GetFileName(GetPath());
            string jsonFile = File.ReadAllText(path);
            

            var jsonObject = JsonConvert.DeserializeObject<List<Root>>(jsonFile);
      

            TreeNode<string> root = new TreeNode<string>("root");
            {
                TreeNode<string> node0 = root.AddChild("000 General Knowledge");
                {

                    TreeNode<string> node01 = node0.AddChild("010 - Bibliography");
                    {
                        TreeNode<string> node011 = node01.AddChild("011 Bibliographies ");
                        TreeNode<string> node012 = node01.AddChild("012 Bibliographies of individuals");
                        TreeNode<string> node013 = node01.AddChild("013 Bibliographies of works by specific classes of authors");
                        TreeNode<string> node014 = node01.AddChild("014  Bibliographies of anonymous and pseudonymous works");
                    }
                    

                }
                TreeNode<string> node1 = root.AddChild("100 - Philosophy and Psychology");
                {
                    TreeNode<string> node11 = node1.AddChild("120 - Epistemology");
                    {
                        TreeNode<string> node111 = node11.AddChild("121 Epistemology (Theory of knowledge) ");
                        TreeNode<string> node112 = node11.AddChild("122 Causation");
                        TreeNode<string> node113 = node11.AddChild("123 Determinism & indeterminism");
                        TreeNode<string> node115 = node11.AddChild("126 The self");
                        TreeNode<string> node116 = node11.AddChild("127 The unconscious & the subconscious");
                        TreeNode<string> node117 = node11.AddChild("128 Humankind ");
                    }
                }
                TreeNode<string> node2 = root.AddChild("200 - Religion ");
                {
                    TreeNode<string> node11 = node1.AddChild("230 – Christian theology");
                    {
                        TreeNode<string> node111 = node11.AddChild("231 God");
                        TreeNode<string> node112 = node11.AddChild("232 Jesus Christ & his family");
                        TreeNode<string> node113 = node11.AddChild("233 Humankind ");
                        TreeNode<string> node114 = node11.AddChild("234 Salvation (Soteriology) & grace");
                        TreeNode<string> node115 = node11.AddChild("235 Spiritual beings");
                        TreeNode<string> node116 = node11.AddChild("236 Eschatology");
                        TreeNode<string> node117 = node11.AddChild("238 Creeds & catechisms");
                    }
                }
                TreeNode<string> node3 = root.AddChild("300 - Social Sciences");
                {
                    TreeNode<string> node11 = node1.AddChild("340 - Law");
                    {
                        TreeNode<string> node111 = node11.AddChild("341 International law");
                        TreeNode<string> node112 = node11.AddChild("342 Constitutional & administrative law");
                        TreeNode<string> node113 = node11.AddChild("343 Military, tax, trade, industrial law");
                        TreeNode<string> node114 = node11.AddChild("344 Social, labour, welfare, & related law");
                        TreeNode<string> node115 = node11.AddChild("345 Criminal law");
                        TreeNode<string> node116 = node11.AddChild("346 Private law");
                        TreeNode<string> node117 = node11.AddChild("347 Civil procedure & courts");
                        TreeNode<string> node118 = node11.AddChild("348 Law (Statutes), regulations, cases");
                    }
                }
                TreeNode<string> node4 = root.AddChild(" 400 - Languages ");
                {
                    TreeNode<string> node11 = node1.AddChild("450 – Italian, Romanian and Rhaeto-Roman");
                    {
                        TreeNode<string> node111 = node11.AddChild("451 Italian writing system & phonology");
                        TreeNode<string> node112 = node11.AddChild("452 Italian etymology");
                        TreeNode<string> node113 = node11.AddChild("453 Italian dictionaries");
                        TreeNode<string> node114 = node11.AddChild("454 Not assigned or no longer used");
                        TreeNode<string> node115 = node11.AddChild("455 Italian grammar");
                        TreeNode<string> node116 = node11.AddChild("457 Italian language variations");
                        TreeNode<string> node117 = node11.AddChild("458 Standard Italian usage");
                    }
                }
                TreeNode<string> node5= root.AddChild("500 - Science");
                {
                    TreeNode<string> node11 = node1.AddChild("560 – Palaeontology Paleozoology");
                    {
                        TreeNode<string> node111 = node11.AddChild("561 Palaeobotany 562 Palaeobotany");
                        TreeNode<string> node112 = node11.AddChild("562 Fossil invertebrates");
                        TreeNode<string> node113 = node11.AddChild("563 Fossil primitive phyla");
                        TreeNode<string> node114 = node11.AddChild("564 Fossil Mollusca & Molluscoidea");
                        TreeNode<string> node115 = node11.AddChild("565 Other fossil invertebrates ");
                        TreeNode<string> node116 = node11.AddChild("566 Fossil Vertebrata (Fossil Craniata) ");
                        TreeNode<string> node117 = node11.AddChild("567 Fossil cold-blooded vertebrates ");
                        TreeNode<string> node118 = node11.AddChild("5568 Fossil Aves (Fossil birds) ");
                    }
                }
            }
            return root;
            }

        }
    }
    /*
    


    600 - Technology 
    •	670 - Manufacturing
    o	671 Metalworking & metal products
    o	672 Iron, steel, other iron alloys
    o	673 Nonferrous metals
    o	674 Lumber processing, wood products, cork
    o	675 Leather & fur processing
    o	676 Pulp & paper technology
    o	677 Textiles
    o	678 Elastomers & elastomer products

    700 - Arts and Recreation
    •	780 - Music
    o	781 General principles & musical forms
    o	782 Vocal music
    o	783 Music for single voices
    o	784  Instruments & Instrumental ensembles
    o	785 Chamber music
    o	786 Keyboard & other instruments
    o	787 Stringed instruments (Chordophones)
    o	788 Wind instruments (Aerophones)









    800 - Literature
    •	830 – Literatures of Germanic languages
    o	831 Early to 1517
    o	832 Reformation, etc.  1517-1750
    o	833 Classic period,  1750-1830
    o	834 Post classic & modern,  1830-1940/50
    o	835 Contemporary authors not already established
    o	836 German dialect literature
    o	837 German American
    o	838 German miscellaneous writings

    900 - History and Geography
    •	910 - Geography and Travel
    o	911 Historical geography 
    o	912 Graphic representations of earth
    o	913 Ancient world 
    o	914 Europe
    o	915 Asia 
    o	916 Africa 
    o	917 North America
    o	918 South America
    */


