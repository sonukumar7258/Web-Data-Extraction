using k190169_Q4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace k190169_Q4.Controllers
{
    public class HomeController : Controller
    {
        List<String> _Categories = new List<String>();
        List<String> Scripts_Title = new List<String>();
        List<String> totalPrices = new List<String>();

        List<List<String>> final = new List<List<String>>();
        //List<String> temp1 = new List<String>();
        List<List<String>> prices = new List<List<String>>();
        String category = "";
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            calculateCategoriesScriptsPrices();

            ViewBag.Categories = new SelectList(_Categories,"Categories");
            ViewBag.scripts = new SelectList(Scripts_Title, "Scripts");
            ViewBag.prices = new SelectList(totalPrices, "Prices");

            return View();
        }

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





        /*        public IActionResult Privacy()
                {
                    return View();
                }

                [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
                public IActionResult Error()
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }*/
    }
}
