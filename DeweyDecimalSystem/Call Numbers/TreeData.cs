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
            

            
           // var path = Path.GetFileName(GetPath());
           // string jsonFile = File.ReadAllText(path);

            //var jsonObject = JsonConvert.DeserializeObject<List<DeweyLibrary.Root>>(jsonFile);

            // var tree = new TreeNode ("root")
           /* TreeNode<string> tree = new TreeNode<string>("root");
            {
                foreach (var item in jsonObject)
                {
                    new TreeNode<string>(item.callnumber + item.description);


                }*/

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
                        TreeNode<string> node114 = node11.AddChild("125 Not assigned or no longer used ");
                        TreeNode<string> node115 = node11.AddChild("126 The self");
                        TreeNode<string> node116 = node11.AddChild("127 The unconscious & the subconscious");
                        TreeNode<string> node117 = node11.AddChild("128 Humankind ");
                    }
                }


            }
            return root;
            }

        }
    }

    

    
    /*000 - General Knowledge
    •	010 - Bibliography
    o	011 Bibliographies 
    o	012 Bibliographies of individuals
    o	013 Bibliographies of works by specific classes of authors
    o	014  Bibliographies of anonymous and pseudonymous works
    o	015 Bibliographies of works from specific places
    o	016 Bibliographies of works from specific subjects
    o	017 General subject catalogues
    o	018 Catalogues arranged by author & date

    100 - Philosophy and Psychology
    •	120 - Epistemology
    o	121  Epistemology (Theory of knowledge)
    o	122 Causation
    o	123 Determinism & indeterminism
    o	124 Teleology
    o	125 Not assigned or no longer used 
    o	126 The self
    o	127 The unconscious & the subconscious
    o	128 Humankind 






    200 - Religion 
    •	230 – Christian theology
    o	231 God 
    o	232 Jesus Christ & his family
    o	233 Humankind 
    o	234 Salvation (Soteriology) & grace
    o	235 Spiritual beings
    o	236 Eschatology
    o	237 Not assigned or no longer used
    o	238 Creeds & catechisms

    300 - Social Sciences
    •	340 - Law
    o	341 International law
    o	342 Constitutional & administrative law
    o	343 Military, tax, trade, industrial law
    o	344 Social, labour, welfare, & related law
    o	345 Criminal law
    o	346 Private law
    o	347 Civil procedure & courts
    o	348 Law (Statutes), regulations, cases








    400 - Languages 
    •	450 – Italian, Romanian and Rhaeto-Roman
    o	451 Italian writing system & phonology
    o	452 Italian etymology
    o	453 Italian dictionaries
    o	454 Not assigned or no longer used
    o	455 Italian grammar
    o	456  Not assigned or no longer used 
    o	457 Italian language variations
    o	458 Standard Italian usage

    500 - Science 
    •	560 – Palaeontology Paleozoology
    o	561 Palaeobotany 562 Palaeobotany
    o	562 Fossil invertebrates
    o	563 Fossil primitive phyla
    o	564 Fossil Mollusca & Molluscoidea
    o	565 Other fossil invertebrates 
    o	566 Fossil Vertebrata (Fossil Craniata) 
    o	567 Fossil cold-blooded vertebrates 
    o	568 Fossil Aves (Fossil birds)








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


