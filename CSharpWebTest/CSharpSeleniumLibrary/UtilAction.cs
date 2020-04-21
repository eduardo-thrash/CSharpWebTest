using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Util
{
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
        /// <param name="tried"></param>
        /// <exception cref="Exception"></exception>
        public void Clear(IWebDriver driverClear, By elementClear, int timeout = 10, int tried = 10)
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
            } while (statement);
        }

        /// <summary>
        /// Method for apply click on element.
        /// </summary>
        /// <param name="driverClick"> Navigator controller </param>
        /// <param name="elementClick"> Page element on the that make click it </param>
        /// <param name="timeout"> Wait for generate error </param>
        /// <param name="tried"></param>
        public void Click(IWebDriver driverClick, By elementClick, int timeout = 10, int tried = 10)
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

                    action.Release().Build().Perform();

                    driverClick.FindElement(elementClick).Click();

                    statement = true;
                }
                catch (Exception ex)
                {
                    if (triedCount >= tried) throw new Exception(ex.Message);

                    Thread.Sleep(1000);
                }
            } while (statement);
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller </param>
        /// <param name="ElementSendKeys"> Page element on the that aplicate text on input field. </param>
        /// <param name="Text">Text to add on input field</param>
        /// <param name="Timeout"> Wait for generate error </param>
        public void Sendkeys(IWebDriver driverSendKeys, By ElementSendKeys, string Text, int Timeout = 10, int tried = 10)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(Timeout));

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Displayed);

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(ElementSendKeys));

                    action.Release().Build().Perform();

                    driverSendKeys.FindElement(ElementSendKeys).Click();

                    driverSendKeys.FindElement(ElementSendKeys).SendKeys(Text);

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller </param>
        /// <param name="ElementSendKeys"> Page element on the that aplicate text on input field. </param>
        /// <param name="Text">Text to add on input field</param>
        /// <param name="Timeout"> Wait for generate error </param>
        public void EnterAfterSendkeys(IWebDriver driverSendKeys, By ElementSendKeys, string Text, int Timeout = 10, int tried = 10)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(Timeout));

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Displayed);

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(ElementSendKeys));

                    action.Release().Build().Perform();

                    driverSendKeys.FindElement(ElementSendKeys).Click();

                    driverSendKeys.FindElement(ElementSendKeys).SendKeys(Text);

                    driverSendKeys.FindElement(ElementSendKeys).SendKeys(Keys.Enter);

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller </param>
        /// <param name="ElementSendKeys"> Page element on the that aplicate text on input field. </param>
        /// <param name="Text">Text to add on input field</param>
        /// <param name="Timeout"> Wait for generate error </param>
        public void TabAfterSendkeys(IWebDriver driverSendKeys, By ElementSendKeys, string Text, int Timeout = 10, int tried = 1)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(Timeout));

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Displayed);

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(ElementSendKeys));

                    action.Release().Build().Perform();

                    driverSendKeys.FindElement(ElementSendKeys).Click();

                    driverSendKeys.FindElement(ElementSendKeys).SendKeys(Text);

                    driverSendKeys.FindElement(ElementSendKeys).SendKeys(Keys.Tab);

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        /// <summary>
        /// Method for entering text to input type field
        /// </summary>
        /// <param name="driverSendKeys"> Navigator controller. </param>
        /// <param name="ElementSendKeys"> Page element on the that aplicate text on input field. </param>
        /// <param name="Text">Text to add on input field. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void ClearBeforeSendkeys(IWebDriver driverSendKeys, By ElementSendKeys, string Text, int Timeout = 10, int tried = 1)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitSendKeys = new WebDriverWait(driverSendKeys, TimeSpan.FromSeconds(Timeout));

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Displayed);

                    WaitSendKeys.Until(drv => drv.FindElement(ElementSendKeys).Enabled);

                    var action = new Actions(driverSendKeys);

                    action.MoveToElement(driverSendKeys.FindElement(ElementSendKeys));

                    action.Release().Build().Perform();

                    driverSendKeys.FindElement(ElementSendKeys).Click();

                    driverSendKeys.FindElement(ElementSendKeys).Clear();

                    driverSendKeys.FindElement(ElementSendKeys).SendKeys(Text);

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        #endregion Basic

        #region Select

        /// <summary>
        /// Method for select item of a dropdown.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="ListItem"> Dropdown of page on the that the options are displayed. </param>
        /// <param name="Option"> Option text to select. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectDropDownList(IWebDriver driverList, By ListItem, string Option, int Timeout = 10, int tried = 10)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));

                    WaitList.Until(drv => drv.FindElement(ListItem).Displayed);

                    WaitList.Until(drv => drv.FindElement(ListItem).Enabled);

                    var action = new Actions(driverList);

                    action.MoveToElement(driverList.FindElement(ListItem));

                    action.Release().Build().Perform();

                    driverList.FindElement(ListItem).Click();

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }

            exit = false;

            count = 1;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));

                    WaitList.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + Option + "')]")).Displayed);

                    WaitList.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + Option + "')]")).Enabled);

                    Actions actionList = new Actions(driverList);

                    var OptionElement = driverList.FindElement(By.XPath("//*[contains(text(),'" + Option + "')]"));

                    actionList.MoveToElement(OptionElement).Release().Click().Build().Perform();

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        /// <summary>
        /// Method for select item of a dropdown.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="ListItem"> Dropdown of page on the that the options are displayed. </param>
        /// <param name="Option"> Option text to select. </param>
        /// <param name="Tag"> HTML listing options tag. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectDropDownList(IWebDriver driverList, By ListItem, string Option, string Tag, int Timeout = 10, int tried = 10)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));

                    WaitList.Until(drv => drv.FindElement(ListItem).Displayed);

                    WaitList.Until(drv => drv.FindElement(ListItem).Enabled);

                    var action = new Actions(driverList);

                    action.MoveToElement(driverList.FindElement(ListItem));

                    action.Release().Build().Perform();

                    driverList.FindElement(ListItem).Click();

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }

            exit = false;

            count = 1;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));

                    WaitList.Until(drv => drv.FindElement(By.XPath("//" + Tag + "[contains(text(),'" + Option + "')]")).Displayed);

                    WaitList.Until(drv => drv.FindElement(By.XPath("//" + Tag + "[contains(text(),'" + Option + "')]")).Enabled);

                    var actionList = new Actions(driverList);

                    IWebElement OptionElement = driverList.FindElement(By.XPath("//" + Tag + "[contains(text(),'" + Option + "')]"));

                    actionList.MoveToElement(OptionElement).Release().Click().Build().Perform();

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        /// <summary>
        /// Method for select item of a ComboBox list.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="ListItem"> ComboBox list of page on the that the options are displayed. </param>
        /// <param name="Option"> Option text to select. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectComboAutocompleteList(IWebDriver driverList, By ListItem, string Option, int Timeout = 10, int tried = 10)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));
                    WaitList.Until(drv => drv.FindElement(ListItem).Displayed);
                    WaitList.Until(drv => drv.FindElement(ListItem).Enabled);
                    driverList.FindElement(ListItem).Click();
                    driverList.FindElement(ListItem).SendKeys(Option);

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }

            count = 1;

            exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));
                    WaitList.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + Option + "')]")).Displayed);
                    WaitList.Until(drv => drv.FindElement(By.XPath("//*[contains(text(),'" + Option + "')]")).Enabled);
                    Actions actionList = new Actions(driverList);
                    IWebElement OptionElement = driverList.FindElement(By.XPath("//*[contains(text(),'" + Option + "')]"));
                    actionList.MoveToElement(OptionElement).Release().Click().Build().Perform();

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        /// <summary>
        /// Method for select item of a ComboBox list.
        /// </summary>
        /// <param name="driverList"> Navigator controller </param>
        /// <param name="ListItem"> ComboBox list of page on the that the options are displayed. </param>
        /// <param name="Option"> Option text to select. </param>
        /// /// <param name="Tag"> HTML listing options tag. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectComboAutocompleteList(IWebDriver driverList, By ListItem, string Option, string Tag, int Timeout = 10, int tried = 10)
        {
            int count = 1;

            bool exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));
                    WaitList.Until(drv => drv.FindElement(ListItem).Displayed);
                    WaitList.Until(drv => drv.FindElement(ListItem).Enabled);
                    driverList.FindElement(ListItem).Click();
                    driverList.FindElement(ListItem).SendKeys(Option);

                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }

            count = 1;

            exit = false;

            while (!exit)
            {
                try
                {
                    WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));
                    WaitList.Until(drv => drv.FindElement(By.XPath("//" + Tag + "[contains(text(),'" + Option + "')]")).Displayed);
                    WaitList.Until(drv => drv.FindElement(By.XPath("//" + Tag + "[contains(text(),'" + Option + "')]")).Enabled);
                    Actions actionList = new Actions(driverList);
                    IWebElement OptionElement = driverList.FindElement(By.XPath("//" + Tag + "[contains(text(),'" + Option + "')]"));
                    actionList.MoveToElement(OptionElement).Release().Click().Build().Perform();
                    exit = true;
                }
                catch (Exception Fail)
                {
                    if (count >= tried)
                        throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);

                    count++;
                }
            }
        }

        /// <summary>
        /// Method for selected option by text.
        /// </summary>
        /// <param name="driverList"> Navigator controller. </param>
        /// <param name="ListItem"> Select of page with options. </param>
        /// <param name="ByText"> Text of option to select. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectByText(IWebDriver driverList, By ListItem, string ByText, int Timeout = 10)
        {
            try
            {
                WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));
                WaitList.Until(drv => drv.FindElement(ListItem).Displayed);
                WaitList.Until(drv => drv.FindElement(ListItem).Enabled);

                IWebElement Select = driverList.FindElement(ListItem);
                SelectElement List = new SelectElement(Select);
                List.SelectByText(ByText);
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }
        }

        /// <summary>
        /// Method for selected option by Index.
        /// </summary>
        /// <param name="driverList"> Navigator controller. </param>
        /// <param name="ListItem"> Select of page with options. </param>
        /// <param name="ByIndex"> Index of option to select. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectByIndex(IWebDriver driverList, By ListItem, int ByIndex, int Timeout = 10)
        {
            try
            {
                WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));
                WaitList.Until(drv => drv.FindElement(ListItem).Displayed);
                WaitList.Until(drv => drv.FindElement(ListItem).Enabled);

                IWebElement Select = driverList.FindElement(ListItem);
                SelectElement List = new SelectElement(Select);
                List.SelectByIndex(ByIndex);
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }
        }

        /// <summary>
        /// Method for selected option by Value.
        /// </summary>
        /// <param name="driverList"> Navigator controller. </param>
        /// <param name="ListItem"> Select of page with options. </param>
        /// <param name="ByValue"> Value of option to select. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectByValue(IWebDriver driverList, By ListItem, string ByValue, int Timeout = 10)
        {
            try
            {
                WebDriverWait WaitList = new WebDriverWait(driverList, TimeSpan.FromSeconds(Timeout));
                WaitList.Until(drv => drv.FindElement(ListItem).Displayed);
                WaitList.Until(drv => drv.FindElement(ListItem).Enabled);

                IWebElement Select = driverList.FindElement(ListItem);
                SelectElement List = new SelectElement(Select);
                List.SelectByValue(ByValue);
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }
        }

        /// <summary>
        /// Method for placing focus on an element.
        /// </summary>
        /// <param name="driverFocus"> Navigator controller. </param>
        /// <param name="ItemFocus"> Element on which the focus is placed. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void SelectItemInFocus(IWebDriver driverFocus, By ItemFocus, int Timeout = 10)
        {
            try
            {
                WebDriverWait WaitList = new WebDriverWait(driverFocus, TimeSpan.FromSeconds(Timeout));
                WaitList.Until(drv => drv.FindElement(ItemFocus).Displayed);
                WaitList.Until(drv => drv.FindElement(ItemFocus).Enabled);

                IWebElement Select = driverFocus.FindElement(ItemFocus);
                Actions action = new Actions(driverFocus);
                action.MoveToElement(Select).Release().Build().Perform();
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }
        }

        #endregion Select

        #region Advance

        /// <summary>
        ///
        /// </summary>
        /// <param name="driverNumberText"> Navigator controller. </param>
        /// <param name="Element"> Element identified in web page </param>
        /// <param name="Text"> Text extracted from the element </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        /// <returns></returns>
        public string ExtractNumberOfText(IWebDriver driverNumberText, By Element, string Text, int Timeout = 10)
        {
            try
            {
                WebDriverWait WaitList = new WebDriverWait(driverNumberText, TimeSpan.FromSeconds(Timeout));
                WaitList.Until(drv => drv.FindElement(Element).Displayed);
                WaitList.Until(drv => drv.FindElement(Element).Enabled);
                Text = driverNumberText.FindElement(Element).Text;
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }
            Match number = Regex.Match(Text, "(\\d+)");
            string result = Convert.ToString(number);
            return result;
        }

        /// <summary>
        /// Method for extracting attribute value from a tag.
        /// </summary>
        /// <param name="driverValue"> Navigator controller. </param>
        /// <param name="ElementValue"> Element on which the attribute value is extracted. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        /// <returns></returns>
        public string ValueExtract(IWebDriver driverValue, By ElementValue, int Timeout = 10)
        {
            string Value = null;

            try
            {
                WebDriverWait WaitClick = new WebDriverWait(driverValue, TimeSpan.FromSeconds(Timeout));
                WaitClick.Until(drv => drv.FindElement(ElementValue).Displayed);
                WaitClick.Until(drv => drv.FindElement(ElementValue).Enabled);

                Value = driverValue.FindElement(ElementValue).GetAttribute("value");
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }

            return Value;
        }

        /// <summary>
        /// Method for extracting text from a tag.
        /// </summary>
        /// <param name="driverText"> Navigator controller. </param>
        /// <param name="ElementText"> Element on which the text is extracted. </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        /// <returns></returns>
        public string TextExtract(IWebDriver driverText, By ElementText, int Timeout = 10)
        {
            string Text = null;

            try
            {
                WebDriverWait WaitClick = new WebDriverWait(driverText, TimeSpan.FromSeconds(Timeout));
                WaitClick.Until(drv => drv.FindElement(ElementText).Displayed);
                WaitClick.Until(drv => drv.FindElement(ElementText).Enabled);

                Text = driverText.FindElement(ElementText).Text;
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }

            return Text;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="driverDragAndDrop"> Navigator controller. </param>
        /// <param name="DragAndDrop"> Element on which it is performed Drag and drop </param>
        /// <param name="x"> Horizontal position  </param>
        /// <param name="y"> Upright position </param>
        /// <param name="Timeout"> Wait for generate error. </param>
        public void DragAndDrop(IWebDriver driverDragAndDrop, By DragAndDrop, int x, int y, int Timeout = 10)
        {
            try
            {
                WebDriverWait WaitClick = new WebDriverWait(driverDragAndDrop, TimeSpan.FromSeconds(Timeout));
                WaitClick.Until(drv => drv.FindElement(DragAndDrop).Displayed);
                WaitClick.Until(drv => drv.FindElement(DragAndDrop).Enabled);

                IWebElement Element = driverDragAndDrop.FindElement(DragAndDrop);
                Actions action = new Actions(driverDragAndDrop);
                action.MoveToElement(Element).Release().DragAndDropToOffset(Element, x, y).Build().Perform();
            }
            catch (Exception Fail)
            {
                throw new Exception(Fail.Message + "\n\n" + Fail.InnerException + "\n\n" + Fail.StackTrace);
            }
        }

        //public void SwitchToNewTab()
        //{
        //    Console.WriteLine("SwitchToNewTab");
        //}

        //public void SwitchToNewFrame()
        //{
        //    Console.WriteLine("SwitchToNewFrame");
        //}

        #endregion Advance
    }
}