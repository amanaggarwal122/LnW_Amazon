using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace LnW_Amazon.StepDefinitions
{
    [Binding]
    internal class Steps_AddToCart
    {
       
        WebDriver driver = new ChromeDriver();
        
        string productpagePrice;

        [Given(@"I am on Amazon India Website")]
        public void GivenIAmOnAmazonIndiaWebsite()
        {
            //Step 1 : Open Amazon.in
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [Given(@"I search for the product ""([^""]*)""")]
        public void GivenISearchForTheProduct(string monitor)
        {
            //Step 2 : Search Monitor in Amazon Home search Box
            IWebElement searchboxElement = driver.FindElement(By.XPath("//input[@id=\"twotabsearchtextbox\"]"));
            searchboxElement.SendKeys(monitor);

            //Step 3 : Click Enter

            Thread.Sleep(1000);
            searchboxElement.SendKeys(Keys.Return);

         }

        [When(@"I click on the first product in result")]
        public void WhenIClickOnTheFirstProductInResult()
        {
            //Step 4 : Select the first Monitor item from the list
            IList<IWebElement> sere = driver.FindElements(By.XPath("//span[contains(@class,\"a-size-medium\")]"));

            foreach (IWebElement element in sere)
            {
                string resultText = element.Text;
                if (resultText.Contains("Monitor"))
                {
                    element.Click();
                    break;
                }

            }

            //Step 5 : Move to new window and store the price in sceario context

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            IWebElement priceElement = driver.FindElement(By.XPath("//span[contains(@class,\"a-price-whole\")]"));
            productpagePrice = priceElement.Text;

        }

        [When(@"I click on Add to cart")]
        public void WhenIClickOnAddToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(By.XPath("//input[contains(@id,\"add-to-cart-button\")]")).Click();
            Thread.Sleep(1000);           
        }

        [When(@"I opened cart")]
        public void WhenIOpenedCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@id,\"attach-added-to-cart-message\")]"))).Displayed)
            {
                driver.FindElement(By.XPath("//a[contains(@id,\"attach-close_sideSheet-link\")]")).Click();
            }
            else
            {
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//a[contains(@id,\"nav-cart\")]")).Click();
                Thread.Sleep(1000);
                string expectedTitle = driver.FindElement(By.TagName("h1")).Text;

                Assert.AreEqual(expectedTitle, "Shopping Cart");
            }
             
        }


        [When(@"I verify the price of the item")]
        public void WhenIVerifyThePriceOfTheItem()
        {
            ////div[@class="sc-item-price-block"]/descendant::div/descendant::div/descendant::div/span[contains(@class,"a-size-medium")]
            //div[@class="sc-item-price-block"]/descendant::div/descendant::div/descendant::div/span[contains(@class,"a-size-medium")]
            IWebElement cartproductpriceElement = driver.FindElement(By.XPath("//div[@class=\"sc-item-price-block\"]/descendant::div/descendant::div/descendant::div/span[contains(@class,\"a-size-medium\")]"));

            string cartproductPrice = cartproductpriceElement.Text;

            Assert.IsTrue(cartproductPrice.Contains(productpagePrice));
        }

        [Then(@"I verify the subtotal of the cart")]
        public void ThenIVerifyTheSubtotalOfTheCart()
        {
            ////div[contains(@class="a-section")]/descendant::div[contains(@class,"a-row")]/descendant::span[@id,"sc-subtotal-amount-buybox"]
            IWebElement cartTotalElement = driver.FindElement(By.XPath("//span[@id=\"sc-subtotal-amount-buybox\"]/descendant::span"));

            string cartTotal = cartTotalElement.Text;

            Assert.IsTrue(cartTotal.Contains(productpagePrice));

        }


    }
}
