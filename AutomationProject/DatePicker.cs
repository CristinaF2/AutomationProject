using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationProject
{
    public class DatePicker
    {
        IWebDriver Driver;

        [Test]
        public void Test()
        {
            Driver=new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            IWebElement widgetsElement = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsElement.Click();

            List<IWebElement> subMenuItems = Driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            subMenuItems[2].Click();

            //----------------------------------------------------------------------------------------------//


            IWebElement dateFieldElement = Driver.FindElement(By.Id("datePickerMonthYearInput"));
                      
            js.ExecuteScript("arguments[0].click();", dateFieldElement);
           

            // Wait for the date picker to be visible
           
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='react-datepicker']")));

            Thread.Sleep(500);

            IWebElement yearDropdown = Driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement yearSelect = new SelectElement(yearDropdown);
            yearSelect.SelectByValue("1998");


            /*
             SelectElement: This is a helper class provided by Selenium that makes it easier to interact with dropdowns(<select> elements).
             The yearDropdown element is passed to the constructor of SelectElement, creating an object (yearSelect) to manage dropdown operations,
             such as selecting options by text, value, or index.
            */

            IWebElement monthDropdown = Driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement monthSelect = new SelectElement(monthDropdown);
            monthSelect.SelectByValue("6");


            IWebElement dayElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'day--016')and not(contains(@class, '--outside-month'))]")));

            js.ExecuteScript("arguments[0].click();", dayElement);
            Thread.Sleep(3000);


            //----------------------------------------------------------------------------------------------//
            

            IWebElement dateAndTimeFieldElement = Driver.FindElement(By.Id("dateAndTimePickerInput"));

            js.ExecuteScript("arguments[0].click();", dateAndTimeFieldElement);
           

            // Wait for the date picker to be visible

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='react-datepicker']")));

            Thread.Sleep(500);

            IWebElement yearArrowElement = Driver.FindElement(By.XPath("//span[@class='react-datepicker__year-read-view--down-arrow']"));
            yearArrowElement.Click();

            IWebElement yearTopArrowElement = Driver.FindElement(By.XPath("//a[@class='react-datepicker__navigation react-datepicker__navigation--years react-datepicker__navigation--years-upcoming']"));
            yearTopArrowElement.Click();

            IWebElement yearValueElement = Driver.FindElement(By.XPath("//div[@class='react-datepicker__year-option' and text()=2031]"));
            yearValueElement.Click();

            IWebElement monthArrowElement = Driver.FindElement(By.XPath("//span[@class='react-datepicker__month-read-view--down-arrow']"));
            monthArrowElement.Click();

            IWebElement monthValueElement = Driver.FindElement(By.XPath("//div[@class='react-datepicker__month-option' and text()='December']"));
            monthValueElement.Click();

            IWebElement dayValueElement = Driver.FindElement(By.XPath("//div[contains(@class,'day--004')and not(contains(@class, '--outside-month'))]"));
            dayValueElement.Click();

            IWebElement timeValueElement = Driver.FindElement(By.XPath("//li[@class='react-datepicker__time-list-item ' and text()='07:15']"));
            timeValueElement.Click();


        }
    }
}
