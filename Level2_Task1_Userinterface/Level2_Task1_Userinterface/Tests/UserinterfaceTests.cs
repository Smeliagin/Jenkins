using Level2_Task1_Userinterface.Utils;
using Level2_Task1_Userinterface.PageObjects;
using Level2_Task1_Userinterface.Models;
using Aquality.Selenium.Browsers;

namespace Level2_Task1_Userinterface.Tests
{
    public class UserinterfaceTests : BaseTest
    {
        [Test(Description = "Checking the filling of forms on the registration page")]
        public void CheckRegistrationPage()
        {
            Logger.Info(TestCaseSeparator + "Test Case 1 start" + TestCaseSeparator);
            string randomEmail = TextGeneratorUtil.GenerteLowerCaseRandomText();
            string randomDomain = TextGeneratorUtil.GenerteLowerCaseRandomText();
            string randomNumber = TextGeneratorUtil.GenerteRandomNumber();
            string randomPassword = randomEmail + randomNumber + TextGeneratorUtil.GenerteUpperCaseRandomText();
            HomePageObject homePage = new HomePageObject();
            Assert.IsTrue(homePage.State.IsDisplayed, "Home page is not open");
            Logger.Info("Click link for navigate to registration page");
            homePage.ClickNextPageLink();
            RegistrationPageObject registrationPage = new RegistrationPageObject();
            Assert.IsTrue(registrationPage.State.IsDisplayed, "Registration page is not open");
            Assert.IsTrue(registrationPage.Login.State.IsDisplayed, "Login form is not displayed");
            Logger.Info("Filling textboxes");
            registrationPage.Login.FillLoginFormTextBoxes(randomPassword, randomEmail, randomDomain);
            Logger.Info("Domain extensions select");
            registrationPage.Login.ClickDomainExtensionsComboBox();
            registrationPage.Login.ClickDomain(Int32.Parse(randomNumber));
            Logger.Info("Accept terms and conditions of use");
            registrationPage.Login.CheckTermsAndConditionsCheckBox();
            Logger.Info("Click button for navigate to avatar and interests form");
            registrationPage.Login.ClickNextButton();
            Assert.IsTrue(registrationPage.AvatarAndInterests.State.WaitForDisplayed(), "Avatar and interests form is not displayed");
            Logger.Info("Upload avatar");
            registrationPage.AvatarAndInterests.ClickUploadAvatarButton();
            CooperationWithDialogWindowUtil.LoadFileToDialogWindow(PathClass.avatarImagePath);
            Logger.Info("Select three random interests");
            registrationPage.AvatarAndInterests.UnselectAllInterests();
            registrationPage.AvatarAndInterests.SelectInterests(Int32.Parse(testData.InterestsNumber));
            Logger.Info("Click button for navigate to personal details form");
            registrationPage.AvatarAndInterests.ClickNextButton();
            Assert.IsTrue(registrationPage.PersonalDetails.State.WaitForDisplayed(), "Personal details form is not displayed");
        }

        [Test(Description = "Checking the help form")]
        public void CheckHelpForm() 
        {
            Logger.Info(TestCaseSeparator + "Test Case 2 start" + TestCaseSeparator);
            HomePageObject homePage = new HomePageObject();
            Assert.IsTrue(homePage.State.IsDisplayed, "Home page is not open");
            Logger.Info("Click link for navigate to registration page");
            homePage.ClickNextPageLink();
            RegistrationPageObject registrationPage = new RegistrationPageObject();
            Assert.IsTrue(registrationPage.State.IsDisplayed, "Registration page is not open");
            Assert.IsTrue(registrationPage.Help.State.IsDisplayed, "Help form is not displayed");
            Logger.Info("Click button for help form hidden");
            registrationPage.Help.ClickSendToBottomButton();
            Logger.Info("Wait for help form hides");
            AqualityServices.ConditionalWait.WaitFor(condition => registrationPage.Help.IsTitleLabelOnScreen());
            Assert.IsTrue(registrationPage.Help.IsTitleLabelOnScreen(), "Help form isn't hidden.");
        }

        [Test(Description = "Checking the cookie form")]
        public void CheckCookieForm()
        {
            Logger.Info(TestCaseSeparator + "Test Case 3 start" + TestCaseSeparator);
            HomePageObject homePage = new HomePageObject();
            Assert.IsTrue(homePage.State.IsDisplayed, "Home page is not open");
            Logger.Info("Click link for navigate to registration page");
            homePage.ClickNextPageLink();
            RegistrationPageObject registrationPage = new RegistrationPageObject();
            Assert.IsTrue(registrationPage.State.IsDisplayed, "Registration page is not open");
            Assert.IsTrue(registrationPage.Cookie.State.WaitForDisplayed(), "Cookie form is not displayed");
            Logger.Info("Click button for accept all cookies");
            registrationPage.Cookie.ClickNotReallyNoButton();
            Assert.IsFalse(registrationPage.Cookie.State.IsDisplayed, "Cookie form isn't hidden.");
        }


        [Test(Description = "Checking the start time of the timer")]
        public void CheckTimer() 
        {
            Logger.Info(TestCaseSeparator + "Test Case 4 start" + TestCaseSeparator);
            var expectedResults = JsonReaderUtil.GetDataFromFile<ExpectedResults>(PathClass.expectedResultsPath);
            HomePageObject homePage = new HomePageObject();
            Assert.IsTrue(homePage.State.IsDisplayed, "Home page is not open");
            Logger.Info("Click link for navigate to registration page");
            homePage.ClickNextPageLink();
            RegistrationPageObject registrationPage = new RegistrationPageObject();
            Assert.IsTrue(registrationPage.State.IsDisplayed, "Registration page is not open");
            Assert.That(registrationPage.GetTimerText().StartsWith(expectedResults.TimerStartTime), "Timer doesn't start from 00:00.");
        }

    }
}