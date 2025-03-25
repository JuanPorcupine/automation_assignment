using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace ElementsTests
{
    public class WebTablesTest
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
            driver.Navigate().GoToUrl("https://demoqa.com");

            var elementsMenu = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            elementsMenu.Click();
            var webtables = driver.FindElement(By.XPath("//span[normalize-space()='Web Tables']"));
            webtables.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.XPath("//div[@class='rt-table']")));

            var columns = driver.FindElements(By.XPath("//div[@class='rt-resizable-header-content']"));
            int columnsCount = columns.Count;

            var rows = driver.FindElements(By.XPath("//div[@class='rt-tr-group']"));
            int totalRowCount = rows.Count;

            int filledRows = 0;
            int emptyRows = 0;
            string aldenEmail = "";

            foreach (var row in rows)
            {
                var cells = row.FindElements(By.XPath(".//div[@class='rt-td']"));
                bool isEmpty = cells.All(cell => string.IsNullOrWhiteSpace(cell.Text));

                if (isEmpty)
                {
                    emptyRows++;
                }
                else
                {
                    filledRows++;
                }

                if (cells.Count > 0 && cells[0].Text.Trim() == "Alden")
                {
                    aldenEmail = cells[3].Text;
                }
            }

            Console.WriteLine($"Total Columns: {columnsCount}");
            Console.WriteLine($"Total Rows: {totalRowCount}");
            Console.WriteLine($"Filled Rows: {filledRows}");
            Console.WriteLine($"Empty Rows: {emptyRows}");
            Console.WriteLine($"Alden's Email: {aldenEmail}");
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
