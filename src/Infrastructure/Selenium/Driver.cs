﻿using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Infrastructure.Selenium
{
    public class Driver : IDriver
    {
        private static Dictionary<FindType, Func<string, By>> findTypeMap
            = new Dictionary<FindType, Func<string, By>>
            {
                { FindType.ClassName, e => By.ClassName(e) },
                { FindType.CssSelector, e => By.CssSelector(e) },
                { FindType.Id, e => By.Id(e) },
                { FindType.LinkText, e => By.LinkText(e) },
                { FindType.Name, e => By.Name(e) },
                { FindType.PartialLinkText, e => By.PartialLinkText(e) },
                { FindType.TagName, e => By.TagName(e) },
                { FindType.XPath, e => By.XPath(e) },
            };

        public Driver(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebDriver WebDriver { get; private set; }

        public string Url
        {
            get { return WebDriver.Url; }
            set { WebDriver.Url = value; }
        }

        public ICheckBox FindCheckBox(FindType findType, string findBy)
        {
            var element = FindElement(findType, findBy);
            return new CheckBox(element);
        }

        public ITextBox FindTextBox(FindType findType, string findBy)
        {
            var element = FindElement(findType, findBy);
            return new TextBox(element);
        }

        public IRadioGroup FindRadioGroup(FindType findType, string findBy)
        {
            var elements = FindElements(findType, findBy);
            return new RadioGroup(elements);
        }

        public IRadioGroup<T> FindRadioGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var elements = FindElements(findType, findBy);
            return new RadioGroup<T>(elements, values);
        }
        public ICheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy)
        {
            var elements = FindElements(findType, findBy);
            return new CheckBoxGroup(elements);
        }

        public ICheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var elements = FindElements(findType, findBy);
            return new CheckBoxGroup<T>(elements, values);
        }

        public IComboBox FindComboBox(FindType findType, string findBy)
        {
            var element = FindElement(findType, findBy);
            return new ComboBox(element);
        }

        public IComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var element = FindElement(findType, findBy);
            return new ComboBox<T>(element, values);
        }
        public void Dispose()
        {
            WebDriver.Dispose();
        }


        #region Helper

        private ReadOnlyCollection<IWebElement> FindElements(FindType findType, string findBy)
        {
            var byGetter = findTypeMap[findType];
            var by = byGetter(findBy);
            return WebDriver.FindElements(by);
        }

        private IWebElement FindElement(FindType findType, string findBy)
        {
            var elements = FindElements(findType, findBy);
            return elements.Single();
        }




        #endregion Helper
    }
}