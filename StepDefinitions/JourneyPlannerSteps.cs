using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTFLJourneyPlanner.Drivers;
using SpecFlowTFLJourneyPlanner.PageObjects;

namespace SpecFlowTFLJourneyPlanner.StepDefinitions
{
    [Binding]
public class JourneyPlannerSteps
        {
            private readonly IWebDriver _driver;
            private readonly JourneyPlannerPage _journeyPlannerPage;

            public JourneyPlannerSteps()
            {
                var seleniumDriver = new SeleniumDriver();
                _driver = seleniumDriver.InitializeDriver();
                _journeyPlannerPage = new JourneyPlannerPage(_driver);
            }

            [Given(@"the user is on the TfL homepage")]
            public void GivenTheUserIsOnTheTfLHomepage()
        {
            _journeyPlannerPage.NavigateToHomepage();
        }
        [When(@"they enter ""(.*)"" in the ""From"" field and select it from autocomplete")]
        public void WhenTheyEnterInTheFromFieldAndSelectItFromAutocomplete(string fromLocation)
        {
            _journeyPlannerPage.EnterFromLocation(fromLocation);
        }
        [When(@"they enter ""(.*)"" in the ""To"" field and select it from autocomplete")]
        public void WhenTheyEnterInTheToFieldAndSelectItFromAutocomplete(string toLocation)
        {
            _journeyPlannerPage.EnterToLocation(toLocation);
        }

        [Then(@"the system should display results for the journey")]
       
           
        public void ThenTheSystemShouldDisplayResultsForTheJourney()
            {
                _journeyPlannerPage.ClickPlanJourney();
                Assert.IsTrue(_journeyPlannerPage.IsJourneyResultsDisplayed(), "Journey results are not displayed.");
            }
        [Then(@"it should show the estimated journey times for both walking and cycling options")]
        public void ThenItShouldShowTheEstimatedJourneyTimesForBothWalkingAndCyclingOptions()
        {
            Assert.IsTrue(_journeyPlannerPage.IsWalkingTimeDisplayed(), "Walking time is not displayed.");
            Assert.IsTrue(_journeyPlannerPage.IsCyclingTimeDisplayed(), "Cycling time is not displayed.");
        }
        [AfterScenario]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
    }
