using FreeCRMDemo.Pages;
using FreeCRMDemo.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

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
           
        }
        [Test, Category("Smoke")]
        public void InvalidLoginTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            loginpage.inValidvalidLogin();
        }
        [Test, Category("Regrission")]
        public void AddContactTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(5000);
            homepage.addNewContact();
            //homepage.logout();

        }

    }
}
