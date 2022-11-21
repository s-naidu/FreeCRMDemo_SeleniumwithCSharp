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

        [FindsBy(How = How.CssSelector, Using = "#main-nav > div:nth-child(3) > button > i")]
        private IWebElement Leftmenubaraddcontract;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-nav']/div[3]/a/span")]
        private IWebElement Leftmenubarcontract;

        [FindsBy(How = How.Name, Using = "first_name")]
        private IWebElement firstname;
        [FindsBy(How = How.Name, Using = "last_name")]
        private IWebElement lastname;
        [FindsBy(How = How.CssSelector, Using = "#dashboard-toolbar > div.ui.right.secondary.pointing.menu.toolbar-container > div > button.ui.linkedin.button")]
        private IWebElement savebutton;


        [FindsBy(How = How.XPath, Using = "//*[@id='top-header-menu']/div[2]/div[2]/div")]
        private IWebElement logoutheader;

        [FindsBy(How = How.CssSelector, Using = "#top-header-menu > div.right.menu > div.ui.buttons > div > div > a:nth-child(5) > span")]
        private IWebElement logoubutton;
        [FindsBy(How = How.XPath, Using = "//*[@id='dashboard-toolbar']")]
        private IWebElement dashboard;

        [FindsBy(How = How.CssSelector, Using = "div.ui.fluid.container div.ui.fluid.container:nth-child(2) div.ui.fluid.container:nth-child(2) div.ui.fluid.container div.ui.secondary.pointing.menu.header-title.page-header:nth-child(1) div.ui.right.secondary.pointing.menu.toolbar-container:nth-child(2) div.item.view-page-toolbar button.ui.button.icon:nth-child(14) > i.trash.icon")]
        private IWebElement clickdeleteicon;

        [FindsBy(How = How.CssSelector, Using = "body > div.ui.page.modals.dimmer.transition.visible.active > div > div.actions > button.ui.red.button")]
        private IWebElement deleteconfirm;

        [FindsBy(How = How.CssSelector, Using = "div.ui.fluid.container div.ui.fluid.container:nth-child(2) div.ui.fluid.container:nth-child(2) div.ui.fluid.container div.ui.fluid.container.main-content:nth-child(2) div.table-wrapper table.ui.celled.sortable.striped.table.custom-grid tbody:nth-child(2) tr:nth-child(1) td:nth-child(1) div.ui.fitted.read-only.checkbox > label:nth-child(2)")]
        private IWebElement selectContact;


        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/div[2]/div/table/tbody/tr/td[8]/div/button/i")]
        private IWebElement deleteContact;
        [FindsBy(How = How.CssSelector, Using = "body > div.ui.page.modals.dimmer.transition.visible.active > div > div.actions > button:nth-child(2)")]
        private IWebElement confirmdeleteContact;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'No records found')]")]
        private IWebElement nocontacts;


        public void addNewContact()
        {
            try
            {
                Actions mousehover = new Actions(driver);
                mousehover.MoveToElement(Leftmenubaraddcontract).Perform();
                Leftmenubaraddcontract.Click();
                firstname.SendKeys(ConfigurationManager.AppSettings["firstname"]);
                lastname.SendKeys(ConfigurationManager.AppSettings["lastname"]);
                savebutton.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div.ui.fluid.container div.ui.fluid.container:nth-child(2) div.ui.fluid.container:nth-child(2) div.ui.fluid.container div.ui.secondary.pointing.menu.header-title.page-header:nth-child(1) div.ui.right.secondary.pointing.menu.toolbar-container:nth-child(2) div.item.view-page-toolbar button.ui.button.icon:nth-child(14) > i.trash.icon")));
                string actualvalue = driver.FindElement(By.CssSelector("div.ui.fluid.container div.ui.fluid.container:nth-child(2) div.ui.fluid.container:nth-child(2) div.ui.fluid.container div.ui.secondary.pointing.menu.header-title.page-header:nth-child(1) > div.ui.header.item.mb5.light-black:nth-child(1)")).Text;
                Assert.That(actualvalue, Is.EqualTo("firstname lastname"));
                TestContext.Progress.WriteLine(actualvalue);

                //dashboard.Click();
                //Thread.Sleep(5000);
                // selectContact.Click();
                clickdeleteicon.Click();
                deleteconfirm.Click();
                string nocontracsresults = driver.FindElement(By.XPath("//p[contains(text(),'No records found')]")).Text;
                Assert.That(nocontracsresults, Is.EqualTo("No records found"));
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e.StackTrace);
                throw;
            }

            

        }

        public string Get8CharacterRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path.Substring(0, 8);  // Return 8 character string
        }

        public LoginPage logout()
        {
            logoutheader.Click();
            logoubutton.Click();
            return new LoginPage(driver);
        }

         //public void waitfordealsboxtoload()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main-content']/div/div/div[2]/div/div[2]")));

        //}

        public void searchContact()
        {

        }

    }
}
