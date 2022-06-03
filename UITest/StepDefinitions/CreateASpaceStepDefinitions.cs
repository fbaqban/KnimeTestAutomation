using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using UITest.Drivers;
using Xunit;

namespace UITest.StepDefinitions
{
    [Binding]
    public sealed class CreateASpaceStepDefinitions
    {
        IWebDriver driver = Hooks.HookInitialization.driver;
        private readonly ScenarioContext _scenarioContext;
        private bool checkSpacePage = Hooks.HookInitialization.checkSpacePage;
        private string spaceName;

        public CreateASpaceStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Then(@"The spaces page is displayed")]
        public void ThenTheSpacesPageIsDisplayed()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            try
            {
                var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//div[@class='profile-short-bio']")));

                checkSpacePage = Locators.SpacesPageLocators.SpacesPageVisibility(driver).Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Space page is not loaded!");
            }
        }

        [When(@"The user clicks on create a new public space")]
        public void WhenTheUserClicksOnCreateANewPublicSpace()
        {
            try
            {
                if (checkSpacePage == true)
                    Locators.SpacesPageLocators.NewPublicSpace(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Create a new public space is not clickable!");
            }
        }

        [Then(@"Create a new public space page and successful creation message are displayed")]
        public void ThenCreateANewPublicSpacePageAndSuccessfulCreationMessageAreDisplayed()
        {

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            try
            {
                var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//span[contains(text(),'Your new space was created successfully!')]")));

                Boolean successfulMessage = Locators.NewSpacePageLocators
                    .PublicSpaceCreationMessage(driver).Displayed == true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Create a new public space page is displayed!");
            }
        }
        [When(@"The user return to his space page")]
        public void WhenTheUserReturnToHisSpacePage()
        {
            try
            {
                Locators.NewSpacePageLocators
                    .ReturnToSpacesPageButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The user spaces button is not found!");
            }
        }

        [Then(@"The created space is visible")]
        public void ThenTheCreatedSpaceIsVisible()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            try
            {
                var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//h3[contains(text(),'New space')]")));

                spaceName = Locators.SpacesPageLocators
                    .RetrieveCreatedSpaceName(driver).Text;

                Assert.Equal(spaceName,
                    Locators.SpacesPageLocators.CreatedSpaceRange(driver).Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The created space is not visible!");
            }
        }


    }
}
