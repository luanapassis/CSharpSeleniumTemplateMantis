using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioSelenium.Pages;

namespace DesafioSelenium.Steps
{
    public class Step_home
    {
        Page_Home pageHome;

        public Step_home()
        {
            pageHome = new Page_Home();
        }

        public string retornaUsuLogado()
        {
            return pageHome.retornaUsuLogado();
        }
    }
}
