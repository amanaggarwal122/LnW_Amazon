using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnW_Amazon.StepDefinitions
{
    [Binding]
    internal class Steps_AddToCart
    {
        WebDriver driver = new ChromeDriver();

        [Given(@"I am on Amazon India Website")]
        public void GivenIAmOnAmazonIndiaWebsite()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");
        }


        [Given(@"I search for product ""([^""]*)""")]
        public void GivenISearchForProduct(string monitor)
        {
            throw new PendingStepException();
        }

        [When(@"I click on the first product in result")]
        public void WhenIClickOnTheFirstProductInResult()
        {
            throw new PendingStepException();
        }

        [When(@"I click on Add to cart")]
        public void WhenIClickOnAddToCart()
        {
            throw new PendingStepException();
        }

        [When(@"I verify the price of the item")]
        public void WhenIVerifyThePriceOfTheItem()
        {
            throw new PendingStepException();
        }

        [When(@"I verify the subtotal of the cart")]
        public void WhenIVerifyTheSubtotalOfTheCart()
        {
            throw new PendingStepException();
        }

    }
}
