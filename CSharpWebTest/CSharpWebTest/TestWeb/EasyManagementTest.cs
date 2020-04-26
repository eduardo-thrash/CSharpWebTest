using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using CSharpWebTest.StepDefinitions.EasyManagement;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using WebActionsUtil;

namespace CSharpWebTest.TestWeb
{
    [TestFixture]
    public class EasyManagementTest
    {
        private readonly CommonSteps _comStep = new CommonSteps();
        private readonly MenuSteps _menStep = new MenuSteps();
        private readonly UtilAction _util = new UtilAction();

        private IWebDriver _driver;

        [Test]
        [Ignore("Waiting for Joe to fix his bugs", Until = "2020-04-12 09:40:00Z")]
        public void SuccessfulDiligenceOfClient()
        {
            _comStep.GivenIHaveAccessToEasyManagementPage(_driver);

            //Thread.Sleep(10000);

            //_driver.FindElement(By.XPath("//a[@class='menu-toggle rounded']")).Click();

            _menStep.WhenISelectPrincipalMenu(_driver);

            Thread.Sleep(6000);

            //Assert.Warn("Warning message");

            //Warn.Unless(2 + 2 == 5);

            //Console.WriteLine("Si cumple la condición");
        }

        [Test]
        public void CrushbankLaboratory()
        {
            _util.AccessPage(_driver, "http://qa.crushbank.com/");

            string connectWiseFormBase = "//div[contains(@ng-show,'ConnectWise')]";

            _util.Sendkeys(_driver, By.Id("1-email"), "emontenegroq@crushbank.com", 60);

            _util.Sendkeys(_driver, By.Name("password"), "Valhalla2010", 60);

            _util.Click(_driver, By.Name("submit"), 60);

            _util.Click(_driver, By.XPath("//div[@id='menu-navbar-hover']/img[@src='/images/menu-icon.png']"), 60);

            _util.Click(_driver, By.XPath("//div[@class='collapse navbar-collapse navbar-right']/ul/li/a[@href='/Admin']"), 60);

            _util.Click(_driver, By.XPath("//div[@class='col-md-2 sidebar']/ul/li/a[@href='/Admin/CompanyList']"), 60);

            CompanySearch(_driver);

            if (!ElementIsPresent(_driver, By.XPath("//form[@name='companyForm']//div[@ng-show,'model.DiscoveryConfig']"), 5))
            {
                var elementClass = _driver.FindElement(By.XPath("//form[@name='companyForm']//div[@ng-show='model.DiscoveryConfig']")).GetAttribute("class");

                if (!string.IsNullOrEmpty(elementClass))
                    _util.Click(_driver, By.XPath("//div[@ng-show='!model.DiscoveryConfig']/div/a[@ng-click='createNewWatsonIntegration(10)']"), 60);
            }

            _util.ClearBeforeSendkeys(_driver, By.XPath("//div[@ng-show='model.DiscoveryConfig']/div/input[@ng-model='model.DiscoveryConfig.EnvironmentId']"), "0000000000000000000000000000000000000", 60);

            _util.ClearBeforeSendkeys(_driver, By.XPath("//div[@ng-show='model.DiscoveryConfig']/div/input[@ng-model='model.DiscoveryConfig.CollectionId']"), "1111111111111111111111111111111111111", 60);

            _util.Click(_driver, By.XPath("//div[@ng-show='model.DiscoveryConfig']/div/span[contains(@class,'label label-success import-status import-status-activate')]"), 60);

            _util.Click(_driver, By.XPath("//button[@ng-click='showModal()']"));

            _util.Click(_driver, By.XPath("//div[@handle='integrationModal']//img[@ng-src='/images/logos/integrations/connectwise.png']"));

            _util.Click(_driver, By.XPath(String.Format("{0}//span[contains(@class,'label label-success import-status import-status-activate')]", connectWiseFormBase)));

            _util.Sendkeys(_driver, By.XPath(String.Format("{0}//input[@ng-model='companyIntegration.Integration.Name']", connectWiseFormBase)), "CW Integration SP19-APR20");

            _util.Sendkeys(_driver, By.XPath(String.Format("{0}//input[@ng-model='companyIntegration.Configuration.APIKey']", connectWiseFormBase)), "dHJhaW5pbmcraTJTOTVLakVPY3ppb2tLSzpNejBoZlhST2hScHdJaXFp");

            _util.Sendkeys(_driver, By.XPath(String.Format("{0}//input[@ng-model='companyIntegration.Configuration.Site']", connectWiseFormBase)), "connect.chipstechnologygroup.com");

            SelectItemTypes(_driver, "Configurations,Configuration Documents,Tickets", By.XPath(String.Format("{0}//div[@id='importTypes']", connectWiseFormBase)), By.XPath("//div[@ng-show='importTypes']/div/input[@type='checkbox']"), "//div[@ng-show='importTypes']/div[{0}]");

            SelectItemTypes(_driver, ",", By.Id("ticketDetails"), By.XPath("//div[@ng-show='ticketDetails']/div/input[@type='checkbox']"), "(//div[@ng-show='ticketDetails']/div[@class='ng-binding ng-scope'])[{0}]");

            SelectItemTypes(_driver, "Alerts,Dispatch,Fast Response,Projects - BI,Short Term Fix,Rampart America,Backup", By.Id("serviceBoard"), By.XPath("//div[@ng-show='serviceBoard']/div/div[@ng-repeat='x in companyIntegration.Configuration.ServiceBoards | filter: { Inactive: false }']/input[@type='checkbox']"), "//div[@ng-show='serviceBoard']/div/div[{0}]");

            SelectItemTypes(_driver, "YPO", By.Id("companyTypes"), By.XPath("//div[@ng-show='companyTypes']/div[@ng-repeat='x in companyIntegration.Configuration.CompanyTypes']/input[@type='checkbox']"), "(//div[@ng-show='companyTypes']/div[@class='ng-binding ng-scope'])[{0}]");

            SelectItemTypes(_driver, "Active", By.Id("companyStatus"), By.XPath("//div[@ng-show='companyStatus']/div[@ng-repeat='x in companyIntegration.Configuration.CompanyStatuses']/input[@type='checkbox']"), "(//div[@ng-show='companyStatus']/div[@class='ng-binding ng-scope'])[{0}]");

            _util.SelectByText(_driver, By.XPath(String.Format("{0}//select[@ng-model='companyIntegration.Configuration.HistoricalDataCutoffValue']", connectWiseFormBase)), "6", 60);

            _util.SelectByValue(_driver, By.XPath(String.Format("{0}//select[@ng-model='companyIntegration.Configuration.HistoricalDataCutoffUnit']", connectWiseFormBase)), String.Format("string:{0}", "month"), 60);

            Thread.Sleep(1);

            Thread.Sleep(1);

            Thread.Sleep(1);

            Thread.Sleep(1);

            Thread.Sleep(1);
        }

