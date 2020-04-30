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
        BaseResponseModel ResetPwd();
        /// <summary>
        /// 退出
        /// </summary>
        BaseResponseModel Logout();
        /// <summary>
        /// 获取国家地区字典表
        /// </summary>
        List<controller_type> GetRegion(string level, string pid);
        /// <summary>
        /// 获取所有字典信息
        /// </summary>
        List<controller_type> GetAllDictionary();

        #region 用户操作接口
        /// <summary>
        /// 用户查询表
        /// </summary>
        List<ResponseUserInfoModel> SearchUser(RequestUserModel request);
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns>所有用户列表</returns>
        List<ResponseUserInfoModel> GetAllUserList();
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageSize">页数</param>
        /// <param name="pageNum">每页多少个</param>
        List<ResponseUserInfoModel> GetUserList(int pageSize, int pageNum);
        /// <summary>
        /// 添加用户信息
        /// </summary>
        BaseResponseModel AddUser(ResponseUserInfoModel request);
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
    }
}
