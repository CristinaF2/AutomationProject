using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject.HelperMethods
{
    public class ElementMethods
    {
        public IWebDriver driver;
        IJavaScriptExecutor js;

        public ElementMethods(IWebDriver webDriver)
        {
            driver = webDriver;
            js = (IJavaScriptExecutor)driver;

        }
        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }
        public void FillElement (IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void SelectElementFromListByText(IList<IWebElement> elementsList, string text)
        {
            foreach (IWebElement element in elementsList)
            {
                if (element.Text == text)
                {
                    ClickOnElement(element);
                }
            }
        }

       
        public void WaitVisibilityElement(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => webElement.Displayed);
        }

        public void ClickOnElementWithKeyboard(IWebElement webElement)
        {
            WaitVisibilityElement(webElement);
            webElement.SendKeys(Keys.Enter);
        }

        public void ClickOnElementWithJS(IWebElement webElement) 
        {
            //aceasta metoda e necesara pt a putea face click pe element daca cumva e acoperit de o reclama
            js.ExecuteScript("arguments[0].click();", webElement);
        }
    }
}
