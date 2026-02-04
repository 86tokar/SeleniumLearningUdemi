using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.Support.UI;

namespace TestProject1;

[TestFixture]
public class NUnitTestItem1
{
    //IWebDriver driver = new ChromeDriver();
    //IWebDriver driver = new FirefoxDriver();
    private IWebDriver driver;

    [SetUp]
    public void StartBrowser()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        driver.Url = "https://sso.teachable.com/secure/9521/identity/login/otp";
        //TestContext.Progress.WriteLine(driver.Title);
        //TestContext.Progress.WriteLine(driver.Url);

        driver.FindElement(By.Id("email")).SendKeys("86tokar@gmail.com");
        driver.FindElement(By.Id("email")).Clear();
        driver.FindElement(By.Id("email")).SendKeys("86tokar@gmail");
        driver.FindElement(By.XPath("//button[@data-test='btn-login']")).Click();
        string errorMessage = driver.FindElement(By.Id("my-error-id")).Text;
        TestContext.Progress.WriteLine(errorMessage);
        IWebElement link = driver.FindElement(By.LinkText("log in with a password"));
        string hrefAttr = link.GetAttribute("href");
        string expectedURl = "https://sso.teachable.com/secure/9521/identity/login/password?force=true";

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.XPath("//button[@data-test='btn-login']")), "Sign IN"));
        Assert.That(hrefAttr, Is.EqualTo(expectedURl));
    
    }

    [TearDown]
    public void StopBroser()
    {
        driver.Close();
        driver.Quit();
    }
}
