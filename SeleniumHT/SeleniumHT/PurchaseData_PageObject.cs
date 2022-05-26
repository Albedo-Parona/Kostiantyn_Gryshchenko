using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumHT
{
    public class PurchaseData_PageObject
    {
        private readonly IWebDriver webdriver;
        public PurchaseData_PageObject(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement FindName()
        {
            return webdriver.FindElement(By.Id("name"));
        }
        public IWebElement FindCountry()
        {
            return webdriver.FindElement(By.Id("country"));
        }
        public IWebElement FindCity()
        {
            return webdriver.FindElement(By.Id("city"));
        }
        public IWebElement FindCard()
        {
            return webdriver.FindElement(By.Id("card"));
        }
        public IWebElement FindMonth()
        {
            return webdriver.FindElement(By.Id("month"));
        }
        public IWebElement FindYear()
        {
            return webdriver.FindElement(By.Id("year"));
        }

    }
}
