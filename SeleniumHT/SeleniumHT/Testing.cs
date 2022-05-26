using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumHT
{
    public class Testing
    {
        public Testing_PageObject element;
        PurchaseData_PageObject element1;
        UserLogin_PageObject element2;
        private readonly IWebDriver WebDriver;
        

        public Testing(IWebDriver driver)
        {
            WebDriver = driver;
            element = new Testing_PageObject(driver);
            element1 = new PurchaseData_PageObject(driver);
            element2 = new UserLogin_PageObject(driver);
        }

        public void GoToLaptop()
        {            
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            wait.Until((ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("#logInModal .btn-primary"))));
            element.FindLaptop().Click();
        }
        public void GoToDell()
        {
            element.FindDell().Click();
        }
        public void AddtoCart()
        {
            element.FindAddtoCart().Click();
            element.FindAddtoCart().SendKeys("{ENTER}");
        }
        public void GoToCart()
        {
            element.FindCart().Click();
        }
        public void GoToPO(string[]PD)
        {
            element.FindPlaceOrder().Click();                      
            //Name
            element1.FindName().SendKeys(PD[0]);
            //Country
            element1.FindCountry().SendKeys(PD[1]);
            //City            
            element1.FindCity().SendKeys(PD[2]);
            //Credit card            
            element1.FindCard().SendKeys(PD[3]);
            //Month           
            element1.FindMonth().SendKeys(PD[4]);
            //Year            
            element1.FindYear().SendKeys(PD[5]);
        }
        public Testing SumbitPurchase()
        {
            element.FindButtonPurchase().Click();            
            var PopUP = element.FindCheckPopUp();            
            Assert.IsTrue(PopUP.Displayed);
            return new Testing(WebDriver);
        }
        public Testing Maintest(string[] PD)
        {
            
            GoToLaptop();            
            GoToDell();            
            AddtoCart();            
            GoToCart();            
            GoToPO(PD);            
            return SumbitPurchase();
        }

    }
}
