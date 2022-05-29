using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumHT
{
    public class DriverSingleton
    {
        private static DriverSingleton instance = null;
        public static WebDriver driver;
        public static ChromeOptions options;

        private DriverSingleton(){
        }

        public void Timeouts()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }
        public static WebDriver getInstance()
        {
            if (driver == null)
            {
                instance = new DriverSingleton();
                options = new ChromeOptions();
                options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss; //.accept, .dismiss, etc.
                driver = new ChromeDriver(options);
                instance.Timeouts();
                
            }
            return driver;
        }
    }
}
