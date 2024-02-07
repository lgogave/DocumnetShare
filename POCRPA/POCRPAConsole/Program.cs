using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace POCRPAConsole
{
	class Program
	{
		public static void Main(string[] args)
		{
			WebDriverWait wait;

			using (IWebDriver driver = new ChromeDriver())
			{
				// Navigate to a web page
				driver.Navigate().GoToUrl("https://apptot.azurewebsites.net/");

				// Perform web automation actions (e.g., click, type, etc.)
				IWebElement element = driver.FindElement(By.Id("btnSignIn"));
				element.Click();


				Thread.Sleep(TimeSpan.FromSeconds(20));
				wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

				IWebElement anchorElement = driver.FindElement(By.CssSelector("a[href='/Report/UserStatistics']"));

				if (anchorElement != null)
				{
					// Click on the anchor element
					anchorElement.Click();

					Thread.Sleep(TimeSpan.FromSeconds(20));

					IWebElement exportElement = driver.FindElement(By.CssSelector("button[aria-controls='reports-tbl']"));
					if (exportElement != null)
					{
						exportElement.Click();
					}
					Console.WriteLine("Clicked on the anchor element successfully after retry.");
					Thread.Sleep(TimeSpan.FromSeconds(20));
				}

				// Optionally, perform other web automation tasks
				// Close the browser
				driver.Quit();

			}

		}
	}
}
