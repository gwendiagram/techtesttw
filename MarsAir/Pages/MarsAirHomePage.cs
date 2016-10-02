using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MarsAir.Pages
{
    public class MarsAirHomePage 
    {
        private readonly IWebDriver driver;
        private readonly string url = @"http://gdiagram.marsair.tw/";

        public MarsAirHomePage(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "promotional_code")]
        public IWebElement DiscountTextBox { get; set; }

        public void EnterCode(string textToEnter)
        {
            DiscountTextBox.Clear();
            DiscountTextBox.SendKeys(textToEnter);   
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/form/dl[4]/dd/input")]
        public IWebElement SubmitButton { get; set; }

        public void Submit()
        {
            SubmitButton.Click();
        }

        [FindsBy(How = How.Id, Using = "content")]
        public IWebElement ContentText { get; set; }

        public void AssertContentText(string textToAssert)
        {
            ContentText.Text.Should().Contain(textToAssert);

        }

        [FindsBy(How = How.LinkText, Using = "Back")]
        public IWebElement BackLink { get; set; }

        public void ClickBackLink()
        {
            BackLink.Click();
        }

        [FindsBy(How = How.Id, Using = "departing")]
        public IWebElement DepartingDropDown { get; set; }

        public void SelectDepartingDd(string month)
        {
            var selectElement = new SelectElement(DepartingDropDown);
            selectElement.SelectByText(month);
        }

        [FindsBy(How = How.Id, Using = "returning")]
        public IWebElement ReturningDropDown { get; set; }

        public void SelectReturningDd(string month)
        {
            var selectElement = new SelectElement(ReturningDropDown);
            selectElement.SelectByText(month);
        }

        [FindsBy(How = How.LinkText, Using = "MarsAir")]
        public IWebElement MarsAirLink { get; set; }

        public void ClickMarsAirLogo()
        {
            MarsAirLink.Click();
        }


    }
}
