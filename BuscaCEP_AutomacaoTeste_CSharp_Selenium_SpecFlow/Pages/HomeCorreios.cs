using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace BuscaCEP_AutomacaoTeste_CSharp_Selenium_SpecFlow.Pages
{
    class HomeCorreios
    {
        private IWebDriver driver;

        public HomeCorreios(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AcessarSite(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(driver.Title.ToLower().Contains("correios"));
        }

        private IWebElement PreencherCampoCEP()
        {
            //Retornando elemento XPath da página
            return driver.FindElement(By.XPath("//input[@id='relaxation']"));
        }

        private IWebElement PreencherCampoCodigoRatreamento()
        {
            //Retornando elemento XPath da página
            return driver.FindElement(By.XPath("//input[@id='objetos']"));
        }

        public void ConsultarCEP(string item)
        {
            //preenchendo o campo CEP
            PreencherCampoCEP().SendKeys(item);
            PreencherCampoCEP().SendKeys(Keys.Enter);
        }

        public void ConsultarCodigoRastreamento(string item)
        {
            //preenchendo o campo do Código de rastreamento
            PreencherCampoCodigoRatreamento().SendKeys(item);
            PreencherCampoCodigoRatreamento().SendKeys(Keys.Enter);
        }

        public void VoltarPaginaInicial()
        {
            //Fechando a aba atual do navegador
            //driver.Close();
            driver.Quit();
        }

    }
}
