using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace MarsAir
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            var browser = Environment.GetEnvironmentVariable("BROWSER");
            switch (browser)
            {
                case "chrome":
                    return new ChromeDriver();
                case "ie":
                    return new InternetExplorerDriver();
                case "firefox":
                    return new FirefoxDriver();
                default: 
                    return new PhantomJSDriver();
            }
        }

    }
    public class Driver
    {
        public IWebDriver _driver;

    }
}
