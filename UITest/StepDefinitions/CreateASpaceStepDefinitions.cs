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
        //public IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private bool checkSpacePage = Hooks.HookInitialization.checkSpacePage;
        private string spaceName;

        public CreateASpaceStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        //public CreateASpaceStepDefinitions(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}

        //[Given(@"The user opens the browser and launch the application")]
        //public void GivenTheUserOpensTheBrowserAndLaunchTheApplication(Table table)
        //{
        //    try
        //    {
        //        driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
        //        driver.Url = "https://hub.knime.com/";
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("The web page is not reachable", e);
        //    }


        //}

        //[When(@"The user accepts the cookies")]
        //public void WhenTheUserAcceptsTheCookies()
        //{
        //    var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //    try
        //    {
        //        var AcceptCookiesPopupVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
        //           .ElementIsVisible(By.XPath("//div[@class='controls']/button[@class='accept-button button primary']")));

        //        Locators.LoginPageLocators.AcceptCookiesButtton(driver).Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("The accept button does not found!", e);
        //    }
        //}

        //[When(@"The user clicks on sign in button")]
        //public void WhenTheUserClicksOnSignInButton()
        //{
        //    try
        //    {
        //        if (Locators.LoginPageLocators.SignInButton(driver).Displayed)
        //            Locators.LoginPageLocators.SignInButton(driver).Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("The Sign in button does not found!");
        //    }
        //}

        //[Given(@"The user login with username ([^""]*) and password ([^""]*)")]
        //public void GivenTheUserLoginWithUsernameAndPassword(string username, string p1)
        //{
        //    var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //    try
        //    {
        //        var AcceptCookiesPopupVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
        //            .ElementIsVisible(By.XPath("//form[@class='user-login-form']")));

        //        Locators.LoginPageLocators.UsernameEntry(driver).SendKeys(username);
        //        Locators.LoginPageLocators.PasswordEntry(driver).SendKeys(p1);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("Cannot insert inputs");
        //    }
        //}

        //[When(@"The user sign in")]
        //public void WhenTheUserSignIn()
        //{
        //    try
        //    {
        //        Locators.LoginPageLocators.SignInFormButton(driver).Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("Cannot login to Knime.com");
        //    }
        //}

        //[When(@"The user clicks on his profile picture")]
        //public void WhenTheUserClicksOnHisProfilePicture()
        //{
        //    try
        //    {
        //        Locators.SpacesPageLocators.ProfilePictureButton(driver).Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("Avatar is not found!");
        //    }
        //}

        //[When(@"The user clicks on spaces item")]
        //public void WhenTheUserClicksOnSpacesItem()
        //{
        //    try
        //    {
        //        driver.Url = "https://hub.knime.com/fbaqban/spaces";
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("Cannot click on Spaces!");
        //    }
        //}

        //[Then(@"The spaces page is displayed")]
        //public void ThenTheSpacesPageIsDisplayed()
        //{
        //    var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

        //    try
        //    {
        //        var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
        //            .ElementIsVisible(By.XPath("//div[@class='profile-short-bio']")));

        //        checkSpacePage = Locators.SpacesPageLocators.SpacesPageVisibility(driver).Displayed;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw new Exception("Space page is not loaded!");
        //    }
        //}

        [When(@"The user clicks on create a new public space")]
        public void WhenTheUserClicksOnCreateANewPublicSpace()
        {
            try
            {
                if (checkSpacePage == true)
                    Locators.SpacesPageLocators.NewPublicSpace(Drivers.SeleniumDriver.driver).Click();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Create a new public space is not clickable!");
            }
        }

        [Then(@"Create a new public space page and successful creation message are displayed")]
        public void ThenCreateANewPublicSpacePageAndSuccessfulCreationMessageAreDisplayed()
        {

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Drivers.SeleniumDriver.driver, TimeSpan.FromSeconds(10));

            try
            {
                var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//span[contains(text(),'Your new space was created successfully!')]")));

                Boolean successfulMessage = Locators.NewSpacePageLocators
                    .PublicSpaceCreationMessage(Drivers.SeleniumDriver.driver).Displayed == true;
            }
            catch(Exception e)
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
                    .ReturnToSpacesPageButton(Drivers.SeleniumDriver.driver).Click();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The user spaces button is not found!");
            }
        }

        [Then(@"The created space is visible")]
        public void ThenTheCreatedSpaceIsVisible()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Drivers.SeleniumDriver.driver, TimeSpan.FromSeconds(20));

            try
            {
                var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//h3[contains(text(),'New space')]")));

                spaceName = Locators.SpacesPageLocators
                    .RetrieveCreatedSpaceName(Drivers.SeleniumDriver.driver).Text;

                Assert.Equal(spaceName,
                    Locators.SpacesPageLocators.CreatedSpaceRange(Drivers.SeleniumDriver.driver).Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The created space is not visible!");
            }
        }


    }
}
