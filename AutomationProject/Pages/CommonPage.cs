using AutomationProject.HelperMethods;
using OpenQA.Selenium;

namespace AutomationProject.Pages
{
    public class CommonPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public IJavaScriptExecutor js;


        public CommonPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods=new ElementMethods(webDriver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;

        }

        List<IWebElement> elements => webDriver.FindElements(By.XPath("//span[@class='text']")).ToList();
        public void GoToDesiredMenu(string menuName)
        {
            js.ExecuteScript("window.scrollTo(0,1000)");
            elementMethods.SelectElementFromListByText(elements, menuName);
        }

    }
}
