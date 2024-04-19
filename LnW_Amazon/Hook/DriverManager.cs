using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LnW_Amazon.Hook
{
    public class DriverManager

    {

        public readonly IWebDriver _driver;

        public DriverManager(IWebDriver driver)
        {

            _driver = driver;
        }

        public void Quite()
        {
            _driver.Quit();
        }
    }
}
