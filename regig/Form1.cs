using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using xNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace regig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {
            //var chromdriver = Createchromedrive();
            //chromdriver.Navigate().GoToUrl("https://www.instagram.com/");
            //Thread.Sleep(2000);
            //Thread.Sleep(100);
            //string username = "dinhhieu_ps4945719";
            //string password = "anhyeuem90";
            //var tbusername = chromdriver.FindElement(By.Name("username"));
            //tbusername.SendKeys(username);
            //Thread.Sleep(100);
            //var tbpassword =chromdriver.FindElement(By.Name("password"));
            //tbpassword.SendKeys(password);
            //Thread.Sleep(100);
            //var login = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div/div[3]"));
            //login.Click();
            //Thread.Sleep(100);

            //var btndangnhapbanginstargram = chromdriver.FindElements(By.XPath("//div[@role='button']"));
            //btndangnhapbanginstargram[1].Click();
            var httpRequest = new xNet.HttpRequest();
            httpRequest.AllowAutoRedirect = true;
            httpRequest.Cookies = new CookieDictionary();
            var emailSrc = httpRequest.Get("https://temp-mail-api3.p.rapidapi.com").ToString();
            Thread.Sleep(1000);
           // Regex.Match(emailSrc, "mail_get_mail\":\"(.*?)\"").Groups[1].Value;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var Account = File.ReadAllLines("Account.txt").ToList();
            //int iThread = 0;
            //int maxThread = (int)numThreads.Value;
            //int i = 0;
            //KillChromeDriver();

            //new Thread(() =>
            //{
            //    while (i < Account.Count)
            //    {
            //        if (iThread < maxThread)
            //        {
            //            int rowi = i;
            //            Interlocked.Increment(ref iThread);
            //            (new Thread(() =>
            //            {
            //                var account = Account[rowi];
            //                var viasplit = account.Split('|');
            //                string username = viasplit[0];
            //                string password = viasplit[1];
            //                string mailhoac2fa = viasplit[2];

            //                if (mailhoac2fa.Contains("@"))
            //                {
            //                    string email = viasplit[2];
            //                    string passmail = viasplit[3];
            //                    string mailkhoiphuc = viasplit[4];

            //                    int add = 0;
            //                    dgv1.Invoke(new Action(() =>
            //                    {

            //                        add = dgv1.Rows.Add((dgv1.RowCount + 1), username, password, "", email, passmail, mailkhoiphuc);

            //                    }));

            //                    DataGridViewRow row = dgv1.Rows[add];

            //                    Loginviano2fa(row, username, password, email, passmail, mailkhoiphuc);
            //                }
            //                else
            //                {
            //                    string c2FA = viasplit[2];
            //                    string email = viasplit[3];
            //                    string passmail = viasplit[4];
            //                    string mailkhoiphuc = viasplit[5];
            //                    int add = 0;
            //                    dgv1.Invoke(new Action(() =>
            //                    {
            //                        add = dgv1.Rows.Add((dgv1.RowCount + 1), username, password, c2FA, email, passmail, mailkhoiphuc);

            //                    }));

            //                    DataGridViewRow row = dgv1.Rows[add];

            //                    Loginvia2FA(row, username, password, c2FA, email, passmail, mailkhoiphuc);
            //                }
            //                Interlocked.Decrement(ref iThread);
            //            })).Start();
            //            i++;
            //            Thread.Sleep(100);
            //        }
            //        else
            //        {
            //            Thread.Sleep(300);
            //        }
            //    }
            //}).Start();









        }
        private void Loginviano2fa(DataGridViewRow row, string username, string password, string email, string passmail, string mailkhoiphuc)
        {
            //  var chromdriver = Createchromedrive();
            var chromdriver = chromeDriver1andanh();
            chromdriver.Navigate().GoToUrl("https://www.facebook.com/");
            Thread.Sleep(100);
            row.Cells["cStatus"].Value = "Login";

            #region dang nhap tk mk
            IWebElement tbmai = chromdriver.FindElement(By.Name("email"));
            tbmai.SendKeys(username);
            Thread.Sleep(100);
            IWebElement tbpass = chromdriver.FindElement(By.Name("pass"));
            tbpass.SendKeys(password);
            Thread.Sleep(100);
            IWebElement btnlogin = chromdriver.FindElement(By.Name("login"));
            btnlogin.Click();
            Thread.Sleep(100);
            var urlChrome = chromdriver.Url;


            while (urlChrome.Contains("https://www.facebook.com/recover/initiate/?lara_product=www_first_password_failure")
                || urlChrome.Contains("https://www.facebook.com/login/device-based/regular/login")
                || urlChrome.Contains("https://www.facebook.com/login/?privacy_mutation_token=")
                || urlChrome.Contains("https://www.facebook.com/login/web/?email=")
                || urlChrome.Contains("https://www.facebook.com/recover/initiate"))

            {

                ReLogin(chromdriver, row, username, password);
                urlChrome = chromdriver.Url;

                break;
            }

            #endregion

            if (urlChrome.Contains("https://www.facebook.com/login/help.php"))
            {
                row.Cells["cStatus"].Value = "via saipass";
                StreamWriter sw = new StreamWriter("viasaipass.txt", true);
                sw.WriteLine(username + "|" + password + "|" + email + "|" + passmail + "|" + mailkhoiphuc);
                sw.Close();
            }
            else if (urlChrome.Contains("1501092823525282"))
            {
                row.Cells["cStatus"].Value = "282";
                StreamWriter sw = new StreamWriter("282.txt", true);
                sw.WriteLine(username + "|" + password + "|" + email + "|" + passmail + "|" + mailkhoiphuc);
                sw.Close();
            }
            else if (urlChrome.Contains("https://www.facebook.com/login/device-based/regular/login"))
            {
                row.Cells["cStatus"].Value = "spam";
                StreamWriter sw = new StreamWriter("spam.txt", true);
                sw.WriteLine(username + "|" + password + "|" + email + "|" + passmail + "|" + mailkhoiphuc);
                sw.Close();
            }
            else if (urlChrome.Contains("465803052217681"))
            {
                row.Cells["cStatus"].Value = "465803052217681";
                IWebElement btntryotherway = null;
                try
                {
                    //phone doi sang mail
                    try
                    {
                        btntryotherway = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[1]/div/div[2]/div[2]/div/div/div/div/div[4]/div/div"));
                        btntryotherway.Click();
                        Task.Delay(100);
                    }
                    catch
                    {
                        var btntryotherway11 = chromdriver.FindElements(By.XPath("//div[@role='button']"));
                        btntryotherway11[2].Click();
                        Task.Delay(100);

                    }

                    var tabEmail = chromdriver.FindElements(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/label"));
                    var email1 = MaskEmail(email);
                    //tim hot mail cua via va chon
                    foreach (var element in tabEmail)
                    {
                        if (element.Text.Contains(email1))
                        {
                            element.Click();
                        }
                    }
                    Task.Delay(100).Wait();
                    chromdriver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div")).Click();
                    Task.Delay(200).Wait();

                    // chon mail kieu 2
                    try
                    {
                        row.Cells["cStatus"].Value = "chọn mail kiểu 2";
                        tabEmail = chromdriver.FindElements(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/label"));
                        email1 = MaskEmail(email);
                        foreach (var element in tabEmail)
                        {
                            if (element.Text.Contains(email))
                            {
                                element.Click();
                            }
                        }
                        Task.Delay(100).Wait();
                        chromdriver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div")).Click();
                        Task.Delay(200).Wait();
                        var btncontinue = chromdriver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                        btncontinue.Click();
                        Thread.Sleep(100);

                    }
                    catch { }

                }
                catch { }
                try
                {
                    row.Cells["cStatus"].Value = "lấy Code mail";
                    Task.Delay(TimeSpan.FromSeconds(11)).Wait();
                    var codemail = GetCodeHotmail(email, passmail);
                    var tbnhapcodemail = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[1]/div/div[2]/div[2]/div/div/div/div/div[3]/div/form/div/div/div/div/div[1]/input"));
                    tbnhapcodemail.SendKeys(codemail);
                    Task.Delay(200).Wait();
                    var btncontinue1 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[1]/div/div[2]/div[2]/div/div/div/div/div[3]/div/div[2]/div/div"));
                    btncontinue1.Click();
                    Thread.Sleep(1000);
                    IWebElement btndismiss = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div[3]/div"));
                    btndismiss.Click();
                    Thread.Sleep(100);

                }
                catch { }


            }else if(urlChrome.Contains("828281030927956"))
            {

                IWebElement Getstarted = chromdriver.FindElement(By.XPath("//span[text()='Get started']"));
                Getstarted.Click();
                Thread.Sleep(100);


                IWebElement next2 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/div/div[2]/div/div"));
                next2.Click();
                Thread.Sleep(100);

                IWebElement getacodemail = chromdriver.FindElement(By.XPath("//*[text()='Get a code by email']"));
                getacodemail.Click();
                Thread.Sleep(100);


                IWebElement tabEmail1 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div/div[1]/div"));
                tabEmail1.Click();
                Thread.Sleep(100);

                IWebElement Getcode = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/div/div[2]/div"));
                Getcode.Click();
                Thread.Sleep(100);


                Task.Delay(TimeSpan.FromSeconds(8)).Wait();
                var codemail1 = GetCodeHotmail(email, passmail);
                var tbnhapcodemail1 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[1]/div/label/input"));
                tbnhapcodemail1.SendKeys(codemail1);
                Task.Delay(200).Wait();

                var btncSubmit = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/div/div[2]/div"));
                btncSubmit.Click();
                Thread.Sleep(100);

                IWebElement btnnext12 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/div/div/div"));
                btnnext12.Click();
                Thread.Sleep(100);

                IWebElement btnnxet65 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/div/div[2]/div"));
                btnnxet65.Click();
                Thread.Sleep(100);

                IWebElement Dontromveanything = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/div/div/div/div"));
                Dontromveanything.Click();
                Thread.Sleep(100);

                IWebElement btnnxet87 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/div"));
                btnnxet87.Click();
                Thread.Sleep(100);

                IWebElement BacktoFacebook = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div/div/div/div/div/div[6]"));
                BacktoFacebook.Click();
                Thread.Sleep(100);

            }
            #region

            //if (!urlChrome.Contains("https://www.facebook.com/login/help.php"))
            //{
            //    #region REG IG
            //    row.Cells["cStatus"].Value = "Reg IG";
            //    Thread.Sleep(5000);
            //    for (int i = 0; i < 5; i++)
            //    {
            //        chromdriver.Navigate().GoToUrl("https://www.instagram.com/");

            //        IWebElement btndangnhapbangfacebook = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div/div[5]"));
            //        btndangnhapbangfacebook.Click();
            //        Thread.Sleep(1000);

            //        IWebElement btnConfirm = chromdriver.FindElement(By.Name("__CONFIRM__"));
            //        btnConfirm.Click();
            //        Thread.Sleep(5000);

            //        //IWebElement btnYesfinishadding = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div[2]/div/div/div/div/div[3]"));
            //        //btnYesfinishadding.Click();
            //        //Thread.Sleep(100);

            //        //ten nguoi dung
            //        //var fullname1 = "huydaica";
            //        //IWebElement btnFullName = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/div[3]/form/div[1]/div/label/input"));
            //        //btnFullName.Click();

            //        //IWebElement btnFullName = chromdriver.FindElement(By.Name("fullName"));
            //        //btnFullName.Clear();

            //        //btnFullName.SendKeys(fullname1);
            //        //var fullname = File.ReadAllLines("tendangnhap.txt");
            //        //foreach (var line in fullname)
            //        //{
            //        //    btnFullName.SendKeys(line);
            //        //    break;
            //        //}

            //        //var usernames = File.ReadAllLines("UserName.txt").ToList();
            //        //Random rnd = new Random();
            //        //int indexRandom = rnd.Next(0, usernames.Count);
            //        //Random rd = new Random();
            //        //int randomNumber = rd.Next(1, 10000000);

            //        //string username1 = usernames[indexRandom] + randomNumber;
            //        //IWebElement btnUserName = chromdriver.FindElement(By.Name("username"));
            //        //btnUserName.SendKeys(username1);
            //        //Thread.Sleep(100);

            //        //string passig1 = "anhyeuem90";
            //        //IWebElement btnpassig = chromdriver.FindElement(By.Name("password"));
            //        //btnpassig.SendKeys(passig1);
            //        //Thread.Sleep(100);

            //        //IWebElement btnSingUp = chromdriver.FindElement(By.XPath("//button[text()='Sign up']"));
            //        //btnSingUp.Click();
            //        //Thread.Sleep(TimeSpan.FromSeconds(50));

            //        //chromdriver.Navigate().GoToUrl("https://www.instagram.com/");

            //        //var uid = Regex.Match(chromdriver.PageSource, "NON_FACEBOOK_USER_ID\":\"(.*?)\"").Groups[1].Value;

            //        //if (uid == "0")
            //        //{
            //        //    btndangnhapbangfacebook = chromdriver.FindElement(By.XPath("//*[text()='Log in with Facebook']"));
            //        //    btndangnhapbangfacebook.Click();
            //        //    Thread.Sleep(100);
            //        //    btnConfirm = chromdriver.FindElement(By.Name("__CONFIRM__"));
            //        //    btnConfirm.Click();
            //        //    Thread.Sleep(10000);
            //        //}


            //        try
            //        {
            //            chromdriver.Navigate().GoToUrl("https://accountscenter.instagram.com/personal_info/contact_points/?contact_point_type=email&dialog_type=add_contact_point");

            //            HttpRequest http = new HttpRequest();
            //            http.Cookies = new CookieDictionary();
            //            http.UserAgent = Http.ChromeUserAgent();
            //            http.KeepAlive = false;
            //            http.AllowAutoRedirect = false;


            //            var (mailao, passmailao, token) = GetNewEmail(http);
            //            http.Authorization = "Bearer " + token;

            //            IWebElement btnmailao = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
            //            btnmailao.SendKeys(mailao);
            //            Thread.Sleep(1000);

            //            IWebElement tbnInsTaGram = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[3]/div/div[2]/div/div/div/div/label[2]/div[1]/div/div[3]/div/input"));
            //            tbnInsTaGram.Click();
            //            Thread.Sleep(1000);

            //            IWebElement next = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //            next.Click();
            //            Thread.Sleep(1000);

            //            Thread.Sleep(TimeSpan.FromMinutes(1));
            //            // code mail ao

            //            var messages = GetMailMessages(http);
            //            string codeMailAo = string.Empty;

            //            foreach (var message in messages)
            //            {

            //            }


            //            IWebElement enterconfirmationcode = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
            //            enterconfirmationcode.SendKeys(codeMailAo);
            //            Thread.Sleep(100);


            //            IWebElement next2 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //            next2.Click();
            //            Thread.Sleep(1000);

            //            int x = 0;
            //            while (x < 5)
            //            {
            //                try
            //                {
            //                    IWebElement close = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //                    close.Click();
            //                    Thread.Sleep(1000);
            //                    break;
            //                }
            //                catch { }
            //            }

            //            chromdriver.Navigate().GoToUrl("https://accountscenter.instagram.com/accounts/");

            //            IWebElement RemoveFacebook = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div/div/div[1]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/div/main/main/div[4]/div/div/div/div[1]/div/div[2]/div/div/a/div/div[1]/div/span/span"));
            //            RemoveFacebook.Click();
            //            Thread.Sleep(100);

            //            IWebElement RemoveAccount = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/div/div/div[1]/div/div[1]/div/div/div[2]/span"));
            //            RemoveAccount.Click();
            //            Thread.Sleep(100);

            //            IWebElement Continue = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
            //            Continue.Click();
            //            Thread.Sleep(100);

            //            IWebElement yesremove = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
            //            yesremove.Click();
            //            Thread.Sleep(TimeSpan.FromSeconds(15));

            //            chromdriver.Navigate().GoToUrl("https://www.instagram.com/");
            //            chromdriver.Manage().Cookies.DeleteAllCookies();
            //            //StreamWriter sw = new StreamWriter("Success.txt", true);
            //            //sw.WriteLine($"{username1}|{passig1}|{mailao}");
            //            //sw.Close();
            //        }
            //        catch { }

            //    }
            //    #endregion

            //}

            #endregion
            try
            {
                row.Cells["cStatus"].Value = "Reg IG";

                for (int i = 0; i < 5; i++)
                {
                    chromdriver.Navigate().GoToUrl("https://www.instagram.com/accounts/login");
                    Thread.Sleep(2000);
                    IWebElement btndangnhapbangfacebook = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div/div/div[1]/div[2]/div/form/div/div[5]"));
                    btndangnhapbangfacebook.Click();
                    Thread.Sleep(100);

                    IWebElement btnConfirm = chromdriver.FindElement(By.Name("__CONFIRM__"));
                    btnConfirm.Click();
                    Thread.Sleep(3000);


                    //if (!urlChrome.Contains("https://www.instagram.com/challenge/action"))
                    //{


                    //    row.Cells["cStatus"].Value = "IG xác minh sđt hoặc mail";
                    //    break;

                    //}

                    if (!urlChrome.Contains("https://www.instagram.com/fxcal/disclosur"))
                    {

                        IWebElement btnYesfinishadding = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div[2]/div/div/div/div/div[3]"));
                        btnYesfinishadding.Click();
                        Thread.Sleep(100);
                        var usernames = File.ReadAllLines("UserName.txt").ToList();
                        Random rnd = new Random();
                        int indexRandom = rnd.Next(0, usernames.Count);
                        var kytu = File.ReadAllLines("kytu.txt").ToList();
                        Random rnd1 = new Random();
                        int indexRandom1 = rnd1.Next(0, kytu.Count);
                        Random rd = new Random();
                        int randomNumber = rd.Next(1, 10000000);
                        // string name = usernames[indexRandom];

                        //     var fullname = chromdriver.FindElement(By.XPath("//input[@name='fullName']"));
                        //     var fullname = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/div[3]/form/div[1]/div/label/input"));
                        //fullname.Clear();
                        //Thread.Sleep(100);
                        //fullname.Clear();
                        //Thread.Sleep(100);

                        //var fullname152 = chromdriver.FindElements(By.XPath("//input[@name='fullName']"));
                        //fullname152[0].SendKeys(name);
                        //Thread.Sleep(5000);
                        //foreach ( var name in fullname1)
                        //{
                        //    break;
                        //}

                        string username1 = usernames[indexRandom] + kytu[indexRandom1] + randomNumber;
                        IWebElement btnUserName = chromdriver.FindElement(By.Name("username"));
                        btnUserName.SendKeys(username1);
                        Thread.Sleep(5000);

                        string passig1 = "anhyeuem90";
                        IWebElement btnpassig = chromdriver.FindElement(By.Name("password"));
                        btnpassig.SendKeys(passig1);
                        Thread.Sleep(5000);

                        IWebElement btnSingUp = null;
                        try
                        {
                            
                                btnSingUp = chromdriver.FindElement(By.XPath("//button[text()='Sign Up']"));
                                btnSingUp.Click();
                                Thread.Sleep(3000);
                          

                        }
                        catch 
                        {
                           
                                btnSingUp = chromdriver.FindElement(By.XPath("//button[text()='Sign up']"));
                                btnSingUp.Click();
                                Thread.Sleep(3000);
                          

                        }
                       

                        Thread.Sleep(TimeSpan.FromSeconds(30));

                        chromdriver.Navigate().GoToUrl("https://www.instagram.com/accounts/login");

                        var uid = Regex.Match(chromdriver.PageSource, "NON_FACEBOOK_USER_ID\":\"(.*?)\"").Groups[1].Value;

                        if (uid == "0")
                        {
                            btndangnhapbangfacebook = chromdriver.FindElement(By.XPath("//*[text()='Log in with Facebook']"));
                            btndangnhapbangfacebook.Click();
                            Thread.Sleep(100);
                            btnConfirm = chromdriver.FindElement(By.Name("__CONFIRM__"));
                            btnConfirm.Click();
                            Thread.Sleep(10000);
                        }

                        try
                        {
                            chromdriver.Navigate().GoToUrl("https://accountscenter.instagram.com/personal_info/contact_points/?contact_point_type=email&dialog_type=add_contact_point");

                            var httpRequest = new xNet.HttpRequest();
                            httpRequest.AllowAutoRedirect = true;
                            httpRequest.Cookies = new CookieDictionary();

                            string mailao = GetEmail(httpRequest);
                            IWebElement btnmailao = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
                            btnmailao.SendKeys(mailao);
                            Thread.Sleep(1000);

                            IWebElement tbnInsTaGram = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[3]/div/div[2]/div/div/div/div/label[2]/div[1]/div/div[3]/div/input"));
                            tbnInsTaGram.Click();
                            Thread.Sleep(1000);

                            IWebElement next = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next.Click();
                            Thread.Sleep(1000);

                            Thread.Sleep(TimeSpan.FromMinutes(1));
                            // code mail ao
                            string codemailao = GetCodeMail10p(httpRequest);


                            IWebElement enterconfirmationcode = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
                            enterconfirmationcode.SendKeys(codemailao);
                            Thread.Sleep(100);


                            IWebElement next2 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next2.Click();
                            Thread.Sleep(1000);

                            int x = 0;
                            while (x < 5)
                            {
                                try
                                {
                                    IWebElement close = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                                    close.Click();
                                    Thread.Sleep(1000);
                                    break;
                                }
                                catch { }
                            }

                            chromdriver.Navigate().GoToUrl("https://accountscenter.instagram.com/accounts/");
                            IWebElement RemoveFacebook = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div/div/div[1]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/div/main/main/div[4]/div/div/div/div[1]/div/div[2]/div/div/a/div/div[1]/div/span/span"));
                            RemoveFacebook.Click();
                            Thread.Sleep(100);

                            IWebElement RemoveAccount = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/div/div/div[1]/div/div[1]/div/div/div[2]/span"));
                            RemoveAccount.Click();
                            Thread.Sleep(100);

                            IWebElement Continue = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
                            Continue.Click();
                            Thread.Sleep(100);

                            IWebElement yesremove = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
                            yesremove.Click();
                            Thread.Sleep(TimeSpan.FromSeconds(15));


                            chromdriver.Navigate().GoToUrl("https://accountscenter.instagram.com/password_and_security/two_factor/");

                            IWebElement towfactor = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div"));
                            towfactor.Click();
                            Thread.Sleep(100);

                            IWebElement next1 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next1.Click();
                            Thread.Sleep(3000);


                            string code = null;
                            try
                            {
                                IWebElement macode2fa = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div[2]/div[4]/div/div/div[4]/div/div[2]/div/div/div[1]/span"));
                                code = macode2fa.Text;

                                Thread.Sleep(2000);
                            }
                            catch
                            {
                                IWebElement macode2fa1 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div[2]/div[4]/div/div/div[4]/div/div[2]/div/div/div[1]/span"));
                                code = macode2fa1.Text;
                                Thread.Sleep(2000);
                            }






                            try
                            {
                                var next11 = chromdriver.FindElements(By.XPath("//div[@role='button']"));
                                next11[10].Click();
                                Thread.Sleep(2000);


                            }
                            catch
                            {
                                var next18 = chromdriver.FindElements(By.XPath("//div[@role='button']"));
                                next18[17].Click();
                                Thread.Sleep(2000);
                            }

                            if (code != null)
                            {
                                var codema6so = GetCode(code);
                                try
                                {
                                    IWebElement nhapma2fa = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[5]/div[2]/div[1]/div/div/div[2]/div/div/div[1]/input"));
                                    nhapma2fa.SendKeys(codema6so);
                                    Thread.Sleep(2000);
                                }
                                catch
                                {
                                    IWebElement nhapma2fa1 = chromdriver.FindElement(By.XPath(" /html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div[1]/input"));
                                    nhapma2fa1.SendKeys(codema6so);
                                    Thread.Sleep(2000);
                                }

                            }

                            try
                            {
                                var next24 = chromdriver.FindElements(By.XPath("//div[@role='button']"));
                                next24[23].Click();
                                Thread.Sleep(2000);
                            }
                            catch
                            {
                                //                                                /html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[6]/div[3]/div/div/div/div/div/div/div/div
                                //                                               /html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[6]/div[3]/div/div/div/div/div/div/div
                                try
                                {
                                    var next14 = chromdriver.FindElements(By.XPath("//div[@role='button']"));
                                    next14[13].Click();
                                    Thread.Sleep(2000);
                                }
                                catch
                                {
                                    var next141 = chromdriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[6]/div[3]/div/div/div/div/div/div/div/div/div[1]/div/span/span"));
                                    next141.Click();
                                    Thread.Sleep(2000);
                                }



                            }
                            chromdriver.Navigate().GoToUrl("https://www.instagram.com/");
                            Thread.Sleep(2000);
                            chromdriver.Manage().Cookies.DeleteAllCookies();
                            StreamWriter sw = new StreamWriter("AccountIG.txt", true);
                            sw.WriteLine($"{username1}|{passig1}|{code}|{mailao}");
                            sw.Close();






                           





                        }
                        catch
                        {
                            row.Cells["cStatus"].Value = "spam iP";
                            break;

                        }
                    }
                }
            }
            catch { }

            

        }

        private void ReLogin(ChromeDriver chromdriver, DataGridViewRow row, string username, string password)
        {
            row.Cells["cStatus"].Value = "Login";

            IWebElement tbpass = null;
            try
            {
                tbpass = chromdriver.FindElement(By.Name("pass"));
                tbpass.SendKeys(password);
                Thread.Sleep(100);

                IWebElement btnlogin = chromdriver.FindElement(By.Name("login"));
                btnlogin.Click();
                Thread.Sleep(100);
                try
                {
                    var urlchrome = chromdriver.Url;
                    if (urlchrome.Contains("https://www.facebook.com/login/device-based/regular/login"))
                    {
                        chromdriver.Navigate().GoToUrl("https://www.facebook.com/");
                        row.Cells["cStatus"].Value = "Login";
                        IWebElement tbmai = chromdriver.FindElement(By.Name("email"));
                        tbmai.SendKeys(username);
                        Thread.Sleep(100);
                        IWebElement tbpass1 = chromdriver.FindElement(By.Name("pass"));
                        tbpass1.SendKeys(password);
                        Thread.Sleep(100);
                        IWebElement btnlogin1 = chromdriver.FindElement(By.Name("login"));
                        btnlogin1.Click();
                        Thread.Sleep(200);

                        try
                        {
                            IWebElement tbpass11 = null;
                            tbpass11 = chromdriver.FindElement(By.Name("pass"));
                            tbpass11.SendKeys(password);
                            Thread.Sleep(100);

                            IWebElement btnlogin11 = chromdriver.FindElement(By.Name("login"));
                            btnlogin11.Click();
                            Thread.Sleep(100);
                        }
                        catch { }
                     
                    }


                }
                catch 
                {
                    var urlchrome = chromdriver.Url;
                    if (urlchrome.Contains("https://www.facebook.com/recover/initiate"))
                    {
                        chromdriver.Navigate().GoToUrl("https://www.facebook.com/");
                        row.Cells["cStatus"].Value = "Login";
                        IWebElement tbmai = chromdriver.FindElement(By.Name("email"));
                        tbmai.SendKeys(username);
                        Thread.Sleep(100);
                        IWebElement tbpass1 = chromdriver.FindElement(By.Name("pass"));
                        tbpass1.SendKeys(password);
                        Thread.Sleep(100);
                        IWebElement btnlogin1 = chromdriver.FindElement(By.Name("login"));
                        btnlogin1.Click();
                        Thread.Sleep(200);

                        IWebElement tbpass11 = null;
                        tbpass11 = chromdriver.FindElement(By.Name("pass"));
                        tbpass11.SendKeys(password);
                        Thread.Sleep(100);

                        IWebElement btnlogin11 = chromdriver.FindElement(By.Name("login"));
                        btnlogin11.Click();
                        Thread.Sleep(100);
                    }



                }

            }
            catch { }


        }
        private void Loginvia2FA(DataGridViewRow row, string username, string password, string c2FA, string email, string passmail, string mailkhoiphuc)
        {
            // chrome thuong
            // var chromeDriver = Createchromedrive();

            // chrome an danh
            var chromeDriver = chromeDriver1andanh();
            chromeDriver.Navigate().GoToUrl("https://www.facebook.com/");
            Thread.Sleep(2000);

            row.Cells["cStatus"].Value = "Login";

            IWebElement tbmai = chromeDriver.FindElement(By.Name("email"));
            tbmai.SendKeys(username);
            Thread.Sleep(100);
            IWebElement tbpass = chromeDriver.FindElement(By.Name("pass"));
            tbpass.SendKeys(password);
            Thread.Sleep(100);
            IWebElement btnlogin = chromeDriver.FindElement(By.Name("login"));
            btnlogin.Click();
            Thread.Sleep(500);

            var urlChrome = chromeDriver.Url;
            if (urlChrome.Contains("https://www.facebook.com/login/?privacy_mutation_token="))
            {
                row.Cells["cStatus"].Value = "Sai pass";
            }


            //if (!urlChrome.Contains("https://www.facebook.com/login/?privacy_mutation_token="))
            //{
            IWebElement tbCode = null;
            try
            {
                row.Cells["cStatus"].Value = "2Fa Kiểu Cũ";
                var code2Fa = GetCode(c2FA);
                tbCode = chromeDriver.FindElement(By.Id("approvals_code"));
                tbCode.SendKeys(code2Fa);
                Thread.Sleep(200);

                var btnNext = chromeDriver.FindElement(By.Id("checkpointSubmitButton"));
                btnNext.Click();
                Thread.Sleep(100);

                var btnNext2 = chromeDriver.FindElement(By.Id("checkpointSubmitButton"));
                btnNext2.Click();

            }
            catch { }

            if (tbCode == null)
            {
                IWebElement btnThuCachKhac = null;
                try
                {
                    row.Cells["cStatus"].Value = "2Fa kiểu mới";
                    btnThuCachKhac = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div/div[4]/div/div"));
                    btnThuCachKhac.Click();
                    Thread.Sleep(300);

                    var rdUngDung = chromeDriver.FindElements(By.XPath("//input[@name='unused']"));
                    rdUngDung[1].Click();
                    Thread.Sleep(100);

                    var btnContinue = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                    btnContinue.Click();
                    Thread.Sleep(100);

                }
                catch { }
                try
                {
                    var code2Fa = GetCode(c2FA);

                    var tbCode2Fa = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div[3]/div/form/div/div/div/div/div[1]/input"));
                    tbCode2Fa.SendKeys(code2Fa);
                    Thread.Sleep(100);

                    var btnContinue2 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div[3]/div/div[1]/div/div"));
                    btnContinue2.Click();
                    Thread.Sleep(300);


                }
                catch { }

                try
                {
                    var btnTinCay = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[2]/div/div/div[3]/div[1]/div/div"));
                    btnTinCay.Click();
                }
                catch
                {
                    try
                    {
                        var btnTinCay = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[2]/div/div/div[3]/div[1]/div/div"));
                        btnTinCay.Click();

                    }
                    catch { }

                }
                Thread.Sleep(5000);
            }
            row.Cells["cStatus"].Value = "Log via ok";

            #region REGIG MailTM
            //    #region REG IG
            //    row.Cells["cStatus"].Value = "Reg IG";
            //    Thread.Sleep(5000);
            //    //for (int i = 0; i < 5; i++)
            //    //{
            //    //    chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");

            //    IWebElement btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div/div[5]"));
            //    btndangnhapbangfacebook.Click();
            //    Thread.Sleep(1000);

            //    IWebElement btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
            //    btnConfirm.Click();
            //    Thread.Sleep(5000);

            //    //    IWebElement btnYesfinishadding = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div[2]/div/div/div/div/div[3]"));
            //    //    btnYesfinishadding.Click();
            //    //    Thread.Sleep(100);

            //    //ten nguoi dung
            //    //var fullname1 = "huydaica";
            //    //IWebElement btnFullName = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/div[3]/form/div[1]/div/label/input"));
            //    //btnFullName.Click();

            //    //IWebElement btnFullName = chromdriver.FindElement(By.Name("fullName"));
            //    //btnFullName.Clear();

            //    //btnFullName.SendKeys(fullname1);
            //    //var fullname = File.ReadAllLines("tendangnhap.txt");
            //    //foreach (var line in fullname)
            //    //{
            //    //    btnFullName.SendKeys(line);
            //    //    break;
            //    //}

            //    //var usernames = File.ReadAllLines("UserName.txt").ToList();
            //    //Random rnd = new Random();
            //    //int indexRandom = rnd.Next(0, usernames.Count);
            //    //Random rd = new Random();
            //    //int randomNumber = rd.Next(1, 10000000);

            //    //string username1 = usernames[indexRandom] + randomNumber;
            //    //IWebElement btnUserName = chromeDriver.FindElement(By.Name("username"));
            //    //btnUserName.SendKeys(username1);
            //    //Thread.Sleep(100);

            //    //string passig1 = "anhyeuem90";
            //    //IWebElement btnpassig = chromeDriver.FindElement(By.Name("password"));
            //    //btnpassig.SendKeys(passig1);
            //    //Thread.Sleep(100);

            //    //IWebElement btnSingUp = chromeDriver.FindElement(By.XPath("//button[text()='Sign up']"));
            //    //btnSingUp.Click();
            //    //Thread.Sleep(TimeSpan.FromSeconds(50));

            //   // chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");

            //    //var uid = Regex.Match(chromeDriver.PageSource, "NON_FACEBOOK_USER_ID\":\"(.*?)\"").Groups[1].Value;

            //    //if (uid == "0")
            //    //{
            //    //    btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("//*[text()='Log in with Facebook']"));
            //    //    btndangnhapbangfacebook.Click();
            //    //    Thread.Sleep(100);
            //    //    btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
            //    //    btnConfirm.Click();
            //    //    Thread.Sleep(10000);
            //    //}


            //    try
            //        {
            //            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/personal_info/contact_points/?contact_point_type=email&dialog_type=add_contact_point");

            //            HttpRequest http = new HttpRequest();
            //            http.Cookies = new CookieDictionary();
            //            http.UserAgent = Http.ChromeUserAgent();
            //            http.KeepAlive = false;
            //            http.AllowAutoRedirect = false;


            //            var (mailao, passmailao, token) = GetNewEmail(http);
            //            http.Authorization = "Bearer " + token;

            //            IWebElement btnmailao = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
            //            btnmailao.SendKeys(mailao);
            //            Thread.Sleep(1000);

            //            IWebElement tbnInsTaGram = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[3]/div/div[2]/div/div/div/div/label[2]/div[1]/div/div[3]/div/input"));
            //            tbnInsTaGram.Click();
            //            Thread.Sleep(1000);

            //            IWebElement next = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //            next.Click();
            //            Thread.Sleep(1000);

            //            Thread.Sleep(TimeSpan.FromMinutes(1));
            //            // code mail ao

            //            var messages = GetMailMessages(http);
            //            string codeMailAo = string.Empty;

            //            foreach (var message in messages)
            //            {

            //            }


            //            IWebElement enterconfirmationcode = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
            //            enterconfirmationcode.SendKeys(codeMailAo);
            //            Thread.Sleep(100);


            //            IWebElement next2 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //            next2.Click();
            //            Thread.Sleep(1000);

            //            int x = 0;
            //            while (x < 5)
            //            {
            //                try
            //                {
            //                    IWebElement close = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //                    close.Click();
            //                    Thread.Sleep(1000);
            //                    break;
            //                }
            //                catch { }
            //            }

            //            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/accounts/");

            //            IWebElement RemoveFacebook = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div/div/div[1]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/div/main/main/div[4]/div/div/div/div[1]/div/div[2]/div/div/a/div/div[1]/div/span/span"));
            //            RemoveFacebook.Click();
            //            Thread.Sleep(100);

            //            IWebElement RemoveAccount = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/div/div/div[1]/div/div[1]/div/div/div[2]/span"));
            //            RemoveAccount.Click();
            //            Thread.Sleep(100);

            //            IWebElement Continue = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
            //            Continue.Click();
            //            Thread.Sleep(100);

            //            IWebElement yesremove = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
            //            yesremove.Click();
            //            Thread.Sleep(TimeSpan.FromSeconds(15));

            //            chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");
            //            chromeDriver.Manage().Cookies.DeleteAllCookies();
            //            //StreamWriter sw = new StreamWriter("Success.txt", true);
            //            //sw.WriteLine($"{username1}|{passig1}|{mailao}");
            //            //sw.Close();
            //        }
            //        catch { }




            //    //}
            //    #endregion
            //}

            #endregion


            try
            {
                row.Cells["cStatus"].Value = "Reg IG";

                for (int i = 0; i < 5; i++)
                {
                    chromeDriver.Navigate().GoToUrl("https://www.instagram.com/accounts/login");
                    Thread.Sleep(2000);
                    IWebElement btndangnhapbangfacebook = null;
                    try
                    {
                        btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div/div/div[1]/div[2]/div/form/div/div[5]"));
                        btndangnhapbangfacebook.Click();
                    }
                    catch
                    {
                        btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("//span[text()='Log in with Facebook']"));
                        btndangnhapbangfacebook.Click();

                    }

                    Thread.Sleep(100);

                    IWebElement btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
                    btnConfirm.Click();
                    Thread.Sleep(300);

                    //if (!urlChrome.Contains("https://www.instagram.com/challenge/action"))
                    //{
                    //    row.Cells["cStatus"].Value = "IG xác minh sđt hoặc mail";
                    //    break;
                    //}

                    if (!urlChrome.Contains("https://www.instagram.com/fxcal/disclosur"))
                    {

                        IWebElement btnYesfinishadding = null;
                        try
                        {
                            btnYesfinishadding = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div[2]/div/div/div/div/div[3]"));
                            btnYesfinishadding.Click();
                            Thread.Sleep(100);

                        }
                        catch
                        {
                            btnYesfinishadding = chromeDriver.FindElement(By.XPath("//button[text()='Yes, finish adding']"));
                            btnYesfinishadding.Click();
                            Thread.Sleep(100);


                        }

                        var usernames = File.ReadAllLines("UserName.txt").ToList();
                        Random rnd = new Random();
                        int indexRandom = rnd.Next(0, usernames.Count);
                        var kytu = File.ReadAllLines("kytu.txt").ToList();
                        Random rnd1 = new Random();
                        int indexRandom1 = rnd1.Next(0, kytu.Count);
                        Random rd = new Random();
                        int randomNumber = rd.Next(1, 10000000);
                        // string name = usernames[indexRandom];

                        //     var fullname = chromdriver.FindElement(By.XPath("//input[@name='fullName']"));
                        //     var fullname = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/div[3]/form/div[1]/div/label/input"));
                        //fullname.Clear();
                        //Thread.Sleep(100);
                        //fullname.Clear();
                        //Thread.Sleep(100);

                        //var fullname152 = chromdriver.FindElements(By.XPath("//input[@name='fullName']"));
                        //fullname152[0].SendKeys(name);
                        //Thread.Sleep(5000);
                        //foreach ( var name in fullname1)
                        //{
                        //    break;
                        //}

                        string username1 = usernames[indexRandom] + kytu[indexRandom1] + randomNumber;
                        IWebElement btnUserName = chromeDriver.FindElement(By.Name("username"));
                        btnUserName.SendKeys(username1);
                        Thread.Sleep(3000);

                        string passig1 = "anhyeuem90";
                        IWebElement btnpassig = chromeDriver.FindElement(By.Name("password"));
                        btnpassig.SendKeys(passig1);
                        Thread.Sleep(3000);

                        IWebElement btnSingUp = chromeDriver.FindElement(By.XPath("//button[text()='Sign up']"));
                        btnSingUp.Click();
                        Thread.Sleep(100);

                        Thread.Sleep(TimeSpan.FromSeconds(20));

                        chromeDriver.Navigate().GoToUrl("https://www.instagram.com/accounts/login");

                        try
                        {
                            IWebElement btnlogin14 = chromeDriver.FindElement(By.XPath("//div[text()='Log in']"));
                            btnlogin14.Click();


                        }
                        catch { }

                        var uid = Regex.Match(chromeDriver.PageSource, "NON_FACEBOOK_USER_ID\":\"(.*?)\"").Groups[1].Value;
                        Thread.Sleep(1000);
                        if (uid == "0")
                        {
                            btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("//*[text()='Log in with Facebook']"));
                            btndangnhapbangfacebook.Click();
                            Thread.Sleep(1000);

                            btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
                            btnConfirm.Click();
                            Thread.Sleep(1000);
                        }

                        try
                        {
                            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/personal_info/contact_points/?contact_point_type=email&dialog_type=add_contact_point");
                            chromeDriver.Navigate().Refresh();
                            Thread.Sleep(1000);
                            var httpRequest = new xNet.HttpRequest();
                            httpRequest.AllowAutoRedirect = true;
                            httpRequest.Cookies = new CookieDictionary();

                            string mailao = GetEmail(httpRequest);
                            IWebElement btnmailao = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
                            btnmailao.SendKeys(mailao);
                            Thread.Sleep(1000);

                            IWebElement tbnInsTaGram = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[3]/div/div[2]/div/div/div/div/label[2]/div[1]/div/div[3]/div/input"));
                            tbnInsTaGram.Click();
                            Thread.Sleep(100);

                            IWebElement next = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next.Click();
                            Thread.Sleep(100);

                            Thread.Sleep(TimeSpan.FromMinutes(1));
                            // code mail ao
                            string codemailao = GetCodeMail10p(httpRequest);


                            IWebElement enterconfirmationcode = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
                            enterconfirmationcode.SendKeys(codemailao);
                            Thread.Sleep(100);


                            IWebElement next2 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next2.Click();
                            Thread.Sleep(100);

                            int x = 0;
                            while (x < 5)
                            {
                                try
                                {
                                    IWebElement close = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                                    close.Click();
                                    Thread.Sleep(100);
                                    break;
                                }
                                catch { }
                            }

                            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/accounts/");
                            IWebElement RemoveFacebook = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div/div/div[1]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/div/main/main/div[4]/div/div/div/div[1]/div/div[2]/div/div/a/div/div[1]/div/span/span"));
                            RemoveFacebook.Click();
                            Thread.Sleep(100);

                            IWebElement RemoveAccount = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/div/div/div[1]/div/div[1]/div/div/div[2]/span"));
                            RemoveAccount.Click();
                            Thread.Sleep(100);

                            IWebElement Continue = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
                            Continue.Click();
                            Thread.Sleep(100);

                            IWebElement yesremove = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
                            yesremove.Click();
                            Thread.Sleep(TimeSpan.FromSeconds(10));


                            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/password_and_security/two_factor/");

                            IWebElement towfactor = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div"));
                            towfactor.Click();
                            Thread.Sleep(100);

                            IWebElement next1 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next1.Click();
                            Thread.Sleep(2000);

                            string code = null;
                            try
                            {
                                IWebElement macode2fa = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div[2]/div[4]/div/div/div[4]/div/div[2]/div/div/div[1]/span"));
                                code = macode2fa.Text;
                                Thread.Sleep(2000);
                            }
                            catch
                            {
                                IWebElement macode2fa1 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div[2]/div[4]/div/div/div[4]/div/div[2]/div/div/div[1]/span"));
                                code = macode2fa1.Text;
                                Thread.Sleep(2000);
                            }

                            try
                            {
                                var next11 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                                next11[10].Click();
                                Thread.Sleep(100);

                            }
                            catch
                            {
                                var next18 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                                next18[17].Click();
                                Thread.Sleep(100);
                            }

                            if (code != null)
                            {
                                var codema6so = GetCode(code);
                                Thread.Sleep(1000);
                                try
                                {
                                    IWebElement nhapma2fa = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[5]/div[2]/div[1]/div/div/div[2]/div/div/div[1]/input"));
                                    nhapma2fa.SendKeys(codema6so);
                                    Thread.Sleep(1000);
                                }
                                catch
                                {
                                    IWebElement nhapma2fa1 = chromeDriver.FindElement(By.XPath(" /html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div[1]/input"));
                                    nhapma2fa1.SendKeys(codema6so);
                                    Thread.Sleep(1000);
                                }

                            }

                            var next101 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[4]/div[3]/div/div/div/div/div/div/div/div/div[1]/div/span//span[text()='Next']"));
                            next101.Click();
                            Thread.Sleep(3000);

                            #region
                            //var next14 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                            //next14[13].Click();
                            //Thread.Sleep(2000);


                            //    try
                            //    {
                            //        var next24 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                            //        next24[23].Click();
                            //        Thread.Sleep(2000);

                            //    }catch 
                            //    {
                            //        var next8 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                            //        next8[7].Click();
                            //        Thread.Sleep(2000);

                            //    }
                            #endregion

                            chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");
                            Thread.Sleep(2000);
                            chromeDriver.Manage().Cookies.DeleteAllCookies();
                            StreamWriter sw = new StreamWriter("AccountIG.txt", true);
                            sw.WriteLine($"{username1}|{passig1}|{code}|{mailao}");
                            sw.Close();

                        }
                        catch
                        {
                            row.Cells["cStatus"].Value = "spam iP";
                            break;

                        }
                    }
                }
            }
            catch { }



        }
        private void Loginvia2FA1(DataGridViewRow row, string username, string password, string c2FA, string email, string passmail , string mailkhoiphuc)
        {

            // var chromeDriver = Createchromedrive();

            var chromeDriver = chromeDriver1andanh();
            chromeDriver.Navigate().GoToUrl("https://www.facebook.com/");
            Thread.Sleep(2000);

            row.Cells["cStatus"].Value = "Login";

            IWebElement tbmai = chromeDriver.FindElement(By.Name("email"));
            tbmai.SendKeys(username);
            Thread.Sleep(1000);
            IWebElement tbpass = chromeDriver.FindElement(By.Name("pass"));
            tbpass.SendKeys(password);
            Thread.Sleep(1000);
            IWebElement btnlogin = chromeDriver.FindElement(By.Name("login"));
            btnlogin.Click();
            Thread.Sleep(5000);

            var urlChrome = chromeDriver.Url;
            if (urlChrome.Contains("https://www.facebook.com/login/?privacy_mutation_token="))
            {
                row.Cells["cStatus"].Value = "Sai pass";
            }
            

            //if (!urlChrome.Contains("https://www.facebook.com/login/?privacy_mutation_token="))
            //{
            IWebElement tbCode = null;
            try
            {
                row.Cells["cStatus"].Value = "2Fa Kiểu Cũ";
                var code2Fa = GetCode(c2FA);
                tbCode = chromeDriver.FindElement(By.Id("approvals_code"));
                tbCode.SendKeys(code2Fa);
                Thread.Sleep(1000);

                var btnNext = chromeDriver.FindElement(By.Id("checkpointSubmitButton"));
                btnNext.Click();
                Thread.Sleep(5000);

                var btnNext2 = chromeDriver.FindElement(By.Id("checkpointSubmitButton"));
                btnNext2.Click();

            }
            catch { }

            if (tbCode == null)
            {
                IWebElement btnThuCachKhac = null;
                try
                {
                    row.Cells["cStatus"].Value = "2Fa kiểu mới";
                    btnThuCachKhac = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div/div[4]/div/div"));
                    btnThuCachKhac.Click();
                    Thread.Sleep(3000);

                    var rdUngDung = chromeDriver.FindElements(By.XPath("//input[@name='unused']"));
                    rdUngDung[1].Click();
                    Thread.Sleep(1000);

                    var btnContinue = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                    btnContinue.Click();
                    Thread.Sleep(5000);

                }
                catch { }
                try
                {
                    var code2Fa = GetCode(c2FA);

                    var tbCode2Fa = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div[3]/div/form/div/div/div/div/div[1]/input"));
                    tbCode2Fa.SendKeys(code2Fa);
                    Thread.Sleep(100);

                    var btnContinue2 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div[3]/div/div[1]/div/div"));
                    btnContinue2.Click();
                    Thread.Sleep(3000);


                }
                catch { }

                try
                {
                    var btnTinCay = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[2]/div/div/div[3]/div[1]/div/div"));
                    btnTinCay.Click();
                }
                catch
                {
                    try
                    {
                        var btnTinCay = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div[2]/div/div/div[3]/div[1]/div/div"));
                        btnTinCay.Click();

                    }
                    catch { }

                }
                Thread.Sleep(5000);
            }
            row.Cells["cStatus"].Value = "Log via ok";

            #region REGIG MailTM
            //    #region REG IG
            //    row.Cells["cStatus"].Value = "Reg IG";
            //    Thread.Sleep(5000);
            //    //for (int i = 0; i < 5; i++)
            //    //{
            //    //    chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");

            //    IWebElement btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div/div[5]"));
            //    btndangnhapbangfacebook.Click();
            //    Thread.Sleep(1000);

            //    IWebElement btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
            //    btnConfirm.Click();
            //    Thread.Sleep(5000);

            //    //    IWebElement btnYesfinishadding = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div[2]/div/div/div/div/div[3]"));
            //    //    btnYesfinishadding.Click();
            //    //    Thread.Sleep(100);

            //    //ten nguoi dung
            //    //var fullname1 = "huydaica";
            //    //IWebElement btnFullName = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/div[3]/form/div[1]/div/label/input"));
            //    //btnFullName.Click();

            //    //IWebElement btnFullName = chromdriver.FindElement(By.Name("fullName"));
            //    //btnFullName.Clear();

            //    //btnFullName.SendKeys(fullname1);
            //    //var fullname = File.ReadAllLines("tendangnhap.txt");
            //    //foreach (var line in fullname)
            //    //{
            //    //    btnFullName.SendKeys(line);
            //    //    break;
            //    //}

            //    //var usernames = File.ReadAllLines("UserName.txt").ToList();
            //    //Random rnd = new Random();
            //    //int indexRandom = rnd.Next(0, usernames.Count);
            //    //Random rd = new Random();
            //    //int randomNumber = rd.Next(1, 10000000);

            //    //string username1 = usernames[indexRandom] + randomNumber;
            //    //IWebElement btnUserName = chromeDriver.FindElement(By.Name("username"));
            //    //btnUserName.SendKeys(username1);
            //    //Thread.Sleep(100);

            //    //string passig1 = "anhyeuem90";
            //    //IWebElement btnpassig = chromeDriver.FindElement(By.Name("password"));
            //    //btnpassig.SendKeys(passig1);
            //    //Thread.Sleep(100);

            //    //IWebElement btnSingUp = chromeDriver.FindElement(By.XPath("//button[text()='Sign up']"));
            //    //btnSingUp.Click();
            //    //Thread.Sleep(TimeSpan.FromSeconds(50));

            //   // chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");

            //    //var uid = Regex.Match(chromeDriver.PageSource, "NON_FACEBOOK_USER_ID\":\"(.*?)\"").Groups[1].Value;

            //    //if (uid == "0")
            //    //{
            //    //    btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("//*[text()='Log in with Facebook']"));
            //    //    btndangnhapbangfacebook.Click();
            //    //    Thread.Sleep(100);
            //    //    btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
            //    //    btnConfirm.Click();
            //    //    Thread.Sleep(10000);
            //    //}


            //    try
            //        {
            //            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/personal_info/contact_points/?contact_point_type=email&dialog_type=add_contact_point");

            //            HttpRequest http = new HttpRequest();
            //            http.Cookies = new CookieDictionary();
            //            http.UserAgent = Http.ChromeUserAgent();
            //            http.KeepAlive = false;
            //            http.AllowAutoRedirect = false;


            //            var (mailao, passmailao, token) = GetNewEmail(http);
            //            http.Authorization = "Bearer " + token;

            //            IWebElement btnmailao = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
            //            btnmailao.SendKeys(mailao);
            //            Thread.Sleep(1000);

            //            IWebElement tbnInsTaGram = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[3]/div/div[2]/div/div/div/div/label[2]/div[1]/div/div[3]/div/input"));
            //            tbnInsTaGram.Click();
            //            Thread.Sleep(1000);

            //            IWebElement next = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //            next.Click();
            //            Thread.Sleep(1000);

            //            Thread.Sleep(TimeSpan.FromMinutes(1));
            //            // code mail ao

            //            var messages = GetMailMessages(http);
            //            string codeMailAo = string.Empty;

            //            foreach (var message in messages)
            //            {

            //            }


            //            IWebElement enterconfirmationcode = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
            //            enterconfirmationcode.SendKeys(codeMailAo);
            //            Thread.Sleep(100);


            //            IWebElement next2 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //            next2.Click();
            //            Thread.Sleep(1000);

            //            int x = 0;
            //            while (x < 5)
            //            {
            //                try
            //                {
            //                    IWebElement close = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
            //                    close.Click();
            //                    Thread.Sleep(1000);
            //                    break;
            //                }
            //                catch { }
            //            }

            //            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/accounts/");

            //            IWebElement RemoveFacebook = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div/div/div[1]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/div/main/main/div[4]/div/div/div/div[1]/div/div[2]/div/div/a/div/div[1]/div/span/span"));
            //            RemoveFacebook.Click();
            //            Thread.Sleep(100);

            //            IWebElement RemoveAccount = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/div/div/div[1]/div/div[1]/div/div/div[2]/span"));
            //            RemoveAccount.Click();
            //            Thread.Sleep(100);

            //            IWebElement Continue = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
            //            Continue.Click();
            //            Thread.Sleep(100);

            //            IWebElement yesremove = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
            //            yesremove.Click();
            //            Thread.Sleep(TimeSpan.FromSeconds(15));

            //            chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");
            //            chromeDriver.Manage().Cookies.DeleteAllCookies();
            //            //StreamWriter sw = new StreamWriter("Success.txt", true);
            //            //sw.WriteLine($"{username1}|{passig1}|{mailao}");
            //            //sw.Close();
            //        }
            //        catch { }




            //    //}
            //    #endregion
            //}

            #endregion


            try
            {
                row.Cells["cStatus"].Value = "Reg IG";

                for (int i = 0; i < 5; i++)
                {
                    chromeDriver.Navigate().GoToUrl("https://www.instagram.com/accounts/login");
                    Thread.Sleep(2000);
                    IWebElement btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div/div/div[1]/div[2]/div/form/div/div[5]/button/span[2]"));
                    btndangnhapbangfacebook.Click();
                    Thread.Sleep(100);

                    IWebElement btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
                    btnConfirm.Click();
                    Thread.Sleep(3000);

                    //if (!urlChrome.Contains("https://www.instagram.com/challenge/action"))
                    //{
                    //    row.Cells["cStatus"].Value = "IG xác minh sđt hoặc mail";
                    //    break;
                    //}

                    if (!urlChrome.Contains("https://www.instagram.com/fxcal/disclosur"))
                    {

                        IWebElement btnYesfinishadding = chromeDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/div[2]/div/div/div/div/div[3]/button"));
                        btnYesfinishadding.Click();
                        Thread.Sleep(100);
                        var usernames = File.ReadAllLines("UserName.txt").ToList();
                        Random rnd = new Random();
                        int indexRandom = rnd.Next(0, usernames.Count);
                        var kytu = File.ReadAllLines("kytu.txt").ToList();
                        Random rnd1 = new Random();
                        int indexRandom1 = rnd1.Next(0, kytu.Count);
                        Random rd = new Random();
                        int randomNumber = rd.Next(1, 10000000);

                        // string name = usernames[indexRandom];

                        //     var fullname = chromdriver.FindElement(By.XPath("//input[@name='fullName']"));
                        //     var fullname = chromdriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/div/div[1]/div[1]/div/div[3]/form/div[1]/div/label/input"));
                        //fullname.Clear();
                        //Thread.Sleep(100);
                        //fullname.Clear();
                        //Thread.Sleep(100);

                        //var fullname152 = chromdriver.FindElements(By.XPath("//input[@name='fullName']"));
                        //fullname152[0].SendKeys(name);
                        //Thread.Sleep(5000);
                        //foreach ( var name in fullname1)
                        //{
                        //    break;
                        //}

                        string username1 = usernames[indexRandom] + kytu[indexRandom1] + randomNumber;
                        IWebElement btnUserName = chromeDriver.FindElement(By.Name("username"));
                        btnUserName.SendKeys(username1);
                        Thread.Sleep(5000);

                        string passig1 = "anhyeuem90";
                        IWebElement btnpassig = chromeDriver.FindElement(By.Name("password"));
                        btnpassig.SendKeys(passig1);
                        Thread.Sleep(5000);

                        IWebElement btnSingUp = null;

                        try
                        {
                            btnSingUp = chromeDriver.FindElement(By.XPath("//button[text()='Sign Up']"));
                            btnSingUp.Click();
                            Thread.Sleep(3000);

                        }
                        catch
                        {
                            btnSingUp = chromeDriver.FindElement(By.XPath("//button[text()='Sign up']"));
                            btnSingUp.Click();
                            Thread.Sleep(3000);

                        }

                        Thread.Sleep(TimeSpan.FromSeconds(30));

                        chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");

                        var uid = Regex.Match(chromeDriver.PageSource, "NON_FACEBOOK_USER_ID\":\"(.*?)\"").Groups[1].Value;

                        if (uid == "0")
                        {
                            btndangnhapbangfacebook = chromeDriver.FindElement(By.XPath("//*[text()='Log in with Facebook']"));
                            btndangnhapbangfacebook.Click();
                            Thread.Sleep(100);
                            btnConfirm = chromeDriver.FindElement(By.Name("__CONFIRM__"));
                            btnConfirm.Click();
                            Thread.Sleep(10000);
                        }

                        try
                        {
                            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/personal_info/contact_points/?contact_point_type=email&dialog_type=add_contact_point");

                            var httpRequest = new xNet.HttpRequest();
                            httpRequest.AllowAutoRedirect = true;
                            httpRequest.Cookies = new CookieDictionary();

                            string mailao = GetEmail(httpRequest);
                            IWebElement btnmailao = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
                            btnmailao.SendKeys(mailao);
                            Thread.Sleep(1000);

                            IWebElement tbnInsTaGram = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div[3]/div/div[2]/div/div/div/div/label[2]/div[1]/div/div[3]/div/input"));
                            tbnInsTaGram.Click();
                            Thread.Sleep(1000);

                            IWebElement next = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next.Click();
                            Thread.Sleep(1000);

                            Thread.Sleep(TimeSpan.FromMinutes(1));
                            // code mail ao
                            string codemailao = GetCodeMail10p(httpRequest);

                            IWebElement enterconfirmationcode = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[3]/div[2]/div[4]/div[2]/div/div/div/div/div[1]/input"));
                            enterconfirmationcode.SendKeys(codemailao);
                            Thread.Sleep(100);

                            IWebElement next2 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next2.Click();
                            Thread.Sleep(1000);

                            int x = 0;
                            while (x < 5)
                            {
                                try
                                {
                                    IWebElement close = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                                    close.Click();
                                    Thread.Sleep(1000);
                                    break;
                                }
                                catch { }
                            }

                            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/accounts/");
                            IWebElement RemoveFacebook = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div/div/div[1]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/div/main/main/div[4]/div/div/div/div[1]/div/div[2]/div/div/a/div/div[1]/div/span/span"));
                            RemoveFacebook.Click();
                            Thread.Sleep(100);

                            IWebElement RemoveAccount = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div/div/div/div/div[1]/div/div[1]/div/div/div[2]/span"));
                            RemoveAccount.Click();
                            Thread.Sleep(100);

                            IWebElement Continue = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
                            Continue.Click();
                            Thread.Sleep(100);

                            IWebElement yesremove = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[4]/div[3]/div/div/div/div/div[1]/div[1]/div/div/div[1]/div/span/span"));
                            yesremove.Click();
                            Thread.Sleep(TimeSpan.FromSeconds(15));

                            chromeDriver.Navigate().GoToUrl("https://accountscenter.instagram.com/password_and_security/two_factor/");

                            IWebElement towfactor = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div"));
                            towfactor.Click();
                            Thread.Sleep(100);

                            IWebElement next1 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[2]/div/div[4]/div[3]/div/div/div/div/div/div/div"));
                            next1.Click();
                            Thread.Sleep(3000);
                            string code = null;
                            try
                            {
                                IWebElement macode2fa = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div[2]/div[4]/div/div/div[4]/div/div[2]/div/div/div[1]/span"));
                                code = macode2fa.Text;

                                Thread.Sleep(2000);
                            }
                            catch
                            {
                                IWebElement macode2fa1 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div[2]/div[4]/div/div/div[4]/div/div[2]/div/div/div[1]/span"));
                                code = macode2fa1.Text;
                                Thread.Sleep(2000);
                            }
                            try
                            {
                                var next11 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                                next11[10].Click();
                                Thread.Sleep(2000);


                            }
                            catch
                            {
                                var next18 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                                next18[17].Click();
                                Thread.Sleep(2000);
                            }

                            if (code != null)
                            {
                                var codema6so = GetCode(code);
                                try
                                {
                                    IWebElement nhapma2fa = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[5]/div[2]/div[1]/div/div/div[2]/div/div/div[1]/input"));
                                    nhapma2fa.SendKeys(codema6so);
                                    Thread.Sleep(2000);
                                }
                                catch
                                {
                                    IWebElement nhapma2fa1 = chromeDriver.FindElement(By.XPath(" /html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[3]/div[2]/div[4]/div/div/div[2]/div/div/div[1]/input"));
                                    nhapma2fa1.SendKeys(codema6so);
                                    Thread.Sleep(2000);
                                }

                            }



                            try
                            {
                                var next24 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                                next24[23].Click();
                                Thread.Sleep(2000);
                            }
                            catch
                            {
                                //                                                /html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[6]/div[3]/div/div/div/div/div/div/div/div
                                //                                               /html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[6]/div[3]/div/div/div/div/div/div/div
                                try
                                {
                                    var next14 = chromeDriver.FindElements(By.XPath("//div[@role='button']"));
                                    next14[13].Click();
                                    Thread.Sleep(2000);
                                }
                                catch
                                {
                                    var next141 = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[2]/div/div/div/div/div/div[4]/div/div[6]/div[3]/div/div/div/div/div/div/div/div/div[1]/div/span/span"));
                                    next141.Click();
                                    Thread.Sleep(2000);
                                }



                            }

                            chromeDriver.Navigate().GoToUrl("https://www.instagram.com/");
                            Thread.Sleep(2000);
                            chromeDriver.Manage().Cookies.DeleteAllCookies();
                            StreamWriter sw = new StreamWriter("AccountIG.txt", true);
                            sw.WriteLine($"{username1}|{passig1}|{code}|{mailao}");
                            sw.Close();


                        }
                        catch
                        {
                            row.Cells["cStatus"].Value = "spam iP";
                            break;

                        }
                    }
                }
            }
            catch { }



        }
        

       const string baseURL = "https://api.mail.tm";

        private (string, string, string) GetNewEmail(HttpRequest http)
        {
            var domainsResponse = http.Get($"{baseURL}/domains").ToString();

            JObject jobject = JObject.Parse(domainsResponse);
            JArray domainArr = jobject["hydra:member"].ToObject<JArray>();

            var domain = domainArr[new Random().Next(0, domainArr.Count)]["domain"].ToString();
            var username = (GenerateRandomUsername() + "@" + domain).ToLower();
            var password = "Honghai!123";
            var payload =
            new
            {
                address = username,
                password = password
            };

            var payloadJson = JsonConvert.SerializeObject(payload);

            var registerResponse = http.Post($"{baseURL}/accounts", payloadJson, "application/json").ToString();

            var tokenResponse = http.Post($"{baseURL}/token", payloadJson, "application/json").ToString();

            var token = JObject.Parse(tokenResponse)["token"].ToString();

            return (username, password, token);
        }

        static string GenerateRandomUsername()
        {
            string[] adjectives = { "Fast", "Clever", "Brave", "Mighty", "Silent" };
            string[] nouns = { "Lion", "Eagle", "Shark", "Panther", "Wolf" };

            Random random = new Random();
            string randomAdjective = adjectives[random.Next(adjectives.Length)];
            string randomNoun = nouns[random.Next(nouns.Length)];
            int randomNumber = random.Next(100000, 999999);

            return randomAdjective + randomNoun + randomNumber;
        }


        static JArray GetMailMessages(HttpRequest http)
        {
            var mailMessagesResponse = http.Get($"{baseURL}/messages").ToString();
            return JObject.Parse(mailMessagesResponse)["hydra:member"].ToObject<JArray>();
        }
        private string GetEmail(HttpRequest httpRequest)
        {
            var emailSrc = httpRequest.Get("https://10minutemail.net/address.api.php").ToString();
            return Regex.Match(emailSrc, "mail_get_mail\":\"(.*?)\"").Groups[1].Value;
        }

        private string GetCodeMail10p(HttpRequest httpRequest)
        {
            var getMailId = httpRequest.Get("https://10minutemail.net/address.api.php").ToString();

            JObject jobject = JObject.Parse(getMailId);
            var maiList = jobject["mail_list"];
            var lstMailitem = maiList.ToObject<JArray>();

            var lstMailId = new Dictionary<string, string>();
            foreach (JObject mailitem in lstMailitem)
            {
                lstMailId.Add(mailitem["from"].ToString(), mailitem["mail_id"].ToString());
            }

            var mailId = lstMailId.Where(x => x.Key.Contains("instagram")).FirstOrDefault().Value;
            var readMail = httpRequest.Get("https://10minutemail.net/mail.api.php?mailid=" + mailId).ToString();
            var body = Regex.Match(readMail, "body\":\\[{\"(.*?)}").Groups[1].Value;
            var stringCode = Regex.Match(readMail, "confirmation code:(.*?)}").Groups[1].Value;

            return Regex.Match(stringCode, @"\d{6}").ToString();
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
            options.AddArguments("incognito","--disable-3d-apis", "--disable-background-networking", "--disable-bundled-ppapi-flash", "--disable-client-side-phishing-detection", "--disable-default-apps", "--disable-hang-monitor", "--disable-prompt-on-repost", "--disable-sync", "--disable-webgl", "--enable-blink-features=ShadowDOMV0", "--enable-logging", "--disable-notifications", "--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage", "--disable-web-security", "--disable-rtc-smoothness-algorithm", "--disable-webrtc-hw-decoding", "--disable-webrtc-hw-encoding", "--disable-webrtc-multiple-routes", "--disable-webrtc-hw-vp8-encoding", "--enforce-webrtc-ip-permission-check", "--force-webrtc-ip-handling-policy", "--ignore-certificate-errors", "--disable-infobars", "--disable-blink-features=\"BlockCredentialedSubresources\"", "--disable-popup-blocking");
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
        public string MaskEmail(string email)
        {
            int atIndex = email.IndexOf('@');
            if (atIndex <= 1)
            {
                throw new ArgumentException("Email address is too short to mask properly.");
            }

            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex);

            // Keep the first character and the last character of the local part
            string maskedLocalPart = localPart[0] + new string('*', localPart.Length - 2) + localPart[localPart.Length - 1];

            return maskedLocalPart + domainPart;
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
