using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace ElementsTests
{
    public class TextBoxFormValidation
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ElementsTests()
        {
            Debug.WriteLine("Navigating to DemoQA...");
            driver.Navigate().GoToUrl("https://demoqa.com");

            Debug.WriteLine("Clicking on Elements tab...");
            var elementsMenu = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementsMenu.Click();

            Debug.WriteLine("Clicking on Text Box option...");
            var textBoxMenu = driver.FindElement(By.XPath("//span[text()='Text Box']"));
            textBoxMenu.Click();

            var fullName = driver.FindElement(By.Id("userName"));
            var email = driver.FindElement(By.Id("userEmail"));
            var currentAddress = driver.FindElement(By.Id("currentAddress"));
            var permanentAddress = driver.FindElement(By.Id("permanentAddress"));
            var submitButton = driver.FindElement(By.Id("submit"));

            fullName.SendKeys("John Wick");
            email.SendKeys("Johnwick@test.com");
            currentAddress.SendKeys("123 Story Str.");
            permanentAddress.SendKeys("4 Fairytale Ave");

            submitButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var outputName = wait.Until(drv => drv.FindElement(By.Id("name")));
            var outputEmail = wait.Until(drv => drv.FindElement(By.Id("email")));
            var outputCurrentAddress = wait.Until(drv => drv.FindElement(By.XPath("//p[@id='currentAddress']")));
            var outputPermanentAddress = wait.Until(drv => drv.FindElement(By.XPath("//p[contains(@id,'permanentAddress')]")));

            Assert.That(outputName.Text, Is.EqualTo("Name:John Wick"));
            Assert.That(outputEmail.Text, Is.EqualTo("Email:Johnwick@test.com"));
            Assert.That(outputCurrentAddress.Text, Is.EqualTo("Current Address :123 Story Str."));
            Assert.That(outputPermanentAddress.Text, Is.EqualTo("Permananet Address :4 Fairytale Ave"));

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

    }
}
