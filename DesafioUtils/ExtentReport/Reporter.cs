
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
        public static ExtentReports EXTENT_REPORT = null;
        public static ExtentTest TEST;

        static string reportName = "TesteMantis_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

        static string projectBinDebugPath = AppDomain.CurrentDomain.BaseDirectory;
        static FileInfo fileInfo = new FileInfo(projectBinDebugPath);
        static DirectoryInfo projectFolder = fileInfo.Directory;
        static string projectFolderPath = projectFolder.FullName;
        static string reportRootPath = projectFolderPath + "/Reports/";
        static string reportPath = projectFolderPath + "/Reports/" + reportName + "/";
        static string fileName = reportName + ".html";
        static string fullReportFilePath = reportPath + "_" + fileName;

        public static void CreateReport()
        {
            if (EXTENT_REPORT == null)
            {
                Utilitarios.EnsureDirectoryExists(reportRootPath);
                Utilitarios.EnsureDirectoryExists(reportPath);

                var htmlReporter = new ExtentV3HtmlReporter(fullReportFilePath);
                htmlReporter.LoadConfig(Utilitarios.GetProjectPath() + "extent-config.xml");
                EXTENT_REPORT = new ExtentReports();
                EXTENT_REPORT.AttachReporter(htmlReporter);
            }
        }

        public static void AddTest()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            var testCategory = (TestContext.CurrentContext.Test?.Properties["Category"]).Cast<string>().ToArray();
            TEST = EXTENT_REPORT.CreateTest(testName).AssignCategory(testCategory);
        }

        public static void AddTestInfo(int methodLevel, string text)
        {
            if (ConfigurationManager.AppSettings["GET_SCREENSHOT_FOR_EACH_STEP"] == "true")
            {
                TEST.Log(Status.Pass, Utilitarios.GetMethodNameByLevel(methodLevel) + " || " + text, GetScreenShotMedia());
            }
            else
            {
                TEST.Log(Status.Pass, Utilitarios.GetMethodNameByLevel(methodLevel) + " || " + text);
            }
        }

        public static MediaEntityModelProvider GetScreenShotMedia()
        {
            string screenshotPath = Utilitarios.GetScreenshot(reportPath);
            TestContext.AddTestAttachment(screenshotPath);
            return MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath.Replace(reportPath, ".")).Build();
        }

        public static void AddTestResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            switch (status)
            {
                case TestStatus.Failed:
                    TEST.Log(Status.Fail, "Test Result: " + Status.Fail + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>", GetScreenShotMedia());
                    break;
                case TestStatus.Inconclusive:
                    TEST.Log(Status.Warning, "Test Result: " + Status.Warning + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>", GetScreenShotMedia());
                    break;
                case TestStatus.Skipped:
                    TEST.Log(Status.Skip, "Test Result: " + Status.Skip + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>", GetScreenShotMedia());
                    break;
                default:
                    TEST.Log(Status.Pass, "Test Result: " + Status.Pass);
                    break;
            }
        }
        public static void JustAddScreenshot()
        {
            String screenshot = TakeScreenshotHelper.TakeScreenShot();

            TEST.Pass(DriverFactory.Instance.Url, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build());

            DriverFactory.GetJSError();

        }

        public static void GenerateReport()
        {
            EXTENT_REPORT.Flush();
        }
    }
}
