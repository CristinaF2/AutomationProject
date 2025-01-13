using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationProject
{
    public class SelectMenuTest
    {
        IWebDriver Driver;
        [Test]
        public void TestMethod()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            IWebElement widgetsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsButton.Click();

            js.ExecuteScript("window.scrollTo(0,2000)");

            IWebElement selectMenuButton = Driver.FindElement(By.XPath("//span[text()='Select Menu']"));
            selectMenuButton.Click();

            // Locate the dropdown input element
            IWebElement selectValueElement = Driver.FindElement(By.XPath("//div[text()='Select Option']"));
            selectValueElement.Click();

            js.ExecuteScript("window.scrollTo(0,2000)");

            // Wait for the dropdown options to become visible and find the desired option
            IWebElement dropdownOption = Driver.FindElement(By.XPath("//div[text()='Group 1, option 2']"));
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(dropdownOption));

            dropdownOption.Click();


            // Locate the dropdown input element
            IWebElement selectTitleElement = Driver.FindElement(By.Id("react-select-3-input"));
            js.ExecuteScript("arguments[0].click();", selectTitleElement);

            selectTitleElement.SendKeys("Prof.");
            selectTitleElement.SendKeys(Keys.Enter);


            IWebElement oldStyleSelectMenuElement = Driver.FindElement(By.Id("oldSelectMenu"));
            // Create a SelectElement object
            SelectElement selectElement = new SelectElement(oldStyleSelectMenuElement);

            // Select an option by visible text
            selectElement.SelectByText("Purple");

            IWebElement multiSelectDropdownElement = Driver.FindElement(By.Id("react-select-4-input"));
            //Create an Actions object
            Actions actions = new Actions(Driver);

            // List of colors to input
            List<string> colors = new List<string> { "Black", "Red", "Blue" };

            // Loop through the colors list and send each color to the input element
            foreach (var color in colors)
            {
                // Click on the input element
                actions.Click(multiSelectDropdownElement)
                      .SendKeys(color)               // Send the color name
                      .Pause(TimeSpan.FromMilliseconds(500))  // Pause for the dropdown to show
                      .SendKeys(Keys.Enter)           // Select the color from the dropdown
                      .Build()
                      .Perform();                    // Perform the action


                System.Threading.Thread.Sleep(500);
            }

           
            List<string> colorsToRemove = new List<string> { "Red" };

            // Loop through each color in the list to remove it
            foreach (var color in colorsToRemove)
            {

                // Find the "X" button next to the color (this is an example XPath and may vary depending on your page)
                IWebElement removeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(
                       $"//div[text()='{color}']/following-sibling::div[@class='css-xb97g8']"
                 )));

                // Click the "X" button to remove the color
                js.ExecuteScript("arguments[0].click();", removeButton);

                System.Threading.Thread.Sleep(500);
            }

            
        }

    }
}
