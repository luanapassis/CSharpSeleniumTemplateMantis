using DesafioSelenium.Flows;
using DesafioSelenium.Pages;
using DesafioTests.BaseClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioUtils.JavaScriptHelpres;
using DesafioSelenium.DataDriven;
using DesafioSelenium.Steps;
using DesafioUtils.Queries;
using System.Configuration;
using DesafioUtils.ExtentReport;

namespace DesafioTests.Tests
{
    public class ProjetoTest : TestBase
    {
        [PageObject]
        LoginStep loginStep;
        [PageObject]
        HomeStep homeStep;

        [Test]
        [Description ("")]
        public void Test_verificaProjetoExistente()
        {
            string usuario = "luana.assis";
            string senha = "123456";
            loginStep.fazLogin(usuario, senha);
        }
    }
}
