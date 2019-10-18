using DesafioUtils.NunitHelpers;
using DesafioUtils.SeleniumUtilitarios;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioUtils.ProjectsUtilitarios
{
    public class TakeScreenshotHelper
    {
        public static string fileName = string.Empty;
        public static String TakeScreenShot()
        {
            // comentado temporariamente 
            //fileName = GetPathTakeScreenShot();


            Screenshot ss = ((ITakesScreenshot)DriverFactory.Instance).GetScreenshot();

            string screenshot = ss.AsBase64EncodedString;
            //byte[] screenshotAsByteArray = ss.AsByteArray;

            //ss.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg); 
            //ss.AsBase64EncodedString.ToString();


            //return fileName;

            return "data:image/jpg; base64, " + screenshot + " ' style='width:100%'";



        }

        //essa função não está sendo usanda por enquanto
        public static string GetPathTakeScreenShot()
        {
            var dir = Utilitarios.CreateDirectoryFolder(GetCurrentContextTestHelper.GetTestDirectoryName(), "\\" + DateTime.Now.ToString("dd-MM-yyyy"));


            String currentDateTime = DateHelper.GetDateTimeNow().Replace("/", "-").Replace(":", "-");
            //fileName = GetCurrentContextTestHelper.GetTestDirectoryName() + @"\Screenshot " + currentDateTime + ".Png";
            fileName = dir + @"\Screenshot " + currentDateTime + ".Png";

            return fileName;

        }
    }
}
