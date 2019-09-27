using NUnit.Framework;
using TechTalk.SpecFlow;
using SelneiumBDDRefresher.PageObjects;
using SelneiumBDDRefresher.Data;
using BoDi;
using System.Threading;

namespace SelneiumBDDRefresher.StepDefs
{
    [Binding]
    public sealed class SignUp
    {
        private SignUpPage signUpPage;
        private HomePage homePage;
        private UserDataModel user;

        public SignUp(SignUpPage signUpPage, HomePage homePage)
        {
            this.signUpPage = signUpPage;
            this.homePage = homePage;
        }


        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            //this is a given - step should be to set the state out instead of validating
            Assert.IsTrue(homePage.SignUpLinkIsDisplayed(), "User is logged in");
        }


        [When(@"I complete the sign up form")]
        public void WhenICompleteTheSignUpForm()
        {
            signUpPage.GoToHere();

            user = new UserDataModel();
            user.GenerateRandomUserDetails();
            signUpPage.CompleteSignupForm(user.username, user.email, user.password);
        }


        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            //SignUp link not available
            Assert.IsFalse(homePage.SignUpLinkIsDisplayed(), "User is not logged in");
        }


        [Then(@"my username is displayed")]
        public void ThenMyUsernameIsDisplayed()
        {
            Assert.IsTrue(homePage.UsernameLinkIsDisplayed(user.username));
        }

    }
}
