using AngleSharp.Common;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCRMDemo.Pages
{
    public class LoginPage
    {
        //Pageobject factory
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement loginemailid;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement loginpassword;

        [FindsBy(How = How.CssSelector, Using = ".button")]
        private IWebElement loginbutton;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='ui']/div/div/form/div/div[3]/div")]
        private IWebElement errorMessage;
 
        public HomePage validLogin()
        {
            loginemailid.SendKeys(ConfigurationManager.AppSettings["loginemailid"]);
            loginpassword.SendKeys(ConfigurationManager.AppSettings["loginpassword"]);
            loginbutton.Click();
            return new HomePage(driver);
        }

        public void inValidvalidLogin()
        {
            loginemailid.SendKeys(ConfigurationManager.AppSettings["invalidloginemailid"]);
            loginpassword.SendKeys(ConfigurationManager.AppSettings["invalidloginpassword"]);
            loginbutton.Click();
            String errorMessage = driver.FindElement(By.XPath("//*[@id='ui']/div/div/form/div/div[3]/div")).Text;
            Assert.That(errorMessage, Is.EqualTo("Something went wrong..."));
        }
        public void verifyTitle()
        {
            String logotext = driver.FindElement(By.XPath("//*[@id='top-header-menu']/div[2]/span[2]/a")).Text;
            Assert.That(logotext, Is.EqualTo("Free account"));

        }

    }
}
