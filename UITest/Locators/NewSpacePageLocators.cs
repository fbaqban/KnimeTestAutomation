using OpenQA.Selenium;

namespace UITest.Locators
{
    public static class NewSpacePageLocators
    {
        public static IWebElement PublicSpaceCreationMessage(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//span[contains(text(),'Your new space was created successfully!')]"));
        }
        public static IWebElement ReturnToSpacesPageButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//a[contains(text(),'Spaces')]"));
        }

        //Delete a space locators

        public static IWebElement SpaceMoreButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class=('action-popover popover')]/button[@class=('toggle function-button single')]"));
        }
        public static IWebElement DeleteSpaceButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class=('content')]/button[contains(text(),'Delete space')]"));
        }
        public static IWebElement DeleteSpacePopup(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class=('inner')]/div[@class='header']"));
        }
        public static IWebElement RetrieveSpaceName(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class=('confirmation')]/p/strong[contains(text(),'New space')]"));
        }
        public static IWebElement SpaceNameTextbox(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//div[@class=('name-input')]/input"));
        }
        public static IWebElement FinalDeleteSpaceButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//button[@class=('button primary fullWidth')]"));
        }
    }
}
