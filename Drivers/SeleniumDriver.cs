using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SpecFlowTFLJourneyPlanner.Drivers
{
    public class SeleniumDriver
        {
            private IWebDriver _driver;

            public IWebDriver InitializeDriver()
            {
              //  var options = new ChromeOptions();
            var options = new FirefoxOptions();
            options.AddArgument("headless");  // Optional: Run in headless mode
               // _driver = new ChromeDriver(options);
            _driver = new FirefoxDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return _driver;
            }

            public void CloseDriver() => _driver.Quit();
        }
    }

