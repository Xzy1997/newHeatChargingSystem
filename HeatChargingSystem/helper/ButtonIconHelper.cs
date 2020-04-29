using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeatChargingSystem.helper
{
    public class ButtonIconHelper:ButtonHelper
    {
        #region IconOver
        public static object GetIconOver(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }

        public static void SetIconOver(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconOverProperty =
            DependencyProperty.RegisterAttached("IconOver", typeof(object), typeof(ButtonIconHelper));


        #endregion
    }
}
