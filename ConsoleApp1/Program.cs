using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ConsoleApp1.PageObjects;
using QA_task3.PageObjects;
using System.Threading;

namespace QA_task3
{
    class MailTest
    {
        readonly string correctEmailLogin = @"valeoaeneus@gmail.com";
        readonly string correctEmailPassword = @"totallynotsafepassword";

        readonly string targetEmail = @"epam_qa_task3@mailinator.com";
        readonly string subj = @"QA_Hometask";
        readonly string letter = @"Text for assert777";

        //[SetUp]
        //public void startBrowser()
        //{
        //    driver = new ChromeDriver
        //    {
        //        Url = @"https://mail.google.com"
        //    };

        //}


        //HomeGmail homeGmail;

        //LoginPage loginPage;//=new LoginPage(driver);


        [Test]
        public void LoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://mail.google.com");
            LoginPage login = new LoginPage(driver);

            login.TypeEmail(correctEmailLogin);
            login.TypePassword(correctEmailPassword);

            NewLetterPage newLetter = new NewLetterPage(driver);
            newLetter.SendNewMessage(targetEmail,subj ,letter );

           
        }

        [Test]
        public void MailinatorCheck()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://www.mailinator.com/");

            MailinatorPage mailinator = new MailinatorPage(driver);
            mailinator.MailinatorCheck(targetEmail);


        }


    }
}
