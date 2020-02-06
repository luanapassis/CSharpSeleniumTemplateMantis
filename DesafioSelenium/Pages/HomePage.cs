using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DesafioUtils.SeleniumUtilitarios;
using DesafioUtils.SeleniumHelpers;

namespace DesafioSelenium.Pages
{
    public class HomePage
    {
        public IWebElement usuLogado => DriverFactory.Instance.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul/li[3]/a/span"));
        public IWebElement projetos => DriverFactory.Instance.FindElement(By.XPath("(//a[@data-toggle = 'dropdown'])"));

        public string retornaUsuLogado()
        {
           return usuLogado.Text;

        }
    }
}
