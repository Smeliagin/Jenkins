using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Level2_Task1_Userinterface.PageObjects.Forms
{
    public class LoginForm : Form
    {
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'login-form__field-row')]//input"), "Password TextBox");
        private ITextBox EmailTextBox => ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'align__cell')]//input[contains(@placeholder,'email')]"), "Email TextBox");
        private ITextBox DomainTextBox => ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'align__cell')]//input[contains(@placeholder,'Domain')]"), "Domain TextBox");
        private IComboBox DomainExtensionsComboBox => ElementFactory.GetComboBox(By.XPath("//div[contains(@class, 'dropdown__header')]//span"), "Domain extensions ComboBox");
        private IList<IButton> DomainExtensionsItems => ElementFactory.FindElements<IButton>(By.XPath("//div[contains(@class, 'dropdown__list-item')]"));
        private ICheckBox TermsAndConditionsCheckBox => ElementFactory.GetCheckBox(By.XPath("//span[contains(@class, 'checkbox__box')]"), "Terms and conditions CheckBox");
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//a[contains(@class, 'button--secondary')]"), "'Next' button");
        
        public LoginForm() : base(By.XPath("//div[contains(@class, 'login-form__container')]"), "Login form")
        {
        }

        public void FillLoginFormTextBoxes(string password, string email, string domain) 
        {
            PasswordTextBox.ClearAndType(password);
            EmailTextBox.ClearAndType(email);
            DomainTextBox.ClearAndType(domain);
        }

        public void ClickDomainExtensionsComboBox()
        {
            DomainExtensionsComboBox.Click();
        }

        public void CheckTermsAndConditionsCheckBox()
        {
            if (!TermsAndConditionsCheckBox.IsChecked) 
            {
                TermsAndConditionsCheckBox.Check();
            }
        }

        public void ClickNextButton()
        {
            NextButton.Click();
        }

        public void ClickDomain(int index)
        {
            if (index <= DomainExtensionsItems.Count)
            {
                DomainExtensionsItems[index].Click();
            }
        }

    }
}
