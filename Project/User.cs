namespace Project
{
    internal abstract class User
    {
        protected string fullName;
        protected string phoneNumber;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public User()
        {
            fullName = "Невідомий користувач";
            phoneNumber = "Не вказано";
        }

        public User(string fullName, string phoneNumber)
        {
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
        }

        public abstract void ShowUserRole();
    }
}