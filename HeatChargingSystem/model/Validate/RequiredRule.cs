using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HeatChargingSystem.model.Validate
{
    /// <summary>
    /// 是否为控制判断
    /// </summary>
    public class RequiredRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "该字段不能为空值！");
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "该字段不能为空字符串！");
            return new ValidationResult(true, null);
        }
    }

    public class NumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex numberReg = new Regex("[^0-9.-]+");

            if (!String.IsNullOrEmpty(value.ToString()))
            {
                if (!numberReg.IsMatch(value.ToString()))
                {
                    return new ValidationResult(false, "请填写数字！");
                }
            }
            return new ValidationResult(true, null);
        }
    }

    public class PhoneRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex phoneReg = new Regex(@"^0{0,1}(13[4-9]|15[7-9]|15[0-2]|18[7-8])[0-9]{8}$");

            if (!String.IsNullOrEmpty(value.ToString()))
            {
                if (!phoneReg.IsMatch(value.ToString()))
                {
                    return new ValidationResult(false, "手机格式不准确！");
                }
            }
            return new ValidationResult(true, null);
        }
    }

    /// <summary>
    /// 邮箱判断
    /// </summary>
    public class EmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex emailReg = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");

            if (!String.IsNullOrEmpty(value.ToString()))
            {
                if (!emailReg.IsMatch(value.ToString()))
                {
                    return new ValidationResult(false, "邮箱地址不准确！");
                }
            }
            return new ValidationResult(true, null);
        }
    }
}
