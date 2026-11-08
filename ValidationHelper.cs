using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25
{
    public static class ValidationHelper
    {
        ///  مخصصة للتحقق من صحة المدخلات (مثل النصوص والتكاليف)
        public static bool IsValidString(string value)
        {
            /// التحقق من أن النص المدخل غير فارغ أو غير معرف
            if (value != null && value.Length > 0)
            {
                return true;
            }
            return false;
        }
        //التحقق من أن التكلفة المدخلة قيمة صحيحة وموجبة(أكبر أو تساوي الصفر)
        public static bool IsValidCost(double cost)
        {
            return cost >= 0;
        }
    }
}
