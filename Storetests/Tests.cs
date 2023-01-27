using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject_Homework.Custom;


namespace TestProject_Homework.Storetests
{
    public class Purchase : Hooks
    {
        string loginName = "homew13";
        string loginPassword = "homew1";

        [Test, Order(1)]
        public void Signup()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("signin2"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("signInModal")));

            var username = driver.FindElement(By.Id("sign-username"));
            var password = driver.FindElement(By.Id("sign-password"));
            var button = driver.FindElement(By.CssSelector("#signInModal .btn.btn-primary"));

            username.SendKeys(loginName);
            password.SendKeys(loginPassword);
            button.Click();

            wait.Until(ExpectedConditions.AlertIsPresent());

            var alertText = driver.SwitchTo().Alert();
            Console.WriteLine(alertText.Text);

            Assert.That(alertText.Text, Is.EqualTo("Sign up successful."));
            driver.SwitchTo().Alert().Accept();
        }

        [Test, Order(2)]
        public void Login()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login2"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("logInModal")));

            var username = driver.FindElement(By.Id("loginusername"));
            var password = driver.FindElement(By.Id("loginpassword"));
            var button = driver.FindElement(By.CssSelector("#logInModal .btn.btn-primary"));

            username.SendKeys(loginName);
            password.SendKeys(loginPassword);
            button.Click();

            var nameofuser = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nameofuser")));
            Assert.That(nameofuser.Text, Is.EqualTo("Welcome " + loginName));
        }

        [Test, Order(3)]
        public void Select()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Laptops"))).Click();



            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='prod.html?idp_=11']"))).Click();



            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"tbodyid\"]/div[2]/div/a"))).Click();

            wait.Until(ExpectedConditions.AlertIsPresent());

            var alertText = driver.SwitchTo().Alert();
            Console.WriteLine(alertText.Text);

            Assert.That(alertText.Text, Is.EqualTo("Product added."));
            driver.SwitchTo().Alert().Accept();
        }

        [Test, Order(4)]
        public void Placeorder()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Cart"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"page-wrapper\"]/div/div[2]/button"))).Click();

            Thread.Sleep(3000);

            var name = driver.FindElement(By.Id("name"));
            var country = driver.FindElement(By.Id("country"));
            var city = driver.FindElement(By.Id("city"));
            var creditcard = driver.FindElement(By.Id("card"));
            var cardmonth = driver.FindElement(By.Id("month"));
            var cardyear = driver.FindElement(By.Id("year"));
            var button = driver.FindElement(By.XPath("//*[@id=\"orderModal\"]/div/div/div[3]/button[2]"));

            name.SendKeys("Liiina");
            country.SendKeys("Lithuania");
            city.SendKeys("Vilnius");
            creditcard.SendKeys("1234");
            cardmonth.SendKeys("June");
            cardyear.SendKeys("2023");
            button.Click();

            var thankyou = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[10]/h2")));
            Assert.That(thankyou.Text, Is.EqualTo("Thank you for your purchase!"));

            Thread.Sleep(3000);
        }
    }
}



