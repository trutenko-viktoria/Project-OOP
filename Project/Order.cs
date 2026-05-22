using System;

namespace Project
{
    internal class Order
    {
        private int orderNumber;
        private Payment payment;
        private Delivery delivery;
        private string trackingNumber;

        public string TrackingNumber
        {
            get { return trackingNumber; }
            set { trackingNumber = value; }
        }

        public Order()
        {
            orderNumber = 0;
            payment = new Payment();
            delivery = new Delivery();

            // Console.WriteLine("Конструктор без параметрів Order");
        }

        public Order(int orderNumber, Payment payment, Delivery delivery)
        {
            this.orderNumber = orderNumber;
            this.payment = payment;
            this.delivery = delivery;
            trackingNumber = GenerateTrackingNumber();

            // Console.WriteLine("Конструктор з параметрами Order");
        }

        private string GenerateTrackingNumber()
        {
            Random random = new Random();

            return "TTN-" + random.Next(100000, 999999);
        }

        //3 версія - булеві
        public bool IsPaidOrder()
        {
            return payment.IsPaid;
        }

        public bool HasDelivery()
        {
            return delivery != null;
        }
        //3 версія -Box методи сценарію
        public void ConfirmOrder()
        {
            if (IsPaidOrder() && HasDelivery())
            {
                Console.WriteLine($"Замовлення №{orderNumber} підтверджено");
            }
            else
            {
                Console.WriteLine($"Замовлення №{orderNumber} не можна підтвердити");
            }
        }
        //
    }
}