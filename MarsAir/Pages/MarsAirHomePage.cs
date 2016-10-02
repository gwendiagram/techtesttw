using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "promotional_code")]
        public IWebElement DiscountTextBox { get; set; }

        public void EnterCode(string textToEnter)
        {
            this.DiscountTextBox.Clear();
            this.DiscountTextBox.SendKeys(textToEnter);   
        }

        [FindsBy(How = How.CssSelector, Using = "input[type = submit")]
        public IWebElement SubmitButton { get; set; }

        public void Submit()
        {
            this.SubmitButton.Click();
        }

        [FindsBy(How = How.Id, Using = "content")]
        public IWebElement ContentText { get; set; }

        public void AssertContentText(string textToAssert)
        {
            this.ContentText.Text.Should().Contain(textToAssert);

        }

        [FindsBy(How = How.LinkText, Using = "Back")]
        public IWebElement BackLink { get; set; }

        public void ClickBackLink()
        {
            this.BackLink.Click();
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
            this.MarsAirLink.Click();
        }


    }
}
