using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class AddAddress
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demowebshop.tricentis.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheAddAddressTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseURL + "/");

            driver.FindElement(By.LinkText("Log in")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("marko@marko.marko");

            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("marko1");
            driver.FindElement(By.CssSelector("input.button-1.login-button")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log out")));
            driver.FindElement(By.CssSelector("a.account")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Addresses")));
            driver.FindElement(By.LinkText("Addresses")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-1.add-address-button")));
            driver.FindElement(By.CssSelector("input.button-1.add-address-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Address_FirstName")));
            driver.FindElement(By.Id("Address_FirstName")).Clear();
            driver.FindElement(By.Id("Address_FirstName")).SendKeys("josko");
            driver.FindElement(By.Id("Address_LastName")).Clear();
            driver.FindElement(By.Id("Address_LastName")).SendKeys("josko");
            driver.FindElement(By.Id("Address_Email")).Clear();
            driver.FindElement(By.Id("Address_Email")).SendKeys("josko@josko.com");
            new SelectElement(driver.FindElement(By.Id("Address_CountryId"))).SelectByText("Canada");
            new SelectElement(driver.FindElement(By.Id("Address_CountryId"))).SelectByText("Croatia");
            driver.FindElement(By.Id("Address_City")).Clear();
            driver.FindElement(By.Id("Address_City")).SendKeys("josko");
            driver.FindElement(By.Id("Address_Address1")).Clear();
            driver.FindElement(By.Id("Address_Address1")).SendKeys("josko");
            driver.FindElement(By.Id("Address_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("Address_ZipPostalCode")).SendKeys("josko");
            driver.FindElement(By.Id("Address_PhoneNumber")).Clear();
            driver.FindElement(By.Id("Address_PhoneNumber")).SendKeys("josko");
            driver.FindElement(By.Id("Address_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("Address_ZipPostalCode")).SendKeys("123");
            driver.FindElement(By.Id("Address_PhoneNumber")).Clear();
            driver.FindElement(By.Id("Address_PhoneNumber")).SendKeys("321");
            driver.FindElement(By.CssSelector("input.button-1.save-address-button")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
