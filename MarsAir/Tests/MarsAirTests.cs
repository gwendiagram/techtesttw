
using System;
using System.Linq;
using System.Runtime.Remoting.Channels;
using FluentAssertions;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using MarsAir.Pages;



namespace MarsAir.Tests
{
    public class Search : Driver
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

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
        public void SelectMonthFromDirectionField(string month, string direction)
        {
            MarsAirHomePage marsAirHomePage = new MarsAirHomePage(_driver);
            if (direction == "departing")
            {
                marsAirHomePage.SelectDepartingDd(month);
            }
            else
            {
                marsAirHomePage.SelectReturningDd(month);
            }

        }

        [Step("Press submit")]
        public void PressValue()
        {
            MarsAirHomePage marsAirHomePage = new MarsAirHomePage(_driver);
            marsAirHomePage.Submit();

        }

        [Step("Assert user is informed, <availability>")]
        public void AssertAvailability(string availability)
        {
            MarsAirHomePage marsAirHomePage = new MarsAirHomePage(_driver);
            marsAirHomePage.AssertContentText(availability);
        }

        [Step("The user enters a discount for a promotional code <table>")]
        public void DiscountAmount(Table table)
        {
            foreach (var tableRow in table.GetTableRows())
            {
                var discountString = RandomString(2) + tableRow.GetCell("discountnumber") + "-" + RandomString(3) + "-" + 0 + 0 +
                                     tableRow.GetCell("discountnumber");
                Console.WriteLine(discountString);
                MarsAirHomePage marsAirHomePage = new MarsAirHomePage(_driver);
                marsAirHomePage.EnterCode(discountString);
                marsAirHomePage.Submit();
                marsAirHomePage.AssertContentText("used: " + tableRow.GetCell("discountpercent"));
                marsAirHomePage.AssertContentText(discountString);
                marsAirHomePage.ClickBackLink();

            }

        }

        [Step("The user clicks the MarsAir logo")]
        public void ClickLogo()
        {
            MarsAirHomePage marsAirHomePage = new MarsAirHomePage(_driver);
            marsAirHomePage.ClickMarsAirLogo();
        }

        [Step("<salestext> is displayed on the page")]
        public void AssertSalesText(string salestext)
        {
            MarsAirHomePage marsAirHomePage = new MarsAirHomePage(_driver);
            marsAirHomePage.AssertContentText(salestext);
        }
    }
}
