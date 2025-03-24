using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Elemnet
{
    public class WaitTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
        }

        [Test]
        public void CheckDynamicButtons()
        {
            try
            {
                driver.Navigate().GoToUrl("https://demoqa.com");

                var elementsMenu = driver.FindElement(By.XPath("//h5[text()='Elements']"));
                elementsMenu.Click();
                
                var webtables = driver.FindElement(By.XPath("//span[normalize-space()='Web Tables']"));
                webtables.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(drv => drv.FindElement(By.XPath("//div[@class='rt-table']")));

                var initialButtons = driver.FindElements(By.TagName("button"))
                    .Where(b => !string.IsNullOrEmpty(b.Text.Trim()))
                    .Select(b => b.Text.Trim())
                    .ToList();

                Console.WriteLine("Initial buttons found on page load:");
                foreach (var btn in initialButtons)
                {
                    Console.WriteLine($"- {btn}");
                }

                System.Threading.Thread.Sleep(5000);

                var newButtons = driver.FindElements(By.TagName("button"))
                    .Where(b => !string.IsNullOrEmpty(b.Text.Trim()))
                    .Select(b => b.Text.Trim())
                    .Where(text => !initialButtons.Contains(text))
                    .ToList();

                Console.WriteLine("\nNew buttons that appeared after 5 seconds:");
                if (newButtons.Count == 0)
                {
                    Console.WriteLine("No new buttons appeared after 5 seconds on https://demoqa.com/webtables.");
                }
                else
                {
                    foreach (var newBtn in newButtons)
                    {
                        Console.WriteLine($"- {newBtn}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
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
