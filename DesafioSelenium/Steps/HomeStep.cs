using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioSelenium.Pages;

namespace DesafioSelenium.Steps
{
    public class HomeStep
    {
        HomePage homePage;

        public HomeStep()
        {
            homePage = new HomePage();
        }

        public string retornaUsuLogado()
        {
            return homePage.retornaUsuLogado();
        }
    }
}
