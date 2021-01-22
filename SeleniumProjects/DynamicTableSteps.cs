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
    public class DynamicTableSteps
    {


            [When(@"I check the content of a table")]
            public static void WhenICheckTheContentOfATable()
            {
            OpenPageSteps.driver1.FindElement(By.XPath("//*[@id='content']/ul/li[41]/a")).Click();
            IWebElement elemTable = OpenPageSteps.driver1.FindElement(By.XPath("//*[@id='table1']"));
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            String strRowData = "";

            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        strRowData = strRowData + elemTd.Text + "\t\t";
                     
                    }
                }

                else
                {
                    // To print the data into the console
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
                    Console.WriteLine(strRowData);
                    strRowData = String.Empty;
            }
                    Console.WriteLine("");
                    OpenPageSteps.driver1.Quit();

            }

        

        [Then(@"the data table should be displayed")]
        public static void ThenTheDataTableShouldBeDisplayed()
        {
        }
            
    }
}
    