using AutomationProject.HelperMethods;
using OpenQA.Selenium;

namespace AutomationProject.Pages
{
    public class CommonPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public CommonPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods=new ElementMethods(webDriver);
        }

        List<IWebElement> elements => webDriver.FindElements(By.XPath("//span[@class='text']")).ToList();
        public void GoToDesiredMenu(string menuName)
        {
            elementMethods.SelectElementFromListByText(elements, menuName);
        }

    }
}
