using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Level2_Task1_Userinterface.PageObjects.Forms
{
    public class PersonalDetailsForm : Form
    {
        public PersonalDetailsForm() : base(By.XPath("//div[contains(@class, 'personal-details__form')]"), "Personal details form")
        {
        }

    }
}
