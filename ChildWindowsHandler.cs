using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace TestProject1
{
    public class ChildWindowsHandler
    {

        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
        }git
        [Test]
        public void WindowHandle()
        {
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(2));
        }
    }
}
