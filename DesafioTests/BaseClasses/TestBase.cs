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

namespace DesafioTests.BaseClasses
{
    public class TestBase
    {

        private ProxyGenerator ProxyGenerator;

        public TestBase()
        {
            this.ProxyGenerator = new ProxyGenerator();

            if (DriverFactory.Instance == null)
            {
                //cria instancia do browser 
                //passa o browser a ser testado
                DriverFactory.Initialize(ConfigurationManager.AppSettings["Browser"]);
            }

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
            Reporter.InitializeReport();

            //nao sei pra q server PlaylistTestHelper.CreatePlaylistArchive();

        }

        [SetUp]

        public void SetupTest()
        {
            Reporter.AddTest();
            //qntTestes++;
            //DriverFactory.Instance.Manage().Cookies.DeleteAllCookies();

        }

        [TearDown]
        public void TearDownTest()
        {
            Reporter.InfoTestAddScreenshot();
            Reporter.GenerateReport();

            //nao sei pra q server PlaylistTestHelper.AddTestToPlaylist();
            //var result = TestContext.CurrentContext.Result.Outcome.Status;
            //if (result == TestStatus.Failed)
            //{
           //     qntTestesFalhas++;
            //}
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

           // DriverFactory.Instance.Quit();
        }

    }
}
