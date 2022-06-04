using UITest.Drivers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace UITest.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        public static IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public static bool checkSpacePage;
        private string spaceName;
        public HookInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario(Order = 0)]
        public void CreateADriver()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [BeforeScenario(Order = 1)]
        public void NavigateTheUrl()
        {
            //The user opens the browser and launch the application
            try
            {
                driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
                driver.Url = "https://hub.knime.com/";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The web page is not reachable", e);
            }
        }

        [BeforeScenario(Order = 2)]
        public void AcceptCookies()
        {
            //The user accepts the cookies
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                var AcceptCookiesPopupVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                   .ElementIsVisible(By.XPath("//div[@class='controls']/button[@class='accept-button button primary']")));

                Locators.LoginPageLocators.AcceptCookiesButtton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The accept button does not found!", e);
            }
        }
        [BeforeScenario(Order = 3)]
        public void ClickFirstSignInButton()
        {
            //The user clicks on sign in button
            try
            {
                if (Locators.LoginPageLocators.SignInButton(driver).Displayed)
                    Locators.LoginPageLocators.SignInButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("The Sign in button does not found!");
            }
        }
        [BeforeScenario(Order = 4)]
        public void EnterLoginData()
        {
            //The user login with given username and password
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            try
            {
                var AcceptCookiesPopupVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementIsVisible(By.XPath("//form[@class='user-login-form']")));

                Locators.LoginPageLocators.UsernameEntry(driver).SendKeys("fbaqban");
                Locators.LoginPageLocators.PasswordEntry(driver).SendKeys("BaghbanF@123");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot insert inputs");
            }
        }
        [BeforeScenario(Order = 5)]
        public void ClickFinalSignInbutton()
        {
            //The user sign in
            try
            {
                Locators.LoginPageLocators.SignInFormButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot login to Knime.com");
            }
        }
        [BeforeScenario(Order = 6)]
        public void ClickProfilePicture()
        {
            //The user clicks on his profile picture
            try
            {
                Locators.SpacesPageLocators.ProfilePictureButton(driver).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Avatar is not found!");
            }
        }
        [BeforeScenario(Order = 7)]
        public void NavigateSpacesPage()
        {
            //The user clicks on spaces item
            try
            {
                driver.Url = "https://hub.knime.com/fbaqban/spaces";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Cannot click on Spaces!");
            }
        }
        [BeforeScenario(Order = 8)]
        public void SpagesPageVisibility()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            //The spaces page is displayed
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
        [BeforeScenario(Order = 9)]
        public void DeletePreviousPublicSpaces()
        {
            var wait = new OpenQA.Selenium.Support.UI
                .WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string xpathPreviousSpace = "//div[@class=('card-body')]/h3[contains(text(),'New space')]";

            //The user delete previous public spaces
            try 
            {
                if (driver.FindElements(By.XPath(xpathPreviousSpace)).Count != 0)
                {
                    Locators.SpacesPageLocators.CreatedSpaceRange(driver).Click();

                    var newPublicSpacePageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                            .ElementIsVisible(By.XPath("//button[@class=('toggle function-button single')]")));


                    Locators.NewSpacePageLocators.SpaceMoreButton(driver).Click();

                    var deleteSpaceButtonVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                            .ElementIsVisible(By.XPath("//button[contains(text(),'Delete space')]")));

                    Locators.NewSpacePageLocators.DeleteSpaceButton(driver).Click();


                    var deleteSpacePopupVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                            .ElementIsVisible(By.XPath("//div[@class=('inner')]/div[@class='header']")));

                    Boolean deleteThisSpacePopup = Locators.NewSpacePageLocators
                        .DeleteSpacePopup(driver)
                        .Displayed == true;

                    spaceName = Locators.NewSpacePageLocators
                        .RetrieveSpaceName(driver).Text;

                    Locators.NewSpacePageLocators
                        .SpaceNameTextbox(driver).SendKeys(spaceName);

                    Boolean deleteSpaceButton = Locators.NewSpacePageLocators
                        .FinalDeleteSpaceButton(driver).Enabled == true;

                    Locators.NewSpacePageLocators
                        .FinalDeleteSpaceButton(driver).Click();

                    var deletedMessageVisibility = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                        .ElementIsVisible(By.XPath("//span[contains(text(),'Space was deleted successfully!')]")));

                    Boolean successfulMessage = Locators.SpacesPageLocators
                        .PublicSpaceDeletionMessage(driver).Displayed == true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Previous public spaces could not remove!");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver quit");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}