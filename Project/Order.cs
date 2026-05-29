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

        public Order(int orderNumber, Payment payment, Delivery delivery)
        {
            this.orderNumber = orderNumber;
            this.payment = payment;
            this.delivery = delivery;
            trackingNumber = GenerateTrackingNumber();
        }

        private string GenerateTrackingNumber()
        {
            Random random = new Random();
            // префікс ТТН тепер береться з конфігу
            return Program.config.TtnPrefix + random.Next(100000, 999999);
        }

        // 3 версія - булеві
        public bool IsPaidOrder()
        {
            return payment.IsPaid;
        }

        public bool HasDelivery()
        {
            return delivery != null;
        }

        // 3 версія - методи сценарію
        public void ConfirmOrder()
        {
            if (IsPaidOrder() && HasDelivery())
            {
                // збираємо рядок підтвердження через json змінні
                Console.WriteLine($"{Program.config.OrderConfirmedPrefix}{orderNumber}{Program.config.OrderConfirmedSuffix}");
            }
            else
            {
                // збираємо рядок помилки через json змінні
                Console.WriteLine($"{Program.config.OrderConfirmedPrefix}{orderNumber}{Program.config.OrderNotConfirmedSuffix}");
            }
        }
    }
}