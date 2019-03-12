using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestSelenium
{
    [TestClass]
    public class UnitTestClient
    {

        public static ChromeDriver DriverPaginaInicial()
        {
            ChromeDriver webDriver = null;

            webDriver = new ChromeDriver("D:\\chromedriver_win32");

            webDriver.Manage().Timeouts().PageLoad = new TimeSpan(0, 1, 0);
            webDriver.Navigate().GoToUrl("https://localhost:44386/");

            return webDriver;
        }


        [TestMethod]
        public void IncluirCandidatos()
        {

            ChromeDriver webDriver = DriverPaginaInicial();

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.PartialLinkText("Cadastro de Candidatos")) != null);

            webDriver.FindElement(By.PartialLinkText("Cadastro de Candidatos")).Click();

            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.LinkText("Novo")) != null);

            webDriver.FindElement(By.LinkText("Novo")).Click();

            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.Id("email")) != null);

            webDriver.FindElement(By.Id("email")).SendKeys("emaildocandidato@email.net");
            webDriver.FindElement(By.Id("nome")).SendKeys("Teste inclusão de candidato");
            webDriver.FindElement(By.Id("skype")).SendKeys("candidato.skype@email.net");
            webDriver.FindElement(By.Id("telefone")).SendKeys("(31)98952.6752");
            webDriver.FindElement(By.Id("cidade")).SendKeys("Vespasiano");
            webDriver.FindElement(By.Id("uf")).SendKeys("Minas Gerais");
            webDriver.FindElement(By.Id("pretencao")).SendKeys("95");

            Random random = new Random();

            foreach (var item in webDriver.FindElements(By.ClassName("custom-range")))
            {
                for (int x = 0; x <= random.Next(1, 5); x++)
                {
                    item.SendKeys(Keys.Right);
                }
            }

            foreach (var item in webDriver.FindElements(By.ClassName("form-check-input")))
            {
                item.Click();
            }

            webDriver.FindElement(By.Id("btn_gravar")).Submit();

            webDriver.Quit();

            webDriver = null;

        }


        [TestMethod]
        public void EditarCandidatos()
        {

            ChromeDriver webDriver = DriverPaginaInicial();

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.PartialLinkText("Cadastro de Candidatos")) != null);

            webDriver.FindElement(By.PartialLinkText("Cadastro de Candidatos")).Click();

            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElements(By.ClassName("btn-danger")) != null);

            webDriver.FindElements(By.ClassName("btn-primary")).FirstOrDefault(x => x.Text == "Editar")?.Click();

            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.Id("email")) != null);

            webDriver.FindElement(By.Id("email")).Clear();
            webDriver.FindElement(By.Id("email")).SendKeys("email@123.com.br");

            webDriver.FindElement(By.Id("nome")).Clear();
            webDriver.FindElement(By.Id("nome")).SendKeys("Nome do Candidato");

            Random random = new Random();

            foreach (var item in webDriver.FindElements(By.ClassName("custom-range")))
            {
                for (int x = 1; x <= 5; x++)
                {
                    item.SendKeys(Keys.Left);
                }

                for (int x = 0; x <= random.Next(1, 5); x++)
                {
                    item.SendKeys(Keys.Right);
                }
            }

            foreach (var item in webDriver.FindElements(By.ClassName("form-check-input")))
            {
                item.Click();
            }

            webDriver.FindElement(By.Id("btn_gravar")).Submit();

            webDriver.Quit();

            webDriver = null;

        }


        [TestMethod]
        public void ExcluirCandidatos()
        {

            ChromeDriver webDriver = DriverPaginaInicial();

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until((d) => d.FindElement(By.PartialLinkText("Cadastro de Candidatos")) != null);

            webDriver.FindElement(By.PartialLinkText("Cadastro de Candidatos")).Click();

            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElements(By.ClassName("btn-danger")) != null);

            foreach(var item in webDriver.FindElements(By.ClassName("btn-danger")))
            {
                if (item.Text == "Excluir")
                {
                    item.Click();

                    webDriver.SwitchTo().Alert().Accept();
                }
            }

            webDriver.Quit();

            webDriver = null;

        }

    }

}
