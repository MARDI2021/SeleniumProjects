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

namespace SeleniumProjects
{
    [Binding]
    public class _3_FormAuthenticationSteps
    {
      public static IWebDriver driver1 = new ChromeDriver();
      [Given(@"the login form page is displayed")]
        public void GivenTheLoginFormPageIsDisplayed()
        {
            driver1 = new ChromeDriver();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\AUTOMATION2020\Projects", "chromedriver.exe");
            driver1.Manage().Window.Size = new System.Drawing.Size(1000, 899);
            driver1.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


        }

        [When(@"I enter the correct username")]
        public void WhenIEnterTheCorrectUsername()
        {
            driver1.FindElement(By.Id("username")).SendKeys("tomsmith");
        }
        
        [When(@"I enter the correct password")]
        public void WhenIEnterTheCorrectPassword()
        {
            driver1.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
        }
        
        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            IWebElement parent = driver1.FindElement(By.Id("login"));
            IWebElement child = parent.FindElement(By.ClassName("radius"));
            child.Submit();
            
        }
        
        [Then(@"the home page is displayed")]
        public void ThenTheHomePageIsDisplayed()
        {
            driver1.FindElement(By.XPath("//*[@id='content']/div/h4"));
            driver1.FindElement(By.LinkText("Logout"));
            IWebElement element = driver1.FindElement(By.XPath("//*[@id='content']/div/h4[contains(text(),'Welcome to the Secure Area. When you are done click logout below.')]"));
            Console.WriteLine("Link Test Pass");
            //driver1.Close();
            
        }
    }
}
