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
using OpenQA.Selenium.PhantomJS;

namespace DesafioUtils.SeleniumUtilitarios
{
    public class DriverFactory
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseUrl { get; set; }


        public static void Initialize(String browser)
        {
            if (browser.Equals("Chrome"))
            {
                Instance = GetChromeDriver();

            }
            if (browser.Equals("Firefox"))
            {
                Instance = GetFirefoxDriver();

            }

            else if (browser.Equals("InternetExplorer"))
            {
                Instance = GetIEDriver();

            }
            else if (browser.Equals("PhantomJS"))
            {
                Instance = GetPhantomJSDriver();
            }

            // inicializa o browser e maximiza a tela 
            BaseUrl = ConfigurationManager.AppSettings["BaseURL"];
            //deleta cookies
            //Instance.Manage().Cookies.DeleteAllCookies();
            //navega para a URL parametrizada no app config
            NavigationHelper.NavigateToUrl(BaseUrl);
            

        }


        public static string pathFirefoxDriver = GetCurrentContextTestHelper.GetTestDirectoryName();

        private static FirefoxProfile GetFirefoxProfile()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();

            profile.SetPreference("webdriver.gecko.driver", pathFirefoxDriver);

            profile = manager.GetProfile("default");

            return profile;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {

            var url = new Uri("http://10.6.122.49:5555/wd/hub");

            var options = new FirefoxOptions();
            options.SetPreference("webdriver.gecko.driver", pathFirefoxDriver);

            var driver = new RemoteWebDriver(url, options.ToCapabilities());

            return options;

        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddArgument("--no-sandbox"); //chrome was crashing
            option.SetLoggingPreference(LogType.Browser, LogLevel.All);


            if (ConfigurationManager.AppSettings["ChromeHeadless"].Equals("true"))
            {
                option.AddArgument("--headless");
            }

            return option;

        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            return options;
        }

        private static PhantomJSOptions GetPhantomJsOptions()
        {
            PhantomJSOptions options = new PhantomJSOptions();
            options.AddAdditionalCapability("takesScreenshot", false);
            return options;
        }

        private static PhantomJSDriverService GetPhantomJsService()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            service.LogFile = "TestPhantomJS.log";
            service.HideCommandPromptWindow = true;
            return service;
        }

        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(pathFirefoxDriver);
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        private static IWebDriver GetPhantomJSDriver()
        {
            PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsService());
            return driver;
        }

        public static void Quit()
        {
            Instance.Quit();
        }

        private static FirefoxProfile CreateFirefoxProfile()
        {
            var firefoxProfile = new FirefoxProfile();
            return firefoxProfile;
        }

        public static void GetJSError()
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
