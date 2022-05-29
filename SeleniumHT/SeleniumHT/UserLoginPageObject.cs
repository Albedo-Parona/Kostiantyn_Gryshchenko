using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumHT
{
    public class UserLoginPageObject
    {
        private readonly IWebDriver webdriver;

        public UserLoginPageObject(IWebDriver driver)
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

        public By WaitingUntilDissapear()
        {
            return By.CssSelector("#logInModal .btn-primary");
        }
    }
}
