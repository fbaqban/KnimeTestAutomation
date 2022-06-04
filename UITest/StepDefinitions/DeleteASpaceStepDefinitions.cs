using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Xunit;
using UITest.Drivers;

namespace UITest.StepDefinitions
{
    [Binding]
    public sealed class DeleteASpaceStepDefinitions
    {
        //IWebDriver driver = Hooks.HookInitialization.driver;
        private string spaceName;

        [When(@"The user clicks on More button")]
        public void WhenTheUserClicksOnMoreButton()
        {
            var wait = new OpenQA.Selenium.Support.UI
                .WebDriverWait(Hooks.HookInitialization.driver, TimeSpan.FromSeconds(5));

            try
            {
                var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//button[@class=('toggle function-button single')]")));

                Locators.NewSpacePageLocators.SpaceMoreButton(Hooks.HookInitialization.driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("More button is not found!");
            }
        }

        [When(@"The user clicks on Delete the space button")]
        public void WhenTheUserClicksOnDeleteTheSpaceButton()
        {
            var wait = new OpenQA.Selenium.Support.UI
                .WebDriverWait(Hooks.HookInitialization.driver, TimeSpan.FromSeconds(5));

            try
            {
                var deleteSpaceButtonVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//button[contains(text(),'Delete space')]")));

                Locators.NewSpacePageLocators.DeleteSpaceButton(Hooks.HookInitialization.driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Delete space button is not found!");
            }
        }

        [Then(@"The Delete this space popup is displayed")]
        public void ThenTheDeleteThisSpacePopupIsDisplayed()
        {
            var wait = new OpenQA.Selenium.Support.UI
                .WebDriverWait(Hooks.HookInitialization.driver, TimeSpan.FromSeconds(5));

            try
            {
                var deleteSpacePopupVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//div[@class=('inner')]/div[@class='header']")));

                Boolean deleteThisSpacePopup = Locators.NewSpacePageLocators
                    .DeleteSpacePopup(Hooks.HookInitialization.driver)
                    .Displayed == true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Delete this space popup is not visible!");
            }
        }

        [When(@"The user enter the space name in the textbox")]
        public void WhenTheUserEnterTheSpaceNameInTheTextbox()
        {
            try
            {
                spaceName = Locators.NewSpacePageLocators
                    .RetrieveSpaceName(Hooks.HookInitialization.driver).Text;

                Locators.NewSpacePageLocators
                    .SpaceNameTextbox(Hooks.HookInitialization.driver).SendKeys(spaceName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot enter the space name!");
            }
        }

        [Then(@"The user checks if the Delete space button is enabled")]
        public void ThenTheUserChecksIfTheDeleteSpaceButtonIsEnabled()
        {
            try
            {
                Boolean deleteSpaceButton = Locators.NewSpacePageLocators
                    .FinalDeleteSpaceButton(Hooks.HookInitialization.driver).Enabled == true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The Delete space button is not enabled!");
            }
        }

        [Then(@"The user clicks on the Delete space button")]
        public void ThenTheUserClicksOnTheDeleteSpaceButton()
        {
            try
            {
                Locators.NewSpacePageLocators
                    .FinalDeleteSpaceButton(Hooks.HookInitialization.driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The Delete space button is not clickable!");
            }
        }

        [Then(@"The successful deletion message is displayed")]
        public void ThenTheSuccessfulDeletionMessageIsDisplayed()
        {
            try
            {
                Boolean successfulMessage = Locators.SpacesPageLocators
                    .PublicSpaceDeletionMessage(Hooks.HookInitialization.driver).Displayed == true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The public space message is not displayed!");
            }
        }

        [Then(@"The user checks existance of the deleted space")]
        public void ThenTheUserChecksExistanceOfTheDeletedSpace()
        {
            var wait = new OpenQA.Selenium.Support.UI
                .WebDriverWait(Hooks.HookInitialization.driver, TimeSpan.FromSeconds(400));

            try
            {
                var returnToSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//div[@class='profile-short-bio']")));

                Assert.Equal(Hooks.HookInitialization.driver
                    .FindElements(By.XPath(("//div[@class=('card-body')]/h3[contains(text(),'New space')]"))).Count, 0);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The deleted space exists!");
            }
        }



    }
}
