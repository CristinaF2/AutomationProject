using AutomationProject.HelperMethods;
using OpenQA.Selenium;

namespace AutomationProject.Pages
{
    public class WebTablesPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public AssertMethods assertMethods;

        public WebTablesPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods=new ElementMethods(webDriver);
            assertMethods=new AssertMethods(webDriver);
        }

        IWebElement addNewRecordButton => webDriver.FindElement(By.Id("addNewRecordButton"));


        IWebElement firstNameElement => webDriver.FindElement(By.Id("firstName"));


        IWebElement lastNameElement => webDriver.FindElement(By.Id("lastName"));


        IWebElement userEmailElement => webDriver.FindElement(By.Id("userEmail"));

        IWebElement ageElement => webDriver.FindElement(By.Id("age"));

        IWebElement salaryElement => webDriver.FindElement(By.Id("salary"));

        IWebElement departmentElement => webDriver.FindElement(By.Id("department"));


        IWebElement submitButton => webDriver.FindElement(By.Id("submit"));


        List<IWebElement> listOfEmployees => webDriver.FindElements(By.XPath("//div[@class='rt-tbody']/div/div[@class='rt-tr -odd' or @class='rt-tr -even']")).ToList();

        IWebElement firstNameOfLastEmployeeAdded => webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{listOfEmployees.Count()}]//div[@class='rt-td'][1]"));
        IWebElement lastNameOfLastEmployeeAdded => webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{listOfEmployees.Count()}]//div[@class='rt-td'][2]"));
        IWebElement ageOfLastEmployeeAdded => webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{listOfEmployees.Count()}]//div[@class='rt-td'][3]"));
        IWebElement emailOfLastEmployeeAdded => webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{listOfEmployees.Count()}]//div[@class='rt-td'][4]"));
        IWebElement salaryOfLastEmployeeAdded => webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{listOfEmployees.Count()}]//div[@class='rt-td'][5]"));
        IWebElement departmentOfLastEmployeeAdded => webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{listOfEmployees.Count()}]//div[@class='rt-td'][6]"));

        public void FillRegistrationForm(string firstName, string lastName, string userEmail, string age, string salary, string department)
        {

            elementMethods.FillElement(firstNameElement, firstName);
            elementMethods.FillElement(lastNameElement, lastName);
            elementMethods.FillElement(userEmailElement, userEmail);
            elementMethods.FillElement(ageElement, age);
            elementMethods.FillElement(salaryElement, salary);
            elementMethods.FillElement(departmentElement, department);

        }
        public void SubmitNewEmployee()
        {
            elementMethods.ClickOnElement(submitButton);
        }

        public void AddNewEmployee()
        {
            elementMethods.ClickOnElement(addNewRecordButton);
        }

        public void CheckSizeOfEmployeesList(int listSize1, int listSize2)
        {
            assertMethods.AssertEqualNumbers(listSize1, listSize2);
        }

        public int GetSizeOfInitialEmployeesList()
        {
         
            return listOfEmployees.Count;
           
        }

        public void CheckDetailsOfLastEmployeeAdded(string firstName, string lastName,string age, string email, string salary, string department)
        {
            Console.WriteLine(firstNameOfLastEmployeeAdded.Text);
            assertMethods.AssertEqualValues(firstNameOfLastEmployeeAdded.Text, firstName);
            assertMethods.AssertEqualValues(lastNameOfLastEmployeeAdded.Text, lastName);
            assertMethods.AssertEqualValues(ageOfLastEmployeeAdded.Text, age);
            assertMethods.AssertEqualValues(emailOfLastEmployeeAdded.Text, email);
            assertMethods.AssertEqualValues(salaryOfLastEmployeeAdded.Text, salary);
            assertMethods.AssertEqualValues(departmentOfLastEmployeeAdded.Text, department);

        }

    }
}
