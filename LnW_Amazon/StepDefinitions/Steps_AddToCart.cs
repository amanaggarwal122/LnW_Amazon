using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using LnW_Amazon.Page;
using LnW_Amazon.Hook;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;

namespace LnW_Amazon.StepDefinitions
{
    [Binding]
    internal class Steps_AddToCart
    {
        private readonly ScenarioContext _scenarioContext;

        public Steps_AddToCart(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        string productpagePrice;
        int totalproductPrice;
        AmazonHook amazonPage;
        LandingPage landingPage;
        ProductPage productPage;
        CartPage cartPage;
        

       [Given(@"I am on Amazon India Website")]
        public void GivenIAmOnAmazonIndiaWebsite()
        {
            
            /*
            //Step 1 : Open Amazon.in
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            */
        }

        [Given(@"I search for the product ""([^""]*)""")]
        public void GivenISearchForTheProduct(string productToSearch)
        {
            landingPage = new LandingPage();
            landingPage.SendValueInSearchBox(productToSearch);
            landingPage.PressEnterOnSearchBox();
        }

        [When(@"I click on the position ""([^""]*)"" in result for product as ""([^""]*)""")]
        public void WhenIClickOnThePositionInResultForProductAs(int position, string productToSearch)
        {
            //Step 4 : Select the first Monitor item from the list           
            landingPage = new LandingPage();
            productPage = new ProductPage();
            landingPage.FindProduct(position, productToSearch);

            //Step 5 : Move to new window and store the price in sceario context
            productpagePrice = productPage.getTextOfElement();
            totalproductPrice = totalproductPrice + int.Parse(Regex.Replace(productpagePrice, @"[^0-9a-zA-Z]+", ""));
        }

        [When(@"I click on Add to cart")]
        public void WhenIClickOnAddToCart()
        {
            
            //Step 6 : Add selected item to cart
            productPage = new ProductPage();
            productPage.clickAddToCart();
        }

        [When(@"I opened cart")]
        public void WhenIOpenedCart()
        {
            //Step 7 : Open Cart
            cartPage = new CartPage();
            cartPage.clickOnCartButton();
        }

        [When(@"I verify the price of the item")]
        public void WhenIVerifyThePriceOfTheItem()
        {
            //Step 8 : Compare product price in cart to product price on product page
            cartPage = new CartPage();

            string cartproductPrice = cartPage.getTextOfProductPrice();
            Assert.IsTrue(cartproductPrice.Contains(productpagePrice));
        }

        [Then(@"I verify the subtotal of the cart")]
        public void ThenIVerifyTheSubtotalOfTheCart()
        {
            //Step 9 : Compare cart subtotal to product price
            cartPage = new CartPage();
            string cartTotal = cartPage.getTextOfCartSubtotal();
            Assert.IsTrue(cartTotal.Contains(productpagePrice));
        }

        [When(@"I hide the alert box")]
        public void WhenIHideTheAlertBox()
        {
            cartPage = new CartPage();
            cartPage.HideAlertBox();
        }

        [When(@"I verify subtotal of cart should match sum of item price")]
        public void WhenIVerifySubtotalOfCartShouldMatchSumOfItemPrice()
        {
            cartPage = new CartPage();
            string cartTotal = cartPage.getTextOfCartSubtotal();
            int numerictotal = int.Parse(Regex.Replace(cartTotal, @"[^0-9a-zA-Z]+", ""));
            Assert.IsTrue(numerictotal.Equals(totalproductPrice*100));
            
        }


    }
}
