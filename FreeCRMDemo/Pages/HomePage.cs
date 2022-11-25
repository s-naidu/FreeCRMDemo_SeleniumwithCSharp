using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.CacheStorage;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCRMDemo.Pages
{
    public class HomePage
    {
 

        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //common save and delete and text elements
        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-toolbar']/div[2]/div/button[3]/i")]
        private IWebElement commondeletebutton;

        [FindsBy(How = How.CssSelector, Using = "body > div.ui.page.modals.dimmer.transition.visible.active > div > div.actions > button.ui.red.button")]
        private IWebElement commonconfirmdeletebutton;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'No records found')]")]
        private IWebElement commonnorecordstext;
  
        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-toolbar']/div[2]/div/button[2]")]
        private IWebElement commonsavebutton;

        [FindsBy(How = How.Id, Using = "main-nav")]
        private IWebElement Leftmenubar;


        //Add calender section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[2]/button/i")]
        private IWebElement LeftmenubaraddcalenderEvent;
        
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement calenderEventname;

        [FindsBy(How = How.XPath, Using = "# dashboard-toolbar > div.ui.header.item.mb5.light-black")]
        private IWebElement calendertitle;

        //Add contact section elements
        [FindsBy(How = How.CssSelector, Using = "#main-nav > div:nth-child(3) > button > i")]
        private IWebElement Leftmenubaraddcontract;

        [FindsBy(How = How.Name, Using = "first_name")]
        private IWebElement firstname;
 
        [FindsBy(How = How.Name, Using = "last_name")]
        private IWebElement lastname;
 
        [FindsBy(How = How.XPath, Using = "//*[@id='top-header-menu']/div[2]/div[2]/div")]
        private IWebElement logoutheader;

        [FindsBy(How = How.CssSelector, Using = "#top-header-menu > div.right.menu > div.ui.buttons > div > div > a:nth-child(5) > span")]
        private IWebElement logoubutton;
 
        //Add company section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[4]/button/i")]
        private IWebElement Leftmenubaraddcompany;

        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement companyTitle;
 
        //Add Deal section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[5]/button/i")]
        private IWebElement Leftmenubaradddeal;

        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement dealtitle;


        //common method to click lefemenu
        public void clickLeftMenu()
        {
            Actions mousehover = new Actions(driver);
            mousehover.MoveToElement(Leftmenubar).Perform();

        }
        public void commonSaveButton()
        {
            this.commonsavebutton.Click();
        }

        public void clickdeleteandConfirmdelete()
        {
           this.commondeletebutton.Click();
            this.commonconfirmdeletebutton.Click();

        }

        public void VerifyNoRecords()
        {
            string text = this.commonnorecordstext.Text;
            Assert.That(text, Is.EqualTo("No records found"));
        }
        public void waitForvisibleDelete()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='dashboard-toolbar']/div[2]/div/button[3]/i")));
        }

        //Contact method
        public void addNewContact()
        {
            try
            {
                this.clickLeftMenu();
                Leftmenubaraddcontract.Click();
                firstname.SendKeys(ConfigurationManager.AppSettings["firstname"]);
                lastname.SendKeys(ConfigurationManager.AppSettings["lastname"]);
                this.commonSaveButton();
                this.waitForvisibleDelete();
                this.clickdeleteandConfirmdelete();
                Thread.Sleep(3000);
                this.VerifyNoRecords();
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }

        //Calender method
        public void addNewCalenderEvent()
        {
            try
            {
                this.clickLeftMenu();
                LeftmenubaraddcalenderEvent.Click();
                Thread.Sleep(3000);
                calenderEventname.SendKeys(ConfigurationManager.AppSettings["calenderEventname"]);
                this.commonSaveButton();
                this.waitForvisibleDelete();
                this.clickdeleteandConfirmdelete();
                string createeventtitle = driver.FindElement(By.XPath("//h3[contains(text(),'Events')]")).Text;
                Assert.That(createeventtitle, Is.EqualTo("Events"));
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }
        
        //company method
        public void addNewCompany()
        {
            try
            {
                this.clickLeftMenu();
                Leftmenubaraddcompany.Click();
                companyTitle.SendKeys(ConfigurationManager.AppSettings["companyname"]);
                this.commonSaveButton();
                this.waitForvisibleDelete();
                this.clickdeleteandConfirmdelete();
                Thread.Sleep(3000);
                this.VerifyNoRecords();
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }

        public void addNewDeal()
        {
            try
            {
                this.clickLeftMenu();
                Leftmenubaradddeal.Click();
                dealtitle.SendKeys(ConfigurationManager.AppSettings["dealtitle"]);
                this.commonSaveButton();
                this.waitForvisibleDelete();
                this.clickdeleteandConfirmdelete();
                Thread.Sleep(5000);
                this.VerifyNoRecords();
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }

        //public string Get8CharacterRandomString()
        //{
        //    string path = Path.GetRandomFileName();
        //    path = path.Replace(".", ""); // Remove period.
        //    return path.Substring(0, 8);  // Return 8 character string
        //}

        public LoginPage logout()
        {
            logoutheader.Click();
            logoubutton.Click();
            return new LoginPage(driver);
        }
        public void searchContact()
        {

        }

    }
}
