using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject
{
    public class WebTablesTest_TrainingSession_
    {
        IWebDriver Driver;
        [Test]
        public void Test1()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();

            IWebElement elementsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
            elementsButton.Click();

            IWebElement webTablesButton = Driver.FindElement(By.XPath("//span[text()='Web Tables']"));
            webTablesButton.Click();

            IWebElement addNewRecordButton = Driver.FindElement(By.Id("addNewRecordButton"));
            addNewRecordButton.Click();

            IWebElement firstNameElement = Driver.FindElement(By.Id("firstName"));
            firstNameElement.SendKeys("Cristina");

            IWebElement lastNameElement = Driver.FindElement(By.Id("lastName"));
            lastNameElement.SendKeys("Filipan");

            IWebElement userEmailElement = Driver.FindElement(By.Id("userEmail"));
            userEmailElement.SendKeys("cristinafilipan2704@gmail.com");

            IWebElement ageElement = Driver.FindElement(By.Id("age"));
            ageElement.SendKeys("34");

            IWebElement salaryElement = Driver.FindElement(By.Id("salary"));
            salaryElement.SendKeys("150569");

            IWebElement departmentElement = Driver.FindElement(By.Id("department"));
            departmentElement.SendKeys("testare");

            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;

            IWebElement submitButton = Driver.FindElement(By.Id("submit"));
            jse.ExecuteScript("arguments[0].click();", submitButton);
            //submitButton.Submit();

            //submit() method does not work always

            //IWebElement newRowWebTable = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]"));
            // Console.WriteLine(newRowWebTable.Text);

            /* Assert.True(newRowWebTable.Text.Contains("Cristina"));
             Assert.True(newRowWebTable.Text.Contains("Filipan"));
             Assert.True(newRowWebTable.Text.Contains("34"));
             Assert.True(newRowWebTable.Text.Contains("cristinafilipan2704@gmail.com"));
             Assert.True(newRowWebTable.Text.Contains("150569"));
             Assert.True(newRowWebTable.Text.Contains("testare"));
            */

            IWebElement firstName = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][1]"));
            IWebElement lastName = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][2]"));
            IWebElement age = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][3]"));
            IWebElement email = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][4]"));
            IWebElement salary = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][5]"));
            IWebElement department = Driver.FindElement(By.XPath("//div[@class='rt-tr-group'][4]//div[@class='rt-td'][6]"));

            Assert.That(firstName.Text.Equals("Cristina"));
            Assert.That(lastName.Text.Equals("Filipan"));
            Assert.That(email.Text.Equals("cristinafilipan2704@gmail.com"));
            Assert.That(age.Text.Equals("34"));
            Assert.That(salary.Text.Equals("150569"));
            Assert.That(department.Text.Equals("testare"));

        }

        [TearDown]
        public void TearDown()
        {
            if (Driver !=null)
            {
                Driver.Dispose();
                Driver.Quit();

            }
        }

    }
}

