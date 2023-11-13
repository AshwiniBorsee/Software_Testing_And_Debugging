using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebUI
{

    public class PdfFileTests
    {
        private IWebDriver driver;
        private const string PdfFilePath = "https://ncu.rcnpv.com.tw/Uploads/20131231103232738561744.pdf";

        public PdfFileTests()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("headless");
            // Set up your WebDriver (in this case, ChromeDriver)
            driver = new EdgeDriver();
            
        }

        [Fact]
        public void ReadPdfContent()
        {
            
            // Navigate to a webpage that contains a link to the PDF file
            driver.Navigate().GoToUrl(PdfFilePath);
            Thread.Sleep(10000);

            driver.Manage().Window.Maximize();

            Thread.Sleep(10000);

            var pageSelectorInput = driver.FindElement(By.Id("pageselector"));
            Console.WriteLine();
            // Now, you can interact with the pageSelectorInput as needed
            pageSelectorInput.Clear();
            pageSelectorInput.SendKeys("2\n");  // Enter the desired page number

            // Additional actions as needed...

            // Close the browser
            driver.Quit();



                    }


        // Optionally, you can add a [Fact] method to close the WebDriver after all tests
        
    }
}

