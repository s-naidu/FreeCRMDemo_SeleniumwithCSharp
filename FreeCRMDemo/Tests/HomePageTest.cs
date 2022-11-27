using FreeCRMDemo.Pages;
using FreeCRMDemo.Utilities;
using FreeCRMDemo.Utilities.ReportUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using IgnoreAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute;

namespace FreeCRMDemo.Tests
{
    [TestFixture]
    //[Parallelizable]
    public class HomePageTest : Base
    {

        [Test, Category("Regression")]
        public void AddCalenderEventTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.AddNewCalenderEvent();
        }

        [Test, Category("Regression")]
        public void AddContactTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.AddNewContact();

        }
        [Test, Category("Regression")]
        public void AddcompanyTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.AddNewCompany();
        }

        [Test, Category("Regression")]
        public void AddDealTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.AddNewDeal();
        }

        [Test, Category("Regression")]
        public void AddTaskTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.AddNewTask();
        }

        [Test, Category("Regression")]
        public void AddCaseTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.AddNewCase();
        }

        [Test, Category("Regression")]
        public void AddDocumentTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.AddNewDocument();
        }

    }
}
