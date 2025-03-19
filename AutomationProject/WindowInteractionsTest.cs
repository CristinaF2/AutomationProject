using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AutomationProject
{
    public class WindowInteractionsTest
    {
        IWebDriver Driver;
        [Test]
        public void TestMethod()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();


            IWebElement alertsFramesWindowsElement = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            alertsFramesWindowsElement.Click();


            List<IWebElement> submenuItems = Driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            submenuItems[0].Click();

            IWebElement newTabButtonElement = Driver.FindElement(By.Id("tabButton"));

            IWebElement newWindowButtonElement = Driver.FindElement(By.Id("windowButton"));

            IWebElement newWindowMessageButtonElement = Driver.FindElement(By.Id("messageWindowButton"));
            


        }
    }
}
