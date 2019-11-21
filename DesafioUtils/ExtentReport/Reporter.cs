
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using DesafioUtils.NunitHelpers;
using DesafioUtils.ProjectsUtilitarios;
using DesafioUtils.SeleniumUtilitarios;
using System;
using System.Configuration;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;

namespace DesafioUtils.ExtentReport
{
    public class Reporter
    {
        public static ExtentReports _extent;
        public static ExtentTest _test;
        public static Scenario _scenario;
        public static ExtentHtmlReporter _html;
        public static string TestType = ProjectsUtilitarios.Utilitarios.GetFrameworkTestType();
        public static string fileScreenShot = string.Empty;
        public static DateTime startTime;

        static string reportName = "Teste_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
        static string projectBinDebugPath = AppDomain.CurrentDomain.BaseDirectory;
        static FileInfo fileInfo = new FileInfo(projectBinDebugPath);
        static DirectoryInfo projectFolder = fileInfo.Directory;
        static string projectFolderPath = projectFolder.FullName;
        static string reportRootPath = projectFolderPath + "/Relatorio/";
        static string reportPath = projectFolderPath + "/Relatorio/" + reportName + "/";
        static string fileName = reportName + ".html";
        static string fullReportFilePath = reportPath + "_" + fileName;

        public static void InitializeReport()
        {
            if (_extent == null)
            {
                startTime = DateTime.Now;
                _extent = new ExtentReports();
                System.IO.Directory.CreateDirectory(reportRootPath);

                var Html = new ExtentHtmlReporter(fullReportFilePath);
                Html.Config.DocumentTitle = "Algum nome qualquer";
                Html.Config.ReportName = "Nome do relatório";
                Html.Config.JS = "var testsDiv = $(\".np-h:nth-child(1)\"); " +
                                          "var stepsDiv = $(\".np-h:nth-child(2)\"); " +
                                          "testsDiv.attr(\"class\", \"col s12 m12 np-h\"); " +
                                          "stepsDiv.css(\"display\", \"none\");";

                _extent.AttachReporter(Html);
            }
        }

        public static void AddTest()
        {
            if (TestType == "NunitTests")
            {

                var testName = GetCurrentContextTestHelper.GetTestName();
                var testDescription = GetCurrentContextTestHelper.GetTestDescription();
                var testCategory = GetCurrentContextTestHelper.GetTestCategory(Convert.ToInt16(ConfigurationManager.AppSettings["CategoryLenght"]));


                _test = _extent.CreateTest(testName, "Descrição: " + testDescription).AssignCategory(testCategory);

               

            }
            else if ((TestType == "SpecflowTests"))
            {
                #region comentado
                /*
                var featureTitle = GetCurrentContextScenarioHelper.GetFeatureTitle();
                var scenarioTitle = GetCurrentContextScenarioHelper.GetScenarioTitle();

                var feature = _extent.CreateTest<Feature>(scenarioTitle).AssignCategory(featureTitle);

                _test = feature.CreateNode<Scenario>(featureTitle);
                */
                #endregion
            }



        }
        public static void AddTestInfo(string text)
        {
            //addicionado para inserir informação de click no relatorio
            _test.Log(Status.Info, text);
            
        }

        public static void PassTest(string text)
        {
            if (TestType == "NunitTests")
            {

                _test.Log(Status.Pass, text);
            }
            DriverFactory.GetJSError();
        }

        public static void RemoveTest()
        {

            _extent.RemoveTest(_test);
        }

