using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject.HelperMethods
{
    public class AssertMethods
    {
        IWebDriver driver;
        ElementMethods elementMethods;
        AssertMethods assertMethods;
     

        public AssertMethods(IWebDriver webDriver)
        {
            driver = webDriver;
           
           
        }
      
        public void AssertEqualValues(string value1, string value2)
        {
            Assert.That(value1, Is.EqualTo(value2), "Valorile nu sunt egale!");
           
        }
        
        public void AssertEqualNumbers(int number1, int number2)
        {
            Assert.That(number1, Is.EqualTo(number2));
        }
        public void AssertTextElement(IWebElement webElement, String value)
        {

            elementMethods.WaitVisibilityElement(webElement);
            assertMethods.AssertEqualValues(webElement.Text, value);

        }

    }
}
