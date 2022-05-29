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
    public class PlaceOrderContext
    {
        public TestingPageObject element;
        NavigationPageObject navigation;
        PurchaseDataPageObject PlaceOrderPopup;
        UserLoginPageObject LogInPopup;
        СategoryResultsPageObject findProduct;
        ProductPageObject AddingtoCart;
        CartPageObject PO;
        private readonly IWebDriver WebDriver;
        

        public PlaceOrderContext(IWebDriver driver)
        {
            WebDriver = driver;
            element = new TestingPageObject(driver);
            navigation = new NavigationPageObject(driver);
            findProduct = new СategoryResultsPageObject(driver);
            AddingtoCart = new ProductPageObject(driver);
            PO = new CartPageObject(driver);
            PlaceOrderPopup = new PurchaseDataPageObject(driver);
            LogInPopup = new UserLoginPageObject(driver);
        }

        public void GoToLaptop()
        {            
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            //Place of LogInPopup usage
            wait.Until((ExpectedConditions.InvisibilityOfElementLocated(LogInPopup.WaitingUntilDissapear())));
            navigation.FindLaptop().Click();
        }
        public void GoToDell()
        {
            findProduct.FindDell().Click();
        }
        public void AddtoCart()
        {
            AddingtoCart.FindAddtoCart().Click();
            AddingtoCart.FindAddtoCart().SendKeys("{ENTER}");
        }
        public void GoToCart()
        {
            navigation.FindCart().Click();
        }
        public void GoToPO(string[]PD)
        {
            PO.FindPlaceOrder().Click();
            //Name
            PlaceOrderPopup.FindName().SendKeys(PD[0]);
            //Country
            PlaceOrderPopup.FindCountry().SendKeys(PD[1]);
            //City            
            PlaceOrderPopup.FindCity().SendKeys(PD[2]);
            //Credit card            
            PlaceOrderPopup.FindCard().SendKeys(PD[3]);
            //Month           
            PlaceOrderPopup.FindMonth().SendKeys(PD[4]);
            //Year            
            PlaceOrderPopup.FindYear().SendKeys(PD[5]);
        }
        public PlaceOrderContext SumbitPurchase(string[] PD)
        {
            element.FindButtonPurchase().Click();            
            var PopUP = element.FindCheckPopUp(PD);            
            Assert.IsTrue(PopUP.Displayed);
            return new PlaceOrderContext(WebDriver);
        }
        public PlaceOrderContext Maintest(string[] PD)
        {
            
            GoToLaptop();            
            GoToDell();            
            AddtoCart();            
            GoToCart();            
            GoToPO(PD);            
            return SumbitPurchase(PD);
        }

    }
}
