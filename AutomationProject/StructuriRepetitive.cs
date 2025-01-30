using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace AutomationProject
{
    public class StructuriRepetitive
    {
        IWebDriver Driver;

        [Test]
        public void Test1()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement interactionsButton = Driver.FindElement(By.XPath("//h5[text()='Interactions']"));
            interactionsButton.Click();

            IWebElement sortableButton = Driver.FindElement(By.XPath("//span[text()='Sortable']"));
            sortableButton.Click();

            List<IWebElement> elementsList = Driver.FindElements(By.XPath("//div[@class='element-list collapse show']//ul//li")).ToList();
            elementsList[0].Click();

            List<IWebElement> list2 = Driver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']//div")).ToList();

            /*foreach(IWebElement element in list2)
            {
               Console.WriteLine(element.Text);
            }
            */

            for (int i = 0; i<list2.Count; i++)
                Console.WriteLine(list2[i].Text);


        }

        [Test]
        public void Test2()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement formsElement = Driver.FindElement(By.XPath("//h5[text()='Forms']"));
            formsElement.Click();

            IWebElement practiceFormElement = Driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            practiceFormElement.Click();
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement sportsElement = Driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']"));
            IWebElement readingElement = Driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-2']"));
            IWebElement musicElement = Driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-3']"));

            List<IWebElement> hobbiesList= new List<IWebElement>();
            hobbiesList.Add(sportsElement);
            hobbiesList.Add(readingElement);
            hobbiesList.Add(musicElement);

            string[] array = ["Sports", "Music"];
            foreach (IWebElement hobby in hobbiesList)   
                foreach (string item in array)    
                    if (hobby.Text.Equals(item))
                        hobby.Click();


            }

        [Test]
        public void Test3()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement formsElement = Driver.FindElement(By.XPath("//h5[text()='Forms']"));
            formsElement.Click();

            IWebElement practiceFormElement = Driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            practiceFormElement.Click();
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement subjectsField = Driver.FindElement(By.Id("subjectsInput"));
            subjectsField.SendKeys("Math");
            subjectsField.SendKeys(Keys.Enter);

            subjectsField.SendKeys("Chemistry");
            subjectsField.SendKeys(Keys.Enter);

            subjectsField.SendKeys("English");
            subjectsField.SendKeys(Keys.Enter);

            List<IWebElement> removeSubjects = Driver.FindElements(By.XPath("//div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']")).ToList();
            bool subjbectFlag = true;

            while (subjbectFlag)
            {
                foreach (IWebElement element in removeSubjects)
                {
                    element.Click();
                   
                }
                subjbectFlag = false;
            }   
      
        }

       
    }
  }
