using System;

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

        public void Deliver()
        {
            status = "доставляється";
            Console.WriteLine("Доставка здійснюється");
        }
    }
}
