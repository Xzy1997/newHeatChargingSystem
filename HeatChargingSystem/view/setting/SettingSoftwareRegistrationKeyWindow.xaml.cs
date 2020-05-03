﻿using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeatChargingSystem.view
{
    /// <summary>
    /// AddSecretKeyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingSoftwareRegistrationKeyWindow : WindowX
    {
        public SettingSoftwareRegistrationKeyWindow()
        {
            InitializeComponent();
        }

        string RegistrationKey;
        private void VerifySignature(object sender, RoutedEventArgs e)
        {

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                //获取公钥
                rsa.FromXmlString(getPubkey());
                //获取并处理唯一特征值
                byte[] source = ASCIIEncoding.ASCII.GetBytes(getGUID());

                RSAPKCS1SignatureDeformatter decry = new RSAPKCS1SignatureDeformatter(rsa);
                decry.SetHashAlgorithm("SHA1");

                //格式化唯一特征值
                SHA1Managed sha = new SHA1Managed();
                byte[] arr = sha.ComputeHash(source);
                TextRange tr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                RegistrationKey = tr.Text.Trim();
                try
                {
                    byte[] signed = Convert.FromBase64String(RegistrationKey);
                    if (decry.VerifySignature(arr, signed))
                    {
                        MessageBox.Show("注册成功！");
                        writeRK();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("注册失败！请输入正确的注册码！");
                        //this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("注册失败！请输入正确的注册码！");
                    return ;
                }
                

                


            }
        }
        private void CloseWindowEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <returns></returns>
        private string getPubkey()
        {
            string pubkey = string.Empty;
            try
            {

                string path = string.Empty;
                path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                path += "pubkey.xml";

                using (StreamReader sr = new StreamReader(path))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        pubkey += line;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return pubkey.Replace(" ", "");
        }

        private void writeRK()
        {
            string fileName = "RegistrationKey.txt";
            using (StreamWriter s = File.CreateText(fileName))
            {
                s.WriteLine(RegistrationKey);
                s.Close();

            }
        }

        /// <summary>
        /// 获取GUID码
        /// </summary>
        /// <returns></returns>
        private string getGUID()
        {
            string guid = string.Empty;
            try
            {
                string fileName = "guid.txt";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        guid += line;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return guid.Replace(" ", "");
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
