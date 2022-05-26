using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumHT
{
        public class UserLogin
    {
        
        UserLogin_PageObject element;
        private readonly IWebDriver WebDriver;

        public UserLogin(IWebDriver driver)
        {
            element = new UserLogin_PageObject(driver);
            WebDriver = driver;
        }
        public void GoToLogin()
        {
            element.FindLogin().Click();
        }
        public UserLogin EnterUsername(string username)
        {
            element.FindLoginUserName().SendKeys(username);
            return this;
        }
        public UserLogin EnterPassword(string password)
        {
            element.FindLoginPassword().SendKeys(password);
            return this;
        }
        public UserLogin SumbitLogin()
        {
            element.FindLoginSubmit().Click();
            return new UserLogin(WebDriver);
        }
        public UserLogin Login(string username, string password)
        {
            GoToLogin();
            
            EnterUsername(username);
            
            EnterPassword(password);
            
            return SumbitLogin();
        }
    }
}
