using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationProject
{
    public class AutoCompleteTest
    {
        IWebDriver Driver;
        [Test]
        public void TestMethod()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();


            IWebElement widgetsButton = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsButton.Click();

            IWebElement autoCompleteButton = Driver.FindElement(By.XPath("//span[text()='Auto Complete']"));
            autoCompleteButton.Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement autoCompleteMultipleInputElement = Driver.FindElement(By.Id("autoCompleteMultipleInput"));

            //Create an Actions object
            Actions actions = new Actions(Driver);

            // List of colors to input
            List<string> colors = new List<string> { "White", "Black", "Red", "Blue", "Green" };

            // Loop through the colors list and send each color to the input element
            foreach (var color in colors)
            {
                // Click on the input element
                actions.Click(autoCompleteMultipleInputElement)
                      .SendKeys(color)               // Send the color name
                      .Pause(TimeSpan.FromMilliseconds(500))  // Pause for the dropdown to show
                      .SendKeys(Keys.Enter)           // Select the color from the dropdown
                      .Build()
                      .Perform();                    // Perform the action

               
                System.Threading.Thread.Sleep(500);
            }


            //'/following-sibling::div': This navigates to the next sibling div element (which is assumed to be the "X" button based on the structure of the HTML).
            //following-sibling:: is a powerful XPath axis for selecting elements that share the same parent and appear after the current node in the document order.
           
            List<string> colorsToRemove = new List<string> { "Black", "Blue", "Green" };

            // Loop through each color in the list to remove it
            foreach (var color in colorsToRemove)
            {
               
                    // Find the "X" button next to the color
                    IWebElement removeButton = Driver.FindElement(By.XPath(
                        $"//div[text()='{color}']/following-sibling::div[@class='css-xb97g8 auto-complete__multi-value__remove']"
                    ));

                    // Click the "X" button to remove the color
                    removeButton.Click();
                               
                    System.Threading.Thread.Sleep(500);
            }

            IWebElement autoCompleteSingleInput = Driver.FindElement(By.Id("autoCompleteSingleInput"));

            js.ExecuteScript("arguments[0].click();", autoCompleteSingleInput);

            autoCompleteSingleInput.SendKeys("Blue");
            autoCompleteSingleInput.SendKeys(Keys.Enter);



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

