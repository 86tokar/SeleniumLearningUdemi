using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class SortWebTables
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void CheckTableSorting()
        {
            List<string> veggiesName = new List<string>();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in veggies)
            {
                veggiesName.Add(veggie.Text);
            }

            veggiesName.Sort();


            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();
            List<string> veggiesNameAfterSorting = new List<string>();
            IList <IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement sorted in sortedVeggies)
            {
                veggiesNameAfterSorting.Add(sorted.Text);
            }

            Assert.That(veggiesName, Is.EquivalentTo(veggiesNameAfterSorting));
        }
    }
}
