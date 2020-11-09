using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using OpenQA.Selenium;
using Xunit;
using Xunit.Sdk;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfeturarRegistro
    {
        public IWebDriver driver;

        public AoEfeturarRegistro(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrage - dado chrome aberto, pagina inicial do sist. de leiloes, 
            var registroPO = new RegistroPO(driver);

            registroPO.PreencheFormulario("William Fernandes Magalhães",
              "willfmaga@gmail.com", "123", "123");

            //act - efetuo o registro
            registroPO.SubmeteFormulario();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("", "willfmaga@gmail.com", "123", "123")]
        [InlineData("William F. Magalhaes", "willfmagagmail.com", "123", "123")]
        [InlineData("William F. Magalhaes", "willfmaga@gmail.com", "123", "456")]
        [InlineData("William F. Magalhaes", "willfmaga@gmail.com", "123", "")]
        public void DadoInfoInvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmacaosenha)
        {
            //arrage - dado chrome aberto, pagina inicial do sist. de leiloes, 
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome, email, senha, confirmacaosenha);

            //act - efetuo o registro
            registroPO.SubmeteFormulario();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();


            //act 
            registroPO.SubmeteFormulario();

            //assert 
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemErro()
        {
            //arrange
            //arrage - dado chrome aberto, pagina inicial do sist. de leiloes, 
            // dados de registros validos informados
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //Email 
            registroPO.PreencheFormulario(
                nome: "",
                email: "willfmagagmail.com",
                senha: "",
                confirmacaosenha: "");

            //act 
            registroPO.SubmeteFormulario();

            //assert 
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
