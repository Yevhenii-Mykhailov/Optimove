using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OptimoveUI.Src.Helpers;

namespace OptimoveUI.Src.Pages
{
	public class MainPage
    {
        CustomControls controls = new();
        string chatFramePath = "//iframe[@id='hubspot-conversations-iframe']";
        string chatCloseButtonPath = "//button[@data-test-id='initial-message-close-button']";
        string cookieBannerPath = "//a[contains(@href, 'java')]";
        string careersButtonPath = "//a[contains(@href, '#c')]";
        string carrersContainerPath = "//div[@class='row block-careers-listing__row']";
        string carrersDropDownPath = "//div[@class='select select--job-locations']";
        string testedValuePath = "//li[@data-index='8']";
        string jobResultsPath = "//div[@class='block-careers-listing__job col']";

        public void switchToFrame(IWebDriver driver)
        {
            controls.waitElement(driver, chatFramePath);
            driver.SwitchTo().Frame(controls.getElementByXpath(driver, chatFramePath));
        }

        public void closeFrameAndSwitchBackToContent(IWebDriver driver)
        {
            controls.waitElement(driver, chatCloseButtonPath);
            controls.getElementByXpath(driver, chatCloseButtonPath).Click();
            driver.SwitchTo().DefaultContent();
        }

        public void closeCookieBanner(IWebDriver driver)
        {
            controls.waitElement(driver, cookieBannerPath);
            controls.getElementByXpath(driver, cookieBannerPath).Click();
        }

        public void goToCarrersSection(IWebDriver driver)
        {
            controls.waitElement(driver, careersButtonPath);
            controls.getElementByXpath(driver, careersButtonPath).Click();
        }

        public void scrollToJobDropdown(IWebDriver driver)
        {
            IWebElement container = controls.getElementByXpath(driver, carrersContainerPath);

            WheelInputDevice.ScrollOrigin scrollOrigin = new WheelInputDevice.ScrollOrigin
            {
                Element = container
            };
            new Actions(driver)
                .ScrollFromOrigin(scrollOrigin, 0, -150)
                .Perform();
        }

        public void selectTestedJobValue(IWebDriver driver)
        {
            controls.waitElement(driver, carrersDropDownPath);
            controls.getElementByXpath(driver, carrersDropDownPath).Click();
            controls.getElementByXpath(driver, testedValuePath).Click();
        }

        public int getJobResults(IWebDriver driver)
        {
            controls.waitElement(driver, jobResultsPath);
            return driver.FindElements(By.XPath(jobResultsPath)).Count;
        }
    }
}

