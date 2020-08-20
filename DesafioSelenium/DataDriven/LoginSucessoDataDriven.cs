using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DesafioSelenium.DataDriven
{
    public class LoginSucessoDataDriven
    {
        public static List<TestCaseData> LoginSucessoTestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"C:\automacao\Desafio\DesafioSelenium\DataDriven\TestData3.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            string colum1 = split[0];
                            string colum2 = split[1];

                            var testCase = new TestCaseData(colum1, colum2);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
    }
}
