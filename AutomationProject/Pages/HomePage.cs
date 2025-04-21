using AutomationProject.HelperMethods;
using OpenQA.Selenium;

namespace AutomationProject.Pages
{
    public class HomePage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods=new ElementMethods(webDriver);
        }

        IWebElement FormsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
        IWebElement ElementsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));

        public void ClickOnFormsPage()
        {
            elementMethods.ClickOnElement(FormsButton);

        }

        public void ClickOnElementsPage()
        {
            elementMethods.ClickOnElement(ElementsButton);

        }

    }
}
