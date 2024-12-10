using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationProject
{
    public class WebTablesTest
    {
        IWebDriver driver;
        [Test]
        public void Test1()
        {
            driver=new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementsButton = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementsButton.Click();

            IWebElement webTablesButton = driver.FindElement(By.XPath("//span[text()='Web Tables']"));
            webTablesButton.Click();

            List<IWebElement> initialListOfPeople = driver.FindElements(By.XPath("//div[@class='rt-tbody']/div/div[@class='rt-tr -odd' or @class='rt-tr -even']")).ToList();
            int initialNumberOfPeople= initialListOfPeople.Count;

            IWebElement addNewRecordButton = driver.FindElement(By.Id("addNewRecordButton"));
            addNewRecordButton.Click();

            IWebElement firstNameElement = driver.FindElement(By.Id("firstName"));
            firstNameElement.SendKeys("Cristina");

            IWebElement lastNameElement = driver.FindElement(By.Id("lastName"));
            lastNameElement.SendKeys("Filipan");

            IWebElement userEmailElement = driver.FindElement(By.Id("userEmail"));
            userEmailElement.SendKeys("cristinafilipan2704@gmail.com");

            IWebElement ageElement = driver.FindElement(By.Id("age"));
            ageElement.SendKeys("34");

            IWebElement salaryElement = driver.FindElement(By.Id("salary"));
            salaryElement.SendKeys("150569");

            IWebElement departmentElement = driver.FindElement(By.Id("department"));
            departmentElement.SendKeys("testare");

            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            js.ExecuteScript("window.scrollTo(0,1000)");

            List<IWebElement> expectedListOfPeople = driver.FindElements(By.XPath("//div[@class='rt-tbody']/div/div[@class='rt-tr -odd' or @class='rt-tr -even']")).ToList();
            int expetedNumberOfPeople = expectedListOfPeople.Count;

            String lastHumanAdded = expectedListOfPeople[3].Text;
          
            string[] person = lastHumanAdded.Split(new[] { "\r\n" }, StringSplitOptions.None);
            
            Assert.AreEqual("Cristina", person[0]);
            Assert.AreEqual("Filipan", person[1]);
            Assert.AreEqual("34", person[2]);
            Assert.AreEqual("cristinafilipan2704@gmail.com", person[3]);
            Assert.AreEqual("150569", person[4]);
            Assert.AreEqual("testare", person[5]);

            Assert.AreEqual(initialNumberOfPeople+1, expetedNumberOfPeople);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".rt-tbody")));

           
}

    }
}
