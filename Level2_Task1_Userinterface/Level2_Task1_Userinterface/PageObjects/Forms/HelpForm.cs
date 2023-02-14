using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Level2_Task1_Userinterface.PageObjects.Forms
{
    public class HelpForm : Form
    {
        private IButton SendToBottomButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'send-to-bottom')]"), "Button 'Send to bottom'");
        private ILabel TitleLabel => ElementFactory.GetLabel(By.XPath("//*[contains(text(),'How can we help?')]"), "Title label");

        public HelpForm() : base(By.XPath("//a[contains(@class,'help')]"), "Help form")
        {
        }

        public void ClickSendToBottomButton() => SendToBottomButton.Click();

        public bool IsTitleLabelOnScreen() => TitleLabel.State.WaitForNotDisplayed();
    }
}
