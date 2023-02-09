using System;
using System.Collections.Generic;
using System.Xml;

namespace k190169_Q2
{
    class Program
    {
        static void createNode(string Script, string Price, XmlTextWriter writer)
        {
            writer.WriteStartElement("Scripts");
            writer.WriteStartElement("Script");
            writer.WriteString(Script);
            writer.WriteEndElement();
            writer.WriteStartElement("Price");
            writer.WriteString(Price);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        static void Main(string[] args)
        {
            
            //Console.WriteLine("Enter url : ");
            String filePath = "Summary16Oct2022.html";
            //filePath = Console.ReadLine();

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            // There are various options, set as needed
            htmlDoc.OptionFixNestedTags = true;

            // filePath is a path to a file containing the html
            htmlDoc.Load(filePath);

            // Use:  htmlDoc.LoadHtml(xmlString);  to load from a string (was htmlDoc.LoadXML(xmlString)
            List<String> Categories = new List<String>();
            List<String> Scripts_Title = new List<String>();
           
            List<List<String>> final = new List<List<String>>();
            //List<String> temp1 = new List<String>();
            List<List<String>> prices = new List<List<String>>();

            if (htmlDoc.DocumentNode != null)
                {
                    HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

                    if (bodyNode != null)
                    {
                        var snode = htmlDoc.DocumentNode.SelectNodes("//div[@class = 'table-responsive']");
                        var nodes = htmlDoc.DocumentNode.SelectNodes("//th[@colspan =8]");
                        var innerNodes = htmlDoc.DocumentNode.SelectNodes("//td[@class = 'dataportal']");


                    var tempNode = htmlDoc.DocumentNode.SelectNodes("//div[@class = 'table-responsive']//td");
                    List<String> allth = new List<String>();
                     foreach (var node in tempNode)
                    {
                        allth.Add(node.InnerText.ToString().Trim());
                    }


                    foreach (var node in nodes)
                    {
                        String temp = node.InnerText.ToString().Trim();
                        temp = temp.Replace(".", "");
                        temp = temp.Replace("/", "");
                        temp = temp.Replace("-", "");
                        
                        Categories.Add(temp);
                    }
                    foreach (var node in innerNodes)
                    {
                        Scripts_Title.Add(node.InnerText.Trim());
                       
                    }
                    foreach (var node in snode)
                    {

                        List<String> temp = new List<String>();
                        List<String> temp1 = new List<String>();
                        for (int i = 0; i < Scripts_Title.Count; i++)
                        {
                            if (node.InnerText.Contains(Scripts_Title[i]))
                            {
                                temp.Add(Scripts_Title[i]);
                                temp1.Add(allth[allth.IndexOf(Scripts_Title[i].Trim()) + 1]);
                            }
                        }
                        final.Add(temp);
                        prices.Add(temp1);
                    }
                }
            }

            // Write Each Category Files to xml
            for (int i = 0; i < final.Count; i++)
            {
               
                XmlTextWriter writer = new XmlTextWriter("Q2XmlFiles\\" + Categories[i] + ".xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("xml");
                for (int j = 0; j < final[i].Count; j++)
                {
                    createNode(final[i][j], prices[i][j], writer);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }
    }
}
