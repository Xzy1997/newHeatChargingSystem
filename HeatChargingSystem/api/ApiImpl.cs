using HeatChargingSystem.constants;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using HeatChargingSystem.utils;
using Newtonsoft.Json;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.api
{
    public class ApiImpl : IApi
    {
        public BaseResponseModel AddCardOperationLog()
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel AddUser(ResponseUserInfoModel request)
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel DelUser(string[] ids)
        {
            throw new NotImplementedException();
        }

        public void GetAllDictionary()
        {
            throw new NotImplementedException();
        }

        public List<ResponseUserInfoModel> GetAllUserList()
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel GetCardOPerationLog()
        {
            throw new NotImplementedException();
        }

        public void GetRegion()
        {
            throw new NotImplementedException();
        }

        public List<ResponseUserInfoModel> GetUserList(int pageSize, int pageNum)
        {
            throw new NotImplementedException();
        }

        public ResponseTokenModel Login(RequestLoginModel request)
        {
            string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_LOGIN_URI, JsonConvert.SerializeObject(request));
            BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
            if (responseModel.code.Equals("200"))
            {
                try
                {
                    ResponseTokenModel response = JsonConvert.DeserializeObject<ResponseTokenModel>(responseModel.data.ToString());
                    return response;
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public BaseResponseModel Logout()
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel ResetPwd()
        {
            throw new NotImplementedException();
        }

        public List<ResponseUserInfoModel> SearchUser(RequestUserModel request)
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel UpdateUser(ResponseUserInfoModel request)
        {
            throw new NotImplementedException();
        }
    }
}
