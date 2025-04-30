using OpenQA.Selenium;

namespace AutomationProject.HelperMethods
{
    public class FramesMethods
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;

        public FramesMethods(IWebDriver webDriver)
        {
            driver = webDriver;
            js = (IJavaScriptExecutor)driver;

        }

        public void SwitchToFrame(IWebElement webElement)
        {
            driver.SwitchTo().Frame(webElement);
        }

        public void SwitchToDefaultContent()
        {
           driver.SwitchTo().DefaultContent();
        }
    }
}
