using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HeatChargingSystem.api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model
{
    public class ChargeAllViewModel : ViewModelBase
    {
        private ObservableCollection<ComboBoxModel> provicneCB;
        private ObservableCollection<ComboBoxModel> cityCB;
        private ObservableCollection<ComboBoxModel> contoryCB;
        private ObservableCollection<ComboBoxModel> streetCB;
        private ObservableCollection<ComboBoxModel> villageCB;
        private ObservableCollection<ComboBoxModel> chargeCB;
        public ObservableCollection<ComboBoxModel> ProvicneCB { get => provicneCB; set => Set(ref provicneCB, value); }
        public ObservableCollection<ComboBoxModel> CityCB { get => cityCB; set => Set(ref cityCB, value); }
        public ObservableCollection<ComboBoxModel> ContoryCB { get => contoryCB; set => Set(ref contoryCB, value); }
        public ObservableCollection<ComboBoxModel> StreetCB { get => streetCB; set => Set(ref streetCB, value); }
        public ObservableCollection<ComboBoxModel> VillageCB { get => villageCB; set => Set(ref villageCB, value); }
        public ObservableCollection<ComboBoxModel> ChargeCB { get => chargeCB; set => Set(ref chargeCB, value); }
        public RelayCommand<ComboBoxModel> ProvicneChangeCommand { get; set; }
        public RelayCommand<ComboBoxModel> CityChangeCommand { get; set; }
        public RelayCommand<ComboBoxModel> ContoryChangeCommand { get; set; }
        public RelayCommand<ComboBoxModel> StreetCommand { get; set; }
        public RelayCommand<ComboBoxModel> VillageChangeCommand { get; set; }

        public ChargeAllViewModel()
        {
            List<ComboBoxModel> data = new ApiImpl().GetProvinceRegion();
            ProvicneChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetCity(p); });
            CityChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetContory(p); });
            ContoryChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetStreet(p); });
            StreetCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetVillage(p); });
            VillageChangeCommand = new RelayCommand<ComboBoxModel>(x => { ComboBoxModel p = x as ComboBoxModel; GetEndRegion(p); });
            provicneCB = new ObservableCollection<ComboBoxModel>(data);
            ChargeCB = new ObservableCollection<ComboBoxModel>(new ApiImpl().GetDictionary("缴费类型"));
        }

        private void GetEndRegion(ComboBoxModel p)
        {
            if (p == null)
            {
                return;
            }
        }
        private void GetVillage(ComboBoxModel p)
        {
            VillageCB = null;
            if (p == null)
            {
                return;
            }
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
            List<ComboBoxModel> data = new ApiImpl().GetCityRegion(p.Id.ToString());
            if (data != null)
            {
                CityCB = new ObservableCollection<ComboBoxModel>(data);
            }
        }
    }
}
