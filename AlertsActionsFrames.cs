using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace TestProject1
{
    public class AlertsActionsFrames
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void Frames()
        {
            // 1. Скроллим (ты это сделал правильно)
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

            // 2. Переключаемся во фрейм
            driver.SwitchTo().Frame(frameScroll); // Лучше передавать сам элемент, это надежнее

            // 3. ТРЕЗВЫЙ ШАГ: Ждем, пока ссылка станет доступна для клика
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement link = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.PartialLinkText("All Access plan")));

            // 4. Кликаем
            link.Click();
        }

        [Test]
        public void Alerts()
        {
            string name = "Alex";
            driver.FindElement(By.Id("name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick *= 'displayConfirm']")).Click();
            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            StringAssert.Contains(name, alertText);

        }

        [Test]
        public void AutoSuggestiveDropdowns()
        {
            driver.FindElement(By.XPath("//input[@id='autocomplete']")).SendKeys("ind");
            Thread.Sleep(3000);

            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
            }
        }

        [Test]
        public void testActions()
        {
            driver.Url = "https://demoqa.com/droppable/";
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.CssSelector("#draggable")), driver.FindElement(By.CssSelector("#droppable"))).Perform();
        }
    }
}
