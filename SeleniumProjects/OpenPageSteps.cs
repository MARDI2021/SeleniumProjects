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
    public class OpenPageSteps
    {
        public static IWebDriver driver1 = new ChromeDriver();
        [Given(@"the browser is open")]
   
        public static void GivenTheBrowserIsOpen()
        {
            driver1 = new ChromeDriver();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\AUTOMATION2020\Projects", "chromedriver.exe");
           
        }
        
        [When(@"I type the url")]
        public static void WhenITypeTheUrl()
        {
            driver1.Manage().Window.Size = new System.Drawing.Size(1000, 899);
            driver1.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }//*[@id="content"]/ul

        [Then(@"the main home page is displayed")]
        public static void ThenTheMainHomePageIsDisplayed()
        {
          
            Assert.That(driver1.Title, Is.EqualTo("The Internet"));
            driver1.Quit(); 

        }
    }
}
