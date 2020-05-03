using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
    public partial class SettingCardPortWindow : WindowX
    {
        private string[] coms;
        public SettingCardPortWindow()
        {
            InitializeComponent();

        }

        private string[] getSerialPortName()
        {
            List<string> ports = new List<string>();
            foreach (string vPortName in SerialPort.GetPortNames())
            {
                ports.Add(vPortName);
            }
            return ports.ToArray();
        }

        private void WindowX_Loaded(object sender, RoutedEventArgs e)
        {
            coms = getSerialPortName();
            
        }

        private void init()
        {
            initComboBox();
            List<string> comList = coms.ToList();
            if (comList.FindIndex(item => item.Equals(AppConfigMoel.ComPortName)) != -1)
            {
                comPort.SelectedIndex = comList.FindIndex(item => item.Equals(AppConfigMoel.ComPortName));
            }
            else 
            {
                comPort.Items.Add(AppConfigMoel.ComPortName);
                comPort.SelectedIndex = comList.Count;
            }
        }

        private void initComboBox() 
        {
            foreach (string a in coms) 
            {
                comPort.Items.Add(a);
            }
        }

        private void SaveComPortEvent(object sender, RoutedEventArgs e)
        {
            AppConfigMoel.ComPortName = string.IsNullOrEmpty((string)this.comPort.SelectedValue)?"1": (string)this.comPort.SelectedValue;
        }
    }
}
