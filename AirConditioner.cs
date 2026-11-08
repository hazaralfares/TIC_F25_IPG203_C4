using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25
{
    // فئة فرعية تمثل المكيف ترث من الفئة المجردة 
    public class AirConditioner : Appliance
    {
        // (خاصية خاصة بالمكيف تعبر عن طاقة التبريد (بالطن
        public double CoolingCapacity { get; set; }

        // base باني الفئة لتهيئة البيانات الأساسية وخاصية المكيف باستخدام  
        public AirConditioner(string serialNumber, string brand, double baseRepairCost, double coolingCapacity) : base(serialNumber, brand, baseRepairCost)
        {
            CoolingCapacity = coolingCapacity;
        }

        //   إعادة تعريف دالة الفحص الخاصة بالمكيف
        public override void Diagnose()
        {
            Console.WriteLine($"Diagnosing air conditioner brand: {Brand}. Checking freon gas and filters");
        }

        //    إعادة تعريف دالة حساب تكلفة الإصلاح لإضافة تكلفة إضافية للقدرات العالية
        public override double CalculateRepairCost()
        {
            double cost = BaseRepairCost;
            if (CoolingCapacity > 2.0)
            {
                cost += 70; // تكلفة إضافية للمكيفات ذات القدرة العالية
            }
            return cost;
        }
    }
}