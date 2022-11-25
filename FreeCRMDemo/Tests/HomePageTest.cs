using FreeCRMDemo.Pages;
using FreeCRMDemo.Utilities;
using FreeCRMDemo.Utilities.ReportUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using IgnoreAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute;

namespace FreeCRMDemo.Tests
{
    //[TestFixture]
    [Parallelizable]
    public class HomePageTest : Base
    {

        [Test, Category("Regression")]
        public void AddCalenderEventTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewCalenderEvent();
        }

        [Test, Category("Regression")]
        public void AddContactTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewContact();

        }
        [Test, Category("Regression")]
        public void AddcompanyTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewCompany();
        }

        [Test, Category("Regression")]
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
