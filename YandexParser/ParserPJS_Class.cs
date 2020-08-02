using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using System.Windows;
using System.Threading;

namespace YandexParser
{
    class ParserPJS_Class
    {


        public string Pars(string search_Name)
        //public Uslugio_Class Pars(string search_Name)
        {
           // Uslugio_Class uslugio_Class = new Uslugio_Class();

            IWebDriver PJS;
            //PJS = new PhantomJSDriver();
            PJS = new ChromeDriver();
            PJS.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            PJS.Manage().Window.Maximize();
            PJS.Navigate().GoToUrl("https://yandex.ru/");
            IWebElement Search = PJS.FindElement(By.Id("text"));
            Search.SendKeys(search_Name);
            Search.SendKeys(Keys.Enter);

            PJS.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            string test = "jhj";
            for (int i = 1; i < 10; i++)
            {
                string SearchString = $"/ html / body / div[3] / div[1] / div[2] / div[1] / div[1] / ul / li[{i}] / div / h2 / a / div[2]";
                Search = PJS.FindElement(By.XPath(SearchString));
                Search.Click();
                PJS.SwitchTo().Window(PJS.WindowHandles[1]);

                
                test = PJS.Url;

                if (PJS.Url.Contains("uslugio.com"))
                {
                    test = "uslugio.com на"+i.ToString();
                }
                else
                {
                    PJS.Close();
                }
            }
            return test;
        }
    }
}
