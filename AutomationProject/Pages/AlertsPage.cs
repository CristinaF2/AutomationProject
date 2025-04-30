using AutomationProject.HelperMethods;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationProject.Pages
{
    public class AlertsPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public Actions actions;
        public AssertMethods assertMethods;
        public JavaScriptMethods javaScriptMethods;
        public FramesMethods framesMethods;
        public IJavaScriptExecutor js;
        public AlertMethods alertMethods;

        public AlertsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods=new ElementMethods(webDriver);
            actions= new Actions(webDriver);
            js = (IJavaScriptExecutor)webDriver;
            javaScriptMethods= new JavaScriptMethods(webDriver);
            framesMethods= new FramesMethods(webDriver);
            assertMethods=new AssertMethods(webDriver);
            alertMethods= new AlertMethods(webDriver);


        }
        IWebElement alertButton => webDriver.FindElement(By.Id("alertButton"));

        IWebElement delayedAlertButton => webDriver.FindElement(By.Id("timerAlertButton"));


        IWebElement confirmAlertButton => webDriver.FindElement(By.Id("confirmButton"));

        IWebElement promtAlertButton => webDriver.FindElement(By.Id("promtButton"));

        IWebElement confirmAlertResultElement => webDriver.FindElement(By.Id("confirmResult"));

        IWebElement promptAlertResultElement => webDriver.FindElement(By.Id("promptResult"));

        public void InterractWithOkAlert()
        {
            
            elementMethods.ClickOnElement(alertButton);
            alertMethods.InterractWithAlertsOk();
        }

        public void InterractWithDelayAlert()
        {
            elementMethods.ClickOnElement(delayedAlertButton);
            alertMethods.InterractWithDelayAlert();
        }

        public void InteractWithDismissedAlert()
        {
            elementMethods.ClickOnElement(confirmAlertButton);
            alertMethods.DismissAlert();
        }

        public void InteractWithPromtAlertResult(String text)
        {
            javaScriptMethods.ScrollPageVertically(100);
            elementMethods.ClickOnElement(promtAlertButton);
            alertMethods.SendTextOnAlert(text);
        }

        
        public void CheckResultOfConfirmedAlert(String resultOfConfirmedAlert)
        {
            assertMethods.AssertEqualValues(confirmAlertResultElement.Text, resultOfConfirmedAlert);

        }

      
        public void CheckResultOfPromptAlert(String resultOfPromptAlert)
        {
            assertMethods.AssertEqualValues(promptAlertResultElement.Text, resultOfPromptAlert);
        }


    }
}
