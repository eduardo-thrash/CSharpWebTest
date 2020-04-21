using OpenQA.Selenium;

namespace CSharpWebTest.Pages.EasyManagment
{
    public class EasyManagmentPrincipalPage
    {
        public By MenuToogle = By.XPath("a[@class='menu-toggle rounded']");

        public By ClientsOption = By.XPath("a[@href='Clients.html']");

        public By ProvidersOption = By.XPath("a[@href='Providers.html.html']");
    }
}