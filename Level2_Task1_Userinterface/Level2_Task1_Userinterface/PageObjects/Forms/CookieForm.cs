using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Level2_Task1_Userinterface.PageObjects.Forms
{
    public class CookieForm : Form
    {
        private IButton NotReallyNoButton => ElementFactory.GetButton(By.XPath("//div[contains(@class, 'cookies')]//button[not(contains(@class,'cookies'))]"), "Button 'Not Really, No'");

        public CookieForm() : base(By.XPath("//div[contains(@class, 'cookies')]"), "Cookie form")
        {
        }

        public void ClickNotReallyNoButton() => NotReallyNoButton.Click();
    }
}