using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CSharpWebTest.StepDefinitions
{
    [Binding]
    public class EasyManagmentSteps
    {
        private readonly UtilAction.UtilAction _util = new UtilAction.UtilAction();

        [Given(@"I have access to EasyManagment page")]
        public void GivenIHaveAccessToEasyManagmentPage(IWebDriver driver)
        {
            _util.AccessPage(driver, "https://eduardo-thrash.github.io/EasyManagment/");
        }
    }
}