using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using BoDi;
using NUnit.Framework;
using System.IO;
using SelneiumBDDRefresher.Data;

namespace SelneiumBDDRefresher
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly IObjectContainer container;
        private TestEnv env = new TestEnv();
        public IWebDriver driver;
        public RemoteWebDriver remoteDriver;



        public Hooks (IObjectContainer container)
        {
            this.container = container;
        }

        //[BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver(Directory.GetCurrentDirectory());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(env.BaseUrl);

            container.RegisterInstanceAs(env);
            container.RegisterInstanceAs(driver);
        }

        [BeforeScenario]
        public void Remote_BeforeScenario()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("no-sandbox");
            
            Uri gridUri = new Uri("http://localhost:4444/wd/hub/");
            var chromeCaps = chromeOptions.ToCapabilities();
            driver = new RemoteWebDriver(gridUri, chromeCaps, TimeSpan.FromSeconds(60));


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(env.BaseUrl);

            container.RegisterInstanceAs(env);
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IWebDriver driver = container.Resolve<IWebDriver>();
            driver.Close();
        }
    }
}
