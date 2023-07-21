using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OptimoveUI.Src.Pages;

namespace OptimoveUI;

public class Tests
{
    IWebDriver driver = new ChromeDriver();

    [SetUp]
    public void Setup()
    {

        driver.Navigate().GoToUrl("https://www.optimove.com/careers");
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        MainPage mainPage = new();

        mainPage.switchToFrame(driver);
        mainPage.closeFrameAndSwitchBackToContent(driver);
        mainPage.closeCookieBanner(driver);
        mainPage.goToCarrersSection(driver);
        mainPage.scrollToJobDropdown(driver);
        mainPage.selectTestedJobValue(driver);
        int jobResults = mainPage.getJobResults(driver);

        Assert.Greater(jobResults, 0);
        driver.Close();
    }
}
