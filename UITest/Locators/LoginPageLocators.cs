using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class LoginPageLocators
    {
        public static IWebElement AcceptCookiesButtton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class='controls']/button[@class='accept-button button primary']"));
        }

        public static IWebElement SignInButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class='login']/button[@class='button primary compact']"));
        }

        public static IWebElement SignInForm(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//form[@class='user-login-form']"));
        }

        public static IWebElement UsernameEntry(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@id='edit-name']"));
        }

        public static IWebElement PasswordEntry(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//input[@id='edit-pass']"));
        }

        public static IWebElement SignInFormButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//button[@id='edit-submit']"));
        }
    }
}
