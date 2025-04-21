using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject.HelperMethods
{
    public class AssertMethods
    {
        IWebDriver driver;

        public AssertMethods(IWebDriver webDriver)
        {
            driver = webDriver;
        }
      
        public void AssertEqualValues(string value1, string value2)
        {
            Assert.That(value1, Is.EqualTo(value2));
        }
        
        public void AssertEqualNumbers(int number1, int number2)
        {
            Assert.That(number1, Is.EqualTo(number2));
        }
    }
}
