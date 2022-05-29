using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace SeleniumHT
{
    public class TestingPageObject
    {
        private readonly IWebDriver webdriver;
        public TestingPageObject(IWebDriver driver)
        {
            webdriver = driver;
        }             
        
        public IWebElement FindButtonPurchase()
        {
            return webdriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]"));
        }
        public IWebElement FindCheckPopUp(string[] PD)
        {
            
            string Name = "\"" + "Name: " + PD[0] + "\"";
            string Card = "\""+ "Card Number: " + PD[3]+ "\"";
            
            //Перевірка виводу PopUp по введеним даним ( карта та ім'я)
            webdriver.FindElement(By.XPath("//*[text()[contains(.," + Name + ")]]"));
            return webdriver.FindElement(By.XPath("//*[text()[contains(.,"+Card+")]]"));
            
        }
    }

    public class NavigationPageObject
    {
        private readonly IWebDriver webdriver;

        public NavigationPageObject(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement FindLaptop()
        {
            return webdriver.FindElement(By.LinkText("Laptops"));
        }
        public IWebElement FindCart()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'cart.html']"));
        }
    }

    public class СategoryResultsPageObject
    {
        private readonly IWebDriver webdriver;

        public СategoryResultsPageObject(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement FindDell()
        {
            return webdriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=12']"));
        }

    }

    public class ProductPageObject
    {
        private readonly IWebDriver webdriver;

        public ProductPageObject(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement FindAddtoCart()
        {
            return webdriver.FindElement(By.CssSelector(" .btn-success"));
        }


    }

    public class CartPageObject
    {
        private readonly IWebDriver webdriver;

        public CartPageObject(IWebDriver driver)
        {
            webdriver = driver;
        }

        public IWebElement FindPlaceOrder()
        {
            return webdriver.FindElement(By.CssSelector(" .btn-success"));
        }

    }

}
