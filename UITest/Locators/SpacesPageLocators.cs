using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class SpacesPageLocators
    {
        public static IWebElement ProfilePictureButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//span[@class='avatar']"));
        }
        public static IWebElement MenuVisibility(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class='menu-wrapper']"));
        }
        public static IWebElement SpacesChoice(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class='menu-wrapper']/[@class='menu-items orient-right']/li[2]"));
        }
        public static IWebElement SpacesPageVisibility(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class='profile-short-bio']"));
        }
        public static IWebElement NewPublicSpace(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class='buttons']/button[contains(text(),'Public space')]"));
        }
        public static IWebElement RetrieveCreatedSpaceName(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class=('card-body')]/h3[contains(text(),'New space')]"));
        }

        //Deleted space locators

        public static IWebElement PublicSpaceDeletionMessage(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//span[contains(text(),'Space was deleted successfully!')]"));
        }
        public static IWebElement CreatedSpaceRange(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//h3[contains(text(),'New space')]"));
        }
        public static IWebElement DeletedSpaceExistance(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//button[@class=('dismiss-button function-button single')]"));
        }

    }
}
