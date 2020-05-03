using HeatChargingSystem.constants;
using HeatChargingSystem.model;
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
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_ADD_USER_URI, JsonConvert.SerializeObject(request), AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                return responseModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BaseResponseModel DelUser(string[] ids)
        {
            throw new NotImplementedException();
        }

        public List<ComboBoxModel> GetDictionary(string typeName)
        {
            try
            {
                string result = HttpUtils.GetRequest(AppConfigMoel.URL + ConstantsValue.HTTP_GETDICTIONARY_URI + typeName, AppConfigMoel.token);
                //Console.WriteLine(result);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                List<ComboBoxModel> obj2 = arrdata.ToObject<List<ComboBoxModel>>();
                return obj2;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ResponseUserInfoModel> GetAllUsers()
        {
            try
            {
                string url = AppConfigMoel.URL + ConstantsValue.HTTP_SEARCH_USER_URI;
                url = url + "?name=&controllerCode=&payStatus=";
                string result = HttpUtils.GetRequest(url, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel != null)
                {
                    if (responseModel.code.Equals("200"))
                    {
                        var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                        List<ResponseUserInfoModel> obj2 = arrdata.ToObject<List<ResponseUserInfoModel>>();
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


        public List<ResponseUserInfoModel> SearchUser(RequestUserModel request)
        {
            try
            {
                string url = AppConfigMoel.URL + ConstantsValue.HTTP_SEARCH_USER_URI;
                string str = url + "?name={0}&controllerCode={1}&payStatus={2}";
                str = String.Format(str, request.Name, request.ControllerCode, request.PayStatus);
                string result = HttpUtils.GetRequest(str, AppConfigMoel.token);
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

        public BaseResponseModel GetCardOPerationLog()
        {
            throw new NotImplementedException();
        }
        #region 获取地域字典
        public List<ComboBoxModel> GetCityRegion(string id)
        {
            try
            {
                string str = AppConfigMoel.URL + ConstantsValue.HTTP_GETREGION_CITY_URI;
                str = str + "?id={0}";
                string url = String.Format(str, id);
                string result = HttpUtils.GetRequest(url, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel.data != null && !string.IsNullOrEmpty(responseModel.data.ToString()))
                {
                    var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                    List<ComboBoxModel> obj2 = arrdata.ToObject<List<ComboBoxModel>>();
                    return obj2;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ComboBoxModel> GetCountryRegion(string id)
        {
            try
            {
                string str = AppConfigMoel.URL + ConstantsValue.HTTP_GETREGION_COUNTRY_URI;
                str = str + "?id={0}";
                string url = String.Format(str, id);
                string result = HttpUtils.GetRequest(url, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel.data != null && !string.IsNullOrEmpty(responseModel.data.ToString()))
                {
                    var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                    List<ComboBoxModel> obj2 = arrdata.ToObject<List<ComboBoxModel>>();
                    return obj2;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ComboBoxModel> GetProvinceRegion()
        {
            try
            {
                string url = AppConfigMoel.URL + ConstantsValue.HTTP_GETREGION_PROVINCE_URI;
                string result = HttpUtils.GetRequest(url, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel.data != null && !string.IsNullOrEmpty(responseModel.data.ToString()))
                {
                    var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                    List<ComboBoxModel> obj2 = arrdata.ToObject<List<ComboBoxModel>>();
                    return obj2;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ComboBoxModel> GetStreetRegion(string id)
        {
            try
            {
                string str = AppConfigMoel.URL + ConstantsValue.HTTP_GETREGION_STREET_URI;
                str = str + "?id={0}";
                string url = String.Format(str, id);
                string result = HttpUtils.GetRequest(url, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel.data != null && !string.IsNullOrEmpty(responseModel.data.ToString()))
                {
                    var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                    List<ComboBoxModel> obj2 = arrdata.ToObject<List<ComboBoxModel>>();
                    return obj2;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ComboBoxModel> GetVillageRegion(string id)
        {
            try
            {
                string str = AppConfigMoel.URL + ConstantsValue.HTTP_GETREGION_VILLAGE_URI;
                str = str + "?id={0}";
                string url = String.Format(str, id);
                string result = HttpUtils.GetRequest(url, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel.data != null && !string.IsNullOrEmpty(responseModel.data.ToString()))
                {
                    var arrdata = Newtonsoft.Json.Linq.JArray.Parse(responseModel.data.ToString());
                    List<ComboBoxModel> obj2 = arrdata.ToObject<List<ComboBoxModel>>();
                    return obj2;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
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

        public BaseResponseModel ResetPwd(string oldPwd, string newPwd)
        {
            try
            {
                RequestResetPwdModel request = new RequestResetPwdModel();
                request.OldPassword = oldPwd;
                request.NewPassword = newPwd;
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_RESET_PWD_URI, JsonConvert.SerializeObject(request), AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                return responseModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region 修改用户标准参数
        public BaseResponseModel UpdateChargeStandar(RequestInformationModel request)
        {
            try
            {
                string result = HttpUtils.PostRequest(AppConfigMoel.URL + ConstantsValue.HTTP_INFORMATION_UPDATE_CHARGE, JsonConvert.SerializeObject(request),AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                return responseModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseInformationModel GetInformation()
        {
            try
            {
                string result = HttpUtils.GetRequest(AppConfigMoel.URL + ConstantsValue.HTTP_INFORMATION_GET, AppConfigMoel.token);
                BaseResponseModel responseModel = JsonConvert.DeserializeObject<BaseResponseModel>(result);
                if (responseModel != null)
                {
                    if (responseModel.code.Equals("200"))
                    {
                        ResponseInformationModel response = JsonConvert.DeserializeObject<ResponseInformationModel>(responseModel.data.ToString());
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
        #endregion
    }
}
