using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;





namespace MyFirstCSharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // open chrome browser
            IWebDriver driver = new ChromeDriver();

            // launch turn up portal and maximize window∑
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();

            // indetify the username textbox enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // identify password textbox enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // identify login button and click
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            // check if user has logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in successfully, test passed.");
            }
            else
            {
                Console.WriteLine("Login failed, test failed.");
            }

            //click on administration dropdown
            IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            Thread.Sleep(3000);
            administration.Click();

            //select time & material from dropdown list
            IWebElement TMdropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TMdropdown.Click();


            //click on "create New" button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // select time from "Type code" dropdown list
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
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

            IWebElement PricePerUnit = driver.FindElement(By.Id("Price"));
            PricePerUnit.SendKeys("2021");

            //click on "save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            //Assert that time record has been created
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            Thread.Sleep(5000);
            IWebElement timeRecord =driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if(timeRecord.Text == "Icsep2021")
            {
                Console.WriteLine("Time record created successfully, test passed");
            }
            else
            {
                Console.WriteLine("Test failed.");
            }


            // select edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            

            // Edit  code
            codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("sep2021IC");

            //edit  description
            description = driver.FindElement(By.Id("Description"));
            description.Clear();
            description.SendKeys("sep2021 industry connect");

            //edit PricePerUnit
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span")).Click();

            PricePerUnit = driver.FindElement(By.Id("Price"));
            PricePerUnit.Clear();

            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span")).Click();

            PricePerUnit = driver.FindElement(By.Id("Price"));
            PricePerUnit.SendKeys("123");

            //click sava button
            saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //wait for 5second to go to next page
            Thread.Sleep(5000);

            //After the edited that time record has been created
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();


            Thread.Sleep(5000);
            timeRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (timeRecord.Text == "sep2021IC")
            {
                Console.WriteLine("Time record edited successfully, test passed");
            }
            else
            {
                Console.WriteLine("Test failed.");
            }

            
            IWebElement lastRow = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]"));
            string lastRowId = lastRow.GetAttribute("data-uid");

            // select delet button
            IWebElement deletButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deletButton.Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);

            lastRow = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]"));
            if (lastRowId != lastRow.GetAttribute("data-uid"))
            {
                Console.WriteLine("Time record deleted successfully, test passed");
            }
            else
            {
                Console.WriteLine("Test failed.");
            }
        }
    }
}