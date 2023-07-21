using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OptimoveUI.Src.Helpers
{
	public class CustomControls
	{
        private static int timeToWait = 10;

        public void WaitElementIsVisible(IWebDriver driver, string elementXPath)
        {
            waiter(driver, timeToWait).Until(e => e.FindElement(By.XPath(elementXPath)));
        }

        public void waitElement(IWebDriver driver, string elementXPath)
        {
            waiter(driver, timeToWait).Until(e => e.FindElement(By.XPath(elementXPath)));
        }

        public IWebElement getElementByXpath(IWebDriver driver, string elementXPath)
        {
            return driver.FindElement(By.XPath(elementXPath));
        }

        public WebDriverWait waiter(IWebDriver driver, int time)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(time));
        }
    }
}

