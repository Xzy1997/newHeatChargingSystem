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

       
        
        private string _province;
        public string Province
        {
            get
            {
                return _province;
            }
            set { _province = value; }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;

            }
            set {  _city=value; }
        }

        private string _county;
        public string County
        {
            get
            {
                return _county;
            }
            set { _county=value; }
        }
       
 

        public string ProvinceID
        {
            get;
            set;
        }

        public static ArrayList province = new ArrayList();
        public static ArrayList city = new ArrayList();
        public static ArrayList county = new ArrayList();

        public static JObject district;
 
        public void GrertDic1()
        {
            //获取省级列表
            // List<controller_type> response = new ApiImpl().GetRegion("1","123");

            province.Add(new struct1("0","浙江"));
        }

        private void com_province_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            //city.Clear();
            //county.Clear();
            //if (com_province.SelectedValue == null)
            //    return;
            //JProperty jp = (JProperty)com_province.SelectedValue;
            //string id = jp.Name.Substring(0, 2);

            //ProvinceID = id;

            ////获取城市列表
            //com_city.ItemsSource = null;

            //com_city.ItemsSource = city;
            //com_city.SelectedIndex = 0;
        }

        private void com_city_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //county.Clear();
            //if (com_city.SelectedValue == null)
            //    return;
            //JProperty jp = (JProperty)com_city.SelectedValue;
            //string id = jp.Name.Substring(2, 2);


            ////获取区/县列表
            //com_county.ItemsSource = null;
            //com_county.ItemsSource = county;
            //com_county.SelectedIndex = 0;
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
          //  GrertDic();
            GrertDic1();

            com_province.ItemsSource = province;
            com_city.ItemsSource = province;
            com_county.ItemsSource = county;

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
