using AutomationProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace AutomationProject
{
    public class AlertsTest
    {
        IWebDriver Driver;
        HomePage homePage;
        CommonPage commonPage;
        AlertsPage alertsPage;


        [Test]
        public void Test()
        {
            Driver=new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();


            homePage=new HomePage(Driver);
            commonPage=new CommonPage(Driver);
            alertsPage=new AlertsPage(Driver);

            homePage.ClickOnAlertsFrameWindowsPage();
            commonPage.GoToDesiredMenu("Alerts");

            alertsPage.InterractWithOkAlert();

            alertsPage.InterractWithDelayAlert();
            alertsPage.InteractWithDismissedAlert();
            alertsPage.InteractWithPromtAlertResult("Cristina");
            alertsPage.CheckResultOfConfirmedAlert("You selected Cancel");
            alertsPage.CheckResultOfPromptAlert("You entered Cristina");

            /*
            IWebElement alertsFramesWindowsElement = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            alertsFramesWindowsElement.Click();


            List<IWebElement> submenuItems = Driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            submenuItems[1].Click();
            */
            /*
            IWebElement alertButton = Driver.FindElement(By.Id("alertButton"));
            alertButton.Click();

            IAlert alertOk = Driver.SwitchTo().Alert();
            alertOk.Accept();
            */
            /*
            IWebElement delayedAlertButton = Driver.FindElement(By.Id("timerAlertButton"));
            delayedAlertButton.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alertWithDelay = Driver.SwitchTo().Alert();
            alertWithDelay.Accept();
            

            IWebElement confirmAlertButton = Driver.FindElement(By.Id("confirmButton"));
            confirmAlertButton.Click();
           

            IAlert alertWithDismiss = Driver.SwitchTo().Alert();
            alertWithDismiss.Dismiss();

            IWebElement promtAlertButton = Driver.FindElement(By.Id("promtButton"));
            promtAlertButton.Click();

            IAlert alertWithInput = Driver.SwitchTo().Alert();
            alertWithInput.SendKeys("test1");
            alertWithInput.Accept();
             */





        }

    }
}
