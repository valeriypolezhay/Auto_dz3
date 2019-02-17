using ConsoleApp1.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace QA_task3.PageObjects
{

    class LoginPage
    {

        private static IWebDriver _driver;

        By emailField = By.XPath("//*[@id='identifierId']");
        By emailNextButton = By.XPath("//*[@id='identifierNext']");
        By passwordField = By.XPath("//*[@id='password']/div[1]/div/div[1]/input");
        By passwordNextButton = By.XPath("//*[@id='passwordNext']");

        public LoginPage(IWebDriver driver) => _driver = driver;


        public void TypeEmail(string email)
        {
            Thread.Sleep(500);
            _driver.FindElement(emailField).SendKeys(email);
            Thread.Sleep(500);
            _driver.FindElement(emailNextButton).Click();
        }



        public void TypePassword(string password)
        {
            Thread.Sleep(1000);
            _driver.FindElement(passwordField).SendKeys(password);
            Thread.Sleep(1000);
            _driver.FindElement(passwordNextButton).Click();
        }

    }


}
