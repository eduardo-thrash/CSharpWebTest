# CSharpWebTest
Usage methods for actions on web parts using Selenium API. Methods with locator parameterization, explicit waits and WebDriver.

## AccessPage method: 
Method to access a web page through a URL
### parameters:

| Parameters | Description | Required
| ------ | ------ | ------ |
| driverUrl | Declared controller type IWebDriver | Yes
| Url | Website URL | Yes
| maximize | Option to maximize or not browser window | No

##### Example:
- `_util.AccessPage(driver, "https://eduardo-thrash.github.io/EasyManagment/");`
- `_util.AccessPage(driver, "https://eduardo-thrash.github.io/EasyManagment/" true);`
