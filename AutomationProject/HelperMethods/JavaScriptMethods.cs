using OpenQA.Selenium;

namespace AutomationProject.HelperMethods
{
    public class JavaScriptMethods
    {
        IWebDriver driver;
        IJavaScriptExecutor js;


        public JavaScriptMethods(IWebDriver webDriver)
        {
            driver = webDriver;
            js = (IJavaScriptExecutor)webDriver;
        }

        public void ScrollPageHorizontal(int x)
        {
            js.ExecuteScript($"window.scrollTo({x},0)");
        }

        public void ScrollPageVertically(int y)
        {
            js.ExecuteScript($"window.scrollTo(0,{y})");
        }

        public void ScrollPageDinamic(int x, int y)
        {
            js.ExecuteScript($"window.scrollTo({x},{y})");
        }

    }
}
