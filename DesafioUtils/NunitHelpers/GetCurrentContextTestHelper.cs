using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace DesafioUtils.NunitHelpers
{
    public class GetCurrentContextTestHelper
    {
        public static String GetTestDirectoryName()
        {
            return TestContext.CurrentContext.TestDirectory + "\\";
        }

        public static String GetTestName()
        {
            return TestContext.CurrentContext.Test.Name;

        }

        public static String GetFullTestName()
        {
            return TestContext.CurrentContext.Test.FullName;
        }
        public static String GetTestDescription()
        {
            if (TestContainsDescription())
            {
                return TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
            }
            else { return String.Empty; }

        }

        public static String GetProjectName()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }

        public static String GetTestCategory(int index)
        {
            return TestContext.CurrentContext.Test.ClassName.Substring(index);

        }

        public static TestStatus GetTestResult()
        {
            return TestContext.CurrentContext.Result.Outcome.Status;
        }

        public static String GetStacktraceResult()
        {
            string stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            return stacktrace;
        }

        private static bool TestContainsDescription()
        {
            var testDescription = TestContext.CurrentContext.Test.Properties.Get("Description");
            if (testDescription != null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
