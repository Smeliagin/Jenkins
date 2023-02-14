using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Level2_Task1_Userinterface.PageObjects
{
    public class HomePageObject : Form
    {
        private ILink NextPageLink => ElementFactory.GetLink(By.XPath("//div[contains(@class, 'view__row')]//a"), "Next page link");

        public HomePageObject() : base(By.XPath("//button[contains(@class, 'start__button')]"), "Home page")
        {
        }

        public void ClickNextPageLink() => NextPageLink.Click();

    }
}
