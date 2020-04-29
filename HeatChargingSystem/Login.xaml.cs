using HeatChargingSystem.api;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Serialization;
using HeatChargingSystem.model;

namespace HeatChargingSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Login : WindowX
    {
        public Login()
        {
            InitializeComponent();
            this.Loaded += LoginWindow_Loaded;
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }


        //局部变量
        ObservableCollection<UserInfo> listUserInfo=new ObservableCollection<UserInfo>();
        LoginInfoXmlHelper loginInfoXmlHelper = new LoginInfoXmlHelper();
        LoginViewModel _viewmodel;
        int feedBack = 0;
        System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker
        {
            WorkerSupportsCancellation = true,//支持取消后台操作
        };
        bool cancellationOperation = false;

        void bw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int userID = 0;
            //反馈
            feedBack = _viewmodel.Verification(ref userID);
        }
        void bw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            //取消后台登录
            if (this.cancellationOperation)
            {
                this.cancellationOperation = false;//恢复以前状态
                return;//截断
            }

            switch (feedBack)
            {
                case 1:
                    //登录成功
                    //获取新的登录信息
                   var userInfo = new UserInfo
                    {
                        AutomaticLogon = (bool)this.checkBox2.IsChecked,
                        RememberPwd = (bool)this.checkBox1.IsChecked,
                        UserName = AccountNmaeTxt.Text.Trim(),
                        UserPwd = PwdTxt.Password.Trim(),
                        };
                    if (!(bool)this.checkBox1.IsChecked)
                    {
                        userInfo.UserPwd = "";
                    }
                    listUserInfo.Remove(listUserInfo.FirstOrDefault(u => u.UserName == userInfo.UserName));
                    listUserInfo.Insert(0, userInfo);
                    //保存登录信息
                    loginInfoXmlHelper.CreateXml(listUserInfo.ToList());
                    HomeWindow home = new HomeWindow();
                    home.Show();
                    this.Close();   
                    break;
                case 0:
                    MessageBox.Show("登录失败！", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case -1:
                    System.Windows.MessageBox.Show("数据库未连接！", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    break;
                case -2:
                    System.Windows.MessageBox.Show("用户名不能为空！", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    break;
                case -3:
                    System.Windows.MessageBox.Show("密码不能为空！", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    break;
                case -4:
                    System.Windows.MessageBox.Show("密码含有特殊字符！", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    break;
                case -5:
                    System.Windows.MessageBox.Show("用户名不正确！", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    break;
                case -6:
                    System.Windows.MessageBox.Show("密码不正确！", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    break;
                default:
                    MessageBox.Show("未知错误！", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
        void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewmodel = new LoginViewModel();
            this.DataContext = _viewmodel;

            //获取登录信息
            listUserInfo = loginInfoXmlHelper.GetLoginInfo();
            CollectionViewSource ListUserInfoViewSource = (CollectionViewSource)this.FindResource("ListUserInfoViewSource");
            ListUserInfoViewSource.Source = listUserInfo;
                

                //计时器 为登录框添加数据计时执行
                var timer1 = new System.Timers.Timer
                {
                    Interval = 100,
                };
                timer1.Elapsed += new System.Timers.ElapsedEventHandler(theout1);//到达时间的时候执行事件；
                timer1.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；   
                timer1.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
                //计时器 自动登录做准备的数据计时执行
                var timer2 = new System.Timers.Timer
                {
                    Interval = 400,
                };
                timer2.Elapsed += new System.Timers.ElapsedEventHandler(theout2);
                timer2.AutoReset = false;
                timer2.Enabled = true;
            
        }

        /// <summary>
        /// 为登录框添加数据计时执行
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void theout1(object source, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                //显示上次登录
                this.AccountNmaeTxt.SelectedIndex = 0;
            }));
        }
        /// <summary>
        /// 自动登录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void theout2(object source, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                //显示上次登录
                var userLogin = listUserInfo.FirstOrDefault();
                if (userLogin != null)
                {
                    if (userLogin.AutomaticLogon)//自动登录
                    {
                        //触发登录
                        this.LoginBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, this.LoginBtn));
                    }
                }
            }));
        }
        private void LoginEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ButtonHelper.GetIsWaiting(this.LoginBtn))
            {               
                this.cancellationOperation = true;
                bw.CancelAsync();//取消后台操作
                ButtonHelper.SetIsWaiting(this.LoginBtn, false);
            }
            else
                ButtonHelper.SetIsWaiting(this.LoginBtn, true);
            this.LoginBtn.IsEnabled = true;
            try
            {               
                bw.RunWorkerAsync();
            }
            catch (Exception)
            {
                //报错无视
            }
        }

        private void MinWindowEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void CloseWindowEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void clear(object sender, System.Windows.RoutedEventArgs e)
        {
           // AccountNmaeTxt.Items.Clear();???
            PwdTxt.Clear();
        }
        /// <summary>
        /// 用户类用于保存记录
        /// </summary>
        public class UserInfo
        {
            public string UserName { get; set; }
            public string UserPwd { get; set; }
            /// <summary>
            /// 是否自动登录
            /// </summary>
            //[System.ComponentModel.DefaultValue(false)]
            public bool AutomaticLogon { get; set; }
            /// <summary>
            /// 是否记住密码
            /// </summary>
            //[System.ComponentModel.DefaultValue(false)]
            public bool RememberPwd { get; set; }
        }
        /// <summary>
        /// 加密类 
        /// </summary>
        internal class CryptInfo
        {
            /// <summary>
            /// 私有构造方法禁止实例化该类型
            /// </summary>
            public CryptInfo() { }

            /// <summary>
            /// 对输入的字符串进行加密，并获取加密后的字符串
            /// </summary>
            /// <param name="text">输入的字符串</param>
            /// <returns></returns>
            public string GetEncrypt(string text)
            {
                return this.Encrypt(text);
            }

            /// <summary>
            /// 加密 对用户名和密码进行加密的方法
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private string Encrypt(string text)
            {
                Rijndael crypt = Rijndael.Create();
                byte[] key = new byte[32] { 0XA6, 0X7D, 0XE1, 0X3F, 0X35, 0X0E, 0XE1, 0XA9, 0X83, 0XA5, 0X62, 0XAA, 0X7A, 0XAE, 0X79, 0X98, 0XA7, 0X33, 0X49, 0XFF, 0XE6, 0XAE, 0XBF, 0X8D, 0X8D, 0X20, 0X8A, 0X49, 0X31, 0X3A, 0X12, 0X40 };

                byte[] iv = new byte[16] { 0XF8, 0X8B, 0X01, 0XFB, 0X08, 0X85, 0X9A, 0XA4, 0XBE, 0X45, 0X28, 0X56, 0X03, 0X42, 0XF6, 0X19 };
                crypt.Key = key;
                crypt.IV = iv;

                MemoryStream ms = new MemoryStream();

                ICryptoTransform transtormEncode = new ToBase64Transform();
                //Base64编码
                CryptoStream csEncode = new CryptoStream(ms, transtormEncode, CryptoStreamMode.Write);

                CryptoStream csEncrypt = new CryptoStream(csEncode, crypt.CreateEncryptor(), CryptoStreamMode.Write);

                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                byte[] rawData = enc.GetBytes(text);

                csEncrypt.Write(rawData, 0, rawData.Length);
                csEncrypt.FlushFinalBlock();

                byte[] encryptedData = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(encryptedData, 0, (int)ms.Length);

                return enc.GetString(encryptedData);
            }

        }

        /// <summary>
        /// 解密类
        /// </summary>
        /// 
        internal class DecryptInfo
        {
            /// <summary>
            /// 私有化构造函数不允许外部实例化
            /// </summary>
            public DecryptInfo()
            { }


            /// <summary>
            /// 对输入的字符串进行加密,并获取解密后的字符串
            /// </summary>
            /// <param name="text">输入的字符串</param>
            /// <returns></returns>
            public string GetDecrypte(string text)
            {
                return this.Decrypt(text);
            }

            /// <summary>
            /// 解密方法 对用户名和密码进行解密
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private string Decrypt(string text)
            {
                Rijndael crypt = Rijndael.Create();
                byte[] key = new byte[32] { 0XA6, 0X7D, 0XE1, 0X3F, 0X35, 0X0E, 0XE1, 0XA9, 0X83, 0XA5, 0X62, 0XAA, 0X7A, 0XAE, 0X79, 0X98, 0XA7, 0X33, 0X49, 0XFF, 0XE6, 0XAE, 0XBF, 0X8D, 0X8D, 0X20, 0X8A, 0X49, 0X31, 0X3A, 0X12, 0X40 };
                byte[] iv = new byte[16] { 0XF8, 0X8B, 0X01, 0XFB, 0X08, 0X85, 0X9A, 0XA4, 0XBE, 0X45, 0X28, 0X56, 0X03, 0X42, 0XF6, 0X19 };
                crypt.Key = key;
                crypt.IV = iv;

                MemoryStream ms = new MemoryStream();
                CryptoStream csDecrypt = new CryptoStream(ms, crypt.CreateDecryptor(), CryptoStreamMode.Write);
                ICryptoTransform transformDecode = new FromBase64Transform();
                CryptoStream csDecode = new CryptoStream(csDecrypt, transformDecode, CryptoStreamMode.Write);

                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                byte[] rawData = enc.GetBytes(text);
                csDecode.Write(rawData, 0, rawData.Length);
                csDecode.FlushFinalBlock();

                byte[] decryptedData = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(decryptedData, 0, (int)ms.Length);

                return (enc.GetString(decryptedData));
            }
        }
        public class LoginInfoXmlHelper
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="userName"></param>
            public LoginInfoXmlHelper()
            {
                string appStartPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                StringBuilder builder = new StringBuilder();
                builder.Append(appStartPath);
                builder.Append("\\LoginFile\\");
                builder.Append("\\XML\\");
                System.IO.DirectoryInfo directoryInfo = new DirectoryInfo(builder.ToString());
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();//创建一个
                }
                builder.Append("LoginInfoXml.xml");
                this.fullFilePath = builder.ToString();
            }

            #region 成员
            /// <summary>
            /// 文件全路径
            /// </summary>
            string fullFilePath;
            /// <summary>
            /// 加密
            /// </summary>
            CryptInfo cryptInfo = new CryptInfo();
            /// <summary>
            /// 解密
            /// </summary>
            DecryptInfo decryptInfo = new DecryptInfo();

            #endregion

            /// <summary>
            /// 获取用户登录信息
            /// </summary>
            /// <returns></returns>
            public ObservableCollection<UserInfo> GetLoginInfo()
            {
                var loginInfo = new List<UserInfo>();
                if (InfoFile.Exists)
                {
                    XmlSerializer xml = new XmlSerializer(loginInfo.GetType());
                    using (Stream s = InfoFile.OpenRead())
                    {
                        loginInfo = xml.Deserialize(s) as List<UserInfo>;
                    }
                }
                var tList = new ObservableCollection<UserInfo>();
                foreach (var item in loginInfo)
                {
                    tList.Add(new UserInfo
                    {
                        AutomaticLogon = item.AutomaticLogon,
                        RememberPwd = item.RememberPwd,
                        UserName = this.decryptInfo.GetDecrypte(item.UserName),
                        UserPwd = this.decryptInfo.GetDecrypte(item.UserPwd),
                    });
                }
                return tList;
            }

            /// <summary>
            /// 文件方式
            /// </summary>
            private FileInfo InfoFile
            {
                get
                {
                    return new FileInfo(fullFilePath);
                }
            }

            /// <summary>
            /// 生成Xml文件
            /// </summary>
            /// <param name="loginInfo"></param>
            private void Create_Xml(List<UserInfo> loginInfo)
            {
                var tList = new List<UserInfo>();
                foreach (var item in loginInfo)
                {
                    tList.Add(new UserInfo
                    {
                        AutomaticLogon = item.AutomaticLogon,
                        RememberPwd = item.RememberPwd,
                        UserName = this.cryptInfo.GetEncrypt(item.UserName),
                        UserPwd = this.cryptInfo.GetEncrypt(item.UserPwd),
                    });
                }
                XmlSerializer xmls = new XmlSerializer(tList.GetType());
                if (InfoFile.Exists)
                {
                    InfoFile.Delete();
                }
                using (Stream s = InfoFile.OpenWrite())
                {
                    xmls.Serialize(s, tList);
                    //s.Close();
                }
            }

            /// <summary>
            /// 生成Xml文件
            /// </summary>
            public void CreateXml(List<UserInfo> loginInfo)
            {
                Create_Xml(loginInfo);
            }


        }

        /// <summary>
        /// 下拉框文本输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is ComboBox && _viewmodel != null)
            {
                var cmb = sender as ComboBox;
                var userinfo = listUserInfo.FirstOrDefault(u => u.UserName == AccountNmaeTxt.Text);
                if (userinfo == null)
                {
                    this.PwdTxt.Password = "";
                    this.checkBox1.RaiseEvent(new RoutedEventArgs(CheckBox.UncheckedEvent, this.checkBox1));
                }
                else
                {
                    UserInfoRecond(userinfo);
                }
            }
        }
        /// <summary>
        /// 记录UserInfo信息
        /// </summary>
        /// <param name="userinfo"></param>
        private void UserInfoRecond(UserInfo userinfo)
        {
            this.AccountNmaeTxt.Text = userinfo.UserName;
            this.PwdTxt.Password = userinfo.UserPwd;
            this.checkBox1.RaiseEvent(new RoutedEventArgs(CheckBox.UncheckedEvent, this.checkBox1));
            if (userinfo.AutomaticLogon)
            {
                this.checkBox2.RaiseEvent(new RoutedEventArgs(CheckBox.CheckedEvent, this.checkBox2));
            }
            else if (!userinfo.RememberPwd)
            {
                this.checkBox1.RaiseEvent(new RoutedEventArgs(CheckBox.UncheckedEvent, this.checkBox1));
            }
            else if (userinfo.RememberPwd)
            {
                this.checkBox1.RaiseEvent(new RoutedEventArgs(CheckBox.CheckedEvent, this.checkBox1));
            }
        }

    }
}
