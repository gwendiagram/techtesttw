using System;
using System.Linq;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;

namespace MarsAir.Discounts
{
    public class Discounts : Driver
    {

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

      

        [Step("The user enters a <discount> for discount of that number times 10")]
        public void DiscountAmount(int discount)
        {

            //var discountString = RandomString(2) + discount + RandomString(3) + 0 + 0 + discount;
            //Console.WriteLine(discountString);
            var codeTextBox = _driver.FindElement(By.Id("promotional_code"));
            //codeTextBox.SendKeys(discountString);

        }
    }
}
