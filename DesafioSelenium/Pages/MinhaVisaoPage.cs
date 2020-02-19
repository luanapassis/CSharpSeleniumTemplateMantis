using DesafioUtils.SeleniumHelpers;
using DesafioUtils.SeleniumHelpers.ElementsHelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSelenium.Pages
{
    public class MinhaVisaoPage : PageBase
    {
        By menuMinhaVisao = By.XPath("//a[@href= '/mantis/my_view_page.php']");
        //

        public void abrirMenuMinhaVisao()
        {
            Click(menuMinhaVisao);
        }

        public bool verificaExistenciaTarefaMinhaVisao(string codTarefa)
        {
            By campoTarefa = By.XPath("//td[@class = 'nowrap width-13 my-buglist-id']/a[contains(@href,'/mantis/view.php') and text() = '"+ codTarefa + "' ]");
            return ReturnIfElementsAreDisplayed(campoTarefa);
        }
    }
}
