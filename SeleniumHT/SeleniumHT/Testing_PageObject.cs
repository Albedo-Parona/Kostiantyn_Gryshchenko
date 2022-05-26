using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace SeleniumHT
{
    public class Testing_PageObject
    {
        private readonly IWebDriver webdriver;
        public Testing_PageObject(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement FindLaptop()
        {
            return webdriver.FindElement(By.LinkText("Laptops"));
        }
        public IWebElement FindDell()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=12']"));
        }
        public IWebElement FindAddtoCart()
        {
            return webdriver.FindElement(By.CssSelector(" .btn-success"));
        }
        public IWebElement FindCart()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'cart.html']"));
        }
        public IWebElement FindPlaceOrder()
        {
            return webdriver.FindElement(By.CssSelector(" .btn-success"));
        }
        public IWebElement FindButtonPurchase()
        {
            return webdriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]"));
        }
        public IWebElement FindCheckPopUp()
        {
            return webdriver.FindElement(By.Id("orderModal"));
        }



    }
    
}
