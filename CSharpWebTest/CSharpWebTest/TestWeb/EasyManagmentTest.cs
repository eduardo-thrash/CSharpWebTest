using CSharpWebTest.StepDefinitions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CSharpWebTest.TestWeb
{
    [TestFixture]
    public class EasyManagmentTest
    {
        private readonly EasyManagmentSteps emStep = new EasyManagmentSteps();

        private IWebDriver _driver;

        [Test]
        [Ignore("Waiting for Joe to fix his bugs", Until = "2020-04-12 09:40:00Z")]
        public void SuccessfulDiligenceOfClient()
        {
            emStep.GivenIHaveAccessToEasyManagmentPage(_driver);

            Thread.Sleep(6000);

            Assert.Warn("Warning message");

            Warn.Unless(2 + 2 == 5);

            Console.WriteLine("Si cumple la condición");
        }

        [SetUp]
        public void SetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            _driver = new ChromeDriver(chromeOptions);

            //_driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}