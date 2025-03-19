using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationProject
{
    public class AccordianTest
    {
        IWebDriver Driver;

        [Test]
        public void Test()
        {
            Driver=new ChromeDriver();
            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            IWebElement widgetsElement = Driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsElement.Click();

            List<IWebElement> subMenuItems = Driver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            subMenuItems[0].Click();

            //----------------------------------------------------------------------------------------------//


            IWebElement firstButtonElement = Driver.FindElement(By.Id("section1Heading"));
            firstButtonElement.Click();

            IWebElement section1Text = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("section1Content")));
                   
            string expectedText1 = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            Assert.AreEqual(expectedText1, section1Text.Text, "The text under the first accordion section is incorrect!");

            //----------------------------------------------------------------------------------------------//


            IWebElement secondButtonElement = Driver.FindElement(By.Id("section2Heading"));

            js.ExecuteScript("window.scrollTo(0,1000)");
            secondButtonElement.Click();

            IWebElement section2Text1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='section2Content']//p)[1]")));

            string expectedTextOfSection2Paragraph1 = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.";

            Assert.AreEqual(expectedTextOfSection2Paragraph1, section2Text1.Text, "The text in the first paragraph under the second accordion section is incorrect!");

            IWebElement section2Text2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='section2Content']//p)[2]")));

            string expectedTextOfSection2Paragraph2 = "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.";

            Assert.AreEqual(expectedTextOfSection2Paragraph2, section2Text2.Text, "The text in the second paragraph under the second accordion section is incorrect!");

            //----------------------------------------------------------------------------------------------//


            IWebElement thirdButtonElement = Driver.FindElement(By.Id("section3Heading"));
            js.ExecuteScript("window.scrollTo(0,1000)");
            thirdButtonElement.Click();

            IWebElement section3Text = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("section3Content")));

            string expectedText3 = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";

            Assert.AreEqual(expectedText3, section3Text.Text, "The text under the third accordion section is incorrect!");


        }

    }
}
