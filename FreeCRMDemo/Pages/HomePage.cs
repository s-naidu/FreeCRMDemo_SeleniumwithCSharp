using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Configuration;

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
        private readonly IWebElement commondeletebutton;

        [FindsBy(How = How.CssSelector, Using = "body > div.ui.page.modals.dimmer.transition.visible.active > div > div.actions > button.ui.red.button")]
        private readonly IWebElement commonconfirmdeletebutton;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'No records found')]")]
        private readonly IWebElement commonnorecordstext;
  
        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-toolbar']/div[2]/div/button[2]")]
        private readonly IWebElement commonsavebutton;

        [FindsBy(How = How.Id, Using = "main-nav")]
        private readonly IWebElement Leftmenubar;

        //Add calender section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[2]/button/i")]
        private readonly IWebElement LeftmenubaraddcalenderEvent;
        
        [FindsBy(How = How.Name, Using = "title")]
        private readonly IWebElement calenderEventname;

        [FindsBy(How = How.XPath, Using = "# dashboard-toolbar > div.ui.header.item.mb5.light-black")]
        private readonly IWebElement calendertitle;

        //Add contact section elements
        [FindsBy(How = How.CssSelector, Using = "#main-nav > div:nth-child(3) > button > i")]
        private readonly IWebElement Leftmenubaraddcontract;

        [FindsBy(How = How.Name, Using = "first_name")]
        private readonly IWebElement firstname;
 
        [FindsBy(How = How.Name, Using = "last_name")]
        private readonly IWebElement lastname;
 
        [FindsBy(How = How.XPath, Using = "//*[@id='top-header-menu']/div[2]/div[2]/div")]
        private readonly IWebElement logoutheader;

        [FindsBy(How = How.CssSelector, Using = "#top-header-menu > div.right.menu > div.ui.buttons > div > div > a:nth-child(5) > span")]
        private readonly IWebElement logoubutton;
 
        //Add company section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[4]/button/i")]
        private readonly IWebElement Leftmenubaraddcompany;

        [FindsBy(How = How.Name, Using = "name")]
        private readonly IWebElement companyTitle;
 
        //Add Deal section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[5]/button/i")]
        private IWebElement Leftmenubaradddeal;

        [FindsBy(How = How.Name, Using = "title")]
        private readonly IWebElement dealtitle;

        //Add Task section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[6]/button/i")]
        private IWebElement Leftmenubaraddtask;

        [FindsBy(How = How.Name, Using = "title")]
        private readonly IWebElement tasktitle;

        //Add Case section elements
         [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[7]/button/i")]
        private readonly IWebElement Leftmenubaraddcase;

        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-toolbar']/div[2]/div/button[4]/i")]
        private readonly IWebElement casedeletebutton;
        

        [FindsBy(How = How.Name, Using = "title")]
        private readonly IWebElement casetitle;

        //Add Document section elements
        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[9]/button/i")]
        private readonly IWebElement Leftmenubaradddocument;

        [FindsBy(How = How.Name, Using = "title")]
        private readonly IWebElement documenttitle;

        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-toolbar']/div[2]/div/button[3]/i")]
        private readonly IWebElement deletedocumenttitle;
        
        [FindsBy(How = How.CssSelector, Using = "body > div.ui.page.modals.dimmer.transition.visible.active > div > div.actions > button.ui.red.button")]
        private readonly IWebElement confirmdeletedocumenttitle;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'No files under this folder.')]")]
        private readonly IWebElement nodocumentrecords;



        //common method to click lefemenu
        public void ClickLeftMenu()
        {
            Actions mousehover = new Actions(driver);
            mousehover.MoveToElement(Leftmenubar).Perform();
            Thread.Sleep(5000);
        }
        public void CommonSaveButton()
        {
            this.commonsavebutton.Click();
        }

        public void ClickdeleteandConfirmdelete()
        {
           this.commondeletebutton.Click();
            this.commonconfirmdeletebutton.Click();

        }

        public void VerifyNoRecords()
        {
            string text = this.commonnorecordstext.Text;
            Assert.That(text, Is.EqualTo("No records found"));
        }
        public void WaitForvisibleDelete()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='dashboard-toolbar']/div[2]/div/button[3]/i")));
        }                                                                                          

        //Contact method
        public void AddNewContact()
        {
            try
            {
                this.ClickLeftMenu();
                Leftmenubaraddcontract.Click();
                firstname.SendKeys(ConfigurationManager.AppSettings["firstname"]);
                lastname.SendKeys(ConfigurationManager.AppSettings["lastname"]);
                this.CommonSaveButton();
                this.WaitForvisibleDelete();
                this.ClickdeleteandConfirmdelete();
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
        public void AddNewCalenderEvent()
        {
            try
            {
                this.ClickLeftMenu();
                LeftmenubaraddcalenderEvent.Click();
                Thread.Sleep(3000);
                calenderEventname.SendKeys(ConfigurationManager.AppSettings["calenderEventname"]);
                this.CommonSaveButton();
                this.WaitForvisibleDelete();
                this.ClickdeleteandConfirmdelete();
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
        public void AddNewCompany()
        {
            try
            {
                this.ClickLeftMenu();
                Leftmenubaraddcompany.Click();
                companyTitle.SendKeys(ConfigurationManager.AppSettings["companyname"]);
                this.CommonSaveButton();
                this.WaitForvisibleDelete();
                this.ClickdeleteandConfirmdelete();
                Thread.Sleep(3000);
                this.VerifyNoRecords();
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }
        public void AddNewDeal()
        {
            try
            {
                this.ClickLeftMenu();
                Leftmenubaradddeal.Click();
                dealtitle.SendKeys(ConfigurationManager.AppSettings["dealtitle"]);
                this.CommonSaveButton();
                this.WaitForvisibleDelete();
                this.ClickdeleteandConfirmdelete();
                Thread.Sleep(5000);
                this.VerifyNoRecords();
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }
        public void AddNewTask()
        {
            try
            {
                this.ClickLeftMenu();
                Leftmenubaraddtask.Click();
                tasktitle.SendKeys(ConfigurationManager.AppSettings["tasktitle"]);
                this.CommonSaveButton();
                casedeletebutton.Click();
                commonconfirmdeletebutton.Click();
                Thread.Sleep(5000);
                this.VerifyNoRecords();
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }
        public void AddNewCase()
        {
            try
            {
                this.ClickLeftMenu();
                Leftmenubaraddcase.Click();
                casetitle.SendKeys(ConfigurationManager.AppSettings["casetitle"]);
                this.CommonSaveButton();
                this.WaitForvisibleDelete();
                casedeletebutton.Click();
                commonconfirmdeletebutton.Click();
                Thread.Sleep(5000);
                this.VerifyNoRecords();
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

        }

        public void AddNewDocument()
        {
            try
            {
                this.ClickLeftMenu();
                Leftmenubaradddocument.Click();
                documenttitle.SendKeys(ConfigurationManager.AppSettings["documenttitle"]);
                this.CommonSaveButton();
                this.WaitForvisibleDelete();
                this.ClickdeleteandConfirmdelete();
                Thread.Sleep(5000);
                
                string text = this.nodocumentrecords.Text;
                Assert.That(text, Is.EqualTo("No files under this folder."));
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

        public LoginPage Logout()
        {
            logoutheader.Click();
            logoubutton.Click();
            return new LoginPage(driver);
        }
        public static void SearchContact()
        {

        }

    }
}
