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
            // Беремо дефолтні значення тексту з json
            address = Program.config.DeliveryNoAddress;
            status = Program.config.DeliveryStatusNone;
        }

        public Delivery(string address, string status)
        {
            this.address = address;
            this.status = status;
        }

        public void Deliver()
        {
            // Оновлюємо статус та вивід через конфіг
            status = Program.config.DeliveryStatusActive;
            Console.WriteLine(Program.config.DeliveryInProcess);
        }
    }
}