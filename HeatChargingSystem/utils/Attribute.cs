using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.utils.Validation
{
    public class Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public class NotEmptyCheck : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var name = value as string;
                if (string.IsNullOrEmpty(name))
                {
                    return false;
                }
                return true;
            }

            public override string FormatErrorMessage(string name)
            {
                return "不能为空";
            }
        }

        /// <summary>
        /// 是否是数字
        /// </summary>
        public class IsNumber : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var name = value as string;
                if (string.IsNullOrEmpty(name))
                {
                    return false;
                }
                return true;
            }

            public override string FormatErrorMessage(string name)
            {
                return "不能为空";
            }
        }

        public class IsPhoneNumber : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var name = value as string;
                if (string.IsNullOrEmpty(name))
                {
                    return false;
                }
                return true;
            }

            public override string FormatErrorMessage(string name)
            {
                return "手机格式不正确";
            }
        }
    }
}
