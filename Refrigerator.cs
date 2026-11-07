using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25
{
    // فئة فرعية تمثل الثلاجة 
    public class Refrigerator : Appliance
    {
        // خاصية خاصة بالثلاجة لتحديد ما إذا كانت تحتوي على فريزر أم لا
        public bool HasFreezer { get; set; }

        // باني الفئة لتهيئة البيانات الأساسية وخاصية الفريزر باستخدام base
        public Refrigerator(string serialNumber, string brand, double baseRepairCost, bool hasFreezer) : base(serialNumber, brand, baseRepairCost)
        {
            this.HasFreezer = hasFreezer;
        }

        // إعادة تعريف دالة الفحص  الخاصة بالثلاجة لفحص نظام التبريد والضاغط
        public override void Diagnose()
        {
            Console.WriteLine("Diagnosing the refrigerator cooling system and compressor");
        }

        // إعادة تعريف دالة حساب تكلفة الإصلاح  لإضافة تكلفة إضافية لوجود الفريزر
        public override double CalculateRepairCost()
        {
            double totalCost = BaseRepairCost;
            if (HasFreezer)
            {
                totalCost += 50; // تكلفة إضافية للثلاجات التي تحتوي على فريزر
            }
            return totalCost;
        }
    }
}