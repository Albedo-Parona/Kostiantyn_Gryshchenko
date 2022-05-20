using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace SeleniumHT
{
    public class Tests
    {
        IWebDriver webDriver;
        ChromeOptions options;
        string[] User_data = { "Onime-power", "12345Kostia" };
        string[] Purchase_data = { "Kostia", "Ukraine", "Kyiv", "111111111", "May", "2022" };
        private readonly By _loginInputButton = By.LinkText("Log in");
        private readonly By _loginName = By.Id("loginusername");
        private readonly By _loginPass = By.Id("loginpassword");
        private readonly By _loginEnterButton = By.CssSelector("#logInModal .btn-primary");
        private readonly By _Laptop = By.LinkText("Laptops");
        private readonly By _Dell = By.CssSelector("a[href *= 'prod.html?idp_=12']");
        private readonly By _AddToCart = By.CssSelector(" .btn-success");
        private readonly By _Cart = By.CssSelector("a[href *= 'cart.html']");
        private readonly By _PlaceOrder = By.CssSelector(" .btn-success");
        private readonly By _ButtonPurchase = By.XPath("//button[contains(@onclick,'purchaseOrder')]");

        private readonly By _CheckPopUp = By.Id("orderModal");



        private bool PopUpCheck(By by, IWebDriver a)
        {
            try
            {
                a.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public Tests() {
            //open browser
            options = new ChromeOptions();
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss; //.accept, .dismiss, etc.
            webDriver = new ChromeDriver(options);

            
            
        }

        [SetUp]
        public void Setup()
        {


            //navigation
            webDriver.Navigate().GoToUrl("https://www.demoblaze.com/");


            //login operation
            // identify login button
            IWebElement lnkLogin = webDriver.FindElement(_loginInputButton);
            //operation
            lnkLogin.Click();
            //Username
            System.Threading.Thread.Sleep(100);
            var txtUserName = webDriver.FindElement(_loginName);
            System.Threading.Thread.Sleep(100);
            var txtUserPass = webDriver.FindElement(_loginPass);
            //Assertion op
            Assert.That(txtUserName.Displayed, Is.True);
            System.Threading.Thread.Sleep(150);
            txtUserName.SendKeys(User_data[0]);
            System.Threading.Thread.Sleep(100);
            txtUserPass.SendKeys(User_data[1]);
            System.Threading.Thread.Sleep(100);
            IWebElement lnkLogin2 = webDriver.FindElement(_loginEnterButton);
            System.Threading.Thread.Sleep(100);
            lnkLogin2.Click();

        }




        



        [Test]
        public void Test1()
        {
            //Part 2
            System.Threading.Thread.Sleep(1200);
            IWebElement lnkNotebook = webDriver.FindElement(_Laptop);
            //IWebElement lnkNotebook = webDriver.FindElement(By.XPath("//button[contains(@onclick,Laptops)]"));

            System.Threading.Thread.Sleep(100);
            lnkNotebook.Click();

            //Part 3
            System.Threading.Thread.Sleep(1000);
            IWebElement lnkDell = webDriver.FindElement(_Dell);
            //prod.html?idp_=12
            System.Threading.Thread.Sleep(100);
            lnkDell.Click();

            //Part 4
            System.Threading.Thread.Sleep(1000);
            IWebElement lnkPurchase = webDriver.FindElement(_AddToCart);
            System.Threading.Thread.Sleep(100);
            lnkPurchase.Click();
            //Part 5
            //Тут вискакувала проблема з Alert-ом, тому я поміняв підключення гугл драйвера вначалі.
            System.Threading.Thread.Sleep(3000);
            lnkPurchase.SendKeys("{ENTER}");
            System.Threading.Thread.Sleep(1000);
            IWebElement lnkCart = webDriver.FindElement(_Cart);
            System.Threading.Thread.Sleep(100);
            lnkCart.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement lnkPOrder = webDriver.FindElement(_PlaceOrder);
            System.Threading.Thread.Sleep(100);
            lnkPOrder.Click();

            //Part 6            
            System.Threading.Thread.Sleep(100);
            var txtPOName = webDriver.FindElement(By.Id("name"));
            System.Threading.Thread.Sleep(100);
            var txtCountry = webDriver.FindElement(By.Id("country"));
            System.Threading.Thread.Sleep(100);
            var txtCity = webDriver.FindElement(By.Id("city"));
            System.Threading.Thread.Sleep(100);
            var txtCard = webDriver.FindElement(By.Id("card"));
            System.Threading.Thread.Sleep(100);
            var txtMonth = webDriver.FindElement(By.Id("month"));
            System.Threading.Thread.Sleep(100);
            var txtYear = webDriver.FindElement(By.Id("year"));
            //Name
            System.Threading.Thread.Sleep(100);
            txtPOName.SendKeys(Purchase_data[0]);
            //Country
            System.Threading.Thread.Sleep(100);
            txtCountry.SendKeys(Purchase_data[1]);
            //City            
            System.Threading.Thread.Sleep(100);
            txtCity.SendKeys(Purchase_data[2]);
            //Credit card            
            System.Threading.Thread.Sleep(100);
            txtCard.SendKeys(Purchase_data[3]);
            //Month           
            System.Threading.Thread.Sleep(100);
            txtMonth.SendKeys(Purchase_data[4]);
            //Year          
            System.Threading.Thread.Sleep(100);
            txtYear.SendKeys(Purchase_data[5]);



            //button Purchase
            System.Threading.Thread.Sleep(100);
            IWebElement lnkBPurchase = webDriver.FindElement(_ButtonPurchase);
            System.Threading.Thread.Sleep(100);
            lnkBPurchase.Click();

            //Check TYFYP
            System.Threading.Thread.Sleep(1000);
            if (PopUpCheck(_CheckPopUp, webDriver) == true)
                webDriver.Navigate().GoToUrl("https://free-png.ru/wp-content/uploads/2021/06/free-png.ru-39.png");
            else webDriver.Navigate().GoToUrl("https://hyperhost.ua/info/storage/uploads/2021/03/wrong%20false%20icon.png");
            // By.CssSelector("sweetalert")

        }

    }


}