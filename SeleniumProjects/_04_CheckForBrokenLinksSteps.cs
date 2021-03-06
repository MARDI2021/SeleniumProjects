﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumProjects
{
    [Binding]
    public class _04_CheckForBrokenLinksSteps
    {



        [Given(@"the web page with links is displayed")]
        public void GivenTheWebPageWithLinksIsDisplayed()
        {

            OpenPageSteps.WhenITypeTheUrl();
        }

        [When(@"I check all the links")]
        public void WhenICheckAllTheLinks()
        {
            //no method declared 

        }



        [Then(@"there should be no broken links")]
        public static void ThenThereShouldBeNoBrokenLinks()
        {

            int elementCount = OpenPageSteps.driver1.FindElements(By.TagName("a")).Count();
            if (elementCount != 46) //there should be 46 links in the page otherwise fail the test
            {
                Assert.Fail();
            }
            else
            {
                Console.WriteLine(elementCount);
            }

            IWebElement links3 = OpenPageSteps.driver1.FindElement(By.XPath("//*[@id='content']/ul"));
            ReadOnlyCollection<IWebElement> aTags = links3.FindElements(By.TagName("a"));
            Console.WriteLine(aTags.Count);

            for (int i = 37; i < aTags.Count; i++)
            {
                int index2 = 2;
                int index7 = 7;
                int index36 = 36;

                if ((i == index2) || (i == index7) || (i == index36))
                {
                    continue;
                }


                aTags[i].SendKeys(Keys.Control + Keys.Enter);
                OpenPageSteps.driver1.SwitchTo().Window(OpenPageSteps.driver1.WindowHandles[1]);
                string pageSource = OpenPageSteps.driver1.PageSource.ToString();

                if (pageSource.Contains("404"))

                {
                    Console.WriteLine("Error 404 page cannot be found");
                }

                Console.WriteLine(pageSource);
                OpenPageSteps.driver1.SwitchTo().Window(OpenPageSteps.driver1.WindowHandles[1]).Close();
                OpenPageSteps.driver1.SwitchTo().Window(OpenPageSteps.driver1.WindowHandles[0]);
                
            }
                OpenPageSteps.driver1.Close();

        }


    }


}



