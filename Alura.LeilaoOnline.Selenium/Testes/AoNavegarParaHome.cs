using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
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
            Assert.Contains("Leil�es", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange 
          
            //act 
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert 
            Assert.Contains("Leil�es", driver.Title);

            //Assert.Contains("Pr�ximos Leil�es", driver.Title);
        }
    }
}
