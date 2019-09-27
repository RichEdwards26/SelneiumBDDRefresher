using System;
using System.Collections.Generic;
using System.Text;
using BoDi;
using OpenQA.Selenium;
using SelneiumBDDRefresher.Data;

namespace SelneiumBDDRefresher.PageObjects
{
    public class SignUpPage : PageBase
    {
        private string pageUrlExt = "/register";
        public string pageUrl;
        private IWebDriver _driver;

        public SignUpPage(IWebDriver driver, IObjectContainer container)
        {
            _driver = driver;
            pageUrl = container.Resolve<TestEnv>().BaseUrl + pageUrlExt;
        }



        private IWebElement UsernameField => _driver.FindElement(By.CssSelector("input[placeholder='Username']"));
        private IWebElement EmailField => _driver.FindElement(By.CssSelector("input[placeholder='Email']"));
        private IWebElement PasswordField => _driver.FindElement(By.CssSelector("input[placeholder='Password']"));
        private IWebElement SignUpButton => _driver.FindElement(By.XPath("//button[contains(text(),'Sign up')]"));


        public void CompleteSignupForm(string username, string email, string password)
        {
            ClearAndSetField(UsernameField, username);
            ClearAndSetField(EmailField, email);
            ClearAndSetField(PasswordField, password);
            SignUpButton.Click();
        }

        public void GoToHere()
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }
    }       

}
