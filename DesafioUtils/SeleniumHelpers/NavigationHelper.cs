using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioUtils.ExtentReport;
using DesafioUtils.ProjectsUtilitarios;
using DesafioUtils.SeleniumUtilitarios;

namespace DesafioUtils.SeleniumHelpers
{
    public class NavigationHelper
    {
        public static void NavigateToUrl(String url)
        {
            DriverFactory.Instance.Navigate().GoToUrl(url);
            string pageName = DriverFactory.Instance.Title;

            Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Acessando a página: " + pageName + " \n- URL: " + url);
        }

        public static void NavigateToUrl(object p)
        {
            throw new NotImplementedException();
        }
    }
}
