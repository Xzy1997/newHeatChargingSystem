using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HeatChargingSystem.api;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model
{
    public class HomeViewModel : ViewModelBase
    {

        private ObservableCollection<ResponseUserInfoModel> _responseUserInfoModels;
        public RelayCommand AddResponseUserInfoModelCommand { get; set; }

        public RelayCommand<ResponseUserInfoModel> EditPersonCommand { get; set; }

        public RelayCommand CancellCommand { get; set; }

        public RelayCommand<RequestUserModel> SearchResponseUserInfoModels { get; set; }

        public ObservableCollection<ResponseUserInfoModel> ResponseUserInfoModels { get => _responseUserInfoModels; set => Set(ref _responseUserInfoModels, value); }
        public RequestUserModel RequestUserParams { get => requestUserParams; set => Set(ref requestUserParams,value); }
        public ObservableCollection<ComboBoxModel> ChargeCBXs { get => chargeCBXs; set => Set(ref chargeCBXs, value); }

        private RequestUserModel requestUserParams;


        private ObservableCollection<ComboBoxModel> chargeCBXs;
        public HomeViewModel()
        {
            List<ResponseUserInfoModel> data = new ApiImpl().GetAllUsers();
            ResponseUserInfoModels = new ObservableCollection<ResponseUserInfoModel>(data);
            SearchResponseUserInfoModels = new RelayCommand<RequestUserModel>(SearchUserInfo);
            requestUserParams = new RequestUserModel();
            chargeCBXs = new ObservableCollection<ComboBoxModel>(new ApiImpl().GetDictionary("缴费类型"));
        }

        private void SearchUserInfo(RequestUserModel request)
        {
            ResponseUserInfoModels= new ObservableCollection<ResponseUserInfoModel>( new ApiImpl().SearchUser(request));
        }
    }
}
