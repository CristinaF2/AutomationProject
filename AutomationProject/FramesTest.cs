using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;

namespace AutomationProject
{
    public class FramesTest
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
            submenuItems[2].Click();

          

            IWebElement frameElement = Driver.FindElement(By.Id("frame1"));
            Driver.SwitchTo().Frame(frameElement);

            IWebElement frameTextElement1 = Driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine(frameTextElement1.Text);

            Driver.SwitchTo().DefaultContent();


            IWebElement frameElement2 = Driver.FindElement(By.Id("frame2"));
            Driver.SwitchTo().Frame(frameElement2);

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement frameTextElement2 = Driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine(frameTextElement2.Text);
            

        }
    }
}
