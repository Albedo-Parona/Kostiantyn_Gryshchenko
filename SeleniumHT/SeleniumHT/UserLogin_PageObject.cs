using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumHT
{
    public class UserLogin_PageObject
    {
        private readonly IWebDriver webdriver;

        public UserLogin_PageObject(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement FindLogin()
        {
            return webdriver.FindElement(By.LinkText("Log in"));
        }

        public IWebElement FindLoginUserName()
        {
            return webdriver.FindElement(By.Id("loginusername"));
        }

        public IWebElement FindLoginPassword()
        {
            return webdriver.FindElement(By.Id("loginpassword"));
        }

        public IWebElement FindLoginSubmit()
        {
            return webdriver.FindElement(By.CssSelector("#logInModal .btn-primary"));
        }
    }
}
