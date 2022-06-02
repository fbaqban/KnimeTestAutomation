using UITest.Drivers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace UITest.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        
        private readonly ScenarioContext _scenarioContext;
        public static IWebDriver driver;
        public static bool checkSpacePage;
        public HookInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario(@"lauchBrowser")]
        public void BeforeScenarioWithTag()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        
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

            //The user login with given username and password
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

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver quit");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}