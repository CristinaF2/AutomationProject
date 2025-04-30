using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject.HelperMethods
{
    public class AlertMethods
    {
        IWebDriver driver;

        public AlertMethods(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void InterractWithAlertsOk()
        {
          
            IAlert alertOk = driver.SwitchTo().Alert();
            alertOk.Accept();
        }

        public void ExplicitAlertWait()
        {
            //definim un wait explicit ca sa astepte dupa alerta    
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
        public void InterractWithDelayAlert()
        {
            
            ExplicitAlertWait();
            InterractWithAlertsOk();
        }

        public void DismissAlert()
        {
            //dam cancel la alerta
            ExplicitAlertWait();
            IAlert alertConfirmation = driver.SwitchTo().Alert();
            alertConfirmation.Dismiss();
        }
        public void SendTextOnAlert(String value)
        {
            ExplicitAlertWait();
            IAlert alertPromt = driver.SwitchTo().Alert();
            alertPromt.SendKeys(value);
            InterractWithAlertsOk();
        }


    }
}
