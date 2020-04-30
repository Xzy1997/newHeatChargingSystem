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
            try
            {
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_ADD_USER_URI, JsonConvert.SerializeObject(request));
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                return responseModel;
            }
            catch (Exception)
            {

                throw;
            }                      
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
            try
            {
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_LOGIN_URI, JsonConvert.SerializeObject(request));
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel != null)
                {
                    if (responseModel.code.Equals("200"))
                    {
                        ResponseTokenModel response = JsonConvert.DeserializeObject<ResponseTokenModel>(responseModel.data.ToString());
                        return response;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
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
            try
            {
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_SEARCH_USER_RUI, JsonConvert.SerializeObject(request));
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel != null)
                {
                    if (responseModel.code.Equals("200"))
                    {
                        var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                        List<ResponseUserInfoModel> obj2 = arrdata.ToObject<List<ResponseUserInfoModel>>();
                        // List<ResponseUserInfoModel> obj2 = new List<ResponseUserInfoModel>();
                        // obj2.Add(new ResponseUserInfoModel());
                        Console.Write("11");
                        return obj2;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public BaseResponseModel UpdateUser(ResponseUserInfoModel request)
        {
            throw new NotImplementedException();
        }
    }
}
