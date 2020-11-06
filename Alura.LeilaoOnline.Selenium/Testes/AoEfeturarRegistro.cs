using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using OpenQA.Selenium;
using Xunit;


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
            // dados de registros validos informados
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //nome 
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));
            
            //password
            var inputSenha = driver.FindElement(By.Id("Password"));
            
            //confirmpassword
            var inputConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));
            
            //botao registro 
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("William Fernandes Magalhães");
            inputEmail.SendKeys("willfmaga@gmail.com");
            inputSenha.SendKeys("123");
            inputConfirmacaoSenha.SendKeys("123");

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("","willfmaga@gmail.com","123","123")]
        [InlineData("William F. Magalhaes","willfmagagmail.com","123","123")]
        [InlineData("William F. Magalhaes", "willfmaga@gmail.com","123","456")]
        [InlineData("William F. Magalhaes", "willfmaga@gmail.com","123","")]
        public void DadoInfoInvalidasDeveContinuarNaHome(
            string nome,
            string email, 
            string senha, 
            string confirmacaosenha)
        {
            //arrage - dado chrome aberto, pagina inicial do sist. de leiloes, 
            // dados de registros validos informados
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //nome 
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //password
            var inputSenha = driver.FindElement(By.Id("Password"));

            //confirmpassword
            var inputConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));

            //botao registro 
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmacaoSenha.SendKeys(confirmacaosenha);

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);

        }

    }
}
