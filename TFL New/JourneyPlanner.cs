using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace TFL_New
{
    [Binding]

    public class JourneyPlanner

    {
        IWebDriver driver;
        


        [Given(@"I am on the TFL journey planning page ""([^""]*)""")]
        public void GivenIAmOnTheTFLJourneyPlanningPage(string p0)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(p0);
            driver.FindElement (By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();    // Accept Cookie on TFL main Page
        }

        [When(@"I enter a valid start location ""([^""]*)""")]
        public void WhenIEnterAValidStartLocation(string bank)
        {
            driver.FindElement(By.Id("InputFrom")).SendKeys("Bank");   
        }

        [When(@"I enter the valid destination location ""([^""]*)""")]
        public void WhenIEnterTheValidDestinationLocation(string p0)
        {
            driver.FindElement(By.Id("InputTo")).SendKeys("Ealing Broadway");
        }

   
         [When(@"I click the Enter")]
        public void WhenIClickTheEnter()
        {
            driver.FindElement(By.Id("InputTo")).Submit();

        }
        [When(@"I click the button ""([^""]*)""")]
        public void WhenIClickTheButton(string p0)
        {
             driver.FindElement(By.Id("plan-journey-button")).Click();
        }

        [Then(@"I see Journey results")]
        public void ThenISeeJourneyResults()
        {
            Assert.AreEqual(true,driver.PageSource.Contains("Journey results"));
        }

        [When(@"I enter the wrong start location ""([^""]*)""")]
        public void WhenIEnterTheWrongStartLocation(string xdf)
        {
            driver.FindElement(By.Id("InputFrom")).SendKeys("xdf");
        }

        [When(@"I enter the wrong destination ""([^""]*)""")]
        public void WhenIEnterTheWrongDestination(string dft)
        {
            driver.FindElement(By.Id("InputTo")).SendKeys("dft");
        }

        [Then(@"I see ""([^""]*)""")]
        public void ThenISee(string p0)
        {
            Assert.AreEqual(true, driver.PageSource.Contains("Sorry, we can't find a journey matching your criteria"));

        }

        [When(@"I entered no information in start location")]
        public void WhenIEnteredNoInformationInStartLocation()
        {
            driver.FindElement(By.Id("InputFrom")).SendKeys("");
        }

        [When(@"I entered no information in the destination")]
        public void WhenIEnteredNoInformationInTheDestination()
        {
            driver.FindElement(By.Id("InputTo")).SendKeys("");
        }
                   
        [Then(@"I see error to fill the required field")]
        public void ThenISeeErrorToFillTheRequiredField()
        {
            Assert.AreEqual(true, driver.PageSource.Contains("The From field is required."));
            Assert.AreEqual(true, driver.PageSource.Contains("The To field is required"));
        }





       [When(@"I see Journey results")]
       public void WhenISeeJourneyResults()
       {
            Assert.AreEqual(true, driver.PageSource.Contains("Journey results"));
        }

        [When(@"I can click ""([^""]*)"" to change journey details")]
        public void WhenICanClickToChangeJourneyDetails(string p0)
        {
            driver.FindElement(By.XPath("//span[contains(.,'Edit journey')]")).Click();
           
        }

        [When(@"I click the arrow to reverse the Journey details")]
        public void WhenIClickTheArrowToReverseTheJourneyDetailsUnableToLocateTheIdForAButton()
        {
            driver.FindElement(By.XPath("//*[@id='plan-a-journey']//a[contains(.,'Switch from and to')]")).Click();

        }

        [When(@"I click Plan a journey")]
        public void WhenIClickPlanAJourney()
        {
            driver.FindElement(By.XPath("//a[contains(.,'Plan a journey')]")).Click();
        }

        [When(@"I click ""([^""]*)"" text")]
        public void WhenIClickText(string recents)
        {
            driver.FindElement(By.XPath("//a[contains(.,'Recents')]")).Click();
        }

        [When(@"I enter a valid new start location ""([^""]*)""")]
        public void WhenIEnterAValidNewStartLocation(string p0)
        {
            driver.FindElement(By.Id("InputFrom")).SendKeys(p0);
        }

        [When(@"I enter the valid new destination location ""([^""]*)""")]
        public void WhenIEnterTheValidNewDestinationLocation(string p0)
        {
            driver.FindElement(By.Id("InputTo")).SendKeys(p0);
        }


        [Then(@"I can see the recent Jounrey result for ""([^""]*)""")]
        public void ThenICanSeeTheRecentJounreyResultFor(string p0)
        {
            Assert.AreEqual(true, driver.PageSource.Contains(p0));
        }


    }
}
