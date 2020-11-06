using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class TesteQualquer
    {
        private readonly IWebDriver driver;

        //Setup
        public TesteQualquer(TestFixture fixture)
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
    }
}
