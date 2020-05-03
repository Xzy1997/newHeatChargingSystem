using HeatChargingSystem.model;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace HeatChargingSystem.view.homeAction
{
    /// <summary>
    /// HomeUserChargeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeChargeAllActionWindow : WindowX
    {
        public HomeChargeAllActionWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 缴费信息编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditChargeInfoEvent(object sender, RoutedEventArgs e)
        {
            EditChargeCountWindow window = new EditChargeCountWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 打印缴费信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintChargeInfoEvent(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 打印用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PringtUserInfoEvent(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 搜索缴费信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchChargeAllInfoEvent(object sender, RoutedEventArgs e)
        {

        }

        private void WindowX_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ChargeAllViewModel();
        }
    }
}
