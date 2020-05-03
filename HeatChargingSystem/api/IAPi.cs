using HeatChargingSystem.model;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.api
{
    public interface IApi
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseTokenModel Login(RequestLoginModel request);
        /// <summary>
        /// 更改密码
        /// </summary>
        BaseResponseModel ResetPwd(string oldPwd,string newPwd);
        /// <summary>
        /// 退出
        /// </summary>
        BaseResponseModel Logout();
        /// <summary>
        /// 获取所有字典信息
        /// </summary>
        List<ComboBoxModel> GetDictionary(string typeName);

        #region 用户操作接口
        /// <summary>
        /// 用户查询表
        /// </summary>
        List<ResponseUserInfoModel> SearchUser(RequestUserModel request);
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns>所有用户列表</returns>
        List<ResponseUserInfoModel> GetAllUsers();
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageSize">页数</param>
        /// <param name="pageNum">每页多少个</param>
        List<ResponseUserInfoModel> GetUserList(int pageSize, int pageNum);
        /// <summary>
        /// 添加用户信息
        /// </summary>
        BaseResponseModel AddUser(ResponseUserInfoModel request) ;
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids">用户唯一识别码</param>
        /// <returns></returns>
        BaseResponseModel DelUser(string[] ids);
        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <returns></returns>
        BaseResponseModel UpdateUser(ResponseUserInfoModel request);
        #endregion
        /// <summary>
        /// 添加卡操作日志
        /// </summary>
        /// <returns></returns>
        BaseResponseModel AddCardOperationLog();
        /// <summary>
        /// 获取卡操作日志
        /// </summary>
        /// <returns></returns>
        BaseResponseModel GetCardOPerationLog();
        /// <summary>
        /// 获取省区域字典
        /// </summary>
        List<ComboBoxModel> GetProvinceRegion();
        /// <summary>
        /// 获取市地区信息
        /// </summary>
        List<ComboBoxModel> GetCityRegion(string id);
        /// <summary>
        /// 获取县/区地区信息
        /// </summary>
        List<ComboBoxModel> GetCountryRegion(string id);
        /// <summary>
        /// 获取街道地区信息
        /// </summary>
        List<ComboBoxModel> GetStreetRegion(string id);
        /// <summary>
        /// 获取小区域字典
        /// </summary>
        List<ComboBoxModel> GetVillageRegion(string id);
        /// <summary>
        /// 修改收费标准
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponseModel UpdateChargeStandar(RequestInformationModel request);
        /// <summary>
        /// 获取标准信息
        /// 收费和供暖时间
        /// </summary>
        /// <returns></returns>
        ResponseInformationModel GetInformation();
    }
}
