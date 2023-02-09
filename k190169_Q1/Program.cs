using System;
using System.IO;
using System.Net;

namespace k190169_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"Jan", "Feb", "Mar", "Apr", "May",
                                "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"};
            Console.WriteLine("Enter Url: ");
            String url = Console.ReadLine();
            Console.WriteLine("Enter Location of Specified Folder: ");
            String finalFolder = Console.ReadLine();

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();

            Console.WriteLine("Downloading Html Data----");
            // DownloadHtml Format of that webpage and treated as String and Store into the data
            String data = myWebClient.DownloadString(url);

            DateTime now = DateTime.Now;
            // get the todays date 
            // String todaysDate = now.Day.ToString() + months[now.Month - 1] + now.Year.ToString(); // by this we can generate todaydate named file
            String todaysDate = "16Oct22";
            // Set the name of folder of todays date
            finalFolder += "\\" + "Summary" + todaysDate + ".html";

            // Store String into HTML File
            File.WriteAllText(finalFolder, data);

            Console.WriteLine("File Downloaded Successfully at Location : {0} from {1} ", finalFolder, url);

        }
    }
}
