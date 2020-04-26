using System;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebActionsUtil
{
    /// <summary>
    ///
    /// </summary>
    public class UtilAction
    {
        /// <summary>
        /// Method to access a web page through a URL
        /// </summary>
        /// <param name="driverUrl">Declared controller type IWebDriver</param>
        /// <param name="url">Website URL</param>
        /// <param name="maximize">Option to maximize or not browser window</param>
        public void AccessPage(IWebDriver driverUrl, string url, bool maximize = true)
        {
            if (maximize)
                driverUrl.Manage().Window.Maximize();

            driverUrl.Navigate().GoToUrl(url);
        }

        #region Basic

        /// <summary>
        /// Method to clear information from an input type field
        /// /// </summary>
        /// <param name="driverClear"> Navigator controller </param>
        /// <param name="elementClear"> Page input type element on the that it field clear</param>
        /// <param name="timeout"> Wait for generate error </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void Clear(IWebDriver driverClear, By elementClear, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitClear = new WebDriverWait(driverClear, TimeSpan.FromSeconds(timeout));

                    waitClear.Until(drv => drv.FindElement(elementClear).Displayed);

                    waitClear.Until(drv => drv.FindElement(elementClear).Enabled);

                    var action = new Actions(driverClear);

                    action.MoveToElement(driverClear.FindElement(elementClear));

                    action.Release().Build().Perform();

                    driverClear.FindElement(elementClear).Clear();

                    statement = true;
                }
                catch (Exception ex)
                {
                    if (triedCount >= tried) throw new Exception(ex.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for apply click on element.
        /// </summary>
        /// <param name="driverClick"> Navigator controller </param>
        /// <param name="elementClick"> Page element on the that make click it </param>
        /// <param name="timeout"> Wait for generate error </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void Click(IWebDriver driverClick, By elementClick, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitClick = new WebDriverWait(driverClick, TimeSpan.FromSeconds(timeout));

                    waitClick.Until(drv => drv.FindElement(elementClick).Displayed);

                    waitClick.Until(drv => drv.FindElement(elementClick).Enabled);

                    var action = new Actions(driverClick);

                    action.MoveToElement(driverClick.FindElement(elementClick));

                    action.Release().Click().Build().Perform();

                    statement = true;
                }
                catch (Exception ex)
                {
                    if (triedCount >= tried) throw new Exception(ex.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller </param>
        /// <param name="elementSendKeys"> Page element on the that apply text on input field. </param>
        /// <param name="text">Text to add on input field</param>
        /// <param name="timeout"> Wait for generate error </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void Sendkeys(IWebDriver driverSendKeys, By elementSendKeys, string text, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(timeout));

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Displayed);

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(elementSendKeys));

                    action.Release().Click().SendKeys(text);

                    action.Build().Perform();

                    statement = true;
                }
                catch (Exception ex)
                {
                    if (triedCount >= tried) throw new Exception(ex.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller </param>
        /// <param name="elementSendKeys"> Page element on the that apply text on input field. </param>
        /// <param name="text">Text to add on input field</param>
        /// <param name="timeout"> Wait for generate error </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void EnterAfterSendkeys(IWebDriver driverSendKeys, By elementSendKeys, string text, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(timeout));

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Displayed);

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(elementSendKeys));

                    action.Release().Click().SendKeys(text);

                    action.SendKeys(Keys.Enter);

                    action.Build().Perform();

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller </param>
        /// <param name="elementSendKeys"> Page element on the that aplicate text on input field. </param>
        /// <param name="text">Text to add on input field</param>
        /// <param name="timeout"> Wait for generate error </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void TabAfterSendkeys(IWebDriver driverSendKeys, By elementSendKeys, string text, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(timeout));

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Displayed);

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(elementSendKeys));

                    action.Release().Click().SendKeys(text);

                    action.SendKeys(Keys.Tab);

                    action.Build().Perform();

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller. </param>
        /// <param name="elementSendKeys"> Page element on the that aplicate text on input field. </param>
        /// <param name="text">Text to add on input field. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void ClearBeforeSendkeys(IWebDriver driverSendKeys, By elementSendKeys, string text, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(timeout));

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Displayed);

                    waitSendKeys.Until(drv => drv.FindElement(elementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(elementSendKeys));

                    action.Release().Click();

                    action.Build().Perform();

                    driverSendKeys.FindElement(elementSendKeys).Clear();

                    action.MoveToElement(driverSendKeys.FindElement(elementSendKeys));

                    action.Release().Click();

                    action.SendKeys(text);

                    action.Build().Perform();

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        #endregion Basic

        #region Select

        /// <summary>
        /// Method for select item of a dropdown.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="listItem"> Dropdown of page on the that the options are displayed. </param>
        /// <param name="option"> Option text to select. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void SelectDropDownList(IWebDriver driverList, By listItem, string option, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(listItem).Displayed);

                    waitList.Until(drv => drv.FindElement(listItem).Enabled);

                    var action = new Actions(driverList);

                    action.MoveToElement(driverList.FindElement(listItem));

                    action.Release().Click();

                    action.Build().Perform();

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);

            var statementOption = false;

            triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitOptions = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitOptions.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + option + "')]")).Displayed);

                    waitOptions.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + option + "')]")).Enabled);

                    Actions actionList = new Actions(driverList);

                    var optionElement = driverList.FindElement(By.XPath("//*[contains(text(),'" + option + "')]"));

                    actionList.MoveToElement(optionElement).Release().Click().Build().Perform();

                    statementOption = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (statementOption);
        }

        /// <summary>
        /// Method for select item of a dropdown.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="listItem"> Dropdown of page on the that the options are displayed. </param>
        /// <param name="option"> Option text to select. </param>
        /// <param name="tag"> HTML listing options tag. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void SelectDropDownList(IWebDriver driverList, By listItem, string option, string tag, int timeout = 10, int tried = 1)
        {
            var statementList = false;

            var triedCountList = 0;

            do
            {
                triedCountList++;
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(listItem).Displayed);

                    waitList.Until(drv => drv.FindElement(listItem).Enabled);

                    var action = new Actions(driverList);

                    action.MoveToElement(driverList.FindElement(listItem));

                    action.Release().Click().Build().Perform();

                    statementList = true;
                }
                catch (Exception fail)
                {
                    if (triedCountList >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (statementList);

            var statementOption = false;

            var triedCountOption = 0;

            do
            {
                triedCountOption++;
                try
                {
                    var waitOption = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitOption.Until(drv => drv.FindElement(By.XPath("//" + tag + "[contains(text(),'" + option + "')]")).Displayed);

                    waitOption.Until(drv => drv.FindElement(By.XPath("//" + tag + "[contains(text(),'" + option + "')]")).Enabled);

                    var actionList = new Actions(driverList);

                    var optionElement = driverList.FindElement(By.XPath("//" + tag + "[contains(text(),'" + option + "')]"));

                    actionList.MoveToElement(optionElement).Release().Click().Build().Perform();

                    statementOption = true;
                }
                catch (Exception fail)
                {
                    if (triedCountOption >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (statementOption);
        }

        /// <summary>
        /// Method for select item of a ComboBox list.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="listItem"> ComboBox list of page on the that the options are displayed. </param>
        /// <param name="textOption"> Option text to select. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void SelectComboAutocompleteList(IWebDriver driverList, By listItem, string textOption, int timeout = 10, int tried = 1)
        {
            var statementList = false;

            var triedCountList = 0;

            do
            {
                triedCountList++;
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(listItem).Displayed);

                    waitList.Until(drv => drv.FindElement(listItem).Enabled);

                    var actionList = new Actions(driverList);

                    actionList.MoveToElement(driverList.FindElement(listItem)).Release().Click();

                    actionList.SendKeys(textOption);

                    actionList.Build().Perform();

                    statementList = true;
                }
                catch (Exception fail)
                {
                    if (triedCountList >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (statementList);

            var statementOption = false;

            var triedCountOption = 0;

            do
            {
                triedCountOption++;
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + textOption + "')]")).Displayed);

                    waitList.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + textOption + "')]")).Enabled);

                    var actionList = new Actions(driverList);

                    var optionElement = driverList.FindElement(By.XPath("//*[contains(text(),'" + textOption + "')]"));

                    actionList.MoveToElement(optionElement).Release().Click().Build().Perform();

                    statementOption = true;
                }
                catch (Exception fail)
                {
                    if (triedCountOption >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (statementOption);
        }

        /// <summary>
        /// Method for select item of a ComboBox list.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="listItem"> ComboBox list of page on the that the options are displayed. </param>
        /// <param name="textOption"> Option text to select. </param>
        /// /// <param name="tag"> HTML listing options tag. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void SelectComboAutocompleteList(IWebDriver driverList, By listItem, string textOption, string tag, int timeout = 10, int tried = 1)
        {
            var statementList = false;

            var triedCountList = 0;

            do
            {
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(listItem).Displayed);

                    waitList.Until(drv => drv.FindElement(listItem).Enabled);

                    var actionList = new Actions(driverList);

                    actionList.MoveToElement(driverList.FindElement(listItem)).Release().Click();

                    actionList.SendKeys(textOption);

                    actionList.Build().Perform();

                    statementList = true;
                }
                catch (Exception fail)
                {
                    if (triedCountList >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (statementList);

            var statementOption = false;

            var triedCountOption = 0;

            do
            {
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(By.XPath("//" + tag + "[contains(text(),'" + textOption + "')]")).Displayed);

                    waitList.Until(drv => drv.FindElement(By.XPath("//" + tag + "[contains(text(),'" + textOption + "')]")).Enabled);

                    var actionList = new Actions(driverList);

                    var optionElement = driverList.FindElement(By.XPath("//" + tag + "[contains(text(),'" + textOption + "')]"));

                    actionList.MoveToElement(optionElement).Release().Click().Build().Perform();

                    statementOption = true;
                }
                catch (Exception fail)
                {
                    if (triedCountOption >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (statementOption);
        }

        /// <summary>
        /// Method for selected option by text.
        /// </summary>
        /// <param name="driverList"> Navigator controller. </param>
        /// <param name="listItem"> Select of page with options. </param>
        /// <param name="byText"> Text of option to select. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void SelectByText(IWebDriver driverList, By listItem, string byText, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(listItem).Displayed);

                    waitList.Until(drv => drv.FindElement(listItem).Enabled);

                    var select = driverList.FindElement(listItem);

                    var list = new SelectElement(select);

                    list.SelectByText(byText);

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for selected option by Index.
        /// </summary>
        /// <param name="driverList"> Navigator controller. </param>
        /// <param name="listItem"> Select of page with options. </param>
        /// <param name="byIndex"> Index of option to select. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void SelectByIndex(IWebDriver driverList, By listItem, int byIndex, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(listItem).Displayed);

                    waitList.Until(drv => drv.FindElement(listItem).Enabled);

                    var select = driverList.FindElement(listItem);

                    var list = new SelectElement(select);

                    list.SelectByIndex(byIndex);

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for selected option by Value.
        /// </summary>
        /// <param name="driverList"> Navigator controller. </param>
        /// <param name="listItem"> Select of page with options. </param>
        /// <param name="byValue"> Value of option to select. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void SelectByValue(IWebDriver driverList, By listItem, string byValue, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(listItem).Displayed);

                    waitList.Until(drv => drv.FindElement(listItem).Enabled);

                    var select = driverList.FindElement(listItem);

                    var list = new SelectElement(select);

                    list.SelectByValue(byValue);

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        /// <summary>
        /// Method for placing focus on an element.
        /// </summary>
        /// <param name="driverFocus"> Navigator controller. </param>
        /// <param name="itemFocus"> Element on which the focus is placed. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        public void WaitElement(IWebDriver driverFocus, By itemFocus, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitClear = new WebDriverWait(driverFocus, TimeSpan.FromSeconds(timeout));

                    waitClear.Until(drv => drv.FindElement(itemFocus).Displayed);

                    waitClear.Until(drv => drv.FindElement(itemFocus).Enabled);

                    var action = new Actions(driverFocus);

                    action.MoveToElement(driverFocus.FindElement(itemFocus));

                    action.Release().Build().Perform();

                    statement = true;
                }
                catch (Exception ex)
                {
                    if (triedCount >= tried) throw new Exception(ex.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        #endregion Select

        #region Advance

        /// <summary>
        ///
        /// </summary>
        /// <param name="driverNumberText"> Navigator controller. </param>
        /// <param name="element"> Element identified in web page </param>
        /// <param name="text"> Text extracted from the element </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        /// <returns></returns>
        public string ExtractNumberOfText(IWebDriver driverNumberText, By element, string text, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitList = new WebDriverWait(driverNumberText, TimeSpan.FromSeconds(timeout));

                    waitList.Until(drv => drv.FindElement(element).Displayed);

                    waitList.Until(drv => drv.FindElement(element).Enabled);

                    text = driverNumberText.FindElement(element).Text;

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);

            var number = Regex.Match(text, "(\\d+)");

            var result = Convert.ToString(number);

            return result;
        }

        /// <summary>
        /// Method for extracting attribute value from a tag.
        /// </summary>
        /// <param name="driverValue"> Navigator controller. </param>
        /// <param name="elementValue"> Element on which the attribute value is extracted. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        /// <returns></returns>
        public string ValueExtract(IWebDriver driverValue, By elementValue, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            string value = null;

            do
            {
                triedCount++;
                try
                {
                    var waitClick = new WebDriverWait(driverValue, TimeSpan.FromSeconds(timeout));

                    waitClick.Until(drv => drv.FindElement(elementValue).Displayed);

                    waitClick.Until(drv => drv.FindElement(elementValue).Enabled);

                    value = driverValue.FindElement(elementValue).GetAttribute("value");

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);

            return value;
        }

        /// <summary>
        /// Method for extracting text from a tag.
        /// </summary>
        /// <param name="driverText"> Navigator controller. </param>
        /// <param name="elementText"> Element on which the text is extracted. </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        /// <returns></returns>
        public string TextExtract(IWebDriver driverText, By elementText, int timeout = 10, int tried = 1)
        {
            string text = null;

            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitClick = new WebDriverWait(driverText, TimeSpan.FromSeconds(timeout));

                    waitClick.Until(drv => drv.FindElement(elementText).Displayed);

                    waitClick.Until(drv => drv.FindElement(elementText).Enabled);

                    text = driverText.FindElement(elementText).Text;

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);

            return text;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="driverDragAndDrop"> Navigator controller. </param>
        /// <param name="dragAndDrop"> Element on which it is performed Drag and drop </param>
        /// <param name="x"> Horizontal position  </param>
        /// <param name="y"> Upright position </param>
        /// <param name="timeout"> Wait for generate error. </param>
        /// <param name="tried">Limit attempts to generate error</param>
        public void DragAndDrop(IWebDriver driverDragAndDrop, By dragAndDrop, int x, int y, int timeout = 10, int tried = 1)
        {
            var statement = false;

            var triedCount = 0;

            do
            {
                triedCount++;
                try
                {
                    var waitClick = new WebDriverWait(driverDragAndDrop, TimeSpan.FromSeconds(timeout));

                    waitClick.Until(drv => drv.FindElement(dragAndDrop).Displayed);

                    waitClick.Until(drv => drv.FindElement(dragAndDrop).Enabled);

                    var element = driverDragAndDrop.FindElement(dragAndDrop);

                    var action = new Actions(driverDragAndDrop);

                    action.MoveToElement(element).Release().DragAndDropToOffset(element, x, y).Build().Perform();

                    statement = true;
                }
                catch (Exception fail)
                {
                    if (triedCount >= tried) throw new Exception(fail.Message);

                    Thread.Sleep(1000);
                }
            } while (!statement);
        }

        #endregion Advance
    }
}