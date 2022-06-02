using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace UITest.Drivers
{
    public class SeleniumDriver
    {
        public static IWebDriver? driver;
        private readonly ScenarioContext _scenarioContext;
        public SeleniumDriver (ScenarioContext scenarioContext)  => _scenarioContext = scenarioContext;
       
        public IWebDriver Setup()
        {
            var chromeOptions = new ChromeOptions();

            driver = new ChromeDriver();

            //Set the driver
            _scenarioContext.Set(driver, "WebDriver");
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
