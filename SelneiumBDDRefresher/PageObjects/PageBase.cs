using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace SelneiumBDDRefresher.PageObjects
{
    public class PageBase
    {

        public void ClearAndSetField(IWebElement field, string text)
        {
            field.Clear();
            field.SendKeys(text);
        }

   }
}
