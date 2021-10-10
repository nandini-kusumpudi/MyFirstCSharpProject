using System;
using System.Threading;
using MyFirstCSharpProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyFirstCSharpProject
{
    class TMPage
    {
        public void createTM(IWebDriver driver)
        {
            //click on "create New" button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // select time from "Type code" dropdown list
            IWebElement typeCodeDropdown =
                driver.FindElement(
                    By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement selectTime = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            selectTime.Click();

            //Identify "code" textbox and input cod
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Icsep2021");

            //Identify "Description" textbox and input code
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("industry connect sep2021");

            //Identify "price" textbox and input code
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span")).Click();

            IWebElement pricePerUnit = driver.FindElement(By.Id("Price"));
            pricePerUnit.SendKeys("2021");

            //click on "save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            // Thread.Sleep(5000);
            Wait.WaitForElementToBeClickable(driver,"Xpath", "//*[@id='tmsGrid']/div[4]/a[4]", 10);
            
            //Assert that time record has been created
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            // Thread.Sleep(5000);
            Wait.WaitForElementToBeClickable(driver,"Xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 10);
            IWebElement timeRecord =
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));


            //Assert that timerecord has been edited
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton1.Click();


            // Assertion
            // Assert.That(newCode.Text == "Icsep2021", "Actual code and expected code dont match");
            // Assert.That(newTypeCode.Text == "T", "Actual typecode and expected typecode code dont match");
            // Assert.That(newDescription.Text == "industry connect sep2021",
            //     "Actual Description and expected Description dont match");
            // Assert.That(newPricePerUnit.Text == "$2021", "Actual priceperunit and priceperunit code dont match");

            ////option 1
            //Assert.That(timeRecord.Text == "Icsep2021", "Actual code and expected code dont match");

            //////option 2
            ////if (timeRecord.Text == "Icsep2021")
            ////{
            ////    Assert.Pass("Time record created successfully, test passed");
            ////}
            ////else
            ////{
            ////    Assert.Fail("Test failed.");
            ////}
        }

        public String GetCode(IWebDriver driver)
        {
            IWebElement newCode =
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public String GetTypeCode(IWebDriver driver)
        {
            IWebElement newTypeCode =
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return newTypeCode.Text;
        }
        
        public String GetDescription(IWebDriver driver)
        {
            IWebElement newDescription =
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }
        
        public String GetPricePerUnit(IWebDriver driver)
        {
            IWebElement newPricePerUnit =
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPricePerUnit.Text;
        }

        public void EditTM(IWebDriver driver)
        {
            //go to last page where we record create will be
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordCreated =
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "Icsep2021")
            {
                IWebElement editButton =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();

                // select time from "Type code" dropdown list
                IWebElement typeCodeDropdown1 =
                    driver.FindElement(
                        By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
                typeCodeDropdown1.Click();

                IWebElement selectTime = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
                selectTime.Click();

                // Edit  code
                IWebElement codeTextbox1 = driver.FindElement(By.Id("Code"));
                codeTextbox1.Clear();
                codeTextbox1.SendKeys("sep2021IC");

                //edit  description
                IWebElement description1 = driver.FindElement(By.Id("Description"));
                description1.Clear();
                description1.SendKeys("sep2021 industry connect");

                //edit PricePerUnit
                driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span")).Click();

                IWebElement PricePerUnit1 = driver.FindElement(By.Id("Price"));
                PricePerUnit1.Clear();

                driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span")).Click();

                PricePerUnit1 = driver.FindElement(By.Id("Price"));
                PricePerUnit1.SendKeys("123");

                //click sava button
                IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                saveButton.Click();

                //wait for 5second to go to next page
                Thread.Sleep(5000);

                //Assert that timerecord has been edited
                IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
                goToLastPageButton1.Click();

                IWebElement newCode1 =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                IWebElement newTypeCode1 =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
                IWebElement newDescription1 =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
                IWebElement newPricePerUnit1 =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

                // Assertion
                Assert.That(newCode1.Text == "sep2021IC", "Actual code and expected code dont match");
                Assert.That(newTypeCode1.Text == "T", "Actual typecode and expected typecode code dont match");
                Assert.That(newDescription1.Text == "sep2021 industry connect",
                    "Actual Description and expected Description dont match");
                Assert.That(newPricePerUnit1.Text == "$123", "Actual priceperunit and priceperunit code dont match");
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited.");
            }
        }

        public void DeletTM(IWebDriver driver)
        {
            //go to last page where edited record create will be
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordEdited =
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (findRecordEdited.Text == "sep2021IC")
            {
                // select delete button
                IWebElement deleteButton =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(5000);

                driver.SwitchTo().Alert().Accept();

                //Assert that time record has been deleted
                IWebElement goToLastPageButton3 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageButton3.Click();
                Thread.Sleep(3000);

                IWebElement editedCode =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                IWebElement editedTypeCode =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
                IWebElement editedDescription =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
                IWebElement editedPricePerUnit =
                    driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

                // Assertion
                Assert.That(editedCode.Text != "sep2021IC", "code record hasn't been deleted");
                Assert.That(editedTypeCode.Text != "T", "Typecode record hasn't been deleted");
                Assert.That(editedDescription.Text != "sep2021 industry connect",
                    "Description record hasn't been deleted");
                Assert.That(editedPricePerUnit.Text != "$123", "Priceperunit record hasn't been deleted");
            }
            else
            {
                Assert.Fail("record to be deleted hasn't been found. Record not deleted");
            }
        }
    }
}