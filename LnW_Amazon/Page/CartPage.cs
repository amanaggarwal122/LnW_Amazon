using LnW_Amazon.Hook;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;

namespace LnW_Amazon.Page
{
    public class CartPage
    {
        public const string cartproductpriceElement = "//div[@class='sc-item-price-block']/descendant::div/descendant::div/descendant::div/span[contains(@class,'a-size-medium')]";
        public const string cartsubtotalElement = "//span[@id=\"sc-subtotal-amount-buybox\"]/descendant::span";
        public const string viewcartButton = "//a[contains(@id,'nav-cart')]";
        public const string checkoutButton = "//span[@id='attach-sidesheet-checkout-button']/span[@class='a-button-inner']/input[@class='a-button-input']";
        // private IWebDriver _driver;

        private IWebElement cartProductPriceElement
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                IWebElement searchboxElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(cartproductpriceElement)));
                return searchboxElement;
            }
        }

        private IWebElement cartSubTotalElement
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                IWebElement searchboxElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(cartsubtotalElement)));
                return searchboxElement;
            }
        }


        public string getTextOfProductPrice()
        {
            string price = cartProductPriceElement.Text;
            return price;
        }

        public string getTextOfCartSubtotal()
        {
            string price = cartSubTotalElement.Text;
            return price;
        }

        public void clickOnCartButton()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            bool displayCheck = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("attach-desktop-sideSheet"))).Displayed;

            if (displayCheck == true)
            {
                Thread.Sleep(500);
                //  Driver.Instance.SwitchTo().Frame(1);
                IWebElement checkouttElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("attach-close_sideSheet-link")));
                checkouttElement.Click();
                Thread.Sleep(1000);
                IWebElement addTocartElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(viewcartButton)));
                addTocartElement.Click();
            }
            else
            {
                Thread.Sleep(500);
                IWebElement addTocartElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(viewcartButton)));
                addTocartElement.Click();
            }


            string expectedTitle = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("h1"))).Text;
            Assert.AreEqual(expectedTitle, "Shopping Cart");
        }

        public void HideAlertBox()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            bool displayCheck = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("attach-desktop-sideSheet"))).Displayed;

            if (displayCheck == true)
            {
                Thread.Sleep(1000);
                //  Driver.Instance.SwitchTo().Frame(1);
                IWebElement checkouttElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("attach-close_sideSheet-link")));
                checkouttElement.Click();
                Thread.Sleep(500);
                //IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
               // Driver.Instance.SwitchTo().Alert();
               // alert.Text;

            }
        }
    }
}
