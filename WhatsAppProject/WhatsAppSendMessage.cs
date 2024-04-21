using EasyAutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq.Expressions;
using WhatsAppProject.Utils;

namespace WhatsAppProject
{

    public class WhatsAppSendMessage : Web
    {
        private string _browserPath = string.Empty;
        public WhatsAppSendMessage()
        {
            var configManager = new AppConfigManager();
            _browserPath = configManager.GetSeleniumOption("browserPath");
        }
        public void SendMessage(string message, string to)
        {
            StartBrowser(TypeDriver.GoogleChorme, _browserPath);

            Navigate("https://web.whatsapp.com/");
            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(4));

            var elemenSearch = AssignValue(TypeElement.Xpath, "//*[@id='side']/div[1]/div/div/div[2]/div/div[2]", to, 5);
            elemenSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);
            var elementMessage = AssignValue(TypeElement.Xpath, "/html/body/div[1]/div/div/div[4]/div/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", message);

            elementMessage.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            CloseBrowser();
        }

        public void SendMessageWithImage(string messsage, string pathImage, string to)
        {
            StartBrowser(TypeDriver.GoogleChorme, _browserPath);

            Navigate("https://web.whatsapp.com/");

            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(4));
            var elemenSearch = AssignValue(TypeElement.Xpath, "//*[@id='side']/div[1]/div/div/div[2]/div/div[2]", to, 5);
            elemenSearch.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            Click(TypeElement.Xpath,       "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/div/span");
            AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/span/div/div/ul/li[1]/button/input", pathImage);
            var elementInput = AssignValue(TypeElement.Xpath, "//*[@id=\"app\"]/div/div/div[2]/div[2]/span/div/span/div/div/div[2]/div/div[1]/div[3]/div/div/div[2]/div[1]/div[1]/p", messsage);

            elementInput.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            CloseBrowser();
        }

        public void SendMessageToZap(string message, string to)
        {
            StartBrowser(TypeDriver.GoogleChorme, _browserPath);
            Navigate("https://web.whatsapp.com/");
            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            IWebElement element = driver.FindElement(By.XPath("//span[contains(@data-icon, 'chat')]"));

            Actions actions = new Actions(driver);
            actions.Click(element).Build().Perform();

            IWebElement inputField = driver.FindElement(By.XPath("//input[@placeholder='Número de telefone']"));
            inputField.SendKeys(to);

            IWebElement button = driver.FindElement(By.XPath("//a[@class='btn-ok']"));
            button.Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));

            WaitForElement(TypeElement.Xpath, "//*[@id='side']/div[1]/div/div/div[2]/div/div[2]");
            var elemenSearch = AssignValue(TypeElement.Xpath, "//*[@id='side']/div[1]/div/div/div[2]/div/div[2]", to, 7);

            IWebElement elemento = driver.FindElement(By.CssSelector("p.selectable-text.copyable-text.x15bjb6t.x1n2onr6"));
            elemento.SendKeys(to);

            if (elemenSearch != null)
            {
                elemento.SendKeys(OpenQA.Selenium.Keys.Enter);
                var elementInput = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", message, 7);
                if (elementInput != null)
                {
                    elementInput.element.SendKeys(OpenQA.Selenium.Keys.Enter);
                }
                else
                {
                    Console.WriteLine("Elemento de entrada de texto não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Elemento de pesquisa não encontrado.");
            }
            driver.Quit();
        }

    }
}