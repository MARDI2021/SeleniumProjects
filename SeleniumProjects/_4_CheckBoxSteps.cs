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
    public class _4_CheckBoxSteps 
    {
        [Given(@"the web page is displayed")]
        public void GivenTheWebPageIsDisplayed()
        {
     
            _3_FormAuthenticationSteps.driver1.Manage().Window.Size = new System.Drawing.Size(1000, 899);
            _3_FormAuthenticationSteps.driver1.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
            _3_FormAuthenticationSteps.driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [When(@"I check the first checkbox")]
        public void WhenICheckTheFirstCheckbox()
        {
            IWebElement Checkbox = _3_FormAuthenticationSteps.driver1.FindElement(By.XPath("//*[@id='checkboxes']/input[1]"));
            
            if (!Checkbox.Selected)
            {
                Checkbox.Click();

            }
        }
        [When(@"I uncheck the second checkbox")]
        public void WhenIUncheckTheSecondCheckbox()
        {
            IWebElement UnCheckbox = _3_FormAuthenticationSteps.driver1.FindElement(By.XPath("//*[@id='checkboxes']/input[2]"));

            if (UnCheckbox.Selected)
            {
                UnCheckbox.Click();
           

            }
        }
        
        [Then(@"the first checkbox is checked and the second check box is unchecked")]
        public void ThenTheFirstCheckboxIsCheckedAndTheSecondCheckBoxIsUnchecked()
        {
            IWebElement Checkbox1 = _3_FormAuthenticationSteps.driver1.FindElement(By.XPath("//*[@id='checkboxes']/input[1]"));
            IWebElement Checkbox2 = _3_FormAuthenticationSteps.driver1.FindElement(By.XPath("//*[@id='checkboxes']/input[2]"));

            Assert.AreEqual("true", Checkbox1.GetAttribute("checked"));
            Assert.AreEqual(null, Checkbox2.GetAttribute("checked"));
        }


    }
}
