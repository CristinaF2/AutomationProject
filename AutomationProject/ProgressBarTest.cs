using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace AutomationProject
{
    public class ProgressBarTest
    {
        IWebDriver Driver;

        [Test]
        public void Test()
        {
            Driver=new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(100));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            IWebElement widgetsElement = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsElement.Click();

            js.ExecuteScript("window.scrollTo(0,1000)");


            List<IWebElement> subMenuItems = Driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            subMenuItems[4].Click();


            IWebElement progressBarElement = Driver.FindElement(By.XPath("//div[@class='progress-bar bg-info']"));

            //stochez valoarea initiala a progressBar ului
            string progressValue = progressBarElement.GetDomAttribute("aria-valuenow");
            Console.WriteLine($"Initial progressBar value: {progressValue}%");

            //verific daca valoarea initiala a progressBar ului este 0
            Assert.That(int.Parse(progressValue), Is.EqualTo(0), "ProgressBar initial value is not 0");

            IWebElement startStopButtonElement = Driver.FindElement(By.Id("startStopButton"));

            //click pe butonul de Start to load progress bar
            startStopButtonElement.Click();
            //astept 2 secunde ca sa se incarce putin din progress bar
            Thread.Sleep(2000);

            //click pe butonul to stop load progress bar
            startStopButtonElement.Click();
            //stochez valoarea curenta a progress bar ului
            progressValue = progressBarElement.GetDomAttribute("aria-valuenow");
            //afisez valoarea curenta a progress bar ului
            Console.WriteLine($"Progress after 2 seconds: {progressValue}%");

            //veriifc daca valoarea curenta a progress bar ului este mai mare decat 0
            Assert.Greater(int.Parse(progressValue), 0, "Progress bar did not increase.");
            //mai astept 2 secunde
            Thread.Sleep(2000);
            int currentProgressBarValue = int.Parse(progressValue);

            //stochez valoarea curenta a progress bar ului fara a fi facut vreo actiune inainte
            progressValue = progressBarElement.GetDomAttribute("aria-valuenow");
            //afisez valoarea curenta a progress bar ului
            Console.WriteLine($"Progress after loading was stopped and a few more seconds had passed: {progressValue}%");

            //verific daca valoarea actuala a progress bar ului nu s a modificat 
            Assert.That(int.Parse(progressValue), Is.EqualTo(currentProgressBarValue), "Progress bar changed even if the stop button was clicked!");

            //continui incarcarea progress bar ului
            startStopButtonElement.Click();
            //astept 12 secunde ca sa se incarce progress bar ul pana la 100%
            Thread.Sleep(12000);
            //stochez valoarea curenta a progress bar ului
            progressValue = progressBarElement.GetDomAttribute("aria-valuenow");
            //afisez valoarea curenta a progress bar ului
            Console.WriteLine($"Current load of progressBar: {progressValue}%");
            //verific daca valoarea curenta a progress bar ului este 100
            Assert.That(int.Parse(progressValue), Is.EqualTo(100), "Progress bar did not reach 100%!");

            IWebElement resetButtonElement = Driver.FindElement(By.Id("resetButton"));
            //click pe reset button
            resetButtonElement.Click();
            //stochez valoarea progress bar ului
            progressValue = progressBarElement.GetDomAttribute("aria-valuenow");
            //afisez valoarea curenta a progress barului
            Console.WriteLine($"Current load of progressBar after reset: {progressValue}%");
            //verific ca valoarea curenta a progress barului este 0%
            Assert.That(int.Parse(progressValue), Is.EqualTo(0), "Progress bar did not reach 0%!");



        }
    }
}
