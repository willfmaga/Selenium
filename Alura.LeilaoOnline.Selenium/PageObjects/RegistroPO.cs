using Alura.LeilaoOnline.Selenium.Fixtures;
using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmacaoSenha;
        private By byBotaoRegistro;
        private By bySpanErroEmail;
        private By bySpanErroNome;

        public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;

        public string NomeMensagemErro => driver.FindElement(bySpanErroNome).Text;

        public string RetornaConteudoPagina => driver.PageSource;

        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;

            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmacaoSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for='Email']");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        internal void SubmeteFormulario()
        {
            driver.FindElement(byBotaoRegistro).Click();
        }

        internal void PreencheFormulario(string nome, string email, string senha, string confirmacaosenha)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmacaoSenha).SendKeys(confirmacaosenha);
        }
    }
}
