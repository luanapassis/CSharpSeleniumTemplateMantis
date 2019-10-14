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
        /// <summary>
        /// Base URL of the site being tested.
        /// </summary>
        public static string BaseUrl { get; set; }

        //public DriverFactory()
        //{
        //    Instance = null;
        //}

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

            // Initialize base URL and maximize browser
            BaseUrl = ConfigurationManager.AppSettings["BaseURL"];

            Instance.Manage().Cookies.DeleteAllCookies();



            NavigationHelper.NavigateToUrl(BaseUrl);

            // If we are running against a remote webdriver.
            //if (ConfigurationManager.AppSettings["RemoteChromeDriver"].Equals("true"))
            //{
            //    //// Create the driver.
            //    //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
            //    //Uri uri = new Uri("http://10.17.14.23:4444/hd/hub");

            //    //// Create an event firing webdriver.
            //    //var firingDriver = new EventFiringWebDriver(new RemoteWebDriver(uri, capabilities));


            //    //Instance = firingDriver;

            //    //DesiredCapabilities capabilities = new DesiredCapabilities();
            //    //capabilities = DesiredCapabilities.F();
            //    //capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            //    //capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));

            //    //var cap = capabilities;
            //    //Instance = new RemoteWebDriver(new Uri("http://10.17.14.23:4444/hd/hub/"), capabilities);

            //    //var url = "http://10.17.14.23:4444/hd/hub/";
            //    //var capabilities = new ChromeOptions().ToCapabilities();
            //    //var commandTimeout = TimeSpan.FromMinutes(5);

            //    //string uri = new Uri(url).LocalPath;

            //    //Instance = new RemoteWebDriver(new Uri(uri), capabilities, commandTimeout);

            //    //DesiredCapabilities capability = DesiredCapabilities.Chrome();
            //    //capability.SetCapability(CapabilityType.Platform, "WINDOWS");
            //    //capability.SetCapability(CapabilityType.BrowserName, "firefox");
            //    //capability.SetCapability(CapabilityType.Version, "5.0");

            //    Instance = new RemoteWebDriver(new Uri("http://10.17.14.23:4444/hd/hub"), DesiredCapabilities.Firefox());








            //    //RemoteWebDriver driver;
            //    //DesiredCapabilities capability = DesiredCapabilities.Chrome();

            //    ////capability.SetCapability(CapabilityType.Platform, PlatformType.Windows);
            //    ////capability.SetCapability(CapabilityType.BrowserName, "chrome");


            //    //driver = new RemoteWebDriver(
            //    //  new Uri(hubAddress), capability, TimeSpan.FromSeconds(600));// NOTE: connection timeout of 600 seconds or more required for time to launch grid nodes if non are available.

            //    ////ISelenium selenium = new WebDriverBackedSelenium(Instance, hubAddress);
            //    ////selenium.Start();




            //}
            //else
            //{


            //}



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
