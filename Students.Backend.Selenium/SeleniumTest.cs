using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace Students.Backend.Selenium
{
    [TestClass]
    public class SeleniumTest
    {
        private IWebDriver chrome;
        [TestInitialize]
        public void Init()
        {
            chrome = new ChromeDriver();
            chrome.Manage().Window.Maximize();
        }

        [TestMethod]
        public void SeleniumGetAllTests()
        {
            var baseUrl = "http://localhost:5000/api/Student";

            chrome.Navigate().GoToUrl(baseUrl);
            var responseElement = chrome.FindElement(By.TagName("pre"));
            var displayedResult = responseElement.Text;




            Assert.IsTrue(displayedResult.Contains("apellidos"));
            Assert.IsTrue(displayedResult.Contains("nombre"));
            Assert.IsTrue(displayedResult.Contains("dni"));
            Assert.IsTrue(displayedResult.Contains("fechaDeNacimiento"));
            Assert.IsTrue(displayedResult.Contains("fechaHoraRegistro"));
            Assert.IsTrue(displayedResult.Contains("guid"));
            Assert.IsTrue(displayedResult.Contains("id"));
            Assert.IsTrue(displayedResult.Contains("edad"));

            var splittedDisplayer = displayedResult.Split("{");

            Assert.IsTrue(splittedDisplayer.Length > 2);



        }

        [TestMethod]
        public void SeleniumAddTest()
        {

        }

        [TestCleanup]
        public void Clean()
        {
            chrome.Close();
            chrome.Quit();
        }


    }
}
