using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using SeleniumExtras.WaitHelpers;


namespace Selenium_ExplicitWait_Demo
{
    class Selenium_ExplicitWait_Demo
    {
        String test_url = "http://the-internet.herokuapp.com/javascript_alerts";

        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\AUTOMATION2020\Projects", "chromedriver.exe");
            driver.Manage().Window.Maximize();

           
        }

        [Test, Order(1)]
        public void test_alert()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1000, 899);
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            String button_xpath = "//button[.='Click for JS Alert']";
            var expectedAlertText = "I am a JS Alert";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            /* IWebElement alertButton = driver.FindElement(By.XPath(button_xpath)); */

            IWebElement alertButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(button_xpath)));
            alertButton.Click();

            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win.Text);

            alert_win.Accept();

            /* IWebElement clickResult = driver.FindElement(By.Id("result")); */

            var clickResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("result")));

            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You successfuly clicked an alert")
            {
                Console.WriteLine("Alert Test Successful");
            }
        }

        [Test, Order(2)]
        public void test_confirm()
        {
            String button_css_selector = "button[onclick='jsConfirm()']";
            var expectedAlertText = "I am a JS Confirm";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));

            confirmButton.Click();

            var confirm_win = driver.SwitchTo().Alert();
            confirm_win.Accept();

            IWebElement clickResult = driver.FindElement(By.Id("result"));
            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You clicked: Ok")
            {
                Console.WriteLine("Confirm Test Successful");
            }
        }

        [Test, Order(3)]
        public void test_dismiss()
        {
            String button_css_selector = "button[onclick='jsConfirm()']";
            var expectedAlertText = "I am a JS Confirm";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));

            confirmButton.Click();

            var confirm_win = driver.SwitchTo().Alert();
            confirm_win.Dismiss();

            IWebElement clickResult = driver.FindElement(By.Id("result"));
            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You clicked: Cancel")
            {
                Console.WriteLine("Dismiss Test Successful");
            }
        }

        [Test, Order(4)]
        public void test_sendalert_text()
        {
            String button_css_selector = "button[onclick='jsPrompt()']";
            var expectedAlertText = "I am a JS prompt";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));
            confirmButton.Click();

            var alert_win = driver.SwitchTo().Alert();
            alert_win.SendKeys("This is a test alert message");
            alert_win.Accept();

            IWebElement clickResult = driver.FindElement(By.Id("result"));
            Console.WriteLine(clickResult.Text);

            if (clickResult.Text == "You entered: This is a test alert message")
            {
                Console.WriteLine("Send Text Alert Test Successful");
            }
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}