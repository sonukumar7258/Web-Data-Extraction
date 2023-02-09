using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k190169_Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Use:  htmlDoc.LoadHtml(xmlString);  to load from a string (was htmlDoc.LoadXML(xmlString)
        List<String> _Categories = new List<String>();
        List<String> Scripts_Title = new List<String>();
        List<String> totalPrices = new List<String>();

        List<List<String>> final = new List<List<String>>();
        List<List<String>> prices = new List<List<String>>();

        private void calculateCategoriesScriptsPrices()
        {
            String filePath = "Summary16Oct2022.html";
            

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            // There are various options, set as needed
            htmlDoc.OptionFixNestedTags = true;

            // filePath is a path to a file containing the html
            htmlDoc.Load(filePath);

    

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

                        _Categories.Add(temp);
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
                                totalPrices.Add(allth[allth.IndexOf(Scripts_Title[i].Trim()) + 1]);
                            }
                        }
                        final.Add(temp);
                        prices.Add(temp1);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calculateCategoriesScriptsPrices();
            populateCategories();
            populateScriptsPrices();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void populateCategories()
        {
            Categories[] categories = new Categories[_Categories.Count];

            for(int i = 0;i< _Categories.Count; i++)
            {
                categories[i] = new Categories();
                categories[i].category = _Categories[i];
                //categories[i].Click += OnLabelClicked;
                flowLayoutPanel1.Controls.Add(categories[i]);
            }
        }
        private void populateScriptsPrices()
        {
            scriptTiltle[] script = new scriptTiltle[Scripts_Title.Count];
            Price[] price = new Price[totalPrices.Count];

            for (int i = 0; i < Scripts_Title.Count; i++)
            {
                script[i] = new scriptTiltle();
                price[i] = new Price();

                script[i].ScriptTitle = Scripts_Title[i];
                price[i].price = totalPrices[i];


                flowLayoutPanel2.Controls.Add(script[i]);
                flowLayoutPanel3.Controls.Add(price[i]);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculateCategoriesScriptsPrices();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
