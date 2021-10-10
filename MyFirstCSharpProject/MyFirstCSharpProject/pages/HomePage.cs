using System;
using System.Threading;
using MyFirstCSharpProject.Utilities;
using OpenQA.Selenium;

namespace MyFirstCSharpProject
{
    class HomePage
    {
        public void GoToHomePage(IWebDriver driver)
        {
            //click on administration dropdown
            IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administration.Click();
            Wait.WaitForElementToBeClickable(driver,"Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

            //select time & material from dropdown list
            IWebElement TMdropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TMdropdown.Click();
        }

        internal void GoToTMPage(IWebDriver driver)
        {
            //click on administration dropdown
            IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administration.Click();
            Wait.WaitForElementToBeClickable(driver,"Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

            //select time & material from dropdown list
            IWebElement TMdropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TMdropdown.Click();
        }

        public void GoToEmployeePage(IWebDriver driver)
        {
            //navigate to employee page
        }
    }
}
