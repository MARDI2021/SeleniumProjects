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



namespace SeleniumProjects
{

    [Binding]
    public class WindowsAlerts
    {
        [When(@"I click on windows alerts link")]
        public void WhenIClickOnWindowsAlertsLink()
        
        {
            OpenPageSteps.WhenITypeTheUrl();
            OpenPageSteps.driver1.FindElement(By.XPath("//*[@id='content']/ul/li[29]/a")).Click();
        }


        [Then(@"the windows alerts should work")]
        //TEST 1
        public void ThenTheWindowsAlertsShouldWork()
        {

            String button_xpath = "//*[@id='content']/div/ul/li[1]/button";
            var expectedAlertText = "I am a JS Alert";

            WebDriverWait wait = new WebDriverWait(OpenPageSteps.driver1, TimeSpan.FromSeconds(10));

            /* IWebElement alertButton = driver.FindElement(By.XPath(button_xpath)); */
            IWebElement alertButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(button_xpath)));
            alertButton.Click();

            /*Once the alert window is loaded, the SwitchTo() command is used to switch the context to the alert window.The alert is accepted using the accept() method.*/
            var alert_win = OpenPageSteps.driver1.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, alert_win.Text);

            alert_win.Accept();

            var clickResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("result")));
            var dd = clickResult.Text;

            if (dd == "You successfuly clicked an alert")
            {
                Console.WriteLine("Alert Test Successful");
            }

            else
            {
                Console.WriteLine("Alert Test fails");
                Assert.Fail();
            }

          


        }
        [Then(@"theTestConfirmAlert should work")]
        //TEST 2
        public void ThenTheTestConfirmAlertShouldWork()
       
        {
            String button_css_selector = "button[onclick='jsConfirm()']";
            var expectedAlertText = "I am a JS Confirm";

            WebDriverWait wait = new WebDriverWait(OpenPageSteps.driver1, TimeSpan.FromSeconds(10));
 

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));

            confirmButton.Click();

            var confirm_win = OpenPageSteps.driver1.SwitchTo().Alert();
            confirm_win.Accept();
           

            IWebElement clickResult = OpenPageSteps.driver1.FindElement(By.Id("result"));
            var bb = clickResult.Text;

            if (bb == "You clicked: Ok")
            {
                Console.WriteLine("Confirm Test Successful with ok");
            }

            
            else
            {
                Console.WriteLine("Confirm Test fails");
                Assert.Fail();
            }

        }

        [Then(@"the Test Dismiss Alert should work")]
        //TEST 3
        public void ThenTheTestDismissAlertShouldWork()
        {
            String button_css_selector = "button[onclick='jsConfirm()']";
            var expectedAlertText = "I am a JS Confirm";

            WebDriverWait wait = new WebDriverWait(OpenPageSteps.driver1, TimeSpan.FromSeconds(10));
            

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));

            confirmButton.Click();

            var confirm_win = OpenPageSteps.driver1.SwitchTo().Alert();
            confirm_win.Dismiss();

            IWebElement clickResult = OpenPageSteps.driver1.FindElement(By.Id("result"));
            var Alert = clickResult.Text;
            if (Alert == "You clicked: Cancel")
            {
                Console.WriteLine("Alert Dismiss Test Successful");
            }

            else
            {
                Console.WriteLine("Alert Dismiss Test fails");
                Assert.Fail();
            }
        }

        [Then(@"send Alert message should work")]
        //TEST 4
        public void ThenSendAlertMessageShouldWork()
        {
            String button_css_selector = "button[onclick='jsPrompt()']";
            var expectedAlertText = "I am a JS prompt";

            WebDriverWait wait = new WebDriverWait(OpenPageSteps.driver1, TimeSpan.FromSeconds(10));
          

            IWebElement confirmButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(button_css_selector)));
            confirmButton.Click();

            var alert_win = OpenPageSteps.driver1.SwitchTo().Alert();
            alert_win.SendKeys("This is Hamid");
            alert_win.Accept();


            IWebElement clickResult = OpenPageSteps.driver1.FindElement(By.Id("result"));
            var SendAlert = clickResult.Text;
            if (SendAlert == "You entered: This is Hamid")
            {
                Console.WriteLine("Alert send message Test Successful");
            }

            else
            {
                Console.WriteLine("Alert Send message Test fails");
                Assert.Fail();
            }
        }

    }





}
