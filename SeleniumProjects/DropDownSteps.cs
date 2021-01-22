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
    public class DropDownSteps
    {
        [Given(@"the web page is open")]
        public void GivenTheWebPageIsOpen()
        {
            OpenPageSteps.WhenITypeTheUrl();
            //Check that the element can be accessed with different types of locators
            //OpenPageSteps.driver1.FindElement(By.LinkText("Dropdown")).Click();
            //OpenPageSteps.driver1.FindElement(By.PartialLinkText("Dropd")).Click();
           // OpenPageSteps.driver1.FindElement(By.ClassName("example")).Click();
            //OpenPageSteps.driver1.FindElement(By.Id("dropdown")).Click();
            OpenPageSteps.driver1.FindElement(By.XPath("//*[@id='content']/ul/li[11]/a")).Click();



        }

        [When(@"I select an item from the dropdwnlist menu")]
        public static void WhenISelectAnItemFromTheDropdwnlistMenu()
        {
       

  //find the element by id and check that the dropdown menu contains the options
           IWebElement element = OpenPageSteps.driver1.FindElement(By.Id("dropdown"));

           SelectElement selectByValue = new SelectElement(element);
           selectByValue.SelectByText("Option 1");
           selectByValue.SelectByText("Option 2");

        }

        [Then(@"the item will be selected")]
        public void ThenTheItemWillBeSelected()
        {



          String elementval = OpenPageSteps.driver1.FindElement(By.Id("dropdown")).GetAttribute("value");
          //assert that the last value selected contains the value
            Assert.That(elementval.ToString, Is.EqualTo("2"));
            
            OpenPageSteps.driver1.Close(); 
        }
    }
}
