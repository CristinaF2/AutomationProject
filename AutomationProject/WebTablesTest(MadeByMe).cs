using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject
{
    public class WebTablesTest_MadeByMe_
    {

        public void AddStudent(IWebDriver Driver, string firstName, string lastName, string email, string age, string salary, string department)
        {

            IWebElement addNewRecordButton = Driver.FindElement(By.Id("addNewRecordButton"));
            addNewRecordButton.Click();

            Driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            Driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("age")).SendKeys(age);
            Driver.FindElement(By.Id("salary")).SendKeys(salary);
            Driver.FindElement(By.Id("department")).SendKeys(department);

            IWebElement submitButton = Driver.FindElement(By.Id("submit"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("arguments[0].click();", submitButton);

            List<IWebElement> currentListOfStudents = Driver.FindElements(By.XPath("//div[@class='rt-tbody']/div/div[@class='rt-tr -odd' or @class='rt-tr -even']")).ToList();
            int rowCount = currentListOfStudents.Count;

            string baseXpath = $"//div[@class='rt-tr-group'][{rowCount}]";

            IWebElement addedFirstName = Driver.FindElement(By.XPath($"{baseXpath}//div[@class='rt-td'][1]"));
            IWebElement addedLastName = Driver.FindElement(By.XPath($"{baseXpath}//div[@class='rt-td'][2]"));
            IWebElement addedAge = Driver.FindElement(By.XPath($"{baseXpath}//div[@class='rt-td'][3]"));
            IWebElement addedEmail = Driver.FindElement(By.XPath($"{baseXpath}//div[@class='rt-td'][4]"));
            IWebElement addedSalary = Driver.FindElement(By.XPath($"{baseXpath}//div[@class='rt-td'][5]"));
            IWebElement addedDepartment = Driver.FindElement(By.XPath($"{baseXpath}//div[@class='rt-td'][6]"));

            Assert.AreEqual(addedFirstName.Text, firstName);
            Assert.AreEqual(addedLastName.Text, lastName);
            Assert.AreEqual(addedEmail.Text, email);
            Assert.AreEqual(addedAge.Text, age);
            Assert.AreEqual(addedSalary.Text, salary);
            Assert.AreEqual(addedDepartment.Text, department);
        }


        IWebDriver Driver;
        [Test]
        public void Test1()
        {
            IWebDriver Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();

            IWebElement elementsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementsButton.Click();

            IWebElement webTablesButton = Driver.FindElement(By.XPath("//span[text()='Web Tables']"));
            webTablesButton.Click();

            AddStudent(Driver, "Cristina", "Filipan", "cristinafilipan2704@gmail.com", "34", "1000", "testare");
            AddStudent(Driver, "Marius", "Popescu", "marius.popescu@gmail.com", "30", "2000", "development");
        }
    }
}
