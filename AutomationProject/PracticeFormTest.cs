
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using static System.Collections.Specialized.BitVector32;
using System.Dynamic;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.IO;
using OpenQA.Selenium.BiDi.Modules.Input;
using static NUnit.Framework.Constraints.Tolerance;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium.BiDi.Modules.Log;
using System.Timers;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;

namespace AutomationProject
{
    public class PracticeFormTest
    {
        IWebDriver Driver;
        [Test]
        public void TestMethod()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
           

            IWebElement formsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
            formsButton.Click();

            IWebElement practiceFormButton = Driver.FindElement(By.XPath("//span[text()='Practice Form']"));
            practiceFormButton.Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement firstNameField = Driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("Cristina");

            IWebElement lastNameField = Driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Filipan");

            IWebElement emailField = Driver.FindElement(By.Id("userEmail"));
            emailField.SendKeys("cristinafilipan08@gmail.com");

            IWebElement maleGenderRadioButton = Driver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
            IWebElement femaleGenderRadioButton = Driver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
            IWebElement otherGenderRadioButton = Driver.FindElement(By.XPath("//label[@for='gender-radio-3']"));


            string gender = "Female";
            /*
            if (gender.Equals("Male"))
            {
               maleGenderRadioButton.Click();
            }
            else  if(gender.Equals("Female"))
              {
                femaleGenderRadioButton.Click();
            }
            else
            {
                otherGenderRadioButton.Click();
            }
            */

            switch (gender)
            {
                case "Male":
                    maleGenderRadioButton.Click();
                    break;
                case "Female":
                    femaleGenderRadioButton.Click();
                    break;
                case "Other":
                    otherGenderRadioButton.Click();
                    break;

            }


            IWebElement mobileNumberField = Driver.FindElement(By.Id("userNumber"));
            mobileNumberField.SendKeys("0748787999");

            IWebElement dateOfBirthField = Driver.FindElement(By.Id("dateOfBirthInput"));
            js.ExecuteScript("arguments[0].click();", dateOfBirthField);
            dateOfBirthField.Click();

            // Wait for the date picker to be visible
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='react-datepicker']")));
  
            Thread.Sleep(500);
                                            
            IWebElement yearDropdown = Driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement yearSelect = new SelectElement(yearDropdown);
            yearSelect.SelectByValue("1990");


            /*
             SelectElement: This is a helper class provided by Selenium that makes it easier to interact with dropdowns(<select> elements).
             The yearDropdown element is passed to the constructor of SelectElement, creating an object (yearSelect) to manage dropdown operations,
             such as selecting options by text, value, or index.
            */

            IWebElement monthDropdown = Driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement monthSelect = new SelectElement(monthDropdown);
            monthSelect.SelectByValue("3");


