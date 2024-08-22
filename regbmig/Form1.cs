using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OtpNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace regbmig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                var ig = File.ReadAllLines("Accountig.txt").ToList();
                KillChromeDriver();
                foreach (var i in ig)
                {
                    var account = i.Split('|');
                    var username = account[0];
                    var password = account[1];
                    var key2fa = account[2];
                    int add = 0;

                    dgv.Invoke(new Action(() =>
                    {
                        add = dgv.Rows.Add((dgv.RowCount + 1), username, password, key2fa);

                    }));
                    DataGridViewRow row = dgv.Rows[add];
                    LoginIG(row, username, password, key2fa);


                }

            });


        }

        private void LoginIG(DataGridViewRow row, string username, string password , string key2fa)
        {
            var chromeDriver = chromeDriver1andanh();
            chromeDriver.Navigate().GoToUrl("https://www.instagram.com/accounts/login");


            IWebElement tbemail = chromeDriver.FindElement(By.Name("username"));
            tbemail.SendKeys(username);
            Thread.Sleep(200);

            IWebElement tbpass = chromeDriver.FindElement(By.Name("password"));
            tbpass.SendKeys(password);
            Thread.Sleep(200);

            IWebElement tblogin = chromeDriver.FindElement(By.XPath("//*[text()='Log in']"));
            tblogin.Click();
            Thread.Sleep(100);

            var code = GetCode(key2fa);

            var btnSecurityCode = chromeDriver.FindElement(By.Name("verificationCode"));
            btnSecurityCode.SendKeys(code);
            Thread.Sleep(1000);

            var tbConFirm = chromeDriver.FindElement(By.XPath("//*[text()='Confirm']"));
            tbConFirm.Click();
            Thread.Sleep(10000);



            try
            {

                chromeDriver.Navigate().GoToUrl("https://business.facebook.com/business/loginpage/?next=https%3A%2F%2Fbusiness.facebook.com%2F%3Fnav_ref%3Dbiz_unified_f3_login_page_to_mbs&login_options%5B0%5D=FB&login_options%5B1%5D=IG&login_options%5B2%5D=SSO&config_ref=biz_login_tool_flavor_mbs");
                Thread.Sleep(1000);

                IWebElement btndangnhapbangig = chromeDriver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/div/div/div/div[2]/div/div/div/div[3]/div/div/div/div/div[1]/div[2]/span/span"));
                btndangnhapbangig.Click();
                Thread.Sleep(1000);

                var loginas = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                loginas[0].Click();
                Thread.Sleep(1000);

                // bat sang tao

                var Business = chromeDriver.FindElement(By.XPath("//input[@value='business']"));
                Business.Click();
                Thread.Sleep(1000);

                var Next10 = chromeDriver.FindElement(By.XPath("//*[text()='Next']"));
                Next10.Click();
                Thread.Sleep(1000);

                var Next11 = chromeDriver.FindElement(By.XPath("//*[text()='Next']"));
                Next11.Click();
                Thread.Sleep(1000);


                var SelectaCategory = chromeDriver.FindElements(By.XPath("//input[@type='radio']"));
                SelectaCategory[4].Click();
                Thread.Sleep(1000);

                var Done1 = chromeDriver.FindElement(By.XPath("//*[text()='Done']"));
                Done1.Click();
                Thread.Sleep(1000);

                var Save = chromeDriver.FindElement(By.XPath("//*[text()='Save']"));
                Save.Click();
                Thread.Sleep(1000);

                var Done2 = chromeDriver.FindElement(By.XPath("//*[text()='Done']"));
                Done2.Click();
                Thread.Sleep(100);

                chromeDriver.Navigate().GoToUrl("https://business.facebook.com/latest/settings");
                Thread.Sleep(7000);

                IWebElement btninvitepeople = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/span/div/div/div[1]/div[1]/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div/div/div/div[2]/div"));
                btninvitepeople.Click();
                Thread.Sleep(10000);

                var mailbusiness = "vu1882168@gmail.com";
                IWebElement btnentercontactinfo = null;
                try
                {
                    btnentercontactinfo = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/span/div/div/div[1]/div[2]/div/div/div[1]/div[1]/div/div[3]/div/div"));
                    btnentercontactinfo.Click();
                    Thread.Sleep(2000);

                    var mailao = "nghiadaica@gmail.com";

                    IWebElement btnbusinessmail = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div[2]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/div/div/div[1]/div[2]/div/div/input"));
                    btnbusinessmail.SendKeys(mailao);
                    Thread.Sleep(2000);

                    IWebElement btnsave = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div[3]/div/div[2]/div/span/div/div"));
                    btnsave.Click();
                    Thread.Sleep(2000);

                    btninvitepeople = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/span/div/div/div[1]/div[1]/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div[1]/div/div/div/div[2]/div"));
                    btninvitepeople.Click();
                    Thread.Sleep(2000);

                    IWebElement tbbusinessemail = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[1]/div[2]/div[1]/div/input"));
                    tbbusinessemail.SendKeys(mailbusiness);
                    Thread.Sleep(2000);

                }
                catch { }

                if (btnentercontactinfo == null)
                {
                    IWebElement tbbusinessemail = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[1]/div[2]/div[1]/div/input"));
                    tbbusinessemail.SendKeys(mailbusiness);
                    Thread.Sleep(2000);
                }

                IWebElement btnnext = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]"));
                btnnext.Click();
                Thread.Sleep(2000);

                try
                {
                    IWebElement btnmanage = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[2]/div/div[2]/div/div[2]/div/div/div[2]/div[1]/div[1]/input"));
                    btnmanage.Click();
                    Thread.Sleep(2000);
                }
                catch
                {
                    IWebElement btnmanage = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[2]/div/div[2]/div/div[2]/div/div/div[2]/div/div[1]/input"));
                    btnmanage.Click();
                    Thread.Sleep(2000);
                }
                btnnext = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]"));
                btnnext.Click();
                Thread.Sleep(2000);

                IWebElement btnnext1 = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[3]/div[2]/div[2]"));
                btnnext1.Click();
                Thread.Sleep(2000);

                IWebElement btncontinue = chromeDriver.FindElement(By.XPath("/html/body/span[2]/div/div[1]/div[1]/div/div/div/div/div[3]/div/div[2]/div/span/div/div/div"));
                btncontinue.Click();
                Thread.Sleep(2000);

                IWebElement btnsendinvitation = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]/div/span/div/div/div"));
                btnsendinvitation.Click();
                Thread.Sleep(2000);

                IWebElement btndone = chromeDriver.FindElement(By.XPath("/html/body/span/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div[2]/div/div/div[3]/div/div/div/span/div/div/div"));
                btndone.Click();
                Thread.Sleep(2000);
            }
            catch { }

        }

        private string GetCode(string key2fa)
        {
            byte[] secretKey = Base32Encoding.ToBytes(key2fa.Trim().Replace(" ", ""));
            Totp totp = new Totp(secretKey);
            return totp.ComputeTotp(DateTime.UtcNow);

        }
        private ChromeDriver chromeDriver1andanh()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("incognito", "--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=\"BlockCredentialedSubresources\"", "--disable-popup-blocking");
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.DisableBuildCheck = true;
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeDriver ChromeDriver1 = new ChromeDriver(chromeDriverService, options);
            ChromeDriver1.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            ChromeDriver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return ChromeDriver1;
        }
        private ChromeDriver Createchromedrive()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=\"BlockCredentialedSubresources\"", "--disable-popup-blocking");
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.DisableBuildCheck = true;
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, options);
            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return chromeDriver;
        }
        private string GetCodeHotmail(string username, string password)
        {
            string server = "pop3.live.com";
            OpenPop.Pop3.Pop3Client client = new OpenPop.Pop3.Pop3Client();
            client.Connect(server, 995, true);
            client.Authenticate(username, password);

            var messageCount = client.GetMessageCount();
            for (var i = messageCount; i >= 0; i--)
            {
                var msg = client.GetMessage(i).ToMailMessage().Body;

                if (msg.Contains("https://www.facebook.com/settings?tab=account&amp;section=password"))
                {
                    var document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(msg);

                    var codeNode = document.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[1]/tr[1]/td[1]/table[1]/tr[4]/td[2]/table[1]/tr[4]/td[1]/span[1]/div[1]/table[1]");
                    var code = codeNode.InnerText;

                    return code;
                }
            }

            return "";
        }
        private void KillChromeDriver()
        {
            Process[] processes = Process.GetProcessesByName("chromedriver");
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }



    }
}
