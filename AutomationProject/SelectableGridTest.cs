using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data;

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


            IWebElement selectableElement = Driver.FindElement(By.XPath("//span[text()='Selectable']"));
            selectableElement.Click();


            IWebElement gridElement = Driver.FindElement(By.Id("demo-tab-grid"));
            gridElement.Click();
            js.ExecuteScript("window.scrollTo(0,1000)");

            List<IWebElement> itemsList = Driver.FindElements(By.XPath("//li[@class='list-group-item list-group-item-action']")).ToList();

            bool alreadySelected = false;
            foreach (var item in itemsList)
            {
                if (item.GetAttribute("class").Contains("active"))
                {
                    alreadySelected = true;
                    break;
                }
            }


            if (alreadySelected)
            {
                Console.WriteLine("At least one element was already selected at the beginning!");
            }
            else
            {
                Console.WriteLine("All elements were initially deselected!");
            }


            for (int i = 0; i<itemsList.Count; i+=2)
            {
                itemsList[i].Click();
                System.Threading.Thread.Sleep(1000);
            }

            bool selectionSucceded = true;
            List<string> notSelectedElements = new List<string>();


            for (int i = 0; i<itemsList.Count; i+=2)
            {
                if (!itemsList[i].GetAttribute("class").Contains("active"))
                {
                    selectionSucceded = false;
                    notSelectedElements.Add(itemsList[i].Text);
                }
            }


            if (selectionSucceded)
            {
                Console.WriteLine("All elements were selected successfully!");
            }
            else
            {
                Console.WriteLine("The following elements were not selected:");
                foreach (string item in notSelectedElements)
                {

                    Console.WriteLine("  "+item);
                }
            }

        }
    }
}