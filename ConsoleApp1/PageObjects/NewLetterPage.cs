using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_task3.PageObjects;
using System.Threading;

namespace ConsoleApp1.PageObjects
{
    class NewLetterPage
    {
        private IWebDriver _driver;
        //work well
        By createNewMessage = By.XPath("//*[@id=':38']/div/div");


        //dont work :(
        //By createNewMessage = By.XPath("//*[@id=':38']/div/div/text('Compose')");
        //By createNewMessage = By.XPath("//div[@role='button'][11]");
        //By createNewMessage = By.XPath("//div[contains(text(), 'Compose')]");
        //By createNewMessage = By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div[1]/div[2]/div/div/div/div[1]/div/div");
        //By createNewMessage = By.XPath("//div[@class='T-I J-J5-Ji T-I-KE L3']");
        //By createNewMessage = By.CssSelector(".T-I J-J5-Ji T-I-KE L3");
        //By createNewMessage = By.ClassName("T-I J-J5-Ji T-I-KE L3");




        public NewLetterPage(IWebDriver driver) => _driver = driver;

        public void SendNewMessage(string email, string letterSubject, string letterText)
        {
            NewEmail();
            EnterAddress(email);
            EnterSubject(letterSubject);
            EnterText(letterText);
            Send();
        }


        private void NewEmail()
        {
            Thread.Sleep(2000);

            _driver.FindElement(createNewMessage).Click();
            Thread.Sleep(2000);
        }

        private void EnterAddress(String email)
        {
            Thread.Sleep(2000);
            IWebElement currentElement = _driver.SwitchTo().ActiveElement();
            currentElement.SendKeys(email);
            Thread.Sleep(500);
            currentElement.SendKeys(Keys.Tab);
            Thread.Sleep(500);

            IWebElement currentElement2 = _driver.SwitchTo().ActiveElement();
            Thread.Sleep(500);
            currentElement2.SendKeys(Keys.Tab);
            Thread.Sleep(500);

        }

        private void EnterSubject(string subj)
        {
            Thread.Sleep(500);
            IWebElement currentElement3 = _driver.SwitchTo().ActiveElement();
            Thread.Sleep(500);
            currentElement3.SendKeys(subj);
            Thread.Sleep(500);
            currentElement3.SendKeys(Keys.Tab);
        }

        private void EnterText(string text)
        {
            IWebElement currentElement4 = _driver.SwitchTo().ActiveElement();
            currentElement4.SendKeys(text);
            Thread.Sleep(1000);
            currentElement4.SendKeys(Keys.Tab);

        }

        private void Send()
        {
            IWebElement currentElement5 = _driver.SwitchTo().ActiveElement();
            currentElement5.Click();
        }

    }
}
