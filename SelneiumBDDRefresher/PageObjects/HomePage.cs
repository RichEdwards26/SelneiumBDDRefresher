using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Protractor;

namespace SelneiumBDDRefresher.PageObjects
{
    public class HomePage
    {
        private IWebDriver _driver;
        private NgWebDriver _ngWebDriver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _ngWebDriver = new NgWebDriver(driver);
        }

        //ul[style = 'display: inherit;']  = which header is dispalyed
        public IWebElement SignUpLink => _driver.FindElement(By.CssSelector("ul[style='display: inherit;'] a[ui-sref='app.register']"));

        public IWebElement UsernameLink(string username) => _driver.FindElement(By.CssSelector($"ul[style='display: inherit;'] a[href='#/@{username}']"));


        public bool SignUpLinkIsDisplayed()
        {
            _ngWebDriver.WaitForAngular();

            try
            {
                return SignUpLink.Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }


        public bool UsernameLinkIsDisplayed(string username)
        {
            try
            {
                return UsernameLink(username).Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

    }
}
