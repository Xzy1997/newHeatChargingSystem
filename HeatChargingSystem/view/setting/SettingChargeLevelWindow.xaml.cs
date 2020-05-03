using HeatChargingSystem.api;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
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
    public partial class SettingChargeLevelWindow : WindowX
    {
        private long id;
        public SettingChargeLevelWindow()
        {
            InitializeComponent();
        }

        private void WindowX_Loaded(object sender, RoutedEventArgs e)
        {
            ResponseInformationModel response = new ApiImpl().GetInformation();
            if (response != null)
            {
                this.ChargeStandard.Text = Convert.ToString(response.ChargeStandard);
                this.ChargeDays.Text = Convert.ToString(response.ChargeDays);
            }
        }

        private void UpdateCahrgeStandardEvent(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ChargeStandard.Text) && !string.IsNullOrEmpty(this.ChargeDays.Text))
            {
                RequestInformationModel request = new RequestInformationModel();
                request.Id = id;
                request.ChargeStandard = Convert.ToDouble(this.ChargeStandard.Text);
                request.ChargeDays = Convert.ToInt32(this.ChargeDays.Text);
                BaseResponseModel responseModel = new ApiImpl().UpdateChargeStandar(request);
                if (responseModel.code.Equals("200"))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
            else
            {
                MessageBox.Show("输入数据有误");
            }
        }

        private void CancleEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
