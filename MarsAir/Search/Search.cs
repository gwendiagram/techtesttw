using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MarsAir.Search
{
    public class Search
    {
        private IWebDriver _driver;

        [BeforeSuite]
        public void Initialize()
        {
            _driver = DriverFactory.GetDriver();
        }

        [AfterSuite]
        public void Cleanup()
        {
            _driver.Quit();
        }

        [Step("Navigate to MarsAir homepage <url>")]
        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);

            _driver.Title.Should().Be("Mars Airlines: Home");
        }

        [Step("Select <month> from the <direction> field")]
        public void GoToGaugeGetStartedPage(string month, string direction)
        {
            var directionField = _driver.FindElement(By.Id(direction));
            var selectElement = new SelectElement(directionField);
            selectElement.SelectByText(month);

        }
    }
}
