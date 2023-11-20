using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowBDDAutomationFramework.ComponentHelper;
using SpecFlowBDDAutomationFramework.Pages;
using SpecFlowBDDAutomationFramework.Settings;
using SpecFlowBDDAutomationFramework.Interfaces;
using Excel.Log;
using System.Configuration;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;
using SpecFlowBDDAutomationFramework.Configuration;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace SpecFlowBDDAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class LoginPageSteps
    {
        private AppiumDriver<AndroidElement> _driver;
        readonly TestDriver driver;
        LoginPage loginPage;
       // IConfig Config;
        ResultPage resultPage;
        AppConfigReader appConfigReader;
        public LoginPageSteps()
        {
            driver = (TestDriver)ScenarioContext.Current["driver"];
        }
        public LoginPageSteps(IWebDriver driver)
        {
            
            loginPage = new LoginPage(_driver);
            appConfigReader = new AppConfigReader();

        }

        [Given(@"I Enter the Voltas Url")]
        public void GivenIEnterTheVoltasUrl()
        {
           
            // driver.Url = "https://vserveq.voltasworld.com/iams";
            NavigationHelper.NavigateToUrl(appConfigReader.GetWebsite());
           // driver.Url = ConfigurationManager.AppSettings["Website"];
            Thread.Sleep(4000);
        }


        [Given(@"I Login to Application")]
        public void GivenILoginToApplication()
        {  
            loginPage.LogintoApp(appConfigReader.GetUsername(), appConfigReader.GetPassword());
            Thread.Sleep(4000);
        }

        [When(@"Create form")]
        public void WhenCreateform()
        {
            loginPage.createForm();
            Thread.Sleep(4000);
        }

        [Then(@"Logout from App")]
        public void ThenLogoutFromApp()
        {
            loginPage.LogOut();
        }


    }
}