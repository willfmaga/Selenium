using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange : dado um navegador aberto 
            IWebDriver driver = new ChromeDriver(
                Path.GetDirectoryName (Assembly.GetExecutingAssembly().Location));

            //act : quando eu navego para url : https://www.caelum.com.br
            driver.Navigate().GoToUrl("https://www.caelum.com.br");

            //assert : então espero que a pagina apresentada seja a Caelum
            Assert.Contains("Caelum", driver.Title);
        }
    }
}
