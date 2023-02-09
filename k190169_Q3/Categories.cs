using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace k190169_Q3
{
    public partial class Categories : UserControl
    {
        List<String> _Categories = new List<String>();
        List<String> Scripts_Title = new List<String>();
        List<String> totalPrices = new List<String>();

        List<List<String>> final = new List<List<String>>();
        //List<String> temp1 = new List<String>();
        List<List<String>> prices = new List<List<String>>();
        public Categories()
        {
            InitializeComponent();
        }
        #region Properties 


        private String _category;

        [Category("Custom Props")]
        public String category
        {
            get { return _category; }
            set { _category = value; Category.Text = value; }
        }

        #endregion

        private void Category_Click(object sender, EventArgs e)
        {
                // Cast the object to the clicked label
                Label clickedLabel = (Label)sender;
            // Here you can also check the name of the label if you need
            String category = clickedLabel.Text.ToString().Trim();
            calculateCategoriesScriptsPrices();

            int findIndex = _Categories.IndexOf(category);

            string scripts = string.Join("  ", final[findIndex]);
            string scriptPrices = string.Join("  ", prices[findIndex]);


            MessageBox.Show(scripts,"Scripts");
            MessageBox.Show(scriptPrices, "Prices");
            // Make the font of the clicked label bold






        }

        private void calculateCategoriesScriptsPrices()
        {
            String filePath = "Summary16Oct2022.html";
            //filePath = Console.ReadLine();

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
    }
}