            IWebElement dayElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'day--001')and not(contains(@class, '--outside-month'))]"))); 

            js.ExecuteScript("arguments[0].click();", dayElement);
            
            /*
             Why Use JavaScript?
             In some cases, Selenium’s regular Click() method may fail(e.g., if an element is obscured, overlapped, or intercepted by another element). Using JavaScript to click directly on the element bypasses such issues.
            */

            // Wait to observe results
            Thread.Sleep(3000);

            
            /*
             subjectsField.SendKeys("English");
             subjectsField.SendKeys(Keys.Enter);

             subjectsField.SendKeys("C");

             subjectsField.SendKeys(Keys.ArrowDown);
             subjectsField.SendKeys(Keys.ArrowDown);
             subjectsField.SendKeys(Keys.ArrowDown);
             subjectsField.SendKeys(Keys.Enter);

             //Instead of writing line subjectsField.SendKeys(Keys.ArrowDown) 3 times use the line of code:
             /*
             for (int i = 0; i < 3; i++)
             {
                 subjectsField.SendKeys(Keys.ArrowDown);
             }

             subjectsField.SendKeys(Keys.Enter);

             */


            IWebElement subjectsField = Driver.FindElement(By.Id("subjectsInput"));

            //One more way to fill the subjectsField using Actions class
            //Create an Actions object
            Actions actions = new Actions(Driver);

          
            // List of subjects to input
            List<string> subjects = new List<string> { "English", "Maths", "Chemistry", "Physics"};

            // Loop through the subjects list and send each subject to the input element
            foreach (var subject in subjects)
            {
                // Click on the input element
                actions.Click(subjectsField)
                      .SendKeys(subject)                      // Send the subject name
                      .Pause(TimeSpan.FromMilliseconds(500))  // Pause for the dropdown to show
                      .SendKeys(Keys.Enter)                   // Select the subject from the dropdown
                      .Build()
                      .Perform();                             // Perform the action

                 System.Threading.Thread.Sleep(500);
            }


            //The Build() method compiles a sequence of actions into a single composite action.
            //This is helpful when you want to execute multiple steps as a single operation.
            //The Perform() method executes the built sequence.
            //Multiple steps such as Click(), SendKeys(), and Keys.Enter are chained before calling Build() and Perform().
            //you can use the Build().Perform() method in Selenium's Actions class to chain multiple actions and execute them as a single unit.
            //using the Actions class in Selenium is highly useful when dealing with complex user interactions or scenarios where simple click() or sendKeys() methods are insufficient
            //The Actions class enables you to simulate actions that cannot be performed using basic WebDriver commands. Examples include:

            /*-Mouse hover: Moving the mouse pointer over an element without clicking.
              -Click and hold: Holding down the left mouse button on an element.
              -Drag and drop: Dragging an element and dropping it onto another element.
              -Double click or right-click(context click): Interacting with elements in ways beyond a single left-click.
            */

            //After typing each subject, I added a small pause using .Pause(TimeSpan.FromMilliseconds(500)).This is to ensure the dropdown is visible and can be interacted with.
            //The pause (.Pause()) ensures the dropdown has enough time to display the filtered options, especially if the suggestions might be delayed a little bit after typing.

            Thread.Sleep(1500);

      
            List<string> subjectsToRemove = new List<string> { "English","Physics" };

            // Loop through each subject in the list to remove it
            foreach (var subject in subjectsToRemove)
            {

                // Find the "X" button next to the subject
                IWebElement removeButton = Driver.FindElement(By.XPath(
                    $"//div[text()='{subject}']/following-sibling::div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']"
                ));

                // Click the "X" button to remove the subject
                removeButton.Click();

                System.Threading.Thread.Sleep(500);
            }

            List<string> hobbies = new List<string> { "Sports", "Reading" };
            foreach (string hobby in hobbies)
            {
                switch (hobby)
                {
                    case "Sports":
                        Driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
                        break;

                    case "Reading":
                        Driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']")).Click();
                        break;

                    case "Music":
                        Driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']")).Click();
                        break;
                }
            }

           
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            /*
            This line retrieves the base directory of the current application domain.
            Purpose: It gives the path to the directory where the application's executable file resides.
           */

            string finalPath = Directory.GetParent(basePath).Parent.Parent.Parent.FullName+"/"+ "resources/Reset.png";

            //This constructs the path to a file named Reset.png located in a resources folder within the application's parent directory hierarchy.
            //Directory.GetParent(basePath): Moves one level up from the base directory
            //.Parent(repeated 3 times): Moves further up the directory structure, ending up three levels higher.

            FileInfo file = new FileInfo(finalPath);

            //Creates a FileInfo object for the file located at finalPath.
            //Purpose: The FileInfo object provides details about the file and methods to interact with it(e.g., checking existence, size, etc.) 

            IWebElement uploadPictureElement = Driver.FindElement(By.Id("uploadPicture"));
            uploadPictureElement.SendKeys(file.FullName);

            //Upload the file by sending its full path to the file upload field.

            IWebElement addressElement = Driver.FindElement(By.Id("currentAddress"));
            addressElement.SendKeys("Strada Microraion vest bloc 1 scara 2");
                       
            IWebElement stateElement = Driver.FindElement(By.Id("react-select-3-input"));
            IWebElement cityElement = Driver.FindElement(By.Id("react-select-4-input"));

            js.ExecuteScript("arguments[0].click();", stateElement);
            stateElement.SendKeys("Haryana");
            stateElement.SendKeys(Keys.Enter);

            js.ExecuteScript("arguments[0].click();", cityElement);
            cityElement.SendKeys("Panipat");
            cityElement.SendKeys(Keys.Enter);

            IWebElement submitElement = Driver.FindElement(By.Id("submit"));
            js.ExecuteScript("arguments[0].click();", submitElement);


        }
        /*[TearDown]
        public void TearDown()
        {
            if (Driver !=null)
            {
                Driver.Dispose();
                Driver.Quit();

            }
        }
        */
    }
}