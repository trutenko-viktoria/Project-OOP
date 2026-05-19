using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ПІБ студента: Трутенко Вікторія Миколаївна");
            Console.WriteLine("Курс: 1");
            Console.WriteLine("Група: ІПЗ-11");
            Console.WriteLine("Варіант: 45");
            Console.WriteLine("Версія 1");
            Console.WriteLine("Старт імітації");

            //======================================
            Console.WriteLine("----- Перевірка класу Payment -----");

            Payment payment1 = new Payment();
            payment1.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment2 = new Payment(25000, false);
            payment2.ShowPaymentInfo();
            payment2.Pay();
            payment2.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment3 = new Payment(payment2);
            payment3.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment4 = new Payment(15000);
            payment4.ShowPaymentInfo();

            Console.WriteLine();
            //=============================================

            Console.WriteLine("Фініш імітації");
        }
    }
}
