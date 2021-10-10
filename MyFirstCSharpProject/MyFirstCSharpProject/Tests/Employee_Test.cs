using System;
using MyFirstCSharpProject.pages;
using MyFirstCSharpProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace MyFirstCSharpProject.Tests
{
    [TestFixture]
    [Parallelizable]
    class EmployeeTest : CommonDriver
    {
        [Test, Order(1), Description(" check if user is able to create Employee time record with valid data")]
        public void CreateEmployeeTests()
        {
            //home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);

            //TMpage object initialization and definition
            EmployeesPage employeeObj = new EmployeesPage();
            employeeObj.CreateEmployee(driver);
        }

        [Test, Order(2), Description(" check if user is able to edit Employee time record with valid data")]
        public void EditEmployeeTests()
        {
            //home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);

            // edit time
            EmployeesPage employeeObj = new EmployeesPage();
            employeeObj.EditEmployee(driver);
        }

        [Test, Order(3), Description(" check if user is able to delete Employee time record")]
        public void DeleteEmployeeTests()
        {
            //home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);

            //delet time
            EmployeesPage employeesObj = new EmployeesPage();
            employeesObj.DeleteEmployee(driver);
        }
    }
}
//EmployeesPage EmployeePageObj = new EmployeesPage();
//EmployeePageObj.createEmployee(driver);