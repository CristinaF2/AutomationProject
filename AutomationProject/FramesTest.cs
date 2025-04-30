using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;
using AutomationProject.Pages;

namespace AutomationProject
{
    public class FramesTest
    {
        IWebDriver Driver;
        HomePage homePage;
        CommonPage commonPage;
        FramesPage framesPage;
        [Test]
        public void TestMethod()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();


            homePage=new HomePage(Driver);
            commonPage=new CommonPage(Driver);
            framesPage=new FramesPage(Driver);


            homePage.ClickOnAlertsFrameWindowsPage();
            commonPage.GoToDesiredMenu("Frames");
          

            framesPage.GetTextFromBigFrame();
            framesPage.GetTextFromSmallFrame();

            framesPage.CheckTextOfBigFrame("This is a sample page");
            framesPage.CheckTextOfSmallFrame("This is a sample page");



            /*
             IWebElement frameElement = Driver.FindElement(By.Id("frame1"));
             Driver.SwitchTo().Frame(frameElement);

             IWebElement frameTextElement1 = Driver.FindElement(By.Id("sampleHeading"));
             Console.WriteLine(frameTextElement1.Text);

             Driver.SwitchTo().DefaultContent();


             IWebElement frameElement2 = Driver.FindElement(By.Id("frame2"));
             Driver.SwitchTo().Frame(frameElement2);

             IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
             js.ExecuteScript("window.scrollTo(0,1000)");

             IWebElement frameTextElement2 = Driver.FindElement(By.Id("sampleHeading"));
             Console.WriteLine(frameTextElement2.Text);
             */

        }
    }
}
