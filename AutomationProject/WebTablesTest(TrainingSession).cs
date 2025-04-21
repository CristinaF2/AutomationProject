using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject.Pages;

namespace AutomationProject
{
    public class WebTablesTest_TrainingSession_
    {
        IWebDriver Driver;
        HomePage homePage;
        CommonPage commonPage;
        WebTablesPage webTablesPage;

        [Test]
        public void Test1()
        {
            Driver=new ChromeDriver();
            homePage=new HomePage(Driver);
            commonPage=new CommonPage(Driver);
            webTablesPage=new WebTablesPage(Driver);

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();

            homePage.ClickOnElementsPage();
            commonPage.GoToDesiredMenu("Web Tables");

            int initialSizeOfEmployeesList = webTablesPage.GetSizeOfInitialEmployeesList();

            webTablesPage.AddNewEmployee();
            webTablesPage.FillRegistrationForm("Cristina", "Filipan", "cristina123@gmail.com", "59", "1000", "testare");
            webTablesPage.SubmitNewEmployee();

            webTablesPage.CheckDetailsOfLastEmployeeAdded("Cristina", "Filipan", "59", "cristina123@gmail.com", "1000", "testare");

            webTablesPage.AddNewEmployee();
            webTablesPage.FillRegistrationForm("Ioana", "Popescu", "popescuioana1789@gmail.com", "63", "5000", "development");
            webTablesPage.SubmitNewEmployee();

            webTablesPage.CheckDetailsOfLastEmployeeAdded("Ioana", "Popescu", "63", "popescuioana1789@gmail.com", "5000", "development");

            List<IWebElement> expectedListOfEmployees = Driver.FindElements(By.XPath("//div[@class='rt-tbody']/div/div[@class='rt-tr -odd' or @class='rt-tr -even']")).ToList();
            webTablesPage.CheckSizeOfEmployeesList(initialSizeOfEmployeesList + 2, expectedListOfEmployees.Count);


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

            /*
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
            */

        }

        [TearDown]
        public void TearDown()
        {
           /* if (Driver !=null)
            {
                Driver.Dispose();
                Driver.Quit();

            }
          */
        }

    }
}

