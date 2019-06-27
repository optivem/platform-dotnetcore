﻿using Optivem.Framework.Test.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class SauceDemoApp : TestPageObject
    {
        public SauceDemoApp(TestDriver driver)
            : base(driver)
        {
        }

        public SauceDemoLoginPage NavigateToLoginScreen()
        {
            return SauceDemoLoginPage.Open(Driver);
        }

        public void Login(string userName, string password)
        {
            var loginScreen = NavigateToLoginScreen();

        }

        public SauceDemoLoginPage LoginScreen => new SauceDemoLoginPage(Driver);

        public SauceDemoInventoryPage InventoryScreen => new SauceDemoInventoryPage(Driver);
    }
}
