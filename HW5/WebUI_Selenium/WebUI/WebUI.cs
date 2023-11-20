using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;


namespace WebUI
{
    public class DataUsaHomePageTests : IDisposable
    {
        private readonly string testUrl = "https://datausa.io/";
        public IWebDriver driver;

        public DataUsaHomePageTests()
        {
            // Initialize the WebDriver in the constructor
            driver = new ChromeDriver();
            // Set implicit wait for a reasonable default wait time
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Fact]
        public void PerformSearchInChrome()
        {
            // Arrange
            NavigateToUrl(testUrl);

            // Act
            PerformSearch("Washington ");

            // Assert
            Assert.StartsWith("https://datausa.io/profile/geo/washington", driver.Url);
        }

        [Fact]
        public void PerformSearchInEdge()
        {
            // Arrange
            driver = new EdgeDriver();
            NavigateToUrl(testUrl);

            // Act
            PerformSearch("Washington ");

            // Assert
            Assert.StartsWith("https://datausa.io/profile/geo/washington", driver.Url);
        }

        [Fact]
        public void PerformSearchInFirefox()
        {
            // Arrange
            driver = new FirefoxDriver();
            NavigateToUrl(testUrl);

            // Act
            PerformSearch("Washington ");

            // Assert
            Assert.StartsWith("https://datausa.io/profile/geo/washington", driver.Url);
        }

        private void PerformSearch(string searchTerm)
        {
            // Interaction with the page elements
            var searchBox = driver.FindElement(By.CssSelector("#App > div.home > header > div.home-header-content > div.home-right > div.bp3-control-group.home-search > div > input"));
            //var searchButton = driver.FindElement(By.CssSelector("#App > div.home > header > div.home-header-content > div.home-right > div.bp3-control-group.home-search > div > a"));
            searchBox.SendKeys(searchTerm);

            //IWebElement dropdownElement = driver.FindElement(By.CssSelector("#App > div.home > header > div.home-header-content > div.home-right > div.bp3-control-group.home-search.active > ul > li:nth-child(1) > a"));
            var searchButton = driver.FindElement(By.CssSelector("#App > div.home > header > div.home-header-content > div.home-right > div.bp3-control-group.home-search.active > ul > li:nth-child(1) > a"));
            //searchBox.SendKeys(searchTerm);

            //var select = new SelectElement(dropdownElement);
            //select.SelectByIndex(1);
            //Thread.Sleep(5000);
            searchButton.Click();

            // Wait for results - you might need a more robust wait strategy
            Thread.Sleep(1000);
        }

        private void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
            driver.Quit();
           driver.Dispose();
        }
    }
}
