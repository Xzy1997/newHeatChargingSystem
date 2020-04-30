using HeatChargingSystem.api;
using HeatChargingSystem.model.request;
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
            this.Loaded += HomeAddUserActionWindow_Loaded;
        }

        class controllerType1
        {
            public int id { get; set; }
            public string name { get; set; }
            public controllerType1(int id, string name)
            {
                this.id = id;
                this.name = name;

            }
        }
        class userType
        {
            public int id { get; set; }
            public string name { get; set; }
            public userType(int id, string name)
            {
                this.id = id;
                this.name = name;

            }
        }
       //0 民用；1商用；2：共建；3：其他类型
        private void HomeAddUserActionWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<controllerType1> list = new List<controllerType1>();
            list.Add(new controllerType1(0, "xx阀"));
            list.Add(new controllerType1(1, "xx阀"));
            list.Add(new controllerType1(2, "xx阀"));
            this.controllerType.ItemsSource = list;


            //List<userType> list1 = new List<userType>();
            //list1.Add(new userType(0, "民用"));
            //list1.Add(new userType(1, "商用"));
            //list1.Add(new userType(2, "共建"));
            //list1.Add(new userType(3, "其他类型"));
            //this.usertype.ItemsSource = list1;
            Dictionary<int, string> response = new ApiImpl().GetAllDictionary();
            List < userType > list1 = new List<userType>();
            if (response != null)
            {
                foreach (var i in response)
                {
                    userType x = new userType(i.Key, i.Value);
                    list1.Add(x);
                }
            }
           

            this.usertype.ItemsSource = list1;

        }

        private void add_btn(object sender, RoutedEventArgs e)
        {
            var userId = this.userId.Text.Trim();
            var phone = this.phone.Text.Trim();
            var usertype = this.usertype.SelectedIndex.ToString();          
            var area = this.area.Text.Trim();
            var controllerType = this.controllerType.SelectedIndex.ToString();
            var controllerCode = this.controllerCode.Text.Trim();
            var build = this.build.Text.Trim();
            var unit = this.unit.Text.Trim();
            var room = this.room.Text.Trim();

            ResponseUserInfoModel request = new ResponseUserInfoModel();
            request.name = userId;
            request.phone = phone;
            request.userType = usertype;
            request.area = area;
            request.controllerType = controllerType;
            request.controllerCode = controllerCode;
            request.build = build;
            request.unit = unit;
            request.room = room;

            request.hourseCode = "11";
            request.provice = "11";
            request.city = "11"; ;
            request.county = "11"; ;
            request.street = "11"; ;
            request.village = "11"; ;

            BaseResponseModel response = new ApiImpl().AddUser(request);
            if (response != null)
            {
                //System.Windows.MessageBox.Show("添加成功", "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                System.Windows.MessageBox.Show(response.msg.ToString(), "系统提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
