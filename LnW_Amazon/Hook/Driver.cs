using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnW_Amazon.Hook
{
    public sealed class Driver
    {
        private static DriverManager instance = null;

        private Driver()
        {
        }

        public static IWebDriver Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance._driver;
                }
                return instance._driver;
            }
            set
            {
                if (instance == null)
                {
                    instance = new DriverManager(value);
                }
            }
        }
    }
   
}
