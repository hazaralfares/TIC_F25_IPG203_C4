using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25
{
    // الواجهة الأساسية التي تحتوي على العمليات المشتركة لجميع الأجهزة
    public interface IRepairable
    {
        void Diagnose();
        double CalculateRepairCost();
    }

    // الفئة المجردة التي تطبق الواجهة وتحتوي على الخصائص المشتركة والدالة المجردة
    public abstract class Appliance : IRepairable
    {
        // حقول خاصة لتطبيق مبدأ التغليف 
        private string serialNumber;
        private string brand;
        private double baseRepairCost;

        // خاصية للقراءة فقط للرقم التسلسلي لضمان عدم تعديله بعد الإنشاء
        public string SerialNumber
        {
            get { return serialNumber; }
        }

        // خاصية للعلامة التجارية مع إمكانية الوصول والتعديل
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        // خاصية لتكلفة الإصلاح الأساسية مع إمكانية الوصول والتعديل
        public double BaseRepairCost
        {
            get { return baseRepairCost; }
            set { baseRepairCost = value; }
        }

        // باني الفئة المجردة  لتهيئة الخصائص الأساسية
        protected Appliance(string serialNumber, string brand, double baseRepairCost)
        {
            this.serialNumber = serialNumber;
            this.brand = brand;
            this.baseRepairCost = baseRepairCost;
        }

        // دالة افتراضية  للفحص الأساسي قابلة للتجاوز
        public virtual void Diagnose()
        {
            Console.WriteLine("Diagnosing basic appliance...");
        }

        // دالة مجردة يجب تجاوزها في الفئات الفرعية لحساب التكلفة
        public abstract double CalculateRepairCost();
    }
}