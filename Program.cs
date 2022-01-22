using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Timers;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Web;
using System.Net;


namespace ToolsQA
{
    using System.Net.Http;

    class Program
    {

        static string getPageData(string url)
        {
            HttpWebResponse response = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(url)).GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();
                return data;

                response.Close();
                readStream.Close();
            }
            else
            {
                Console.WriteLine(response.StatusCode.ToString());
                return "";
            }
        }
        static void Main(string[] args)
        {
            getPageData("https://www.wikipedia.org/wiki/computer");
            Console.ReadLine();
            
        }

    }
}