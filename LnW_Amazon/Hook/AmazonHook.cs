using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnW_Amazon.Hook
{
    [Binding]
    internal class AmazonHook
    {
        [BeforeScenario(Order = 0)]
        public void EnableActorRegistration()
        {
            var driver = new ChromeDriver();
            //Step 1 : Open Amazon.in
            Thread.Sleep(500);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            
            Driver.Instance = driver;
        }

        [AfterScenario(Order = 0)]
        public void DisableActorRegistration()
        {
            Driver.Instance.Quit();
        }
    }
}
