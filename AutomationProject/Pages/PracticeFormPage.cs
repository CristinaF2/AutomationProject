using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationProject.Pages
{
    public class PracticeFormPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public Actions actions;

        public PracticeFormPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods=new ElementMethods(webDriver);
            actions= new Actions(webDriver);
        }

        IWebElement firstNameElement => webDriver.FindElement(By.Id("firstName"));
        IWebElement lastNameElement => webDriver.FindElement(By.Id("lastName"));
        IWebElement emailElement => webDriver.FindElement(By.Id("userEmail"));

        IWebElement mobileNumberElement => webDriver.FindElement(By.Id("userNumber"));

        IWebElement addressElement => webDriver.FindElement(By.Id("currentAddress"));

        IWebElement maleGenderRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
        IWebElement femaleGenderRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
        IWebElement otherGenderRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-3']"));

        IWebElement dateOfBirthField => webDriver.FindElement(By.Id("dateOfBirthInput"));

        IWebElement datePickerElement => webDriver.FindElement(By.XPath("//div[@class='react-datepicker']"));
        IWebElement yearDropdown => webDriver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));

        IWebElement monthDropdown => webDriver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));

        IWebElement dayElement => webDriver.FindElement(By.XPath("//div[contains(@class,'day--003')and not(contains(@class, '--outside-month'))]"));

        IWebElement subjectsField => webDriver.FindElement(By.Id("subjectsInput"));

        IWebElement sportsElement => webDriver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']"));
        IWebElement readingElement => webDriver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']"));
        IWebElement musicElement => webDriver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']"));


        IWebElement removeEnglishSubjectButton => webDriver.FindElement(By.XPath(
                  $"//div[text()='English']/following-sibling::div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']"
              ));

        IWebElement removePhysicsSubjectButton => webDriver.FindElement(By.XPath(
                $"//div[text()='Physics']/following-sibling::div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']"
            ));

        IWebElement removeMathsSubjectButton => webDriver.FindElement(By.XPath(
                $"//div[text()='Maths']/following-sibling::div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']"
            ));

        IWebElement removeChemistrySubjectButton => webDriver.FindElement(By.XPath(
               $"//div[text()='Chemistry']/following-sibling::div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']"
           ));

        IWebElement stateElement => webDriver.FindElement(By.Id("react-select-3-input"));
        IWebElement cityElement => webDriver.FindElement(By.Id("react-select-4-input"));


        IWebElement uploadPictureElement => webDriver.FindElement(By.Id("uploadPicture"));

        IWebElement submitElement => webDriver.FindElement(By.Id("submit"));

        public void CompleteFirstRegion(string firstName, string lastName, string email, string mobileNumber, string currentAddress)
        {
            elementMethods.FillElement(firstNameElement, firstName);

            elementMethods.FillElement(lastNameElement, lastName);

            elementMethods.FillElement(emailElement, email);

            elementMethods.FillElement(mobileNumberElement, mobileNumber);

            elementMethods.FillElement(addressElement, currentAddress);
        }

        public void FillDateOfBirth(string year, string month)
        {
            elementMethods.ClickOnElement(dateOfBirthField);

            elementMethods.WaitVisibilityElement(datePickerElement);

            SelectElement yearSelect = new SelectElement(yearDropdown);
            yearSelect.SelectByValue(year);

            SelectElement monthSelect = new SelectElement(monthDropdown);
            monthSelect.SelectByValue(month);

            elementMethods.WaitVisibilityElement(dayElement);
            elementMethods.ClickOnElement(dayElement);
        }
        public void SelectGender(string gender)
        {
            switch (gender)
            {
                case "Male":
                    elementMethods.ClickOnElement(maleGenderRadioButton);
                    break;
                case "Female":
                    elementMethods.ClickOnElement(femaleGenderRadioButton);
                    break;
                case "Other":
                    elementMethods.ClickOnElement(otherGenderRadioButton);
                    break;

            }
        }

        public void FillSubjects(List<string> subjects)
        {

            // Loop through the subjects list and send each subject to the input element
            foreach (var subject in subjects)
            {
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
                // Click on the input element
                actions.Click(subjectsField)
                      .SendKeys(subject)                      // Send the subject name
                      .Pause(TimeSpan.FromMilliseconds(500))  // Pause for the dropdown to show
                      .SendKeys(Keys.Enter)                   // Select the subject from the dropdown
                      .Build()
                      .Perform();                             // Perform the action

            }

        }

        public void FillHobbies(List<string> hobbies)
        {
            foreach (string hobby in hobbies)
            {
                switch (hobby)
                {
                    case "Sports":
                        elementMethods.ClickOnElement(sportsElement);
                        break;

                    case "Reading":
                        elementMethods.ClickOnElement(readingElement);
                        break;

                    case "Music":
                        elementMethods.ClickOnElement(musicElement);
                        break;
                }
            }
        }

        public void RemoveSubjects(List<string> subjectsToRemove)
        {
            // Loop through each subject in the list to remove it
            foreach (var subject in subjectsToRemove)
            {

                switch (subject)
                {
                    case "English":
                        elementMethods.ClickOnElement(removeEnglishSubjectButton);
                        break;

                    case "Physics":
                        elementMethods.ClickOnElement(removePhysicsSubjectButton);
                        break;

                    case "Maths":
                        elementMethods.ClickOnElement(removeMathsSubjectButton);
                        break;

                    case "Chemistry":
                        elementMethods.ClickOnElement(removeChemistrySubjectButton);
                        break;
                }


            }
        }

        public void UploadPicture(string fileName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            /*
            This line retrieves the base directory of the current application domain.
            Purpose: It gives the path to the directory where the application's executable file resides.
           */

            string finalPath = Directory.GetParent(basePath).Parent.Parent.Parent.FullName+"/"+ "resources/"+ fileName;

            //This constructs the path to a file named Reset.png located in a resources folder within the application's parent directory hierarchy.
            //Directory.GetParent(basePath): Moves one level up from the base directory
            //.Parent(repeated 3 times): Moves further up the directory structure, ending up three levels higher.

            FileInfo file = new FileInfo(finalPath);

            //Creates a FileInfo object for the file located at finalPath.
            //Purpose: The FileInfo object provides details about the file and methods to interact with it(e.g., checking existence, size, etc.) 

           
            elementMethods.FillElement(uploadPictureElement, file.FullName);

            //Upload the file by sending its full path to the file upload field.

        }

        public void FillState(string state)
        {

            elementMethods.ClickOnElementWithJS(stateElement);
            elementMethods.FillElement(stateElement, state);
            elementMethods.ClickOnElementWithKeyboard(stateElement);
            
        }


        public void FillCity(string city)
        {
            elementMethods.ClickOnElementWithJS(cityElement);
            elementMethods.FillElement(cityElement, city);
            elementMethods.ClickOnElementWithKeyboard(cityElement);
        }

        public void SubmitForm()
        {
            elementMethods.ClickOnElementWithJS(submitElement);
        }
    }
}
