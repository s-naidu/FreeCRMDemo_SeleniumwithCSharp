using FreeCRMDemo.Pages;
using FreeCRMDemo.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using IgnoreAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute;

namespace FreeCRMDemo.Tests
{   [TestClass]
    //[Parallelizable(ParallelScope.Children)]
    public class Tests : Base
    {

        [Test,Category("Smoke")]
        public void ValidLoginTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            loginpage.verifyTitle();
            homepage.logout();
            Thread.Sleep(3000);
           
        }
        [Test, Category("Smoke")]
        //[Ignore]
        public void InvalidLoginTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            loginpage.inValidvalidLogin();
        }
        
        [Test, Category("Regrission")]
        public void AddCalenderEventTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewCalenderEvent();
            //homepage.logout();
        }


        [Test, Category("Regrission")]
        public void AddContactTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewContact();
            //homepage.logout();
        }
        [Test, Category("Regrission")]
        public void AddcompanyTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
           Thread.Sleep(3000);
            homepage.addNewCompany();
        }

        [Test, Category("Regrission")]
        public void AddDealTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewDeal();
        }

    }
}
