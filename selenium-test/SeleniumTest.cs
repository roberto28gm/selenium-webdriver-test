using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_test
{
    public class SeleniumTest
    {
        IWebDriver driver { get; set; }

        public SeleniumTest()
        {
            this.driver = new ChromeDriver();
        }

        public void ShowWebInfo()
        {
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            var title = driver.Title;
            Console.WriteLine("Title: " + title);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var textBox = driver.FindElement(By.Name("my-text"));
            var submitButton = driver.FindElement(By.TagName("button"));

            textBox.SendKeys("Selenium");
            submitButton.Click();

            var message = driver.FindElement(By.Id("message"));
            var value = message.Text;
            Console.WriteLine("Text: " + value);
        }

        public void ShowLatestNews()
        {
            driver.Navigate().GoToUrl("https://www.rtve.es/noticias/");
            driver.Manage().Window.Maximize();
            var title = driver.Title;
            Console.WriteLine("\n");
            Console.WriteLine("Showing latest news from https://www.rtve.es/noticias/");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("-------------------------------------------------------------");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);


            // Accept Cookies
            var cookiesBtn = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            cookiesBtn.Click();
            Thread.Sleep(1000);

            var titles = driver.FindElements(By.ClassName("maintitle"));

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("\t" + titles[i].Text + "");
            }


            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();

            if (!Directory.Exists("screenshots"))
            {
                Directory.CreateDirectory("screenshots");
            }
            string filename = "screenshots\\" + DateTime.Now.ToString("yyyy-MM-dd__HH-mm-ss") + ".png";
            
            // Format values are Bmp, Gif, Jpeg, Png, Tiff
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
        }


        public void StopDriver()
        {
            driver.Quit();
        }
    }
}
