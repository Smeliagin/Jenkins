using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Level2_Task1_Userinterface.PageObjects.Forms;
using OpenQA.Selenium;

namespace Level2_Task1_Userinterface.PageObjects
{
    public class RegistrationPageObject : Form
    {
        private ILabel TimerLabel => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'timer')]"), "Timer label");
        private AvatarAndInterestsForm? _avatarAndInterestsForm;
        private CookieForm? _cookieForm;
        private HelpForm? _helpForm;
        private LoginForm? _loginForm;
        private PersonalDetailsForm? _personalDetailsForm;

        public AvatarAndInterestsForm AvatarAndInterests => _avatarAndInterestsForm ??= new AvatarAndInterestsForm();
        public CookieForm Cookie => _cookieForm ??= new CookieForm();
        public HelpForm Help => _helpForm ??= new HelpForm();
        public LoginForm Login => _loginForm ??= new LoginForm();
        public PersonalDetailsForm PersonalDetails => _personalDetailsForm ??= new PersonalDetailsForm();

        public RegistrationPageObject() : base(By.XPath("//div[contains(@class, 'game view')]"), "Registration page")
        {
        }

        public string GetTimerText() 
        { 
            return TimerLabel.Text;
        }

    }
}
