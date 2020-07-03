using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace LPRecordPriceFinder
{
    public static class ScreenshotHelper
    {
        /// <summary>
        /// Takes a screenshot, if isHeadless is set to false then we see the window
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="isHeadless"></param>
        public static void TakesScreenshot(string url, string fileName, bool isHeadless = true)
        {
            var options = new ChromeOptions();
            if (isHeadless)
            {
                options.AddArgument("headless");
            }

            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            try
            {
                var screenshot = (driver as ITakesScreenshot).GetScreenshot();
                screenshot.SaveAsFile(fileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
