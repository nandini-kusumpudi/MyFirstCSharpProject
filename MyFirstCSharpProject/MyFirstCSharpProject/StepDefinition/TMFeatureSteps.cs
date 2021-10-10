using MyFirstCSharpProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MyFirstCSharpProject.StepDefinition
{
    [Binding]
    public class TMFeatureSteps : CommonDriver
    {
        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [Given(@"I navigate to time and material page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create time and material record")]
        public void WhenICreateTimeAndMaterialRecord()
        {
            //TMpage object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.createTM(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tMPageObj = new TMPage();

            string newCode = tMPageObj.GetCode(driver);
            string newTypeCode = tMPageObj.GetTypeCode(driver);
            string newDescription = tMPageObj.GetDescription(driver);
            string newPricePerUnit = tMPageObj.GetPricePerUnit(driver);
            
            Assert.That(newCode == "Icsep2021", "code didn't match");
            Assert.That(newTypeCode == "T", "typecode didn't match");
            Assert.That(newDescription == "industry connect sep2021",
                "Actual Description and expected Description dont match");
            Assert.That(newPricePerUnit == "$2,021.00", "Actual priceperunit and priceperunit code dont match");
            
        }
    }
}