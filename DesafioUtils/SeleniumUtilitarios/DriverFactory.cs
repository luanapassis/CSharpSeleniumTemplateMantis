using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioUtils.ExtentReport;
using OpenQA.Selenium;
using System.Configuration;
using DesafioUtils.SeleniumHelpers;
using DesafioUtils.NunitHelpers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using DesafioUtils.SeleniumUtilitarios;

namespace DesafioUtils.SeleniumUtilitarios
{
    public class DriverFactory 
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseUrl { get; set; }


        public static void Initialize(String browser)
        {
            string execution = ConfigurationManager.AppSettings["execution"].ToString();
            bool headless = bool.Parse(ConfigurationManager.AppSettings["headless"]);

            if (Instance == null)
            {


                switch (browser)
                {
                    case "chrome":
                        if (execution.Equals("local"))
                        {
                            Instance = headless ? Browsers.GetLocalChromeHeadless() : Browsers.GetLocalChrome();
                        }

                        if (execution.Equals("remota"))
                        {
                            Instance = headless ? Browsers.GetRemoteChromeHeadless() : Browsers.GetRemoteChrome();
                        }

                        break;

                    case "ie":
                        if (execution.Equals("local"))
                        {
                            Instance = Browsers.GetLocalInternetExplorer();
                        }

                        if (Instance.Equals("remota"))
                        {
                            Instance = Browsers.GetRemoteInternetExplorer();
                        }

                        break;

                    case "firefox":
                        if (execution.Equals("local"))
                        {
                            Instance = Browsers.GetLocalFirefox();
                        }

                        if (execution.Equals("remota"))
                        {
                            Instance = Browsers.GetRemoteFirefox();
                        }

                        break;

                    case "edge":
                        if (execution.Equals("local"))
                        {
                            Instance = Browsers.GetLocalEdge();
                        }

                        if (execution.Equals("remota"))
                        {
                            Instance = Browsers.GetRemoteEdge();
                        }

                        break;

                    default:
                        throw new Exception("O browser informado não existe ou não é suportado pela automação");
                }


                // inicializa o browser e maximiza a tela 
                BaseUrl = ConfigurationManager.AppSettings["BaseURL"];
                //deleta cookies
                //Instance.Manage().Cookies.DeleteAllCookies();
                //navega para a URL parametrizada no app config
                NavigationHelper.NavigateToUrl(BaseUrl);

            }
        }
        
       
        public static void GetJSError()
        {
            if(ConfigurationManager.AppSettings["Browser"] == "Chrome")
            {
                var entries = DriverFactory.Instance.Manage().Logs.GetLog(LogType.Browser);

                bool errorDisplayed = entries.Any(e => e.Level == OpenQA.Selenium.LogLevel.Severe && e.Message.Contains("javascript"));
                if (errorDisplayed)
                {
                    foreach (var entry in entries.Where(e => e.Level == OpenQA.Selenium.LogLevel.Severe && e.Message.Contains("javascript")))
                    {
                        Reporter.InfoTestWarning(entry.Message);
                    }
                }
            }
            
        }
    
    }
}
