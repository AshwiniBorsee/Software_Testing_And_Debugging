using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace WebUI
{
    public class SeleniumStarbucksWebsiteTests
    {
        [Theory]
        [InlineData(1, "Edge", 1000)]
        //[InlineData(2, "Chrome", 1000)]
        //[InlineData(3, "Firefox", 5000)]
        public void FindAStoreLocation(int whichBrowser, string browserName, int submitWait)
        {
            // arrange
            IWebDriver driver;
            switch (whichBrowser)
            {
                case 1:
                    driver = new ChromeDriver();
                    break;
                case 2:
                    driver = new EdgeDriver();
                    break;
                case 3:
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("-disable-geolocation");
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                default:
                    throw new ArgumentException("Unknown browser {0}", browserName);
            }
            // act
            driver.Navigate().GoToUrl("https://www.starbucks.com");
            // We had to expand the window to make sure the link shows up instead of being collapsed in the hamburger menu
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.PageSource);
            var storeLink = driver.FindElement(By.LinkText("Find a store"));
            storeLink.Click();
            // assert
            Assert.StartsWith("https://www.starbucks.com/store-locator", driver.Url);

            // act 2
            var searchCriteria = driver.FindElement(By.Name("place"));
            searchCriteria.Click();
            // lookup for zip code include the enter at the end
            searchCriteria.SendKeys("98122\n");
            searchCriteria.Submit();
            // wait a few second for results - worked with 1000 for Chrome and Edge, Firefox permissions prompt took longer
            Thread.Sleep(submitWait);
            // Validating the desired store is present
            var storeSUbutton = driver.FindElement(By.XPath(@"//button[@aria-label=""Select 12th & Columbia""]"));

            // assert 2
            Assert.NotNull(storeSUbutton);

            // act 3 - assert the desired store is now selected
            storeSUbutton.Click();
            var newStoreSUbutton = driver.FindElement(By.XPath(@"//button[@aria-label=""12th & Columbia Selected""]"));
            // assert 3
            Assert.NotNull(newStoreSUbutton);
            driver.Close();
        }
    }
}