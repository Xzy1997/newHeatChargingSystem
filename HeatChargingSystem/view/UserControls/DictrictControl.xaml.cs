//using HeatChargingSystem.api;
//using HeatChargingSystem.model.response;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace HeatChargingSystem.view.UserControls
//{
//    /// <summary>
//    /// DictrictControl.xaml 的交互逻辑
//    /// </summary>
//    public partial class DictrictControl : UserControl
//    {
//        public DictrictControl()
//        {
//            InitializeComponent();
//        }

//        public List<Region> province = new List<Region>();
//        public List<Region> city = new List<Region>();
//        public List<Region> county = new List<Region>();
//        public List<Region> street = new List<Region>();
//        public List<Region> village = new List<Region>();


//        private void com_province_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
//        {
//            //获取城市列表
//            city = new ApiImpl().GetCityRegion(com_province.SelectedValue.ToString());
//            if (city != null)
//            {
//                com_city.ItemsSource = city;
//            }
//        }

//        private void com_city_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
//        {
//                com_county.ItemsSource = null;
//            if (string.IsNullOrEmpty(com_city.SelectedValue.ToString()))
//            {
//                return;
//            }
//            ////获取区/县列表
//            county = new ApiImpl().GetCountryRegion(com_city.SelectedValue.ToString());
//            if (county != null)
//            {
//                com_county.ItemsSource = county;
//            }

//        }
//        private void com_county_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
//        {
//                com_street.ItemsSource = null;
//            if (string.IsNullOrEmpty(com_county.SelectedValue.ToString()))
//            {

//                return;
//            }
//            ////获取区/县列表
//            street = new ApiImpl().GetStreetRegion(com_county.SelectedValue.ToString());
//            if (street != null)
//            {
//                com_street.ItemsSource = street;
//            }
//        }

//        private void com_street_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
//        {
//                com_village.ItemsSource = null;
//            if (string.IsNullOrEmpty(com_street.SelectedValue.ToString()))
//            {
//                return;
//            }
//            ////获取区/县列表
//            village = new ApiImpl().GetVillageRegion(com_street.SelectedValue.ToString());
//            if (village != null)
//            {
//                com_village.ItemsSource = street;
//            }
//        }


//        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
//        {
//            com_province.ItemsSource = province;
//            com_city.ItemsSource = city;
//            com_county.ItemsSource = county;
//            com_street.ItemsSource = street;
//            com_village.ItemsSource = village;

//            //获取省级列表
//            //List<Region> response = new ApiImpl().GetProvinceRegion();
//            if (response != null)
//            {
//                province = response;
//                com_province.ItemsSource = province;
//            }

//        }


//    }
//}
