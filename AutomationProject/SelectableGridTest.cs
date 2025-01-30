using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject
{
    public class SelectableGridTest
    {
       
        IWebDriver Driver;
        [Test]
        public void Test()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
           

            IWebElement interactionsElement = Driver.FindElement(By.XPath("//h5[text()='Interactions']"));
            interactionsElement.Click();

            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement selectableElement = Driver.FindElement(By.XPath("//span[text()='Selectable']"));
            selectableElement.Click();


            IWebElement gridElement = Driver.FindElement(By.Id("demo-tab-grid"));
            gridElement.Click();

            List<IWebElement> itemsList = Driver.FindElements(By.XPath("//li[@class='list-group-item list-group-item-action']")).ToList();

            for(int i=0; i<itemsList.Count; i+=2 )
            {
                itemsList[i].Click();
                System.Threading.Thread.Sleep(1000);
            }
            
          
        }
    }
}
