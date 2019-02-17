using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_task3.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;
using NUnit.Framework;

namespace ConsoleApp1.PageObjects
{
    class MailinatorPage
    {
        private IWebDriver _driver;

        By inputEmail = By.XPath("//*[@id='inboxfield']");
        By goButton = By.XPath("/html/body/section[1]/div/div[3]/div[2]/div[2]/div[1]/span/button");
        By from = By.XPath("//td[3]");
        By subj = By.XPath("//td[4]");

        By letterText = By.XPath("/html/body/div");

        string expectedName = "Valeo Aeneus";
        string expectedSubj = "QA_Hometask";
        string expectedText = "Text for assert777";

        public MailinatorPage(IWebDriver driver) => _driver = driver;

        public void MailinatorCheck(string email)
        {

            OpenMailinator();
            EnterAndSearch(email);
            CheckFromAndSubject();
            OpenLastAndCheck();
        }


        private void OpenMailinator()
        {
            Thread.Sleep(1000);
            _driver.Navigate().GoToUrl(@"https://www.mailinator.com/");
            Thread.Sleep(1000);
        }

        private void EnterAndSearch(string email)
        {
            _driver.FindElement(inputEmail).SendKeys(email);
            Thread.Sleep(500);
            _driver.FindElement(goButton).Click();
            Thread.Sleep(500);
        }

        private void CheckFromAndSubject()
        {
            string s1 = _driver.FindElement(from).Text;
            string s2 = _driver.FindElement(subj).Text;

            Assert.IsTrue(s1.Contains(expectedName), "Name is wrong");
            Assert.IsTrue(s2.Contains(expectedSubj), "Subject of the letter is wrong");

        }

        private void OpenLastAndCheck()
        {
            _driver.FindElement(subj).Click();
            Thread.Sleep(1000);

            _driver.SwitchTo().Frame("msg_body");

            string text = _driver.FindElement(letterText).Text;

            Assert.IsTrue(text.Contains(expectedText), "g");


        }


    }
}
