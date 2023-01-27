using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject_Homework.Custom
{
    public class Hooks : Base
    {
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}