        [SetUp]
        public void SetUp()
        {
            //ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");
            //_driver = new ChromeDriver(chromeOptions);

            _driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        public bool CompanySearch(IWebDriver companyDriver)
        {
            var companyName = "Company SP20 APR24";

            bool companyFind = false;

            var companiesListIndex = 0;

            _util.WaitElement(_driver, By.XPath("//table[@st-safe-src='model.Companies']/tbody/tr[@ng-repeat='row in displayedCollection']/td/button[@ng-click='editCompany(row)']"), 20, 2);

            IList<IWebElement> companiesCollection = companyDriver.FindElements(By.XPath("//table[@st-safe-src='model.Companies']/tbody/tr[@ng-repeat='row in displayedCollection']/td/button[@ng-click='editCompany(row)']"));

            foreach (var company in companiesCollection)
            {
                companiesListIndex++;

                IList<IWebElement> rowsCompaniesList = companyDriver.FindElements(By.XPath("//tr[" + companiesListIndex + "]/td[@class='ng-binding']"));

                foreach (var rowCompany in rowsCompaniesList)
                {
                    var listCompanyName = rowCompany.Text;

                    if (listCompanyName == companyName)
                    {
                        company.Click();

                        companyFind = true;

                        break;
                    }
                }

                if (companyFind)
                    break;
            }

            return companyFind;
        }

        private void SelectItemTypes(IWebDriver driverItemTypes, string keyConfig, By itemTitle, By checkboxItem, string itemWithIndex)
        {
            _util.Click(driverItemTypes, itemTitle);

            Thread.Sleep(2000);

            IList<IWebElement> itemsList = _driver.FindElements(checkboxItem);

            if (string.IsNullOrEmpty(keyConfig))
            {
                foreach (var item in itemsList)
                {
                    item.Click();
                }
            }
            else
            {
                string[] words = keyConfig.Split(',');

                var countWords = 0;

                var itemsCount = 0;

                foreach (var item in itemsList)
                {
                    itemsCount++;

                    var text = _driver.FindElement(By.XPath(String.Format(itemWithIndex, itemsCount))).Text;

                    var result = from w in words
                                 where w == text
                                 select new { wResult = w };

                    if (result.Any())
                    {
                        item.Click();
                        countWords++;
                    }

                    if (countWords >= words.Count())
                    {
                        break;
                    }
                }
            }

            Thread.Sleep(1000);
        }

        public bool ElementIsPresent(IWebDriver driverElement, By elementWait, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driverElement, TimeSpan.FromSeconds(seconds));

                wait.Until(drv => drv.FindElement(elementWait).Displayed);

                wait.Until(drv => drv.FindElement(elementWait).Enabled);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}