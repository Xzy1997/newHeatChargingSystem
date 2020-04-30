using HeatChargingSystem.api;
using HeatChargingSystem.model.response;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeatChargingSystem.view.UserControls
{
    /// <summary>
    /// DictrictControl.xaml 的交互逻辑
    /// </summary>
    public partial class DictrictControl : UserControl
    {
        public DictrictControl()
        {
            InitializeComponent();
        }

        public  List<Region> province = new List<Region>();
        public  List<Region> city = new List<Region>();
        public  List<Region> county = new List<Region>();
        public List<Region> street = new List<Region>();
        public List<Region> village = new List<Region>();


        private void com_province_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            city.Clear();
            county.Clear();
            street.Clear();
            village.Clear();
            if (com_province.SelectedValue == null)
                return;
            Region s = (Region)com_province.SelectedValue;

            //获取城市列表
            com_city.ItemsSource = null;
            city = new ApiImpl().GetRegion("3", s.id);
            if(city!=null)
            {
                com_city.ItemsSource = city;
                com_city.SelectedIndex = 0;
            }            
        }

        private void com_city_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            county.Clear();
            street.Clear();
            village.Clear();
            if (com_city.SelectedValue == null)
                return;
            Region s = (Region)com_city.SelectedValue;
            ////获取区/县列表
            county = new ApiImpl().GetRegion("4",s.id);
            if (county != null)
            {
                com_county.ItemsSource = null;
                com_county.ItemsSource = county;
                com_county.SelectedIndex = 0;
            }
            
        }
        private void com_county_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            street.Clear();
            village.Clear();
            if (com_county.SelectedValue == null)
                return;
            Region s = (Region)com_county.SelectedValue;
            ////获取区/县列表
            street = new ApiImpl().GetRegion("4", s.id);
            if (street != null)
            {
                com_street.ItemsSource = null;
                com_street.ItemsSource = street;
                //com_street.SelectedIndex = 0;
            }
        }

        private void com_street_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            village.Clear();
            if (com_street.SelectedValue == null)
                return;
            Region s = (Region)com_street.SelectedValue;
            ////获取区/县列表
            village = new ApiImpl().GetRegion("4", s.id);
            if (village != null)
            {
                com_village.ItemsSource = null;
                com_village.ItemsSource = street;
              //  com_county.SelectedIndex = 0;
            }
        }


        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            //获取省级列表
            List<Region> response = new ApiImpl().GetRegion("2", "1");
            if (response != null)
            {
                com_province.ItemsSource = response;
            }


        }


    }
    public class struct1
    {
        public string id{ get; set; }
        public string name { get; set; }
        public struct1(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
