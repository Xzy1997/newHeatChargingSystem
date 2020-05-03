using HeatChargingSystem.api;
using HeatChargingSystem.model;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeatChargingSystem.view.homeAction
{
    /// <summary>
    /// HomeUserChargeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeAddUserActionWindow : WindowX
    {
        public HomeAddUserActionWindow()
        {
            InitializeComponent();
        }

       
        private void add_btn(object sender, RoutedEventArgs e)
        {
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }

        private void WindowX_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AddUserViewModel();
        }
    }
}
