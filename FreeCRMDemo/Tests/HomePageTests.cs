using FreeCRMDemo.Pages;
using FreeCRMDemo.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IgnoreAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute;

namespace FreeCRMDemo.Tests
{
    [TestClass]
    //[Parallelizable(ParallelScope.Children)]
    public class HomePageTests : Base
    {

        [Test, Category("Regression")]
        public void AddCalenderEventTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewCalenderEvent();
            //homepage.logout();
        }


        [Test, Category("Regression")]
        public void AddContactTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            HomePage homepage = new HomePage(getDriver());
            loginpage.validLogin();
            Thread.Sleep(3000);
            homepage.addNewContact();
            //homepage.logout();
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
