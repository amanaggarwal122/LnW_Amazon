using LnW_Amazon.Hook;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnW_Amazon.Page
{
    public class ProductPage
    {
        public const string price2 = "//span[contains(@class,'a-price-whole')]";
        public const string priceElement = "//div[contains(@class,'a-section')]/span[contains(@class,'a-price')]/span[@aria-hidden='true']/span[(@class='a-price-whole')]";
        public const string addTocartButton2 = "//input[contains(@id,'add-to-cart-button')]";
        public const string addTocartButton = "//div[contains(@class,'a-section')]/div[contains(@id,'addToCart_feature_div')]/div[contains(@class,'a-button-stack')]/span[contains(@class,'a-declarative')]/span[contains(@id,'submit.add-to-cart')]/span[@class='a-button-inner']/input[contains(@id,'add-to-cart-button')]";
        // private IWebDriver _driver;

        private IWebElement weSearchBox
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                IWebElement searchboxElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(priceElement)));
                return searchboxElement;
            }
        }

        public IWebElement currentPriceElement()
        {
            return weSearchBox;
        }
        public string getTextOfElement()
        {
             string price = weSearchBox.Text;
            return price;
        }

        public void clickAddToCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            IWebElement addTocartElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(addTocartButton)));
            addTocartElement.Click();
            Thread.Sleep(100);
        }

    }
}
