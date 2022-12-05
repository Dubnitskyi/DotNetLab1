namespace CashMachineClassLibrary
{
    public class Account
    {
        public string CardNumber { set; get; }
        public int PinCode { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public int Balance { set; get; }

        public Account(string cardNumber, int pinCode, string lastName, string firstName, int balance)
        {
            CardNumber = cardNumber;
            PinCode = pinCode;
            LastName = lastName;
            FirstName = firstName;
            Balance = balance;
        }
    }
}
