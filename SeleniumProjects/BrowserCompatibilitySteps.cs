using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using Microsoft.Edge.SeleniumTools;



namespace SeleniumProjects
{
    [Binding]

    public class BrowserCompatibilitySteps
    {

       public static IWebDriver driverChrome = new ChromeDriver();
       public static IWebDriver driverFox = new FirefoxDriver();
       public static IWebDriver driverIE = new InternetExplorerDriver();
        // public static IWebDriver driverEdge = new EdgeDriver();
        EdgeOptions options = new EdgeOptions();


        // Launch Microsoft Edge (Chromium)



        [Given(@"a webpage exists")]
        public void GivenAWebpageExists()
        {



            options.UseChromium = true;
           
            driverChrome = new ChromeDriver();
          driverFox = new FirefoxDriver();
          driverIE = new InternetExplorerDriver();
          //driverEdge = new EdgeDriver();

            ChromeDriverService chromeservice = ChromeDriverService.CreateDefaultService(@"C:\AUTOMATION2020\Projects", "chromedriver.exe");
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\AUTOMATION2020\Projects", "geckodriver.exe");
            InternetExplorerDriverService InternetDriverservice = InternetExplorerDriverService.CreateDefaultService(@"C:\AUTOMATION2020\Projects", "IEDriverServer.exe");
            EdgeDriverService edgeservice = EdgeDriverService.CreateDefaultService(@"C:\AUTOMATION2020\Projects", "msedgedriver.exe");
            





        }

        [When(@"i open the webpage in different browsers")]
        public void WhenIOpenTheWebpageInDifferentBrowsers()
        {


           var driverEdge = new EdgeDriver(options);
           driverChrome.Manage().Window.Size = new System.Drawing.Size(1000, 899);
           driverChrome.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
           driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
           driverFox.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
           driverIE.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
           driverEdge.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

        }
        
        [Then(@"The webpage should open in multiple browsers")]
        public void ThenTheWebpageShouldOpenInMultipleBrowsers()
        {
           driverChrome.Close();
           driverFox.Close();
           driverIE.Close();
        }
    }
}




/* 
IE Driver Notes:
"Enhanced Protected Mode" must be disabled for IE 10 and higher
The browser zoom level must be set to 100% so that the native mouse events can be set to the correct coordinates.
Change the size of text, apps, and other items" to 100% in display settings.
*/