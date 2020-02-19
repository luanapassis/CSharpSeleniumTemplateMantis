using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioUtils.SeleniumUtilitarios;
using DesafioUtils.AchivesHelpres;
using Castle.DynamicProxy;
using System.Configuration;
using NUnit.Framework;
using DesafioUtils.ExtentReport;
using System.Reflection;
using NUnit.Framework.Interfaces;
using DesafioSelenium.Pages;
using DesafioUtils.Queries;

namespace DesafioTests.BaseClasses
{
    public class TestBase
    {

        private ProxyGenerator ProxyGenerator;

        public TestBase()
        {
            this.ProxyGenerator = new ProxyGenerator();
            DriverFactory.Initialize(ConfigurationManager.AppSettings["Browser"]);
            InjectPageObjects(CollectPageObjects(), null);
        }


        private void InjectPageObjects(List<FieldInfo> fields, IInterceptor proxy)
        {
            foreach (FieldInfo field in fields)
            {
                field.SetValue(this, ProxyGenerator.CreateClassProxy(field.FieldType, proxy));
            }
        }

        private List<FieldInfo> CollectPageObjects()
        {
            List<FieldInfo> fields = new List<FieldInfo>();

            foreach (FieldInfo field in this.GetType().GetRuntimeFields())
            {
                if (field.GetCustomAttribute(typeof(PageObject)) != null)
                    fields.Add(field);
            }

            return fields;
        }
        [OneTimeSetUp]

        public void OneTimeSetup()
        {
            Reporter.CreateReport();

            //carga no banco
            DataBaseSteps db = new DataBaseSteps();
            db.cargaTabelaUsuario();
            db.cargaProjeto();
            db.cargaMarcadores();

        }

        [SetUp]

        public void SetupTest()
        {
            DataBaseSteps db = new DataBaseSteps();
            db.atualizacaoCargaUsuario();
            db.atualizacaoCargaProjeto();
            db.atualizacaoCargaMarcadores();
            Reporter.AddTest();
            DriverFactory.Initialize(ConfigurationManager.AppSettings["Browser"]);
            DriverFactory.Instance.Manage().Cookies.DeleteAllCookies();

        }

        [TearDown]
        public void TearDownTest()
        {
            Reporter.AddTestResult();
            Reporter.GenerateReport();
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DriverFactory.QuitInstace();
        }

    }
}
