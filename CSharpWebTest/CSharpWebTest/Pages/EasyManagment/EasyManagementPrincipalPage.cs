using OpenQA.Selenium;

namespace CSharpWebTest.Pages.EasyManagement
{
    public static class EasyManagementPrincipalPage
    {
        public static By MenuToogle = By.XPath("//a[@class='menu-toggle rounded']");

        public static By ClientsOption = By.XPath("//a[@href='Clients.html']");

        public static By ProvidersOption = By.XPath("//a[@href='Providers.html.html']");
    }
}