        public static void InfoTestAddScreenshot()
        {
            var result = GetCurrentContextTestHelper.GetTestResult();
            var stacktrace = GetCurrentContextTestHelper.GetStacktraceResult();
            String screenshot = TakeScreenshotHelper.TakeScreenShot();


            switch (result)
            {
                case TestStatus.Inconclusive:
                    _test.Fail(DriverFactory.Instance.Url + "<pre>Exception: " + stacktrace + "</pre>", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
                    break;
                case TestStatus.Skipped:
                    _test.Skip(DriverFactory.Instance.Url, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
                    break;
                case TestStatus.Passed:
                    //_test.Pass(result.ToString()).AddScreenCaptureFromPath(screenshot);
                    _test.Pass(DriverFactory.Instance.Url, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());

                    break;
                case TestStatus.Warning:
                    _test.Warning(DriverFactory.Instance.Url, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
                    break;
                case TestStatus.Failed:
                    _test.Fail(DriverFactory.Instance.Url + "<pre>Exception: " + stacktrace + "</pre>", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
                    break;
                default:
                    _test.Info(DriverFactory.Instance.Url, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
                    break;
            }
            DriverFactory.GetJSError();

        }
        public static void JustAddScreenshot()
        {
            String screenshot = TakeScreenshotHelper.TakeScreenShot();

            _test.Pass(DriverFactory.Instance.Url, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());
            
            DriverFactory.GetJSError();

        }

        public static void InfoTestPass(String text, String result)
        {
            if (TestType == "NunitTests")
            {
                try
                {
                    _test.Pass(text + result);
                }
                catch { }
            }
            DriverFactory.GetJSError();
        }

        public static void InfoTestWarning(String result)
        {
            if (TestType == "NunitTests")
            {
                try
                {
                    _test.Warning(result);
                }
                catch { }
            }
            DriverFactory.GetJSError();
        }

        public static void InfoTestFail(String result)
        {
            if (TestType == "NunitTests")
            {
                try
                {
                    _test.Fail(result);
                }
                catch { }
            }
            DriverFactory.GetJSError();
            Assert.Fail();
        }


        public static void InfoTest(String text)
        {
            if (TestType == "NunitTests")
            {
                try
                {
                    _test.Log(Status.Pass, text);
                }
                catch { }
            }
            else if ((TestType == "SpecflowTests"))
            {
                #region Comentado
                /*
                var stepType = GetCurrentContextScenarioHelper.getStepType();
                var desc = GetCurrentContextScenarioHelper.GetStepDescription();
                var getAll = GetCurrentContextScenarioHelper.GetStepStatus();


                switch (stepType)
                {
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                        _test.CreateNode<Given>(desc).Warning("<pre>" + text + "</pre>");
                        break;
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                        _test.CreateNode<When>(desc).Warning("<pre>" + text + "</pre>");
                        break;
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                        _test.CreateNode<Then>(desc).Warning("<pre>" + text + "</pre>");
                        break;
                    default:
                        break;
                }
                */
                #endregion
            }
            DriverFactory.GetJSError();


        }

        public static void FailTest(string text)
        {

            _test.Log(Status.Fail, text);
            DriverFactory.GetJSError();
            Assert.Fail();
        }

        public static void FailTestMarkup(String text)
        {
            string txt = text;
            IMarkup Amber = MarkupHelper.CreateLabel(text, ExtentColor.Amber);
            _test.Log(Status.Fail, Amber);

            IMarkup Black = MarkupHelper.CreateLabel(text, ExtentColor.Black);
            _test.Log(Status.Fail, Black);

            IMarkup Blue = MarkupHelper.CreateLabel(text, ExtentColor.Blue);
            _test.Log(Status.Fail, Blue);


            IMarkup Brown = MarkupHelper.CreateLabel(text, ExtentColor.Brown);
            _test.Log(Status.Fail, Brown);


            IMarkup Cyan = MarkupHelper.CreateLabel(text, ExtentColor.Cyan);
            _test.Log(Status.Fail, Cyan);

            IMarkup Green = MarkupHelper.CreateLabel(text, ExtentColor.Green);
            _test.Log(Status.Fail, Green);

            IMarkup Grey = MarkupHelper.CreateLabel(text, ExtentColor.Grey);
            _test.Log(Status.Fail, Grey);

            IMarkup Indigo = MarkupHelper.CreateLabel(text, ExtentColor.Indigo);
            _test.Log(Status.Fail, Indigo);

            IMarkup Lime = MarkupHelper.CreateLabel(text, ExtentColor.Lime);
            _test.Log(Status.Fail, Lime);

            IMarkup Orange = MarkupHelper.CreateLabel(text, ExtentColor.Orange);
            _test.Log(Status.Fail, Orange);

            DriverFactory.GetJSError();

        }

        public static void InfoTestMarkup(string text)
        {

            String code = " \n\t \n\t\t" + text + "\n\t \n ";

            IMarkup p = MarkupHelper.CreateCodeBlock(code);
            _test.Log(Status.Info, p);
            DriverFactory.GetJSError();

        }

        
        public static void GenerateReport()
        {
            DriverFactory.GetJSError();
            _extent.Flush();

        }
    }
}
