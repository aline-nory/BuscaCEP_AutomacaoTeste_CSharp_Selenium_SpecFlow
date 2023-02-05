using BuscaCEP_AutomacaoTeste_CSharp_Selenium_SpecFlow.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;



namespace BuscaCEP_AutomacaoTeste_CSharp_Selenium_SpecFlow.Steps
{
    [Binding]
    public class BuscaSteps
    {
        string url = "https://www.correios.com.br/";
        IWebDriver driver;
        Pesquisa pesquisa;
        HomeCorreios home;

        [Given(@"que acesse o site correios")]
        public void AcessarpaginaHomeCorreios()
        {
            //Iniciando as classes
            driver = new ChromeDriver();
            home = new HomeCorreios(driver);
            pesquisa = new Pesquisa(driver);

            //Acessando o site
            home.AcessarSite(url);
        }

        [When(@"desejar buscar (.*)")]
        public void BuscarCep(string cep)
        {
            //Buscando CEP
            home.ConsultarCEP(cep);
        }

        [Then(@"o site deve retornar que endereco nao existe")]
        public void RetornarEnderecoQueNaoExiste()
        {
            //Buscando Endereço
            pesquisa.ValidarResultadoDeEnderecoQueNaoExiste();
        }

        [Then(@"o site deve retornar o (.*) com sucesso")]
        public void RetornarEnderecoComSucesso(string endereco)
        {
            //Buscando Endereço
            pesquisa.ValidarResultadoDeEnderecoComSucesso(endereco);
        }

        [Then(@"voltar para a tela inicial")]
        public void VoltarParaATelaInicial()
        {
            home.VoltarPaginaInicial();
        }

        [When(@"desejar busca o (.*)")]
        public void BuscarCodigoDeRastreamento(string codigo)
        {
            //Buscando código de rastremaneto
            home.ConsultarCodigoRastreamento(codigo);
        }

        [Then(@"o site deve retornar que codigo de rastreamento nao existe")]
        public void RetornarQueCodigoDeRastreamentoNaoExiste()
        {
            pesquisa.ValidarResultadoDeCodigoRastraemento();
        }

        [Then(@"fechar o navegador")]
        public void FecharNavegador()
        {
            //Fechando navegador
            //driver.Close();
            driver.Quit();
        }

    }
}
