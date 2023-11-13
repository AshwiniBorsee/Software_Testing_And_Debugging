using System;
using iText.Commons.Utils;
using iText.Forms.Form.Element;
using iText.Layout.Element;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace WebUI
{
    public class PDFReaderTest
    {
        public required IWebDriver driver;
        private readonly string pdfFileUrl = "https://ncu.rcnpv.com.tw/Uploads/20131231103232738561744.pdf";

        [Fact]
        private void PerformInChrome()
        {
            //Initialised a webdriver
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            driver = new ChromeDriver(chromeOptions);

            Console.WriteLine("Open the pdf");
            driver.Navigate().GoToUrl(pdfFileUrl);
            Thread.Sleep(10000);

            IWebElement pageNumberInput = driver.FindElement(By.Id("pageSelector"));
            Assert.NotNull(pageNumberInput);
            pageNumberInput.Clear();
            // Enter the page number and press Enter
            pageNumberInput.SendKeys("2");
            pageNumberInput.SendKeys(Keys.Enter);

            //Perform the zoom-in action, e.g., click the zoom -in button

            IWebElement zoomInButton = driver.FindElement(By.CssSelector("#zoom-controls > cr-icon-button:nth-child(3)"));

            // Perform the zoom-in action, e.g., click the zoom-in button
            zoomInButton.Click();

            // Additional verification steps based on your requirements
            // check if the zoom level has changed
            IWebElement zoomLevelIndicator = driver.FindElement(By.CssSelector("#zoom-controls > cr-icon-button:nth-child(3)"));
            Assert.NotNull(zoomLevelIndicator);
            driver.Quit();

        }

        [Fact]
        private void PerformInEdge()
        {
            //Initialised a webdriver
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            driver = new ChromeDriver(chromeOptions);

            Console.WriteLine("Open the pdf");
            driver.Navigate().GoToUrl(pdfFileUrl);
            Thread.Sleep(10000);

            IWebElement pageNumberInput = driver.FindElement(By.Id("pageselector"));
            Assert.NotNull(pageNumberInput);
            pageNumberInput.Clear();
            // Enter the page number and press Enter
            pageNumberInput.SendKeys("2");
            pageNumberInput.SendKeys(Keys.Enter);

            //Perform the zoom-in action, e.g., click the zoom -in button

            IWebElement zoomInButton = driver.FindElement(By.XPath("//*[@id=\"zoom-in\"]"));

            // Perform the zoom-in action, e.g., click the zoom-in button
            zoomInButton.Click();

            // Additional verification steps based on your requirements
            // check if the zoom level has changed
            IWebElement zoomLevelIndicator = driver.FindElement(By.XPath("//*[@id=\"zoom-in\"]"));
            Assert.NotNull(zoomLevelIndicator);
            driver.Quit();

        }

        [Fact]
        private void PerformInFireFox()
        {
            //Initialised a webdriver
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            driver = new ChromeDriver(chromeOptions);

            Console.WriteLine("Open the pdf");
            driver.Navigate().GoToUrl(pdfFileUrl);
            Thread.Sleep(10000);

            IWebElement pageNumberInput = driver.FindElement(By.Id("pageNumber"));
            //Assert.NotNull(pageNumberInput);
            pageNumberInput.Clear();
            // Enter the page number and press Enter
            pageNumberInput.SendKeys("2");
            pageNumberInput.SendKeys(Keys.Enter);

            //Perform the zoom-in action, e.g., click the zoom -in button

            IWebElement zoomInButton = driver.FindElement(By.CssSelector("#zoomIn"));

            // Perform the zoom-in action, e.g., click the zoom-in button
            zoomInButton.Click();

            // Additional verification steps based on your requirements
            // Check if the zoom level has changed
            IWebElement zoomLevelIndicator = driver.FindElement(By.CssSelector("#zoomIn"));
            Assert.NotNull(zoomLevelIndicator);
            driver.Quit();

        }
    }
}
