using System;
using System.Threading;
using MyFirstCSharpProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace MyFirstCSharpProject
{
    [TestFixture]
    [Parallelizable]
    class TM_Tests : CommonDriver
    {
        [Test, Order(1), Description(" check if user is able to create time record with valid data")]
        public void CreateTMTests()
        {
            //home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            //TMpage object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.createTM(driver);
        }

        [Test, Order(2), Description(" check if user is able to edit time record with valid data")]
        public void EditTMTests()
        {
            //home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // edit time
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTM(driver, "sep2021 industry connect");
        }

        [Test, Order(3), Description(" check if user is able to delete time record")]
        public void DeleteTMTests()
        {
            //home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            //delet time
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeletTM(driver);
        }
    }
}