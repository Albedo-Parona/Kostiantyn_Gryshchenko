using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumExtras.WaitHelpers;




namespace SeleniumHT
{      

        public class Tests

        {   
            IWebDriver webDriver;
            ChromeOptions options;            
            string[] User_data = { "Onime-power", "12345Kostia" };
            string[] Purchase_data = { "Kostia", "Ukraine", "Kyiv", "111111111", "May", "2022" };
                   
            [SetUp]
            public void Setup()
            {
                options = new ChromeOptions();
                options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss; //.accept, .dismiss, etc.
                webDriver = new ChromeDriver(options);
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                webDriver.Navigate().GoToUrl("https://www.demoblaze.com/");
                UserLogin Log_in = new UserLogin(webDriver);
                Log_in.Login(User_data[0], User_data[1]);                
            }

            [Test]
            public void Test()
            {
            Testing tesT = new Testing(webDriver);
            tesT.Maintest(Purchase_data);
            webDriver.Quit();

            }
        }
    }
