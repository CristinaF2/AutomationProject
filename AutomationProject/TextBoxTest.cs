using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject
{
    public class TextBoxTest
    {
        IWebDriver driver;

        [Test]
        public void Test1()
        {
            driver=new ChromeDriver();

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();
            IJavaScriptExecutor js= (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement elementsButton = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementsButton.Click();

            IWebElement textBoxButton = driver.FindElement(By.XPath("//span[text()='Text Box']"));
            textBoxButton.Click();

            IWebElement fullNameElement= driver.FindElement(By.Id("userName"));
            fullNameElement.SendKeys("Cristina Filipan");

            IWebElement emailElement = driver.FindElement(By.Id("userEmail"));
            emailElement.SendKeys("cristinafilipan2704@gmail.com");

            IWebElement currentAddressElement = driver.FindElement(By.Id("currentAddress"));
            currentAddressElement.SendKeys("Strada Microration vest nr 1 ap 13");

            IWebElement permanentAddressElement = driver.FindElement(By.Id("permanentAddress"));
            permanentAddressElement.SendKeys("Strada Galaxiei nr 1 bloc A ap 28");

            js.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            string actualName = driver.FindElement(By.Id("name")).Text;
            string actualEmail = driver.FindElement(By.Id("email")).Text;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement actualCurrentAddressElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//p[@id='currentAddress']")));
            string actualCurrentAddress = actualCurrentAddressElement.Text;

            IWebElement actualPermanentAddressElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//p[@id='permanentAddress']")));
            string actualPermanentAddress = actualPermanentAddressElement.Text;

            string enteredFullName = fullNameElement.GetAttribute("value");
            string enteredEmail = emailElement.GetAttribute("value");
            string enteredCurrentAddress = currentAddressElement.GetAttribute("value");
            string enteredPermanentAddress = permanentAddressElement.GetAttribute("value");

            //check the table displayed after submit
            Assert.AreEqual($"Name:{enteredFullName}", actualName, "Name does not match!");
            Assert.AreEqual($"Email:{enteredEmail}", actualEmail, "Email does not match!");
            Assert.AreEqual($"Current Address :{enteredCurrentAddress}", actualCurrentAddress, "Current Address does not match!");
            Assert.AreEqual($"Permananet Address :{enteredPermanentAddress}", actualPermanentAddress, "Permanent Address does not match!");

            //get the fields placeholders
            string fullNamePlaceholder = fullNameElement.GetAttribute("placeholder");
            string emailPlaceholder = emailElement.GetAttribute("placeholder");
            string currentAddressPlaceholder = currentAddressElement.GetAttribute("placeholder");
            string permanentAddressPlaceholder = permanentAddressElement.GetAttribute("placeholder");

            //Assert placeholders values or existance
            Assert.AreEqual("Full Name", fullNamePlaceholder, "Full Name placeholder value is incorrect");
            Assert.AreEqual("name@example.com", emailPlaceholder, "Email placeholder value is incorrect");
            Assert.AreEqual("Current Address", currentAddressPlaceholder, "Current Address placeholder value is incorrect");
            Assert.IsTrue(string.IsNullOrEmpty(permanentAddressPlaceholder), "Permanent Address field has a placeholder!!");

            IWebElement fullNameLabel = driver.FindElement(By.Id("userName-label"));
            IWebElement emailLabel = driver.FindElement(By.Id("userEmail-label"));
            IWebElement currentAddressLabel = driver.FindElement(By.Id("currentAddress-label"));
            IWebElement permanentAddressLabel = driver.FindElement(By.Id("permanentAddress-label"));

            //assert the names of fields labels
            Assert.AreEqual("Full Name", fullNameLabel.Text, "Full Name label text is incorrect");
            Assert.AreEqual("Email", emailLabel.Text, "Email label text is incorrect");
            Assert.AreEqual("Current Address", currentAddressLabel.Text, "Current Address label text is incorrect");
            Assert.AreEqual("Permanent Address", permanentAddressLabel.Text, "Permanent Address label text is incorrect");

        }
        /*
         [TearDown]
         public void TearDown()
         {
             driver.Quit();
             driver.Close();

         }
         */
    }
}