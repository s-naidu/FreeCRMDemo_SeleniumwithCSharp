using FreeCRMDemo.Pages;
using FreeCRMDemo.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IgnoreAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute;

namespace FreeCRMDemo.Tests
{
    [TestClass]
    //[Parallelizable(ParallelScope.Children)]
    public class LoginPageTests : Base
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
