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
    public class LoginPageTest : Base
    {

        [Test, Category("Smoke")]
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
        public void InvalidLoginTest()
        {
            LoginPage loginpage = new LoginPage(getDriver());
            loginpage.inValidvalidLogin();
        }


    }
}
