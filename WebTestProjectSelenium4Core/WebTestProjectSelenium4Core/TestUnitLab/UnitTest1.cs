using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.Network;

namespace WebTestProjectSelenium4Core.TestUnitLab
{
    public class Tests
    {
        protected DevToolsSession Session;
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            //Set ChromeDriver
            Driver = new ChromeDriver();

            //Get DevTools
            IDevTools devTools = Driver as IDevTools;

            //DevTools Session
            Session = devTools.CreateDevToolsSession();
        }

        [Test]
        public void NetworkInterception()
        {
            Session.Network.Enable(new EnableCommandSettings());

            Session.Network.SetBlockedURLs(new SetBlockedURLsCommandSettings()
            {
                Urls = new string[] { "*://*/*.css", "*://*/*.jpg", "*://*/*.png" }
            });

            Driver.Url = "http://www.executeautomation.com";

            Assert.Warn("sss");
        }
    }
}