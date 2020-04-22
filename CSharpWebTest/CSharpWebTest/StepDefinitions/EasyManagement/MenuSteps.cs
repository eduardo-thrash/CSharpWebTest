using CSharpWebTest.Pages.EasyManagement;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebActionsUtil;

namespace CSharpWebTest.StepDefinitions.EasyManagement
{
    [Binding]
    public class MenuSteps
    {
        private readonly UtilAction _util = new UtilAction();

        [When(@"I select principal menu")]
        public void WhenISelectPrincipalMenu(IWebDriver driver)
        {
            _util.Click(driver, EasyManagementPrincipalPage.MenuToogle, 20);
        }
    }
}