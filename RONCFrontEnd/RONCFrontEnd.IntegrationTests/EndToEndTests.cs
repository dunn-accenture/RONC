using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Shouldly;
using Xunit;

namespace RONCFrontEnd.IntegrationTests
{
    public class EndToEndTests
    {
        private string _driverFile = SetGeckoDriver();
        
        private static string SetGeckoDriver()
        {
            var variable = Environment.GetEnvironmentVariable("GeckoDriverFile");

            if (variable != null)
            {
                return variable;
            } 
            
            return "geckodriver";
        }
        
        [Fact]
        public void HomePageIsCorrect()
        {
            // TODO something here, possibly the way we're getting the Environment.CurrentDirectory and the hardcoded result, is throwing a "System.ComponentModel.Win32Exception; exec format error"
            var service = FirefoxDriverService.CreateDefaultService(Environment.CurrentDirectory, _driverFile);   
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");
            var webdriver = new FirefoxDriver(service,firefoxOptions);
            
            webdriver.Navigate().GoToUrl("http://localhost:5000/");
            
            //Thread.Sleep(TimeSpan.FromSeconds(5));

            var div = webdriver.FindElementByTagName("div");
            
            try
            {
                div.Text.ShouldBe("biggun");
            }
            finally
            {
                webdriver.Quit();
            }
            
            
        }
    }
}