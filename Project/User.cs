using System;

namespace Project
{
    internal abstract class User
    {
        protected string fullName;
        protected string phoneNumber;

        public User()
        {
            // Беремо початкові значення тексту з json
            fullName = Program.config.UserUnknown;
            phoneNumber = Program.config.UserNoPhone;
        }

        public User(string fullName, string phoneNumber)
        {
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
        }

        public abstract void ShowUserRole();
    }
}