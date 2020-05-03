using HeatChargingSystem.api;
using HeatChargingSystem.model.response;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class ResetPwdWindow : WindowX
    {
        public ResetPwdWindow()
        {
            InitializeComponent();
        }

        private void UpdatePassWordEvent(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(OldPwd.Password) && !string.IsNullOrEmpty(NewPwd1.Password) && string.IsNullOrEmpty(NewPwd2.Password))
            {
                if (NewPwd2.Password == NewPwd1.Password)
                {
                    if (NewPwd1.Password == OldPwd.Password)
                    {
                        MessageBox.Show("新密码和旧密码不可以一样，请重新输入");
                        NewPwd1.Password = string.Empty;
                        NewPwd2.Password = string.Empty;
                        OldPwd.Password = string.Empty;
                    }
                    else
                    {
                        BaseResponseModel baseResponse = new ApiImpl().ResetPwd(OldPwd.Password, NewPwd1.Password);
                        if (baseResponse.code.Equals("200"))
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(baseResponse.msg);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("新密码输入不一致，请重新输入");
                    NewPwd1.Password = string.Empty;
                    NewPwd2.Password = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("请完整输入信息");
            }
        }

        private void CancleEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
