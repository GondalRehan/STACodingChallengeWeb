using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowTFLJourneyPlanner.PageObjects
{

    public class JourneyPlannerPage
        {
            private readonly IWebDriver _driver;
            private readonly WebDriverWait _wait;

            public JourneyPlannerPage(IWebDriver driver)
            {
                _driver = driver;
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            }

        public void NavigateToHomepage() => _driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey");

        public void EnterFromLocation(string location)
        {
            var fromField = _driver.FindElement(By.Id("InputFrom"));
            fromField.SendKeys(location);

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//li[contains(text(), '{location}')]"))).Click();
        }
        public void EnterToLocation(string location)
        {
            var toField = _driver.FindElement(By.Id("InputTo"));
            toField.SendKeys(location);
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//li[contains(text(), '{location}')]"))).Click();
        }

        public void ClickPlanJourney()
        {
            _driver.FindElement(By.CssSelector("button[aria-label='Plan my journey']")).Click();
        }
        public bool IsJourneyResultsDisplayed()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.journey-results")));
            return _driver.FindElement(By.CssSelector("div.journey-results")).Displayed;
        }

        public bool IsWalkingTimeDisplayed() => _driver.FindElements(By.XPath("//*[contains(text(), 'Walking time')]")).Count > 0;

       // public bool IsCyclingTimeDisplayed() => _driver.FindElements(By.XPath("//*[contains(text(), 'Cycling time')]

        //    public bool IsJourneyResultsDisplayed()
        //{
        //    _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.journey-results")));
        //    return _driver.FindElement(By.CssSelector("div.journey-results")).Displayed;
        //}

// public bool IsWalkingTimeDisplayed() => _driver.FindElements(By.XPath("//*[contains(text(), 'Walking time')]")).Count > 0;

 public bool IsCyclingTimeDisplayed() => _driver.FindElements(By.XPath("//*[contains(text(), 'Cycling time')]")).Count > 0;
    }
}


    
