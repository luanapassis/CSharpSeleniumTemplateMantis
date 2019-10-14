using DesafioSelenium.Pages;
using DesafioTests.BaseClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTests.Tests
{
    class Test_inicial : TestBase
    {
        [PageObject]
        Page_Inicial pageInicial;

        [Test]
        public void teste1()
        {
            
            pageInicial.clicaNovoChamado();
        }
    }
}
