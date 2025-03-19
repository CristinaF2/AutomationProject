using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutomationProject
{
    public class Slider
    {
        IWebDriver Driver;

        [Test]
        public void Test()
        {
            Driver=new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            Actions action = new Actions(Driver);

            IWebElement widgetsElement = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsElement.Click();

            List<IWebElement> subMenuItems = Driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            subMenuItems[3].Click();


            IWebElement slider = Driver.FindElement(By.XPath("//input[@class='range-slider range-slider--primary']"));
            IWebElement sliderValue = Driver.FindElement(By.Id("sliderValue"));

            //move slider to a greater value than the default one
            //stocare valoarea initiala a sliderului(25)
            int initialValue = int.Parse(sliderValue.GetDomAttribute("value"));
            Console.WriteLine("Valoarea initiala/default a sliderului este: " + initialValue);

            //muta sliderul la o valoare mai mare decat valoarea default
            action.ClickAndHold(slider).MoveByOffset(50, 0).Release().Perform();
            Thread.Sleep(1000);

            //stocheaza valoarea curenta a sliderului
            int updatedValue = int.Parse(sliderValue.GetDomAttribute("value"));
            Console.WriteLine("Valoarea curenta a sliderului (dupa pozitionarea mai la dreapta): " + updatedValue);

            //verifica daca valoarea updatata a sliderului este mai mare decat valoarea default(25)
            Assert.Greater(updatedValue, initialValue, "Valoarea curenta a sliderului nu este mai mare decat cea initiala!");

            Thread.Sleep(1000);

            //move slider to lower value
            //stocheaza valoarea curenta a sliderului
            int currentValue = updatedValue;

            //muta sliderul la stanga
            action.ClickAndHold(slider).MoveByOffset(-50, 0).Release().Perform();
            Thread.Sleep(1000);

            //stocheaza valoarea actuala a sliderului
            updatedValue = int.Parse(sliderValue.GetDomAttribute("value"));
            Console.WriteLine("Valoarea curenta a sliderului (dupa pozitionarea mai la stanga): " + updatedValue);

            //verifica daca valoarea updatata a sliderului este < valoarea anterioara
            Assert.Less(updatedValue, currentValue, "Valoarea curenta a sliderului nu este mai mica decat cea anterioara!");

            //mut sliderul cat mai la stanga (pt a ajunge la 0)
            action.ClickAndHold(slider).MoveByOffset(-475, 0).Release().Perform();
            Thread.Sleep(1000);

            //stochez valoarea updatata a sliderului
            updatedValue = int.Parse(sliderValue.GetDomAttribute("value"));
            Console.WriteLine("Valoarea sliderlui dupa pozitionarea pe valoarea minima (0): " + updatedValue);

            //verifica daca valoarea curenta a sliderului este 0
            Assert.AreEqual(0, updatedValue, "Valoarea sliderului nu este 0!");

            //incerc sa mut sliderul la o valoarea <0 
            action.ClickAndHold(slider).MoveByOffset(-420, 0).Release().Perform();
            Thread.Sleep(1000);

            //stochez valoarea curenta a sliderului
            updatedValue = int.Parse(sliderValue.GetDomAttribute("value"));
            Console.WriteLine("Valoarea sliderului dupa incercarea de a-l muta pe o valoare mai mica decat 0: " + updatedValue);

            //verific ca valoarea curenta a sliderului e 0
            Assert.AreEqual(0, updatedValue, "Valoarea sliderului este mai mica decat 0!");


            //mut sliderul cat mai la dreapta (pt a ajunge la 100)
            action.ClickAndHold(slider).MoveByOffset(975, 0).Release().Perform();
            Thread.Sleep(1000); 

            // stochez valoarea actuala a sliderului
            updatedValue = int.Parse(sliderValue.GetDomAttribute("value"));
            Console.WriteLine("Valoarea sliderlui dupa pozitionarea pe valoarea maxima (100): " + updatedValue);

            // verific ca sliderul a ajuns la valoarea maxima (100)
            Assert.AreEqual(100, updatedValue, "Valoarea sliderului nu a ajuns la valoarea maxima (100)! ");

            // incerc sa cresc valoarea sliderului la o valoare > 100
            action.ClickAndHold(slider).MoveByOffset(920, 0).Release().Perform();
            Thread.Sleep(1000);

            // stochez valoarea actuala a sliderului
            updatedValue = int.Parse(sliderValue.GetDomAttribute("value"));
            Console.WriteLine("Valoarea sliderului dupa incercarea de a-l pozitiona la o valoare mai mare decat valoarea maxima(100): " + updatedValue);

            //verific ca valoarea actuala a sliderului e tot 100
            Assert.AreEqual(100, updatedValue, "Valoarea sliderului este > 100 (maxim)!");

        }
    }
}