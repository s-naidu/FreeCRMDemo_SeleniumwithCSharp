using System;
using System.Configuration;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FreeCRMDemo.Utilities;
using FreeCRMDemo.Utilities.ReportUtil;
using NPOI.XWPF.UserModel;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace FreeCRMDemo.Utilities
{

    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;
        string browserName;

        [OneTimeSetUp]
        public void GlobalSetup()

        {
            ExtentTestManager.CreateParentTest(GetType().Name);
        }

        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void LaunchBrowser()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
           //test = ExtentTestManager.CreateParentTest(GetType().Name);
           
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            //fetching specified browser details from app config file
            InitBrowser(browserName);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            //fetching test url details from app config file
            driver.Value.Url = ConfigurationManager.AppSettings["Url"];

        }
        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    //Handling InsecureCertificates errors
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AcceptInsecureCertificates = true;
                    driver.Value = new FirefoxDriver(firefoxOptions);
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;

                default:
                    Assert.Fail("Invalid browser");
                    break;

            }
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentService.GetExtent().Flush();
        }

        [TearDown]
        public void AfterTest()

        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                //var stackTrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                        ? ""
                        : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);

                var stackMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                        ? ""
                        : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
                switch (status)
                {
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errorMessage);
                        ReportLog.Fail(stackMessage);
                        ReportLog.Fail("Screenshot", captureScreenShot(driver.Value,TestContext.CurrentContext.Test.Name));
                        break;
                    case TestStatus.Skipped:
                        ReportLog.Skip("Test Failed");
                        break;
                    case TestStatus.Passed:
                        ReportLog.Pass("Test Passed");
                        break;
                    default:
                        break;
                }

                //DateTime time = DateTime.Now;
                //String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

                //if (status == TestStatus.Failed)
                //{

                //    test.Fail("Test failed", captureScreenShot(driver.Value, fileName));
                //    test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
                //}
                //else if (status == TestStatus.Passed)
                //{

                //}

            }
            catch (Exception e)
            {

                throw new Exception("Exception: " + e);
            }
            finally
            {
                driver.Value.Quit();
            }
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

        {
            //ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }

    }
}
