using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumExtras.WaitHelpers;




namespace SeleniumHT
{  

    
    




    public class UserLogin
        {
            private readonly By _loginInputButton = By.LinkText("Log in");
            private readonly By _loginName = By.Id("loginusername");
            private readonly By _loginPass = By.Id("loginpassword");
            private readonly By _loginEnterButton = By.CssSelector("#logInModal .btn-primary");

            private readonly IWebDriver WebDriver;

            public UserLogin(IWebDriver driver)
            {
                WebDriver = driver;
            }
            public void GoToLogin()
            {
                WebDriver.FindElement(_loginInputButton).Click();
            }
            public UserLogin EnterUsername(string username)
            {
                WebDriver.FindElement(_loginName).SendKeys(username);
                return this;
            }
            public UserLogin EnterPassword(string password)
            {
                WebDriver.FindElement(_loginPass).SendKeys(password);
                return this;
            }
            public UserLogin SumbitLogin()
            {
                WebDriver.FindElement(_loginEnterButton).Click();
                return new UserLogin(WebDriver);
            }
            public UserLogin Login(string username, string password)
            {
                GoToLogin();
                Thread.Sleep(200);
                EnterUsername(username);
                Thread.Sleep(200);
                EnterPassword(password);
                Thread.Sleep(200);
                return SumbitLogin();
            }
        }

        public class Tests

        {   
            
            IWebDriver webDriver;
            ChromeOptions options;
            string[] User_data = { "Onime-power", "12345Kostia" };
            string[] Purchase_data = { "Kostia", "Ukraine", "Kyiv", "111111111", "May", "2022" };

            private readonly By _Laptop = By.LinkText("Laptops");            
            private readonly By _Dell = By.CssSelector("a[href *= 'prod.html?idp_=12']");
            private readonly By _AddToCart = By.CssSelector(" .btn-success");
            private readonly By _Cart = By.CssSelector("a[href *= 'cart.html']");
            private readonly By _PlaceOrder = By.CssSelector(" .btn-success");
            private readonly By _ButtonPurchase = By.XPath("//button[contains(@onclick,'purchaseOrder')]");

            private readonly By _CheckPopUp = By.Id("orderModal");

            




        public Tests()
            {
                //open browser
                options = new ChromeOptions();
                options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss; //.accept, .dismiss, etc.
                webDriver = new ChromeDriver(options);
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);



        }

            [SetUp]
            public void Setup()
            {


                //navigation User_data[1]
                webDriver.Navigate().GoToUrl("https://www.demoblaze.com/");


                //login operation
                // identify login button
                UserLogin Log_in = new UserLogin(webDriver);
                Log_in.Login(User_data[0], User_data[1]);



            }








            [Test]
            public void Test1()
            {


            //Part 2
                    
                    System.Threading.Thread.Sleep(1200);              
                    IWebElement lnkNotebook = webDriver.FindElement(_Laptop);
            //IWebElement lnkNotebook = webDriver.FindElement(By.XPath("//button[contains(@onclick,Laptops)]"));



                lnkNotebook.Click();

                //Part 3
                System.Threading.Thread.Sleep(1000);
                IWebElement lnkDell = webDriver.FindElement(_Dell);
                //prod.html?idp_=12
                System.Threading.Thread.Sleep(100);
                lnkDell.Click();

                //Part 4
                
                IWebElement lnkPurchase = webDriver.FindElement(_AddToCart);
                
                lnkPurchase.Click();
                //Part 5
                
                lnkPurchase.SendKeys("{ENTER}");
                
                IWebElement lnkCart = webDriver.FindElement(_Cart);
                
                lnkCart.Click();
                
                IWebElement lnkPOrder = webDriver.FindElement(_PlaceOrder);
                
                lnkPOrder.Click();

                //Part 6            
                
                var txtPOName = webDriver.FindElement(By.Id("name"));
                
                var txtCountry = webDriver.FindElement(By.Id("country"));
                
                var txtCity = webDriver.FindElement(By.Id("city"));
                
                var txtCard = webDriver.FindElement(By.Id("card"));
                
                var txtMonth = webDriver.FindElement(By.Id("month"));
                
                var txtYear = webDriver.FindElement(By.Id("year"));
                //Name
                
                txtPOName.SendKeys(Purchase_data[0]);
                //Country
                
                txtCountry.SendKeys(Purchase_data[1]);
                //City            
                
                txtCity.SendKeys(Purchase_data[2]);
                //Credit card            
                
                txtCard.SendKeys(Purchase_data[3]);
                //Month           
                
                txtMonth.SendKeys(Purchase_data[4]);
                //Year          
                System.Threading.Thread.Sleep(300);
                txtYear.SendKeys(Purchase_data[5]);


                
                    //button Purchase
                    
                    IWebElement lnkBPurchase = webDriver.FindElement(_ButtonPurchase);
                    
                    lnkBPurchase.Click();
                

                //Check TYFYP
                var element = webDriver.FindElement(_CheckPopUp);
                Assert.IsTrue(element.Displayed);
               /// System.Threading.Thread.Sleep(3000);
                webDriver.Quit();

            }

        }


    }
