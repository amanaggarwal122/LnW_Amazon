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
    public class LandingPage
    {
        public const string searchBox = "//input[@id='twotabsearchtextbox']";
        public const string productElement = "//span[contains(@class,'a-size-medium')]";
        // private IWebDriver _driver;

        private IWebElement weSearchBox
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                IWebElement searchboxElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(searchBox)));
                return searchboxElement;
            }
        }

        public void ClickonSearchBox()
        {
            weSearchBox.Click();
        }
        public void SendValueInSearchBox(string value)
        {
          weSearchBox.SendKeys(value);            
        }

        public void PressEnterOnSearchBox()
        {
            weSearchBox.SendKeys(Keys.Return);
        }

        public void FindProduct(int position, string productToSearch)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            //Step 4 : Select the first Monitor item from the list

            IList<IWebElement> resultList = Driver.Instance.FindElements(By.XPath(productElement));
            int count = position;
            foreach (IWebElement element in resultList)
            {
                string resultText = element.Text;

                if (resultText.Contains(productToSearch))
                {
                    count++;
                    //element.Click();
                    break;
                }

            }
            resultList[count].Click();
            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.Last());
        }
    }
}
