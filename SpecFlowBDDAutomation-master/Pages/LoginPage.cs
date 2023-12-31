﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SeleniumExtras.PageObjects;
using System.Xml;
using SpecFlowBDDAutomationFramework.ComponentHelper;
using SpecFlowBDDAutomationFramework.Settings;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Internal;

namespace SpecFlowBDDAutomationFramework.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            ObjectRepository.Driver = driver;   
        }
        By userName = By.XPath("//input[@Id='UserID']");
        By password = By.XPath("//input[@Id='Password']");
        By loginButton = By.XPath("//button[@type='submit']");
        By formsConfiguration = By.XPath("//a[contains(text(),'Forms Configuration')]");
        By newButton = By.XPath("//span[contains(text(),'New')]");
        By category = By.XPath("//select[@id='ProductCategoryId']");
        By processType = By.XPath("//select[@id='ProcessTypeId']");
        By activityName = By.XPath("//input[@Id='ActivityName']");
        By saveButton = By.XPath("//button[@name='assetcreate']");
        By successMessage = By.XPath("//label[contains(text(),'Created successfully')]");
        By closedPopup = By.XPath("//a[@id='closePopupNotificationView']");
        By userProfile = By.XPath("//a[@id='userProfileDropdown']");
        By logoutButton = By.XPath("//a[@id='btnSignout']");
        By logoutButtonYes = By.XPath("//button[contains(text(),'Yes')]");
        

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement myElement;

     
        public IWebElement category1 => driver.FindElement(By.XPath("//select[@id='ProductCategoryId']"));
        public IWebElement processType1 => driver.FindElement(By.XPath("//select[@id='ProcessTypeId']"));

        // public IWebElement password => driver.FindElement(By.Id("Password"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@type='submit']"));
      
        public void LogintoApp(string usernme,string pwd)
        {
            TextBoxHelper.TypeInTextBox(userName, usernme);
            TextBoxHelper.TypeInTextBox(password, pwd);
            ButtonHelper.ClickButton(loginButton);
        }
        public void createForm()
        {
            GenericHelper.WaitForWebElementInPage(formsConfiguration, TimeSpan.FromSeconds(30));
            LinkHelper.ClickLink(formsConfiguration);
            GenericHelper.WaitForWebElementInPage(newButton, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(newButton);
            GenericHelper.WaitForWebElementInPage(category, TimeSpan.FromSeconds(30));
            category1.Click();
            category1.SendKeys(Keys.Down);
            category1.SendKeys(Keys.Return);
            category1.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            processType1.Click();
            processType1.SendKeys(Keys.Down);
            processType1.SendKeys(Keys.Return);
            processType1.SendKeys(Keys.Enter);
           // ComboBoxHelper.SelectElementByValue(processType, "Scrap");
            TextBoxHelper.TypeInTextBox(activityName, "AGS_200062");
            ButtonHelper.ClickButton(saveButton);
            GenericHelper.WaitForWebElementInPage(successMessage, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(closedPopup);

        }
        public void LogOut()
        {
            ButtonHelper.ClickButton(userProfile);
            GenericHelper.WaitForWebElementInPage(logoutButton, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(logoutButton);
            GenericHelper.WaitForWebElementInPage(logoutButtonYes, TimeSpan.FromSeconds(30));
            ButtonHelper.ClickButton(logoutButtonYes);

            
        }

    }
}
