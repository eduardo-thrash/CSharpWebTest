using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebActionsUtil;

namespace CSharpWebTest.StepDefinitions.EasyManagement
{
    [Binding]
    public class CommonSteps
    {
        private readonly UtilAction _util = new UtilAction();

        [Given(@"I have access to EasyManagement page")]
        public void GivenIHaveAccessToEasyManagementPage(IWebDriver driver)
        {
            _util.AccessPage(driver, "https://eduardo-thrash.github.io/EasyManagment/");
        }
    }
}