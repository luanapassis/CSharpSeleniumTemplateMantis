using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace DesafioUtils.ProjectsUtilitarios
{
    public static class Utilitarios
    {
        public static string GetFrameworkTestType()
        {
            return ConfigurationManager.AppSettings["TestType"];
        }

        public static String CreateDirectoryFolder(string path, string folderName)
        {
            // Specify the directory you want to manipulate.

            try
            {
                if (Directory.Exists(path + "\\" + folderName))
                {
                    Console.WriteLine("That path exists already.");
                    return path + folderName;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path + "\\" + folderName);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path + "\\" + folderName));

                // Delete the directory.
                //di.Delete();

                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            return path + "\\" + folderName;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }


    }
}
