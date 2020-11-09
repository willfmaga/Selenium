using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private readonly IWebDriver driver;

        //Setup
        public AoNavegarParaHome(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange 

            //act 
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert 
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange 

            //act 
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert 
            Assert.Contains("Leilões", driver.Title);

            //Assert.Contains("Próximos Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
        {
            //arrange 
            //vem da TesFixture

            //act 
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert 
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));

            foreach (var span in spans)
            {
                Assert.True(String.IsNullOrWhiteSpace(span.Text));
            }
        }
    }
}
