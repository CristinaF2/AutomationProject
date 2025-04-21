
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using static System.Collections.Specialized.BitVector32;
using System.Dynamic;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.IO;
using OpenQA.Selenium.BiDi.Modules.Input;
using static NUnit.Framework.Constraints.Tolerance;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium.BiDi.Modules.Log;
using System.Timers;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;

namespace AutomationProject
{
    public class PracticeFormTest
    {
        IWebDriver Driver;
        HomePage homePage;
        CommonPage commonPage;
        PracticeFormPage practiceFormPage;

        [Test]
        public void TestMethod()
        {
            Driver=new ChromeDriver();

            Driver.Navigate().GoToUrl("https://demoqa.com/");
            Driver.Manage().Window.Maximize();
            
            homePage= new HomePage(Driver);
            commonPage=new CommonPage(Driver);
            practiceFormPage= new PracticeFormPage(Driver);

            homePage.ClickOnFormsPage();
            commonPage.GoToDesiredMenu("Practice Form");
            practiceFormPage.CompleteFirstRegion("Cris", "Filip", "tina123@gmail.com", "0744878985", "Microraion vest 29/2");
            practiceFormPage.SelectGender("Female");
            practiceFormPage.FillDateOfBirth("1988", "4");

            List<string> subjects = new List<string> { "English", "Maths", "Chemistry", "Physics" };
            practiceFormPage.FillSubjects(subjects);

            List<string> hobbies = new List<string> { "Sports", "Reading" };
            practiceFormPage.FillHobbies(hobbies);


            List<string> subjectsToRemove = new List<string> { "English", "Physics" };
            practiceFormPage.RemoveSubjects(subjectsToRemove);

            practiceFormPage.UploadPicture("Reset.png");
            practiceFormPage.FillState("Haryana");
            practiceFormPage.FillCity("Panipat");
            practiceFormPage.SubmitForm();

           

            /*
            if (gender.Equals("Male"))
            {
               maleGenderRadioButton.Click();
            }
            else  if(gender.Equals("Female"))
              {
                femaleGenderRadioButton.Click();
            }
            else
            {
                otherGenderRadioButton.Click();
            }
            */

            
            /*
             subjectsField.SendKeys("English");
             subjectsField.SendKeys(Keys.Enter);

             subjectsField.SendKeys("C");

             subjectsField.SendKeys(Keys.ArrowDown);
             subjectsField.SendKeys(Keys.ArrowDown);
             subjectsField.SendKeys(Keys.ArrowDown);
             subjectsField.SendKeys(Keys.Enter);

             //Instead of writing line subjectsField.SendKeys(Keys.ArrowDown) 3 times use the line of code:
             /*
             for (int i = 0; i < 3; i++)
             {
                 subjectsField.SendKeys(Keys.ArrowDown);
             }

             subjectsField.SendKeys(Keys.Enter);

             */

      
        }
       [TearDown]
        public void TearDown()
        {
          /*  if (Driver !=null)
            {
                Driver.Dispose();
                Driver.Quit();

            }
          */
        }
        
    }
}