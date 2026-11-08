using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F25
{
    // تعريف التفويض المخصص للإشعار بتغير الحالة أو إضافة جهاز
    public delegate void MaintenanceEventHandler(string message);

    internal class Program
    {
        // تعريف الحدث بناءً على الوكيل المعرف أعلاه
        public static event MaintenanceEventHandler OnApplianceAdded;

        // خاصية ساكنة لحساب العدد الإجمالي للأجهزة المسجلة في النظام
        public static int TotalApplianceCount { get; set; } = 0;

        static void Main(string[] args)
        {
            // الاشتراك في الحدث عبر ربطه بدالة عرض الإشعارات
            OnApplianceAdded += DisplayNotification;

            // قائمة من النمط الواجهي لاستخدام تعدد الأشكال ومعالجة الأجهزة معاً
            List<IRepairable> appliances = new List<IRepairable>();
            bool running = true;

            // حلقة تكرارية لإدارة عمليات إدخال الأجهزة وإدارتها
            while (running)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1- Add Refrigerator");
                Console.WriteLine("2- Add Washing Machine");
                Console.WriteLine("3- Add Air Conditioner");
                Console.WriteLine("4- Finish and Show Report");
                Console.Write("choice (1,2,3,4): ");

                string choice = Console.ReadLine();

                Console.Write("Enter Serial Number: ");
                string serial = Console.ReadLine();

                Console.Write("Brand: ");
                string brand = Console.ReadLine();

                Console.Write("Base Repair Cost: ");
                double baseCost = Convert.ToDouble(Console.ReadLine());

                if (choice == "4")
                {
                    running = false;
                    break;
                }

                // التحقق من صحة المدخلات باستخدام فئة التحقق الساكنة 
                if (ValidationHelper.IsValidString(serial) && ValidationHelper.IsValidString(brand) && ValidationHelper.IsValidCost(baseCost))
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Does it have a freezer? (yes/no): ");
                            string answer = Console.ReadLine();
                            bool hasFreezer = (answer == "yes");

                            // إضافة ثلاجة إلى القائمة وزيادة عداد الأجهزة الثابت
                            Refrigerator refrigerator = new Refrigerator(serial, brand, baseCost, hasFreezer);
                            appliances.Add(refrigerator);
                            TotalApplianceCount++;

                            // التحقق وإطلاق الحدث عند اكتمال إضافة الجهاز
                            if (OnApplianceAdded != null)
                            {
                                OnApplianceAdded("Refrigerator added successfully with serial: " + serial);
                            }
                            break;

                        case "2":
                            Console.Write("Enter Washing Capacity (kg): ");
                            int capacity = Convert.ToInt32(Console.ReadLine());

                            // إضافة غسالة إلى القائمة وزيادة العداد
                            WashingMachine washingMachine = new WashingMachine(serial, brand, baseCost, capacity);
                            appliances.Add(washingMachine);
                            TotalApplianceCount++;

                            // إطلاق الحدث الخاص بإضافة الغسالة
                            if (OnApplianceAdded != null)
                            {
                                OnApplianceAdded("Washing Machine added successfully with serial: " + serial);
                            }
                            break;

                        case "3":
                            Console.Write("Enter Cooling Capacity (tons): ");
                            double coolingCap = Convert.ToDouble(Console.ReadLine());


                            // إضافة مكيف إلى القائمة وزيادة العداد
                            AirConditioner myAc = new AirConditioner(serial, brand, baseCost, coolingCap);
                            appliances.Add(myAc);
                            TotalApplianceCount++;

                            // إطلاق الحدث الخاص بإضافة المكيف
                            if (OnApplianceAdded != null)
                            {
                                OnApplianceAdded("Air Conditioner added successfully with serial: " + serial);
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

        
            Console.WriteLine($"Total Registered Appliances: {TotalApplianceCount}");
           

            // المرور على جميع الأجهزة واستخدام تعدد الأشكال لفحصها وحساب تكاليف الإصلاح
            foreach (IRepairable appliance in appliances)
            {
                appliance.Diagnose();
                double cost = appliance.CalculateRepairCost();
                Console.WriteLine($"Final Cost: {cost} $");
                Console.WriteLine("----------------------------------------");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // دالة معالجة الحدث المطابقة لتوقيع الوكيل لعرض رسائل الإشعار
        public static void DisplayNotification(string message)
        {
            Console.WriteLine(" [EVENT NOTIFICATION]: " + message);
        }
    }
}