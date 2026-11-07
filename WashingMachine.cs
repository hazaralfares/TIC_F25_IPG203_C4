using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25
{
    // فئة فرعية تمثل الغسالة
    public class WashingMachine : Appliance
    {
        // خاصية خاصة بالغسالة تعبر عن سعة الغسيل بالكيلو
        public int Capacity { get; set; }

        // باني الفئة لتهيئة البيانات الأساسية وخاصية السعة باستخدام base
        public WashingMachine(string serialNumber, string brand, double baseRepairCost, int capacity) : base(serialNumber, brand, baseRepairCost)
        {
            Capacity = capacity;
        }

        // إعادة تعريف دالة الفحص الخاصة بالغسالة
        public override void Diagnose()
        {
            Console.WriteLine($"Diagnosing washing machine brand: {Brand}. Checking the wash tub and pump");
        }

        // إعادة تعريف دالة حساب تكلفة الإصلاح  لإضافة تكلفة إضافية للسعات الكبيرة
        public override double CalculateRepairCost()
        {
            double cost = BaseRepairCost;
            if (Capacity > 8)
            {
                cost += 40; // تكلفة إضافية للغسالات ذات السعة الكبيرة
            }
            return cost;
        }
    }
}