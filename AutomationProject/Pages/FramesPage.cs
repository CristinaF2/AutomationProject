using AutomationProject.HelperMethods;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationProject.Pages
{
    public class FramesPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public Actions actions;
        public AssertMethods assertMethods;
        public JavaScriptMethods javaScriptMethods;
        public FramesMethods framesMethods;
        public IJavaScriptExecutor js;


        public FramesPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods=new ElementMethods(webDriver);
            actions= new Actions(webDriver);
            js = (IJavaScriptExecutor)webDriver;
            javaScriptMethods= new JavaScriptMethods(webDriver);
            framesMethods= new FramesMethods(webDriver);
            assertMethods=new AssertMethods(webDriver);
        }


        IWebElement frameElement => webDriver.FindElement(By.Id("frame1"));

        IWebElement frameTextElement1 => webDriver.FindElement(By.Id("sampleHeading"));

        IWebElement frameElement2 => webDriver.FindElement(By.Id("frame2"));


        public void GetTextFromBigFrame()
        {
            framesMethods.SwitchToFrame(frameElement);
            Console.WriteLine(frameTextElement1.Text);
            framesMethods.SwitchToDefaultContent();

        }

       
        public void GetTextFromSmallFrame()
        {
            javaScriptMethods.ScrollPageVertically(1000);
            framesMethods.SwitchToFrame(frameElement2);
            javaScriptMethods.ScrollPageDinamic(1000,1000);


        }

        public void CheckTextOfBigFrame(string text)
        {
            framesMethods.SwitchToFrame(frameElement);
            assertMethods.AssertEqualValues(frameTextElement1.Text, text);
        }
        public void CheckTextOfSmallFrame(string text)
        {
            javaScriptMethods.ScrollPageVertically(1000);
            framesMethods.SwitchToFrame(frameElement2);
            javaScriptMethods.ScrollPageDinamic(1000, 1000);
            assertMethods.AssertEqualValues(frameTextElement1.Text, text);

        }


    }
}
