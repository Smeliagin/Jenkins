using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Level2_Task1_Userinterface.PageObjects.Forms
{
    public class AvatarAndInterestsForm : Form
    {
        private IList<ILabel> InterestsListText => ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'avatar-and-interests__interests-list__item')]//span[not(contains(@class,'checkbox'))]"));
        private IList<ICheckBox> InterestsList => ElementFactory.FindElements<ICheckBox>(By.XPath("//label[contains(@class, 'checkbox__label')]"));
        private ICheckBox UnselectAllCheckBox => ElementFactory.GetCheckBox(By.XPath("//*[contains(@for,'interest_unselectall')]"), "UnselectAllCheckBox");
        private ICheckBox SelectAllCheckBox => ElementFactory.GetCheckBox(By.XPath("//*[contains(@for,'interest_selectall')]"), "SelectAllCheckBox");
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//div[contains(@class, 'align__cell')]//button[contains(@class,'button--stroked')]"), "'Next' button");
        private IButton UploadAvatarButton => ElementFactory.GetButton(By.XPath("//a[contains(@class, 'avatar-and-interests__upload-button')]"), "'Unload' button");
        private ILabel UploadedAvatar => ElementFactory.GetLabel(By.ClassName("avatar-and-interests__avatar-image"), "UploadedImage");
        
        public AvatarAndInterestsForm() : base(By.XPath("//div[contains(@class, 'avatar-and-interests')]"), "Avatar and interests form")
        {
        }

        public void UnselectAllInterests()
        {
            UnselectAllCheckBox.Check();
        }

        public void SelectInterests(int number)
        {
            SelectFewRandomCheckBoxes(InterestsList, InterestsListText, number);
        }

        public void ClickNextButton()
        {
            NextButton.Click();
        }

        public void ClickUploadAvatarButton()
        {
            UploadAvatarButton.Click();
        }
        private static void SelectFewRandomCheckBoxes(IList<ICheckBox> checkBoxes, IList<ILabel> checkBoxesText, int number)
        {
            var interests = checkBoxes;
            var interestsText = checkBoxesText;
            var random = new Random();
            const string exeption1 = "Select all";
            const string exeption2 = "Unselect all";
            for (int i = 1; i <= number;)
            {
                int index = random.Next(interests.Count);
                if (!interestsText[index].Text.Equals(exeption1) && !interestsText[index].Text.Equals(exeption2))
                {
                    interests[index].Check();
                    interests.RemoveAt(index);
                    interestsText.RemoveAt(index);
                    i++;
                }
                else 
                { 
                    interests.RemoveAt(index);
                    interestsText.RemoveAt(index);
                }
            }
        }
    }
}
