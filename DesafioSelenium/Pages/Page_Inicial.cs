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
    public class Page_Inicial
    {
        WebDriverWait wait = null;
        IWebDriver driver = null;

        public Page_Inicial()
        {
            //PageFactory.InitElements(DriverFactory.Instance, this);
            //teste wait = new WebDriverWait(DriverFactory.Instance, new TimeSpan(0, 0, 5));
            //teste driver = DriverFactory.Instance;
        }

        public IWebElement campoNovo => DriverFactory.Instance.FindElement(By.XPath("//*[@id='opcaoBoxNovoChamado']/img"));

        public void abrirPagina()
        {
            NavigationHelper.NavigateToUrl(DriverFactory.BaseUrl);

        }

        public void clicaNovoChamado()
        {
            
             campoNovo.Click();
        }
    }
}
