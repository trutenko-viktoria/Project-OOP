using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Delivery
    {
        private string address;
        private string status;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Status
        {
            get { return status; }
            private set { status = value; }
        }

        static Delivery()
        {
           // Console.WriteLine("Статичний конструктор Delivery");
        }

        private Delivery(bool isHidden)
        {
         //   Console.WriteLine("Закритий конструктор Delivery");
        }

        public Delivery()
        {
            address = "Адреса не вказана";
            status = "не оформлена";

           // Console.WriteLine("Конструктор без параметрів Delivery");
        }

        public Delivery(string address, string status)
        {
            this.address = address;
            this.status = status;

            // Console.WriteLine("Конструктор з параметрами Delivery");
        }

        public Delivery(Delivery other)
        {
            address = other.address;
            status = other.status;

         //   Console.WriteLine("Конструктор копіювання Delivery");
        }

        public Delivery(string address) : this()
        {
            this.address = address;

          //  Console.WriteLine("Конструктор з викликом іншого конструктора Delivery");
        }

        public void Deliver()
        {
            status = "доставляється";
            Console.WriteLine("Доставка здійснюється");
        }

        // 3 версія булеві
        public bool IsDelivered()
        {
            return status == "доставляється";
        }

        public bool HasAddress()
        {
            return address != "Адреса не вказана";
        }
        //3 версія - сценарію
        public void CompleteDelivery()
        {
            status = "доставлено";
            Console.WriteLine("Доставку завершено");
        }
        //

        public void ShowDeliveryInfo()
        {
            Console.WriteLine($"Адреса доставки: {address}");
            Console.WriteLine($"Статус доставки: {status}");
        }

    }
}
