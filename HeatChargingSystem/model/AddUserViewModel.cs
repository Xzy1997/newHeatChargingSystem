using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HeatChargingSystem.api;
using HeatChargingSystem.model.response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model
{
    public class AddUserViewModel : ViewModelBase
    {

        private ResponseUserInfoModel userInfoModel;

        private ObservableCollection<ComboBoxModel> userType;
        private ObservableCollection<ComboBoxModel> controllerType;
        private ObservableCollection<ComboBoxModel> provicneCB;
        private ObservableCollection<ComboBoxModel> cityCB;
        private ObservableCollection<ComboBoxModel> contoryCB;
        private ObservableCollection<ComboBoxModel> streetCB;
        private ObservableCollection<ComboBoxModel> villageCB;




        //<i:Interaction.Triggers>
        //               <i:EventTrigger EventName = "SelectionChanged" >
        //                   < i:InvokeCommandAction
        //                        Command = "{Binding DataContext.GetCityCommand,RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=ComboBox}}"
        //                       CommandParameter="{Binding Path=SelectionBoxItem,RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=ComboBox}}" />
        //               </i:EventTrigger>
        //           </i:Interaction.Triggers>

        private void GetEndRegion(ComboBoxModel p)
        {
            if (p == null)
            {
                return;
            }
            userInfoModel.Village = p.Name;
        }
        private void GetVillage(ComboBoxModel p)
        {
            VillageCB = null;
            if (p == null)
            {
                return;
            }
            userInfoModel.Street = p.Name;
            List<ComboBoxModel> data = new ApiImpl().GetVillageRegion(p.Id.ToString());
            if (data != null)
            {
                VillageCB = new ObservableCollection<ComboBoxModel>(data);
            }
        }

        private void GetStreet(ComboBoxModel p)
        {
            StreetCB = null;
            VillageCB = null;
            if (p == null)
            {

                return;
            }
            userInfoModel.County = p.Name;
            List<ComboBoxModel> data = new ApiImpl().GetStreetRegion(p.Id.ToString());
            if (data != null)
            {
                StreetCB = new ObservableCollection<ComboBoxModel>(data);
            }
        }

        private void GetContory(ComboBoxModel p)
        {
            ContoryCB = null;
            StreetCB = null;
            VillageCB = null;
            if (p == null)
            {

                return;
            }
            userInfoModel.City = p.Name;
            List<ComboBoxModel> data = new ApiImpl().GetCountryRegion(p.Id.ToString());
            if (data != null)
            {
                ContoryCB = new ObservableCollection<ComboBoxModel>(data);
            }
        }

        private void GetCity(ComboBoxModel p)
        {
            CityCB = null;
            ContoryCB = null;
            StreetCB = null;
            VillageCB = null;
            if (p == null)
            {
                return;
            }
            userInfoModel.Provice = p.Name;
            List<ComboBoxModel> data = new ApiImpl().GetCityRegion(p.Id.ToString());
            if (data != null)
            {
                CityCB = new ObservableCollection<ComboBoxModel>(data);
            }
        }

        public RelayCommand SaveUserInfo { get; set; }
        public RelayCommand<ComboBoxModel> ProvicneChangeCommand { get; set; }
        public RelayCommand<ComboBoxModel> CityChangeCommand { get; set; }
        public RelayCommand<ComboBoxModel> ContoryChangeCommand { get; set; }
        public RelayCommand<ComboBoxModel> StreetCommand { get; set; }
        public RelayCommand<ComboBoxModel> VillageChangeCommand { get; set; }

        public ResponseUserInfoModel UserInfoModel { get => userInfoModel; set => Set(ref userInfoModel, value); }
        public ObservableCollection<ComboBoxModel> UserType { get => userType; set => Set(ref userType, value); }
        public ObservableCollection<ComboBoxModel> ControllerType { get => controllerType; set => Set(ref controllerType, value); }
        public ObservableCollection<ComboBoxModel> ProvicneCB { get => provicneCB; set => Set(ref provicneCB, value); }
        public ObservableCollection<ComboBoxModel> CityCB { get => cityCB; set => Set(ref cityCB, value); }
        public ObservableCollection<ComboBoxModel> ContoryCB { get => contoryCB; set => Set(ref contoryCB, value); }
        public ObservableCollection<ComboBoxModel> StreetCB { get => streetCB; set => Set(ref streetCB, value); }
        public ObservableCollection<ComboBoxModel> VillageCB { get => villageCB; set => Set(ref villageCB, value); }


        public AddUserViewModel()
        {
            UserInfoModel = new ResponseUserInfoModel();
            UserInfoModel.Name = string.Empty;
            UserType = new ObservableCollection<ComboBoxModel>(new ApiImpl().GetDictionary("用户类型"));
            ControllerType = new ObservableCollection<ComboBoxModel>(new ApiImpl().GetDictionary("阀门类型"));
            List<ComboBoxModel> data = new ApiImpl().GetProvinceRegion();
            ProvicneChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetCity(p); });
            CityChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetContory(p); });
            ContoryChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetStreet(p); });
            StreetCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetVillage(p); });
            VillageChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetEndRegion(p); });
            provicneCB = new ObservableCollection<ComboBoxModel>(data);
            SaveUserInfo = new RelayCommand(Save);
        }

        private void Save()
        {
            if (UserInfoModel.IsValidated)
            {
                new ApiImpl().AddUser(userInfoModel);
            }
        }


        //SelectedValue="{Binding Path=userInfoModel.Provice}" 
        //    SelectedValue="{Binding Path=UserInfoModel.City}"
        //    SelectedValue="{Binding Path=UserInfoModel.County}"
        //    SelectedValue="{Binding Path=UserInfoModel.Street}"
        //    SelectedValue="{Binding Path=UserInfoModel.Village}"
    }
}
