using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace BuscaCEP_AutomacaoTeste_CSharp_Selenium_SpecFlow.Pages
{
    class Pesquisa
    {
        private IWebDriver driver;

        public Pesquisa(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement PreencherCodigoRastreamento()
        {
            //Retornando elemento XPath da página da nova aba de consulta
            return driver.FindElement(By.XPath("//input[@id='objeto']"));
        }

        public void ValidarResultadoDeEnderecoQueNaoExiste()
        {
            Thread.Sleep(2000);
            //Navegar para nova aba do navegador chamada Busca CEP
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            //Validação de teste utilizando elemento CSS
            Assert.That(driver.FindElement(By.CssSelector("#mensagem-resultado")).Text, Does.Contain("Não há dados a serem exibidos"));
        }

        public void ValidarResultadoDeEnderecoComSucesso(string endereco)
        {
            Thread.Sleep(2000);
            //Navegar para nova aba do navegador chamada Busca CEP
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string end = endereco.Substring(0, 21);
            //Validação de teste utilizando elemento XPath
            Assert.That(driver.FindElement(By.XPath("//td[contains(text(),'Rua Quinze de Novembro - lado ímpar')]")).Text, Does.Contain(end));
        }

        public void ValidarResultadoDeCodigoRastraemento()
        {
            Thread.Sleep(2000);
            //Navegar para nova aba do navegador chamada Rastreamento
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            //Realizando novamente a busca na nova aba do navegador
            PreencherCodigoRastreamento().Click();
            //PreencherCodigoRastreamento().SendKeys(Keys.Enter);
            //Validação de teste utilizando elemento ID
            Assert.That(driver.FindElement(By.Id("titulo-pagina")).Text, Does.Contain("Rastreamento"));
            //Assert.That(driver.FindElement(By.XPath("/html/body/main/div[1]/form/div[2]/div[1]/div/div[4]")).Text, Does.Contain("Código de objeto, CPF ou CNPJ informado não está válido"));

        }
    }
}
