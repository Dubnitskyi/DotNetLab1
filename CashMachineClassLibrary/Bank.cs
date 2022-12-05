namespace CashMachineClassLibrary
{
    public class Bank
    {
        public string Name { get; set; }
        public List<AutomatedTellerMachine> CashMachines = new List<AutomatedTellerMachine>();
        public List<Account> Users = new List<Account>();

        public Bank(string name)
        {
            Name = name;
        }

        public void AddCashMachine(AutomatedTellerMachine cashMachine)
        {
            CashMachines.Add(cashMachine);
        }

        public void AddUser(Account user)
        {
            Users.Add(user);
        }

        public Account Authentication(string cardNumber, int pinCode)
        {
            foreach (Account user in Users)
                if (user.CardNumber == cardNumber)
                {
                    if (user.PinCode == pinCode)
                        return user;
                    return null;
                }
            return null;
        }
    }
}
